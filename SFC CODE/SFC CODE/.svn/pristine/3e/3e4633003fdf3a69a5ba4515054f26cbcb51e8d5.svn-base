Imports MainFrame
Imports System.Data.SqlClient
Imports System.Text

Public Class FrmWhMove
    '*****************************
    'Function : 倉庫調撥作業
    'CreateTime: 2009/1/9
    'create by: tangxiang
    '*****************************
    Dim Pubclass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim G_StrMoveid As String = ""  '最大調撥單號

    Private Sub FrmWhMove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '加載公司權限 
        'DoRights()
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)

        CobMoveType.Items.Add("GC-良品到管制")
        CobMoveType.Items.Add("CG-管制到良品")
        CobMoveType.Items.Add("GG-良品到良品")
        CobMoveType.Items.Add("CC-管制到管制")

        ContorState("RETURN")

    End Sub

#Region "按鈕單擊事件"

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        ContorState("NEW")
        ChkSelectAll.Checked = False
    End Sub     '新增

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim Inti As Integer  '用於 for 循環
        Dim Intn As Integer = 0 '用於計數
        Dim IntCout As Integer '調撥總數量
        Dim Strsql As New StringBuilder

        DGShipList.EndEdit()
        If Trim(txtMoveWhid.Text) = "" Then
            MessageBox.Show("請輸入[ERP調撥單號]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMoveWhid.Focus()
            Exit Sub
        End If
        If CobFactory.SelectedIndex = -1 Then
            MessageBox.Show("請選擇[公司]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobFactory.Focus()
            Exit Sub
        End If
        If Trim(txtPartid.Text) = "" Then
            MessageBox.Show("請輸入[料件編號]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPartid.Focus()
            Exit Sub
        End If
        If Trim(txtQty.Text) = "" Then
            MessageBox.Show("請輸入[調撥數量]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQty.Focus()
            Exit Sub
        End If
        If Trim(txtController.Text) = "" Then
            MessageBox.Show("請輸入[管制人]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtController.Focus()
            Exit Sub
        End If
        If Trim(txtControlTime.Text) = "" Then
            MessageBox.Show("請輸入[管制期限]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtControlTime.Focus()
            Exit Sub
        End If
        If CobMoveType.SelectedIndex = -1 Then
            MessageBox.Show("請選擇[調撥類型]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobMoveType.Focus()
            Exit Sub
        End If
        If CobOutWhid.SelectedIndex = -1 Then
            MessageBox.Show("請選擇[調出倉]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobOutWhid.Focus()
            Exit Sub
        End If
        If CobIntoWhid.SelectedIndex = -1 Then
            MessageBox.Show("請選擇[調入倉]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobIntoWhid.Focus()
            Exit Sub
        End If
        If CobIntoFloor.SelectedIndex = -1 Then
            MessageBox.Show("請選擇[調入樓層]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobIntoFloor.Focus()
            Exit Sub
        End If
        'If CobIntoAreaid.SelectedIndex = -1 Then
        '    MessageBox.Show("請選擇[調入區域]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    CobIntoAreaid.Focus()
        '    Exit Sub
        'End If
        If Trim(txtMoveReason.Text) = "" Then
            MessageBox.Show("請輸入[調撥原因]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMoveReason.Focus()
            Exit Sub
        End If

        'check “調撥類型”與“選擇倉”是否相符
        If CheckWhType() = False Then
            MessageBox.Show("[調撥類型]與所選擇的[倉別]不符！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobMoveType.Focus()
            Exit Sub
        End If
        If DGShipList.Rows.Count <= 0 Then
            MessageBox.Show("當前條件下無資料可供調撥！或者您需要按下[刷新]按鈕", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '判斷表格中是否有選中項
        If CheckNull(DGShipList, 0) = True Then
            MessageBox.Show("表格中無選中項，請勾選待調撥項次！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            '取得最大調撥單號
            G_StrMoveid = Getmaxid()
            '計算“勾選數量”總和
            For Inti = 0 To DGShipList.Rows.Count - 2
                If DGShipList.Item(0, Inti).Value = 1 Then
                    IntCout = IntCout + CType(DGShipList.Item(5, Inti).Value, Integer)
                End If
            Next
            '提示“勾選數量”與“輸入數量”是否相等
            If IntCout = CType(txtQty.Text, Integer) Then
                Strsql = GetStrsql(IntCout)
            Else
                If MessageBox.Show("您勾選的 [數量總和] 與輸入的 [調撥數量] 不相等，是否依照 [勾選的總數量] 進行調撥？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                    Strsql = GetStrsql(IntCout)
                Else
                    Return
                End If
            End If

            Pubclass.ExecSql(Strsql.ToString)
            Strsql.Remove(0, Strsql.ToString.Length)
            MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ContorState("RETURN")
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "FrmWhMove", "MesWarehouseManage", "BtSave_Click")
        End Try

    End Sub    '保存

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRefresh.Click
        Dim Strsql As String
        Dim Rs As SqlDataReader
        Dim Strtemp As String = ""
        'Dim Inti As Integer '用於for循環
        Dim IntCount As Integer = 0 '用於總計

        If Trim(txtPartid.Text) = "" Then
            MessageBox.Show("請輸入[料件編號]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPartid.Focus()
            Exit Sub
        End If
        If CobOutWhid.SelectedIndex = -1 Then
            MessageBox.Show("請選擇[調出倉]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobOutWhid.Focus()
            Exit Sub
        End If
        If CobFactory.Text = "" Then
            MessageBox.Show("請選擇[公司]！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobFactory.Focus()
            Exit Sub
        End If
        DGShipList.Rows.Clear()
        If ChkDtp.Checked = True Then
            Strtemp = " and a.intime between '" & StartDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' and '" & EndDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' "
        End If
        Strsql = "select moid,intime,floorid,areaid,sum(qty) as qty from (select a.moid,substring(convert(varchar,a.intime, 120), 1, 10) as Intime," & _
                 "a.floorid,a.areaid,sum(a.cartonqty) as qty from m_carton_t a, m_mainmo_t b where a.moid = b.moid and " & _
                 "b.partid = '" & Trim(txtPartid.Text) & "'and a.whid ='" & Trim(CobOutWhid.Text) & "' and a.cartonstatus='I'" & _
                 " and b.factory='" & CobFactory.Text.Substring(0, InStr(CobFactory.Text, "-") - 1) & "'" & _
                 "" + Strtemp + "group by a.moid,a.intime,a.floorid,a.areaid) g group by moid,intime,floorid,areaid"
        Rs = Pubclass.GetDataReader(Strsql)
        If Rs.HasRows Then
            While Rs.Read
                DGShipList.Rows.Add(0, Rs("moid").ToString, Rs(1).ToString, Rs("floorid").ToString, Rs("areaid").ToString, Rs("qty"))
            End While
        End If
        Rs.Close()
        If DGShipList.Rows.Count <= 0 Then Exit Sub
        'For Inti = 0 To DGShipList.Rows.Count - 1
        '    IntCount += DGShipList.Item(5, Inti).Value
        'Next

        DGShipList.Rows.Add(0, "", "", "", "合計", "0")

    End Sub '刷新

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        ContorState("RETURN")
    End Sub  '返回

    Private Sub BtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub    '退出

#End Region

#Region "供調用功能函數"

    '按鈕狀態控制
    Private Sub ContorState(ByVal flag As String)
        Select Case flag
            Case "NEW"
                CobFactory.Enabled = True
                txtPartid.Enabled = True
                txtMoveWhid.Enabled = True
                CobMoveType.Enabled = True
                CobOutWhid.Enabled = True
                CobIntoWhid.Enabled = True
                txtMoveReason.Enabled = True
                ChkDtp.Enabled = True
                txtQty.Enabled = True
                txtController.Enabled = True
                txtControlTime.Enabled = True
                MVDtp.Enabled = True
                DGShipList.Enabled = True
                CobIntoFloor.Enabled = True
                CobIntoAreaid.Enabled = True

                txtPartid.Text = ""
                txtMoveReason.Text = ""
                txtQty.Text = ""
                txtMoveWhid.Text = ""
                txtController.Text = ""
                txtControlTime.Text = ""
                CobFactory.SelectedIndex = -1
                CobMoveType.SelectedIndex = -1
                CobOutWhid.SelectedIndex = -1
                CobIntoWhid.SelectedIndex = -1
                CobIntoFloor.SelectedIndex = -1
                CobIntoAreaid.SelectedIndex = -1

                BtNew.Enabled = False
                BtSave.Enabled = True
                BtRefresh.Enabled = True
                BtCancel.Enabled = True
                BtExit.Enabled = True
            Case "RETURN"
                CobFactory.Enabled = False
                txtPartid.Enabled = False
                CobMoveType.Enabled = False
                txtMoveWhid.Enabled = False
                CobOutWhid.Enabled = False
                CobIntoWhid.Enabled = False
                txtMoveReason.Enabled = False
                ChkDtp.Enabled = False
                txtQty.Enabled = False
                MVDtp.Enabled = False
                DGShipList.Enabled = False
                CobIntoFloor.Enabled = False
                CobIntoAreaid.Enabled = False
                StartDtp.Enabled = False
                EndDtp.Enabled = False

                txtPartid.Text = ""
                txtMoveReason.Text = ""
                txtQty.Text = ""
                txtMoveWhid.Text = ""
                txtController.Text = ""
                txtControlTime.Text = ""
                CobFactory.SelectedIndex = -1
                CobMoveType.SelectedIndex = -1
                CobOutWhid.SelectedIndex = -1
                CobIntoWhid.SelectedIndex = -1
                CobIntoFloor.SelectedIndex = -1
                CobIntoAreaid.SelectedIndex = -1
                DGShipList.Rows.Clear()
                CobIntoFloor.Items.Clear()

                BtNew.Enabled = True
                BtSave.Enabled = False
                BtRefresh.Enabled = False
                BtCancel.Enabled = False
                BtExit.Enabled = True
                txtController.Enabled = False
                txtControlTime.Enabled = False
        End Select

    End Sub

    '取得保存數據庫
    '
    Private Function GetStrsql(ByVal IntCout As Integer) As StringBuilder
        Dim StrMV As New StringBuilder
        Dim Inti As Integer  '用於 for 循環
        Dim StrReMark As String = "" '備注信息 
        Dim Intn As Integer = 1 '記錄序號 

        For Inti = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(0, Inti).Value = 1 Then
                StrReMark = StrReMark + "(" & Intn & ")從倉庫:" & CobOutWhid.Text & " 樓層:" & DGShipList.Item(3, Inti).Value.ToString & " 儲位:" & DGShipList.Item(4, Inti).Value.ToString & " 調出數量:" & DGShipList.Item(5, Inti).Value.ToString & " ;"
                Intn = Intn + 1
            End If
        Next

        txtQty.Text = IntCout   '重置調撥數量
        '數據處理
        StrMV.Append("insert into M_RemoveM_t(moveid,ERPmoveid,partid,cwhid,rwhid,mvqty,reasons,remark,typeid," & _
                     "userid,intime,movedate,controller,controltime,factoryid)values('" & G_StrMoveid & "','" & Trim(txtMoveWhid.Text) & "','" & Trim(txtPartid.Text) & "'," & _
                     "'" & Trim(CobOutWhid.Text) & "','" & Trim(CobIntoWhid.Text) & "','" & IntCout & "','" & Trim(txtMoveReason.Text) & "'," & _
                     "'" & StrReMark & "','" & getvalue(CobMoveType.Text) & "','" & SysCheckData.SysMessageClass.UseId & "'," & _
                     "getdate(),'" & MVDtp.Value.ToString("yyyy/MM/dd HH:mm") & "','" & Trim(txtController.Text) & "'," & Trim(txtControlTime.Text) & ",'" & CobFactory.Text.Substring(0, InStr(CobFactory.Text, "-") - 1) & "')")
        StrMV.Append(Environment.NewLine)
        For Inti = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(0, Inti).Value = 1 Then
                StrMV.Append("Insert into M_RemoveD_t(moveid,cartonid,cartonmvqty,cwhid,careaid,cfloorid,rwhid,rareaid," & _
                             "rfloorid,userid,intime,DisposeY) select '" & G_StrMoveid & "',cartonid,cartonqty," & _
                             "whid,areaid,floorid,'" & Trim(CobIntoWhid.Text) & "','" & Trim(CobIntoAreaid.Text) & "'," & _
                             "'" & Trim(CobIntoFloor.Text) & "','" & SysCheckData.SysMessageClass.UseId & "',getdate(),'N' " & _
                             "from m_carton_t a join m_mainmo_t b  on a.moid=b.moid where a.cartonstatus='I'and b.partid=" & _
                             "'" & Trim(txtPartid.Text) & "' and a.intime between '" & StartDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' " & _
                             "and '" & EndDtp.Value.ToString("yyyy/MM/dd HH:mm") & "'and a.whid='" & Trim(CobOutWhid.Text) & "'" & _
                             "and a.floorid='" & DGShipList.Item(3, Inti).Value.ToString & "'and a.areaid='" & DGShipList.Item(4, Inti).Value.ToString & "'" & _
                             "and a.moid='" & DGShipList.Item(1, Inti).Value.ToString & "'")
                StrMV.Append(Environment.NewLine)
                StrMV.Append("update a set a.whid='" & Trim(CobIntoWhid.Text) & "',a.areaid='" & Trim(CobIntoAreaid.Text) & "'," & _
                             "a.floorid='" & Trim(CobIntoFloor.Text) & "',a.updateuser='" & SysCheckData.SysMessageClass.UseId & "'," & _
                             "a.updatetime=getdate() from m_carton_t a join m_mainmo_t b on a.moid=b.moid where a.cartonstatus='I' and " & _
                             "b.partid='" & Trim(txtPartid.Text) & "' and a.intime between '" & StartDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' " & _
                             "and '" & EndDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' " & _
                             "and a.whid='" & Trim(CobOutWhid.Text) & "'and a.floorid='" & DGShipList.Item(3, Inti).Value.ToString & "' and " & _
                             "a.areaid='" & DGShipList.Item(4, Inti).Value.ToString & "'and a.moid='" & DGShipList.Item(1, Inti).Value.ToString & "'")
                StrMV.Append(Environment.NewLine)
            End If
        Next

        Return StrMV
    End Function

    '取最大調撥單號
    Private Function Getmaxid() As String
        Dim strSql As String
        Dim strReturn As String '返回字符串
        Dim StrTemp As String = ""
        Dim Rs As SqlDataReader

        strSql = "select right(max(Moveid),3) From m_RemoveM_t Where " & _
                 "Moveid like 'MV' + convert(varchar(6),getdate(),12)+'%'"
        Rs = Pubclass.GetDataReader(strSql)

        If Rs.Read Then
            StrTemp = Rs(0).ToString
            StrTemp = "1" & StrTemp
            StrTemp = Mid(CType(CType(StrTemp, Integer) + 1, String), 2, 3)
        End If
        If StrTemp = "" Then
            StrTemp = "001"
        End If
        Rs.Close()

        strReturn = "MV" & Now.Date.ToString("yyMMdd") & StrTemp

        Return strReturn

    End Function

    'check “調撥類型”與“選擇倉”是否相符
    Private Function CheckWhType() As Boolean
        Dim Strsql As String
        Dim Rs As SqlDataReader = Nothing
        Dim StrOut As String = ""
        Dim StrIn As String = ""

        Try
            '調出倉
            Strsql = "select Typeid from M_Wh_t where Whid='" & Trim(CobOutWhid.Text) & "'and usey='Y' "
            Rs = Pubclass.GetDataReader(Strsql)
            If Rs.Read Then
                StrOut = Rs(0).ToString
            End If
            Rs.Close()
            '調入倉
            Strsql = "select Typeid from M_Wh_t where Whid='" & Trim(CobIntoWhid.Text) & "'and usey='Y' "
            Rs = Pubclass.GetDataReader(Strsql)
            If Rs.Read Then
                StrIn = Rs(0).ToString
            End If
            Rs.Close()

            If getvalue(CobMoveType.Text) = StrOut + StrIn Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "FrmWhMove", "MesWarehouseManage", "Function_CheckWhType")
            Rs.Close()
            Return False
        End Try

    End Function

    Private Sub ChkDtp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDtp.CheckedChanged
        DGShipList.Rows.Clear()
        If StartDtp.Enabled = False Then
            StartDtp.Enabled = True
            EndDtp.Enabled = True
        Else
            StartDtp.Enabled = False
            EndDtp.Enabled = False
        End If

    End Sub

    ' 取得字串中“-”之前的值    
    '
    Private Function getvalue(ByVal str As String)
        Dim FlagInt As Integer
        FlagInt = InStr(Trim(str), "-")
        str = Trim(str)
        If FlagInt <> 0 Then
            str = str.Substring(0, FlagInt - 1)
        End If
        Return str
    End Function

    '帶出倉庫別
    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobFactory.SelectedIndexChanged
        Dim Rs As SqlDataReader
        Dim Strsql As String

        CobOutWhid.Items.Clear()
        CobIntoWhid.Items.Clear()
        DGShipList.Rows.Clear()
        Strsql = "select distinct whid from m_wh_t where factory='" & getvalue(CobFactory.Text) & "' and usey='Y'"
        Rs = Pubclass.GetDataReader(Strsql)
        If Rs.HasRows Then
            While Rs.Read
                CobOutWhid.Items.Add(Rs(0).ToString)
                CobIntoWhid.Items.Add(Rs(0).ToString)
            End While
        End If
        Rs.Close()

    End Sub

    ' 判斷數據是否全部沒選    
    '
    Private Function CheckNull(ByVal DgName As DataGridView, ByVal Intindex As Integer) As Boolean
        Dim i As Integer

        For i = 0 To DgName.RowCount - 1
            If DgName.Item(Intindex, i).Value Then
                Return False
                Exit Function
            End If
        Next
        Return True

    End Function

    '加載數據到 Combox
    '
    Private Sub LoadInf_Cobox(ByVal str As String, ByVal CoboxName As Windows.Forms.ComboBox)
        Dim Rs As SqlDataReader

        CoboxName.Items.Clear()
        Rs = Pubclass.GetDataReader(str)
        If Rs.HasRows Then
            While Rs.Read
                CoboxName.Items.Add(Rs(0).ToString)
            End While
        End If
        Rs.Close()

    End Sub

    '權限處理
    Public Sub FillFactory(ByRef ComBox As ComboBox, ByVal strUser As String)
        Dim strSql As String
        Dim rs As SqlDataReader
        '
        ComBox.Items.Clear()
        strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
               & " (select tkey from m_userright_t where tkey in " _
               & " (select tkey from m_logtree_t where tparent='F0_') " _
               & " and userid='" & strUser & "') "
        rs = Pubclass.GetDataReader(strSql)
        While rs.Read
            'ComBox.Items.Add(rs(0).ToString & "(" & rs(1).ToString & ")")
            ComBox.Items.Add(rs(1).ToString & "-" & rs(0).ToString)
        End While
        rs.Close()
        'ComBox.SelectedIndex = 0
    End Sub


    'Private Sub DoRights()
    '    Dim strSql As String
    '    Dim Rs As SqlDataReader
    '    '
    '    CobFactory.Items.Clear()
    '    strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
    '           & " (select tkey from m_userright_t where tkey='F010_' and userid='" & SysCheckData.SysMessageClass.UseId & "' " _
    '           & " union " _
    '           & " select tkey from m_userright_t where tkey='F011_' and userid='" & SysCheckData.SysMessageClass.UseId & "') "
    '    Rs = PubClass.GetDataReader(strSql)
    '    If Rs.HasRows Then
    '        While Rs.Read
    '            CobFactory.Items.Add(Rs(1).ToString & "-" & Rs(0).ToString)
    '        End While
    '    End If
    '    Rs.Close()
    'End Sub

#End Region

    Private Sub DGShipList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShipList.CellClick

        If DGShipList.Rows.Count <= 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex < 0 Then Exit Sub

        '反顯
        If e.ColumnIndex = 0 Then
            If DGShipList.Item(0, e.RowIndex).Value = 0 Then
                DGShipList.Item(0, e.RowIndex).Value = 1
            Else
                DGShipList.Item(0, e.RowIndex).Value = 0
            End If
        End If
        '數量累加
        AddCount()
    End Sub

    Private Sub CobIntoWhid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobIntoWhid.SelectedIndexChanged
        LoadInf_Cobox("select distinct(Floorid) from m_Wh_t where factory in(select buttonid from m_UserRight_t a join m_Logtree_t b on a.tkey=b.tkey where b.tparent='F0_' and a.userid= '" & SysCheckData.SysMessageClass.UseId & "')and usey='Y' and floorid <> ''", CobIntoFloor)

    End Sub

    Private Sub CobIntoFloor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobIntoFloor.SelectedIndexChanged
        LoadInf_Cobox("select Areaid from m_WhArea_t where Floorid='" & Trim(CobIntoFloor.Text) & "' and usey='Y'", CobIntoAreaid)

    End Sub

    Private Sub DGShipList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShipList.CellDoubleClick
        Dim FrmShowDetail As New FrmShowDetail
        Dim Strtemp As String = ""

        If DGShipList.Rows.Count <= 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex <= 0 Then Exit Sub

        FrmShowDetail.Text = "明細資料"
        FrmShowDetail.TabTitle = "箱號|箱裝數量|倉位|樓層|儲位"

        If ChkDtp.Checked = True Then
            Strtemp = " and intime between '" & StartDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' and '" & EndDtp.Value.ToString("yyyy/MM/dd HH:mm") & "' "
        End If
        FrmShowDetail.strSQL = "select a.cartonid,a.cartonqty,a.whid,a.floorid,a.areaid from m_carton_t a, m_mainmo_t b " & _
                 "where a.moid = b.moid and b.partid = '" & Trim(txtPartid.Text) & "'and a.whid ='" & Trim(CobOutWhid.Text) & "'" & _
                 " and a.cartonstatus='I'and a.floorid='" & DGShipList.Item(3, e.RowIndex).Value.ToString & "'and a.areaid=" & _
                 "'" & DGShipList.Item(4, e.RowIndex).Value.ToString & "'and b.moid='" & DGShipList.Item(1, e.RowIndex).Value.ToString & "'" + Strtemp
        FrmShowDetail.ShowDialog()

    End Sub

    Private Sub CobOutWhid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobOutWhid.SelectedIndexChanged
        DGShipList.Rows.Clear()

    End Sub

    Private Sub txtPartid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartid.TextChanged
        DGShipList.Rows.Clear()
    End Sub

    Private Sub txtPartid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartid.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '控制數字輸入
    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress, txtControlTime.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmWhMove_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.N AndAlso e.Alt Then
            BtNew_Click(sender, e)
        ElseIf e.KeyCode = Keys.S AndAlso e.Alt Then
            BtSave_Click(sender, e)
        ElseIf e.KeyCode = Keys.R AndAlso e.Alt Then
            BtRefresh_Click(sender, e)
        ElseIf e.KeyCode = Keys.C AndAlso e.Alt Then
            BtCancel_Click(sender, e)
        ElseIf e.KeyCode = Keys.X AndAlso e.Alt Then
            BtExit_Click(sender, e)
        End If

    End Sub

    'Tab---Enter觸發事件
    Private Sub CobFactory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobFactory.KeyPress, StartDtp.KeyPress, EndDtp.KeyPress, ChkDtp.KeyPress, CobMoveType.KeyPress, txtMoveReason.KeyPress, DGShipList.KeyPress, CobOutWhid.KeyPress, CobIntoWhid.KeyPress, CobIntoFloor.KeyPress, CobIntoAreaid.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtMoveWhid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMoveWhid.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub ChkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelectAll.CheckedChanged
        Dim Inti As Integer

        If ChkSelectAll.Checked = True Then
            '全選中
            For Inti = 0 To DGShipList.Rows.Count - 2
                DGShipList.Item(0, Inti).Value = 1
            Next
        Else
            '全置空
            For Inti = 0 To DGShipList.Rows.Count - 2
                DGShipList.Item(0, Inti).Value = 0
            Next
        End If
        '數量累加
        AddCount()
    End Sub

    '數量累加
    Private Sub AddCount()
        Dim Inti As Integer '用於for循環

        If DGShipList.Rows.Count <= 0 Then Exit Sub

        DGShipList.Item(5, DGShipList.Rows.Count - 1).Value = 0
        For Inti = 0 To DGShipList.Rows.Count - 2
            If DGShipList.Item(0, Inti).Value = 1 Then
                DGShipList.Item(5, DGShipList.Rows.Count - 1).Value += DGShipList.Item(5, Inti).Value
            End If
        Next
    End Sub

    Private Sub CobMoveType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobMoveType.SelectedIndexChanged
        DGShipList.Rows.Clear()
        If CobMoveType.Text = "CG-管制到良品" Or CobMoveType.Text = "GG-良品到良品" Then
            txtController.Enabled = False
            txtControlTime.Enabled = False
            txtControlTime.Text = "0"
            txtController.Text = "N/A"
        Else
            txtController.Enabled = True
            txtControlTime.Enabled = True
            txtControlTime.Text = ""
            txtController.Text = ""
        End If
    End Sub

    Private Sub BtReuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReuse.Click
        Dim FrmRMB As New FrmReMoveBack
        FrmRMB.ShowDialog()
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExit.Click
        Me.Close()
    End Sub
End Class