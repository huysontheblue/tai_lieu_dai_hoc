Imports System.Data.SqlClient

'****************************************************************************
'* 文件名稱：FrmMgWHInfo.vb
'* 摘    要：倉庫別維護程式
'* 當前版本：1.01
'* 作    者：Tim Liu
'* 完成日期：2007年12月12日
'****************************************************************************

Public Class FrmMgWHPart

    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader
    Private strSaveSql As String
    Private g_User As String = MainFrame.SysCheckData.SysMessageClass.UseId
    Const ParentKey = "m0890_"
    Const TKeyfix = "m7008"

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
        Dim ColValue As Color

        ColValue = TxtTmp.BackColor
        CobArea.BackColor = Color.White
        CobPart.BackColor = Color.White

        Select Case intStyle
            Case 0 '默認狀態
                'BtNew.Enabled = True
                'BtModify.Enabled = False
                'BtDelete.Enabled = False
                'BtSave.Enabled = False
                'BtReturn.Enabled = False
                'BtDelete.Enabled = False

                FillRightButton(BtNew, BtNew.Tag)
                BtModify.Enabled = False
                BtDelete.Enabled = False
                BtSave.Enabled = False

                FillRightButton(BtExport, BtExport.Tag)

                BtRefresh.Enabled = True
                BtReturn.Enabled = False


                DgWHList.Enabled = True
                BtExport.Enabled = True
                BtRefresh.Enabled = True
                CobArea.Enabled = True
                CobPart.Enabled = True
                LoadArea()
                If CobPart.Items.IndexOf("ALL") < 0 Then
                    CobPart.Items.Insert(0, "ALL")
                End If

                If CobArea.Items.IndexOf("ALL") < 0 Then
                    CobArea.Items.Insert(0, "ALL")
                End If
            Case 1
                'BtModify.Enabled = False
                'BtDelete.Enabled = True
                BtNew.Enabled = False
                BtReturn.Enabled = True
                FillRightButton(BtModify, BtModify.Tag)
                FillRightButton(BtDelete, BtDelete.Tag)

            Case 2 'New
                GB1.Visible = True
                GB1.Enabled = True
                DgWHList.Enabled = False
                BtNew.Enabled = False
                BtModify.Enabled = False
                BtDelete.Enabled = False
                BtExport.Enabled = False
                BtRefresh.Enabled = False
                BtSave.Enabled = True
                BtReturn.Enabled = True
                CobArea.Text = ""
                CobArea.Enabled = True
                CobPart.SelectedIndex = -1
                CobArea.BackColor = ColValue
                CobPart.BackColor = ColValue
                CobArea.Items.Remove("ALL")
                CobPart.Items.Remove("ALL")
                CobPart.Focus()
            Case 3 'Edit
                GB1.Visible = True
                GB1.Enabled = True
                CobPart.Enabled = False
                BtNew.Enabled = False
                BtModify.Enabled = False
                BtSave.Enabled = True
                BtReturn.Enabled = True
                BtDelete.Enabled = False
                DgWHList.Enabled = False
                BtExport.Enabled = False
                BtRefresh.Enabled = False
                DgWHList.Enabled = False
                CobArea.BackColor = ColValue
                CobPart.BackColor = ColValue
                CobPart.Items.Remove("ALL")
        End Select
    End Sub

    Private Sub FillRightButton(ByRef BtName As ToolStripButton, ByVal Enable As String)
        If Enable = "Y" Then
            BtName.Enabled = True
        Else
            BtName.Enabled = False
        End If
    End Sub

    '加載區域
    Private Sub LoadArea()
        Dim strSql As String

        CobArea.Items.Clear()
        CobArea.Items.Add("ALL")
        strSql = " select distinct areaid from m_wharea_t where usey='Y' and floorid is not null "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobArea.Items.Add(Rs(0).ToString)
        End While
        Rs.Close()
        CobArea.SelectedIndex = 0
    End Sub

    '加載料件清單
    Private Sub LoadPart()
        Dim strSql As String

        CobPart.Items.Clear()
        CobPart.Items.Add("ALL")
        strSql = " select distinct partid from m_mainmo_t  "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobPart.Items.Add(Rs(0).ToString)
        End While
        Rs.Close()
        CobPart.SelectedIndex = 0
    End Sub

    '初始化
    Private Sub Init()
        LoadRights()
        ChangeUI(0)
        LoadAreaPartList()
        LoadArea()
        LoadPart()
        DgWHList.Focus()
    End Sub

    '加載所有區域
    Private Sub LoadAreaPartList()
        Dim strSql As String
        Dim strDt As String
        Dim dt As Date

        strSql = " select partid, areaid, userid, intime from m_whpart_t where usey='Y' "
        If CobPart.Text <> "ALL" Then
            strSql = strSql & " and partid='" & CobPart.Text & "' "
        End If

        If CobArea.Text <> "ALL" Then
            strSql = strSql & " and areaid='" & CobArea.Text & "' "
        End If

        strSql = strSql & " order by partid "
        Rs = objDB.GetDataReader(strSql)

        DgWHList.Rows.Clear()
        While Rs.Read
            dt = Rs(3)
            strDt = dt.ToString("yyyy-MM-dd HH:mm")
            DgWHList.Rows.Add(Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, strDt)
        End While
        Rs.Close()

        strSaveSql = strSql
        ToolCount.Text = DgWHList.Rows.Count.ToString
    End Sub

    '檢查輸入料號是否正確
    Private Function CheckPartNO(ByVal strPartNo As String) As Boolean
        Dim strSql As String
        Dim bReturn As Boolean

        strSql = " select count(*) from matter_tab where partid='" & strPartNo & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            If Rs(0) > 0 Then
                bReturn = True
            Else
                bReturn = False
            End If
        Else
            bReturn = False
        End If

        Rs.Close()
        Return bReturn
    End Function

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

    '保存數據
    Private Function SaveData(ByVal intNew As Integer) As Boolean
        Dim strArea As String
        Dim strPart As String
        Dim strSql As String
        Dim bExist As Boolean

        Try
            strArea = CobArea.Text
            strPart = CobPart.Text

            If strArea = "" Then
                MsgBox("料件編號不能為空.", 48, "Warning")
                Return False
            End If

            If strPart = "" Then
                MsgBox("儲位名稱不能為空.", 48, "Warning")
                Return False
            Else
                If CheckPartNO(strPart) = False Then
                    MsgBox("料件編號輸入錯誤.", 48, "Warning")
                    Return False
                End If
            End If

            If intNew = 1 Then
                strSql = " select * from m_whpart_t where partid='" & strPart & "' and areaid='" & strArea & "' and usey='Y' "
                Rs = objDB.GetDataReader(strSql)
                If Rs.Read Then
                    bExist = True
                Else
                    bExist = False
                End If
                Rs.Close()
                If bExist = True Then
                    MsgBox("[" & strPart & "&" & strArea & "]已經存在.", MsgBoxStyle.Exclamation, "提示信息")
                    Return False
                End If
            End If

            strSql = " delete from m_whpart_t where partid='" & strPart & "' and areaid='" & strArea & "' " _
                   & " insert into m_whpart_t (partid, areaid, usey, userid, intime) " _
                   & " values ('" & strPart & "', '" & strArea & "', 'Y' ,'" & g_User & "', getdate()) " _
                   & "  "
            objDB.ExecSql(strSql)
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

    Private Sub DgWHList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        ShowText(e.RowIndex)
        ChangeUI(1)
    End Sub

    Private Sub ShowText(ByVal selectRow As Integer)
        If DgWHList.Rows.Count > 0 Then
            CobPart.Text = DgWHList.Item(0, selectRow).Value.ToString
            CobArea.Text = DgWHList.Item(1, selectRow).Value.ToString
        End If
    End Sub

    Private Sub BtReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReturn.Click
        Init()
    End Sub

    Private Sub BtModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtModify.Click
        ChangeUI(3)
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click
        Dim strSql As String
        Dim strArea As String
        Dim strPart As String

        strPart = CobPart.Text
        strArea = CobArea.Text

        If MsgBox("確實要作廢[ " & strPart & "&" & strArea & " ]嗎？", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "確認信息") = MsgBoxResult.Yes Then
            strSql = " update m_whpart_t set usey='N' where partid='" & strPart & "' and areaid='" & strArea & "' "
            objDB.ExecSql(strSql)
            MsgBox("操作成功.", MsgBoxStyle.Exclamation, "提示信息")
            Init()
            LoadAreaPartList()
        End If
    End Sub

    Private Function GetQueryCondition() As String
        Return ""
    End Function

    Private Sub BtExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExport.Click
        If DgWHList.Rows.Count = 0 Then Exit Sub
        objDB.InportInExcel(strSaveSql, "倉庫別清單", DgWHList, GetQueryCondition)
    End Sub

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRefresh.Click
        LoadAreaPartList()
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim intNw As Integer

        If CobArea.Enabled = True Then
            intNw = 1
        Else
            intNw = 0
        End If

        If SaveData(intNw) = True Then
            MsgBox("操作成功.", MsgBoxStyle.Exclamation, "提示信息")
            Init()
            LoadAreaPartList()
        End If
    End Sub

    Private Sub CobWHQ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DgWHList.Rows.Clear()
    End Sub

    Private Sub ClearGrid()
        If DgWHList.Enabled = True Then
            DgWHList.Rows.Clear()
            ToolCount.Text = ""
        End If
    End Sub

    Private Sub CobArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CobArea.KeyDown, CobPart.KeyDown
        ClearGrid()
    End Sub

    Private Sub CobArea_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobArea.DropDownClosed, CobPart.DropDownClosed
        ClearGrid()
    End Sub

    Private Sub FrmMgArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

   
End Class