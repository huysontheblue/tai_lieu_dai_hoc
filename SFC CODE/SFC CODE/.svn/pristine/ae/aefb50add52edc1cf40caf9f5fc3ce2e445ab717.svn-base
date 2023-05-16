Imports System.Data.SqlClient

'****************************************************************************
'* 文件名稱：FrmMgWHInfo.vb
'* 摘    要：倉庫別維護程式


'* 當前版本：1.01
'* 作    者：Anday_xu
'* 完成日期：2011年08月17日


'****************************************************************************

Public Class FrmMgWHinfo
    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader
    Private strSaveSql As String
    Private g_User As String = MainFrame.SysCheckData.SysMessageClass.UseId
    Const ParentKey = "m0870_"
    Const TKeyfix = "m7006"
    Dim EditFlag As String = ""
    '加載權限
    Private Sub LoadRights()
        Dim strSql As String
        Dim strTkey As String

        BtNew.Tag = "N"
        BtModify.Tag = "N"
        BtSave.Tag = "N"
        BtDelete.Tag = "N"
        BtExport.Tag = "N"

        strSql = " select a.tkey, a.tparent, a.ttext from m_logtree_t a, m_userright_t b " _
               & " where a.tkey=b.tkey and b.userid='" & g_User & "' and a.tparent='" & ParentKey & "' "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            strTkey = Rs(0).ToString
            If strTkey = TKeyfix & "a_" Then
                BtNew.Tag = "Y"
            End If

            If strTkey = TKeyfix & "b_" Then
                BtModify.Tag = "Y"
            End If

            If strTkey = TKeyfix & "c_" Then
                BtSave.Tag = "Y"
            End If

            If strTkey = TKeyfix & "d_" Then
                BtDelete.Tag = "Y"
            End If

            If strTkey = TKeyfix & "e_" Then
                BtExport.Tag = "Y"
            End If
        End While
        Rs.Close()
    End Sub

    '界面改變
    Private Sub ChangeUI(ByVal intStyle As Integer)
        Select Case intStyle
            Case 0 '默認狀態
                BtNew.Enabled = False
                BtModify.Enabled = False
                BtDelete.Enabled = False
                BtSave.Enabled = False
                BtExport.Enabled = False
                BtReturn.Enabled = False
                FillRightButton(BtNew, BtNew.Tag)
                FillRightButton(BtModify, BtModify.Tag)
                FillRightButton(BtDelete, BtDelete.Tag)
                FillRightButton(BtExport, BtExport.Tag)

                CobWHID.Enabled = False
                CobWHName.Enabled = False
                CobFactory.Enabled = False
                DgWHList.Enabled = True
                CkbControl.Enabled = False
                TxtRemark.Enabled = False
                CobFloor.Enabled = False
                Chkusey.Enabled = False
                Toolreflash.Enabled = False
            Case 1 'Select
                BtNew.Enabled = False
                BtReturn.Enabled = True
                FillRightButton(BtModify, BtModify.Tag)
                FillRightButton(BtDelete, BtDelete.Tag)

            Case 2 'New

                BtNew.Enabled = False
                BtModify.Enabled = False
                BtDelete.Enabled = False
                BtExport.Enabled = False
                BtSave.Enabled = True
                BtReturn.Enabled = True

                CobWHID.Items.Clear()
                CobWHID.Text = ""
                CkbControl.Checked = False
                CobWHName.Items.Clear()
                CobWHName.Text = ""
                TxtRemark.Text = ""
                CobFloor.SelectedIndex = -1

                DgWHList.Enabled = False
                CobWHName.Enabled = True
                CobWHID.Enabled = True
                CobFloor.Enabled = True
                TxtRemark.Enabled = True
                CkbControl.Enabled = True
                CobFactory.Enabled = True
                Chkusey.Enabled = True
            Case 3 'Edit

                BtNew.Enabled = False
                BtModify.Enabled = False
                BtSave.Enabled = True
                BtReturn.Enabled = True
                BtDelete.Enabled = False
                BtExport.Enabled = False
                DgWHList.Enabled = False

                CobWHID.Enabled = False
                CobWHName.Enabled = True
                CobFactory.Enabled = False
                CkbControl.Enabled = True
                CobFloor.Enabled = False
                TxtRemark.Enabled = True
                Chkusey.Enabled = True
                CobWHName.Items.Clear()
            Case 4 'Find

                BtNew.Enabled = False
                BtModify.Enabled = False
                BtDelete.Enabled = False
                BtExport.Enabled = False
                BtSave.Enabled = False
                BtReturn.Enabled = True

                CobWHID.Items.Clear()
                CobWHID.Text = ""
                CkbControl.Checked = False
                CobWHName.Items.Clear()
                CobWHName.Text = ""
                TxtRemark.Text = ""
                CobFloor.SelectedIndex = -1

                DgWHList.Enabled = False
                CobWHName.Enabled = True
                CobWHID.Enabled = True
                CobFloor.Enabled = True
                TxtRemark.Enabled = True
                CkbControl.Enabled = True
                CobFactory.Enabled = True
                Chkusey.Enabled = True
                Toolreflash.Enabled = True
        End Select
    End Sub

    Private Sub FillRightButton(ByRef BtName As ToolStripButton, ByVal Enable As String)
        If Enable = "Y" Then
            BtName.Enabled = True
        Else
            BtName.Enabled = False
        End If
    End Sub

    '加載工廠別


    'Private Sub LoadFactory()
    '    Dim strSql As String

    '    CobFactory.Items.Clear()
    '    'CobFactory.Items.Add("ALL")
    '    strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
    '           & " (select tkey from m_userright_t where tkey='F010_' and userid='" & g_User & "' " _
    '           & " union " _
    '           & " select tkey from m_userright_t where tkey='F011_' and userid='" & g_User & "') "
    '    Rs = objDB.GetDataReader(strSql)
    '    While Rs.Read
    '        CobFactory.Items.Add(Rs(1).ToString & "-" & Rs(0).ToString)
    '    End While
    '    Rs.Close()
    '    CobFactory.SelectedIndex = 0
    'End Sub

    Public Sub FillFactory(ByRef ComBox As ComboBox, ByVal strUser As String)
        Dim strSql As String
        '
        ComBox.Items.Clear()
        strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
               & " (select tkey from m_userright_t where tkey in " _
               & " (select tkey from m_logtree_t where tparent='F0_') " _
               & " and userid='" & strUser & "') "
        Rs = objDB.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                'ComBox.Items.Add(rs(0).ToString & "(" & rs(1).ToString & ")")
                ComBox.Items.Add(Rs(1).ToString & "-" & Rs(0).ToString)
            End While
            'ComBox.SelectedIndex = 0
        End If
        Rs.Close()

    End Sub

    Private Sub LoadWHID()
        Dim strSql As String

        'CobWHID.Items.Add("ALL")
        strSql = " select distinct(whid) from m_wh_t "
        Rs = objDB.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                CobWHID.Items.Add(Rs(0).ToString)
            End While
            CobWHID.SelectedIndex = 0
        End If
        Rs.Close()

    End Sub

    Private Sub LoadWHName()
        Dim strSql As String

        'CobWHName.Items.Add("ALL")
        strSql = " select distinct(whname) from m_wh_t "
        Rs = objDB.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                CobWHName.Items.Add(Rs(0).ToString)
            End While
        End If
        Rs.Close()
        'CobWHName.SelectedIndex = 0
    End Sub

    Private Sub LoadFloor()
        Dim strSql As String

        CobFloor.Items.Clear()
        ' CobFloor.Items.Add("ALL")
        strSql = " select distinct(floorid) from m_wh_t where floorid is not null and usey='Y'"
        Rs = objDB.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                CobFloor.Items.Add(Rs(0).ToString)
            End While
            CobFloor.SelectedIndex = 0
        End If
        Rs.Close()

    End Sub

    Private Sub Init()
        LoadRights()
        ' LoadFactory()
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        LoadFloor()
        LoadWHID()
        LoadWHName()
        ChangeUI(0)
        LoadWHList("")
        'DgWHList.Focus()
    End Sub

    Private Sub LoadWHList(ByVal StrWhere As String)
        Dim strSql As String
        Dim strDt As String
        Dim dt As Date

        strSql = " select whid, whname, factory, floorid, isnull(typeid,''), isnull(remark,''), userid, intime,Usey from m_wh_t where 1=1 " & StrWhere & " order by whid "
        Rs = objDB.GetDataReader(strSql)

        DgWHList.Rows.Clear()
        If Rs.HasRows Then
            While Rs.Read
                dt = Rs(7)
                strDt = dt.ToString("yyyy-MM-dd HH:mm")
                DgWHList.Rows.Add(Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString, Rs(4).ToString, Rs(5).ToString, Rs(6).ToString, strDt, Rs(8).ToString)
            End While
        End If
        Rs.Close()

        strSaveSql = strSql
        ToolCount.Text = DgWHList.Rows.Count.ToString
        CellClick()
    End Sub


    Private Function GetFactoryName(ByVal strCode As String) As String
        Dim strSql As String
        Dim strReturn As String

        strSql = " select ttext from m_logtree_t where buttonid='" & strCode & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            strReturn = strCode & "-" & Rs(0).ToString
        Else
            strReturn = ""
        End If
        Rs.Close()

        Return strReturn
    End Function

    Private Function SaveData(ByVal intNew As Integer) As Boolean
        Dim strWHID As String
        Dim strWHName As String
        Dim strFactory As String
        Dim strFloor As String
        Dim strRemark As String
        Dim strSql As String
        Dim strType As String
        Dim bExist As Boolean

        Try
            strWHID = CobWHID.Text
            strWHName = CobWHName.Text
            strFloor = CobFloor.Text
            strFactory = Mid(CobFactory.Text, 1, 2)
            strRemark = TxtRemark.Text
            If CkbControl.Checked = False Then
                strType = "G"
            Else
                strType = "C"
            End If

            If strWHID = "" Then
                MsgBox("倉庫編號不能為空.", 48, "Warning")
                Return False
            End If

            If strWHName = "" Then
                MsgBox("倉庫編號不能為空.", 48, "Warning")
                Return False
            End If

            If intNew = 1 Then
                strSql = " select * from m_wh_t where whid='" & strWHID & "' and floorid='" & CobFloor.Text & "' and factory='" & strFactory & "'"
                Rs = objDB.GetDataReader(strSql)
                If Rs.Read Then
                    bExist = True
                Else
                    bExist = False
                End If
                Rs.Close()
                If bExist = True Then
                    MsgBox("[" & strWHID & "]已經存在.", MsgBoxStyle.Exclamation, "提示信息")
                    Return False
                End If

                strSql = " insert into m_wh_t (whid, whname, floorid, factory, usey, remark, userid, intime,typeid) " _
                       & " values ('" & strWHID & "', '" & strWHName & "', '" & strFloor & "', '" & strFactory & "','" _
                       & IIf(Me.Chkusey.Checked, "Y", "N") & "','" & strRemark & " ', '" & g_User & "', getdate(),'" & strType & "') " _
                       & "  "
                objDB.ExecSql(strSql)
            End If

            If intNew = 0 Then
                strSql = " update m_wh_t set  whname ='" & strWHName & "', usey='" & IIf(Me.Chkusey.Checked, "Y", "N") & "',remark ='" & strRemark & "', userid ='" & g_User & "' , intime =getdate(),typeid='" & strType & _
                         "' where  whid='" & strWHID & "' and floorid='" & CobFloor.Text & "' and factory='" & strFactory & "'"
                objDB.ExecSql(strSql)
            End If
            Return True
        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmMgWHinfo", "SaveData", "sys")
            Return False
        End Try
    End Function

    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub FrmMgWHinfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        ChangeUI(2)
    End Sub

    Private Sub ShowText()
        Dim strTmp As String
        If DgWHList.Rows.Count > 0 Then
            CobWHID.Text = DgWHList.CurrentRow.Cells(0).Value.ToString
            CobWHName.Text = DgWHList.CurrentRow.Cells(1).Value.ToString
            strTmp = DgWHList.CurrentRow.Cells(2).Value.ToString
            CobFactory.SelectedIndex = CobFactory.Items.IndexOf(GetFactoryName(strTmp))
            CobFloor.Text = DgWHList.CurrentRow.Cells(3).Value.ToString
            TxtRemark.Text = DgWHList.CurrentRow.Cells(5).Value.ToString
            If DgWHList.CurrentRow.Cells(4).Value.ToString = "C" Then
                CkbControl.Checked = True
            Else
                CkbControl.Checked = False
            End If

            If DgWHList.CurrentRow.Cells("Colusey").Value.ToString = "Y" Then
                Me.Chkusey.Checked = True
            Else
                Me.Chkusey.Checked = False
            End If
        End If
    End Sub

    Private Sub BtReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReturn.Click
        Init()
        LoadWHList("")
    End Sub

    Private Sub BtModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtModify.Click
        ''判斷該倉庫是否有庫存，有的話不能修改倉庫
        'Dim strSql As String = " select * from m_carton_t  where whid in " _
        '                       & " ( select whid from m_wh_t where usey='N') and cartonstatus ='I' and " _
        '                       & " whid='" & CobWHID.Text & "' and floorid= '" & CobFloor.Text & "'"
        'Dim dt As DataTable = objDB.GetDataTable(strSql)
        'If dt.Rows.Count > 0 Then
        '    MessageBox.Show("該倉庫有庫存，不能修改！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        EditFlag = "1"
        ChangeUI(3)
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click
        Dim strWHID As String
        Dim strFloorid As String
        Dim strSql As String

        strWHID = CobWHID.Text
        strFloorid = Me.CobFloor.Text
        If CheckWhid(strWHID, strFloorid) = True Then
            MessageBox.Show("該倉庫有庫存,不能作廢！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MsgBox("確實要作廢倉庫編號[ " & strWHID & " ]嗎？", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "確認信息") = MsgBoxResult.Yes Then
            'add by anday 增加判斷該倉庫是否有庫存，如果有庫存則不能作廢
            strSql = " update m_wh_t set usey='N' where whid='" & strWHID & "' "
            objDB.ExecSql(strSql)
            MsgBox("操作成功.", MsgBoxStyle.Exclamation, "提示信息")
            Init()
            LoadWHList("")
        End If
    End Sub

    Private Function CheckWhid(ByVal strWhid As String, ByVal strFloorid As String) As Boolean
        '判斷要作廢的倉庫中是否有庫存,有的話不能作廢
        Dim StrSql As String = "select top 10 * from m_carton_t where whid ='" & strWhid & "' and floorid='" & strFloorid & "' and Cartonstatus ='I' "
        Dim dt As DataTable = objDB.GetDataTable(StrSql)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GetQueryCondition() As String
        Return ""
    End Function

    Private Sub BtExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExport.Click
        If DgWHList.Rows.Count = 0 Then Exit Sub
        objDB.InportInExcel(strSaveSql, "倉庫別清單", DgWHList, GetQueryCondition)
    End Sub

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadWHList("")
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim intNw As Integer

        If CobWHID.Enabled = True Then
            intNw = 1
        Else
            intNw = 0
        End If

        If SaveData(intNw) = True Then
            MsgBox("操作成功.", MsgBoxStyle.Exclamation, "提示信息")
            Init()
            LoadWHList("")
        End If
    End Sub

    Private Sub DgWHList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        CellClick()
    End Sub

    Sub CellClick()
        If DgWHList.Rows.Count = 0 Then Exit Sub

        ShowText()
        'ChangeUI(1)
    End Sub

    Private Sub CobWHID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobWHID.SelectedIndexChanged
        Dim strSql As String

        If CobWHID.Text = "ALL" Then
            CobWHName.Text = "ALL"
        Else
            Rs.Close()
            strSql = " select whname from m_wh_t where whid='" & CobWHID.Text & "' "
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                CobWHName.Text = Rs(0).ToString
            End If
            Rs.Close()
        End If
    End Sub

    Private Sub CobWHName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strSql As String

        If CobWHName.Text = "ALL" Then
            CobWHID.Text = "ALL"
        Else
            Rs.Close()
            strSql = " select whid from m_wh_t where whname='" & CobWHName.Text & "' and usey='Y'"
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                CobWHID.Text = Rs(0).ToString
            End If
            Rs.Close()
        End If
    End Sub

    Private Sub CobWHID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CobWHID.KeyDown, CobWHName.KeyDown, CobFloor.KeyDown, CobFactory.KeyDown
        ClearGrid()
    End Sub


    Private Sub CobWHID_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobWHID.DropDownClosed, CobWHName.DropDownClosed, CobFloor.DropDownClosed, CobFactory.DropDownClosed
        ClearGrid()
    End Sub

    Private Sub ClearGrid()
        If DgWHList.Enabled = True Then
            DgWHList.Rows.Clear()
            ToolCount.Text = ""
            TxtRemark.Text = ""
        End If
    End Sub

    Private Sub FrmMgWHinfo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Alt Then
            BtNew_Click(sender, e)
        ElseIf e.KeyCode = Keys.M AndAlso e.Alt Then
            BtModify_Click(sender, e)
        ElseIf e.KeyCode = Keys.S AndAlso e.Alt Then
            BtSave_Click(sender, e)
        ElseIf e.KeyCode = Keys.D AndAlso e.Alt Then
            BtDelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.U AndAlso e.Alt Then
            BtReturn_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            BtExport_Click(sender, e)
        ElseIf e.KeyCode = Keys.R AndAlso e.Alt Then
            BtRefresh_Click(sender, e)
        ElseIf e.KeyCode = Keys.Q AndAlso e.Alt Then
            BtClose_Click(sender, e)
        End If
    End Sub


    Private Sub Chkusey_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkusey.CheckStateChanged
        If Me.Chkusey.Checked = False And Me.Chkusey.Enabled = True Then
            Dim strWHID As String
            Dim strFloorid As String
            strWHID = CobWHID.Text
            strFloorid = Me.CobFloor.Text
            If CheckWhid(strWHID, strFloorid) = True Then
                MessageBox.Show("該倉庫有庫存,不能作廢！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Chkusey.Checked = True
            End If
        End If
    End Sub


    Private Sub Toolfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolfind.Click
        ChangeUI(4)
        Me.DgWHList.Rows.Clear()
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        LoadFloor()
        LoadWHID()
        LoadWHName()
        Me.CobFloor.Items.Insert(0, "All")
        Me.CobFloor.SelectedIndex = 0
        Me.CobWHID.Items.Insert(0, "All")
        Me.CobWHID.SelectedIndex = 0
        Me.CobFactory.Items.Insert(0, "All")
        Me.CobFactory.SelectedIndex = 0
        Me.CobWHName.Items.Insert(0, "All")
        Me.CobWHName.SelectedIndex = 0
    End Sub

    Private Sub Toolreflash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolreflash.Click
        ChangeUI(0)
        Dim strWhere As String = ""  'whid='' whname floorid  factory usey
        If Me.CobWHID.Text.Trim <> "All" Then
            strWhere = strWhere & " and whid ='" & Me.CobWHID.Text.Trim & "'"
        End If

        If Me.Chkusey.Checked Then
            strWhere = strWhere & " and usey='Y'"
        Else
            strWhere = strWhere & " and usey='N'"
        End If

        If Me.CobFloor.Text.Trim <> "All" Then
            strWhere = strWhere & " and floorid='" & Me.CobFloor.Text.Trim & "'"
        End If

        If Me.CobFactory.Text.Trim <> "All" Then
            strWhere = strWhere & " and factory='" & Me.CobFactory.Text.Trim.Substring(0, 2) & "'"
        End If

        If Me.CkbControl.Checked Then
            strWhere = strWhere & " and typeid='C'"
        Else
            strWhere = strWhere & " and typeid='G'"
        End If

        If Me.CobWHName.Text.Trim <> "All" Then
            strWhere = strWhere & " and whname='" & Me.CobWHName.Text.Trim & "'"
        End If

        LoadWHList(strWhere)
    End Sub

    Private Sub BtClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub
End Class