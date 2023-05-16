Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports MainFrame

Public Class FrmPackingPartSetOper
    '新增或修改标志
    Private Flag As Integer = 0
    Private StrLPartID As String = ""

    Public Sub New(ByVal _Flag As Integer, ByVal _StrLPartID As String)
        InitializeComponent()

        Flag = _Flag
        StrLPartID = _StrLPartID
    End Sub

    '加载数据
    Private Sub FrmPackingPartSetOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Flag = 0 Then
            Me.Text = "新增料件扫描参数"
            Me.BtnOK.Text = "确认新增"
            Me.TxtLPartID.Enabled = True
            Me.TxtLPartID.Focus()
        ElseIf Flag = 1 Then
            Me.Text = "修改料件扫描参数"
            Me.BtnOK.Text = "确认修改"
            Me.TxtLPartID.Enabled = False
            Me.TxtLPartID.Text = StrLPartID
            ShowEditInfo()
        End If
    End Sub

    '显示修改的信息
    Private Sub ShowEditInfo()
        LoadStyleData()

        Dim StrSql As String = String.Format(" SELECT IsAutoGenerateCarton,IsScanFixedCarton,IsSystemPrintCarton,IsScanCustProAndQtyI,CartonStylePackID,CartonStylePackItem,CartonQtyI,IsScanQRCode,QRCodeStylePackID,QRCodeStylePackItem,IsSystemPrintQRCode, " &
                                    " IsScanPECarton, PECartonStylePackID, PECartonStylePackItem, PECartonQtyI,IsSystemPrintPECarton, IsFixedCode, PpIDCodeStylePackID, PpIDCodeStylePackItem, PpIDQtyI,IsSystemPrintPpID " &
                                    " FROM dbo.m_PartScanStyleInof_t WHERE LPartID='{0}' ", StrLPartID)
        Dim dtLPartData As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If (dtLPartData Is Nothing) OrElse dtLPartData.Rows.Count <= 0 Then
            MessageBox.Show("料件扫描参数已被删除,请检查！")
            Exit Sub
        End If

        Dim IsAutoGenerateCarton As String = dtLPartData.Rows(0)("IsAutoGenerateCarton").ToString.Trim
        If IsAutoGenerateCarton.ToUpper = "Y" Then
            Me.ChkIsAutoGenerateCarton.Checked = True
        Else
            Me.ChkIsAutoGenerateCarton.Checked = False
        End If
        '增加是否扫描固定外箱 Add By KyLinQiu20180315
        Dim IsScanFixedCarton As String = dtLPartData.Rows(0)("IsScanFixedCarton").ToString.Trim
        If IsScanFixedCarton.ToUpper = "Y" Then
            Me.ChkIsScanFixedCarton.Checked = True
        Else
            Me.ChkIsScanFixedCarton.Checked = False
        End If

        Dim IsScanCustProAndQtyI As String = dtLPartData.Rows(0)("IsScanCustProAndQtyI").ToString.Trim
        If IsScanCustProAndQtyI.ToUpper = "Y" Then
            Me.ChkIsScanCustProAndQtyI.Checked = True
        Else
            Me.ChkIsScanCustProAndQtyI.Checked = False
        End If
        '是否系统打印条码AddByKyLinQiu20171016
        Dim IsSystemPrintCarton As String = dtLPartData.Rows(0)("IsSystemPrintCarton").ToString.Trim
        If IsSystemPrintCarton.ToUpper = "Y" Then
            Me.ChkIsSystemPrintCarton.Checked = True
        Else
            Me.ChkIsSystemPrintCarton.Checked = False
        End If
        Dim IsSystemPrintQRCode As String = dtLPartData.Rows(0)("IsSystemPrintQRCode").ToString.Trim
        If IsSystemPrintQRCode.ToUpper = "Y" Then
            Me.ChkIsSystemPrintQRCode.Checked = True
        Else
            Me.ChkIsSystemPrintQRCode.Checked = False
        End If
        Dim IsSystemPrintPECarton As String = dtLPartData.Rows(0)("IsSystemPrintPECarton").ToString.Trim
        If IsSystemPrintPECarton.ToUpper = "Y" Then
            Me.ChkIsSystemPrintPECarton.Checked = True
        Else
            Me.ChkIsSystemPrintPECarton.Checked = False
        End If
        Dim IsSystemPrintPpID As String = dtLPartData.Rows(0)("IsSystemPrintPpID").ToString.Trim
        If IsSystemPrintPpID.ToUpper = "Y" Then
            Me.ChkIsSystemPrintPpID.Checked = True
        Else
            Me.ChkIsSystemPrintPpID.Checked = False
        End If

        Me.CbbCartonStyle.Text = dtLPartData.Rows(0)("CartonStylePackID").ToString.Trim & "-" & dtLPartData.Rows(0)("CartonStylePackItem").ToString.Trim
        Me.TxtCartonQtyI.Text = dtLPartData.Rows(0)("CartonQtyI").ToString.Trim

        Dim IsScanQRCode As String = dtLPartData.Rows(0)("IsScanQRCode").ToString.Trim
        If IsScanQRCode.ToUpper = "Y" Then
            Me.ChkIsScanQRCode.Checked = True
            Me.CbbQRCodeStyle.Enabled = True
            Me.CbbQRCodeStyle.Text = dtLPartData.Rows(0)("QRCodeStylePackID").ToString.Trim & "-" & dtLPartData.Rows(0)("QRCodeStylePackItem").ToString.Trim
        Else
            Me.ChkIsScanQRCode.Checked = False
            Me.CbbQRCodeStyle.Enabled = False
        End If

        Dim IsScanPECarton As String = dtLPartData.Rows(0)("IsScanPECarton").ToString.Trim
        If IsScanPECarton.ToUpper = "Y" Then
            Me.ChkIsScanPECarton.Checked = True
            Me.CbbPECartonStyle.Enabled = True
            Me.CbbPECartonStyle.Text = dtLPartData.Rows(0)("PECartonStylePackID").ToString.Trim & "-" & dtLPartData.Rows(0)("PECartonStylePackItem").ToString.Trim
            Me.TxtPECartonQtyI.Text = dtLPartData.Rows(0)("PECartonQtyI").ToString.Trim
        Else
            Me.ChkIsScanPECarton.Checked = False
            Me.CbbPECartonStyle.Enabled = False
        End If

        Dim IsFixedCode As String = dtLPartData.Rows(0)("IsFixedCode").ToString.Trim
        If IsFixedCode.ToUpper = "Y" Then
            Me.ChkIsFixed.Checked = True
        Else
            Me.ChkIsFixed.Checked = False
        End If
        Me.CbbPpidStyle.Text = dtLPartData.Rows(0)("PpIDCodeStylePackID").ToString.Trim & "-" & dtLPartData.Rows(0)("PpIDCodeStylePackItem").ToString.Trim
        Me.TxtPpidQtyI.Text = dtLPartData.Rows(0)("PpIDQtyI").ToString.Trim

        Me.TxtCartonQtyI.Focus()
    End Sub

    '确认
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If Me.TxtLPartID.Text.Trim = "" Then
            MessageBox.Show("料件编号不能为空！")
            Exit Sub
        End If
        If Me.CbbCartonStyle.Text.Trim = "" Then
            MessageBox.Show("外箱条码类型和项次不能为空！")
            Exit Sub
        End If
        If Me.TxtCartonQtyI.Text.Trim = "" Then
            MessageBox.Show("外箱装箱数量不能为空！")
            Exit Sub
        End If
        Dim IntCartonQtyI As Integer = 0
        Dim IntPECartonQtyI As Integer = 0
        Dim IntPpidQtyi As Integer = 0
        Try
            IntCartonQtyI = Convert.ToInt32(Me.TxtCartonQtyI.Text.Trim)
            If IntCartonQtyI <= 0 Then
                MessageBox.Show("外箱装箱数量必须为正整数！")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("外箱装箱数量格式不对！")
            Exit Sub
        End Try
        If Me.ChkIsScanQRCode.Checked Then
            If Me.CbbQRCodeStyle.Text.Trim = "" Then
                MessageBox.Show("QR条码类型和项次不能为空！")
                Exit Sub
            End If
        End If
        If Me.ChkIsScanPECarton.Checked Then
            If Me.CbbPECartonStyle.Text.Trim = "" Then
                MessageBox.Show("PE袋条码类型和项次不能为空！")
                Exit Sub
            End If
            If Me.TxtPECartonQtyI.Text.Trim = "" Then
                MessageBox.Show("PE袋装箱数量不能为空！")
                Exit Sub
            End If
            Try
                IntPECartonQtyI = Convert.ToInt32(Me.TxtPECartonQtyI.Text.Trim)
                If IntPECartonQtyI <= 0 Then
                    MessageBox.Show("PE袋装箱数量必须为正整数！")
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("PE袋装箱数量格式不对！")
                Exit Sub
            End Try
        End If
        If Me.CbbPpidStyle.Text.Trim = "" Then
            MessageBox.Show("产品条码类型和项次不能为空！")
            Exit Sub
        End If
        If Me.TxtPpidQtyI.Text.Trim = "" Then
            MessageBox.Show("产品数量不能为空！")
            Exit Sub
        End If
        Try
            IntPpidQtyi = Convert.ToInt32(Me.TxtPpidQtyI.Text.Trim)
            If IntPpidQtyi <= 0 Then
                MessageBox.Show("产品数量必须为正整数！")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("产品数量格式不对！")
            Exit Sub
        End Try

        Dim CartonStylePackID As String = Me.CbbCartonStyle.Text.Trim.Split("-")(0).Trim
        Dim CartonStylePackItem As Integer = Convert.ToInt32(Me.CbbCartonStyle.Text.Trim.Split("-")(1).Trim)
        Dim IsScanQRCode As String = "N"
        Dim QRCodeStylePackID As String = ""
        Dim QRCodeStylePackItem As Integer = 0
        If Me.ChkIsScanQRCode.Checked Then
            IsScanQRCode = "Y"
            QRCodeStylePackID = Me.CbbQRCodeStyle.Text.Trim.Split("-")(0).Trim
            QRCodeStylePackItem = Convert.ToInt32(Me.CbbQRCodeStyle.Text.Trim.Split("-")(1).Trim)
        End If
        Dim IsAutoGenerateCarton As String = "N"
        If Me.ChkIsAutoGenerateCarton.Checked Then
            IsAutoGenerateCarton = "Y"
        End If
        Dim IsScanFixedCarton As String = "N"
        If Me.ChkIsScanFixedCarton.Checked Then
            IsScanFixedCarton = "Y"
        End If
        Dim IsScanCustProAndQtyI As String = "N"
        If Me.ChkIsScanCustProAndQtyI.Checked Then
            IsScanCustProAndQtyI = "Y"
        End If
        Dim IsSystemPrintCarton As String = "N"
        If Me.ChkIsSystemPrintCarton.Checked Then
            IsSystemPrintCarton = "Y"
        End If
        Dim IsSystemPrintQRCode As String = "N"
        If Me.ChkIsSystemPrintQRCode.Checked Then
            IsSystemPrintQRCode = "Y"
        End If
        Dim IsSystemPrintPECarton As String = "N"
        If Me.ChkIsSystemPrintPECarton.Checked Then
            IsSystemPrintPECarton = "Y"
        End If
        Dim IsSystemPrintPpID As String = "N"
        If Me.ChkIsSystemPrintPpID.Checked Then
            IsSystemPrintPpID = "Y"
        End If

        Dim IsScanPECarton As String = "N"
        Dim PECartonStylePackID As String = ""
        Dim PECartonStylePackItem As Integer = 0
        If Me.ChkIsScanPECarton.Checked Then
            IsScanPECarton = "Y"
            PECartonStylePackID = Me.CbbPECartonStyle.Text.Trim.Split("-")(0).Trim
            PECartonStylePackItem = Convert.ToInt32(Me.CbbPECartonStyle.Text.Trim.Split("-")(1).Trim)
        End If
        Dim PpIDCodeStylePackID As String = Me.CbbPpidStyle.Text.Trim.Split("-")(0).Trim
        Dim PpIDCodeStylePackItem As Integer = Convert.ToInt32(Me.CbbPpidStyle.Text.Trim.Split("-")(1).Trim)
        Dim IsFixedCode As String = "N"
        If Me.ChkIsFixed.Checked Then
            IsFixedCode = "Y"
        End If

        Dim pCode As String = ""
        Dim IsCheckPCode As String = "N"
        If Me.chkIsCheckPCode.Checked Then
            IsCheckPCode = "Y"
            txtPCode.Enabled = True
            pCode = txtPCode.Text
        End If

        'Dim StrSql As String = ""
        'If Flag = 0 Then
        '    StrSql = String.Format(" SELECT LPartID FROM dbo.m_PartScanStyleInof_t WHERE LPartID='{0}' ", Me.TxtLPartID.Text.Trim)
        '    Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(StrSql)
        '    If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
        '        MessageBox.Show("已经存在该料号的扫描参数资料，不能重复增加")
        '        Exit Sub
        '    End If
        '    StrSql = String.Format(" INSERT INTO dbo.m_PartScanStyleInof_t(LPartID ,CartonStylePackID ,CartonStylePackItem , " &
        '                    " CartonQtyI, IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, " &
        '                    " PECartonStylePackID, PECartonStylePackItem, PECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, " &
        '                    " IsFixedCode, PpIDQtyI, IsChecked, CreateUserID, CreateDate,IsScanCustProAndQtyI,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton) " &
        '                    " VALUES(N'{0}',N'{1}',{2},{3},N'{4}',N'{5}',{6},N'{7}',N'{8}',N'{9}',{10},{11},N'{12}',{13},N'{14}',{15},N'{16}', " &
        '                    " N'{17}',GETDATE(),N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}') ", Me.TxtLPartID.Text.Trim, CartonStylePackID, CartonStylePackItem, IntCartonQtyI, IsScanQRCode,
        '                    QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, PECartonStylePackID, PECartonStylePackItem,
        '                    IntPECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, IsFixedCode, IntPpidQtyi, "N", SysMessageClass.UseId, IsScanCustProAndQtyI, IsSystemPrintCarton, IsSystemPrintQRCode, IsSystemPrintPECarton, IsSystemPrintPpID, IsScanFixedCarton)
        'Else
        '    StrSql = String.Format(" INSERT INTO dbo.m_PartScanStyleInof_t_Log(OperLogID ,LPartID ,CartonStylePackID ,CartonStylePackItem , " &
        '                                " CartonQtyI, IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton,IsScanCustProAndQtyI, IsScanPECarton, " &
        '                                " PECartonStylePackID, PECartonStylePackItem, PECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, " &
        '                                " IsFixedCode, PpIDQtyI, IsChecked, CheckedUserID, CheckedDate, CreateUserID, CreateDate, OperType, OperUserid, OperDate,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton) " &
        '                                " SELECT NEWID() AS OperLogID,LPartID,CartonStylePackID ,CartonStylePackItem , " &
        '                                " CartonQtyI ,IsScanQRCode ,QRCodeStylePackID ,QRCodeStylePackItem ,IsAutoGenerateCarton ,IsScanCustProAndQtyI,IsScanPECarton , " &
        '                                " PECartonStylePackID ,PECartonStylePackItem ,PECartonQtyI ,PpIDCodeStylePackID ,PpIDCodeStylePackItem , " &
        '                                " IsFixedCode ,PpIDQtyI ,IsChecked ,CheckedUserID ,CheckedDate ,CreateUserID ,CreateDate ,'Update' AS OperType, " &
        '                                " '{1}' AS OperUserid,GETDATE() AS OperDate,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton FROM m_PartScanStyleInof_t WHERE LPartID='{0}' ", Me.TxtLPartID.Text.Trim, SysMessageClass.UseId)

        '    StrSql = StrSql & String.Format(" UPDATE dbo.m_PartScanStyleInof_t SET CartonStylePackID=N'{0}',CartonStylePackItem={1},CartonQtyI={2},IsScanQRCode=N'{3}', " &
        '                    " QRCodeStylePackID = N'{4}',QRCodeStylePackItem={5},IsAutoGenerateCarton=N'{6}',IsScanPECarton=N'{7}',PECartonStylePackID=N'{8}', " &
        '                    " PECartonStylePackItem={9},PECartonQtyI={10},PpIDCodeStylePackID=N'{11}',PpIDCodeStylePackItem={12},IsFixedCode=N'{13}', " &
        '                    " PpIDQtyI={14},CreateUserID=N'{15}',CreateDate=GETDATE(),IsScanCustProAndQtyI=N'{17}',IsSystemPrintCarton=N'{18}',IsSystemPrintQRCode=N'{19}',IsSystemPrintPECarton=N'{20}',IsSystemPrintPpID=N'{21}',IsScanFixedCarton=N'{22}' WHERE LPartID=N'{16}' ", CartonStylePackID, CartonStylePackItem, IntCartonQtyI,
        '                    IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, PECartonStylePackID, PECartonStylePackItem,
        '                    IntPECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, IsFixedCode, IntPpidQtyi, SysMessageClass.UseId, Me.TxtLPartID.Text.Trim, IsScanCustProAndQtyI, IsSystemPrintCarton, IsSystemPrintQRCode, IsSystemPrintPECarton, IsSystemPrintPpID, IsScanFixedCarton)

        'End If

        Dim StrSql As String = ""
        If Flag = 0 Then
            StrSql = String.Format(" SELECT LPartID FROM dbo.m_PartScanStyleInof_t WHERE LPartID='{0}' ", Me.TxtLPartID.Text.Trim)
            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(StrSql)
            If (Not dtTemp Is Nothing) AndAlso dtTemp.Rows.Count > 0 Then
                MessageBox.Show("已经存在该料号的扫描参数资料，不能重复增加")
                Exit Sub
            End If
            StrSql = String.Format(" INSERT INTO dbo.m_PartScanStyleInof_t(LPartID ,CartonStylePackID ,CartonStylePackItem , " &
                            " CartonQtyI, IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, " &
                            " PECartonStylePackID, PECartonStylePackItem, PECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, " &
                            " IsFixedCode, PpIDQtyI, IsChecked, CreateUserID, CreateDate,IsScanCustProAndQtyI,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton,IsCheckPCode,PCode) " &
                            " VALUES(N'{0}',N'{1}',{2},{3},N'{4}',N'{5}',{6},N'{7}',N'{8}',N'{9}',{10},{11},N'{12}',{13},N'{14}',{15},N'{16}', " &
                            " N'{17}',GETDATE(),N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}') ", Me.TxtLPartID.Text.Trim, CartonStylePackID, CartonStylePackItem, IntCartonQtyI, IsScanQRCode,
                            QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, PECartonStylePackID, PECartonStylePackItem,
                            IntPECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, IsFixedCode, IntPpidQtyi, "N", SysMessageClass.UseId, IsScanCustProAndQtyI, IsSystemPrintCarton, IsSystemPrintQRCode, IsSystemPrintPECarton, IsSystemPrintPpID, IsScanFixedCarton, IsCheckPCode, pCode)
        Else
            StrSql = String.Format(" INSERT INTO dbo.m_PartScanStyleInof_t_Log(OperLogID ,LPartID ,CartonStylePackID ,CartonStylePackItem , " &
                                        " CartonQtyI, IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton,IsScanCustProAndQtyI, IsScanPECarton, " &
                                        " PECartonStylePackID, PECartonStylePackItem, PECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, " &
                                        " IsFixedCode, PpIDQtyI, IsChecked, CheckedUserID, CheckedDate, CreateUserID, CreateDate, OperType, OperUserid, OperDate,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton) " &
                                        " SELECT NEWID() AS OperLogID,LPartID,CartonStylePackID ,CartonStylePackItem , " &
                                        " CartonQtyI ,IsScanQRCode ,QRCodeStylePackID ,QRCodeStylePackItem ,IsAutoGenerateCarton ,IsScanCustProAndQtyI,IsScanPECarton , " &
                                        " PECartonStylePackID ,PECartonStylePackItem ,PECartonQtyI ,PpIDCodeStylePackID ,PpIDCodeStylePackItem , " &
                                        " IsFixedCode ,PpIDQtyI ,IsChecked ,CheckedUserID ,CheckedDate ,CreateUserID ,CreateDate ,'Update' AS OperType, " &
                                        " '{1}' AS OperUserid,GETDATE() AS OperDate,IsSystemPrintCarton,IsSystemPrintQRCode,IsSystemPrintPECarton,IsSystemPrintPpID,IsScanFixedCarton FROM m_PartScanStyleInof_t WHERE LPartID='{0}' ", Me.TxtLPartID.Text.Trim, SysMessageClass.UseId)

            StrSql = StrSql & String.Format(" UPDATE dbo.m_PartScanStyleInof_t SET CartonStylePackID=N'{0}',CartonStylePackItem={1},CartonQtyI={2},IsScanQRCode=N'{3}', " &
                            " QRCodeStylePackID = N'{4}',QRCodeStylePackItem={5},IsAutoGenerateCarton=N'{6}',IsScanPECarton=N'{7}',PECartonStylePackID=N'{8}', " &
                            " PECartonStylePackItem={9},PECartonQtyI={10},PpIDCodeStylePackID=N'{11}',PpIDCodeStylePackItem={12},IsFixedCode=N'{13}', " &
                            " PpIDQtyI={14},CreateUserID=N'{15}',CreateDate=GETDATE(),IsScanCustProAndQtyI=N'{17}',IsSystemPrintCarton=N'{18}',IsSystemPrintQRCode=N'{19}',IsSystemPrintPECarton=N'{20}',IsSystemPrintPpID=N'{21}',IsScanFixedCarton=N'{22}' WHERE LPartID=N'{16}' ", CartonStylePackID, CartonStylePackItem, IntCartonQtyI,
                            IsScanQRCode, QRCodeStylePackID, QRCodeStylePackItem, IsAutoGenerateCarton, IsScanPECarton, PECartonStylePackID, PECartonStylePackItem,
                            IntPECartonQtyI, PpIDCodeStylePackID, PpIDCodeStylePackItem, IsFixedCode, IntPpidQtyi, SysMessageClass.UseId, Me.TxtLPartID.Text.Trim, IsScanCustProAndQtyI, IsSystemPrintCarton, IsSystemPrintQRCode, IsSystemPrintPECarton, IsSystemPrintPpID, IsScanFixedCarton)

        End If


        Try
            DbOperateUtils.ExecSQL(StrSql)
            MessageBox.Show(Me.Text.Trim & "成功！")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "新增或修改时发生错误!", "提示信息", MessageBoxButtons.OK)
        End Try
    End Sub

    '取消
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    '是否扫描QRCODE
    Private Sub ChkIsScanQRCode_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIsScanQRCode.CheckedChanged
        If Me.ChkIsScanQRCode.Checked Then
            Me.CbbQRCodeStyle.Enabled = True
        Else
            Me.CbbQRCodeStyle.Enabled = False
        End If
    End Sub

    '是否扫描PE袋条码
    Private Sub ChkIsScanPECarton_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIsScanPECarton.CheckedChanged
        If Me.ChkIsScanPECarton.Checked Then
            Me.CbbPECartonStyle.Enabled = True
            Me.TxtPECartonQtyI.Enabled = True
        Else
            Me.CbbPECartonStyle.Enabled = False
            Me.TxtPECartonQtyI.Enabled = False
        End If
    End Sub

    '料件编号离开事件
    Private Sub TxtLPartID_Leave(sender As Object, e As EventArgs) Handles TxtLPartID.Leave
        LoadStyleData()
    End Sub

    '加载料件参数信息
    Private Sub LoadStyleData()
        If Me.TxtLPartID.Text.Trim = "" Then
            Exit Sub
        End If
        Dim StrSql As String = String.Format("SELECT Packid+'-'+CONVERT(NVARCHAR(10),Packitem) AS PackInfo FROM dbo.m_PartPack_t WHERE Partid='{0}' AND (Usey='C' OR Usey='Y')", Me.TxtLPartID.Text.Trim)
        Dim dtData As DataTable = DbOperateUtils.GetDataTable(StrSql)
        Me.CbbCartonStyle.DataSource = dtData
        Me.CbbCartonStyle.DisplayMember = "PackInfo"
        Me.CbbCartonStyle.ValueMember = "PackInfo"
        Me.CbbCartonStyle.SelectedIndex = -1

        Dim dtTemp1 As DataTable = dtData.Copy
        Me.CbbQRCodeStyle.DataSource = dtTemp1
        Me.CbbQRCodeStyle.DisplayMember = "PackInfo"
        Me.CbbQRCodeStyle.ValueMember = "PackInfo"
        Me.CbbQRCodeStyle.SelectedIndex = -1

        Dim dtTemp2 As DataTable = dtData.Copy
        Me.CbbPECartonStyle.DataSource = dtTemp2
        Me.CbbPECartonStyle.DisplayMember = "PackInfo"
        Me.CbbPECartonStyle.ValueMember = "PackInfo"
        Me.CbbPECartonStyle.SelectedIndex = -1

        Dim dtTemp3 As DataTable = dtData.Copy
        Me.CbbPpidStyle.DataSource = dtTemp3
        Me.CbbPpidStyle.DisplayMember = "PackInfo"
        Me.CbbPpidStyle.ValueMember = "PackInfo"
        Me.CbbPpidStyle.SelectedIndex = -1
    End Sub

    Private Sub chkIsCheckPCode_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsCheckPCode.CheckedChanged
        If chkIsCheckPCode.Checked = True Then
            txtPCode.Enabled = True
        Else
            txtPCode.Enabled = False
        End If
    End Sub
End Class