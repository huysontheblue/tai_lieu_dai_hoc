#Region "Inports 區"

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.IO


#End Region
Public Class FrmTestTypePT
    Const DgColZero As Integer = 0
    Const DgColOne As Integer = 1
    Const DgColTwo As Integer = 2
    Const DgColThree As Integer = 3

    Dim CanCelFlag As Boolean
    Dim FlagObj As DataGridView

    Dim strFileName As String


#Region "退出窗體"

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click

        Me.Close()

    End Sub

#End Region

#Region "Tab轉換Enter"
    Private Sub FrmTestTypePT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim TabTrans As New TextHandle
        TabTrans.TabTransEnter(sender, e)
        TabTrans = Nothing
    End Sub
#End Region


#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub dgScanShow_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgWorkSit.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

#Region "窗體初始化"

    Private Sub FrmTestTypePT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetToolButtonStutas(False)
        TextHandle.ControlIsEnable(Me, True)
        IsEnableObj(Me, False)
        'TextHandle.ControlIsEnable(Me, False)
        'LoadDataToStationGrid()
        LaodDataInControl(Me.DgWorkSit)
        'Me.DgWorkSit.Enabled = True



    End Sub

#End Region

#Region "指定類型的控件是否可用"

    Private Sub IsEnableObj(ByVal CtrlParent As Control, ByVal IsEnable As Boolean)
        Dim i As Int16 = 0
        Dim Ctrl As Control
        For Each Ctrl In CtrlParent.Controls
            If TypeOf Ctrl Is TextBox OrElse TypeOf Ctrl Is RichTextBox OrElse TypeOf Ctrl Is ComboBox OrElse TypeOf Ctrl Is CheckBox OrElse TypeOf Ctrl Is GroupBox Then
                Ctrl.Enabled = IsEnable
                'i += 1
            End If
        Next
    End Sub
#End Region

#Region "Load數據到DgStation表格"

    Private Sub LoadDataToStationGrid()

        Dim K As Integer
        Dim UserDg As DataTable
        Dim DataHand As New SysDataBaseClass

        DgWorkSit.Rows.Clear()
        UserDg = DataHand.GetDataTable("Select  * from m_TestType_t")
        For K = 0 To UserDg.Rows.Count - 1
            DgWorkSit.Rows.Add(UserDg.Rows(K)("TestTypeID"), UserDg.Rows(K)("TestTypeName"), UserDg.Rows(K)("UploadY"), UserDg.Rows(K)("DefaultSaveWay"), UserDg.Rows(K)("DocumentType"), UserDg.Rows(K)("IsMultFolder"), UserDg.Rows(K)("GetMethod"), UserDg.Rows(K)("GetRate"), UserDg.Rows(K)("InSertSql"), UserDg.Rows(K)("SelectSql"), UserDg.Rows(K)("TestParamList"), UserDg.Rows(K)("SaveTableName"), UserDg.Rows(K)("Usey"), UserDg.Rows(K)("Userid"), UserDg.Rows(K)("Intime"))
        Next
        DataHand = Nothing
        UserDg.Dispose()

    End Sub

#End Region


