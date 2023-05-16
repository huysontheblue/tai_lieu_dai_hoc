Imports System.Data.SqlClient

'****************************************************************************
'* 文件名稱：FrmMgArea.vb
'* 摘    要：倉庫別維護程式
'* 當前版本：1.01
'* 作    者：Anday_xu 
'* 完成日期：2011年08月17日
'****************************************************************************

Public Class FrmMgArea
    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader
    Private strSaveSql As String
    Private g_User As String = MainFrame.SysCheckData.SysMessageClass.UseId
    Const ParentKey = "m0880_"
    Const TKeyfix = "m7007"

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
        If Rs.HasRows Then
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
        End If
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
                FillRightButton(BtNew, BtNew.Tag)
                FillRightButton(BtExport, BtExport.Tag)
                FillRightButton(BtModify, BtModify.Tag)
                FillRightButton(BtDelete, BtDelete.Tag)

                BtReturn.Enabled = False

                DgWHList.Enabled = True
                TxtStoQty.Enabled = False
                CobArea.Enabled = False
                CobFloor.Enabled = False
                Me.ChkUsey.Enabled = False
                TxtStoQty.Text = ""
                LoadArea()
            Case 1
                BtNew.Enabled = False
                BtReturn.Enabled = True
            Case 2 'New
                BtNew.Enabled = False
                BtModify.Enabled = False
                BtDelete.Enabled = False
                BtExport.Enabled = False
                BtSave.Enabled = True
                BtReturn.Enabled = True

                CobArea.Text = ""
                TxtStoQty.Text = ""
                CobFloor.SelectedIndex = -1

                DgWHList.Enabled = False
                CobFloor.Enabled = True
                Me.ChkUsey.Enabled = True
                TxtStoQty.Enabled = True
                CobArea.Enabled = True
                CobArea.Items.Clear()
            Case 3 'Edit
                BtNew.Enabled = False
                BtModify.Enabled = False
                BtSave.Enabled = True
                BtReturn.Enabled = True
                BtExport.Enabled = False
                BtDelete.Enabled = False

                DgWHList.Enabled = False
                CobArea.Enabled = False
                Me.ChkUsey.Enabled = True
                CobFloor.Enabled = True
                DgWHList.Enabled = False
                TxtStoQty.Enabled = True
        End Select

    End Sub

    Private Sub FillRightButton(ByRef BtName As ToolStripButton, ByVal Enable As String)
        If Enable = "Y" Then
            BtName.Enabled = True
        Else
            BtName.Enabled = False
        End If
    End Sub

    '加載樓層
    Private Sub LoadFloor()
        Dim strSql As String

        CobFloor.Items.Clear()
        strSql = " select distinct(floorid) from m_wharea_t where usey='Y' and floorid is not null "
        Rs = objDB.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                CobFloor.Items.Add(Rs(0).ToString)
            End While
            CobFloor.SelectedIndex = 0
        End If
        Rs.Close()
        '
    End Sub

    '加載區域
    Private Sub LoadArea()
        Dim strSql As String

        CobArea.Items.Clear()
        strSql = " select distinct areaid from m_wharea_t where usey='Y' and floorid is not null "
        Rs = objDB.GetDataReader(strSql)
        If Rs.HasRows Then
            While Rs.Read
                CobArea.Items.Add(Rs(0).ToString)
            End While
        End If
        Rs.Close()
    End Sub

    Private Sub Init()
        LoadFloor()
        ChangeUI(0)
        LoadAreaList()
    End Sub

    '加載所有區域
    Private Sub LoadAreaList()
        Dim strSql As String
        Dim strDt As String
        Dim dt As Date

        strSql = " select areaid, floorid, palletqty, userid, intime,usey from m_wharea_t order by areaid "

        Rs = objDB.GetDataReader(strSql)

        DgWHList.Rows.Clear()
        If Rs.HasRows Then
            While Rs.Read
                dt = Rs(4)
                strDt = dt.ToString("yyyy-MM-dd HH:mm")
                DgWHList.Rows.Add(Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString, strDt, Rs(5).ToString)
            End While
        End If
        Rs.Close()

        strSaveSql = strSql
        ToolCount.Text = DgWHList.Rows.Count.ToString
        cellclick()
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

    '保存數據
    Private Function SaveData(ByVal intNew As Integer) As Boolean
        Dim strArea As String
        Dim strQty As String
        Dim strFloor As String
        Dim strSql As String
        Dim bExist As Boolean

        Try
            strArea = CobArea.Text
            strFloor = CobFloor.Text
            strQty = TxtStoQty.Text

            If strArea = "" Then
                MsgBox("儲位名稱不能為空.", 48, "Warning")
                Return False
            End If

            If strFloor = "" Then
                MsgBox("倉庫位置不能為空.", 48, "Warning")
                Return False
            End If

            If intNew = 1 Then
                strSql = " select * from m_wharea_t where floorid='" & strFloor & "' and areaid='" & strArea & "' "
                Rs = objDB.GetDataReader(strSql)
                If Rs.Read Then
                    bExist = True
                Else
                    bExist = False
                End If
                Rs.Close()
                If bExist = True Then
                    MsgBox("[" & strFloor & "-" & strArea & "]已經存在.", MsgBoxStyle.Exclamation, "提示信息")
                    Return False
                End If
            End If

            strSql = " delete from m_wharea_t where floorid='" & strFloor & "' and areaid='" & strArea & "' " _
                   & " insert into m_wharea_t (floorid, areaid, palletqty, usey, userid, intime) " _
                   & " values ('" & strFloor & "', '" & strArea & "', '" & TxtStoQty.Text & "','" & IIf(Me.ChkUsey.Checked, "Y", "N") & "','" & g_User & "', getdate()) " _
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
        LoadRights()
        Init()
    End Sub

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        ChangeUI(2)
    End Sub

    Private Sub DgWHList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        cellclick()
    End Sub

    Sub cellclick()
        ShowText()
        'ChangeUI(1)
    End Sub

    Private Sub ShowText()
        If DgWHList.Rows.Count > 0 Then
            CobArea.Text = DgWHList.CurrentRow.Cells(0).Value.ToString
            CobFloor.Text = DgWHList.CurrentRow.Cells(1).Value.ToString
            TxtStoQty.Text = DgWHList.CurrentRow.Cells(2).Value.ToString
            If DgWHList.CurrentRow.Cells("ColUsey").Value.ToString.Trim = "Y" Then
                Me.ChkUsey.Checked = True
            Else
                Me.ChkUsey.Checked = False
            End If
        End If
    End Sub

    Private Sub BtReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReturn.Click
        Init()
    End Sub

    Private Sub BtModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtModify.Click
        If Checkarea() = True Then
            MessageBox.Show("該儲位有庫存不能修改！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ChangeUI(3)
    End Sub

    Function Checkarea() As Boolean
        ''判斷儲位是否有庫存，有的話不能刪除。
        Dim strArea As String
        Dim strFloor As String
        strArea = CobArea.Text
        StrFloor = CobFloor.Text
        Dim strSql As String = "  select * from m_carton_t  where  cartonstatus ='I' and  floorid='" & strFloor & "' and Areaid= '" & strArea & "'"
        Dim dt As DataTable = objDB.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click
        Dim strSql As String
        Dim strArea As String
        Dim strFloor As String

        strArea = CobArea.Text
        strFloor = CobFloor.Text

        If Checkarea() = True Then
            MessageBox.Show("該儲位有庫存不能作廢！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MsgBox("確實要作廢[ " & strArea & "-" & strFloor & " ]嗎？", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "確認信息") = MsgBoxResult.Yes Then
            strSql = " update m_wharea_t set usey='N' where floorid='" & strFloor & "' and areaid='" & strArea & "' "
            objDB.ExecSql(strSql)
            MsgBox("操作成功.", MsgBoxStyle.Exclamation, "提示信息")
            Init()
            LoadAreaList()
        End If
    End Sub

    Private Function GetQueryCondition() As String
        Return ""
    End Function

    Private Sub BtExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExport.Click
        If DgWHList.Rows.Count = 0 Then Exit Sub
        objDB.InportInExcel(strSaveSql, "倉庫別清單", DgWHList, GetQueryCondition)
    End Sub

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadAreaList()
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
            LoadAreaList()
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

    Private Sub CobArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CobArea.KeyDown, CobFloor.KeyDown
        ClearGrid()
    End Sub

    Private Sub CobArea_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobArea.DropDownClosed, CobFloor.DropDownClosed
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

    Private Sub TxtStoQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStoQty.KeyPress
        Dim ctrTextBox As TextBox
        ctrTextBox = CType(sender, TextBox)

        If ctrTextBox.Text = "" AndAlso e.KeyChar = ChrW(Keys.D0) AndAlso ctrTextBox.Text.Length > 3 Then
            e.Handled = True
            Exit Sub
        End If

        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then '
            e.Handled = False
        Else
            e.Handled = True
        End If

        If ctrTextBox.Text.Length > 5 Then
            If e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub BtClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub
End Class