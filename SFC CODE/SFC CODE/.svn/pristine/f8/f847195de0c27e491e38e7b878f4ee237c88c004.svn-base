Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text
Imports System.Data.SqlClient

Public Class FrmAddress
    Dim DtCustAdd As DataTable
    Dim AddOrEidt As Boolean
    Dim SearchY As Boolean
    Dim TextHandleClass As New TextHandle
    Dim StrOldCusid As String
    Dim StrOldAddress As String

    Private Sub FrmAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        ControlStatus("undo")
        FillCobType(Me.CobCusid, "select * from m_Customer_t where usey='Y'")
        Sdbc.ExecSql("Delete from m_Customer_t where usey='N' and cusname=''")
        ReLodaData()
        ReLodaCustData()
        SetControlValue()
        SetControlCustValue()
    End Sub

    Private Sub TsBnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnNew.Click
        If SearchY = True Then
            SearchY = False
            Me.GroupBox1.Text = ""
        End If
        AddOrEidt = True
        ControlStatus("add")

    End Sub

    Private Sub TsBtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtEdit.Click
        If Me.DGridCustAdr.CurrentRow.Index = -1 Then Exit Sub
        If SearchY = True Then
            SearchY = False
            Me.GroupBox1.Text = ""
            SetControlValue()
        End If
        AddOrEidt = False
        StrOldCusid = DGridCustAdr.CurrentRow.Cells(0).Value.ToString
        StrOldAddress = Trim(Me.TxtCusAddr.Text)
        ControlStatus("edit")

    End Sub
    Private Sub DGridCustAdr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGridCustAdr.Click
        SetControlValue()
    End Sub

    Private Sub TsBtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtSearch.Click
        Dim ChColsText As String
        If Me.CobCusid.Enabled = False Then
            Me.CobCusid.SelectedIndex = 0
            Me.CobCusid.Enabled = True
            Me.TxtCusAddr.Text = ""
            Me.TxtCusAddr.Enabled = True
            Me.CbUsey.Checked = False
            Me.CbUsey.Enabled = True
            SearchY = True
            Me.GroupBox1.Text = "查詢條件"
        Else
            Me.CobCusid.Enabled = False
            Me.TxtCusAddr.Enabled = False
            Me.CbUsey.Enabled = False
            Me.GroupBox1.Text = ""
            SearchY = False
            Me.DGridCustAdr.DataSource = Nothing
            Me.DGridCustAdr.DataSource = DtCustAdd
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "客戶編號|客戶名稱|出貨地址|有效否|維護人員|維護時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i%
            For i = 0 To DGridCustAdr.Columns.Count - 1
                DGridCustAdr.Columns(i).HeaderText = colNames(i)
                DGridCustAdr.Columns(i).Name = colNames(i)
            Next
            SetControlValue()
        End If
    End Sub

    Private Sub TsBnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnBack.Click
        ControlStatus("undo")
        SetControlValue()
    End Sub

    Private Sub TsBtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtDelete.Click

        If Me.DGridCustAdr.CurrentRow.Index = -1 Then Exit Sub
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        If MessageBox.Show("你確定要刪除該筆資料嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Sdbc.ExecSql("delete from m_Custsadd_t where cusid='" & Me.DGridCustAdr.CurrentRow.Cells(0).Value & "'and shipaddress='" & Me.DGridCustAdr.CurrentRow.Cells(2).Value & "'")
            ReLodaData()
            MessageBox.Show("刪除成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub TsBtUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtUndo.Click
        If Me.DGridCustAdr.CurrentRow.Index = -1 Then Exit Sub
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        If MessageBox.Show("你確定要作廢該筆資料嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Sdbc.ExecSql("update m_Custsadd_t set usey='N',userid='" & SysMessageClass.UseId & "',intime=getdate() where cusid='" & Me.DGridCustAdr.CurrentRow.Cells(0).Value & "'and shipaddress='" & Me.DGridCustAdr.CurrentRow.Cells(2).Value & "'")
            ReLodaData()
            MessageBox.Show("作廢成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub TsBtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtSave.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        If Me.CobCusid.Text = "" OrElse Me.CobCusid.Text = "ALL" Then
            MessageBox.Show("請選擇客戶！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Me.TxtCusAddr.Text = "" Then
            MessageBox.Show("出貨地址不能為空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            TxtCusAddr.Text = TextHandleClass.TraditionalChinese(Me.TxtCusAddr.Text, True)
            If AddOrEidt = True Then
                DrCheck = Sdbc.GetDataReader("select * from m_Custsadd_t where cusid='" & Mid(Trim(Me.CobCusid.Text), 1, InStr(Trim(Me.CobCusid.Text), "(") - 1) & "'and shipaddress='" & Trim(TxtCusAddr.Text) & "' ")
                If DrCheck.Read Then
                    MessageBox.Show("該筆出貨地址記錄已維護過，不能再添加！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DrCheck.Close()
                    Exit Sub
                End If
                DrCheck.Close()
                Sdbc.ExecSql("insert into m_Custsadd_t(cusid,shipaddress,usey,userid,intime) values('" & Mid(Trim(Me.CobCusid.Text), 1, InStr(Trim(Me.CobCusid.Text), "(") - 1) & "','" & Trim(Me.TxtCusAddr.Text) & "','" & IIf(Me.CbUsey.Checked, "Y", "N") & "','" & SysMessageClass.UseId & "',getdate())")
            Else
                Sdbc.ExecSql("update m_Custsadd_t set cusid='" & Mid(Trim(Me.CobCusid.Text), 1, InStr(Trim(Me.CobCusid.Text), "(") - 1) & "',shipaddress='" & Trim(Me.TxtCusAddr.Text) & "',usey='" & IIf(Me.CbUsey.Checked, "Y", "N") & "',userid='" & SysMessageClass.UseId & "',intime= getdate() where cusid='" & StrOldCusid & "' and shipaddress='" & StrOldAddress & "'")
            End If
            MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            StrOldCusid = ""
            StrOldAddress = ""
            ReLodaData()
            ControlStatus("undo")
            SetControlValue()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#Region "數據導入"
    Private Sub ReLodaData()

        Dim ChColsText As String
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        DtCustAdd = Sdbc.GetDataTable("select a.cusid,b.cusname,a.shipaddress,a.usey,a.userid,a.intime from dbo.m_Custsadd_t a join dbo.m_Customer_t b on a.cusid=b.cusid order by a.intime desc")
        DGridCustAdr.DataSource = DtCustAdd

        Sdbc = Nothing
        If LCase(SysMessageClass.Language) = "english" Then
            ChColsText = ""
        Else
            ChColsText = "客戶編號|客戶名稱|出貨地址|有效否|維護人員|維護時間"
        End If
        Dim colNames As String() = ChColsText.Split("|")
        Dim i%
        For i = 0 To DGridCustAdr.Columns.Count - 1
            DGridCustAdr.Columns(i).HeaderText = colNames(i)
            DGridCustAdr.Columns(i).Name = colNames(i)
        Next
       
    End Sub

    Private Sub ReLodaCustData()

        Dim ChColsText As String
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DtCustData As DataTable
        DtCustData = Sdbc.GetDataTable("SELECT CusID, CusName,Address,Linkman,Tel,Fax,Usey  FROM  m_Customer_t ")
        DgCustData.DataSource = DtCustData

        Sdbc = Nothing
        If LCase(SysMessageClass.Language) = "english" Then
            ChColsText = ""
        Else
            ChColsText = "客戶編號|客戶名稱|客戶地址|聯繫人員|聯繫電話|電話傳真|有效否"
        End If
        Dim colNames As String() = ChColsText.Split("|")
        Dim i%
        For i = 0 To DgCustData.Columns.Count - 1
            DgCustData.Columns(i).HeaderText = colNames(i)
            DgCustData.Columns(i).Name = colNames(i)
        Next

    End Sub
#End Region

    Private Sub ControlStatus(ByVal Status As String)
        Select Case Status
            Case "add"
                Me.CobCusid.SelectedIndex = -1
                Me.CobCusid.Enabled = True
                Me.TxtCusAddr.Text = ""
                Me.TxtCusAddr.Enabled = True
                Me.CbUsey.Checked = True
                Me.CbUsey.Enabled = True
                Me.DGridCustAdr.Enabled = False
                Me.TsBnNew.Enabled = False
                TsBtEdit.Enabled = False
                TsBtDelete.Enabled = False
                TsBtUndo.Enabled = False
                TsBnBack.Enabled = True
                TsBtSave.Enabled = True
                TsBtSearch.Enabled = False
                TsBtExit.Enabled = True
            Case "edit"
                Me.CobCusid.Enabled = True
                Me.TxtCusAddr.Enabled = True
                Me.CbUsey.Enabled = True
                Me.DGridCustAdr.Enabled = False
                Me.TsBnNew.Enabled = False
                TsBtEdit.Enabled = False
                TsBtDelete.Enabled = False
                TsBtUndo.Enabled = False
                TsBnBack.Enabled = True
                TsBtSave.Enabled = True
                TsBtSearch.Enabled = False
                TsBtExit.Enabled = True
            Case "undo"
                Me.CobCusid.Enabled = False
                Me.TxtCusAddr.Enabled = False
                Me.CbUsey.Enabled = False
                Me.DGridCustAdr.Enabled = True
                Me.TsBnNew.Enabled = True
                TsBtEdit.Enabled = True
                TsBtDelete.Enabled = True
                TsBtUndo.Enabled = True
                TsBnBack.Enabled = False
                TsBtSave.Enabled = False
                TsBtSearch.Enabled = True
                TsBtExit.Enabled = True
        End Select
    End Sub

    Private Sub SetControlStatus(ByVal Status As String)
        Select Case Status
            Case "add"
                TxtCustid.Enabled = False
                TxtLinkman.Enabled = True
                TxtLinkTel.Enabled = True
                TxtCustName.Enabled = True
                TxtExt.Enabled = True
                TxtCustAdd.Enabled = True
                Checky.Enabled = True
                Checky.Checked = True
                TxtCustid.Text = ""
                TxtLinkman.Text = ""
                TxtLinkTel.Text = ""
                TxtCustName.Text = ""
                TxtExt.Text = ""
                TxtCustAdd.Text = ""
                DgCustData.Enabled = False
            Case "edit"
                TxtCustid.Enabled = False
                TxtLinkman.Enabled = True
                TxtLinkTel.Enabled = True
                TxtCustName.Enabled = True
                TxtExt.Enabled = True
                TxtCustAdd.Enabled = True
                Checky.Enabled = True
                DgCustData.Enabled = False
            Case "undo"
                TxtCustid.Enabled = False
                TxtLinkman.Enabled = False
                TxtLinkTel.Enabled = False
                TxtCustName.Enabled = False
                TxtExt.Enabled = False
                TxtCustAdd.Enabled = False
                Checky.Enabled = False
                DgCustData.Enabled = True
        End Select
    End Sub
    Private Sub SetControlValue()

        If Me.DGridCustAdr.Rows.Count < 1 Then Exit Sub
        If SearchY = True Then Exit Sub
        Me.CobCusid.Text = Me.DGridCustAdr.Item(0, DGridCustAdr.CurrentRow.Index).Value.ToString & "(" & Me.DGridCustAdr.Item(1, DGridCustAdr.CurrentRow.Index).Value.ToString & ")"
        TxtCusAddr.Text = Me.DGridCustAdr.Item(2, DGridCustAdr.CurrentRow.Index).Value.ToString
        Me.CbUsey.Checked = IIf(Me.DGridCustAdr.Item(3, DGridCustAdr.CurrentRow.Index).Value = "Y", True, False)
    End Sub

    Private Sub SetControlCustValue()

        If Me.DgCustData.Rows.Count < 1 Then Exit Sub
        Me.TxtCustid.Text = Me.DgCustData.Item(0, DgCustData.CurrentRow.Index).Value.ToString
        TxtCustName.Text = Me.DgCustData.Item(1, DgCustData.CurrentRow.Index).Value.ToString
        TxtCustAdd.Text = Me.DgCustData.Item(2, DgCustData.CurrentRow.Index).Value.ToString
        TxtLinkman.Text = Me.DgCustData.Item(3, DgCustData.CurrentRow.Index).Value.ToString
        TxtLinkTel.Text = Me.DgCustData.Item(4, DgCustData.CurrentRow.Index).Value.ToString
        TxtExt.Text = Me.DgCustData.Item(5, DgCustData.CurrentRow.Index).Value.ToString
        Me.Checky.Checked = IIf(Me.DgCustData.Item(6, DgCustData.CurrentRow.Index).Value = "Y", True, False)
    End Sub

#Region "填充下拉菜單資料"
    Private Sub FillCobType(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()
        CboDr = Sdbc.GetDataReader(SqlStr)
        CboName.Items.Add("ALL")
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0) & "(" & CboDr.GetString(1) & ")")
            End While
        End If
        Sdbc = Nothing
        CboDr.Close()

    End Sub
#End Region

    Private Sub TsBtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtExit.Click
        Me.Close()
    End Sub

    Private Sub CobCusid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobCusid.TextChanged
        If SearchY = False Then Exit Sub
        Dim tableview As New DataView(DtCustAdd)
        Dim ChColsText As String
        Dim RowFilterStr As String = ""
        Dim StrCusAddr As String
        RowFilterStr = " usey = '" & IIf(Me.CbUsey.Checked, "Y", "N") & "'"

        If Me.TxtCusAddr.Text <> "" Then
            StrCusAddr = TextHandleClass.TraditionalChinese(Me.TxtCusAddr.Text, True)
            RowFilterStr = RowFilterStr + " and shipaddress like '" & Trim(StrCusAddr) & "%'"
        End If
        If Me.CobCusid.Text <> "ALL" Then
            RowFilterStr = RowFilterStr + " and cusid='" & Mid(Trim(Me.CobCusid.Text), 1, InStr(Trim(Me.CobCusid.Text), "(") - 1) & "'"
        End If
        tableview.RowFilter = RowFilterStr

        Me.DGridCustAdr.DataSource = Nothing
        Me.DGridCustAdr.DataSource = tableview

        If LCase(SysMessageClass.Language) = "english" Then
            ChColsText = ""
        Else
            ChColsText = "客戶編號|客戶名稱|出貨地址|有效否|維護人員|維護時間"
        End If
        Dim colNames As String() = ChColsText.Split("|")
        Dim i%
        For i = 0 To DGridCustAdr.Columns.Count - 1
            DGridCustAdr.Columns(i).HeaderText = colNames(i)
            DGridCustAdr.Columns(i).Name = colNames(i)
        Next

    End Sub

    Private Sub TsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsAdd.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim GetMaxCustid As SqlDataReader
        SetControlStatus("add")
        GetMaxCustid = Sdbc.GetDataReader("SELECT 'Cus'+right('00'+cast(cast(right(max(Cusid),3)as int)+1 as varchar),3) MaxCusId from m_Customer_t ")
        GetMaxCustid.Read()
        Me.TxtCustid.Text = GetMaxCustid("MaxCusId").ToString
        GetMaxCustid.Close()
        Sdbc.ExecSql("insert into m_Customer_t(cusid,cusname,Usey) values('" & TxtCustid.Text & "','','N'")
        Me.TxtCustName.Focus()
    End Sub

    Private Sub DgCustData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgCustData.Click
        SetControlCustValue()
    End Sub

    Private Sub TsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsEdit.Click
        SetControlStatus("edit")
    End Sub

    Private Sub TsBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBack.Click
        SetControlStatus("undo")
        SetControlCustValue()
    End Sub

    Private Sub TsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsSave.Click
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.TxtCustName.Text = "" Then
            MessageBox.Show("客戶名稱不能為空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCustName.Focus()
            Exit Sub
        End If

        Try
            TxtCustName.Text = TextHandleClass.TraditionalChinese(Me.TxtCusAddr.Text, True)
            TxtLinkman.Text = TextHandleClass.TraditionalChinese(Me.TxtLinkman.Text, True)
            TxtCustAdd.Text = TextHandleClass.TraditionalChinese(Me.TxtCustAdd.Text, True)
            'If AorE = True Then
            '    Sdbc.ExecSql("insert into m_Customer_t(cusid,cusname,Address,Tel,Fax,Linkman,Usey) values('" & TxtCustid.Text & "','" & Trim(Me.TxtCustName.Text) & "','" & TxtCustAdd.Text & "','" & TxtLinkTel.Text & "','" & TxtExt.Text & "','" & TxtLinkman.Text & "','" & IIf(Me.Checky.Checked, "Y", "N") & "')")
            'Else
            Sdbc.ExecSql("update m_Customer_t set cusname='" & TxtCustid.Text & "',Address='" & TxtCustAdd.Text & "',Tel='" & TxtLinkTel.Text & "',Fax='" & TxtExt.Text & "',Linkman='" & TxtLinkman.Text & "',Usey='" & IIf(Me.Checky.Checked, "Y", "N") & "' where cusid='" & Me.TxtCustid.Text & "'")
            'End If
            MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReLodaCustData()
            SetControlStatus("undo")
            SetControlCustValue()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub TsReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsReturn.Click
        Me.Close()
    End Sub
End Class