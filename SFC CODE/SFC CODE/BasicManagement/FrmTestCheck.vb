#Region "Imports "

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.IO


#End Region
Public Class FrmTestCheck

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
            End If
        Next

    End Sub

#End Region

#Region "退出"
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click

        Close()

    End Sub
#End Region

#Region "Tab轉換Enter"
    Private Sub FrmTestCheck_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
    Private Sub FrmTestCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetToolButtonStutas(False)
        'TextHandle.ControlIsEnable(GroupStation, True)
        IsEnableObj(GroupStation, False)
        TextHandle.ControlIsEnable(Me, False)
        LoadDataToStationGrid()
        LaodDataInControl(Me.DgWorkSit)
        Me.DgWorkSit.Enabled = True

    End Sub
#End Region

#Region "Load數據到DgStation表格"

    Private Sub LoadDataToStationGrid()

        Dim K As Integer
        Dim UserDg As DataTable
        Dim DataHand As New SysDataBaseClass

        DgWorkSit.Rows.Clear()
        UserDg = DataHand.GetDataTable("select a.*,TestTypeID from m_TestCheck_t a join m_TestType_t b on a.CheckTable=b.SaveTableName")
        For K = 0 To UserDg.Rows.Count - 1
            DgWorkSit.Rows.Add(UserDg.Rows(K)("TestItemID"), UserDg.Rows(K)("TestTypeID"), UserDg.Rows(K)("CheckTable"), UserDg.Rows(K)("CheckField"), UserDg.Rows(K)("CheckCondition"), UserDg.Rows(K)("CheckValue"), UserDg.Rows(K)("Usey"), UserDg.Rows(K)("Userid"), UserDg.Rows(K)("Intime"))
        Next
        DataHand = Nothing
        UserDg.Dispose()

    End Sub

#End Region


#Region "單擊主表格控件時,對應的表格行數據顯示在對應的編輯控件中"

    Private Sub LaodDataInControl(ByVal DataGridObj As DataGridView) ''表格里的數據顯示在對應的非表格控件中

        If DataGridObj.RowCount < 1 Then Exit Sub
        TxtTestItemID.Text = DataGridObj.CurrentRow.Cells(0).Value
        Me.TxtTypeid.Text = DataGridObj.CurrentRow.Cells(1).Value
        TxtCheckTable.Text = DataGridObj.CurrentRow.Cells(2).Value
        TxtCheckField.Text = DataGridObj.CurrentRow.Cells(3).Value
        TxtCheckCondition.Text = DataGridObj.CurrentRow.Cells(4).Value
        TxtCheckValue.Text = DataGridObj.CurrentRow.Cells(5).Value
        CbxUsey.Checked = IIf(DataGridObj.CurrentRow.Cells(6).Value = "Y", True, False)

    End Sub

#End Region
#Region "新增"
    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        Dim MoHandle As New SysDataBaseClass

        SysMessageClass.EditFlag = False ''新增


        Dim GetMaxCustid As SqlDataReader
        GetMaxCustid = MoHandle.GetDataReader("SELECT max(TestItemID) AS ID from m_TestCheck_t ")
        GetMaxCustid.Read()
        TextHandle.ClearControl(Me.GroupStation)
        Me.TxtTestItemID.Text = GetMaxCustid("ID") + 1.ToString

        IsEnableObj(GroupStation, True)
        GroupBox1.Enabled = True
        'TextHandle.ControlIsEnable(GroupStation, False)
        SetToolButtonStutas(True)
        TxtTestItemID.Enabled = False
        Me.DgWorkSit.Enabled = False
        TxtCheckTable.Enabled = False
        Me.TxtSpart.Enabled = False
        Me.TxtPartid.Enabled = True
        Me.TxtPpartid.Enabled = True
        Me.CobStation.Enabled = True
        Me.Button2.Enabled = True

    End Sub
#End Region
#Region "保存"
    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Try
            SaveRecordToServer()
           
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

#End Region


