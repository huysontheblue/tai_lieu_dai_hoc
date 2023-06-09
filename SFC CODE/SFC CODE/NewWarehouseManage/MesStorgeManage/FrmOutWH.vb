Imports System.Data.SqlClient

<Microsoft.VisualBasic.ComClass()> Public Class FrmOutWH

    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader
    Private ClassInf As New InfClass
    Private g_PartID As String
    Private g_Item As String
    Private g_CustID As String
    Private g_User As String
    Private g_Rights As String
    Private g_WHID As String
    Private g_KDShip As Boolean = False

    '窗體加載
    Private Sub FrmOutWH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
        DoRights()
        LoadInvoiceList()
    End Sub

    '初始化變量
    Private Sub Init()
        TxtCust.Text = ""
        TxtDate.Text = ""
        TxtAddress.Text = ""
        TxtRemark.Text = ""
        TxtScan.Text = ""
        LabInfo.Text = ""
        LabLocal.Text = ""
        g_PartID = ""
        g_Item = ""
        g_CustID = ""
        g_WHID = ""
        LabCartCoun.Text = ""
        LabWHID.Text = ""
        g_User = MainFrame.SysCheckData.SysMessageClass.UseId
        DGShipList.Rows.Clear()
        DGScanList.Rows.Clear()
        PlScan.Enabled = False
        ChangeUI()
    End Sub

    Private Sub ClearKText()
        TxtVInvo.Text = ""
        LaState.Text = ""
        CobSpType.SelectedIndex = -1
        TxtCount.Text = ""
        TxtSM.Text = ""
        ' LoadPartList()
        CobPart.Text = ""
        g_WHID = ""
        g_PartID = ""
        TxtVInvo.Focus()
        EnableMainatain()
    End Sub

    '權限處理
    Private Sub DoRights()
        Dim strSql As String

        strSql = " select * from m_userright_t where tkey='m0820a_' and userid='" & g_User & "'" _
                  & vbNewLine & "select * from m_userright_t where tkey='m0800_' and userid='" & g_User & "'"

        Rs = objDB.GetDataReader(strSql)
        If Rs.Read() Then
            BtReuse.Enabled = True
        End If
        Rs.NextResult()
        If Rs.Read() Then
            R1.Enabled = True
            R2.Enabled = True
        End If
        Rs.Close()
        g_Rights = ""
        CobFacory.Items.Clear()
        strSql = " select a.ttext, a.buttonid from m_logtree_t a join m_userright_t b on a.tkey=b.tkey where a.tparent='F0_' and userid='" & g_User & "'"
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            g_Rights = g_Rights & "," & "'" & Rs(1).ToString & "'"
            CobFacory.Items.Add(Rs(0).ToString & "(" & Rs(1).ToString & ")")
        End While

        CobFacory.SelectedIndex = 0
        g_Rights = Mid(g_Rights, 2)
        If g_Rights = "" Then g_Rights = "''"
        Rs.Close()
    End Sub

    '格式化提示信息
    Private Sub Meg(ByVal strValue As String, ByVal intType As Integer, ByVal bShowBox As Boolean)
        Dim msgStyle As MsgBoxStyle
        Dim strTitle As String
        Dim strPath As String

        LabInfo.Text = strValue
        Select Case intType
            Case 0
                LabInfo.ForeColor = Color.Red
                msgStyle = MsgBoxStyle.Critical
                strTitle = "錯誤信息"
                strPath = Application.StartupPath & "\Error.wav"
                If My.Computer.FileSystem.FileExists(strPath) Then
                    My.Computer.Audio.Play(Application.StartupPath & "\Error.wav", AudioPlayMode.Background)
                End If
            Case 1
                LabInfo.ForeColor = Color.Green
                msgStyle = MsgBoxStyle.Information
                strTitle = "提示信息"
            Case 2
                LabInfo.ForeColor = Color.Blue
                msgStyle = MsgBoxStyle.Exclamation
                strTitle = "警告信息"
            Case Else
                strTitle = ""
        End Select

        If bShowBox Then
            MsgBox(strValue, msgStyle, strTitle)
        End If
    End Sub

    '取系統出貨單號
    Private Function GetNewWHID(ByVal strPart As String, ByVal strInvoice As String) As String
        Dim strSql, str As String
        Dim strMaxID As String
        Dim SvrDate As Date

        Try
            strMaxID = ""
            strSql = " select getdate(), max(outwhid) from m_whoutm_t where " _
                   & " substring(outwhid,3,6) = convert(varchar(6), getdate(), 12) "
            Rs = objDB.GetDataReader(strSql)

            If Rs.Read Then
                SvrDate = Rs(0)
                strMaxID = Rs(1).ToString
            End If

            If strMaxID = "" Then
                str = "WO" & Format(SvrDate, "yyMMdd") & "0001"
            Else
                str = "WO" & Mid((1 & Mid(strMaxID, 3)) + 1, 2)
            End If

            Rs.Close()

            strSql = " insert into m_whoutm_t (outwhid, partid, orderseq, shipqty, states, userid, intime) " _
                   & " values ('" & str & "', '" & strPart & "', '" & strInvoice & "', '0', '1', '" & g_User & "', getdate()) " & vbCrLf

            strSql = strSql & " update m_shipd_t set outwhid='" & str & "', states='1' where invoice='" & strInvoice & "' and partid='" & strPart & "' "

            objDB.ExecSql(strSql)

        Catch ex As Exception
            str = ""
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "GetNewWHID", "sys")
        End Try

        Return str
    End Function

    '取得箱號對應的WHID
    Private Function GetWHIDByCarton(ByVal strCarton As String)
        Dim strSql As String
        Dim strReturn As String

        strSql = " select * from m_whoutd_t where cartonid='" & strCarton & "' "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            strReturn = Rs(0).ToString
        Else
            strReturn = ""
        End If

        Rs.Close()
        Return strReturn
    End Function

    '加載Invoice清單
    Private Sub LoadInvoiceList()
        Dim strSql As String

        CobInvoice.Items.Clear()
        strSql = " select distinct a.invoice from m_shipm_t a, m_shipd_t b " _
               & " where a.invoice=b.invoice and (b.states='E' or b.states='1') " _
               & " and b.eintime>getdate()-30 and a.factory in (" & g_Rights & ") and a.usey='Y' " _
               & " and (a.flag<>'2' or a.flag is null) order by a.invoice "
        Rs = objDB.GetDataReader(strSql)

        While Rs.Read()
            CobInvoice.Items.Add(Rs(0).ToString())
        End While
        Rs.Close()
    End Sub

    '加載出貨地址
    Public Sub LoadShipInfoMain(ByVal strInvoice As String)
        Dim strSql As String
        Dim strSource As String
        Dim dt As Date

        TxtCust.Text = ""
        TxtAddress.Text = ""
        TxtDate.Text = ""

        '讀出貨地址資料
        strSql = " select b.cusid, b.cusname, b.saddress, c.saddress, getdate() dt, a.flag " _
               & " from m_shipm_t a join m_custinfo_t b on a.cusid=b.cusid left outer join " _
               & " m_custother_t c on a.cusid=c.cusid where a.invoice='" & strInvoice & "' "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            g_CustID = Rs(0).ToString
            TxtCust.Text = Rs(1).ToString
            TxtAddress.Text = Rs(2).ToString
            If TxtAddress.Text = "" Then
                TxtAddress.Text = Rs(3).ToString
            End If
            dt = Rs(4)
            TxtDate.Text = dt.ToString("yyyy-MM-dd HH:mm")
            strSource = Rs(5).ToString
            If strSource = "1" Then
                LabLocal.Text = "資料來源：手工新增 / 更改"
            Else
                LabLocal.Text = "資料來源：ERP下載"
            End If
        End If
        Rs.Close()
    End Sub

    '加載出貨明細
    Public Sub LoadShipInfoDetail(ByVal strInvoice As String)
        Dim strSql As String
        Dim strStatus, str As String
        Dim intItem As Integer
        Dim intScanQty As Integer
        Dim intShipQty As Integer
        Dim intCarCout As Integer
        Dim intSel As Integer
        Dim strSta As String

        intItem = 0
        intScanQty = 0
        intCarCout = 0
        intSel = 0
        strStatus = ""
        DGShipList.Rows.Clear()

        strSql = " select a.shippno, b.partid, sum(b.eqty), c.shipqty, b.outwhid, b.states  " _
               & " from m_shipm_t a join m_shipd_t b on a.invoice=b.invoice left outer join " _
               & " m_whoutm_t c on b.outwhid=c.outwhid where a.invoice='" & strInvoice & "' " _
               & " group by a.shippno, b.partid, c.shipqty, b.outwhid, b.states "
        Rs = objDB.GetDataReader(strSql)

        While Rs.Read
            intItem += 1
            intShipQty = Rs(2)
            str = Trim(Rs(3).ToString)
            strSta = Trim(Rs(5).ToString)

            If str = "" Then
                intScanQty = 0
            Else
                intScanQty = str
            End If

            If intScanQty = intShipQty Then
                strStatus = "掃描完成"
                intSel = 0
            ElseIf intScanQty < intShipQty Then
                If intScanQty = 0 Then
                    strStatus = "待出庫"
                    intSel = 0
                Else
                    strStatus = "掃描中"
                    PlScan.Enabled = True
                    TxtScan.Focus()
                    If g_PartID = "" Or g_PartID = Rs(1).ToString Then
                        intSel = 1
                        g_Item = intItem
                        g_PartID = Rs(1).ToString
                        g_WHID = Rs(4).ToString
                        Meg("當前掃描料號：" & g_PartID, 2, False)
                    Else
                        intSel = 0
                    End If
                End If
            ElseIf intScanQty > intShipQty Then
                strStatus = "掃描數量多於出貨數量"
                intSel = 0
            End If

            If strSta = "2" Then
                strStatus = "已確認出庫"
                intSel = 0
            End If

            DGShipList.Rows.Add(intSel, intItem, Rs(1).ToString, intShipQty.ToString, _
                                intScanQty.ToString, strStatus, Rs(4).ToString)
            If strSta = "2" Then
                DGShipList.Rows(intItem - 1).ReadOnly = True
                DGShipList.Item(5, intItem - 1).Style.ForeColor = Color.Red
                DGShipList.Item(5, intItem - 1).Style.SelectionForeColor = Color.Red
            End If
        End While
        Rs.Close()

    End Sub

    '加載掃描明細
    Private Sub LoadScanList(ByVal strValue As String)
        Dim i As Integer
        Dim strSql As String
        Dim intCount As Integer
        LabCartCoun.Text = 0
        DGScanList.Rows.Clear()
        If strValue = "" Then Exit Sub
        strSql = " select a.partid, c.palletid, b.cartonid, d.cartonqty, b.userid, b.intime " _
               & " from m_whoutm_t a join m_whoutd_t b on a.outwhid=b.outwhid " _
               & " left outer join m_palletcarton_t c on b.cartonid=c.cartonid " _
               & " join m_carton_t d on b.cartonid=d.cartonid where a.outwhid='" & strValue & "'"

        
        i = 0
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            intCount = DGScanList.Rows.Count + 1
            DGScanList.Rows.Add(intCount, Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString, _
                                Rs(4).ToString, Rs(5).ToString)
        End While
        LabCartCoun.Text = DGScanList.Rows.Count
        If DGScanList.Rows.Count > 0 Then
            DGScanList.Rows(DGScanList.Rows.Count - 1).Selected = True
            DGScanList.CurrentCell = DGScanList(0, DGScanList.Rows.Count - 1)
            DGScanList.FirstDisplayedScrollingRowIndex = DGScanList.RowCount - 1
        End If
        Rs.Close()

        'DGScanList.Rows.Count.ToString
    End Sub

    '判斷是否有更早入庫的產品
    Private Function HaveOldProduct(ByVal strPart As String) As Boolean
        Dim strSql As String
        Dim strReturn As Boolean

        strSql = " select top 1 c.floorid,c.whid,c.areaid,e.Makedate " _
               & " from m_Carton_t a join m_WhInD_t b on a.cartonid=b.cartonid " _
               & " join m_WhInM_t c on c.inwhid=b.inwhid Join m_Mainmo_t d on a.moid=d.moid " _
               & " join m_SnSBarCode_t e on a.cartonid=e.sbarcode " _
               & " where d.partid='" & strPart & "' and c.states='2' and a.cartonstatus='I' " _
               & " and convert(datetime, e.Makedate) - 30 > 0 order by e.Makedate "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            ClassInf.StrInf = "該料號: " & strPart & " 在" & vbCrLf & Rs(0).ToString & " 樓層, " _
                            & Rs(1).ToString & " 倉庫, " & Rs(2).ToString & " 儲位 " & vbCrLf & "有 " _
                            & Rs(3).ToString & " 先入庫的產品"
            ClassInf.StrColor = Color.Green
            ClassInf.StrQInf = "你確定不遵守先進先出嗎？"
            ClassInf.StrQColor = Color.Red
            strReturn = True
        Else
            strReturn = False
        End If

        Rs.Close()
        Return strReturn
    End Function

    '檢查掃描數據
    Private Function CheckScanData(ByVal intType As Integer, ByVal strvalue As String, ByVal partno As String, ByVal invoice As String, ByVal item As String, ByVal whid As String, ByVal user As String) As String
        Dim strSpname As String
        Dim strInParam As String

        Select Case intType
            Case 1
                strSpname = "m_OutWHCarton_p"
            Case 2
                strSpname = "m_OutWHPallet_p"
            Case Else
                strSpname = ""
        End Select

        If intType = 1 Then
            strInParam = "@carton"
        Else
            strInParam = "@pallet"
        End If

        'Dim command As SqlCommand = New SqlCommand(strSpname, objDB.PubConnection)
        'Dim parameter As SqlParameter
        'Dim strReturn As String
        'Try
        '    command.CommandType = CommandType.StoredProcedure

        '    If intType = 1 Then
        '        parameter = command.Parameters.Add("@carton", SqlDbType.VarChar, 35)
        '    Else
        '        parameter = command.Parameters.Add("@pallet", SqlDbType.VarChar, 35)
        '    End If
        '    parameter.Value = strvalue

        '    parameter = command.Parameters.Add("@partno", SqlDbType.VarChar, 15)
        '    parameter.Value = partno

        '    parameter = command.Parameters.Add("@invoice", SqlDbType.VarChar, 15)
        '    parameter.Value = invoice


        '    parameter = command.Parameters.Add("@item", SqlDbType.VarChar, 15)
        '    parameter.Value = item

        '    parameter = command.Parameters.Add("@whid", SqlDbType.VarChar, 15)
        '    parameter.Value = whid

        '    parameter = command.Parameters.Add("@user", SqlDbType.VarChar, 10)
        '    parameter.Value = user

        '    parameter = command.Parameters.Add("@strmsg", SqlDbType.VarChar, 35)
        '    parameter.Direction = ParameterDirection.Output
        '    command.ExecuteNonQuery()

        '    strReturn = command.Parameters("@strmsg").Value.ToString()
        '    command = Nothing
        '    Return strReturn

        'Catch ex As Exception
        '    MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "CheckScanData", "sys")
        '    Return False
        'End Try

        Dim strSql As String
        Dim Rs As SqlDataReader
        Dim strReturn As String

        Try
            strSql = " declare " & strInParam & " varchar(35) , @partno varchar(15), @invoice  varchar(15),  " _
                   & " @item varchar(15), @whid varchar(15), @user varchar(10), @strmsg varchar(35) " _
                   & " execute " & strSpname & " '" & strvalue & "', '" & partno & "', '" & invoice & "', " _
                   & " '" & item & "', '" & whid & "', '" & user & "', @strmsg output select @strmsg "
            Rs = objDB.GetDataReader(strSql)

            If Rs.Read Then
                strReturn = Rs(0).ToString
            Else
                strReturn = "excute store procedure(m_RecordDateCode_p) error."
            End If
            Rs.Close()

        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "CheckScanData", "sys")
            strReturn = "excute store procedure(" & strSpname & ") error."
        End Try

        Return strReturn
    End Function

    '掃描還原操作
    Private Sub DropScanData(ByVal intType As Integer, ByVal strWHid As String, ByVal strValue As String)
        Dim strSql As String

        Try
            strSql = ""
            '0 按Invoice全部還原
            If intType = 0 Then
                strSql = strSql & " begin " & vbCrLf

                strSql = strSql & " update m_carton_t set cartonstatus='I' where cartonid in " _
                                & " (select cartonid from m_whoutd_t where outwhid in " _
                                & " (select outwhid from m_shipd_t where invoice='" & strValue & "')); " & vbCrLf

                strSql = strSql & " update m_palletm_t set palletstatus = 'I' where palletid in " _
                                & " (select distinct palletid from m_palletcarton_t " _
                                & " where cartonid in (select cartonid from m_whoutd_t where outwhid in " _
                                & " (select outwhid from m_shipd_t where invoice='" & strValue & "'))); " & vbCrLf

                strSql = strSql & " delete m_whoutm_t where outwhid in (select outwhid  " _
                                & " from m_shipd_t where invoice='" & strValue & "'); " & vbCrLf

                strSql = strSql & " delete m_whoutd_t where outwhid in (select outwhid  " _
                                & " from m_shipd_t where invoice='" & strValue & "'); " & vbCrLf

                strSql = strSql & " update m_shipd_t set outwhid=null, states='E', eintime=getdate(),  " _
                                & " euserid='" & g_User & "' where invoice='" & strValue & "' " & vbCrLf

                strSql = strSql & " end "
            End If

            '1 按箱號還原
            If intType = 1 Then
                strSql = strSql & " begin " & vbCrLf

                strSql = strSql & " update m_whoutm_t set shipqty=shipqty-(select cartonqty from m_carton_t " _
                                & " where cartonid='" & strValue & "') where outwhid='" & strWHid & "'; " & vbCrLf

                strSql = strSql & " delete from m_whoutd_t where cartonid='" & strValue & "'; " & vbCrLf

                strSql = strSql & " update m_carton_t set cartonstatus='I' where cartonid='" & strValue & "';  " & vbCrLf

                strSql = strSql & " end "
            End If

            '2 按棧板還原
            If intType = 2 Then
                strSql = strSql & " begin " & vbCrLf

                '2008-05-07 修改 扣除數量時增加棧板中箱號是否可用判斷。                            

                strSql = strSql & " update m_whoutm_t set shipqty=shipqty-(select sum(cartonqty) from m_carton_t where  " _
                                & " cartonid in (select cartonid from m_palletcarton_t where palletid = '" & strValue & "'  and usey='Y')) " _
                                & " where outwhid='" & strWHid & "'; " & vbCrLf

                'strSql = strSql & " update m_whoutm_t set shipqty=shipqty-(select sum(cartonqty) from m_carton_t where  " _
                '                & " cartonid in (select cartonid from m_palletcarton_t where palletid = '" & strValue & "')) " _
                '                & " where outwhid='" & strWHid & "'; "

                strSql = strSql & " update m_palletm_t set palletstatus='I' where palletid= '" & strValue & "'; " & vbCrLf

                strSql = strSql & " delete from m_whoutd_t where cartonid in (select cartonid from m_palletcarton_t where palletid = '" & strValue & "' and usey='Y'); " _
                                & vbCrLf

                strSql = strSql & " update m_carton_t set cartonstatus='I' where cartonid in " _
                                & " (select cartonid from m_palletcarton_t where palletid = '" & strValue & "' and usey='Y'); " & vbCrLf

                strSql = strSql & " end "
            End If

            '3 按出貨掃描單還原
            If intType = 3 Then
                strSql = strSql & " begin " & vbCrLf

                strSql = strSql & " update m_carton_t set cartonstatus='I' where cartonid in " _
                                & " (select cartonid from m_whoutd_t where outwhid ='" & strWHid & "'); " & vbCrLf

                strSql = strSql & " update m_palletm_t set palletstatus = 'I' where palletid in " _
                                & " (select distinct palletid from m_palletcarton_t " _
                                & " where cartonid in (select cartonid from m_whoutd_t where outwhid ='" & strWHid & "')); " & vbCrLf

                strSql = strSql & " delete m_whoutm_t where outwhid ='" & strWHid & "' " & vbCrLf

                strSql = strSql & " delete m_whoutd_t where outwhid ='" & strWHid & "' " & vbCrLf

                strSql = strSql & " update m_shipd_t set outwhid=null, states='E', eintime=getdate(),  " _
                                & " euserid='" & g_User & "' where outwhid='" & strWHid & "' " & vbCrLf

                strSql = strSql & " end "
            End If

            objDB.ExecSql(strSql)
        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "BtApply_Click", "sys")
        End Try
    End Sub

    '判斷掃描是否達到數量
    Private Function HaveScanFinish(ByVal strWHId As String) As Boolean
        Dim strSql As String
        Dim bReturn As Boolean = False
        Dim intShipQty As Integer
        Dim intScanQty As Integer

        'If g_KDShip = False Then
        '    strSql = " select sum(a.eqty),sum(b.shipqty),a.outwhid from m_shipd_t a, m_whoutm_t b  " _
        '           & " where a.outwhid=b.outwhid and a.outwhid='" & strWHId & "' " _
        '           & " and a.eqty=b.shipqty group by a.outwhid "
        'Else
        '    strSql = " select a.eqty,b.shipqty from m_shipd_t a, m_whoutm_t b  " _
        '           & " where a.outwhid=b.outwhid and a.outwhid='" & strWHId & "' " _
        '           & " and a.eqty=b.shipqty  "
        'End If

        'Rs = objDB.GetDataReader(strSql)
        'Rs.Close()

        'If Rs.Read Then
        '    bReturn = True
        'Else
        '    bReturn = False
        'End If

        Try
            strSql = " select sum(eqty) from m_shipd_t where outwhid='" & strWHId & "' "
            Rs = objDB.GetDataReader(strSql)

            If Rs.Read Then
                If IsDBNull(Rs(0)) Then
                    intShipQty = 0
                Else
                    intShipQty = Rs(0)
                End If
            Else
                intShipQty = 0
            End If
            Rs.Close()

            strSql = " select shipqty from m_whoutm_t where outwhid='" & strWHId & "' "
            Rs = objDB.GetDataReader(strSql)

            If Rs.Read Then
                intScanQty = Rs(0)
            Else
                intScanQty = 0
            End If
            Rs.Close()

            If intShipQty = intScanQty And intScanQty <> 0 And intShipQty <> 0 Then
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            Rs.Close()
            bReturn = False
        End Try

        Return bReturn
    End Function

    'Private Function GetScanCartons(ByVal strWHId As String) As String
    '    Dim strSql As String
    '    Dim strQty As String

    '    strSql = " select count(*) as qty from m_whoutd_t  where outwhid='" & strWHId & "' "
    '    Rs = objDB.GetDataReader(strSql)

    '    If Rs.Read Then
    '        strQty = Rs(0).ToString
    '    Else
    '        strQty = "0"
    '    End If
    '    Rs.Close()
    '    Return strQty
    'End Function

    Private Function GetPartNo(ByVal strValue As String, ByVal intType As Integer) As String
        Dim strReturn As String
        Dim strSql As String
        Dim Rs As SqlDataReader

        strSql = ""
        If intType = 1 Then
            strSql = " select partid from m_mainmo_t where moid in " _
                   & " (select moid from m_carton_t where cartonid='" & strValue & "') "
        End If

        If intType = 2 Then
            strSql = " select partid from m_mainmo_t where moid in " _
                   & " (select top 1 moid from m_carton_t where cartonid in  " _
                   & " (select top 1 cartonid from m_PalletCarton_t where palletid='" & strValue & "')) "
        End If

        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            strReturn = Rs(0).ToString
        Else
            strReturn = ""
        End If
        Rs.Close()

        Return strReturn
    End Function

    Private Sub GetScanDetailData()
        Init()
        If CobInvoice.Text = "" Then Exit Sub

        LoadShipInfoMain(CobInvoice.Text)

        LoadShipInfoDetail(CobInvoice.Text)
        If DGShipList.Rows.Count > 1 Then
            LoadScanList(DGShipList.CurrentRow.Cells(6).Value.ToString)
        End If

    End Sub

    'Private Sub DGShipList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShipList.CellClick
    '    Dim intCol, intRow As Integer
    '    Dim i As Integer

    '    If DGShipList.Rows.Count = 0 Then Exit Sub
    '    If e.RowIndex = -1 Then Exit Sub

    '    intCol = DGShipList.CurrentCell.ColumnIndex
    '    intRow = DGShipList.CurrentCell.RowIndex

    '    If intCol <> 0 Then
    '        DGShipList.Rows(intRow).Selected = False
    '        For i = 0 To DGShipList.Rows.Count - 1
    '            If DGShipList.Item(0, i).Value = 1 Then
    '                DGShipList.Rows(i).Selected = True
    '                Exit Sub
    '            End If
    '        Next i

    '    End If
    '    'LoadScanList(DGShipList.CurrentRow.Cells(6).Value.ToString)
    'End Sub

    '選取出貨明細資料
    Private Sub DGShipList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShipList.CellContentClick
        Dim i As Integer
        Dim intSel As Integer
        Dim intCol, intRow As Integer
        Dim strStatus As String

        If DGShipList.Rows.Count = 0 Then Exit Sub
        If e.RowIndex = -1 Then Exit Sub

        intCol = DGShipList.CurrentCell.ColumnIndex
        intRow = DGShipList.CurrentCell.RowIndex

        If intCol <> 0 Then Exit Sub
        If intRow < 0 Then Exit Sub


        intSel = DGShipList.Item(0, e.RowIndex).Value
        g_Item = DGShipList.Item(1, e.RowIndex).Value
        g_PartID = DGShipList.Item(2, e.RowIndex).Value
        strStatus = DGShipList.Item(5, e.RowIndex).Value
        g_WHID = DGShipList.Item(6, e.RowIndex).Value

        For i = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(2, i).Value = g_PartID Then
                If intSel = 0 Then
                    DGShipList.Item(0, i).Value = 1
                Else
                    DGShipList.Item(0, i).Value = 0
                End If
            Else
                DGShipList.Item(0, i).Value = 0
            End If
        Next i

        If strStatus = "掃描完成" Then
            PlScan.Enabled = True
            Meg("料號：" & g_PartID & " 已掃描完成.", 1, False)
        ElseIf strStatus = "已確認出庫" Then
            PlScan.Enabled = False
            DGShipList.Item(0, intRow).Value = 0
            Meg("料號：" & g_PartID & " 已確認出庫.", 1, True)
            g_PartID = ""
            Exit Sub
        ElseIf strStatus = "" Then
            PlScan.Enabled = True
            Meg("當前掃描料號：" & g_PartID, 2, False)
        Else
            PlScan.Enabled = False
            Meg("當前掃描料號：" & g_PartID, 2, False)
        End If

        If intSel = 0 Then
            PlScan.Enabled = True
            TxtScan.Focus()
        Else
            LabInfo.Text = ""
            PlScan.Enabled = False
        End If
        LoadScanList(DGShipList.CurrentRow.Cells(6).Value.ToString)
    End Sub

    Private Function QueryWHID(ByVal strInvoice As String, ByVal strPart As String) As String
        Dim strSql As String
        Dim strReturn As String
        Dim Rs As SqlDataReader = Nothing

        Try
            strSql = " select outwhid from m_shipd_t where invoice='" & strInvoice & "' and partid='" & strPart & "' "
            Rs = objDB.GetDataReader(strSql)

            If Rs.Read Then
                strReturn = Rs(0).ToString
            Else
                strReturn = ""
            End If
            Rs.Close()
        Catch ex As Exception
            Rs.Close()
            strReturn = ""
        End Try
        Return strReturn
    End Function

    Private Function GetSelectRowIndex() As Integer
        Dim i As Integer
        Dim intReturn As Integer

        intReturn = -1
        For i = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(0, i).FormattedValue.ToString = "True" Then
                intReturn = i
                Exit For
            End If
        Next

        Return intReturn
    End Function

    '掃描開始
    Private Sub TxtScan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScan.KeyPress
        Dim strValue As String
        Dim strReturn As String
        Dim strPartno As String
        Dim strShipno As String
        Dim intSelrow As Integer
        Dim strInvoice As String
        Dim strWHid As String
        Dim FrmInformation As New FrmInfShow

        Try
            strValue = TxtScan.Text.ToUpper()
            strWHid = ""

            If Asc(e.KeyChar) = 13 And strValue <> "" Then

                If g_PartID = "" Then
                    Meg("請選擇要掃描的料號.", 2, True)
                    Exit Sub
                End If

                If g_KDShip = False Then
                    'intSelrow = DGShipList.CurrentRow.Index
                    intSelrow = GetSelectRowIndex()
                    If intSelrow = -1 Then
                        Meg("請選擇要掃描的料號.", 2, True)
                        Exit Sub
                    End If
                    strShipno = DGShipList.Item(0, intSelrow).Value.ToString
                    strPartno = DGShipList.Item(2, intSelrow).Value.ToString
                    strWHid = DGShipList.Item(6, intSelrow).Value.ToString
                    strInvoice = CobInvoice.Text.ToUpper
                Else
                    strShipno = ""
                    strWHid = LabWHID.Text
                    g_Item = 1
                    strPartno = g_PartID
                    strInvoice = TxtVInvo.Text.ToUpper
                End If

                If strWHid = "" Then
                    strWHid = QueryWHID(strInvoice, strPartno)
                End If

                '正常掃描------------------------------------------------------------------------------------------------------
                If chkReuse.Checked = False Then
                    '掃描第一筆
                    If strWHid = "" Then
                        '先進先出判斷
                        'If HaveOldProduct(strPartno) Then
                        '    FrmInformation.ShowDialog()
                        '    If ClassInf.ChoseY = False Then Exit Sub
                        'End If

                        strWHid = GetNewWHID(strPartno, strInvoice)
                        If strWHid = "" Then
                            Meg("取出貨掃描單號出錯，請重試!", 0, True)
                            Exit Sub
                        End If
                        g_WHID = strWHid

                        If g_KDShip = True Then
                            LabWHID.Text = strWHid
                        End If
                    End If

                    If R1.Checked Then
                        strReturn = CheckScanData(1, strValue, strPartno, strInvoice, g_Item, strWHid, g_User)
                    ElseIf R2.Checked Then
                        strReturn = CheckScanData(2, strValue, strPartno, strInvoice, g_Item, strWHid, g_User)
                    Else
                        strReturn = "未定義"
                    End If


                    If strReturn = "OK" Then
                        If g_KDShip = False Then
                            LoadShipInfoDetail(strInvoice)
                            DGShipList.Item(0, intSelrow).Value = 1
                        Else
                            Meg("當前掃描料號：" & g_PartID, 2, False)
                        End If

                        LoadScanList(strWHid)
                        TxtScan.Text = ""
                        TxtScan.Focus()
                        My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)

                        If HaveScanFinish(strWHid) = True And g_WHID <> "" Then
                            'Dim style As MsgBoxStyle
                            'style = MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo
                            'If MsgBox("料號[ " & g_PartID & " ]已掃描完成，是否確認出庫？", style, "確認信息") = MsgBoxResult.Yes Then
                            '    BtApply_Click(sender, e)
                            'End If
                            BtApply_Click(sender, e)
                            ' MsgBox("料號[ " & g_PartID & " ]掃描完成，已確認出庫", 48, "確認信息")
                        End If

                        'If g_KDShip = True Then
                        '    LabCartCoun.Text = GetScanCartons(strWHid)
                        'End If
                    Else
                        Meg(strReturn, 0, True)

                        If g_KDShip = False Then
                            LoadShipInfoDetail(strInvoice)
                            DGShipList.Item(0, intSelrow).Value = 1
                        End If
                    End If
                Else '駁回掃描--------------------------------------------------------------------------------------------------
                    Dim i As Integer
                    Dim bExist As Boolean = False
                    Dim str As String
                    Dim intQty As Integer
                    Dim scanPartNo As String

                    intQty = DGShipList.Item(4, intSelrow).Value

                    If intQty <= 0 Then
                        Meg("此單已移除完畢!", 0, True)
                        Exit Sub
                    End If

                    For i = 0 To DGScanList.Rows.Count - 1
                        If R1.Checked Then
                            str = DGScanList.Item(3, i).Value
                        ElseIf R2.Checked Then
                            str = DGScanList.Item(2, i).Value
                        Else
                            str = "  "
                        End If
                        If str = strValue Then
                            bExist = True
                            Exit For
                        End If
                    Next i

                    If bExist = False Then
                        If R1.Checked Then
                            Meg("輸入的箱號不在此單中!", 0, True)
                            Exit Sub
                        End If

                        If R2.Checked Then
                            Meg("輸入的棧板號不在此單中!", 0, True)
                            Exit Sub
                        End If
                    End If

                    If R1.Checked Then
                        scanPartNo = GetPartNo(strValue, 1)
                        If scanPartNo <> strPartno Then
                            Meg("輸入的箱號料號與選擇的料號不一致!", 0, True)
                            Exit Sub
                        End If
                    End If

                    If R2.Checked Then
                        scanPartNo = GetPartNo(strValue, 2)
                        If scanPartNo <> strPartno Then
                            Meg("輸入的棧板號料號與選擇的料號不一致!", 0, True)
                            Exit Sub
                        End If
                    End If

                    If R1.Checked Then
                        DropScanData(1, strWHid, strValue)
                    ElseIf R2.Checked Then
                        DropScanData(2, strWHid, strValue)
                    End If
                    Meg(strValue & "刪除成功!", 1, False)

                    If g_KDShip = False Then
                        LoadShipInfoMain(strInvoice)
                        LoadShipInfoDetail(strInvoice)
                        DGShipList.Item(0, intSelrow).Value = 1
                    End If
                    LoadScanList(strWHid)
                End If
            End If
        Catch ex As Exception
            Rs.Close()
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "TxtScan_KeyPress", "sys")
        End Try
    End Sub

    '確認作業
    Private Sub BtConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim FrmConfirm As New FrmConfirm

        'FrmConfirm.Text = "確認出庫資料"
        'FrmConfirm.BtReject.Visible = False
        'FrmConfirm.Sp1.Visible = False
        'FrmConfirm.g_OpType = 1
        'FrmConfirm.g_User = g_User
        'FrmConfirm.g_Rights = g_Rights
        'FrmConfirm.ShowDialog()
    End Sub

    '駁回作業
    Private Sub BtReuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReuse.Click
        'Dim FrmConfirm As New FrmConfirm

        'FrmConfirm.Text = "駁回出庫資料"
        'FrmConfirm.BtConfirm.Visible = False
        'FrmConfirm.Sp2.Visible = False
        'FrmConfirm.g_OpType = 0
        'FrmConfirm.g_User = g_User
        'FrmConfirm.g_Rights = g_Rights
        'FrmConfirm.ShowDialog()
    End Sub


    Private Sub ConfirmAllShip()
        Dim i As Integer
        Dim strSql As String
        Dim strInvoice As String

        If DGShipList.Rows.Count = 0 Then Exit Sub

        If g_KDShip = False Then
            strInvoice = CobInvoice.Text.ToUpper
        Else
            strInvoice = TxtVInvo.Text.ToUpper
        End If

        If TxtAddress.Text = "" Then
            Meg("出貨地址不能為空!", 2, True)
            Exit Sub
        End If

        For i = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(3, i).Value <> DGShipList.Item(4, i).Value Then
                Meg("掃描未完成，不能提交!", 2, True)
                Exit Sub
            End If
        Next i

        Try
            strSql = " begin " _
                   & " update m_whoutm_t set cusid='" & g_CustID & "', orderseq='" & strInvoice & "', " _
                   & " saddress='" & TxtAddress.Text & "', states='2' , remark='" & TxtRemark.Text & "',  " _
                   & " userid='" & g_User & "', intime=getdate() " _
                   & " where outwhid in (select outwhid from m_shipd_t where invoice='" & strInvoice & "' ); " _
                   & " update m_shipd_t set states='2', eintime=getdate(), euserid='" & g_User & "'  " _
                   & " where invoice='" & strInvoice & "'; " _
                   & " end "
            objDB.ExecSql(strSql)
            Meg("[" & strInvoice & "]" & "確認成功!", 1, True)
            Init()
            CobInvoice.Text = ""
        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "BtApply_Click", "sys")
        End Try
    End Sub

    Private Sub ConfirmBySelectShip()
        Dim intRow As Integer
        Dim strSql As String
        Dim strState As String
        Dim strPart As String
        Dim strItem As String
        Dim strInvoice As String
        Dim strWHID As String
        Dim strAddress As String
        Dim strRemark As String
        Dim strCusid As String
        Dim strTmp1, strTmp2 As Integer

        strTmp1 = 0
        strTmp2 = 0

        If g_KDShip = False Then
            If DGShipList.Rows.Count = 0 Then Exit Sub

            If TxtAddress.Text = "" Then
                Meg("下載的資料出貨地址為空，請輸入正確的出貨地址!", 2, True)
                TxtAddress.ReadOnly = False
                TxtAddress.Focus()
                Exit Sub
            Else
                TxtAddress.ReadOnly = True
            End If

            intRow = GetSelectRowIndex()
            If DGShipList.Item(3, intRow).Value <> DGShipList.Item(4, intRow).Value Then
                Meg("掃描未完成，不能提交!", 2, True)
                Exit Sub
            End If

            strInvoice = CobInvoice.Text.ToUpper
            strItem = DGShipList.Item(1, intRow).Value.ToString
            strPart = DGShipList.Item(2, intRow).Value.ToString
            strWHID = DGShipList.Item(6, intRow).Value.ToString
            strAddress = TxtAddress.Text
            strRemark = TxtRemark.Text
            strCusid = g_CustID
        Else
            strInvoice = TxtVInvo.Text.ToUpper
            strCusid = "N/A"
            strPart = g_PartID
            strWHID = LabWHID.Text
            strAddress = ""
            strRemark = Trim(CobSpType.Text & "  " & TxtRemark.Text)

            If Not HaveScanFinish(strWHID) Then
                Meg("掃描未完成，不能提交!", 0, True)
                Exit Sub
            End If
        End If

        strSql = " select distinct states from m_shipd_t where invoice='" & strInvoice & "'  " _
               & " and partid='" & strPart & "' and outwhid ='" & strWHID & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            strState = Rs(0).ToString
            If strState = "2" Then
                Meg("此出貨掃描單已確認出庫!", 2, True)
                Rs.Close()
                Exit Sub
            End If
        End If
        Rs.Close()

        Try
            strSql = " begin " _
                   & " update m_whoutm_t set cusid='" & strCusid & "', orderseq='" & strInvoice & "', " _
                   & " saddress='" & strAddress & "', states='2' , remark='" & strRemark & "',  " _
                   & " userid='" & g_User & "', intime=getdate() where outwhid ='" & strWHID & "' ; " _
                   & " update m_shipd_t set states='2', eintime=getdate(), euserid='" & g_User & "' " _
                   & " where invoice='" & strInvoice & "' and partid='" & strPart & "' and outwhid ='" & strWHID & "' ; " _
                   & " end "
            objDB.ExecSql(strSql)
            Meg("[" & strWHID & "]" & "確認出庫成功!", 1, True)
            ' Init()

            If g_KDShip = False Then
                LoadShipInfoDetail(CobInvoice.Text)
                LoadScanList(strWHID)
                g_WHID = ""
            Else
                ClearKText()
                DGScanList.Rows.Clear()
                LabInfo.Text = ""
            End If
        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "BtApply_Click", "sys")
        End Try
    End Sub

    '加載料件清單
    Private Sub LoadPartList()
        Dim strSql As String

        CobPart.Items.Clear()
        CobPart.Items.Add("")
        strSql = " select distinct partid from m_mainmo_t order by partid "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobPart.Items.Add(Rs(0).ToString)
        End While
        Rs.Close()
        CobPart.SelectedIndex = -1
    End Sub

    Private Sub ChangeUI()
        If R1.Checked Then
            LabScan.Text = "輸入" & R1.Text & "："
        End If

        If R2.Checked Then
            LabScan.Text = "輸入" & R2.Text & "："
        End If
    End Sub

    Private Sub BtBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBack.Click
        Close()
    End Sub

    Private Sub CobInvoice_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.SelectedValueChanged
        GetScanDetailData()
    End Sub

    Private Sub CobInvoice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobInvoice.KeyPress
        If Asc(e.KeyChar) = 13 Then
            GetScanDetailData()
        End If
    End Sub

    Private Sub R1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R1.CheckedChanged
        ChangeUI()
    End Sub

    Private Sub FrmOutWH_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.C AndAlso e.Alt Then
            BtApply_Click(sender, e)
        ElseIf e.KeyCode = Keys.D AndAlso e.Alt Then
            BtDrop_Click(sender, e)
        ElseIf e.KeyCode = Keys.R AndAlso e.Alt Then
            BtReuse_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            BtBack_Click(sender, e)
        ElseIf e.KeyCode = Keys.M AndAlso e.Alt Then
            BtModify_Click(sender, e)
        End If
    End Sub

    Private Sub CobInvoice_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.DropDown
        LoadInvoiceList()
    End Sub

    Private Sub ToolStripDelSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strReturn As String
        Dim strSql As String
        Dim intSelrow As Integer

        If g_KDShip = False Then
            intSelrow = GetSelectRowIndex()
            If intSelrow < 0 Then Exit Sub
            g_WHID = DGShipList.Item(6, intSelrow).Value
        End If

        If g_WHID = "" Then Exit Sub
        'If DGScanList.Rows.Count = 0 And g_KDShip = False Then Exit Sub

        strSql = " select states from m_whoutm_t where outwhid='" & g_WHID & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            If Rs(0).ToString = "2" Then
                MsgBox("已確認出貨，不能舍棄。", 48, "提示信息")
                Rs.Close()
                Exit Sub
            End If
        End If
        Rs.Close()

        If MsgBox("確實要舍棄出貨掃描單[ " & g_WHID & " ]的資料嗎？", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "確認信息") = MsgBoxResult.Yes Then
            Dim FrmMgShipInfo As New FrmMgShipInfo
            DropScanData(3, g_WHID, "")
            If g_KDShip = False Then
                LoadShipInfoDetail(CobInvoice.Text)
                DGScanList.Rows.Clear()
                LabCartCoun.Text = 0
            Else
                strReturn = FrmMgShipInfo.DelShipList(TxtVInvo.Text)
                ClearKText()
                DGScanList.Rows.Clear()
                LabInfo.Text = ""
            End If
            FrmMgShipInfo.Dispose()
            Meg("[" & g_WHID & "]舍棄成功.", 1, True)
            g_WHID = ""
        End If
    End Sub

    Private Sub ToolStripApySel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConfirmBySelectShip()
    End Sub

    Private Sub ToolStripApyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  ConfirmAllShip()
    End Sub

    Private Sub BtModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtModify.Click
        Dim FrmMgShipInfo As New FrmMgShipInfo

        If CobInvoice.Text = "" Then
            MsgBox("請選擇要修改的Invoice號。", 48, "提示信息")
            Exit Sub
        End If

        If DGShipList.Rows.Count = 0 Then
            MsgBox("請選輸入正確的Invoice號並按回車鍵。", 48, "提示信息")
            Exit Sub
        End If

        FrmMgShipInfo.g_MInvoice = CobInvoice.Text.ToUpper
        FrmMgShipInfo.ShowDialog()
    End Sub

    Private Sub DGShipList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShipList.CellDoubleClick
        Dim FrmShowDetail As New FrmShowDetail
        Dim strInvoice As String

        If g_KDShip = False Then
            strInvoice = CobInvoice.Text.ToUpper
        Else
            strInvoice = TxtVInvo.Text.ToUpper
        End If

        FrmShowDetail.Text = "[" & strInvoice & "] 的明細資料"
        FrmShowDetail.TabTitle = "Invoice|項次|產品料號|出貨數量"
        FrmShowDetail.strSQL = " select invoice, items, partid,eqty from m_shipd_t where invoice='" & strInvoice & "' "
        FrmShowDetail.ShowDialog()
    End Sub

    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If BtStartScan.Enabled = False And LaState.Text <> "已確認出庫" Then Exit Sub
        Init()
        If e.TabPageIndex = 1 Then
            BtModify.Enabled = False
            g_KDShip = True
            LoadPartList()
            ClearKText()
        Else
            BtModify.Enabled = True
            g_KDShip = False
            ClearKText()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If BtStartScan.Enabled = False And LaState.Text <> "已確認出庫" Then
            TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        End If
    End Sub

    Private Sub TxtCount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCount.KeyPress
        Dim ctrTextBox As TextBox
        ctrTextBox = CType(sender, TextBox)
        If ctrTextBox.Text = "" AndAlso e.KeyChar = ChrW(Keys.D0) Then
            e.Handled = True
            Exit Sub
        End If
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
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

    Private Sub BtApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtApply.Click
        ConfirmBySelectShip()
        'MsgBox(g_WHID)
    End Sub

    Private Sub BtDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDrop.Click
        ToolStripDelSel_Click(sender, e)
    End Sub

    Private Sub BtStartScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtStartScan.Click
        Dim intStar, intEnd As Integer
        Dim strSql As String
        Dim strUser As String
        Dim strReturn As String
        Dim strFactory As String
        Dim bExist As Boolean = False
        Dim strItem As String
        Dim FrmMgShipInfo As New FrmMgShipInfo

        Try
            If TxtVInvo.Text = "" Then
                MsgBox("請輸入出貨單號。", 48, "提示信息")
                TxtVInvo.Focus()
                FrmMgShipInfo.Dispose()
                Exit Sub
            End If

            If CobPart.Text = "" Then
                MsgBox("請選擇產品料號。", 48, "提示信息")
                CobPart.Focus()
                FrmMgShipInfo.Dispose()
                Exit Sub
            End If

            If Not FrmMgShipInfo.CheckPartNO(CobPart.Text) Then
                MsgBox("輸入的料號錯誤.", 48, "Warning")
                CobPart.Text = ""
                CobPart.Focus()
                FrmMgShipInfo.Dispose()
                Exit Sub
            End If

            If CobSpType.Text = "" Then
                MsgBox("請選擇出貨類型。", 48, "提示信息")
                CobSpType.Focus()
                FrmMgShipInfo.Dispose()
                Exit Sub
            End If

            If TxtCount.Text = "" Then
                MsgBox("請選輸入出貨數量。", 48, "提示信息")
                TxtCount.Focus()
                FrmMgShipInfo.Dispose()
                Exit Sub
            End If

            intStar = CobFacory.Text.IndexOf("(")
            intEnd = CobFacory.Text.IndexOf(")")
            strFactory = Mid(CobFacory.Text, intStar + 2, intEnd - intStar - 1)
            strUser = MainFrame.SysCheckData.SysMessageClass.UseId

            strSql = " select * from m_shipd_t where invoice='" & TxtVInvo.Text & "' and partid='" & CobPart.Text & "' "
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                Rs.Close()
                MsgBox("此單號已保存。", 48, "提示信息")
                ClearKText()
                FrmMgShipInfo.Dispose()
                Exit Sub
            End If
            Rs.Close()
            'Flag = 2 為快遞出貨

            strSql = " select * from m_shipm_t where invoice='" & TxtVInvo.Text & "' "
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                bExist = True
            Else
                bExist = False
            End If
            Rs.Close()
            If Not bExist Then
                strSql = " insert into m_shipm_t (invoice, shippno, cusid, eintime, euserid, factory, flag, usey) " _
                       & " values ('" & TxtVInvo.Text.Trim & "', 'N/A', '" & CobSpType.Text & "', getdate(), '" & strUser & "',  " _
                       & " '" & strFactory & "', '2', 'Y') "
                objDB.ExecSql(strSql)
            End If

            strSql = " select items from m_shipd_t where invoice='" & TxtVInvo.Text & "' "
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                strItem = CType(CType(Rs(0).ToString, Integer) + 1, String)
            Else
                strItem = "1"
            End If
            Rs.Close()

            strSql = " insert into m_shipd_t (invoice, items, partid, eqty, eintime, euserid, flag) " _
                   & " values('" & TxtVInvo.Text.Trim & "', '" & strItem & "', '" & CobPart.Text.ToUpper.Trim & "', '" & TxtCount.Text & "', " _
                   & " getdate(), '" & strUser & "', '2') "
            objDB.ExecSql(strSql)

            If PlScan.Enabled = False Then
                PlScan.Enabled = True
            End If

            LabWHID.Text = ""
            g_PartID = CobPart.Text
            g_WHID = ""
            DisableMaintain()

        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH", "BtStartScan_Click", "sys")
            strReturn = FrmMgShipInfo.DelShipList(TxtVInvo.Text)
            FrmMgShipInfo.Dispose()
        End Try
        FrmMgShipInfo.Dispose()
    End Sub

    Private Sub ShowFactoryName(ByVal strInvoice)
        Dim strSql As String
        Dim strFactory As String

        strSql = " select b.ttext, a.factory from m_shipm_t a  left outer join m_logtree_t b " _
       & " on a.factory= b.buttonid where invoice='" & strInvoice & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read() Then
            Dim intPos As Integer
            strFactory = Rs(0).ToString & "(" & Rs(1).ToString & ")"
            intPos = CobFacory.Items.IndexOf(strFactory)
            CobFacory.SelectedIndex = intPos
        End If
        Rs.Close()
    End Sub

    Private Sub LoadKDInvoicePart(ByVal strInvoice As String)
        Dim strSql As String

        CobPart.Items.Clear()
        strSql = " select distinct partid from m_shipd_t where invoice='" & strInvoice & "' and flag='2' "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobPart.Items.Add(Rs(0).ToString)
        End While
        Rs.Close()
        CobPart.SelectedIndex = 0
    End Sub

    Private Sub LoadKDShipInfo(ByVal strInvoice As String, ByVal strPart As String)
        Dim strSql As String
        Dim strFactory As String
        Dim strShipType As String
        Dim strShipQty As String
        Dim strState As String

        ShowFactoryName(strInvoice)

        strSql = " select b.partid, a.factory, a.cusid, b.eqty, b.states, b.outwhid " _
               & " from m_shipm_t a, m_shipd_t b where a.invoice=b.invoice " _
               & " and a.invoice='" & strInvoice & "' and b.partid='" & strPart & "' and b.flag='2' "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            strPart = Rs(0).ToString
            strFactory = Rs(1).ToString
            strShipType = Rs(2).ToString
            strShipQty = Rs(3).ToString
            strState = Rs(4).ToString
            g_WHID = Rs(5).ToString
            LabWHID.Text = g_WHID
            g_PartID = strPart

            CobPart.SelectedIndex = CobPart.Items.IndexOf(strPart)
            CobSpType.SelectedIndex = CobSpType.Items.IndexOf(strShipType)
            TxtCount.Text = strShipQty
            DisableMaintain()

            Select Case strState
                Case "E"
                    LaState.Text = "待出庫"
                    LaState.ForeColor = Color.Blue
                    PlScan.Enabled = True
                Case "1"
                    LaState.Text = "掃描中"
                    LaState.ForeColor = Color.Blue
                    PlScan.Enabled = True
                Case "2"
                    LaState.Text = "已確認出庫"
                    LaState.ForeColor = Color.Red
                    PlScan.Enabled = False
            End Select
        End If
        Rs.Close()
        'LabCartCoun.Text = GetScanCartons(g_WHID)
    End Sub

    Private Sub EnableMainatain()
        'CobPart.Enabled = True
        CobSpType.Enabled = True
        TxtCount.Enabled = True
        CobFacory.Enabled = True
        BtStartScan.Enabled = True
    End Sub

    Private Sub DisableMaintain()
        'CobPart.Enabled = False
        CobSpType.Enabled = False
        TxtCount.Enabled = False
        CobFacory.Enabled = False
        BtStartScan.Enabled = False
    End Sub

    Private Sub TxtVInvo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVInvo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            LoadKDInvoicePart(TxtVInvo.Text)
            LoadKDShipInfo(TxtVInvo.Text, CobPart.Text)
            If DGShipList.Rows.Count > 1 Then
                LoadScanList(DGShipList.CurrentRow.Cells(6).Value.ToString)
            End If
            TxtVInvo.SelectAll()
        End If

        If TxtVInvo.Text.Length > 19 Then
            If e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CobPart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobPart.SelectedIndexChanged
        LoadKDShipInfo(TxtVInvo.Text, CobPart.Text)
    End Sub

    Private Sub TxtSM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSM.KeyPress
        If TxtSM.Text.Length > 49 Then
            If e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

End Class