#Region "單擊主表格控件時,對應的表格行數據顯示在對應的編輯控件中"

    Private Sub LaodDataInControl(ByVal DataGridObj As DataGridView) ''表格里的數據顯示在對應的非表格控件中

        If DataGridObj.RowCount < 1 Then Exit Sub
        TxtTestTypeID.Text = DataGridObj.CurrentRow.Cells(0).Value.ToString
        TxtTestTypeName.Text = DataGridObj.CurrentRow.Cells(1).Value.ToString
        If DataGridObj.CurrentRow.Cells(2).Value.ToString <> "" Then
            CbxUploadY.Checked = IIf(DataGridObj.CurrentRow.Cells(2).Value = "Y", True, False)
        End If

        TxtDefaultSaveWay.Text = DataGridObj.CurrentRow.Cells(3).Value.ToString
        TxtDocumentType.Text = DataGridObj.CurrentRow.Cells(4).Value.ToString
        CbxIsMultFolder.Checked = IIf(DataGridObj.CurrentRow.Cells(5).Value = "Y", True, False)
        Me.RadFixedTime.Checked = IIf(DataGridObj.CurrentRow.Cells(6).Value = "1", True, False)
        Me.RadFrequentTime.Checked = IIf(DataGridObj.CurrentRow.Cells(6).Value = "1", True, False)
        DUpWhen.Text = IIf(RadFixedTime.Checked = True, DataGridObj.CurrentRow.Cells(7).Value.Substring(0, DataGridObj.CurrentRow.Cells(7).Value.IndexOf(":")), "")
        DUpPoints.Text = IIf(RadFixedTime.Checked = True, DataGridObj.CurrentRow.Cells(7).Value.Substring(3, DataGridObj.CurrentRow.Cells(7).Value.IndexOf(":")), "")
        DUpSeconds.Text = IIf(RadFixedTime.Checked = True, DataGridObj.CurrentRow.Cells(7).Value.Substring(6, DataGridObj.CurrentRow.Cells(7).Value.IndexOf(":")), "")

        DUpWhen1.Text = IIf(RadFrequentTime.Checked = True, DataGridObj.CurrentRow.Cells(7).Value.Substring(0, DataGridObj.CurrentRow.Cells(7).Value.IndexOf(":")), "")
        DUpPoints1.Text = IIf(RadFrequentTime.Checked = True, DataGridObj.CurrentRow.Cells(7).Value.Substring(3, DataGridObj.CurrentRow.Cells(7).Value.IndexOf(":")), "")
        DUpSeconds1.Text = IIf(RadFrequentTime.Checked = True, DataGridObj.CurrentRow.Cells(7).Value.Substring(6, DataGridObj.CurrentRow.Cells(7).Value.IndexOf(":")), "")

        TxtInSertSql.Text = DataGridObj.CurrentRow.Cells(8).Value.ToString
        TxtSelecttSql.Text = DataGridObj.CurrentRow.Cells(9).Value.ToString
        TxtTestParamList.Text = DataGridObj.CurrentRow.Cells(10).Value.ToString
        TxtSaveTableName.Text = DataGridObj.CurrentRow.Cells(11).Value.ToString
        CbxUsey.Checked = IIf(DataGridObj.CurrentRow.Cells(12).Value = "Y", True, False)


    End Sub

#End Region

#Region "設置工具欄上按鈕的狀態"

    Private Sub SetToolButtonStutas(ByVal Flag As Boolean)

        Dim RtoolControl As ToolStripItem
        For Each RtoolControl In Me.ToolSitSet.Items
            If Flag = False Then
                If RtoolControl.Tag <> "chang" And RtoolControl.Tag <> "" Then
                    RtoolControl.Enabled = False
                Else
                    RtoolControl.Enabled = True
                End If

            Else
                If RtoolControl.Tag <> "chang" Then
                    RtoolControl.Enabled = True
                Else
                    RtoolControl.Enabled = False
                End If
                Me.TxtSpart.Enabled = False
            End If
        Next

    End Sub

#End Region

#Region "新增"
    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click

        'Dim MoHandle As New SysDataBaseClass

        SysMessageClass.EditFlag = False ''新增


        'Dim GetMaxCustid As SqlDataReader
        'GetMaxCustid = MoHandle.GetDataReader("SELECT 'T'+right('0000'+cast(cast(right(max(TestTypeID),4)as int)+1 as varchar),4) MaxCusId from m_TestType_t ")
        'While GetMaxCustid.Read()
        '    Me.TxtTestTypeID.Text = GetMaxCustid("MaxCusId").ToString
        'End While
        TextHandle.ClearControl(Me)


        IsEnableObj(Me, True)
        TextHandle.ControlIsEnable(Me, False)
        SetToolButtonStutas(True)
        TxtTestTypeID.Enabled = False
        Me.DgWorkSit.Enabled = False
        RadFrequentTime.Checked = True
        DUpWhen.Text = "01"
        DUpPoints.Text = "01"
        DUpSeconds.Text = "01"


        DUpWhen1.Text = "01"
        DUpPoints1.Text = "01"
        DUpSeconds1.Text = "01"

    End Sub
#End Region

#Region "保存"

    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Try
            SaveRecordToServer()
            'IsEnableObj(Me, False)
            'TextHandle.ControlIsEnable(Me, True)
          
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub


