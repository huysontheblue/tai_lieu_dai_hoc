#Region "Imports area"
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame

#End Region

''' <summary>
''' 修改者：田玉琳
''' 日期：20180929
''' 修改内容：整理修改，增加发送邮件
''' 增加预定发送日期
''' </summary>
''' <remarks></remarks>
Public Class FrmSystemFileManage

    Dim EditFlag As String
    Private Userid As String = VbCommClass.VbCommClass.UseId
    Private UserName As String = VbCommClass.VbCommClass.UseName
    Private FactoryAll As String = ""
    Private MailTo As String = "MES.IMS@luxshare-ict.com" 'MES.IMS@luxshare-ict.com
    Private MailTittle As String = ""
    Private MailContent As String = ""

#Region "事件"

    '初期化
    Private Sub FrmSystemFileManage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setToolControlStatus()
        setToolButtonStatus("0")
        Me.Refresh()
        Me.Tooluser.Text = Userid & "--" & UserName
        BindSortSet("fileclass", CobFileClass)
        GetMailTo()
        InitFactoryData()
        LoadDataInGrid()
    End Sub

    '新增
    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        EditFlag = "0"
        dtpEffectTime.Value = System.DateTime.Now
        Dim mControl As Control
        For Each mControl In Me.GroupBox1.Controls
            If TypeOf (mControl) Is TextBoxUL.TextBoxUL Then
                mControl.Text = ""
                mControl.Enabled = True
            ElseIf TypeOf (mControl) Is CheckBox Or TypeOf (mControl) Is Button Or TypeOf (mControl) Is ComboBox Then
                mControl.Enabled = True
            End If
        Next
        Me.ChkUsey.Checked = True

        SystemAutoGenNo()
        setToolButtonStatus("1")
    End Sub

    '保存上傳文件
    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        If Me.CobFileClass.SelectedIndex = -1 Then
            SetMessage("FAIL", "文件分類不能為空，請選擇文件分類")
            Me.CobFileClass.Focus()
            Exit Sub
        End If
        If Me.TxtFileName.Text = "" Then
            SetMessage("FAIL", "上傳文件不能為空，請選擇上傳文件")
            Me.ButFileView.Focus()
            Exit Sub
        End If
        If txtUpdatePJContent.Text.Trim = "" Then
            SetMessage("FAIL", "请填写修改项目!")
            Me.txtUpdatePJContent.Focus()
            Exit Sub
        End If
        If TxtMeno.Text.Trim = "" Then
            SetMessage("FAIL", "请填写备注原因!")
            Me.TxtMeno.Focus()
            Exit Sub
        End If

        If EditFlag = "0" Then
            SaveFileToDataBase()
        Else
            ModifyFileData()
        End If
        ToolRefesh_Click(sender, e)
    End Sub

    '编辑
    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        If Me.DGridBarCode.Rows.Count < 1 Then Exit Sub
        EditFlag = "1"
        dtpEffectTime.Value = System.DateTime.Now
        setToolButtonStatus("1")
        Me.CobFileClass.Enabled = True
        Me.TxtMeno.Enabled = True
        Me.ChkUsey.Enabled = True
    End Sub

    '撤销
    Private Sub ToolUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolUndo.Click
        setToolButtonStatus("1")
        setToolControlStatus()
        SetGridValueInControl()
    End Sub

    '刷新
    Private Sub ToolRefesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefesh.Click
        LoadDataInGrid()
        SetGridValueInControl()
    End Sub

    '设置数据
    Private Sub DGridBarCode_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridBarCode.CellClick
        SetGridValueInControl()
    End Sub

    '作废
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        Try
            If TxtMeno.Text.Trim = "" Then
                SetMessage("FAIL", "作廢文件请填写备注原因......")
                TxtMeno.Focus()
                Exit Sub
            End If
            If TxtMeno.Text.Trim <> "" Then
                Dim strSQL As String = "update M_SystemFile_t set usey='N',remark=remark+'['+N'" & Me.TxtMeno.Text &
                                       "'+N' 作废时间：'+CONVERT(varchar(100), GETDATE(), 121)+N' 操作人：'+'" & Userid &
                                       "'+']' where fileno='" & Me.TxtFileNo.Text & "'"
                DbOperateUtils.ExecSQL(strSQL)
                LoadDataInGrid()
                SetMessage("PASS", "作廢文件成功......")

                '邮件标题：SFC公用版本-程序发布通告-加日期-发布人
                'MailTittle = String.Format("SFC公用版本-程序发布通告(作废)-{0}-{1}", System.DateTime.Today.ToLongDateString, UserName)
                MailTittle = String.Format("SFC程序发布(作废):{0}-{1}-{2}-{3}", txtProjectCode.Text, txtUpdatePJContent.Text,
                                           System.DateTime.Now.ToLongDateString, UserName)

                '邮件内容：发布ID，DLL名称，DLL版本，修改人，修改时间，备注，生效时间；
                'MailContent = "发布ID:{0};<p>DLL名称:{1};<p>DLL版本:{2};<p>修改人:{3};<p>修改时间:{4};<p>备注:{5};<p>生效时间:{6}<p>"
                Dim tempContent As String = MailContent
                tempContent = String.Format(MailContent, "SFC", FactoryAll, txtBU.Text, txtProjectCode.Text, txtDongBie.Text, txtUpdatePJContent.Text,
                                            TxtFileName.Text, TxtVerNo.Text, dtpEffectTime.Value.ToString, UserName + "(" + Userid + ")", TxtMeno.Text,
                                            System.DateTime.Now.ToString)

                MailUtils.SeedMail(MailTo, MailTittle, tempContent)

            End If

        Catch ex As Exception
            SetMessage("FAIL", "作廢文件失敗......")
        End Try
    End Sub

    '浏览上传文件
    Private Sub ButFileView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFileView.Click
        Me.OpenFileDialog1.ShowDialog()
        Me.OpenFileDialog1.Multiselect = False
    End Sub

    '退出子窗體
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    '查询
    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        LoadDataInGrid()
        SetGridValueInControl()
    End Sub

    '查询
    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            ToolQuery_Click(sender, e)
        End If
    End Sub

    '浏览
    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Me.TxtFileName.Text = Me.OpenFileDialog1.FileName.Substring(Me.OpenFileDialog1.FileName.LastIndexOf("\") + 1)
        Me.TxtFilePathName.Text = Me.OpenFileDialog1.FileName
        Dim LoacalFileModifyDateTime As String = File.GetLastWriteTime(Me.TxtFilePathName.Text)
        Me.TxtFileModifyDate.Text = File.GetLastWriteTime(Me.TxtFilePathName.Text).ToString("yyyy/MM/dd HH:mm:ss")
        If FileVersionInfo.GetVersionInfo(Me.TxtFilePathName.Text).FileVersion Is Nothing Then
            Me.TxtVerNo.Text = ""
        Else
            Me.TxtVerNo.Text = FileVersionInfo.GetVersionInfo(Me.TxtFilePathName.Text).FileVersion.ToString()
        End If
        Me.TxtIntime.Text = Now()
        Me.TxtUserid.Text = Userid & "---" & UserName
        Me.ChkUsey.Checked = True
        Me.TxtMeno.Focus()
    End Sub

    '上传说明文件
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim odf As OpenFileDialog = New OpenFileDialog()
        If odf.ShowDialog() = DialogResult.OK Then
            LinkLbl.Text = odf.FileName
        End If
    End Sub

    'grid双击点开说明文件
    Private Sub DGridBarCode_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridBarCode.CellDoubleClick
        If DGridBarCode.Columns(e.ColumnIndex).Name = "ColfileName" Then
            Dim dgvr As DataGridViewRow = DGridBarCode.Rows(e.RowIndex)
            Dim FileName = dgvr.Cells("ColfileName").Value.ToString()
            Dim yyyyMMdd = Convert.ToDateTime(dgvr.Cells("ColTime").Value.ToString()).ToString("yyyyMMdd")
            Dim FullPath = GetMyFolder(FileName + "\" + yyyyMMdd)
            If Directory.Exists(FullPath) Then
                System.Diagnostics.Process.Start(FullPath)
            End If
        End If
    End Sub

#End Region

#Region "方法"

    '设置下拉数据
    Public Shared Sub BindSortSet(ByVal SortType As String, ByVal Ctrl As Object)
        BindCombox(String.Format("select SortID,SortName from m_Sortset_t where SortType='{0}' and usey='Y' order by Orderid", SortType), Ctrl, "SortName", "SortID")
    End Sub

    '共通
    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub

    '自動生成單據編號
    Private Sub SystemAutoGenNo()
        Dim mDataReader As DataTable = DbOperateUtils.GetDataTable("select case when max(fileno) is null then'1001' else max(fileno)+1 end as maxno from M_SystemFile_t")
        If mDataReader.Rows.Count > 0 Then
            Me.TxtFileNo.Text = mDataReader.Rows(0)!maxno.ToString
        End If
    End Sub

    '取得发送邮件地址,和发送格式地址
    Private Sub GetMailTo()
        Dim strSQL As String = "select PARAMETER_CODE,PARAMETER_VALUES from m_SystemSetting_t where MODE_NAME='MES' and PARAMETER_CODE in ('AlertEmailList','AlertEmailFormat') "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            Select Case dt.Rows(rowIndex).Item(0).ToString.ToUpper()
                Case "AlertEmailList".ToUpper()
                    MailTo = dt.Rows(rowIndex).Item(1).ToString
                Case "AlertEmailFormat".ToUpper()
                    MailContent = dt.Rows(rowIndex).Item(1).ToString
            End Select
        Next
    End Sub

    '初始化长区信息
    Private Sub InitFactoryData()
        Dim sql As String = "SELECT Shortname+','  from m_Dcompany_t WHERE usey = 'Y' FOR XML PATH('')"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            FactoryAll = dt.Rows(0)(0).ToString
            If Len(FactoryAll) > 1 Then
                FactoryAll = FactoryAll.Substring(0, Len(FactoryAll) - 1)
            End If
        End If
    End Sub

    '初始化GRID
    Private Sub LoadDataInGrid()
        Dim strSQL As String =
            " select fileno,[filename]," &
            " (select SortName from m_sortset_t sortset where SortType='fileclass' and SortID = fileclass ) fileclass," &
            " fileversion,usey,isnull(remark,'')remark," &
            " (select username from m_Users_t users where sysfile.userid = users.UserID)userid ,intime,Updateuser=(select username from m_Users_t users where sysfile.Updateuser = users.UserID),Updatetime,EffectTime,BU,ProjectCode,UpdatePJContent,DONGBIE  " &
            " from M_SystemFile_t sysfile"
        If String.IsNullOrEmpty(Me.TxtSearch.Text) = False Then
            strSQL = strSQL + String.Format(" where [filename] like '%{0}%' ", Me.TxtSearch.Text)
        End If
        strSQL = strSQL + " order by Fileno desc"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Me.DGridBarCode.DataSource = dt

        SetGridValueInControl()
    End Sub

    '修改文件数据
    Private Sub ModifyFileData()
        Try
            Dim str As String =
                        "update M_SystemFile_t set fileclass='" & Me.CobFileClass.SelectedValue + "'" &
                        ", BU = N'" & txtBU.Text & "', ProjectCode = N'" & txtProjectCode.Text & "', DONGBIE=N'" & txtDongBie.Text & "'" &
                        ", UpdatePJContent = N'" & txtUpdatePJContent.Text & "', EffectTime = '" + dtpEffectTime.Value.ToString + "'" &
                        ", usey='" & IIf(Me.ChkUsey.Checked, "Y", "N") & "',filetime=getdate(),updatetime=getdate(),remark='['+N'" &
                        Me.TxtMeno.Text & "'+N' 修改时间：'+CONVERT(varchar(100), GETDATE(), 121)+N' 修改人：'+'" & Userid & "'+']' where fileno='" &
                        Me.TxtFileNo.Text & "'"
            DbOperateUtils.ExecSQL(str)
            SetMessage("PASS", "修改文件成功......")
            setToolButtonStatus("1")

            '邮件标题：SFC公用版本-程序发布通告-加日期-发布人
            'MailTittle = String.Format("SFC公用版本-程序发布通告(修改)-{0}-{1}", System.DateTime.Today.ToLongDateString, UserName)
            MailTittle = String.Format("SFC程序发布(修改):{0}-{1}-{2}-{3}", txtProjectCode.Text, txtUpdatePJContent.Text,
                                       System.DateTime.Now.ToLongDateString, UserName)

            '邮件内容：发布ID，DLL名称，DLL版本，修改人，修改时间，备注，生效时间；
            'MailContent = "发布ID:{0};<p>DLL名称:{1};<p>DLL版本:{2};<p>修改人:{3};<p>修改时间:{4};<p>备注:{5};<p>生效时间:{6}<p>"
            Dim tempContent As String = MailContent
            tempContent = String.Format(MailContent, "SFC", FactoryAll, txtBU.Text, txtProjectCode.Text, txtDongBie.Text, txtUpdatePJContent.Text,
                                        TxtFileName.Text, TxtVerNo.Text, dtpEffectTime.Value.ToString, UserName + "(" + Userid + ")", TxtMeno.Text,
                                        System.DateTime.Now.ToString)

            MailUtils.SeedMail(MailTo, MailTittle, tempContent)

        Catch ex As Exception
            SetMessage("FAIL", "修改文件失敗......" + ex.Message.ToString)
        End Try

    End Sub

    Private Sub setToolControlStatus()
        Me.CobFileClass.Enabled = False
        Me.ButFileView.Enabled = False
        Me.DGridBarCode.Enabled = True
        EditFlag = ""
        Me.ChkUsey.Enabled = False
    End Sub

    '保存数据,新增
    Private Sub SaveFileToDataBase()
        Dim FsFile(0) As FileStream
        Dim Parmter As SqlClient.SqlParameter() = New SqlClient.SqlParameter(0) {}

        FsFile(0) = New FileStream(Me.TxtFilePathName.Text, FileMode.Open, FileAccess.Read)
        Dim Data(FsFile(0).Length) As Byte
        FsFile(0).Read(Data, 0, Int(FsFile(0).Length))
        Dim size As Int32 = FsFile(0).Length
        Parmter(0) = New SqlClient.SqlParameter("@File", Data)
        Try
            DbOperateUtils.ExecSqlAddParameter("update M_SystemFile_t set usey='N' where filename='" & Me.TxtFileName.Text & "' " & vbNewLine &
                                    "insert into M_SystemFile_t(fileno,filename,fileclass,fileversion,filetime,usey,remark,userid,intime,updateuser," &
                                    "updatetime,Size,EffectTime,BU,ProjectCode,UpdatePJContent,DONGBIE,filecontent) values('" &
                                    TxtFileNo.Text & "','" & TxtFileName.Text & "','" &
                                    Me.CobFileClass.SelectedValue & "','" & Me.TxtVerNo.Text & "','" & TxtFileModifyDate.Text & "','Y',N'" &
                                    TxtMeno.Text & "','" & Userid & "',getdate(),'" & Userid & "',getdate(),'" & size & "','" &
                                    dtpEffectTime.Value.ToString & "',N'" & txtBU.Text & "',N'" & txtProjectCode.Text & "' ,N'" & txtUpdatePJContent.Text &
                                    "',N'" & txtDongBie.Text & "',@File)", Parmter)
            SetMessage("PASS", "保存文件成功......")
            setToolControlStatus()
            setToolButtonStatus("1")
            LoadDataInGrid()
            Me.DGridBarCode.Enabled = True

            '邮件标题：SFC公用版本-程序发布通告-加日期-发布人
            MailTittle = String.Format("SFC程序发布(新增):{0}-{1}-{2}-{3}", txtProjectCode.Text, txtUpdatePJContent.Text,
                                       System.DateTime.Now.ToLongDateString, UserName)

            '邮件内容：发布ID，DLL名称，DLL版本，修改人，修改时间，备注，生效时间；
            'MailContent = "发布ID:{0};<p>DLL名称:{1};<p>DLL版本:{2};<p>修改人:{3};<p>修改时间:{4};<p>备注:{5};<p>生效时间:{6}<p>"
            Dim tempContent As String = MailContent
            tempContent = String.Format(MailContent, "SFC", FactoryAll, txtBU.Text, txtProjectCode.Text, txtDongBie.Text, txtUpdatePJContent.Text,
                                        TxtFileName.Text, TxtVerNo.Text, dtpEffectTime.Value.ToString, UserName + "(" + Userid + ")", TxtMeno.Text,
                                        System.DateTime.Now.ToString)

            MailUtils.SeedMail(MailTo, MailTittle, tempContent)
            UpLoadFile()
        Catch ex As Exception
            SetMessage("FAIL", "保存文件失敗......")
        End Try
    End Sub

    ''' <summary>
    ''' 自定义文件夹
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMyFolder(ByVal FileName As String) As String
        Dim FolderPath As String = ""
        Dim SqlserverName As String = MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName
        If SqlserverName.Contains("DG-MESDB.luxshare.com.cn") Then
            FolderPath = "\\192.168.20.123\SFCDeploy\" + FileName
        Else
            FolderPath = "D:\SFCDeploy\" + FileName
        End If
        Return FolderPath
    End Function


    ''' <summary>
    ''' 上传更新文件说明图片
    ''' add by 马跃平
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpLoadFile()
        Try
            Dim FolderPath As String = ""
            Dim FileName As String = ""
            Dim UserName As String = VbCommClass.VbCommClass.UseName
            If String.IsNullOrEmpty(LinkLbl.Text.Trim()) = False Then
                FolderPath = GetMyFolder(TxtFileName.Text.Trim()) + "\" + Date.Now.ToString("yyyyMMdd") + "\"
                If Directory.Exists(FolderPath) = False Then
                    Directory.CreateDirectory(FolderPath)
                End If
                FileName = Date.Now.ToString("yyyyMMddHHmmss") + UserName + "_" + LinkLbl.Text.Substring(LinkLbl.Text.LastIndexOf("\") + 1)
                Dim by As Byte() = File.ReadAllBytes(LinkLbl.Text.Trim())
                File.WriteAllBytes(FolderPath + FileName, by)
            End If


            If ChkBoxNotice.Checked = True Then

                Dim Notice As System.Text.StringBuilder = New System.Text.StringBuilder()
                Notice.AppendLine(TxtMeno.Text)
                'If String.IsNullOrEmpty(LinkLbl.Text.Trim()) = False Then
                '    Notice.AppendLine("<a href='" & FolderPath + FileName & "'>" & TxtFileName.Text.Trim() & "</a>")
                'End If
                Dim by As Byte() = System.Text.Encoding.UTF8.GetBytes(Notice.ToString())

                Dim paras(0) As SqlParameter
                paras(0) = New SqlParameter("@richText", by)

                Dim sql As System.Text.StringBuilder = New System.Text.StringBuilder()
                sql.AppendLine("update m_Advert_t set usey='N' ")
                sql.AppendLine("insert into m_Advert_t (title,contents,dtstart,dtend,usey,intime) " & vbCrLf &
                "values(N'SFC公用版本-程序发布通告',N'" & TxtMeno.Text & "',getdate(),dateadd(day,2,getdate()),'Y',getdate() ) ")
                sql.AppendLine("select @@identity ")
                Dim ID As Integer = Convert.ToInt32(DbOperateUtils.GetDataTable(sql.ToString()).Rows(0)(0))
                sql = New System.Text.StringBuilder()
                sql.AppendLine("insert into m_richAdv_t (richID,richText,inTime) values(" & ID & ",@richText,getdate())")
                DbOperateUtils.ExecSqlAddParameter(sql.ToString(), paras)
            End If

            ChkBoxNotice.Checked = False

            LinkLbl.Text = Nothing
        Catch ex As Exception

        End Try
    End Sub

    '设置数据
    Private Sub SetGridValueInControl()
        If Me.DGridBarCode.Rows.Count < 1 Then Exit Sub

        Me.TxtFileNo.Text = DGridBarCode.CurrentRow.Cells("ColID").Value.ToString
        Me.TxtFileName.Text = DGridBarCode.CurrentRow.Cells("ColfileName").Value.ToString
        CobFileClass.SelectedIndex = CobFileClass.FindString(DGridBarCode.CurrentRow.Cells("ColFileType").Value.ToString)
        ' Me.CobFileClass.Text = DGridBarCode.CurrentRow.Cells("ColFileType").Value.ToString
        Me.ChkUsey.Checked = IIf(DGridBarCode.CurrentRow.Cells("ColUsey").Value.ToString = "Y", True, False)
        Me.TxtUserid.Text = DGridBarCode.CurrentRow.Cells("ColUser").Value.ToString
        Me.TxtIntime.Text = DGridBarCode.CurrentRow.Cells("ColTime").Value.ToString
        Me.TxtVerNo.Text = DGridBarCode.CurrentRow.Cells("ColVersion").Value.ToString
        Me.TxtMeno.Text = DGridBarCode.CurrentRow.Cells("ColMeno").Value.ToString
        Me.TxtFileModifyDate.Text = DGridBarCode.CurrentRow.Cells("Updatetime").Value.ToString
        Me.dtpEffectTime.Value = DGridBarCode.CurrentRow.Cells("EffectTime").Value.ToString
        Me.txtDongBie.Text = DGridBarCode.CurrentRow.Cells("DONGBIE").Value.ToString
        Me.txtBU.Text = DGridBarCode.CurrentRow.Cells("BU").Value.ToString
        Me.txtProjectCode.Text = DGridBarCode.CurrentRow.Cells("ProjectCode").Value.ToString
        Me.txtUpdatePJContent.Text = DGridBarCode.CurrentRow.Cells("UpdatePJContent").Value.ToString


    End Sub

    '设置状态
    Private Sub setToolButtonStatus(ByVal Flag As String)
        If Flag = "0" Then
            Me.ToolNew.Enabled = True
            Me.ToolEdit.Enabled = True
            Me.ToolQuery.Enabled = True
            Me.ToolUndo.Enabled = False
            Me.ToolCancel.Enabled = True
            Me.ToolSave.Enabled = False
            Me.ToolRefesh.Enabled = True
            Me.DGridBarCode.Enabled = True
            Me.TxtSearch.ReadOnly = False
        Else
            Me.ToolNew.Enabled = Not Me.ToolNew.Enabled
            Me.ToolEdit.Enabled = Not Me.ToolEdit.Enabled
            Me.ToolQuery.Enabled = Not Me.ToolQuery.Enabled
            Me.ToolUndo.Enabled = Not Me.ToolUndo.Enabled
            Me.ToolCancel.Enabled = Not Me.ToolCancel.Enabled
            Me.ToolSave.Enabled = Not Me.ToolSave.Enabled
            Me.ToolRefesh.Enabled = Not Me.ToolRefesh.Enabled
            Me.DGridBarCode.Enabled = Not Me.DGridBarCode.Enabled
            Me.TxtSearch.ReadOnly = Not Me.TxtSearch.ReadOnly
        End If
    End Sub

    '设置信息
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            LblResult.Text = message
            LblResult.ForeColor = Color.Crimson
            LblResult.ForeColor = Color.Crimson
        Else
            LblResult.Text = message
            LblResult.ForeColor = Color.FromArgb(0, 192, 0)
            LblResult.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub


#End Region


End Class