#Region "保存數據過程"

    Private Sub SaveRecordToServer()

        If TxtCheckCondition.Text.Trim = "" Then
            MessageBox.Show("判斷條件不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCheckCondition.Focus()
            Exit Sub
        End If
        If TxtCheckTable.Text.Trim = "" Then
            MessageBox.Show("數據收集的所在Table不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCheckTable.Focus()
            Exit Sub
        End If
        If TxtCheckField.Text.Trim = "" Then
            MessageBox.Show("數據所依據的判斷字段不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCheckField.Focus()
            Exit Sub
        End If
        If TxtCheckCondition.Text.Trim = "" Then
            MessageBox.Show("數據所依據的判斷條件不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCheckCondition.Focus()
            Exit Sub
        End If

        If TxtCheckValue.Text.Trim = "" Then
            MessageBox.Show("數據所依據的判斷條件不能為空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCheckValue.Focus()
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
            IsEnableObj(GroupStation, False)
            GroupBox1.Enabled = False
            'TextHandle.ControlIsEnable(GroupStation, True)
            SetToolButtonStutas(False)
            DgWorkSit.Enabled = True
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
            SqlItemStr = "insert into m_TestCheck_t(CheckTable,CheckField,CheckCondition,CheckValue,usey,userid,intime)" & _
            "values('" & TxtCheckTable.Text.Trim & "','" & TxtCheckField.Text.Trim & "','" & TxtCheckCondition.Text.Trim & "','" & TxtCheckValue.Text.Trim & "','" & IIf(CbxUsey.Checked = True, "Y", "N") & "','" & LCase(SysMessageClass.UseId) & "',getdate())"
        Else
            SqlItemStr = "update m_TestCheck_t set CheckTable='" & TxtCheckTable.Text.Trim & "',CheckField='" & TxtCheckField.Text.Trim & "',CheckCondition='" & TxtCheckCondition.Text.Trim & "',CheckValue='" & TxtCheckValue.Text.Trim & "'  " & _
            " ,Usey='" & IIf(CbxUsey.Checked = True, "Y", "N") & "',Userid='" & LCase(SysMessageClass.UseId) & "',intime=getdate()  where TestItemID='" & TxtTestItemID.Text.Trim & "'"
        End If
        GetSqlString = SqlItemStr

    End Function

#End Region

#Region "修改"

    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        If Me.DgWorkSit.RowCount < 1 Then Exit Sub
        SetToolButtonStutas(True)
        'TextHandle.ControlIsEnable(GroupStation, False)
        IsEnableObj(GroupStation, True)
        SysMessageClass.EditFlag = True
        DgWorkSit.Enabled = False
        TxtTestItemID.Enabled = False
        TxtCheckTable.Enabled = False
        Me.TxtSpart.Enabled = False
        Me.TxtPartid.Enabled = True
        'Me.TxtPpartid.Enabled = True
        'Me.CobStation.Enabled = True
        'Me.Button2.Enabled = True

    End Sub
#End Region


#Region "刪除"
    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click
        If Me.DgWorkSit.RowCount < 1 Then Exit Sub
        Dim MoHandle As New SysDataBaseClass
        If MessageBox.Show("你確定要刪除嗎?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                MoHandle.ExecSql("delete from m_TestCheck_t where TestItemID='" & Me.DgWorkSit.CurrentRow.Cells(0).Value.ToString & "'")
                DgWorkSit.Rows.RemoveAt((DgWorkSit.CurrentRow.Index))
                TextHandle.ClearControl(Me.GroupStation)
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
        'TextHandle.ControlIsEnable(GroupStation, Trueddd)
        IsEnableObj(GroupStation, False)
        SetToolButtonStutas(False)

        DgWorkSit.Enabled = True
        LaodDataInControl(DgWorkSit)
        Me.TxtPartid.Enabled = False
        Me.TxtPpartid.Enabled = False
        Me.CobStation.Enabled = False
        Me.Button2.Enabled = False
        'If CanCelFlag = True Then    ''如果主表格不存在記錄時的處理
        '    FlagObj.Rows.Clear()
        '    TextHandle.ClearControl(Me)
        '    FlagObj = Nothing
        '    CanCelFlag = False
        'End If


    End Sub
#End Region

#Region "單擊DG事件"
    Private Sub DgWorkSit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgWorkSit.Click
        LaodDataInControl(DgWorkSit)
    End Sub
#End Region


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim MoHandle As New SysDataBaseClass
        Dim Sqlstr As String = "select savetablename,a.TestTypeID from dbo.m_TestType_t a join dbo.m_RPartStationD_t b on a.testtypeid=b.testtypeid and ppartid='" & Me.TxtPpartid.Text & "' and Tpartid='" & Me.TxtPartid.Text & "' and Stationid='" & Me.CobStation.Text.Trim & "' and state=1"
        Dim SqlDataReader As SqlDataReader = MoHandle.GetDataReader(Sqlstr)
        While SqlDataReader.Read
            TxtCheckTable.Text = SqlDataReader!savetablename.ToString
            TxtTypeid.Text = SqlDataReader!TestTypeID.ToString
        End While
        SqlDataReader.Close()

    End Sub

   
    Private Sub ToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFind.Click

        TxtSpart.Enabled = True
        ToolFind.Enabled = False
        Me.ToolRsflsh.Enabled = True
        Me.TxtSpart.Focus()

    End Sub

    Private Sub ToolRsflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRsflsh.Click

        Me.TxtSpart.Enabled = False
        Me.ToolFind.Enabled = True
        Me.ToolRsflsh.Enabled = False
        Dim K As Integer
        Dim UserDg As DataTable
        Dim DataHand As New SysDataBaseClass

        DgWorkSit.Rows.Clear()
        If Me.TxtSpart.Text.Trim = "" Then
            UserDg = DataHand.GetDataTable("select a.*,TestTypeID from m_TestCheck_t a join m_TestType_t b on a.CheckTable=b.SaveTableName")
        Else
            UserDg = DataHand.GetDataTable("select a.*,b.TestTypeID from m_TestCheck_t a join m_TestType_t b on a.CheckTable=b.SaveTableName  join dbo.m_RPartStationD_t c on b.testtypeid=c.testtypeid and c.ppartid='" & Me.TxtSpart.Text & "' ")
        End If
        For K = 0 To UserDg.Rows.Count - 1
            DgWorkSit.Rows.Add(UserDg.Rows(K)("TestItemID"), UserDg.Rows(K)("TestTypeID"), UserDg.Rows(K)("CheckTable"), UserDg.Rows(K)("CheckField"), UserDg.Rows(K)("CheckCondition"), UserDg.Rows(K)("CheckValue"), UserDg.Rows(K)("Usey"), UserDg.Rows(K)("Userid"), UserDg.Rows(K)("Intime"))
        Next
        DataHand = Nothing
        UserDg.Dispose()

    End Sub
End Class