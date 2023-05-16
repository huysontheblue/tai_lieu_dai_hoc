Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame

Public Class FrmPartLotScan

    Dim _dt As DateTime = DateTime.Now '' //定义一个成员函数用于保存每次的时间点
    Dim EideFlag As String = ""
    Dim PreMoid As String = ""
    Dim SumQty As Integer = 0

#Region "期化"
    Sub New()

        InitializeComponent()
        Me.TxtMoid.Text = ""
        Me.TxtMoid.Enabled = True '' "5120K-130300001" ''"5120K-130300010" ''moid
        Me.TxtPartid.Text = ""  ''"LA06US572-1H" ''"LA06US573-1H" '' partid
        Me.TxtStationid.Text = ""
        Me.lblLine.Text = "线别:"
        '"LA06US573-1H" '' 
    End Sub

    Sub New(ByVal moid As String, ByVal partid As String, ByVal stationid As String)

        InitializeComponent()
        Me.TxtMoid.Text = moid  '' "5120K-130300001" ''"5120K-130300010" ''moid
        Me.TxtPartid.Text = partid  ''"LA06US572-1H" ''"LA06US573-1H" '' partid
        Me.TxtStationid.Text = stationid.Split(" ")(0)
        Me.lblLine.Text = "站点:"
        '"LA06US573-1H" '' 
    End Sub

    '初期化
    Private Sub FrmPartLotScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RefreshComponet()
            RefeshDataInGrid()

            Call CheckStaion()

            TxtStyle.Text = "条码不符合标准样式XXX*XXXXXXX*XXXXXX*XXXXXX*XXXXXX"
            Me.toolBOMCheckSet.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "事件"

    '新增
    Private Sub toolScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click
        Setcontrolstute("1")
        EideFlag = "0"
        CobPartid.Enabled = True
        CobPartid.SelectedIndex = -1
        CobPartid.Text = ""
        TxtLotno.Enabled = True
        TxtLotno.Clear()
        CobPartid.Focus()
        If lblLine.Text = "线别:" Then
            Me.TxtMoid.Text = ""
            Me.TxtPartid.Text = ""
            Me.TxtStationid.Text = ""
            Me.TxtMoid.Focus()
            Me.CobPartid.DataSource = Nothing
            Me.TxtMoid.Enabled = True
        End If

    End Sub

    '批次号事件,扫描即保存
    Private Sub TxtLotno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLotno.KeyPress
        If e.KeyChar = Chr(13) Then
            ToolSave_Click(sender, e)
        End If
    End Sub

    '工单事件
    Private Sub TxtMoid_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMoid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strmoid As String = TxtMoid.Text.Trim.ToUpper
            If TxtMoid.Text.Trim <> "" Then
                Dim dt As DataTable
                Dim sql As String = Nothing
                sql = "EXEC GETCHECKTTMO '" & strmoid & "' , '" & VbCommClass.VbCommClass.Factory & "'"
                dt = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Me.TxtMoid.Text = dt.Rows(0)("MOID").ToString
                    Me.TxtPartid.Text = dt.Rows(0)("PARTID").ToString
                    Me.TxtStationid.Text = dt.Rows(0)("LINEID").ToString
                    Me.lblMOQty.Text = dt.Rows(0)("MOQty").ToString
                    TxtLotno.Clear()
                    RefreshComponet()
                    Me.CobPartid.Enabled = True
                    Me.TxtLotno.Enabled = True
                    RefeshDataInGrid()
                    CobPartid.Focus()
                    TxtStyle.Text = "XXXXX*XXXXXXX*XXXXXX*XXXXXX*XXXXXX"

                    'If Not IsSetCheckBOMScanOK() Then
                    '    MessageUtils.ShowError("请先维护哪些物料需要扫描检查...")
                    '    Exit Sub
                    'End If

                Else
                    MessageBox.Show("TT找不到此工单...")
                    Exit Sub
                End If
            Else
                MessageBox.Show("请输入工单...")
                Exit Sub
            End If
        End If
    End Sub

    '是否
    Private Sub chkSap_CheckedChanged(sender As Object, e As EventArgs) Handles chkSap.CheckedChanged
        If chkSap.Checked = True Then
            TxtStyle.Text = "条码不符合标准样式XXX*XXXXXXX*XXXXXX"
        Else
            TxtStyle.Text = "条码不符合标准样式XXX*XXXXXXX*XXXXXX*XXXXXX*XXXXXX"
        End If
    End Sub

    '保存
    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        If Me.TxtPartid.Text.Trim = "" Then
            LblMsg.Text = "料号不能为空，不能进行来料批次扫描..."
            Exit Sub
        End If

        If Me.TxtLotno.Text.Trim = "" Then
            LblMsg.Text = "批次条码不能为空，请扫描来料批次条码..."
            Exit Sub
        End If


        Dim arr As Array

        Dim tavcpart As String = ""
        Dim inlotid As String = ""
        Dim supplier As String = ""
        Dim remark As String = "", o_strSupplierCode As String = ""
        If EideFlag <> "1" Then

            If Not IsSetCheckBOMScanOK() Then
                MessageUtils.ShowError("请先维护哪些物料需要扫描检查...")
                Exit Sub
            End If

            If TxtLotno.Text.Trim.ToUpper.Contains("#") Then
                '仓库打印 250-230200-026H#180226xxx
                arr = TxtLotno.Text.Trim.ToUpper.Split("#")
                If arr.Length < 2 Then
                    LblMsg.Text = "条码不符合标准样式XXX#XXXX"
                    Exit Sub
                End If
                tavcpart = arr(0).ToString.ToUpper
                inlotid = arr(1).ToString.ToUpper
            End If

            Select Case VbCommClass.VbCommClass.Factory
                Case "LX81"
                    '料号*数量*日期*订单*供应商
                    If TxtLotno.Text.Trim.ToUpper.Contains("*") Then
                        '供应商 立讯料号、交货数量、供应商代码、最后工序日期、LOT 单号 RU2000-01DZ-100-2H2*1008*19/3/30*L5158-190100039*XXX
                        arr = TxtLotno.Text.Trim.ToUpper.Split("*")
                        If arr.Length <= 4 Then
                            LblMsg.Text = "条码不符合标准样式XXX*XXXXXXX*XXXXXX*XXXXXX*XXXXXX"
                            Exit Sub
                        End If
                        tavcpart = arr(0).ToString.ToUpper '立讯料号
                        supplier = arr(4) '供应商代码
                        txtTotalQTY.Text = arr(1)
                        inlotid = arr(2)
                    End If
                Case Else
                    If TxtLotno.Text.Trim.ToUpper.Contains("*") Then
                        '供应商 立讯料号、交货数量、供应商代码、最后工序日期、LOT 单号 250-230200-026H*0002000*M10080*180226*XXXXXX
                        arr = TxtLotno.Text.Trim.ToUpper.Split("*")

                        '是否是SAP标签
                        If chkSap.Checked = True Then
                            If arr.Length <> 3 Then
                                LblMsg.Text = "条码不符合标准样式XXX*XXXXXXX*XXXXXX"
                                Exit Sub
                            End If
                            tavcpart = arr(0).ToString.ToUpper '立讯料号
                            supplier = "" '供应商代码
                            remark = ""
                            inlotid = TxtLotno.Text.Trim
                        Else
                            If arr.Length <= 4 Then
                                LblMsg.Text = "条码不符合标准样式XXX*XXXXXXX*XXXXXX*XXXXXX*XXXXXX"
                                Exit Sub
                            End If
                            tavcpart = arr(0).ToString.ToUpper '立讯料号
                            supplier = arr(2) '供应商代码
                            remark = arr(1)
                            inlotid = arr(2) & "*" & arr(3) & "*" & arr(4)
                        End If
                    End If
            End Select

        End If
        If inlotid <> "" Then
            CobPartid.Text = ""
        Else
            tavcpart = CobPartid.Text.Split("(")(0).ToString
            inlotid = TxtLotno.Text.Trim.ToUpper
            If Me.txtTotalQTY.Text.Trim <> "" Then
                If Not IsNumeric(Me.txtTotalQTY.Text.Trim) Then
                    LblMsg.Text = "批次总数输入数字..."
                    Exit Sub
                End If
                Dim sql As String = ""
                sql = "select top 1 Linkqty from M_PCBLot_t where  Lotid  ='" & inlotid & "' and Linkqty <>" & txtTotalQTY.Text & " and Partid='" & tavcpart & "' order by intime desc"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    If MessageUtils.ShowConfirm("批次数量:" & txtTotalQTY.Text & "与上次设定不一致: " & dt.Rows(0)("Linkqty").ToString & ",确定吗?", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                        Exit Sub
                    End If
                End If
            Else
                If MessageUtils.ShowConfirm("确定不卡批次总数吗?", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End If

        Dim mReader As DataTable = GetPartDt(Me.TxtPartid.Text, tavcpart)

        If mReader.Rows.Count = 0 Then
            CobPartid.SelectedIndex = -1
            LblMsg.Text = "料号" & TxtPartid.Text.Trim & "找不到子料号" & tavcpart & "..."
            Exit Sub
        End If

        For iRowIndex As Integer = 0 To mReader.Rows.Count - 1
            Select Case VbCommClass.VbCommClass.Factory
                Case "LX81"
                    'DO nothing
                    o_strSupplierCode = IIf(IsDBNull(mReader.Rows(iRowIndex)!Supplierid) = False, mReader.Rows(iRowIndex)!Supplierid, supplier)
                Case Else
                    o_strSupplierCode = IIf(IsDBNull(mReader.Rows(iRowIndex)!Supplierid) = False, mReader.Rows(iRowIndex)!Supplierid, "")
            End Select

            DgPartid.Rows.Insert(0, mReader.Rows(iRowIndex)!TAvcPart, mReader.Rows(iRowIndex)!PAvcPart,
                                     mReader.Rows(iRowIndex)!TypeDest, mReader.Rows(iRowIndex)!CustPart,
                                     mReader.Rows(iRowIndex)!PartCode, o_strSupplierCode)
            CobPartid.SelectedText = mReader.Rows(iRowIndex)!TAvcPart & "(" & mReader.Rows(iRowIndex)!TypeDest & ")"
        Next

        Dim sqlstr As String = ""
        Dim lotqty As String = txtTotalQTY.Text.Trim
        Dim userid As String = VbCommClass.VbCommClass.UseId
        Dim facoty As String = VbCommClass.VbCommClass.Factory
        Dim profit As String = VbCommClass.VbCommClass.profitcenter
        Dim stationid As String = TxtStationid.Text
        Try
            sqlstr = ""
            If EideFlag = "1" Then
                Dim lotid As String = Me.Dglot.CurrentRow.Cells("Collot").Value
                'sqlstr = "update M_PCBLot_t set Lotid='" & inlotid & "',Linkqty=" & lotqty & ",updateuser='" & VbCommClass.VbCommClass.UseId & "',updatetime=getdate() where  moid='" & TxtMoid.Text & "' and Isnew='Y' and ppartid='" & Me.TxtPartid.Text & "' and Partid='" & tavcpart & "' AND  Lotid ='" & lotid & "' "
                sqlstr = "EXEC P_PCBLotScan '" & TxtMoid.Text.Trim.ToUpper & "','" & TxtLotno.Text.Trim.ToUpper & "','" & lotid & "','" & Me.TxtPartid.Text &
                                            "','" & tavcpart & "','','','" & lotqty & "','" & userid & "','','','" & facoty & "','" & profit & "','1'"
                DbOperateUtils.ExecSQL(sqlstr)

                Me.Dglot.Enabled = True
                LblMsg.Text = "来料批次编号，已经成功修改..."
                Dglot.Rows.Clear()
                RefeshDataInGrid()
                Me.CobPartid.Focus()
                EideFlag = "0"
                Setcontrolstute("2")
                Exit Sub
            End If

            If sqlstr = "" Then
                sqlstr = "EXEC P_PCBLotScan '" & TxtMoid.Text.Trim.ToUpper & "','" & inlotid & "','','" & Me.TxtPartid.Text & "','" & tavcpart & "','" & stationid & "',"
                sqlstr += "'','" & lotqty & "','" & userid & "','" & supplier & "','" & remark & "','" & facoty & "','" & profit & "','0','" & Val(Me.lblMOQty.Text.Trim) & "'"
                DbOperateUtils.ExecSQL(sqlstr)
            End If

            CobPartid.SelectedIndex = -1
            Me.CobPartid.Focus()
            TxtLotno.Clear()

            Setcontrolstute("2")
            'TxtStyle.Clear()
            Dglot.Rows.Clear()
            txtTotalQTY.Text = ""
            RefeshDataInGrid()
            Me.Dglot.Enabled = True
            LblMsg.Text = "来料批次编号，已经成功保存..."
            Exit Sub
        Catch ex As Exception
            LblMsg.Text = "来料批次扫描发生错误..."
            Exit Sub
        End Try
    End Sub

    '删除
    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click

        If Me.Dglot.Rows.Count < 1 Then
            LblMsg.Text = "没有可以修改的料件批次数据行..."
            Exit Sub
        End If
        If Me.Dglot.CurrentRow Is Nothing Then
            LblMsg.Text = "请在下边表格中，选择你要修改的数据行..."
            Exit Sub
        End If

        If MessageUtils.ShowConfirm("你确定要作废这个" & Me.Dglot.CurrentRow.Cells("Colmpartid").Value & "的来料批次号吗?", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
            Exit Sub
        End If

        'If MessageBox.Show("你确定要作废这个" & Me.Dglot.CurrentRow.Cells("Colmpartid").Value & "的来料批次号吗?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
        '    Exit Sub
        'End If

        Dim sqlstr As String = ""
        Dim PARTID As String = Me.Dglot.CurrentRow.Cells("Colmpartid").Value
        Dim lotid As String = Me.Dglot.CurrentRow.Cells("Collot").Value
        sqlstr = " UPDATE M_PCBLOT_T SET ISNEW='N' WHERE  MOID='" & TxtMoid.Text & "' AND PARTID='" & PARTID & "' AND ISNEW='Y'   AND LOTID='" & lotid & "'"

        Try
            DbOperateUtils.ExecSQL(sqlstr)
            CobPartid.SelectedIndex = -1
            TxtLotno.Clear()
            LblMsg.Text = "你已成功作废来料批次的组件料号..."
            RefeshDataInGrid()
        Catch ex As Exception
            LblMsg.Text = "作废来料批次的组件料号,发生错误..."
        End Try
    End Sub

    '修改
    Private Sub toolUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolUpdate.Click
        If Me.Dglot.Rows.Count < 1 Then
            LblMsg.Text = "没有可以修改的料件批次数据行..."
            Exit Sub
        End If
        If Me.Dglot.CurrentRow Is Nothing Then
            LblMsg.Text = "请在下边表格中，选择你要修改的数据行..."
            Exit Sub
        End If
        Me.Dglot.Enabled = False
        Setcontrolstute("1")
        Me.CobPartid.Enabled = False
        Me.TxtMoid.Enabled = False
        TxtMoid.Text = Me.Dglot.CurrentRow.Cells("moid").Value
        TxtPartid.Text = Me.Dglot.CurrentRow.Cells("partid").Value
        Me.CobPartid.Text = Me.Dglot.CurrentRow.Cells("Colmpartid").Value & "(" & Me.Dglot.CurrentRow.Cells("Coldes").Value & ")"
        Me.TxtLotno.Text = Me.Dglot.CurrentRow.Cells("Collot").Value
        Me.txtTotalQTY.Text = Me.Dglot.CurrentRow.Cells("linkqty").Value
        EideFlag = "1"
    End Sub

    '取消
    Private Sub ToolNg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNg.Click
        CobPartid.SelectedIndex = -1
        TxtLotno.Clear()
        Setcontrolstute("2")
        Me.TxtLotno.Clear()
        'Me.TxtStyle.Clear()
        If Me.lblLine.Text = "线别:" Then
            Me.TxtMoid.Text = ""
            Me.TxtMoid.Focus()
        End If
        txtTotalQTY.Text = ""
        Me.Dglot.Enabled = True

    End Sub

    '子料件选择
    Private Sub CobPartid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobPartid.SelectedIndexChanged
        'Me.TxtStyle.Text = "*******"
        DgPartid.Rows.Clear()
        If CobPartid.Text.ToString <> "" Then
            Dim mReader As DataTable = GetPartDt(Me.TxtPartid.Text, CobPartid.Text.Split("(")(0).ToString)

            If mReader.Rows.Count = 0 Then
                CobPartid.SelectedIndex = -1
                LblMsg.Text = "请维护好料件基础资料中的相关资料..."
                Exit Sub
            End If
            For iRowIndex As Integer = 0 To mReader.Rows.Count - 1
                DgPartid.Rows.Add(mReader.Rows(iRowIndex)!TAvcPart, mReader.Rows(iRowIndex)!PAvcPart,
                                  mReader.Rows(iRowIndex)!TypeDest, mReader.Rows(iRowIndex)!CustPart,
                                  mReader.Rows(iRowIndex)!PartCode, mReader.Rows(iRowIndex)!Supplierid)
            Next

            DgPartid.AutoResizeColumns()
            txtTotalQTY.Focus()
        Else
            CobPartid.Focus()
        End If
    End Sub

    '退出 
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

#Region "方法"

    Private Sub CheckStaion()
        Dim Sqlstr As String = String.Empty
        Sqlstr = " DECLARE @outstrResult  varchar(10)" & _
                 " EXECUTE [m_CheckPCBLotStation_P] '" & Me.TxtStationid.Text.Trim & "','" & Trim(TxtMoid.Text.Trim) & "','" & Trim(TxtPartid.Text.Trim) & "'" & _
                 " ,@outstrResult output " & _
                 " SELECT @outstrResult"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0)(0).ToString
                Case "0"
                    LblMsg.Text = "FAIL, 站别选择错误,请退出该程序重新选择!"
                    Me.toolScanSet.Enabled = False
                    Me.ToolNg.Enabled = False
                    Me.toolUpdate.Enabled = False
                    Me.TxtLotno.Enabled = False
                    Me.ToolDelete.Enabled = False
                    Exit Sub
                Case "1"
                    'Pass        
                Case Else
                    'do nothing
            End Select

        End If
    End Sub

    Private Sub RefreshComponet()
        Dim sql As String = Nothing
        sql = "SELECT A.tAvcPart+'('+A.TypeDest +')' TAvcPart FROM (SELECT * FROM m_PartContrast_t where PAvcPart='{0}' " &
              " AND PAvcPart<>tAvcPart AND USEY='Y'  and factory = '{1}' )A  ORDER BY TAvcPart"
        sql = String.Format(sql, Me.TxtPartid.Text, VbCommClass.VbCommClass.Factory)

        Dim mReader As DataTable = DbOperateUtils.GetDataTable(sql)

        For iRowIndex As Integer = 0 To mReader.Rows.Count - 1
            CobPartid.Items.Add(mReader.Rows(iRowIndex)!TAvcPart.ToString)
        Next
        CobPartid.SelectedIndex = -1
        'Dim arr As List(Of String) = New List(Of String)

        'For iRowIndex As Integer = 0 To mReader.Rows.Count - 1
        '    arr.Add(mReader.Rows(iRowIndex)!TAvcPart.ToString)
        'Next

        'Me.CobPartid.DataSource = arr
        'Me.CobPartid.AutoCompleteSource = AutoCompleteSource.CustomSource
        'Me.CobPartid.AutoCompleteMode = AutoCompleteMode.Suggest
        'Me.CobPartid.AutoCompleteCustomSource.AddRange(arr.ToArray)
        'CobPartid.SelectedIndex = -1
    End Sub

    Private Sub RefeshDataInGrid()
        Dim strSQL As String = "select Moid,ppartid,Partid,Partdes,Lotid,isnew,linkqty,splitqty,scancount,Intime from M_PCBLot_t " &
                              " where moid='{0}' and  ppartid='{1}'  and Isnew='Y' order by Intime DESC"
        strSQL = String.Format(strSQL, Me.TxtMoid.Text, Me.TxtPartid.Text.Trim)
        Dim mReader As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dglot.Rows.Clear()
        For iRowIndex As Integer = 0 To mReader.Rows.Count - 1
            Me.Dglot.Rows.Add(mReader.Rows(iRowIndex)!Moid.ToString, mReader.Rows(iRowIndex)!ppartid.ToString,
                              mReader.Rows(iRowIndex)!Partid.ToString, mReader.Rows(iRowIndex)!Partdes.ToString,
                              mReader.Rows(iRowIndex)!Lotid.ToString, mReader.Rows(iRowIndex)!isnew.ToString,
                              mReader.Rows(iRowIndex)!linkqty.ToString, mReader.Rows(iRowIndex)!splitqty.ToString,
                              mReader.Rows(iRowIndex)!scancount.ToString, mReader.Rows(iRowIndex)!Intime.ToString)
        Next

        Dglot.AutoResizeColumns()
    End Sub

    Private Function GetPartDt(ppartid As String, tpartid As String) As DataTable
        Dim strSQL As String =
            "select TAvcPart,PAvcPart,TypeDest,CustPart,PartCode,Supplierid from  m_PartContrast_t  " &
            "where PAvcPart='{0}' and TAvcPart='{1}'  and PAvcPart<>tAvcPart and factory = '{2}'"

        strSQL = String.Format(strSQL, ppartid, tpartid, VbCommClass.VbCommClass.Factory)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        GetPartDt = dt
    End Function

    Private Sub Setcontrolstute(ByVal flag As String)

        If flag = "1" Then
            toolScanSet.Enabled = False
            toolUpdate.Enabled = False
            ToolDelete.Enabled = False
            ToolNg.Enabled = True
            toolSave.Enabled = True
            ' CobPartid.SelectedIndex = -1
            Me.TxtLotno.Enabled = False
            Me.TxtLotno.Clear()
            Me.txtTotalQTY.Focus()
        ElseIf flag = "2" Then
            toolScanSet.Enabled = True
            toolUpdate.Enabled = True
            ToolDelete.Enabled = True
            ToolNg.Enabled = False
            toolSave.Enabled = False
            txtTotalQTY.Text = ""
            CobPartid.Enabled = True
            CobPartid.Text = ""
            CobPartid.SelectedIndex = -1
            Me.TxtLotno.Clear()
            Me.TxtLotno.Enabled = True
            Me.TxtLotno.Focus()
            Me.ActiveControl = Me.TxtLotno
        End If

    End Sub


    Public Function IsSetCheckBOMScanOK() As Boolean
        Dim lssql As String = String.Empty
        Dim o_strBOMCheckSetOfDB As String = ""
        Dim o_strBOMCheckSetOfDB_factory As String = ""
        Try
            lssql = " select PARAMETER_VALUES from m_SystemSetting_t where upper(PARAMETER_CODE)='ENABLEBOMCHECK'  "
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    o_strBOMCheckSetOfDB = o_dt.Rows(0).Item(0)
                    '  1|1021,1021
                    If o_strBOMCheckSetOfDB.Split("|")(0) = "1" Then
                        o_strBOMCheckSetOfDB_factory = o_strBOMCheckSetOfDB.Split("|")(1)
                        If ("," & o_strBOMCheckSetOfDB_factory & ",").IndexOf("," & VbCommClass.VbCommClass.Factory & ",") >= 0 Then
                            '检查是否维护好该产品哪些物料需要检查上料扫描
                            '默认只要存在记录就认为是ready
                            If IsSetCheckBOMScanReady(TxtPartid.Text.Trim) Then
                                IsSetCheckBOMScanOK = True
                            Else
                                IsSetCheckBOMScanOK = False
                            End If
                        Else
                            IsSetCheckBOMScanOK = True
                        End If
                    Else
                        IsSetCheckBOMScanOK = True
                        Return IsSetCheckBOMScanOK
                    End If
                Else
                    IsSetCheckBOMScanOK = True
                End If
            End Using
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Function IsSetCheckBOMScanReady(ByVal PPartid As String) As Boolean
        Dim lssql As String
        Try
            lssql = " select top 1 1 from m_bomchecklist_t where ppartid='" & PPartid & "'  "
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    IsSetCheckBOMScanReady = True
                Else
                    IsSetCheckBOMScanReady = False
                End If
            End Using
        Catch ex As Exception
            IsSetCheckBOMScanReady = False
        End Try
    End Function

#End Region

    Private Sub toolBOMCheckSet_Click(sender As Object, e As EventArgs) Handles toolBOMCheckSet.Click
        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()
        If CartonScanOption.CheckStr = True Then
            Dim frm As New FrmBOMCheckSet
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.txtPPartID_Hide.Text = TxtPartid.Text
            frm.ShowDialog()
        End If

    End Sub


End Class