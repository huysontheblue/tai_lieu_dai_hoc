Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame
Imports System.Xml
Imports MainFrame.SysCheckData
Imports System.IO

Public Class FrmManualpacking
    '外箱临时编号
    Private TempCartonId As String = ""
    '匹配顺序
    Private CheckCartonIndex As Integer = 0
    '未使用的字段
    'Dim IsConnect As Boolean = False
    'Dim ServerName As String
    'Dim ServerCon As String
    'Public LockFile As String = ""
    'Public IsServer As Boolean = False
    'Public Master As String = "Y"
    'Public FactoryName As String
    'Public Linename As String
    Public curindex As Integer = 0
    Public DoCount As Integer = 0
    Private DicData As New Dictionary(Of String, String)

    '华为客户料号条码及装箱数量条码顺序
    Private CheckHwIndex As Integer = 0
    '客户料号临时条码
    Private TempHwCustPartID As String = ""
    '是否扫描托盘 Add By KyLinQiu20171228
    Private IsScanLayer As Boolean = False
    '托盘个数
    Private LayerNum As Integer = 0
    '每个托盘数量
    Private PcsOfEachLayer As Integer = 0
    '装箱数量
    Private PackageNum As Integer = 0
    '托盘顺序号
    Private LayerIndex As Integer = 0
    'Mr Luu Add 2018-09-27
    Private PartId As String = ""
    Private k1 As Integer = 0
    Private row1 As Integer = 0
    Private index1 As Integer = 0
    'End Mr Luu Add 2018-09-27
    'Mr Luu Add 2019-09-17 Function Scan Product Barcode For Dell Customer
    Private TemPPID As String = ""
    Private CheckPPIDIndex As Integer = 0
    'End Mr Luu Add 2019-09-17
    '加载数据
    Private Sub FrmManualpacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadSqlServerName()
        ToolStripAnkerSetting.Visible = False
        Me.txtStyle.ReadOnly = True
        Me.TxtBHWCode.ReadOnly = True
        Me.txtCarton.ReadOnly = True
        Me.txtSecond.ReadOnly = True
        Me.txtPpid.ReadOnly = True
        Me.TxtBHWCode.Focus()
        '加载料件包装扫描参数设置权限
        LoadPartSetData()
        LoadAnkerData()
        'If VbCommClass.VbCommClass.Factory = "02J0" Then
        '    Dim StrSql_CheckUser As String = String.Format(" Select top 1 PwdType from m_SuperPassWord_t where PwdType='FrmAnker' and Usey='Y' and Userid='{0}' ", SysMessageClass.UseId)
        '    Dim dtTemp_CheckUser As DataTable = DbOperateUtils.GetDataTable(StrSql_CheckUser)
        '    If dtTemp_CheckUser.Rows.Count > 0 Then
        '        ToolStripAnkerSetting.Visible = True
        '    End If
        '    'If MultLanguage.Language.lang = "en" Then
        '    '    SetControl()
        '    'End If
        '    SetControl()
        '    ToolNext.Visible = False
        '    ToolNext.Enabled = False
        'End If
    End Sub

    Private Sub SetControl()
        Label1.Left -= 15
        lblppid.Left -= 25
        LabComplete.Left -= 10
        LabNeed.Left -= 10
    End Sub
    '料件包装扫描参数设置权限
    Private Sub LoadPartSetData()
        Dim StrSql As String = String.Format(" SELECT a.Tkey FROM dbo.m_Logtree_t a INNER JOIN dbo.m_UserRight_t b ON a.Tkey=b.Tkey " &
                                             " WHERE a.TreeTag='BarCodeScan.FrmManualpacking' AND a.ButtonID='ToolPartSet' AND b.UserID='{0}' ", SysMessageClass.UseId)
        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
            Me.ToolPartSet.Enabled = False
            Me.ToolPartSet.Visible = False
        Else
            Me.ToolPartSet.Visible = True
            Me.ToolPartSet.Enabled = True
        End If
    End Sub
    'Anker-Setting设置权限
    Private Sub LoadAnkerData()
        Dim StrSql As String = String.Format(" SELECT a.Tkey FROM dbo.m_Logtree_t a INNER JOIN dbo.m_UserRight_t b ON a.Tkey=b.Tkey " &
                                             " WHERE a.TreeTag='BarCodeScan.FrmManualpacking' AND a.ButtonID='FrmAnker' AND b.UserID='{0}' ", SysMessageClass.UseId)
        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
            Me.ToolStripAnkerSetting.Enabled = False
            Me.ToolStripAnkerSetting.Visible = False
        Else
            Me.ToolStripAnkerSetting.Visible = True
            Me.ToolStripAnkerSetting.Enabled = True
        End If
    End Sub

    '加载服务器
    'Private Sub LoadSqlServerName()
    '    Dim ipstr As String = ""
    '    Dim xmldoc As New XmlDocument
    '    Try
    '        xmldoc.Load(Application.StartupPath & "\Loginlog.xml") '讀取XML中的上次登錄用戶名

    '        Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
    '        For Each xn As XmlNode In nodeList
    '            If LCase(xn.Name) = "systemip" Then
    '                ServerName = xn.InnerText
    '            ElseIf LCase(xn.Name) = "collectcon" Then
    '                ServerCon = xn.InnerText
    '            ElseIf LCase(xn.Name) = "startcollect" Then
    '                If xn.InnerText.Trim = "0" Then
    '                    IsConnect = False
    '                Else
    '                    IsConnect = True
    '                End If
    '            ElseIf LCase(xn.Name) = "lockfile" Then
    '                LockFile = xn.InnerText
    '            ElseIf LCase(xn.Name) = "master" Then
    '                Master = xn.InnerText
    '            ElseIf LCase(xn.Name) = "servername" Then
    '                FactoryName = xn.InnerText
    '            ElseIf LCase(xn.Name) = "linename" Then
    '                Linename = xn.InnerText
    '            End If
    '        Next
    '        If IsConnect Then
    '            MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = ServerCon
    '            MainFrame.SysDataHandle.SysDataBaseClass.IsSecurity = True
    '            ipstr = ServerCon.Split(";")(0).Split("=")(1).ToString
    '        Else
    '            MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = ServerName
    '            MainFrame.SysDataHandle.SysDataBaseClass.IsSecurity = False
    '            ipstr = ServerName
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & vbNewLine & "不存在XML檔", "提示資訊", MessageBoxButtons.OK)
    '        Exit Sub
    '    End Try
    'End Sub

    '扫描设置
    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click

        WorkStantOption.FormName = Me.Name
        Dim FrmConfigSet As New FrmConfigPackSet
        FrmConfigSet.ShowDialog()
        If ScanOption.IsExitFlag = True Then Exit Sub
        LabLineID.Text = ScanOption.SelLineID
        LabMoID.Text = ScanOption.SelMOID
        lbl_MOSetupQty.Text = ScanOption.MOSetupQty
        lbl_MOScannedQty.Text = ScanOption.MOScannedQty
        lbl_MONGQty.Text = ScanOption.MONGQty
        ControlCartonState(0)

        ''如果是自动生成外箱的料号，则自动生成外箱
        ''add by song
        ''2017-09-02
        'If (ScanOption.CartonAutoGen = True) Then
        '    txtCarton.Text = ScanOption.SelCartonStyle
        '    If (ScanOption.SelCartonStyle = "L1WUC005-CS-H****V350DXY0") Then
        '        txtCarton.Text = GetStyle("L1WUC005-CS-H****V350DXY0")
        '    End If
        '    ScanCarton()
        'End If

        If Not ScanOption.IsScanCustProAndQtyI Then
            AutoScanCartonFun()
        End If
    End Sub

    '自动扫描外箱,存储过程中有自动生成外箱,规则是:外箱=生产线别+外箱条码样式+流水号
    Private Sub AutoScanCartonFun()
        If ScanOption.CartonAutoGen AndAlso (Not ScanOption.IsScanFixedCarton) Then
            Me.txtCarton.Text = ScanOption.SelCartonStyle

            'Begin Mr Luu Add Scan Rework 2020-01-08'
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                If chk_MoRework.CheckState = CheckState.Checked Then
                    ScanCartonRework()
                    Exit Sub
                End If
            End If
            'End Mr Luu Add Scan Rework 2020-01-08'

            ScanCarton()
        End If
    End Sub

    '状态设置
    Private Sub ControlCartonState(ByVal ScanIndex As String)
        If ScanIndex = "0" Then
            If ScanOption.IsScanCustProAndQtyI Then
                LabHwInfo.BackColor = Color.Gray
            Else
                LabHwInfo.BackColor = SystemColors.Control
            End If
            LabInfo1.BackColor = Color.Gray
            If ScanOption.IsScanCartonQrCode Then
                LabInfo2.BackColor = Color.Gray
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo3.BackColor = Color.Gray
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray

            If ScanOption.IsScanCustProAndQtyI Then
                txtStyle.Text = ScanOption.CustPartStyle
                TxtBHWCode.Enabled = True
                TxtBHWCode.ReadOnly = False
                txtCarton.Enabled = False
                txtCarton.ReadOnly = True
            Else
                txtStyle.Text = ScanOption.SelCartonStyle
                TxtBHWCode.Enabled = False
                TxtBHWCode.ReadOnly = True
                txtCarton.Enabled = True
                txtCarton.ReadOnly = False
            End If
            
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            TxtBHWCode.Clear()
            txtCarton.Clear()
            txtSecond.Clear()
            txtPpid.Clear()
            CheckHwIndex = 0
            CheckCartonIndex = 0
            LabNeedQtyI.Text = ScanOption.CartonQty.ToString
            Me.LabCompleteQtyI.Text = "0"
            Me.DoCount = 0
            curindex = 0
            IsScanLayer = False
            LayerNum = 0
            PcsOfEachLayer = 0
            PackageNum = 0
            LayerIndex = 0
            If ScanOption.IsScanSecondCode Then
                Me.MetroTilePanel1.Visible = True
                Dim packCount As Integer = ScanOption.CartonQty / ScanOption.SelSecondQty
                Dim _size As Size = New Size
                _size.Height = 50
                _size.Width = 150
                If packCount >= 100 Then
                    _size.Height = 30
                    _size.Width = 75
                End If
                ItemContainer1.SubItems.Clear()
                Dim objlb As DevComponents.DotNetBar.LabelItem = New DevComponents.DotNetBar.LabelItem
                objlb.Name = "L001"
                objlb.Text = "装箱明细 CHi tiết đóng gói"
                objlb.ContainerNewLineAfter = True
                ItemContainer1.SubItems.Add(objlb)
                Dim i As Integer = 1
                For i = 1 To packCount
                    Dim obj As DevComponents.DotNetBar.Metro.MetroTileItem = New DevComponents.DotNetBar.Metro.MetroTileItem
                    obj.Name = "T001" + i.ToString
                    obj.Text = i.ToString
                    obj.TileSize = _size
                    obj.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray
                    obj.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
                    ItemContainer1.SubItems.Add(obj)
                Next
                CType(ItemContainer1.SubItems(0), DevComponents.DotNetBar.LabelItem).Text = "装箱进度明细CHi tiết tiến độ đói gói" + "---" + "每个大外箱装 Mỗi thùng carton lớn bên ngoài " + packCount.ToString + "个PE袋，每个PE袋装 Túi PE, mỗi túi PE" + ScanOption.SelSecondQty.ToString + "个产品"
                MetroTilePanel1.Refresh()
            Else
                '料号L1WAD004-CS-H和料号L1WUC005-CS-H增加托盘进度条显示 Add By KyLinQiu201228
                Me.MetroTilePanel1.Visible = False
                Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format("SELECT a.LayerNum,a.PcsOfEachLayer,a.PackageNum, a.PartId FROM dbo.m_PartGroupWithOutPEBag_t a INNER JOIN dbo.m_Mainmo_t b ON a.PartId=b.PartID WHERE b.Moid='{0}' AND a.IsUseY='Y'", ScanOption.SelMOID))
                If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
                    Try
                        LayerNum = Convert.ToInt32(dtTemp.Rows(0)("LayerNum").ToString.Trim)
                        PcsOfEachLayer = Convert.ToInt32(dtTemp.Rows(0)("PcsOfEachLayer").ToString.Trim)
                        PackageNum = Convert.ToInt32(dtTemp.Rows(0)("PackageNum").ToString.Trim)

                        'Mr Luu Edit 2018-09-03
                        PartId = dtTemp.Rows(0)("PartId").ToString.Trim
                        ScanOption.PartID = PartId
                        If (PartId = "L1LUC008-CS-H" Or PartId = "L1LUC010-CS-H" Or PartId = "L1LUC011-CS-H" Or PartId = "L1LUC014-CS-H" Or PartId = "L1LUC014-CS-H-VN" Or PartId = "L1LUC015-CS-H" Or PartId = "L1LUC008-CS-H-LQ" Or PartId = "L1LUC008-CS-H-HQ" Or PartId = "L1LUC008-CS-H-US" Or PartId = "L1LUC008-CS-H-WT" Or PartId = "L1LUC008-CS-H-VN") And VbCommClass.VbCommClass.Factory = "02J0" Then
                            Me.MetroTilePanel1.Visible = False
                            Me.MetroTilePanel1.Enabled = False
                            Me.DataGridView1.Width = 570
                            tableLayoutPanel1.Visible = True
                            txtPE1.Visible = True
                            k1 = 0
                            row1 = 0
                            index1 = 0

                            Dim str_SQL_LG = ""
                            Dim Qty_count As Integer = 0
                            If ScanOption.CartonAutoGen Then
                                str_SQL_LG = String.Format("select top 1 Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid like'{0}%' and CartonStatus='N' and CartonLevel=1 and Moid='{1}' and Teamid='{2}' ", ScanOption.SelLineID & Me.txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelLineID)
                            End If
                            Dim dt As DataTable = DbOperateUtils.GetDataTable(str_SQL_LG)
                            If (dt.Rows.Count > 0) Then
                                Qty_count = dt.Rows(0)("Cartonqty")
                                GenerateTable_LG_VN(13, 4)
                                Load_Tablelayout_LG(Qty_count)
                            Else
                                GenerateTable_LG_VN(13, 4)
                                Load_Tablelayout_LG(0)
                            End If

                        Else
                            txtPE1.Visible = False
                            tableLayoutPanel1.Visible = False
                            tableLayoutPanel1.Enabled = False
                            Me.MetroTilePanel1.Enabled = True
                            Me.MetroTilePanel1.Visible = True
                            If (LayerNum > 0) AndAlso (PcsOfEachLayer > 0) Then
                                Me.MetroTilePanel1.Visible = True
                                Dim packCount As Integer = LayerNum
                                Dim _size As Size = New Size
                                _size.Height = 50
                                '_size.Width = 140
                                'Begin Mr Luu Edit XiaoMi 2020-01-04
                                If PartId = "L6BU2032-CS-H-2" Or PartId = "L6BU2060-CS-H-1" Or PartId = "L6BU2060-CS-H" Then
                                    _size.Width = 116
                                Else
                                    _size.Width = 140
                                End If
                                'End  Mr Luu Edit XiaoMi 2020-01-04
                                If packCount >= 100 Then
                                    _size.Height = 30
                                    _size.Width = 70
                                End If
                                ItemContainer1.SubItems.Clear()
                                Dim objlb As DevComponents.DotNetBar.LabelItem = New DevComponents.DotNetBar.LabelItem
                                objlb.Name = "M001"
                                objlb.Text = "装箱明细"
                                objlb.ContainerNewLineAfter = True
                                ItemContainer1.SubItems.Add(objlb)
                                Dim i As Integer = 1
                                For i = 1 To packCount
                                    Dim obj As DevComponents.DotNetBar.Metro.MetroTileItem = New DevComponents.DotNetBar.Metro.MetroTileItem
                                    obj.Name = "N001" + i.ToString
                                    obj.Text = i.ToString
                                    obj.TileSize = _size
                                    obj.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray
                                    obj.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
                                    ItemContainer1.SubItems.Add(obj)
                                Next
                                CType(ItemContainer1.SubItems(0), DevComponents.DotNetBar.LabelItem).Text = "装箱进度明细" + "---" + "每个大外箱装" + packCount.ToString + "个托盘，每个托盘装" + PcsOfEachLayer.ToString + "个产品"
                                MetroTilePanel1.Refresh()
                                IsScanLayer = True
                            End If
                        End If
                    Catch ex As Exception
                        '出错说明托盘数据格式有误...
                        MessageBox.Show("托盘数据格式有误,请联系开发人员Quy cách dữ liệu khay có lỗi, Vui lòng liên hệ nhân viên lập trình!" & ex.Message)
                    End Try
                End If
            End If
            If ScanOption.IsScanCustProAndQtyI Then
                lblResult.Text = "请扫描客户料号条码 Vui lòng quét mã liệu khách hàng"
                TxtBHWCode.Focus()
            Else
                lblResult.Text = "请扫描大外箱条码 Vui lòng quét mã thùng to"
                txtCarton.Focus()
            End If
            lblMessage.Text = "开始扫描 Bắt đầu quét..."
            lblResult.ForeColor = Color.DarkGreen
            lblMessage.ForeColor = Color.Green
        ElseIf ScanIndex = "1" Then
            LabInfo1.BackColor = Color.Green
            If ScanOption.IsScanCartonQrCode Then
                LabInfo2.BackColor = Color.Gray
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo3.BackColor = Color.Gray
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelQrCodeStyle
            txtCarton.Enabled = True
            txtCarton.ReadOnly = False
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtSecond.BorderColor = Color.FromArgb(35, 130, 196)
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
            txtCarton.Text = ""
            Me.txtCarton.Focus()
            txtSecond.Text = ""
            txtPpid.Text = ""
        ElseIf ScanIndex = "2" Then
            If ScanOption.IsScanCustProAndQtyI Then
                LabHwInfo.BackColor = Color.Green
            Else
                LabHwInfo.BackColor = SystemColors.Control
            End If
            LabInfo1.BackColor = Color.Green
            If ScanOption.IsScanCartonQrCode Then
                LabInfo2.BackColor = Color.Green
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo3.BackColor = Color.Gray
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelSecondStyle
            Me.TxtBHWCode.Enabled = False
            Me.TxtBHWCode.ReadOnly = True
            txtCarton.Enabled = False
            txtCarton.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = True
            txtSecond.ReadOnly = False
            txtSecond.Text = ""
            txtPpid.Text = ""
            Me.txtSecond.Focus()
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
        ElseIf ScanIndex = "3" Then
            If ScanOption.IsScanCustProAndQtyI Then
                LabHwInfo.BackColor = Color.Green
            Else
                LabHwInfo.BackColor = SystemColors.Control
            End If
            LabInfo1.BackColor = Color.Green
            If ScanOption.IsScanCartonQrCode Then
                LabInfo2.BackColor = Color.Green
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo3.BackColor = Color.Gray
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelThirdStyle
            Me.TxtBHWCode.Enabled = False
            Me.TxtBHWCode.ReadOnly = True
            txtCarton.Enabled = False
            txtCarton.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = True
            txtSecond.ReadOnly = False
            txtSecond.Text = ""
            txtSecond.Focus()
            txtPpid.Text = ""
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
        ElseIf ScanIndex = "4" Then '产品条码
            If ScanOption.IsScanCustProAndQtyI Then
                LabHwInfo.BackColor = Color.Green
            Else
                LabHwInfo.BackColor = SystemColors.Control
            End If
            LabInfo1.BackColor = Color.Green
            If ScanOption.IsScanCartonQrCode Then
                LabInfo2.BackColor = Color.Green
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo3.BackColor = Color.Green
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray
            ScanOption.vCurrentStandIndex = 4
            Me.TxtBHWCode.Enabled = False
            Me.TxtBHWCode.ReadOnly = True
            txtCarton.Enabled = False
            txtCarton.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtSecond.BorderColor = Color.FromArgb(35, 130, 196)
            txtStyle.Text = ScanOption.SelPpidStyle
            txtPpid.Text = ""
            txtPpid.Enabled = True
            txtPpid.ReadOnly = False
            Me.txtPpid.Focus()
        End If
    End Sub

    '外箱条码扫描逻辑
    Private Sub ScanCarton()
        DicData = New Dictionary(Of String, String)

        If CheckCartonIndex = 0 Then
            '增加是否系统打印判断  Add By KyLinQiu 20171016
            If ScanOption.IsSystemPrintCarton Then
                If CheckIsSystemPrint(txtCarton.Text.Trim) = False Then
                    ' Begin Mr Luu Add Warning audio 20190617
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_Warning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(1)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190617
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = "该外箱条码不是由系统打印，打印记录表中不存在！Mã thùng ngoài này không phải in trên hệ thống, danh sách lịch sử in không tồn tại"
                    FrmError.MyCobError = "请检查外箱条码样式 Vui lòng kiểm tra quy cách mã thùng ngoài！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该外箱条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查外箱条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
            End If

            If CheckStyle(txtCarton.Text.Trim, "大外箱条码") = False Then
                ' Begin Mr Luu Add Warning audio 20190617
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190617
                Dim FrmError As New FrmScanErrPromptNew

                FrmError.MyBarCodeStr = txtCarton.Text.Trim
                FrmError.MyErrorStr = "大外箱条码样式不匹配 Quy cách mã thùng ngoài không phù hợp"
                FrmError.MyCobError = "请检查大外箱条码样式！Vui lòng kiểm tra mã quy cách thùng ngoài"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "大外箱条码样式不匹配", SysMessageClass.UseId, "请检查大外箱条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                FrmError.ShowDialog()
                txtCarton.Text = ""
                txtCarton.Focus()
                Exit Sub
            End If

            ''如果是L1WUC003-CS-H，L1WUC005-CS-H，处理方法有所不同
            ''add by song
            ''2017-08-03
            'Dim s As String = ""
            'Dim Partid As String = ""
            'Dim sql As String = ""
            's = "select PartId from m_Mainmo_t(nolock) where Moid='" & LabMoID.Text & "'"
            'Dim d As DataTable = DbOperateUtils.GetDataTable(s)
            'If d.Rows.Count > 0 Then
            '    Partid = d.Rows(0)(0).ToString.Trim
            'End If

            ''自动生成外箱与不自动生成处箱查询条件不一样
            ''add by song
            ''2017-09-06
            'If (ScanOption.CartonAutoGen = False) Then
            '    sql = "select Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid='" & txtCarton.Text.Trim & "'  ;"
            'Else
            '    sql = "select top 1 Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid like'%" & txtCarton.Text.Trim & "%' and CartonStatus='N' and Moid='" & LabMoID.Text.Trim & "' order by topcartonid desc  ;"
            'End If

            'If Partid = "L1WUC003-CS-H" Then
            '    If txtStyle.Text.Trim = "L1WUC003-CS-HJ110A350DXY0" Then
            '        sql = "select top 1 Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid like'%" & txtCarton.Text.Trim & "%' and CartonStatus='N' and Moid='" & LabMoID.Text.Trim & "' order by topcartonid desc  ;"
            '    Else
            '        Dim FrmError As New FrmScanErrPromptNew
            '        Dim ErrorStr As String = "Carton样式不正确！"
            '        Data.BarCodeStr = txtCarton.Text.Trim
            '        Data.CheckStr = False
            '        WorkStantOption.BarCodeStr = txtCarton.Text.Trim
            '        WorkStantOption.ErrorStr = ErrorStr
            '        WorkStantOption.PartidStr = WorkStantOption.PartidStr
            '        WorkStantOption.vSq = WorkStantOption.vSq
            '        WorkStantOption.vMainBarCode = txtCarton.Text.Trim
            '        FrmError.ShowDialog()
            '        Return
            '    End If
            'End If
            'If Partid = "L1WUC005-CS-H" Then
            '    If txtStyle.Text.Trim = "L1WUC005-CS-H****V350DXY0" Then
            '        Dim ss As String = GetStyle("L1WUC005-CS-H****V350DXY0")
            '        sql = "select top 1 Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid like'%" & ss & "%' and CartonStatus='N' and Moid='" & LabMoID.Text.Trim & "' order by topcartonid desc  ;"
            '    Else
            '        Dim FrmError As New FrmScanErrPromptNew
            '        Dim ErrorStr As String = "Carton样式不正确！"
            '        Data.BarCodeStr = txtCarton.Text.Trim
            '        Data.CheckStr = False
            '        WorkStantOption.BarCodeStr = txtCarton.Text.Trim
            '        WorkStantOption.ErrorStr = ErrorStr
            '        WorkStantOption.PartidStr = WorkStantOption.PartidStr
            '        WorkStantOption.vSq = WorkStantOption.vSq
            '        WorkStantOption.vMainBarCode = txtCarton.Text.Trim
            '        FrmError.ShowDialog()
            '        Return
            '    End If
            'End If

            'Update By KyLinQiu
            Dim sql As String = "select Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid='" & txtCarton.Text.Trim & "' "
            If ScanOption.CartonAutoGen Then
                sql = String.Format("select top 1 Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_Carton_HY_t where topcartonid like'{0}%' and CartonStatus='N' and Moid='{1}' and Teamid='{2}' ", ScanOption.SelLineID & Me.txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelLineID)
            End If

            Dim DataDt As DataSet = DbOperateUtils.GetDataSet(sql)

            Dim CartonStatus As String = ""
            If DataDt.Tables(0).Rows.Count > 0 Then '有数据，需要判断继续扫描PE袋还是扫描产品条码
                Dim Topdr() As DataRow = DataDt.Tables(0).Select("CartonLevel=1")
                'add by song
                '2017/08/05
                If Topdr(0)("Cartonid").ToString.Trim <> "" Then
                    txtCarton.Text = Topdr(0)("Cartonid").ToString.Trim
                End If
                If Topdr(0)("Moid").ToString.Trim <> ScanOption.SelMOID.Trim Then
                    SetMessage("Fail", "该大外箱条码 Mã thùng này:" + txtCarton.Text.Trim + "已在工单đã ở trong công đơn này:" + Topdr(0)("Moid").ToString.Trim + "中扫描过 quét mã！")
                    Dim FrmError As New FrmScanErrPromptNew
                    Dim ErrorStr As String = "该大外箱条码:" + txtCarton.Text.Trim + "已在工单:" + Topdr(0)("Moid").ToString.Trim + "中扫描过！"

                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "请检查大外箱是否已经扫描过 Vui lòng kiểm tra mã thùng ngoài đã quét qua chưa? ！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查大外箱是否已经扫描过！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
                '增加装箱数量设置是否一致判断
                If Convert.ToInt32(Topdr(0)("PackingQuantity").ToString.Trim) <> Convert.ToInt32(Me.LabNeedQtyI.Text.Trim) Then
                    SetMessage("Fail", "该大外箱条码 Mã thùng ngoài này " + txtCarton.Text.Trim + "两次设置装箱数量不一致 2 lần thiết đặt số lượng thùng không đồng nhất！")
                    Dim FrmError As New FrmScanErrPromptNew
                    Dim ErrorStr As String = "大外箱两次设置装箱数量不一致 2 lần thiết đặt số lượng mã thùng to không đồng nhất"

                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "请检查大外箱设置装箱数量 Vui lòng kiểm tra thiết đặt số lượng mã thùng to ！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查大外箱设置装箱数量！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
                CartonStatus = Topdr(0)("CartonStatus").ToString
                If CartonStatus = "Y" Then
                    SetMessage("Fail", "该大外箱条码 Mã thùng to này " + txtCarton.Text.Trim + "已扫描包装完成 đã quét hoàn thành！")
                    Dim FrmError As New FrmScanErrPromptNew
                    Dim ErrorStr As String = "大外箱条码已扫描包装完成 Mã thùng to này đã quét hoàn thành! "

                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "大外箱条码已扫描包装完成 Mã thùng ngoài đã quét hoàn thành đóng gói！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "大外箱条码已扫描包装完成！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                Else
                    DoCount = Topdr(0)("Cartonqty")
                    LabCompleteQtyI.Text = DoCount.ToString
                    Dim Seconddr() As DataRow = DataDt.Tables(0).Select("CartonLevel=2")
                    If Seconddr.Length > 0 Then
                        If Not ScanOption.IsScanSecondCode Then
                            SetMessage("Fail", "二层外箱PE袋两次设置是否扫描不一致 Mã vạch cài đặt lần 2 tầng 2 PE không đồng nhất！")
                            Dim FrmError As New FrmScanErrPromptNew
                            Dim ErrorStr As String = "二层PE袋条码两次设置是否扫描不一致 Mã vạch cài đặt lần 2 tầng 2 PE không đồng nhất"

                            FrmError.MyBarCodeStr = txtCarton.Text.Trim
                            FrmError.MyErrorStr = ErrorStr
                            FrmError.MyCobError = "请检查二层PE袋条码两次设置 Kiểm tra 2 lần cài đặt mã bao PE tầng 2！"

                            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查二层PE袋条码两次设置！")
                            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                            FrmError.ShowDialog()
                            txtCarton.Text = ""
                            txtCarton.Focus()
                            Exit Sub
                        End If
                        Dim pecode As String = ""
                        Dim i As Integer = 0
                        For i = 0 To Seconddr.Length - 1
                            Dim dr As DataRow = Seconddr(i)
                            curindex = i + 1
                            DicData.Add(dr("Cartonid").ToString.Trim, curindex.ToString)
                            If dr("CartonStatus") = "Y" Then
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + dr("Cartonqty").ToString '+ "/" + dr("PackingQuantity").ToString
                            Else
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + dr("Cartonqty").ToString + "/" + dr("PackingQuantity").ToString
                                pecode = dr("Cartonid").ToString
                            End If
                        Next
                        'If pecode <> "" Then
                        '    txtSecond.Text = pecode
                        '    SetMessage("PASS", "外箱条码" + Trim(txtCarton.Text) + "扫描成功，有未装满的PE袋，请继续装箱！")
                        '    ControlCartonState("4")
                        'Else
                        '    SetMessage("PASS", "外箱条码" + Trim(txtCarton.Text) + "扫描成功，请继续扫描二层PE袋条码！")
                        '    ControlCartonState("2")
                        'End If
                        SetMessage("PASS", "外箱条码 Mã thùng ngoài " + Trim(txtCarton.Text) + "扫描成功，请继续扫描二层PE袋条码 quét hoàn thành, vui lòng tiếp tục quét mã vạch bao PE tầng 2！")
                        ControlCartonState("2")
                    Else
                        If ScanOption.IsScanSecondCode Then
                            txtStyle.Text = ScanOption.SelSecondStyle
                            lblCode02.Text = "二层外箱条码:"
                            lblMessage.Text = "请继续扫描二层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 2 "
                            lblResult.Text = "条码 Mã tem " + txtCarton.Text + "已扫描通过 đã quét thông qua"
                            lblResult.ForeColor = Color.DarkGreen
                            lblMessage.ForeColor = Color.Gold
                            ControlCartonState("2")
                            SetMessage("PASS", "外箱条码 Mã thùng ngoài " + Trim(txtCarton.Text) + "扫描成功，请继续扫描二层PE袋条码！quét thành công, Tiếp tục quét mã vạch bao PE tầng 2 ")
                        ElseIf ScanOption.IsScanThirdCode Then
                            txtStyle.Text = ScanOption.SelSecondStyle
                            lblCode02.Text = "三层外箱条码:"
                            lblMessage.Text = "请继续扫描三层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 3 "
                            lblResult.Text = "条码 Mã tem  " + txtCarton.Text + "已扫描通过 đã quét thông qua"
                            lblResult.ForeColor = Color.DarkGreen
                            lblMessage.ForeColor = Color.Gold
                            ControlCartonState("3")
                            SetMessage("PASS", "外箱条码  Mã thùng ngoài " + Trim(txtCarton.Text) + "扫描成功，请继续扫描三层PE袋条码 quét thành công, Tiếp tục quét mã vạch bao PE tầng 3！")
                        Else
                            If IsScanLayer Then
                                Dim CartonqtyLayer As Integer = Convert.ToInt32(Topdr(0)("Cartonqty").ToString.Trim())
                                Dim PackingQuantityLayer As Integer = Convert.ToInt32(Topdr(0)("PackingQuantity").ToString.Trim())
                                If PackingQuantityLayer <> PackageNum Then
                                    SetMessage("Fail", "托盘设置装箱数量与系统设置装箱数量不一致,请检查！Cài đặt số lượng đóng gói khay và cài đặt số lượng đóng gói hệ thống không đồng nhất, vui lòng kiểm tra lại !")
                                    Dim FrmError As New FrmScanErrPromptNew
                                    Dim ErrorStr As String = "托盘设置装箱数量与系统设置装箱数量不一致 Cài đặt số lượng đóng gói khay và cái đặt số lượng đống gói hệ thống không đồng nhất"

                                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                                    FrmError.MyErrorStr = ErrorStr
                                    FrmError.MyCobError = "托盘设置装箱数量与系统设置装箱数量不一致 Cài đặt số lượng đóng gói khay và cái đặt số lượng đống gói hệ thống không đồng nhất"

                                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "托盘设置装箱数量与系统设置装箱数量不一致")
                                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                                    FrmError.ShowDialog()
                                    txtCarton.Text = ""
                                    txtCarton.Focus()
                                    Exit Sub
                                End If
                                Dim LayerCount As Integer = CartonqtyLayer \ PcsOfEachLayer
                                For j As Integer = 0 To LayerCount - 1
                                    LayerIndex = j + 1
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = LayerIndex.ToString + "-" + PcsOfEachLayer.ToString
                                Next
                                Dim LayerModNum As Integer = CartonqtyLayer Mod PcsOfEachLayer
                                LayerIndex = LayerIndex + 1
                                If LayerModNum <> 0 Then
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = LayerIndex.ToString + "-" + LayerModNum.ToString + "/" + PcsOfEachLayer.ToString
                                End If
                            End If
                            ControlCartonState("4")
                            SetMessage("PASS", "外箱条码 Mã thùng ngoài " + Trim(txtCarton.Text) + "扫描成功，请继续扫描产品条码！quét thành công, Vui lòng tiếp tục quét mã sản phẩm")
                        End If

                    End If
                End If
                GetScanData(txtCarton.Text.Trim)
            Else
                '检查是否超过工单数量
                Dim StrMoCheckSql As String = String.Format(" SELECT ISNULL(SUM(a.PackingQuantity),0) AS PackingQuantity,b.Moqty FROM m_Carton_HY_t a INNER JOIN dbo.m_Mainmo_t b ON a.Moid=b.Moid " &
                                              " WHERE a.Moid='{0}' AND a.CartonLevel=1 GROUP BY b.Moqty", ScanOption.SelMOID)
                Dim dtMoCheckData As DataTable = DbOperateUtils.GetDataTable(StrMoCheckSql)
                If (Not dtMoCheckData Is Nothing) AndAlso dtMoCheckData.Rows.Count > 0 Then
                    If (ScanOption.CartonQty + Convert.ToInt32(dtMoCheckData.Rows(0)("PackingQuantity").ToString)) > Convert.ToInt32(dtMoCheckData.Rows(0)("Moqty").ToString) Then
                        SetMessage("FAIL", "装箱数量已超过工单数可以装箱的数量,请检查是否有空箱或未装满箱 Số lượng đóng gói đã vượt quá số lượng có thể đóng gói công đơn, Vui lòng kiểm tra có thùng không hoặc thùng chưa đóng gói đầy không ? ")
                        Dim FrmError As New FrmScanErrPromptNew
                        Dim ErrorStr As String = "装箱数量已超过工单数可以装箱的数量,请检查是否有空箱或未装满箱！ Số lượng đóng gói đã vượt quá số lượng có thể đóng gói công đơn, Vui lòng kiểm tra có thùng không hoặc thùng chưa đóng gói đầy không ?"

                        FrmError.MyBarCodeStr = txtCarton.Text.Trim
                        FrmError.MyErrorStr = ErrorStr
                        FrmError.MyCobError = "请检查装箱数量 Vui lòng kiểm tra số lượng đóng gói！"

                        Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查装箱数量！")
                        Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                        FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                        FrmError.ShowDialog()
                        'txtCarton.Enabled = False
                        'txtCarton.ReadOnly = True
                        txtCarton.Enabled = True
                        txtCarton.ReadOnly = False
                        txtSecond.Enabled = False
                        txtSecond.ReadOnly = True
                        txtPpid.Enabled = False
                        txtPpid.ReadOnly = True
                        Exit Sub
                    End If
                End If

                '没有数据，则开启校验数据
                If ScanOption.IsScanCartonQrCode Then
                    CheckCartonIndex = CheckCartonIndex + 1
                    TempCartonId = txtCarton.Text.Trim
                    txtStyle.Text = ScanOption.SelQrCodeStyle
                    lblCode01.Text = "外箱QRCODE:"
                    lblMessage.Text = "请继续扫描外箱QRCODE条码 Vui lòng tiếp tục quét mã QRCODE thùng ngoài"
                    lblResult.Text = "条码 Mã tem " + TempCartonId + "已扫描通过 đã được quét"
                    lblResult.ForeColor = Color.DarkGreen
                    lblMessage.ForeColor = Color.Gold
                    txtCarton.Clear()
                    txtCarton.Focus()
                Else
                    Dim IsAutoGenerateCarton As String = "N"
                    If ScanOption.CartonAutoGen Then
                        IsAutoGenerateCarton = "Y"
                    End If
                    Dim qrcode As String = ""
                    Dim Sqlstr As String = "declare @strmsgid varchar(1),@strmsgText varchar(200),@qty int execute [m_NV_NewCartonScan_p_ByNewScan] " & _
                     " '" & Trim(ScanOption.SelMOID) & "','" & Trim(ScanOption.SelLineID) & "','" & Trim(txtCarton.Text) & "','" & qrcode & "','" & Trim(txtCarton.Text) & "','" & Trim(txtCarton.Text) & "','" & Trim(ScanOption.CartonQty) & "',1,'" & SysMessageClass.UseId & "'," & _
                     "@strmsgid output,@strmsgText output,@qty output,'" & IsAutoGenerateCarton & "' select @strmsgid ,isnull(@strmsgText,'') ,@qty "
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                    If dt.Rows.Count > 0 Then
                        Select Case dt.Rows(0)(0).ToString()
                            Case "1" To "3"
                                SetMessage("FAIL", dt.Rows(0)(1).ToString())
                                Dim FrmError As New FrmScanErrPromptNew

                                FrmError.MyBarCodeStr = txtCarton.Text.Trim
                                FrmError.MyErrorStr = dt.Rows(0)(1).ToString()
                                FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi ！"

                                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, dt.Rows(0)(1).ToString(), SysMessageClass.UseId, "请检查相关错误信息！")
                                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                                FrmError.ShowDialog()
                                Me.txtCarton.Clear()
                                txtCarton.Focus()
                                Exit Sub
                            Case 4
                                DataGridView1.Rows.Clear()
                                'add by song
                                '2017-08-05
                                'If txtStyle.Text.Trim = "L1WUC003-CS-HJ110A350DXY0" Then
                                'txtCarton.Text = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功！", "")
                                'End If
                                'add by song
                                '2017-09-02
                                'If txtStyle.Text.Trim = "L1WUC005-CS-H****V350DXY0" Then
                                'txtCarton.Text = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功！", "")
                                'End If
                                If (ScanOption.CartonAutoGen = True) Then
                                    txtCarton.Text = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功 Quét thành công！", "")
                                End If

                                SetMessage("PASS", "外箱条码 Mã thùng ngoài " + Trim(txtCarton.Text) + "扫描成功Quét thành công！")

                                If IsScanLayer Then
                                    LayerIndex = LayerIndex + 1
                                End If

                                Me.DataGridView1.Rows.Insert(0, Trim(txtCarton.Text), Trim(txtCarton.Text), SysMessageClass.UseId, Now())

                                DataGridView1.ClearSelection()
                                DataGridView1.Rows(0).Cells(0).Selected = True
                                If DataGridView1.Rows.Count > 30 Then
                                    DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                                End If
                                lblCode01.Text = "外层外箱条码:"
                        End Select
                    End If
                    CheckCartonIndex = 0

                    If ScanOption.IsScanSecondCode Then
                        txtStyle.Text = ScanOption.SelSecondStyle
                        lblCode02.Text = "二层外箱条码:"
                        lblMessage.Text = "请继续扫描二层外箱条码 Vui lòng tiếp tục quét mã thùng ngoài tầng 2"
                        lblResult.Text = "条码 Mã tem " + txtCarton.Text + "已扫描通过 đã được quét"
                        lblResult.ForeColor = Color.DarkGreen
                        lblMessage.ForeColor = Color.Gold
                        ControlCartonState("2")
                    ElseIf ScanOption.IsScanThirdCode Then
                        txtStyle.Text = ScanOption.SelSecondStyle
                        lblCode02.Text = "三层外箱条码:"
                        lblMessage.Text = "请继续扫描三层外箱条码 Vui lòng tiếp tục quét mã thùng ngoài tầng 3"
                        lblResult.Text = "条码 Mã tem" + txtCarton.Text + "已扫描通过 đã được quét"
                        lblResult.ForeColor = Color.DarkGreen
                        lblMessage.ForeColor = Color.Gold
                        ControlCartonState("3")
                    Else
                        ControlCartonState("4")
                    End If
                End If
            End If
        Else
            Dim IsAutoGenerateCarton As String = "N"
            If ScanOption.CartonAutoGen Then
                IsAutoGenerateCarton = "Y"
            End If
            Dim qrcode As String = txtCarton.Text.Trim

            '增加是否系统打印判断  Add By KyLinQiu 20171016
            If ScanOption.IsSystemPrintQRCode Then
                If CheckIsSystemPrint(qrcode) = False Then
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = qrcode
                    FrmError.MyErrorStr = "该外箱QR条码不是由系统打印，打印记录表中不存在 Mã QR thùng ngoài không phải do hệ thống in, Trong bảng lịch sử in tem không tồn tại mã này！"
                    FrmError.MyCobError = "请检查外箱QR条码样式 Vui lòng kiểm tra quy cách mã QR thùng！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该外箱QR条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查外箱QR条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
            End If

            If CheckStyle(qrcode, "QRCODE条码") = False Then
                Dim FrmError As New FrmScanErrPromptNew
                Dim ErrorStr As String = "QRCODE条码样式不匹配SS"

                FrmError.MyBarCodeStr = txtCarton.Text.Trim
                FrmError.MyErrorStr = ErrorStr
                FrmError.MyCobError = "请检查QRCODE条码样式 Vui lòng kiểm tra quy cách mã QRCODE！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查QRCODE条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                FrmError.ShowDialog()
                txtCarton.Text = ""
                txtCarton.Focus()
                Exit Sub
            End If

            Dim Sqlstr As String = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_NV_NewCartonScan_p_ByNewScan] " & _
                  " '" & Trim(ScanOption.SelMOID) & "','" & Trim(ScanOption.SelLineID) & "','" & Trim(TempCartonId) & "','" & qrcode & "','" & Trim(TempCartonId) & "','" & Trim(TempCartonId) & "','" & Trim(ScanOption.CartonQty) & "',1,'" & SysMessageClass.UseId & "'," & _
                  "@strmsgid output,@strmsgText output,@qty output,'" & IsAutoGenerateCarton & "'  select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        SetMessage("FAIL", dt.Rows(0)(1).ToString())
                        Dim FrmError As New FrmScanErrPromptNew

                        FrmError.MyBarCodeStr = Trim(TempCartonId)
                        FrmError.MyErrorStr = dt.Rows(0)(1).ToString()
                        FrmError.MyCobError = "请检查相关错误信息 Vui lòng kiểm tra thông tin lỗi liên quan！"

                        Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", Trim(TempCartonId), ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, dt.Rows(0)(1).ToString(), SysMessageClass.UseId, "请检查相关错误信息！")
                        Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                        FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                        FrmError.ShowDialog()
                        Me.txtCarton.Clear()
                        Me.txtCarton.Focus()
                        Exit Sub
                    Case 4
                        DataGridView1.Rows.Clear()
                        'add by song
                        '2017-08-05
                        'If txtStyle.Text.Trim = "L1WUC003-CS-HJ110A350DXY0" Then
                        'TempCartonId = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功！", "")
                        'End If
                        If (ScanOption.CartonAutoGen = True) Then
                            TempCartonId = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功 QUét mã thành công！", "")
                        End If
                        txtCarton.Text = TempCartonId
                        SetMessage("PASS", "外箱条码 Mã tem thùng" + Trim(TempCartonId) + "及QRCODE码扫描成功 và mã QRCODE quét thành công！")

                        If IsScanLayer Then
                            LayerIndex = LayerIndex + 1
                        End If

                        Me.DataGridView1.Rows.Insert(0, Trim(TempCartonId), Trim(TempCartonId), SysMessageClass.UseId, Now())

                        DataGridView1.ClearSelection()
                        DataGridView1.Rows(0).Cells(0).Selected = True
                        If DataGridView1.Rows.Count > 30 Then
                            DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                        End If
                        lblCode01.Text = "外层外箱条码:"
                End Select
            End If
            CheckCartonIndex = 0
            If ScanOption.IsScanSecondCode Then
                txtStyle.Text = ScanOption.SelSecondStyle
                lblCode02.Text = "二层外箱条码:"
                lblMessage.Text = "请继续扫描二层外箱条码 Vui lòng tiếp tục quét mã thùng tầng 2"
                lblResult.Text = "条码 Mã tem " + TempCartonId + "已扫描通过 đã được quét"
                lblResult.ForeColor = Color.DarkGreen
                lblMessage.ForeColor = Color.Gold
                ControlCartonState("2")
            ElseIf ScanOption.IsScanThirdCode Then
                txtStyle.Text = ScanOption.SelSecondStyle
                lblCode02.Text = "三层外箱条码:"
                lblMessage.Text = "请继续扫描三层外箱条码 Vui lòng tiếp tục quét mã thùng tầng 3 "
                lblResult.Text = "条码 Mã tem" + TempCartonId + "已扫描通过 đã được quét"
                lblResult.ForeColor = Color.DarkGreen
                lblMessage.ForeColor = Color.Gold
                ControlCartonState("3")
            Else
                ControlCartonState("4")
            End If
        End If
    End Sub

    ' Begin Mr Luu Add ScanCartonRework 2020-01-08
    Private Sub ScanCartonRework()
        DicData = New Dictionary(Of String, String)

        If CheckCartonIndex = 0 Then
            '增加是否系统打印判断  Add By KyLinQiu 20171016
            If ScanOption.IsSystemPrintCarton Then
                If CheckIsSystemPrint(txtCarton.Text.Trim) = False Then
                    ' Begin Mr Luu Add Warning audio 20190617
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_Warning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(1)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190617
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = "该外箱条码不是由系统打印，打印记录表中不存在 Mã thùng ngoài này không phải in trên hệ thống, danh sách lịch sử in không tồn tại！"
                    FrmError.MyCobError = "请检查外箱条码样式 Vui lòng kiểm tra quy cách mã thùng ngoài！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该外箱条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查外箱条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
            End If

            If CheckStyle(txtCarton.Text.Trim, "大外箱条码") = False Then
                ' Begin Mr Luu Add Warning audio 20190617
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190617
                Dim FrmError As New FrmScanErrPromptNew

                FrmError.MyBarCodeStr = txtCarton.Text.Trim
                FrmError.MyErrorStr = "大外箱条码样式不匹配 Quy cách mã thùng ngoài không tương thích"
                FrmError.MyCobError = "请检查大外箱条码样式 Vui lòng kiểm tra quy cách mã thùng ngoài！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "大外箱条码样式不匹配", SysMessageClass.UseId, "请检查大外箱条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                FrmError.ShowDialog()
                txtCarton.Text = ""
                txtCarton.Focus()
                Exit Sub
            End If

            'Update By KyLinQiu
            Dim sql As String = "select Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_CartonRework_t where topcartonid='" & txtCarton.Text.Trim & "' "
            If ScanOption.CartonAutoGen Then
                sql = String.Format("select top 1 Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,Moid from m_CartonRework_t where topcartonid like'{0}%' and CartonStatus='N' and Moid='{1}' and Teamid='{2}' ", ScanOption.SelLineID & Me.txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelLineID)
            End If

            Dim DataDt As DataSet = DbOperateUtils.GetDataSet(sql)

            Dim CartonStatus As String = ""
            If DataDt.Tables(0).Rows.Count > 0 Then '有数据，需要判断继续扫描PE袋还是扫描产品条码
                Dim Topdr() As DataRow = DataDt.Tables(0).Select("CartonLevel=1")
                'add by song
                '2017/08/05
                If Topdr(0)("Cartonid").ToString.Trim <> "" Then
                    txtCarton.Text = Topdr(0)("Cartonid").ToString.Trim
                End If
                If Topdr(0)("Moid").ToString.Trim <> ScanOption.SelMOID.Trim Then
                    SetMessage("Fail", "该大外箱条码 Mã thùng này :" + txtCarton.Text.Trim + "已在工单Đã quét trong côn đơn này :" + Topdr(0)("Moid").ToString.Trim + "中扫描过！")
                    Dim FrmError As New FrmScanErrPromptNew
                    Dim ErrorStr As String = "该大外箱条码:" + txtCarton.Text.Trim + "已在工单:" + Topdr(0)("Moid").ToString.Trim + "中扫描过！"

                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "请检查大外箱是否已经扫描过 Vui lòng kiểm tra mã thùng nãy đã quét qua hay chưa ?！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查大外箱是否已经扫描过！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
                '增加装箱数量设置是否一致判断
                If Convert.ToInt32(Topdr(0)("PackingQuantity").ToString.Trim) <> Convert.ToInt32(Me.LabNeedQtyI.Text.Trim) Then
                    SetMessage("Fail", "该大外箱条码 Mã thùng ngoài này " + txtCarton.Text.Trim + "两次设置装箱数量不一致 2 lần cài đặt số lượng đóng gói không đồng nhất！")
                    Dim FrmError As New FrmScanErrPromptNew
                    Dim ErrorStr As String = "大外箱两次设置装箱数量不一致 2 lần thiết đặt số lượng mã thùng to không đồng nhất"

                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "请检查大外箱设置装箱数量  Vui lòng kiểm tra cài đặt số lượng đóng gói！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查大外箱设置装箱数量！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
                CartonStatus = Topdr(0)("CartonStatus").ToString
                If CartonStatus = "Y" Then
                    SetMessage("Fail", "该大外箱条码 Mã thùng này" + txtCarton.Text.Trim + "已扫描包装完成 đã quét đóng gói hoàn thành！")
                    Dim FrmError As New FrmScanErrPromptNew
                    Dim ErrorStr As String = "大外箱条码已扫描包装完成"

                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "大外箱条码已扫描包装完成 Mã thùng to đã quét đóng gói hoàn thành ！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "大外箱条码已扫描包装完成！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                Else
                    DoCount = Topdr(0)("Cartonqty")
                    LabCompleteQtyI.Text = DoCount.ToString
                    Dim Seconddr() As DataRow = DataDt.Tables(0).Select("CartonLevel=2")
                    If Seconddr.Length > 0 Then
                        If Not ScanOption.IsScanSecondCode Then
                            SetMessage("Fail", "二层外箱PE袋两次设置是否扫描不一致 Mã Bao PE thùng ngoài tầng 2 cài đặt 2 lần không đồng nhất！")
                            Dim FrmError As New FrmScanErrPromptNew
                            Dim ErrorStr As String = "二层PE袋条码两次设置是否扫描不一致 Mã vạch cài đặt lần 2 tầng 2 PE không đồng nhất"

                            FrmError.MyBarCodeStr = txtCarton.Text.Trim
                            FrmError.MyErrorStr = ErrorStr
                            FrmError.MyCobError = "请检查二层PE袋条码两次设置 Vui lòng kiểm tra mã bao PE tầng 2 thiết đặt 2 lần không đồng nhất！"

                            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查二层PE袋条码两次设置！")
                            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                            FrmError.ShowDialog()
                            txtCarton.Text = ""
                            txtCarton.Focus()
                            Exit Sub
                        End If
                        Dim pecode As String = ""
                        Dim i As Integer = 0
                        For i = 0 To Seconddr.Length - 1
                            Dim dr As DataRow = Seconddr(i)
                            curindex = i + 1
                            DicData.Add(dr("Cartonid").ToString.Trim, curindex.ToString)
                            If dr("CartonStatus") = "Y" Then
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + dr("Cartonqty").ToString '+ "/" + dr("PackingQuantity").ToString
                            Else
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
                                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + dr("Cartonqty").ToString + "/" + dr("PackingQuantity").ToString
                                pecode = dr("Cartonid").ToString
                            End If
                        Next
                        'If pecode <> "" Then
                        '    txtSecond.Text = pecode
                        '    SetMessage("PASS", "外箱条码" + Trim(txtCarton.Text) + "扫描成功，有未装满的PE袋，请继续装箱！")
                        '    ControlCartonState("4")
                        'Else
                        '    SetMessage("PASS", "外箱条码" + Trim(txtCarton.Text) + "扫描成功，请继续扫描二层PE袋条码！")
                        '    ControlCartonState("2")
                        'End If
                        SetMessage("PASS", "外箱条码 mã thùng ngoài" + Trim(txtCarton.Text) + "扫描成功，请继续扫描二层PE袋条码！QUét thành công, tiếp tục quét mã bao PE tầng 2")
                        ControlCartonState("2")
                    Else
                        If ScanOption.IsScanSecondCode Then
                            txtStyle.Text = ScanOption.SelSecondStyle
                            lblCode02.Text = "二层外箱条码:"
                            lblMessage.Text = "请继续扫描二层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 2 "
                            lblResult.Text = "条码 Mã tem" + txtCarton.Text + "已扫描通过 đã được quét"
                            lblResult.ForeColor = Color.DarkGreen
                            lblMessage.ForeColor = Color.Gold
                            ControlCartonState("2")
                            SetMessage("PASS", "外箱条码 Mã thùng ngoài" + Trim(txtCarton.Text) + "扫描成功，请继续扫描二层PE袋条码  quét hoàn thành, vui lòng tiếp tục quét mã vạch bao PE tầng 2！")
                        ElseIf ScanOption.IsScanThirdCode Then
                            txtStyle.Text = ScanOption.SelSecondStyle
                            lblCode02.Text = "三层外箱条码:"
                            lblMessage.Text = "请继续扫描三层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 3"
                            lblResult.Text = "条码 Mã tem" + txtCarton.Text + "已扫描通过 đã được quét"
                            lblResult.ForeColor = Color.DarkGreen
                            lblMessage.ForeColor = Color.Gold
                            ControlCartonState("3")
                            SetMessage("PASS", "外箱条码 Mã thùng ngoài" + Trim(txtCarton.Text) + "扫描成功，请继续扫描三层PE袋条码  quét hoàn thành, vui lòng tiếp tục quét mã vạch bao PE tầng 3！")
                        Else
                            If IsScanLayer Then
                                Dim CartonqtyLayer As Integer = Convert.ToInt32(Topdr(0)("Cartonqty").ToString.Trim())
                                Dim PackingQuantityLayer As Integer = Convert.ToInt32(Topdr(0)("PackingQuantity").ToString.Trim())
                                If PackingQuantityLayer <> PackageNum Then
                                    SetMessage("Fail", "托盘设置装箱数量与系统设置装箱数量不一致,请检查 Cài đặt số lượng đóng gói khay và cài đặt số lượng đóng gói hệ thống không đồng nhất, vui lòng kiểm tra lại！")
                                    Dim FrmError As New FrmScanErrPromptNew
                                    Dim ErrorStr As String = "托盘设置装箱数量与系统设置装箱数量不一致"

                                    FrmError.MyBarCodeStr = txtCarton.Text.Trim
                                    FrmError.MyErrorStr = ErrorStr
                                    FrmError.MyCobError = "托盘设置装箱数量与系统设置装箱数量不一致 Cài đặt số lượng đóng gói khay và cài đặt số lượng đóng gói hệ thống không đồng nhất"

                                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "托盘设置装箱数量与系统设置装箱数量不一致")
                                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                                    FrmError.ShowDialog()
                                    txtCarton.Text = ""
                                    txtCarton.Focus()
                                    Exit Sub
                                End If
                                Dim LayerCount As Integer = CartonqtyLayer \ PcsOfEachLayer
                                For j As Integer = 0 To LayerCount - 1
                                    LayerIndex = j + 1
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = LayerIndex.ToString + "-" + PcsOfEachLayer.ToString
                                Next
                                Dim LayerModNum As Integer = CartonqtyLayer Mod PcsOfEachLayer
                                LayerIndex = LayerIndex + 1
                                If LayerModNum <> 0 Then
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                                    CType(ItemContainer1.SubItems(LayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = LayerIndex.ToString + "-" + LayerModNum.ToString + "/" + PcsOfEachLayer.ToString
                                End If
                            End If
                            ControlCartonState("4")
                            SetMessage("PASS", "外箱条码 Mã thùng ngoài" + Trim(txtCarton.Text) + "扫描成功，请继续扫描产品条码 quét thành công, Vui lòng tiếp tục quét mã sản phẩm！")
                        End If

                    End If
                End If
                GetScanData(txtCarton.Text.Trim)
            Else
                '检查是否超过工单数量
                Dim StrMoCheckSql As String = String.Format(" SELECT ISNULL(SUM(a.PackingQuantity),0) AS PackingQuantity,b.Moqty FROM m_CartonRework_t a INNER JOIN dbo.m_Mainmo_t b ON a.Moid=b.Moid " &
                                              " WHERE a.Moid='{0}' AND a.CartonLevel=1 GROUP BY b.Moqty", ScanOption.SelMOID)
                Dim dtMoCheckData As DataTable = DbOperateUtils.GetDataTable(StrMoCheckSql)
                If (Not dtMoCheckData Is Nothing) AndAlso dtMoCheckData.Rows.Count > 0 Then
                    If (ScanOption.CartonQty + Convert.ToInt32(dtMoCheckData.Rows(0)("PackingQuantity").ToString)) > Convert.ToInt32(dtMoCheckData.Rows(0)("Moqty").ToString) Then
                        SetMessage("FAIL", "装箱数量已超过工单数可以装箱的数量,请检查是否有空箱或未装满箱 Số lượng đóng gói đã vượt quá số lượng có thể đóng gói công đơn, Vui lòng kiểm tra có thùng không hoặc thùng chưa đóng gói đầy không ?！")
                        Dim FrmError As New FrmScanErrPromptNew
                        Dim ErrorStr As String = "装箱数量已超过工单数可以装箱的数量,请检查是否有空箱或未装满箱！"

                        FrmError.MyBarCodeStr = txtCarton.Text.Trim
                        FrmError.MyErrorStr = ErrorStr
                        FrmError.MyCobError = "请检查装箱数量 Vui lòng kiểm tra số lượng đóng gói ！"

                        Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查装箱数量！")
                        Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                        FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                        FrmError.ShowDialog()
                        'txtCarton.Enabled = False
                        'txtCarton.ReadOnly = True
                        txtCarton.Enabled = True
                        txtCarton.ReadOnly = False
                        txtSecond.Enabled = False
                        txtSecond.ReadOnly = True
                        txtPpid.Enabled = False
                        txtPpid.ReadOnly = True
                        Exit Sub
                    End If
                End If

                '没有数据，则开启校验数据
                If ScanOption.IsScanCartonQrCode Then
                    CheckCartonIndex = CheckCartonIndex + 1
                    TempCartonId = txtCarton.Text.Trim
                    txtStyle.Text = ScanOption.SelQrCodeStyle
                    lblCode01.Text = "外箱QRCODE:"
                    lblMessage.Text = "请继续扫描外箱QRCODE条码 Vui lòng tiếp tục quét mã QRCODE thùng ngoài"
                    lblResult.Text = "条码 Mã tem" + TempCartonId + "已扫描通过 đã được quét"
                    lblResult.ForeColor = Color.DarkGreen
                    lblMessage.ForeColor = Color.Gold
                    txtCarton.Clear()
                    txtCarton.Focus()
                Else
                    Dim IsAutoGenerateCarton As String = "N"
                    If ScanOption.CartonAutoGen Then
                        IsAutoGenerateCarton = "Y"
                    End If
                    Dim qrcode As String = ""
                    Dim Sqlstr As String = "declare @strmsgid varchar(1),@strmsgText varchar(200),@qty int execute [m_NV_NewCartonReworkScan_p_ByNewScan] " & _
                     " '" & Trim(ScanOption.SelMOID) & "','" & Trim(ScanOption.SelLineID) & "','" & Trim(txtCarton.Text) & "','" & qrcode & "','" & Trim(txtCarton.Text) & "','" & Trim(txtCarton.Text) & "','" & Trim(ScanOption.CartonQty) & "',1,'" & SysMessageClass.UseId & "'," & _
                     "@strmsgid output,@strmsgText output,@qty output,'" & IsAutoGenerateCarton & "' select @strmsgid ,isnull(@strmsgText,'') ,@qty "
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                    If dt.Rows.Count > 0 Then
                        Select Case dt.Rows(0)(0).ToString()
                            Case "1" To "3"
                                SetMessage("FAIL", dt.Rows(0)(1).ToString())
                                Dim FrmError As New FrmScanErrPromptNew

                                FrmError.MyBarCodeStr = txtCarton.Text.Trim
                                FrmError.MyErrorStr = dt.Rows(0)(1).ToString()
                                FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi ！"

                                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, dt.Rows(0)(1).ToString(), SysMessageClass.UseId, "请检查相关错误信息！")
                                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                                FrmError.ShowDialog()
                                Me.txtCarton.Clear()
                                txtCarton.Focus()
                                Exit Sub
                            Case 4
                                DataGridView1.Rows.Clear()
                                'add by song
                                '2017-08-05
                                If (ScanOption.CartonAutoGen = True) Then
                                    txtCarton.Text = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功 Quét thàn công！", "")
                                End If

                                SetMessage("PASS", "外箱条码 Mã thùng " + Trim(txtCarton.Text) + "扫描成功 Quét thành công！")

                                If IsScanLayer Then
                                    LayerIndex = LayerIndex + 1
                                End If

                                Me.DataGridView1.Rows.Insert(0, Trim(txtCarton.Text), Trim(txtCarton.Text), SysMessageClass.UseId, Now())

                                DataGridView1.ClearSelection()
                                DataGridView1.Rows(0).Cells(0).Selected = True
                                If DataGridView1.Rows.Count > 30 Then
                                    DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                                End If
                                lblCode01.Text = "外层外箱条码:"
                        End Select
                    End If
                    CheckCartonIndex = 0

                    If ScanOption.IsScanSecondCode Then
                        txtStyle.Text = ScanOption.SelSecondStyle
                        lblCode02.Text = "二层外箱条码:"
                        lblMessage.Text = "请继续扫描二层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 2"
                        lblResult.Text = "条码 Mã Tem" + txtCarton.Text + "已扫描通过 đã được quét"
                        lblResult.ForeColor = Color.DarkGreen
                        lblMessage.ForeColor = Color.Gold
                        ControlCartonState("2")
                    ElseIf ScanOption.IsScanThirdCode Then
                        txtStyle.Text = ScanOption.SelSecondStyle
                        lblCode02.Text = "三层外箱条码:"
                        lblMessage.Text = "请继续扫描三层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 3"
                        lblResult.Text = "条码 Mã tem" + txtCarton.Text + "已扫描通过 đã được quét"
                        lblResult.ForeColor = Color.DarkGreen
                        lblMessage.ForeColor = Color.Gold
                        ControlCartonState("3")
                    Else
                        ControlCartonState("4")
                    End If
                End If
            End If
        Else
            Dim IsAutoGenerateCarton As String = "N"
            If ScanOption.CartonAutoGen Then
                IsAutoGenerateCarton = "Y"
            End If
            Dim qrcode As String = txtCarton.Text.Trim

            '增加是否系统打印判断  Add By KyLinQiu 20171016
            If ScanOption.IsSystemPrintQRCode Then
                If CheckIsSystemPrint(qrcode) = False Then
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = qrcode
                    FrmError.MyErrorStr = "该外箱QR条码不是由系统打印，打印记录表中不存在 Mã QR thùng ngoài không phải do hệ thống in, Trong bảng lịch sử in tem không tồn tại mã này！"
                    FrmError.MyCobError = "请检查外箱QR条码样式 Vui lòng kiểm tra quy cách mã QR thùng！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该外箱QR条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查外箱QR条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtCarton.Text = ""
                    txtCarton.Focus()
                    Exit Sub
                End If
            End If

            If CheckStyle(qrcode, "QRCODE条码") = False Then
                Dim FrmError As New FrmScanErrPromptNew
                Dim ErrorStr As String = "QRCODE条码样式不匹配"

                FrmError.MyBarCodeStr = txtCarton.Text.Trim
                FrmError.MyErrorStr = ErrorStr
                FrmError.MyCobError = "请检查QRCODE条码样式 Vui lòng kiểm tra quy cách mã QRCODE！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtCarton.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查QRCODE条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                FrmError.ShowDialog()
                txtCarton.Text = ""
                txtCarton.Focus()
                Exit Sub
            End If

            Dim Sqlstr As String = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_NV_NewCartonScan_p_ByNewScan] " & _
                  " '" & Trim(ScanOption.SelMOID) & "','" & Trim(ScanOption.SelLineID) & "','" & Trim(TempCartonId) & "','" & qrcode & "','" & Trim(TempCartonId) & "','" & Trim(TempCartonId) & "','" & Trim(ScanOption.CartonQty) & "',1,'" & SysMessageClass.UseId & "'," & _
                  "@strmsgid output,@strmsgText output,@qty output,'" & IsAutoGenerateCarton & "'  select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        SetMessage("FAIL", dt.Rows(0)(1).ToString())
                        Dim FrmError As New FrmScanErrPromptNew

                        FrmError.MyBarCodeStr = Trim(TempCartonId)
                        FrmError.MyErrorStr = dt.Rows(0)(1).ToString()
                        FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi！"

                        Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", Trim(TempCartonId), ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, dt.Rows(0)(1).ToString(), SysMessageClass.UseId, "请检查相关错误信息！")
                        Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                        FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                        FrmError.ShowDialog()
                        Me.txtCarton.Clear()
                        Me.txtCarton.Focus()
                        Exit Sub
                    Case 4
                        DataGridView1.Rows.Clear()
                        'add by song
                        '2017-08-05
                        If (ScanOption.CartonAutoGen = True) Then
                            TempCartonId = dt.Rows(0)(1).ToString.Trim.Replace("掃描成功Quét thành công！", "")
                        End If
                        txtCarton.Text = TempCartonId
                        SetMessage("PASS", "外箱条码 Mã thùng " + Trim(TempCartonId) + "及QRCODE码扫描成功 và mã QRCODE quét thành công！")

                        If IsScanLayer Then
                            LayerIndex = LayerIndex + 1
                        End If

                        Me.DataGridView1.Rows.Insert(0, Trim(TempCartonId), Trim(TempCartonId), SysMessageClass.UseId, Now())

                        DataGridView1.ClearSelection()
                        DataGridView1.Rows(0).Cells(0).Selected = True
                        If DataGridView1.Rows.Count > 30 Then
                            DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                        End If
                        lblCode01.Text = "外层外箱条码:"
                End Select
            End If
            CheckCartonIndex = 0
            If ScanOption.IsScanSecondCode Then
                txtStyle.Text = ScanOption.SelSecondStyle
                lblCode02.Text = "二层外箱条码:"
                lblMessage.Text = "请继续扫描二层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 2"
                lblResult.Text = "条码 Mã tem" + TempCartonId + "已扫描通过 đã được quét"
                lblResult.ForeColor = Color.DarkGreen
                lblMessage.ForeColor = Color.Gold
                ControlCartonState("2")
            ElseIf ScanOption.IsScanThirdCode Then
                txtStyle.Text = ScanOption.SelSecondStyle
                lblCode02.Text = "三层外箱条码:"
                lblMessage.Text = "请继续扫描三层外箱条码 Vui lòng tiếp tục quét mã tem thùng phân tầng 3"
                lblResult.Text = "条码 Mã tem" + TempCartonId + "已扫描通过 đã được quét"
                lblResult.ForeColor = Color.DarkGreen
                lblMessage.ForeColor = Color.Gold
                ControlCartonState("3")
            Else
                ControlCartonState("4")
            End If
        End If
    End Sub
    ' End Mr Luu Add ScanCartonRework 2020-01-08

    '外箱条码扫描
    Private Sub txtCarton_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCarton.KeyPress
        If (e.KeyChar = Chr(13)) AndAlso (Not Me.txtCarton.ReadOnly) Then
            If txtCarton.Text.Trim = "" Then
                Exit Sub
            End If

            'Begin Mr Luu Add Scan Rework 2020-01-08'
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                If chk_MoRework.CheckState = CheckState.Checked Then
                    Dim Sql_CheckCartonid As String = String.Format(" SELECT top 1 Cartonid  FROM dbo.m_Carton_HY_t WHERE TopCartonId='{0}' AND CartonLevel=1", Me.txtCarton.Text.Trim)
                    Dim dtCarton As DataTable = DbOperateUtils.GetDataTable(Sql_CheckCartonid)
                    If dtCarton.Rows.Count > 0 Then
                        ScanCartonRework()
                    Else
                        MessageBox.Show(" The Cartonid " & txtCarton.Text.Trim & " is not exist in sytem . It can not rework scanning .")
                    End If

                    Exit Sub
                End If
            End If
            'End Mr Luu Add Scan Rework 2020-01-08'
            ScanCarton()
        End If
    End Sub

    '设置信息
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lblResult.Text = message
            lblMessage.Text = "FAIL"
            lblResult.ForeColor = Color.DarkGreen
            lblMessage.ForeColor = Color.Red
        Else
            lblResult.Text = message
            lblMessage.Text = "PASS"
            lblResult.ForeColor = Color.DarkGreen
            lblMessage.ForeColor = Color.Green
        End If
    End Sub

    '扫描PE袋条码
    Private Sub txtSecond_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSecond.KeyPress
        If (e.KeyChar = Chr(13)) AndAlso (Not Me.txtSecond.ReadOnly) Then
            If txtCarton.Text.Trim = "" Then
                Exit Sub
            End If
            If txtSecond.Text.Trim = "" Then
                Exit Sub
            End If
            Dim qrcode As String = ""
            Dim cartonid As String = txtSecond.Text.Trim
            Dim pcartonid As String = txtCarton.Text
            Dim TopCartonId As String = txtCarton.Text
            Dim PackingQuantity As String = ScanOption.SelSecondQty.ToString

            '增加是否系统打印判断  Add By KyLinQiu 20171016
            If ScanOption.IsSystemPrintPECarton Then
                If CheckIsSystemPrint(cartonid) = False Then
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = cartonid
                    FrmError.MyErrorStr = "该PE袋条码不是由系统打印，打印记录表中不存在 Mã bao PE không phải do in ra từ hệ thống, Không tồn tại mã này trong bảng lịch sử in！"
                    FrmError.MyCobError = "请检查PE袋条码样式 Vui lòng kiểm tra quy cách mã bao PE！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该PE袋条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查PE袋条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtSecond.Text = ""
                    txtSecond.Focus()
                    Exit Sub
                End If
            End If

            If CheckStyle(cartonid, "二层外箱条码") = False Then
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = cartonid
                FrmError.MyErrorStr = "二层外箱条码样式不匹配 Quy cách mã tem tầng 2 không tương thích"
                FrmError.MyCobError = "请检查二层外箱条码样式 Vui lòng kiểm tra mã tem thùng tầng 2！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", cartonid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "二层外箱条码样式不匹配", SysMessageClass.UseId, "请检查二层外箱条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                FrmError.ShowDialog()
                txtSecond.Text = ""
                txtSecond.Focus()
                Exit Sub
            End If

            Dim sql As String = "select Cartonid,PCartonId,Cartonqty,PackingQuantity,CartonStatus,CartonLevel,TopCartonId from m_Carton_HY_t where cartonid='" & cartonid & "'  ;"
            Dim DataDt As DataSet = DbOperateUtils.GetDataSet(sql)

            Dim CartonStatus As String = ""
            If DataDt.Tables(0).Rows.Count > 0 Then '有数据，需要判断继续扫描PE袋还是扫描产品条码
                Dim Topdr As DataRow = DataDt.Tables(0).Rows(0)
                '增加判断
                If Topdr("TopCartonId").ToString.Trim <> Me.txtCarton.Text.Trim Then
                    SetMessage("Fail", "该外箱PE袋条码 Mã bao PE thùng ngoài này :" + cartonid + "在大外箱中 trong thùng to :" + Topdr("TopCartonId").ToString.Trim + "已经有扫描 đã quét！")
                    ControlCartonState("2")
                    Exit Sub
                End If
                CartonStatus = Topdr("CartonStatus").ToString

                If CartonStatus = "Y" Then
                    SetMessage("Fail", "该外箱PE袋条码 Mã bao PE thùng ngoài này" + cartonid + "已扫描过 đã được quét！")
                    ControlCartonState("2")
                Else
                    SetMessage("PASS", "二层外箱PE袋条码 Mã bao PE tầng 2 " + Trim(cartonid) + "扫描成功  đã hoàn thành！")
                    ControlCartonState("4")
                End If
            Else
                '增加PE袋是否已经满了判断 Add By KyLinQiu20171219
                sql = String.Format("SELECT ISNULL(COUNT(*),0) AS PECount FROM dbo.m_Carton_HY_t WHERE TopCartonId='{0}' AND CartonLevel=2", Me.txtCarton.Text.Trim)
                Dim dtTempPECount As DataTable = DbOperateUtils.GetDataTable(sql)
                Dim pECount As Integer = Convert.ToInt32(dtTempPECount.Rows(0)("PECount").ToString)
                If (pECount * ScanOption.SelSecondQty) >= ScanOption.CartonQty Then
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = cartonid
                    FrmError.MyErrorStr = "二层外箱数量已超出大外箱范围,请检查是否有未扫描的二层外箱 số lượng thùng tầng 2 đã vượt qua phạm vi số lượng thùng to, vui lòng xem còn mã thùng tầng 2 chưa quét！"
                    FrmError.MyCobError = "二层外箱数量已超出大外箱范围,请检查是否有未扫描的二层外箱 số lượng thùng tầng 2 đã vượt qua phạm vi số lượng thùng to, vui lòng xem còn mã thùng tầng 2 chưa quét！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", cartonid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "二层外箱数量已超出大外箱范围,请检查是否有未扫描的二层外箱！", SysMessageClass.UseId, "二层外箱数量已超出大外箱范围,请检查是否有未扫描的二层外箱！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                    FrmError.ShowDialog()
                    txtSecond.Text = ""
                    txtSecond.Focus()
                    Exit Sub
                End If

                Dim Sqlstr As String = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_NV_NewCartonScan_p_ByNewScan] " & _
                " '" & Trim(ScanOption.SelMOID) & "','" & Trim(ScanOption.SelLineID) & "','" & Trim(cartonid) & "','" & qrcode & "','" & Trim(pcartonid) & "','" & Trim(TopCartonId) & "','" & Trim(PackingQuantity) & "',2,'" & SysMessageClass.UseId & "'," & _
                "@strmsgid output,@strmsgText output,@qty output,'N' select @strmsgid ,isnull(@strmsgText,'') ,@qty "
                Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0).ToString()
                        Case "1" To "3"
                            SetMessage("FAIL", dt.Rows(0)(1).ToString())
                            Dim FrmError As New FrmScanErrPromptNew
                            FrmError.MyBarCodeStr = cartonid
                            FrmError.MyErrorStr = dt.Rows(0)(1).ToString()
                            FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi！"

                            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", cartonid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, dt.Rows(0)(1).ToString(), SysMessageClass.UseId, "请检查相关错误信息！")
                            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()

                            FrmError.ShowDialog()
                            Me.txtSecond.Clear()
                            Me.txtSecond.Focus()
                            Exit Sub
                        Case 4
                            SetMessage("PASS", "二层外箱PE袋条码 Mã bao PE thùng tầng 2" + Trim(cartonid) + "扫描成功 đã quét hoàn thành！")
                            Me.DataGridView1.Rows.Insert(0, cartonid, Trim(pcartonid), SysMessageClass.UseId, Now())
                            DataGridView1.ClearSelection()
                            DataGridView1.Rows(0).Cells(0).Selected = True
                            If DataGridView1.Rows.Count > 30 Then
                                DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                            End If
                            ControlCartonState("4")
                            curindex = curindex + 1
                    End Select
                End If
            End If
        End If
    End Sub

    '获取箱号扫描记录
    Private Sub GetScanData(ByVal cartonid As String)
        '换一种方式查询
        'DataGridView1.Rows.Clear()
        'Dim Dt As SqlDataReader
        'Dt = DbOperateUtils.GetDataReader(String.Format("select top 10 b.ppid,b.Cartonid,b.Userid,b.Intime from m_Carton_HY_t a join m_cartonsn_t b on a.cartonid=b.cartonid  where a.topcartonid='{0}' order by intime desc", cartonid))
        'If Dt.HasRows() Then
        '    While (Dt.Read())
        '        DataGridView1.Rows.Add(Dt!ppid, Dt!Cartonid, Dt!Userid, Dt!Intime)
        '    End While
        'End If
        'DataGridView1.AutoResizeColumns()
        'Dt.Close()
        'Dt.Dispose()
        Me.DataGridView1.Rows.Clear()
        Dim dtCartonPPIDData As DataTable = DbOperateUtils.GetDataTable(String.Format("select top 10 b.ppid,b.Cartonid,b.Userid,b.Intime from m_Carton_HY_t a join m_cartonsn_t b on a.cartonid=b.cartonid  where a.topcartonid='{0}' order by intime desc", cartonid))
        If (Not dtCartonPPIDData Is Nothing) AndAlso dtCartonPPIDData.Rows.Count > 0 Then
            For Each dr As DataRow In dtCartonPPIDData.Rows
                Me.DataGridView1.Rows.Add(dr("ppid").ToString.Trim, dr("Cartonid").ToString.Trim, dr("Userid").ToString.Trim, dr("Intime").ToString.Trim)
            Next
        End If
        DataGridView1.AutoResizeColumns()
    End Sub

    '继续下一箱产品扫描
    Private Sub ToolNext_Click(sender As Object, e As EventArgs) Handles ToolNext.Click
        If ScanOption.IsExitFlag = True Then Exit Sub
        ControlCartonState(0)
        If ScanOption.IsScanCustProAndQtyI Then
            lblResult.Text = "请重新扫描客户料号条码 Vui lòng quét mã liệu khách hàng"
            Me.TxtBHWCode.Focus()
        Else
            lblResult.Text = "请重新扫描大外箱条码 Vui lòng quét lại mã thùng to"
            Me.txtCarton.Focus()
        End If
        lblMessage.Text = "开始扫描 bắt đầu quét..."
        lblResult.ForeColor = Color.DarkGreen
        lblMessage.ForeColor = Color.Green
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs)
    End Sub

    '设置进度条
    Private Sub Set_SubItemsOK(ByVal curindex As Integer)
        Dim val As String = CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text.Trim
        Dim arr() As String = val.Split("-")
        If arr.Length = 2 Then
            Dim qtyarr() As String = arr(1).Trim.Split("/")
            Dim finishedqty As String = qtyarr(0).ToString
            Dim cartonqty As String = qtyarr(1).ToString
            Dim str As String = ""
            If (Integer.Parse(finishedqty) + 1) < Integer.Parse(cartonqty) Then
                str = (Integer.Parse(finishedqty) + 1).ToString + "/" + cartonqty
                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + str
            Else
                str = (Integer.Parse(finishedqty) + 1).ToString
                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + str
            End If

        Else
            Dim str As String = "1/" + ScanOption.SelSecondQty.ToString
            CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal
            CType(ItemContainer1.SubItems(curindex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = curindex.ToString + "-" + str

        End If
    End Sub

    '设置托盘进度条 Add By KyLinQiu20171228
    Private Sub SetLayerItemsOk(ByVal currLayerIndex As Integer)
        Dim val As String = CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text.Trim
        Dim arr() As String = val.Split("-")
        If arr.Length = 2 Then
            Dim qtyarr() As String = arr(1).Trim.Split("/")
            Dim finishedqty As String = qtyarr(0).ToString
            Dim cartonqty As String = qtyarr(1).ToString
            Dim str As String = ""
            If (Integer.Parse(finishedqty) + 1) < Integer.Parse(cartonqty) Then
                str = (Integer.Parse(finishedqty) + 1).ToString + "/" + cartonqty
                CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = currLayerIndex.ToString + "-" + str
            Else
                str = (Integer.Parse(finishedqty) + 1).ToString
                CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = currLayerIndex.ToString + "-" + str
                Me.LayerIndex = Me.LayerIndex + 1
            End If
        Else
            Dim str As String = "1/" + PcsOfEachLayer.ToString
            CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
            CType(ItemContainer1.SubItems(currLayerIndex), DevComponents.DotNetBar.Metro.MetroTileItem).Text = currLayerIndex.ToString + "-" + str
        End If
    End Sub

    '条码扫描具体逻辑
    Private Sub ScanPpid()
        If ScanOption.IsScanSecondCode Then
            If txtSecond.Text.Trim = "" Then
                Exit Sub
            End If
        End If
        If txtPpid.Text.Trim = "" Then
            Exit Sub
        End If

        Dim ppid As String = txtPpid.Text.Trim

        '增加是否系统打印判断  Add By KyLinQiu 20171016
        If ScanOption.IsSystemPrintPpID Then
            If CheckIsSystemPrint(ppid) = False Then
                ' Begin Mr Luu Add Warning audio 20190614
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190614
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = ppid
                FrmError.MyErrorStr = "该产品条码不是由系统打印，打印记录表中不存在 Mã sản phẩm này không phải in từ hệ thống, không tồn tại mã này trong bảng lịch sử ！"
                FrmError.MyCobError = "请检查产品条码样式 Vui lòng kiểm tra quy cách mã sản phẩm！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该产品条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查产品条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                lbl_MONGQty.Text = Convert.ToString(Convert.ToInt32(lbl_MONGQty.Text) + 1)
                'Begin Mr Luu Add QC unlock 20180810
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                    ConnectDB.ExecSql(strSQL_Insert)
                End If
                'End Mr Luu Add QC unlock 20180810
                FrmError.ShowDialog()
                txtPpid.Text = ""
                txtPpid.Focus()
                Exit Sub
            End If
        End If

        If CheckStyle(ppid, "产品条码") = False Then
            ' Begin Mr Luu Add Warning audio 20190614
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                If chk_Warning.CheckState = CheckState.Checked Then
                    PlaySimpleSound(1)
                End If
            End If
            'End Mr Luu Add Warning audio 20190614
            Dim FrmError As New FrmScanErrPromptNew
            FrmError.MyBarCodeStr = ppid
            FrmError.MyErrorStr = "产品条码样式不匹配 Quy cách mã sản phẩm không phù hợp "
            FrmError.MyCobError = "请检查产品条码样式！ Vui lòng kiểm tra quy cách mã sản phẩm "

            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
            lbl_MONGQty.Text = Convert.ToString(Convert.ToInt32(lbl_MONGQty.Text) + 1)
            'Begin Mr Luu Add QC unlock 20180529
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                ConnectDB.ExecSql(strSQL_Insert)
            End If
            'End Mr Luu Add QC unlock 20180529
            FrmError.ShowDialog()
            txtPpid.Text = ""
            txtPpid.Focus()
            Exit Sub
        End If

        Dim MO_ID As String = Trim(ScanOption.SelMOID)
        Dim TEAM_ID As String = Trim(ScanOption.SelLineID)
        Dim SPOINT As String = Environment.MachineName
        Dim USER_ID As String = SysMessageClass.UseId
        '工站目前写死
        Dim STATION_ID As String = "P0001"
        Dim STAORDER_ID As String = "1"
        Dim SCANORDER_ID As String = "1"
        Dim CARTON_ID As String = ""
        If ScanOption.IsScanSecondCode Then
            CARTON_ID = txtSecond.Text.Trim
        Else
            CARTON_ID = txtCarton.Text.Trim
        End If
        Dim FACT_QUANTITY As String = ScanOption.SelSecondQty
        Dim IsFixedCode As String = "N"
        If ScanOption.PPid_N Then
            IsFixedCode = "Y"
        End If

        'Begin 2019-07-22 Mr Luu added OPPO repaired product
        Dim P_Mark1 As String = Nothing
        Dim Sqlstr As String = ""
        If VbCommClass.VbCommClass.Factory.ToUpper = "02J0" Then
            If chk_OPPORepaired.CheckState = CheckState.Checked Then
                P_Mark1 = "OPPO-Repaired"
                Sqlstr = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_OPPOReparied] " &
            "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "','" & P_Mark1 & "', " &
            "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "
            Else
                Sqlstr = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_ByNewScan] " &
            "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "', " &
            "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "
            End If
        Else
            Sqlstr = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_ByNewScan] " & _
          "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "', " & _
          "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "
        End If 
        'End 2019-07-22 Mr Luu added OPPO repaired product

        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0)(0).ToString()
                Case "1" To "3"
                    Dim ErrorStr As String = dt.Rows(0)(1).ToString()
                    SetMessage("FAIL", ErrorStr)

                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = txtPpid.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtPpid.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查相关错误信息！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                    'Begin Mr Luu Add QC unlock 20180810
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                        Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                        ConnectDB.ExecSql(strSQL_Insert)
                    End If
                    'End Mr Luu Add QC unlock 20180810
                    FrmError.ShowDialog()
                    Me.txtPpid.Clear()
                    Me.txtPpid.Focus()
                    Exit Sub
                Case 6
                    SetMessage("PASS", "产品条码  Mã sản phẩm" + Trim(ppid) + "扫描成功 quét thành công！")
                    ' Begin Mr Luu Add Warning audio 20190614
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_Warning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(0)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190614
                    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(0).Cells(0).Selected = True
                    If DataGridView1.Rows.Count > 30 Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                    End If

                    'ControlCartonState("4")
                    DoCount = DoCount + ScanOption.SelPpidQty
                    LabCompleteQtyI.Text = DoCount.ToString
                    lbl_MOScannedQty.Text = Convert.ToString(Convert.ToInt32(lbl_MOScannedQty.Text) + Convert.ToInt32(ScanOption.SelPpidQty))
                    'End Mr Luu Edit 2018-10-03
                    If (ScanOption.Partid = "L1LUC008-CS-H" Or ScanOption.Partid = "L1LUC010-CS-H" Or ScanOption.Partid = "L1LUC011-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H-VN" Or ScanOption.Partid = "L1LUC015-CS-H" Or ScanOption.Partid = "L1LUC008-CS-H-LQ" Or ScanOption.Partid = "L1LUC008-CS-H-HQ" Or ScanOption.Partid = "L1LUC008-CS-H-US" Or ScanOption.Partid = "L1LUC008-CS-H-WT" Or ScanOption.Partid = "L1LUC008-CS-H-VN") And VbCommClass.VbCommClass.Factory = "02J0" Then
                        Scan_Barcode_LG_VN()
                    Else
                        ControlCartonState("4")
                    End If
                    'End Mr Luu Edit 2018-10-03
                    If ScanOption.IsScanSecondCode Then
                        If DicData.ContainsKey(Me.txtSecond.Text.Trim) Then
                            Set_SubItemsOK(Convert.ToInt32(DicData(Me.txtSecond.Text.Trim)))
                        Else
                            Set_SubItemsOK(curindex)
                        End If
                    ElseIf IsScanLayer Then
                        SetLayerItemsOk(LayerIndex)
                    End If
                Case 7
                    SetMessage("PASS", "产品条码 Mã sản phẩm" + Trim(ppid) + "扫描成功！请扫描下一个PE袋条码 quét thành công, Vui lòng quét mã bao PE tiếp theo")
                    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(0).Cells(0).Selected = True
                    If DataGridView1.Rows.Count > 30 Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                    End If
                    ControlCartonState("2")
                    DoCount = DoCount + ScanOption.SelPpidQty
                    LabCompleteQtyI.Text = DoCount.ToString
                    lbl_MOScannedQty.Text = Convert.ToString(Convert.ToInt32(lbl_MOScannedQty.Text) + Convert.ToInt32(ScanOption.SelPpidQty))
                    If ScanOption.IsScanSecondCode Then
                        If DicData.ContainsKey(Me.txtSecond.Text.Trim) Then
                            Set_SubItemsOK(Convert.ToInt32(DicData(Me.txtSecond.Text.Trim)))
                        Else
                            Set_SubItemsOK(curindex)
                        End If
                    ElseIf IsScanLayer Then
                        SetLayerItemsOk(LayerIndex)
                    End If
                Case 8 '最外层大外箱装箱完成
                    SetMessage("PASS", "产品条码 Mã sản phẩm " + Trim(ppid) + "扫描成功！装箱完毕，请扫描下一个外箱条码 quét hoàn thành, Đóng gói hoàn thành, vui lòng quét mã thùng tiếp theo")
                    ' Begin Mr Luu Add Warning audio 20190614
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_CartonWarning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(2)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190614
                    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(0).Cells(0).Selected = True
                    If DataGridView1.Rows.Count > 30 Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                    End If
                    ControlCartonState("0")
                    DoCount = 0
                    LabCompleteQtyI.Text = DoCount.ToString
                    lbl_MOScannedQty.Text = Convert.ToString(Convert.ToInt32(lbl_MOScannedQty.Text) + Convert.ToInt32(ScanOption.SelPpidQty))
                    'lbl_MOScannedQty.Text = "0"
                    curindex = 0
                    LayerIndex = 0
                    'Mr Luu Add 2018-10-03
                    If (ScanOption.Partid = "L1LUC008-CS-H" Or ScanOption.Partid = "L1LUC010-CS-H" Or ScanOption.Partid = "L1LUC011-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H-VN" Or ScanOption.Partid = "L1LUC015-CS-H" Or ScanOption.Partid = "L1LUC008-CS-H-LQ" Or ScanOption.Partid = "L1LUC008-CS-H-HQ" Or ScanOption.Partid = "L1LUC008-CS-H-US" Or ScanOption.Partid = "L1LUC008-CS-H-WT" Or ScanOption.Partid = "L1LUC008-CS-H-VN") And VbCommClass.VbCommClass.Factory = "02J0" Then
                        txtPE1.BackColor = Color.Red
                    End If
                    'End Mr Luu Add 2018-10-03
                    'LabInfo4.BackColor = Color.Green
                    'AutGenCartonID(ppid)
                    If Not ScanOption.IsScanCustProAndQtyI Then
                        AutoScanCartonFun()
                    End If
            End Select
        End If
    End Sub

    ' Begin Mr Luu Add ScanPpidRework 2020-01-08
    Private Sub ScanPpidRework()
        If ScanOption.IsScanSecondCode Then
            If txtSecond.Text.Trim = "" Then
                Exit Sub
            End If
        End If
        If txtPpid.Text.Trim = "" Then
            Exit Sub
        End If

        Dim ppid As String = txtPpid.Text.Trim

        '增加是否系统打印判断  Add By KyLinQiu 20171016
        If ScanOption.IsSystemPrintPpID Then
            If CheckIsSystemPrint(ppid) = False Then
                ' Begin Mr Luu Add Warning audio 20190614
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190614
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = ppid
                FrmError.MyErrorStr = "该产品条码不是由系统打印，打印记录表中不存在 Mã sản phẩm này không in từ hệ thống, không tồn tại trong bảng lịch sử in ！"
                FrmError.MyCobError = "请检查产品条码样式 Kiểm tra quy cách mã sản phẩm！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该产品条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查产品条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                'Begin Mr Luu Add QC unlock 20180810
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                    ConnectDB.ExecSql(strSQL_Insert)
                End If
                'End Mr Luu Add QC unlock 20180810
                FrmError.ShowDialog()
                txtPpid.Text = ""
                txtPpid.Focus()
                Exit Sub
            End If
        End If

        If CheckStyle(ppid, "产品条码") = False Then
            ' Begin Mr Luu Add Warning audio 20190614
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                If chk_Warning.CheckState = CheckState.Checked Then
                    PlaySimpleSound(1)
                End If
            End If
            'End Mr Luu Add Warning audio 20190614
            Dim FrmError As New FrmScanErrPromptNew
            FrmError.MyBarCodeStr = ppid
            FrmError.MyErrorStr = "产品条码样式不匹配 Quy cách mã sản phẩm không tương thích"
            FrmError.MyCobError = "请检查产品条码样式 Kiểm tra quy cách mã sản phẩm！"

            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
            'Begin Mr Luu Add QC unlock 20180529
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                ConnectDB.ExecSql(strSQL_Insert)
            End If
            'End Mr Luu Add QC unlock 20180529
            FrmError.ShowDialog()
            txtPpid.Text = ""
            txtPpid.Focus()
            Exit Sub
        End If

        Dim MO_ID As String = Trim(ScanOption.SelMOID)
        Dim TEAM_ID As String = Trim(ScanOption.SelLineID)
        Dim SPOINT As String = Environment.MachineName
        Dim USER_ID As String = SysMessageClass.UseId
        '工站目前写死
        Dim STATION_ID As String = "P0001"
        Dim STAORDER_ID As String = "1"
        Dim SCANORDER_ID As String = "1"
        Dim CARTON_ID As String = ""
        If ScanOption.IsScanSecondCode Then
            CARTON_ID = txtSecond.Text.Trim
        Else
            CARTON_ID = txtCarton.Text.Trim
        End If
        Dim FACT_QUANTITY As String = ScanOption.SelSecondQty
        Dim IsFixedCode As String = "N"
        If ScanOption.PPid_N Then
            IsFixedCode = "Y"
        End If

        'Begin 2019-07-22 Mr Luu added OPPO repaired product
        Dim P_Mark1 As String = Nothing
        Dim Sqlstr As String = ""
        If VbCommClass.VbCommClass.Factory.ToUpper = "02J0" Then
            'If chk_OPPORepaired.CheckState = CheckState.Checked Then
            '    P_Mark1 = "OPPO-Repaired"
            '    Sqlstr = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_OPPOReparied] " & _
            '"'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "','" & P_Mark1 & "', " & _
            '"@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "
            'Else
            Sqlstr = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScanRework_P_ByNewScan] " &
        "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "', " &
        "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "
            ' End If
        Else
            Sqlstr = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_ByNewScan] " & _
          "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "', " & _
          "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "
        End If
        'End 2019-07-22 Mr Luu added OPPO repaired product

        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0)(0).ToString()
                Case "1" To "3"
                    Dim ErrorStr As String = dt.Rows(0)(1).ToString()
                    SetMessage("FAIL", ErrorStr)

                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = txtPpid.Text.Trim
                    FrmError.MyErrorStr = ErrorStr
                    FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi！"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtPpid.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查相关错误信息！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                    'Begin Mr Luu Add QC unlock 20180810
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                        Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                        ConnectDB.ExecSql(strSQL_Insert)
                    End If
                    'End Mr Luu Add QC unlock 20180810
                    FrmError.ShowDialog()
                    Me.txtPpid.Clear()
                    Me.txtPpid.Focus()
                    Exit Sub
                Case 6
                    SetMessage("PASS", "产品条码 mã sản phẩm  " + Trim(ppid) + "扫描成功 đã được quét！")
                    ' Begin Mr Luu Add Warning audio 20190614
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_Warning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(0)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190614
                    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(0).Cells(0).Selected = True
                    If DataGridView1.Rows.Count > 30 Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                    End If

                    'ControlCartonState("4")
                    DoCount = DoCount + ScanOption.SelPpidQty
                    LabCompleteQtyI.Text = DoCount.ToString
                    'End Mr Luu Edit 2018-10-03
                    If (ScanOption.Partid = "L1LUC008-CS-H" Or ScanOption.Partid = "L1LUC010-CS-H" Or ScanOption.Partid = "L1LUC011-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H-VN" Or ScanOption.Partid = "L1LUC015-CS-H" Or ScanOption.Partid = "L1LUC008-CS-H-LQ" Or ScanOption.Partid = "L1LUC008-CS-H-HQ" Or ScanOption.Partid = "L1LUC008-CS-H-US" Or ScanOption.Partid = "L1LUC008-CS-H-WT" Or ScanOption.Partid = "L1LUC008-CS-H-VN") And VbCommClass.VbCommClass.Factory = "02J0" Then
                        Scan_Barcode_LG_VN()
                    Else
                        ControlCartonState("4")
                    End If
                    'End Mr Luu Edit 2018-10-03
                    If ScanOption.IsScanSecondCode Then
                        If DicData.ContainsKey(Me.txtSecond.Text.Trim) Then
                            Set_SubItemsOK(Convert.ToInt32(DicData(Me.txtSecond.Text.Trim)))
                        Else
                            Set_SubItemsOK(curindex)
                        End If
                    ElseIf IsScanLayer Then
                        SetLayerItemsOk(LayerIndex)
                    End If

                Case 7
                    SetMessage("PASS", "产品条码 Mã sản phẩm " + Trim(ppid) + "扫描成功！请扫描下一个PE袋条码 quét thành công, vui lòng quét tiếp mã bao tiếp theo")
                    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(0).Cells(0).Selected = True
                    If DataGridView1.Rows.Count > 30 Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                    End If
                    ControlCartonState("2")
                    DoCount = DoCount + ScanOption.SelPpidQty
                    LabCompleteQtyI.Text = DoCount.ToString
                    If ScanOption.IsScanSecondCode Then
                        If DicData.ContainsKey(Me.txtSecond.Text.Trim) Then
                            Set_SubItemsOK(Convert.ToInt32(DicData(Me.txtSecond.Text.Trim)))
                        Else
                            Set_SubItemsOK(curindex)
                        End If
                    ElseIf IsScanLayer Then
                        SetLayerItemsOk(LayerIndex)
                    End If
                Case 8 '最外层大外箱装箱完成
                    SetMessage("PASS", "产品条码 mã sản phẩm" + Trim(ppid) + "扫描成功！装箱完毕，请扫描下一个外箱条码 quét thành công, đóng gói thùng hoàn thành, vui lòng quét thùng tiếp theo")
                    ' Begin Mr Luu Add Warning audio 20190614
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_CartonWarning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(2)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190614
                    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(0).Cells(0).Selected = True
                    If DataGridView1.Rows.Count > 30 Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                    End If
                    ControlCartonState("0")
                    DoCount = 0
                    LabCompleteQtyI.Text = DoCount.ToString
                    curindex = 0
                    LayerIndex = 0
                    'Mr Luu Add 2018-10-03
                    If (ScanOption.Partid = "L1LUC008-CS-H" Or ScanOption.Partid = "L1LUC010-CS-H" Or ScanOption.Partid = "L1LUC011-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H" Or ScanOption.Partid = "L1LUC014-CS-H-VN" Or ScanOption.Partid = "L1LUC015-CS-H" Or ScanOption.Partid = "L1LUC008-CS-H-LQ" Or ScanOption.Partid = "L1LUC008-CS-H-HQ" Or ScanOption.Partid = "L1LUC008-CS-H-US" Or ScanOption.Partid = "L1LUC008-CS-H-WT" Or ScanOption.Partid = "L1LUC008-CS-H-VN") And VbCommClass.VbCommClass.Factory = "02J0" Then
                        txtPE1.BackColor = Color.Red
                    End If
                    'End Mr Luu Add 2018-10-03
                    'LabInfo4.BackColor = Color.Green
                    'AutGenCartonID(ppid)
                    If Not ScanOption.IsScanCustProAndQtyI Then
                        AutoScanCartonFun()
                    End If
            End Select
        End If
    End Sub
    ' End Mr Luu Add ScanPpidRework 2020-01-08

    '条码扫描
    Private Sub txtPpid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPpid.KeyPress
        If (e.KeyChar = Chr(13)) AndAlso (Not Me.txtPpid.ReadOnly) Then
            If txtCarton.Text.Trim = "" Then
                Exit Sub
            End If
            'Mr Luu Begin : Scan Product for Dell Customer 20190922
            'Dim Str_PartID As String = ""
            'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format(" Select PartID From m_Mainmo_t Where Moid='{0}' ", LabMoID.Text))
            'If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
            '    Str_PartID = dtTemp.Rows(0)("PartID").ToString()
            'End If
            'If (VbCommClass.VbCommClass.Factory = "02J0" And Str_PartID = "L56H1002-CS-H-WW") Then
            '    ScanProductDell()
            '    Exit Sub
            'End If
            'Mr Luu End : Scan Product for Dell Customer

            'Mr Luu Begin : Scan Product for Dell Customer 2019-12-13
            Dim Str_PartID As String = ""
            Dim str_IsCheckPCode As String = ""
            Dim str_Pcode As String = ""
            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format(" Select P.LPartID as PartID,P.IsCheckPCode as IsCheckPCode, P.PCode as Pcode From m_Mainmo_t  M , m_PartScanStyleInof_t P Where M.PartID = P.LPartID AND M.Moid='{0}' ", LabMoID.Text))
            If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
                Str_PartID = dtTemp.Rows(0)("PartID").ToString()
                str_IsCheckPCode = dtTemp.Rows(0)("IsCheckPCode").ToString()
                str_Pcode = dtTemp.Rows(0)("Pcode").ToString()
            End If
            If (VbCommClass.VbCommClass.Factory = "02J0" And str_IsCheckPCode = "Y") Then
                ScanProductDell(str_Pcode)
                Exit Sub
            End If
            'Mr Luu End : Scan Product for Dell Customer 2019-12-13

            'Begin Mr Luu Add Scan Rework 2020-01-08'
            If VbCommClass.VbCommClass.Factory = "02J0" Then
                If chk_MoRework.CheckState = CheckState.Checked Then

                    Dim Sql_CheckPpid As String = String.Format(" Select top 1 ppid from m_Cartonsn_t where ppid='{0}' ", Me.txtPpid.Text.Trim)
                    Dim dtCartonsn As DataTable = DbOperateUtils.GetDataTable(Sql_CheckPpid)
                    If dtCartonsn.Rows.Count > 0 Then
                        ScanPpidRework()
                    Else
                        MessageBox.Show(" The Ppid " & txtPpid.Text.Trim & " is not exist in system . It can not rework scanning !!!")
                    End If
                    Exit Sub
                End If
            End If
            'End Mr Luu Add Scan Rework 2020-01-08'

            ScanPpid()
        End If
    End Sub

    ''自动生成外箱
    ''add by song
    ''2017-09-02
    'Private Sub AutGenCartonID(ByVal Ppid As String)
    '    If (Ppid = "CH39-01922A") Then
    '        txtCarton.Text = Trim(ScanOption.SelCartonStyle)
    '        ScanCarton()
    '    ElseIf (Ppid = "GH39-01949A") Then
    '        txtCarton.Text = GetStyle("L1WUC005-CS-H****V350DXY0")
    '        ScanCarton()
    '    Else
    '        txtCarton.Text = Trim(ScanOption.SelCartonStyle)
    '        ScanCarton()
    '    End If
    'End Sub

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String, Optional ByVal BarcodeType As String = "条码") As Boolean
        '扫描条码样式不能为空
        If txtStyle.Text.Trim.Length = 0 Then
            SetMessage("Fail", "扫描的 Kiểu mã quét: " + BarcodeType + "样式不能为空quy cách không được để trống！")
            Return False
        Else
            If BarCode.Trim.Length <> txtStyle.Text.Length Then
                SetMessage("Fail", "扫描的 Kiểu mã quét " + BarcodeType + "长度不符合標準樣式长度 Độ dài không phù hợp với quy cách tiêu chuẩn độ dài ")
                Return False
            End If
            If TextHandle.verfyBarCodeStyle(txtStyle.Text, BarCode, txtStyle.Text) = False Then
                SetMessage("FAIL", "扫描的 Kiểu mã quét " + BarcodeType + "不符合標準樣式 không phù hợp  quy cách tiêu chuẩn ")
                Return False
            End If
        End If
        Return True
    End Function

    '确认是否为系统打印条码
    Private Function CheckIsSystemPrint(ByVal StrBarCode As String) As Boolean
        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format("SELECT SBarCode FROM dbo.m_SnSBarCode_t WHERE SBarCode='{0}'", StrBarCode))
        If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    '应装数量变化
    Private Sub Label6_TextChanged(sender As Object, e As EventArgs) Handles LabCompleteQtyI.TextChanged
        LabCompleteQtyIShow.Text = LabCompleteQtyI.Text
        LabNeedQtyIShow.Text = LabNeedQtyI.Text
    End Sub

    '已装数量变化
    Private Sub Label5_TextChanged(sender As Object, e As EventArgs) Handles LabNeedQtyI.TextChanged
        LabCompleteQtyIShow.Text = LabCompleteQtyI.Text
        LabNeedQtyIShow.Text = LabNeedQtyI.Text
    End Sub

    '生成L1WUC005-CS-H日期编码
    'add by song
    '2017-09-02
    'Private Function GetStyle(ByVal s As String) As String
    '    Dim str As String = ""
    '    Dim style As String = ""

    '    If (Date.Today.Year.ToString = "2015") Then
    '        style += "G"
    '    ElseIf (Date.Today.Year.ToString = "2016") Then
    '        style += "H"
    '    ElseIf (Date.Today.Year.ToString = "2017") Then
    '        style += "J"
    '    ElseIf (Date.Today.Year.ToString = "2018") Then
    '        style += "K"
    '    ElseIf (Date.Today.Year.ToString = "2019") Then
    '        style += "M"
    '    ElseIf (Date.Today.Year.ToString = "2020") Then
    '        style += "N"
    '    End If

    '    If (Date.Today.Month.ToString = "10") Then
    '        style += "A"
    '    ElseIf (Date.Today.Month.ToString = "11") Then
    '        style += "B"
    '    ElseIf (Date.Today.Month.ToString = "12") Then
    '        style += "C"
    '    Else
    '        style += Date.Today.Month.ToString
    '    End If

    '    If (Date.Today.Day.ToString.Length = 1) Then
    '        style += "0" + Date.Today.Day.ToString
    '    Else
    '        style += Date.Today.Day.ToString
    '    End If

    '    If (s = "L1WUC005-CS-H****V350DXY0") Then
    '        str = s.Replace("****", style)
    '    End If
    '    Return str
    'End Function

    '退出
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '料件包装扫描参数设置 Add By KyLinQiu20170925
    Private Sub ToolPartSet_Click(sender As Object, e As EventArgs) Handles ToolPartSet.Click
        Dim frm As New FrmPackingPartSet
        frm.ShowDialog()
    End Sub

    '华为客户料号条码或装箱数量条码 Add By KyLinQiu20171010
    Private Sub TxtBHWCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBHWCode.KeyPress
        If (e.KeyChar = Chr(13)) AndAlso (Not Me.TxtBHWCode.ReadOnly) Then
            If Me.TxtBHWCode.Text.Trim = "" Then
                Exit Sub
            End If
            ScanCustPartOrQtyI()
        End If
    End Sub

    '扫描客户料号或装箱数量
    Private Sub ScanCustPartOrQtyI()
        '扫描客户料号条码
        If CheckHwIndex = 0 Then
            If CheckStyle(Me.TxtBHWCode.Text.Trim, "客户料号条码") = False Then
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = Me.TxtBHWCode.Text.Trim
                FrmError.MyErrorStr = "客户料号条码样式不匹配 QUy cách mã liệu khách hàng không tương tích "
                FrmError.MyCobError = "请检查客户料号条码样式 Kiểm tra quy cách mã liệu khách hàng！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", Me.TxtBHWCode.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "客户料号条码样式不匹配", SysMessageClass.UseId, "请检查客户料号条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                FrmError.ShowDialog()
                Me.TxtBHWCode.Text = ""
                Me.TxtBHWCode.Focus()
                Exit Sub
            End If
            CheckHwIndex = CheckHwIndex + 1
            Me.txtStyle.Text = ScanOption.CartonQtyIStyle
            TempHwCustPartID = Me.TxtBHWCode.Text.Trim
            Me.LabHWDesc.Text = "装箱数量条码:"
            Me.lblMessage.Text = "请继续扫描装箱数量条码 Tiếp tục quét mã số lượng thùng đóng gói"
            Me.lblResult.Text = "条码 Mã tem" + Me.TxtBHWCode.Text.Trim + "已扫描通过 đã được quét"
            Me.lblResult.ForeColor = Color.DarkGreen
            Me.lblMessage.ForeColor = Color.Gold
            Me.TxtBHWCode.Text = ""
            Me.TxtBHWCode.Focus()
        Else '扫描装箱数量条码
            If CheckStyle(Me.TxtBHWCode.Text.Trim, "装箱数量条码") = False Then
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = Me.TxtBHWCode.Text.Trim
                FrmError.MyErrorStr = "装箱数量条码样式不匹配 Quy cách số lượng mã đóng gói không phù hợp"
                FrmError.MyCobError = "请检查装箱数量条码样式 vui lòng kiểm tra quy cách số lượng mã đóng gói ！"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", Me.TxtBHWCode.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "装箱数量条码样式不匹配", SysMessageClass.UseId, "请检查装箱数量条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                FrmError.ShowDialog()
                Me.TxtBHWCode.Text = ""
                Me.TxtBHWCode.Focus()
                Exit Sub
            End If
            CheckHwIndex = 0
            SetMessage("PASS", "客户料号条码及装箱数量条码扫描成功 Quét thành công Mã liệu khách hàng và mã số lượng đóng gói！")
            Me.LabHWDesc.Text = "客户料号条码"
            Me.txtStyle.Text = ScanOption.SelCartonStyle
            Me.TxtBHWCode.Text = TempHwCustPartID
            Me.TxtBHWCode.Enabled = False
            Me.TxtBHWCode.ReadOnly = True
            Me.txtCarton.Enabled = True
            Me.txtCarton.ReadOnly = False
            Me.txtSecond.Enabled = False
            Me.txtSecond.ReadOnly = True
            Me.txtPpid.Enabled = False
            Me.txtPpid.ReadOnly = True
            Me.txtCarton.Focus()
            AutoScanCartonFun()
        End If
    End Sub

    Private Sub SetXMLNodeData(ByVal XmlNodeName As String, ByVal XmlNodeValue As String)
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        If File.Exists(FilePath) Then
            Dim IsExistsNode As Boolean = False
            lXmlDocument.Load(FilePath)
            Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
            Dim xn As XmlNode
            For Each xn In lXmlNodeList
                If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                    xn.InnerText = XmlNodeValue
                    IsExistsNode = True
                    Continue For
                End If
            Next
            If Not IsExistsNode Then
                Dim lChildXmlElement As XmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlDocument.SelectSingleNode("Info").AppendChild(lChildXmlElement)
            End If
            lXmlDocument.Save(FilePath)
        Else
            Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
            Dim lChildXmlElement As XmlElement = Nothing
            lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
            lChildXmlElement.InnerText = XmlNodeValue
            lXmlNode.AppendChild(lChildXmlElement)
            lXmlDocument.AppendChild(lXmlNode)
            lXmlDocument.Save(FilePath)
        End If
    End Sub


    Private Function GetXMLNodeData(ByVal XmlNodeName As String) As String
        Dim XmlNodeValue As String = ""
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        Try
            If File.Exists(FilePath) Then
                lXmlDocument.Load(FilePath)
                Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
                Dim xn As XmlNode
                For Each xn In lXmlNodeList
                    If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                        XmlNodeValue = xn.InnerText
                    End If
                Next
            Else
                Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
                Dim lChildXmlElement As XmlElement = Nothing
                lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlNode.AppendChild(lChildXmlElement)
                lXmlDocument.AppendChild(lXmlNode)
                lXmlDocument.Save(FilePath)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return XmlNodeValue
    End Function


    'Mr Luu Add 2018-10-03
    Private Sub GenerateTable_LG_VN(ByVal columnCount As Integer, ByVal rowCount As Integer)
        tableLayoutPanel1.Controls.Clear()
        tableLayoutPanel1.ColumnStyles.Clear()
        tableLayoutPanel1.RowStyles.Clear()
        tableLayoutPanel1.ColumnCount = columnCount
        tableLayoutPanel1.RowCount = rowCount
        For x As Integer = 0 To rowCount - 1
            tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            For y As Integer = 0 To columnCount - 1
                If x = 0 Then
                    tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                End If
                Dim btn As Button = New Button()
                btn.Dock = DockStyle.Fill
                btn.Margin = New Padding(0)
                btn.ForeColor = Color.White
                btn.Font = New Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold)
                btn.Height = 80
                btn.BackColor = Color.Gray
                btn.FlatStyle = FlatStyle.Flat
                tableLayoutPanel1.Controls.Add(btn, y, x)
            Next
        Next
    End Sub

    Private Sub Load_Tablelayout_LG(ByVal currentIndex As Integer)
        If currentIndex = 0 Then
            Dim k1 As Integer = 0
            Dim rowa As Integer = 0
            Dim index1 As Integer = 0
            For rowa = 0 To 3
                If (rowa) Mod 2 = 0 Then
                    For k1 = 1 To 13
                        index1 = index1 + 1
                        tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).Text = Convert.ToString(index1)
                    Next
                End If
                If (rowa) Mod 2 = 1 Then

                    For k1 = 1 To 12
                        index1 = index1 + 1
                        tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).Text = Convert.ToString(index1)
                    Next
                End If
            Next
        Else
            Dim k1 As Integer = 0
            Dim rowa As Integer = 0
            Dim index1 As Integer = 0
            If currentIndex >= 1 AndAlso currentIndex <= 50 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 1"
            End If
            If currentIndex > 50 AndAlso currentIndex <= 100 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 2"
                currentIndex = currentIndex - 50
            End If
            If currentIndex > 100 AndAlso currentIndex <= 150 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 3"
                currentIndex = currentIndex - 100
            End If
            If currentIndex > 150 AndAlso currentIndex <= 200 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 4"
                currentIndex = currentIndex - 150
            End If
            If currentIndex > 200 AndAlso currentIndex <= 250 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 5"
                currentIndex = currentIndex - 200
            End If
            If currentIndex > 250 AndAlso currentIndex <= 300 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 6"
                currentIndex = currentIndex - 250
            End If

            If currentIndex > 300 AndAlso currentIndex <= 350 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 7"
                currentIndex = currentIndex - 300
            End If
            If currentIndex > 350 AndAlso currentIndex <= 400 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 8"
                currentIndex = currentIndex - 350
            End If
            If currentIndex > 400 AndAlso currentIndex <= 450 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 9"
                currentIndex = currentIndex - 400
            End If
            If currentIndex > 450 AndAlso currentIndex <= 500 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 10"
                currentIndex = currentIndex - 450
            End If
            If currentIndex > 500 AndAlso currentIndex <= 550 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 11"
                currentIndex = currentIndex - 500
            End If
            If currentIndex > 550 AndAlso currentIndex <= 600 Then
                txtPE1.BackColor = Color.Green
                txtPE1.Text = "PE 12"
                currentIndex = currentIndex - 550
            End If

            For rowa = 0 To 3
                If (rowa) Mod 2 = 0 Then
                    For k1 = 1 To 13
                        index1 = index1 + 1
                        tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).Text = Convert.ToString(index1)
                        If tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).Text.Trim().ToUpper() = Convert.ToString(currentIndex).Trim().ToUpper() Then
                            tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).BackColor = Color.Green
                        End If
                    Next
                End If
                If (rowa) Mod 2 = 1 Then
                    For k1 = 1 To 12
                        index1 = index1 + 1
                        tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).Text = Convert.ToString(index1)
                        If tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).Text.Trim().ToUpper() = Convert.ToString(currentIndex).Trim().ToUpper() Then
                            tableLayoutPanel1.GetControlFromPosition(k1 - 1, rowa).BackColor = Color.Green
                        End If
                    Next
                End If
            Next

            Dim btn As Button = Nothing
            Dim m1 As Integer
            For m1 = 1 To currentIndex
                For Each ctrl As Control In tableLayoutPanel1.Controls
                    If TypeOf ctrl Is Button Then
                        btn = TryCast(ctrl, Button)
                        If btn.Text = m1.ToString() Then
                            btn.BackColor = Color.Green
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub GenerateTable_CurrentIndex_LG_VN(ByVal currentIndex As Integer)
        currentIndex = Convert.ToInt32(LabCompleteQtyI.Text)
        If index1 >= 1 AndAlso index1 <= 50 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 1"
        End If
        If index1 > 50 AndAlso index1 <= 100 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 2"
        End If
        If index1 > 100 AndAlso index1 <= 150 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 3"
        End If
        If index1 > 150 AndAlso index1 <= 200 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 4"
        End If
        If index1 > 200 AndAlso index1 <= 250 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 5"
        End If
        If index1 > 250 AndAlso index1 <= 300 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 6"
        End If

        If index1 > 300 AndAlso index1 <= 350 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 7"
        End If
        If index1 > 350 AndAlso index1 <= 400 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 8"
        End If
        If index1 > 400 AndAlso index1 <= 450 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 9"
        End If
        If index1 > 450 AndAlso index1 <= 500 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 10"
        End If
        If index1 > 500 AndAlso index1 <= 550 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 11"
        End If
        If index1 > 550 AndAlso index1 <= 600 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 12"
        End If

        For x As Integer = 0 To 3
            For y As Integer = 0 To 13
                tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green
                tableLayoutPanel1.GetControlFromPosition(y, x).Text = Convert.ToString(currentIndex)
                tableLayoutPanel1.GetControlFromPosition(y, x).ForeColor = Color.White
            Next
        Next
    End Sub

    Private m_CurrentIndext As Integer = 0
    Private Sub Scan_Barcode_LG_VN()
        m_CurrentIndext = DoCount
        If m_CurrentIndext >= 1 AndAlso m_CurrentIndext <= 50 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 1"
        End If
        If m_CurrentIndext > 50 AndAlso m_CurrentIndext <= 100 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 2"
            m_CurrentIndext = DoCount - 50
        End If
        If m_CurrentIndext > 100 AndAlso m_CurrentIndext <= 150 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 3"
            m_CurrentIndext = DoCount - 100
        End If
        If m_CurrentIndext > 150 AndAlso m_CurrentIndext <= 200 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 4"
            m_CurrentIndext = DoCount - 150
        End If
        If m_CurrentIndext > 200 AndAlso m_CurrentIndext <= 250 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 5"
            m_CurrentIndext = DoCount - 200
        End If
        If m_CurrentIndext > 250 AndAlso m_CurrentIndext <= 300 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 6"
            m_CurrentIndext = DoCount - 250
        End If

        If m_CurrentIndext > 300 AndAlso m_CurrentIndext <= 350 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 7"
            m_CurrentIndext = DoCount - 300
        End If
        If m_CurrentIndext > 350 AndAlso m_CurrentIndext <= 400 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 8"
            m_CurrentIndext = DoCount - 350
        End If
        If m_CurrentIndext > 400 AndAlso m_CurrentIndext <= 450 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 9"
            m_CurrentIndext = DoCount - 400
        End If
        If m_CurrentIndext > 450 AndAlso m_CurrentIndext <= 500 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 10"
            m_CurrentIndext = DoCount - 450
        End If
        If m_CurrentIndext > 500 AndAlso m_CurrentIndext <= 550 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 11"
            m_CurrentIndext = DoCount - 500
        End If
        If m_CurrentIndext > 550 AndAlso m_CurrentIndext <= 600 Then
            txtPE1.BackColor = Color.Green
            txtPE1.Text = "PE 12"
            m_CurrentIndext = DoCount - 550
        End If


        Dim btn As Button = Nothing
        For Each ctrl As Control In tableLayoutPanel1.Controls
            If TypeOf ctrl Is Button Then
                btn = TryCast(ctrl, Button)
                If btn.Text = m_CurrentIndext.ToString() Then
                    btn.BackColor = Color.Green
                    Exit For
                End If
            End If
        Next
        tableLayoutPanel1.SelectNextControl(btn, True, True, True, True)
        If m_CurrentIndext = 50 Then
            GenerateTable_LG_VN(13, 4)
            Load_Tablelayout_LG(0)
            k1 = 0
            row1 = 0
            index1 = 0
            m_CurrentIndext = 0
            txtPE1.BackColor = Color.Red
        End If
        txtPpid.Text = ""
        txtPpid.Focus()
    End Sub
    'End Mr Luu Add 2018-10-03
    'Begin Mr Luu Add 2019-06-13
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        Select Case PassOrNg
            Case 0  '
                My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
            Case 1
                My.Computer.Audio.Play(My.Resources.Resource1.ERR, AudioPlayMode.WaitToComplete)
            Case 2
                My.Computer.Audio.Play(My.Resources.Resource1.ERR, AudioPlayMode.Background)
            Case 3
                My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
        End Select
    End Sub
    'End Mr Luu Add 2019-06-13

    'Begin Mr Luu Add Scan Product for Dell Customer 20190917
    'Private Sub ScanProductDell()
    '    'txtStyle.Text = ScanOption.SelPpidStyle
    '    If CheckPPIDIndex = 0 Then
    '        If txtPpid.Text.Trim = "" Then
    '            Exit Sub
    '        End If

    '        Dim ppid As String = txtPpid.Text.Trim
    '        ' Mr Luu Check Print by MES system
    '        If ScanOption.IsSystemPrintPpID Then
    '            If CheckIsSystemPrint(ppid) = False Then
    '                ' Begin Mr Luu Add Warning audio 20190614
    '                If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                    If chk_Warning.CheckState = CheckState.Checked Then
    '                        PlaySimpleSound(1)
    '                    End If
    '                End If
    '                'End Mr Luu Add Warning audio 20190614
    '                Dim FrmError As New FrmScanErrPromptNew
    '                FrmError.MyBarCodeStr = ppid
    '                FrmError.MyErrorStr = "The Product Barcode is not print by MES system. It is not exist "
    '                FrmError.MyCobError = "Please check Style of the Product Barcode !"

    '                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该产品条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查产品条码样式！")
    '                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
    '                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
    '                'Begin Mr Luu Add QC unlock 20180810
    '                If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
    '                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
    '                    ConnectDB.ExecSql(strSQL_Insert)
    '                End If
    '                'End Mr Luu Add QC unlock 20180810
    '                FrmError.ShowDialog()
    '                txtPpid.Text = ""
    '                txtPpid.Focus()
    '                Exit Sub
    '            End If
    '        End If

    '        'Mr Luu Check Style ppid
    '        If CheckStyle(ppid, "产品条码") = False Then
    '            ' Begin Mr Luu Add Warning audio 20190614
    '            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                If chk_Warning.CheckState = CheckState.Checked Then
    '                    PlaySimpleSound(1)
    '                End If
    '            End If
    '            'End Mr Luu Add Warning audio 20190614
    '            Dim FrmError As New FrmScanErrPromptNew
    '            FrmError.MyBarCodeStr = ppid
    '            FrmError.MyErrorStr = "Mã vạch không đúng / 条码不对"
    '            FrmError.MyCobError = "Please check Style of the Product Barcode !"

    '            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
    '            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
    '            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
    '            'Begin Mr Luu Add QC unlock 20180529
    '            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
    '                Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
    '                ConnectDB.ExecSql(strSQL_Insert)
    '            End If
    '            'End Mr Luu Add QC unlock 20180529
    '            FrmError.ShowDialog()
    '            txtPpid.Text = ""
    '            txtPpid.Focus()
    '            Exit Sub
    '        End If

    '        'Mr Luu Check repeat ppid
    '        If CheckPackingPPID(ppid) = True Then
    '            ' Begin Mr Luu Add Warning audio 20190614
    '            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                If chk_Warning.CheckState = CheckState.Checked Then
    '                    PlaySimpleSound(1)
    '                End If
    '            End If
    '            'End Mr Luu Add Warning audio 20190614
    '            Dim FrmError As New FrmScanErrPromptNew
    '            FrmError.MyBarCodeStr = ppid
    '            FrmError.MyErrorStr = " Mã vạch " & ppid & "  đã tồn tại trong hệ thống. / 在系统已存在 " & ppid & " 条码 . "
    '            FrmError.MyCobError = "Please check the Product Barcode !"

    '            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该产品条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查产品条码样式！")
    '            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
    '            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
    '            'Begin Mr Luu Add QC unlock 20180810
    '            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
    '                Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
    '                ConnectDB.ExecSql(strSQL_Insert)
    '            End If
    '            'End Mr Luu Add QC unlock 20180810
    '            FrmError.ShowDialog()
    '            txtPpid.Text = ""
    '            txtPpid.Focus()
    '            Exit Sub
    '        End If

    '        ScanOption.ProductPPID = txtPpid.Text
    '        CheckPPIDIndex = 1
    '        txtPpid.Text = ""
    '        txtPpid.Focus()

    '    ElseIf CheckPPIDIndex = 1 Then
    '        Dim ppid As String = txtPpid.Text.Trim

    '        If txtPpid.Text = ScanOption.ProductPPID Then
    '            CheckPPIDIndex = 2
    '            txtStyle.Text = "DAUBNBC084"
    '            txtPpid.Text = ""
    '            txtPpid.Focus()
    '        Else
    '            ' Begin Mr Luu Add Warning audio 20190614
    '            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                If chk_Warning.CheckState = CheckState.Checked Then
    '                    PlaySimpleSound(1)
    '                End If
    '            End If
    '            'End Mr Luu Add Warning audio 20190614
    '            Dim FrmError As New FrmScanErrPromptNew
    '            FrmError.MyBarCodeStr = ppid
    '            FrmError.MyErrorStr = "Mã vạch sản phẩm không giống với mã túi PE. / 产品条码与PE袋条码不一样 ."
    '            FrmError.MyCobError = "Please check Style of the Product Barcode or PE Barcode !"

    '            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
    '            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
    '            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
    '            'Begin Mr Luu Add QC unlock 20180529
    '            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
    '                Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
    '                ConnectDB.ExecSql(strSQL_Insert)
    '            End If
    '            'End Mr Luu Add QC unlock 20180529
    '            FrmError.ShowDialog()
    '            txtPpid.Text = ""
    '            txtPpid.Focus()
    '            Exit Sub
    '        End If
    '    Else
    '        If CheckPPIDIndex = 2 Then
    '            Dim peid As String = txtPpid.Text.Trim

    '            If txtPpid.Text = "DAUBNBC084" Then

    '                Dim ppid As String = ScanOption.ProductPPID
    '                Dim MO_ID As String = Trim(ScanOption.SelMOID)
    '                Dim TEAM_ID As String = Trim(ScanOption.SelLineID)
    '                Dim SPOINT As String = Environment.MachineName
    '                Dim USER_ID As String = SysMessageClass.UseId
    '                Dim STATION_ID As String = "P0001"
    '                Dim STAORDER_ID As String = "1"
    '                Dim SCANORDER_ID As String = "1"
    '                Dim CARTON_ID As String = ""
    '                CARTON_ID = txtCarton.Text.Trim
    '                Dim FACT_QUANTITY As String = ScanOption.SelSecondQty
    '                Dim IsFixedCode As String = "N"
    '                If ScanOption.PPid_N Then
    '                    IsFixedCode = "Y"
    '                End If
    '                Dim Sqlstr As String = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_ByNewScan] " & _
    '       "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "', " & _
    '       "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "

    '                Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
    '                If dt.Rows.Count > 0 Then
    '                    Select Case dt.Rows(0)(0).ToString()
    '                        Case "1" To "3"
    '                            Dim ErrorStr As String = dt.Rows(0)(1).ToString()
    '                            SetMessage("FAIL", ErrorStr)

    '                            Dim FrmError As New FrmScanErrPromptNew
    '                            FrmError.MyBarCodeStr = txtPpid.Text.Trim
    '                            FrmError.MyErrorStr = ErrorStr
    '                            FrmError.MyCobError = "请检查相关错误信息！"

    '                            Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtPpid.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查相关错误信息！")
    '                            Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
    '                            FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
    '                            'Begin Mr Luu Add QC unlock 20180810
    '                            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                                Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
    '                                Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
    '                                ConnectDB.ExecSql(strSQL_Insert)
    '                            End If
    '                            'End Mr Luu Add QC unlock 20180810
    '                            FrmError.ShowDialog()
    '                            CheckPPIDIndex = 0
    '                            Me.txtPpid.Clear()
    '                            Me.txtPpid.Focus()
    '                            Exit Sub
    '                        Case 6
    '                            SetMessage("PASS", "产品条码" + Trim(ppid) + "扫描成功！")
    '                            ' Begin Mr Luu Add Warning audio 20190614
    '                            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                                If chk_Warning.CheckState = CheckState.Checked Then
    '                                    PlaySimpleSound(0)
    '                                End If
    '                            End If
    '                            'End Mr Luu Add Warning audio 20190614
    '                            Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
    '                            DataGridView1.ClearSelection()
    '                            DataGridView1.Rows(0).Cells(0).Selected = True
    '                            If DataGridView1.Rows.Count > 30 Then
    '                                DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
    '                            End If
    '                            DoCount = DoCount + ScanOption.SelPpidQty
    '                            LabCompleteQtyI.Text = DoCount.ToString
    '                            CheckPPIDIndex = 0
    '                            txtStyle.Text = ScanOption.SelPpidStyle
    '                            txtPpid.Text = ""
    '                            txtPpid.Focus()


    '                        Case 8 '最外层大外箱装箱完成
    '                            SetMessage("PASS", "产品条码" + Trim(ppid) + "扫描成功！装箱完毕，请扫描下一个外箱条码")
    '                            ' Begin Mr Luu Add Warning audio 20190614
    '                            If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                                If chk_CartonWarning.CheckState = CheckState.Checked Then
    '                                    PlaySimpleSound(2)
    '                                End If
    '                            End If
    '                            'End Mr Luu Add Warning audio 20190614
    '                            Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
    '                            DataGridView1.ClearSelection()
    '                            DataGridView1.Rows(0).Cells(0).Selected = True
    '                            If DataGridView1.Rows.Count > 30 Then
    '                                DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
    '                            End If

    '                            txtStyle.Text = ScanOption.SelCartonStyle
    '                            If ScanOption.CartonAutoGen = True Then
    '                                AutoScanCartonFun()
    '                            End If
    '                            CheckPPIDIndex = 0
    '                            'txtStyle.Text = ScanOption.SelPpidStyle
    '                            txtPpid.Text = ""
    '                            txtPpid.Focus()
    '                            DoCount = 0
    '                            LabCompleteQtyI.Text = DoCount.ToString
    '                            curindex = 0
    '                            LayerIndex = 0

    '                    End Select
    '                End If

    '            Else

    '                ' Begin Mr Luu Add Warning audio 20190614
    '                If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                    If chk_Warning.CheckState = CheckState.Checked Then
    '                        PlaySimpleSound(1)
    '                    End If
    '                End If
    '                'End Mr Luu Add Warning audio 20190614
    '                Dim FrmError As New FrmScanErrPromptNew
    '                FrmError.MyBarCodeStr = peid
    '                FrmError.MyErrorStr = "Mã vạch không đúng. / 条码不对 . "
    '                FrmError.MyCobError = "Please check Style of PE Barcode !"

    '                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", peid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
    '                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
    '                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
    '                'Begin Mr Luu Add QC unlock 20180529
    '                If VbCommClass.VbCommClass.Factory = "02J0" Then
    '                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
    '                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", peid, SysMessageClass.UseId)
    '                    ConnectDB.ExecSql(strSQL_Insert)
    '                End If
    '                'End Mr Luu Add QC unlock 20180529
    '                FrmError.ShowDialog()
    '                CheckPPIDIndex = 2
    '                txtStyle.Text = "DAUBNBC084"
    '                txtPpid.Text = ""
    '                txtPpid.Focus()
    '                Exit Sub
    '            End If

    '        End If
    '    End If


    'End Sub

    'Private Function CheckPackingPPID(ByVal PPID As String) As Boolean
    '    Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format("Select top 1 ppid From m_Cartonsn_t Where ppid='{0}'", PPID))
    '    If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'End Mr Luu Add Scan Product for Dell Customer 20190917



    'Begin Mr Luu Add Scan Product for Dell Customer 2019-12-13
    Private Sub ScanProductDell(ByVal str_PCode As String)
        'txtStyle.Text = ScanOption.SelPpidStyle
        If CheckPPIDIndex = 0 Then
            If txtPpid.Text.Trim = "" Then
                Exit Sub
            End If

            Dim ppid As String = txtPpid.Text.Trim
            ' Mr Luu Check Print by MES system
            If ScanOption.IsSystemPrintPpID Then
                If CheckIsSystemPrint(ppid) = False Then
                    ' Begin Mr Luu Add Warning audio 20190614
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_Warning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(1)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190614
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = ppid
                    FrmError.MyErrorStr = "The Product Barcode is not print by MES system. It is not exist "
                    FrmError.MyCobError = "Please check Style of the Product Barcode !"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该产品条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查产品条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                    'Begin Mr Luu Add QC unlock 20180810
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                        Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                        ConnectDB.ExecSql(strSQL_Insert)
                    End If
                    'End Mr Luu Add QC unlock 20180810
                    FrmError.ShowDialog()
                    txtPpid.Text = ""
                    txtPpid.Focus()
                    Exit Sub
                End If
            End If

            'Mr Luu Check Style ppid
            If CheckStyle(ppid, "产品条码") = False Then
                ' Begin Mr Luu Add Warning audio 20190614
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190614
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = ppid
                FrmError.MyErrorStr = "Mã vạch không đúng / 条码不对"
                FrmError.MyCobError = "Please check Style of the Product Barcode !"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                'Begin Mr Luu Add QC unlock 20180529
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                    ConnectDB.ExecSql(strSQL_Insert)
                End If
                'End Mr Luu Add QC unlock 20180529
                FrmError.ShowDialog()
                txtPpid.Text = ""
                txtPpid.Focus()
                Exit Sub
            End If

            'Mr Luu Check repeat ppid
            If CheckPackingPPID(ppid) = True Then
                ' Begin Mr Luu Add Warning audio 20190614
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190614
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = ppid
                FrmError.MyErrorStr = " Mã vạch " & ppid & "  đã tồn tại trong hệ thống. / 在系统已存在 " & ppid & " 条码 . "
                FrmError.MyCobError = "Please check the Product Barcode Vui lòng kiểm tra lại mã sản phẩm  !"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "该产品条码不是由系统打印，打印记录表中不存在！", SysMessageClass.UseId, "请检查产品条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                'Begin Mr Luu Add QC unlock 20180810
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                    ConnectDB.ExecSql(strSQL_Insert)
                End If
                'End Mr Luu Add QC unlock 20180810
                FrmError.ShowDialog()
                txtPpid.Text = ""
                txtPpid.Focus()
                Exit Sub
            End If

            ScanOption.ProductPPID = txtPpid.Text
            CheckPPIDIndex = 1
            txtPpid.Text = ""
            txtPpid.Focus()

        ElseIf CheckPPIDIndex = 1 Then
            Dim ppid As String = txtPpid.Text.Trim

            If txtPpid.Text = ScanOption.ProductPPID Then
                CheckPPIDIndex = 2
                'txtStyle.Text = "DAUBNBC084"
                txtStyle.Text = str_PCode
                txtPpid.Text = ""
                txtPpid.Focus()
            Else
                ' Begin Mr Luu Add Warning audio 20190614
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    If chk_Warning.CheckState = CheckState.Checked Then
                        PlaySimpleSound(1)
                    End If
                End If
                'End Mr Luu Add Warning audio 20190614
                Dim FrmError As New FrmScanErrPromptNew
                FrmError.MyBarCodeStr = ppid
                FrmError.MyErrorStr = "Mã vạch sản phẩm không giống với mã túi PE. / 产品条码与PE袋条码不一样 ."
                FrmError.MyCobError = "Please check Style of the Product Barcode or PE Barcode !"

                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", ppid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                'Begin Mr Luu Add QC unlock 20180529
                If VbCommClass.VbCommClass.Factory = "02J0" Then
                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                    ConnectDB.ExecSql(strSQL_Insert)
                End If
                'End Mr Luu Add QC unlock 20180529
                FrmError.ShowDialog()
                txtPpid.Text = ""
                txtPpid.Focus()
                Exit Sub
            End If
        Else
            If CheckPPIDIndex = 2 Then
                Dim peid As String = txtPpid.Text.Trim

                'If txtPpid.Text = "DAUBNBC084" Then
                If txtPpid.Text = str_PCode Then
                    Dim ppid As String = ScanOption.ProductPPID
                    Dim MO_ID As String = Trim(ScanOption.SelMOID)
                    Dim TEAM_ID As String = Trim(ScanOption.SelLineID)
                    Dim SPOINT As String = Environment.MachineName
                    Dim USER_ID As String = SysMessageClass.UseId
                    Dim STATION_ID As String = "P0001"
                    Dim STAORDER_ID As String = "1"
                    Dim SCANORDER_ID As String = "1"
                    Dim CARTON_ID As String = ""
                    CARTON_ID = txtCarton.Text.Trim
                    Dim FACT_QUANTITY As String = ScanOption.SelSecondQty
                    Dim IsFixedCode As String = "N"
                    If ScanOption.PPid_N Then
                        IsFixedCode = "Y"
                    End If
                    Dim Sqlstr As String = "declare @RTVALUE varchar(1),@RTMSG varchar(150),@RTCURR_QUANTITY int,@RTCURR_PQUANTITY int,@OUT_PQUANTITY int execute [m_NV_NewPpidScan_P_ByNewScan] " & _
           "'" & ppid & "', '" & MO_ID & "','" & TEAM_ID & "','" & SPOINT & "','" & USER_ID & "','" & STATION_ID & "','" & STAORDER_ID & "','" & SCANORDER_ID & "','" & CARTON_ID & "','" & FACT_QUANTITY & "', " & _
           "@RTVALUE output,@RTMSG output,@RTCURR_QUANTITY output,@RTCURR_PQUANTITY output,@OUT_PQUANTITY output," & ScanOption.SelPpidQty & ",'" & IsFixedCode & "'  select @RTVALUE ,isnull(@RTMSG,'') ,@RTCURR_QUANTITY,@RTCURR_PQUANTITY,@OUT_PQUANTITY "

                    Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                    If dt.Rows.Count > 0 Then
                        Select Case dt.Rows(0)(0).ToString()
                            Case "1" To "3"
                                Dim ErrorStr As String = dt.Rows(0)(1).ToString()
                                SetMessage("FAIL", ErrorStr)

                                Dim FrmError As New FrmScanErrPromptNew
                                FrmError.MyBarCodeStr = txtPpid.Text.Trim
                                FrmError.MyErrorStr = ErrorStr
                                FrmError.MyCobError = "请检查相关错误信息 VUi lòng kiểm tra thông tin lỗi！"

                                Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}');SELECT @@IDENTITY AS Id", txtPpid.Text.Trim, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, ErrorStr, SysMessageClass.UseId, "请检查相关错误信息！")
                                Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                                FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                                'Begin Mr Luu Add QC unlock 20180810
                                If VbCommClass.VbCommClass.Factory = "02J0" Then
                                    Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                                    Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", ppid, SysMessageClass.UseId)
                                    ConnectDB.ExecSql(strSQL_Insert)
                                End If
                                'End Mr Luu Add QC unlock 20180810
                                FrmError.ShowDialog()
                                CheckPPIDIndex = 0
                                Me.txtPpid.Clear()
                                Me.txtPpid.Focus()
                                Exit Sub
                            Case 6
                                SetMessage("PASS", "产品条码  mã sản phẩm  " + Trim(ppid) + "扫描成功 quét thành công！")
                                ' Begin Mr Luu Add Warning audio 20190614
                                If VbCommClass.VbCommClass.Factory = "02J0" Then
                                    If chk_Warning.CheckState = CheckState.Checked Then
                                        PlaySimpleSound(0)
                                    End If
                                End If
                                'End Mr Luu Add Warning audio 20190614
                                Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                                DataGridView1.ClearSelection()
                                DataGridView1.Rows(0).Cells(0).Selected = True
                                If DataGridView1.Rows.Count > 30 Then
                                    DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                                End If
                                DoCount = DoCount + ScanOption.SelPpidQty
                                LabCompleteQtyI.Text = DoCount.ToString
                                CheckPPIDIndex = 0
                                txtStyle.Text = ScanOption.SelPpidStyle
                                txtPpid.Text = ""
                                txtPpid.Focus()


                            Case 8 '最外层大外箱装箱完成
                                SetMessage("PASS", "产品条码  mã sản phẩm " + Trim(ppid) + "扫描成功！装箱完毕，请扫描下一个外箱条码 quét thành công, đóng gói hoàn thành vui lòng quét mã thùng sau")
                                ' Begin Mr Luu Add Warning audio 20190614
                                If VbCommClass.VbCommClass.Factory = "02J0" Then
                                    If chk_CartonWarning.CheckState = CheckState.Checked Then
                                        PlaySimpleSound(2)
                                    End If
                                End If
                                'End Mr Luu Add Warning audio 20190614
                                Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                                DataGridView1.ClearSelection()
                                DataGridView1.Rows(0).Cells(0).Selected = True
                                If DataGridView1.Rows.Count > 30 Then
                                    DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                                End If

                                txtStyle.Text = ScanOption.SelCartonStyle
                                If ScanOption.CartonAutoGen = True Then
                                    AutoScanCartonFun()
                                End If
                                CheckPPIDIndex = 0
                                'txtStyle.Text = ScanOption.SelPpidStyle
                                txtPpid.Text = ""
                                txtPpid.Focus()
                                DoCount = 0
                                LabCompleteQtyI.Text = DoCount.ToString
                                curindex = 0
                                LayerIndex = 0

                        End Select
                    End If

                Else

                    ' Begin Mr Luu Add Warning audio 20190614
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        If chk_Warning.CheckState = CheckState.Checked Then
                            PlaySimpleSound(1)
                        End If
                    End If
                    'End Mr Luu Add Warning audio 20190614
                    Dim FrmError As New FrmScanErrPromptNew
                    FrmError.MyBarCodeStr = peid
                    FrmError.MyErrorStr = "Mã vạch không đúng. / 条码不对 . "
                    FrmError.MyCobError = "Please check Style of PE Barcode !"

                    Dim strSql As String = String.Format("Insert into m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}'); SELECT @@IDENTITY AS Id", peid, ScanOption.SelMOID, ScanOption.SelStationID, ScanOption.SelLineID, Environment.MachineName, "产品条码样式不匹配", SysMessageClass.UseId, "请检查产品条码样式！")
                    Dim dtAssysnEData As DataTable = DbOperateUtils.GetDataTable(strSql)
                    FrmError.MyAutoID = dtAssysnEData.Rows(0)("Id").ToString()
                    'Begin Mr Luu Add QC unlock 20180529
                    If VbCommClass.VbCommClass.Factory = "02J0" Then
                        Dim ConnectDB As New MainFrame.SysDataHandle.SysDataBaseClass
                        Dim strSQL_Insert As String = String.Format("Insert into m_Lock(Moid,Status_Lock,Ppid,Intime,Userid) values('{0}','{1}','{2}',getdate(),'{3}')", ScanOption.SelMOID, "Y", peid, SysMessageClass.UseId)
                        ConnectDB.ExecSql(strSQL_Insert)
                    End If
                    'End Mr Luu Add QC unlock 20180529
                    FrmError.ShowDialog()
                    CheckPPIDIndex = 2
                    'txtStyle.Text = "DAUBNBC084"
                    txtStyle.Text = str_PCode
                    txtPpid.Text = ""
                    txtPpid.Focus()
                    Exit Sub
                End If

            End If
        End If


    End Sub

    Private Function CheckPackingPPID(ByVal PPID As String) As Boolean
        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(String.Format("Select top 1 ppid From m_Cartonsn_t Where ppid='{0}'", PPID))
        If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'End Mr Luu Add Scan Product for Dell Customer 2019-12-13

    Private Sub ToolStripAnkerSetting_Click(sender As Object, e As EventArgs) Handles ToolStripAnkerSetting.Click
        Dim frm_AnkerSetting As New FrmAnkerSetting
        frm_AnkerSetting.ShowDialog()
    End Sub
End Class