#End Region


#Region "保存數據過程"

    Private Sub SaveRecordToServer()

        If Me.TxtTestTypeID.Text.Trim = "" Then
            MessageBox.Show("該料號不存在測試編號，請檢查料件站點設置資料...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If TxtTestTypeName.Text.Trim = "" Then
            MessageBox.Show("編號名稱不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtTestTypeName.Focus()
            Exit Sub
        End If
        If Me.TxtSaveTableName.Text.Trim = "" Then
            MessageBox.Show("保存的數據表不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtSaveTableName.Focus()
            Exit Sub
        End If

        Dim MoHandle As New SysDataBaseClass
        Dim SqlStr As String
        Try
            SqlStr = GetSqlString()
            If SqlStr = "" Then Exit Sub
            MoHandle.ExecSql(SqlStr)
            LoadDataToStationGrid()
            LaodDataInControl(Me.DgWorkSit)
            MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            SetToolButtonStutas(False)
            DgWorkSit.Enabled = True
            SetToolButtonStutas(False)
            TextHandle.ControlIsEnable(Me, True)
            IsEnableObj(Me, False)
            Me.TxtSpart.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Finally
            MoHandle = Nothing
        End Try

    End Sub

#End Region

#Region "獲取維護時的sql語句"
    Private Function GetSqlString() As String

        Dim SqlItemStr As String = ""
        'Dim ChanNoStr As String

        'If TxtSitId.Text.Trim <> "" Then
        '    ChanNoStr = TxtSitId.Text.Trim
        'Else
        '    If Me.CobType.SelectedIndex = 0 Then
        '        ChanNoStr = Me.TxtSitId.Text.Trim
        '    Else
        '        ChanNoStr = AotoGenChanNo("ST")
        '    End If
        'End If
        If SysMessageClass.EditFlag = False Then
            SqlItemStr = "insert into m_TestType_t(Testtypeid,testtypename,uploady,defaultsaveway,documenttype,ismultfolder,getmethod,getrate,insertsql,selectsql,testparamlist,savetablename,usey,userid,intime)" & _
            "values('" & TxtTestTypeID.Text.Trim & "','" & TxtTestTypeName.Text.Trim & "','" & IIf(Me.CbxUploadY.Checked = True, "Y", "N") & "','" & TxtDefaultSaveWay.Text.Trim & "','" & TxtDocumentType.Text.Trim & "','" & IIf(Me.CbxIsMultFolder.Checked = True, "Y", "N") & "','" & IIf(Me.RadFixedTime.Checked = True, "1", "2") & "','" & IIf(Me.RadFixedTime.Checked = True, DUpWhen.Text & ":" & DUpPoints.Text & ":" & DUpSeconds.Text, DUpWhen1.Text & ":" & DUpPoints1.Text & ":" & DUpSeconds1.Text) & "','" & TxtInSertSql.Text.Trim & "','" & TxtSelecttSql.Text.Trim & "','" & TxtTestParamList.Text.Trim & "','" & TxtSaveTableName.Text.Trim & "','" & IIf(CbxUsey.Checked = True, "Y", "N") & "','" & LCase(SysMessageClass.UseId) & "',getdate())"
        Else
            SqlItemStr = "update m_TestType_t set testtypename='" & TxtTestTypeName.Text.Trim & "',uploady='" & IIf(Me.CbxUploadY.Checked = True, "Y", "N") & "',defaultsaveway='" & TxtDefaultSaveWay.Text.Trim & "',documenttype='" & TxtDocumentType.Text.Trim & "',ismultfolder='" & IIf(Me.CbxIsMultFolder.Checked = True, "Y", "N") & "',getmethod='" & IIf(Me.RadFixedTime.Checked = True, "1", "2") & "'," & _
            "getrate='" & IIf(Me.RadFixedTime.Checked = True, DUpWhen.Text & ":" & DUpPoints.Text & ":" & DUpSeconds.Text, DUpWhen1.Text & ":" & DUpPoints1.Text & ":" & DUpSeconds1.Text) & "',insertsql='" & TxtInSertSql.Text.Trim & "',selectsql='" & TxtSelecttSql.Text.Trim & "',testparamlist='" & TxtTestParamList.Text.Trim & "',savetablename='" & TxtSaveTableName.Text.Trim & "',usey='" & IIf(CbxUsey.Checked = True, "Y", "N") & "',Userid='" & LCase(SysMessageClass.UseId) & "',intime=getdate() where TestTypeID='" & TxtTestTypeID.Text.Trim & "'"
        End If
        GetSqlString = SqlItemStr

    End Function

#End Region

#Region "修改"

    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        If Me.DgWorkSit.RowCount < 1 Then Exit Sub
        SetToolButtonStutas(True)
        TextHandle.ControlIsEnable(Me, False)
        IsEnableObj(Me, True)
        SysMessageClass.EditFlag = True
        DgWorkSit.Enabled = False
        TxtTestTypeID.Enabled = False


    End Sub
#End Region

#Region "刪除"
    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click
        If Me.DgWorkSit.RowCount < 1 Then Exit Sub
        Dim MoHandle As New SysDataBaseClass
        If MessageBox.Show("你確定要刪除嗎?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                MoHandle.ExecSql("delete from m_TestType_t where Testtypeid='" & Me.DgWorkSit.CurrentRow.Cells(DgColZero).Value.ToString & "'")
                DgWorkSit.Rows.RemoveAt((DgWorkSit.CurrentRow.Index))
                'TextHandle.ClearControl(Me.GroupStation)
                LaodDataInControl(DgWorkSit)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If
        MoHandle = Nothing

    End Sub
#End Region

#Region "返回"
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        'TextHandle.ControlIsEnable(GroupStation, True)
        'IsEnableObj(GroupStation, False)
        '' SetToolButtonStutas(False)

        DgWorkSit.Enabled = True
        If CanCelFlag = True Then    ''如果主表格不存在記錄時的處理
            FlagObj.Rows.Clear()
            TextHandle.ClearControl(Me)
            FlagObj = Nothing
            CanCelFlag = False
        End If
        LaodDataInControl(DgWorkSit)
        SetToolButtonStutas(False)
        TextHandle.ControlIsEnable(Me, True)
        IsEnableObj(Me, False)
        Me.TxtSpart.Enabled = True
    End Sub
#End Region

#Region "單擊DG事件"

    Private Sub DgWorkSit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgWorkSit.Click
        LaodDataInControl(DgWorkSit)
    End Sub
#End Region

#Region "即時上傳單擊事件"

    Private Sub CbxUploadY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CbxUploadY.Checked = True Then

            'IsEnableObj(GroupStation, False)
            Me.GroupBox5.Enabled = True
            Me.TxtTestTypeName.Enabled = True
            Me.CbxUploadY.Enabled = True
            Me.CbxUsey.Enabled = True
            'TextHandle.ControlIsEnable(GroupBox2, True)
            'TextHandle.ControlIsEnable(GroupBox3, False)
            'TextHandle.ControlIsEnable(GroupBox4, False)
        Else
            'IsEnableObj(GroupStation, True)
            TxtTestTypeID.Enabled = False
        End If
    End Sub
#End Region

#Region "固定時間單擊事件"
    Private Sub RadFixedTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.RadFixedTime.Checked = True Then

            Me.DUpWhen1.Text = ""
            Me.DUpWhen1.Enabled = False
            Me.DUpPoints1.Text = ""
            Me.DUpPoints1.Enabled = False
            Me.DUpSeconds1.Text = ""
            Me.DUpSeconds1.Enabled = False

            Me.DUpWhen.Enabled = True
            Me.DUpPoints.Enabled = True
            Me.DUpSeconds.Enabled = True
        End If
    End Sub
#End Region

#Region "頻發時間單擊"
    Private Sub RadFrequentTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.RadFrequentTime.Checked = True Then

            Me.DUpWhen.Text = ""
            Me.DUpWhen.Enabled = False
            Me.DUpPoints.Text = ""
            Me.DUpPoints.Enabled = False
            Me.DUpSeconds.Text = ""
            Me.DUpSeconds.Enabled = False

            Me.DUpWhen1.Enabled = True
            Me.DUpPoints1.Enabled = True
            Me.DUpSeconds1.Enabled = True
        End If
    End Sub
#End Region

#Region "獲取保存路徑"

    ''Dim OpenFileDialog2 As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
    ''openfiledialog1.filter="Text files (*.txt)|*.txt|ALL files (*.*)|*.*"
    ''Dim offn As OpenFileDialog
    Private a As String = "c:\"


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With OpenFileDialog2
            '.DefaultExt = "txt"
            .Filter = "text file(*.txt)|*.txt|all file(*.*)|*.*"
            .FilterIndex = 1
            .InitialDirectory = "c\"
            .Title = "打开文件"
            .Multiselect = True
            .ReadOnlyChecked = False
            .ShowReadOnly = True

        End With
        If OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFileName = OpenFileDialog2.FileName
            'Dim s As String
            'Dim i As Integer
            'For i = 0 To Me.strFileName.Length - 1
            '    s = s + Me.strFileName(i) + Chr(10) + Chr(13)
            'Next

            TxtDefaultSaveWay.Text = strFileName

        End If

    End Sub


#End Region

#Region "根據料號查詢測試類型"
    Private Sub ButQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButQuery.Click

        Dim GetMaxCustid As SqlDataReader
        Dim MoHandle As New SysDataBaseClass
        If Me.TxtPpartid.Text.Trim = "" Then
            MessageBox.Show("請輸入成品料號...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtPpartid.Focus()
            Exit Sub
        End If

        If Me.CobPartid.Text.Trim = "" Then
            MessageBox.Show("請選擇料號編號...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobPartid.Focus()
            Exit Sub
        End If
        If Me.CobStation.Text.Trim = "" Then
            MessageBox.Show("請選擇測試站點編號...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobStation.Focus()
            Exit Sub
        End If
        Me.TxtTestTypeID.Clear()
        GetMaxCustid = MoHandle.GetDataReader("select  testtypeid from dbo.m_RPartStationD_t where ppartid='" & Me.TxtPpartid.Text & "' and tPartid='" & Me.CobPartid.Text & "' and stationid='" & Me.CobStation.Text & "' and [state]='1' ")
        While GetMaxCustid.Read()
            TxtTestTypeID.Text = GetMaxCustid!testtypeid.ToString
        End While
        GetMaxCustid.Close()

    End Sub
#End Region

    Private Sub ToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFind.Click

        Me.ToolRsflsh.Enabled = True
        ToolFind.Enabled = False
        Me.ToolCancel.Enabled = True
        ''Me.TxtPpartid.Enabled = True
        TxtSpart.Enabled = True
        Me.TxtSpart.Focus()

    End Sub

    Private Sub ToolRsflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRsflsh.Click

        Dim K As Integer
        Dim UserDg As DataTable
        Dim DataHand As New SysDataBaseClass

        DgWorkSit.Rows.Clear()
        If Me.TxtSpart.Text.Trim = "" Then
            UserDg = DataHand.GetDataTable("Select  * from m_TestType_t")
        Else
            UserDg = DataHand.GetDataTable("Select  * from m_TestType_t where TestTypeID in(select TestTypeID from dbo.m_RPartStationD_t where ppartid='" & Me.TxtSpart.Text & "' and [state]=1)")
        End If
        For K = 0 To UserDg.Rows.Count - 1
            DgWorkSit.Rows.Add(UserDg.Rows(K)("TestTypeID"), UserDg.Rows(K)("TestTypeName"), UserDg.Rows(K)("UploadY"), UserDg.Rows(K)("DefaultSaveWay"), UserDg.Rows(K)("DocumentType"), UserDg.Rows(K)("IsMultFolder"), UserDg.Rows(K)("GetMethod"), UserDg.Rows(K)("GetRate"), UserDg.Rows(K)("InSertSql"), UserDg.Rows(K)("SelectSql"), UserDg.Rows(K)("TestParamList"), UserDg.Rows(K)("SaveTableName"), UserDg.Rows(K)("Usey"), UserDg.Rows(K)("Userid"), UserDg.Rows(K)("Intime"))
        Next
        DataHand = Nothing
        UserDg.Dispose()
        Me.ToolCancel.Enabled = False
        Me.ToolFind.Enabled = True
        Me.ToolRsflsh.Enabled = False
        TxtSpart.Enabled = False

    End Sub

   
    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
End Class