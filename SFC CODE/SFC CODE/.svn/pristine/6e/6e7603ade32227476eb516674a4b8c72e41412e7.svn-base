Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports SysBasicClass
Imports System.Reflection
Imports System.Threading
Imports MainFrame
Imports UIHandler
'Imports SysBasicClass
Imports VbCommClass
Imports BarCodePrint


Public Class FrmWorkSheet
    Const GridColZero As Integer = 0    ''''checkbox
    Const GridColOne As Integer = 1     ''''MOID
    Const GridColTwo As Integer = 2     ''''PartID
    Const GridColThree As Integer = 3   ''''PName
    Const GridColFour As Integer = 4   ''''Deptid
    Const GridColFive As Integer = 5    ''''LineId
    Const GridColSix As Integer = 6    ''''MOqty
    Const GridColServ As Integer = 7    ''''MoType
    Const GridColEig As Integer = 8    ''''MOstate
    Const GridColNine As Integer = 9    ''''CustID
    Const GridColTen As Integer = 10    ''''
    Const GridEven As Integer = 11    ''''
    Const GridTwe As Integer = 12        ''
    Dim ComboxFlag As Boolean
    Dim DataGridHeight As Integer = 0
    Dim DataGridNew As Integer = 0
    Dim DataLocation As Integer = 0
    Dim DataLocaNew As Integer = 0
    Dim opFlag As Int16 = 0    '新增,修改,初始狀態的標誌 
    Private m_blnErpSave As Boolean = False
    Dim profitcenter As String = VbCommClass.VbCommClass.profitcenter
    Dim UseId As String = VbCommClass.VbCommClass.UseId
    Public OldPartID As String

    Private Enum enumdgMOData
        iSelect '0
        MOID '工单编号
        PartID '料件编号
        Cust '客户别
        Series '序列别
        PName '品名
        Deptid '生产部门
        Lineid '生产线别
        MOqty '工单数量
        PO '合同号
        Typeid '工单类型
        EstateID '工单状态
        OrderNo '订单编号
        OrderSeq '订单项次
        Version
        DeliveryDate '订单预计交货日期
        ScheFinishDate  '工单预定完工日
        ParentMo
        Dept
        Type
    End Enum

    Public m_listCustID As New List(Of String)
    ''' <summary>
    ''' 工单的各个状态EstateID
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumMOState
        ConfirmStart = 1 '1	確認生產工單(firm plan) 	
        BOMNoPrint '2	工單已發放,料表尚未列印	
        BOMPrinted '3	工單已發放,料表已列印	
        MOSend '4	工單已發料	
        WIP '5	在製過程中	
        FQC '6	工單已完工,進入F.Q.C 	
        StoreIn '7	完工入庫	
        Close '8	結案	
        'RBatchAndClose '9	工單成功分批并結案	
        ' RPrinted  ?? 'A	工單打印RUN CARD	
        Lock  '9
    End Enum

#Region "初期化"

    Private Sub FrmWorkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Erightbutton() '
        '檢視用戶權限()
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)

        Me.toolAddQty.Enabled = IIf(Me.toolAddQty.Tag = "YES", True, False)
        Me.toolMOLock.Enabled = IIf(Me.toolMOLock.Tag = "YES", True, False)

        Panel1.Enabled = False
        FillCombox(CobFactory)
        'FillComboLine(CboMoType)
        FillCombox(CboMoType)
        FillCombox(cobLineQuery)
        FillCombox(CboCust)
        FillCombox(ComMoType)
        FillCombox(CboCustID)
        FillCombox(CobSeries)
        FillCombox(CboSerialID)
        CobFactory.SelectedIndex = -1
        ComMoType.SelectedIndex = -1
        CboDept.SelectedIndex = -1
        CboCust.SelectedIndex = -1
        Me.CboCustID.SelectedIndex = -1
        Me.CobSeries.SelectedIndex = -1
        Me.CboSerialID.SelectedIndex = -1
        Me.cobLineQuery.SelectedIndex = -1
        Me.ToolCancel.Enabled = False
        SetStatus(opFlag)
    End Sub

#End Region


#Region "事件"

    '查询 
    Private Sub BtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        QueryDataToGrid()
    End Sub

    'GRID选择
    Private Sub DgMoData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellClick
        If DgMoData.CurrentCell Is Nothing Then Exit Sub
        If DgMoData.CurrentCell.RowIndex = DgMoData.Rows.Count Then Exit Sub

        If DgMoData.CurrentCell.ColumnIndex = GridColZero Then
            DgMoData.CurrentRow.Cells(GridColZero).Value = Not (DgMoData.CurrentRow.Cells(GridColZero).Value)
        End If
        'If factory.IndexOf(Factory) > 0 Then‘所有厂区一样
        '    InitControl(DgMoData.CurrentRow)
        'End If
        InitControl(DgMoData.CurrentRow)
    End Sub


    Private Sub TxtparentMo_Leave(sender As Object, e As EventArgs) Handles TxtparentMo.Leave
        If VbCommClass.VbCommClass.Factory.IndexOf(VbCommClass.VbCommClass.Factory) > 0 Then
            Dim qty As Integer = 0
            Dim rQty As Integer = 0
            Dim SQL As String = "SELECT MOQTY FROM M_MAINMO_T WHERE MOID=PARENTMO AND PARENTMO='" & TxtparentMo.Text & "'"
            Using dt As DataTable = DbOperateUtils.GetDataTable(SQL)
                If dt.Rows.Count > 0 Then
                    qty = CInt(dt.Rows(0)("MOQTY"))
                End If
            End Using
            Dim SQLS As String = "SELECT ISNULL(SUM(MOQTY),0) sMOQTY FROM M_MAINMO_T WHERE MOID<>PARENTMO AND PARENTMO='" & TxtparentMo.Text & "'"
            Using dt1 As DataTable = DbOperateUtils.GetDataTable(SQLS)
                If dt1.Rows.Count > 0 Then
                    rQty = CInt(dt1.Rows(0)("sMOQTY"))
                End If
            End Using
            TxtMoQty.Text = qty - rQty
        End If
    End Sub

    '工单类型下拉框改变不清空datagridview数据 关晓艳 2018/11/26
    Private Sub CboMoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMoType.TextChanged
        'If ComboxFlag = False Then
        '    ComboxFlag = True
        '    Exit Sub
        'Else
        '    DgMoData.Rows.Clear()
        '    TlelCount.Text = "0"
        'End If
    End Sub


    Private Sub DgMoData_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellLeave
        If DgMoData.CurrentCell.ColumnIndex = GridColFive Then
            DgMoData.EndEdit()
        End If
    End Sub

    'ERP查询下载
    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        Me.LblMsg.Text = ""
        QueryDataToGrid()
    End Sub

    '新增
    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        opFlag = "1"
        SetStatus(opFlag)
        DgMoData.Rows.Clear() : TlelCount.Text = "0"
        m_blnErpSave = False
        Me.TxtMoNumber.Clear() : Me.txtPartNo.Clear() : Me.TxtMoQty.Clear()
        Me.TxtMoNumber.Focus()
        Me.CboMoType.SelectedIndex = -1
    End Sub

    Private Sub TxtMoQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoQty.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CboDept.Focus()
        End If
        If Me.TxtMoQty.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '返回
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        opFlag = 0
        SetStatus(opFlag)
        Me.Panel1.Enabled = False
        Me.Panel2.Enabled = True
        Me.TxtMoNo.Focus()
    End Sub

    '
    Private Sub TxtMoNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMoNumber.KeyPress, txtPartNo.KeyPress, CboCust.KeyPress, TxtMoQty.KeyPress, CboDept.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Dim TabTrans As New TextHandle
            TabTrans.TabTransEnter(sender, e)
            TabTrans = Nothing
        End If
    End Sub

    Private Sub CboLine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboLine.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            TxtMoNumber.Focus()
        End If
    End Sub

    Private Sub CobFactory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobFactory.LostFocus
        CboLine.DataSource = Nothing
        CboDept.DataSource = Nothing
        FillCombox(CboDept)
        CboDept.SelectedIndex = -1
        CboLine.SelectedIndex = -1
    End Sub

    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobFactory.SelectedIndexChanged
        CboDept.SelectedIndex = -1
        CboLine.SelectedIndex = -1
    End Sub

    Private Sub CboDept_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDept.LostFocus
        CboLine.DataSource = Nothing
        FillCombox(CboLine)
        CboLine.SelectedIndex = -1
    End Sub


    Private Sub CboDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDept.SelectedIndexChanged
        CboLine.SelectedIndex = -1
    End Sub

    Private Sub DgMoData_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellEnter
        On Error Resume Next

        If Me.DgMoData.Rows.Count = 0 OrElse Me.DgMoData.CurrentRow Is Nothing Then
            Me.TxtMoNumber.Text = ""
            Me.txtPartNo.Text = ""
            Me.TxtMoQty.Text = ""
            Me.txtPO.Text = ""
            Me.CboCust.SelectedIndex = -1
            Me.CobFactory.SelectedIndex = -1
            Me.CboLine.SelectedIndex = -1
            Me.CboDept.SelectedIndex = -1
            Me.ComMoType.SelectedIndex = -1
            Me.cobLineQuery.SelectedIndex = -1
            Exit Sub
        Else
            Me.TxtMoNumber.Text = Me.DgMoData.Item("Comoid", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
            Me.txtPartNo.Text = Me.DgMoData.Item("ColPartid", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
            Me.TxtMoQty.Text = Me.DgMoData.Item("Colqty", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
            'cq 20160720
            Me.txtPO.Text = Me.DgMoData.Item("ColPO", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
            Me.TxtparentMo.Text = Me.DgMoData.Item("PARENTMO", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()

            Me.CboCust.SelectedIndex = -1
            Me.CobFactory.SelectedIndex = -1
            Me.CboLine.SelectedIndex = -1
            Me.CboDept.SelectedIndex = -1
            Me.ComMoType.SelectedIndex = -1

            'zhenfei.hu BZ修改需要带出工单信息,减少手工录入工作量
            'If Factory = "BZLANTO" OrElse Factory = "SUINING" Then
            '    Me.CobFactory.SelectedIndex = 0
            '    CobFactory_LostFocus(Nothing, Nothing)
            '    Me.ComMoType.SelectedValue = Me.DgMoData.Item("Coltype", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
            '    Me.CboDept.SelectedIndex = CboDept.FindString(Me.DgMoData.Item("ColDept", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim())
            '    CboDept_LostFocus(Nothing, Nothing)
            '    Me.CboLine.SelectedValue = Me.DgMoData.Item("ColLine", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
            '    Me.CboCust.SelectedIndex = Me.CboCust.FindString(CboCustID.Text.Split("(")(0).Trim)
            '    Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(CboSerialID.Text)
            '    TxtparentMo.Text = TxtMoNumber.Text
            '    'Me.CobFactory.SelectedIndex = 0
            '    txtOrderNo.Text = "1"
            '    txtOrderSeq.Text = "1"
            '    txtPO.Text = "1"
            '    dtDeliveryDate.Checked = True
            '    dtScheFinishDate.Checked = True
            'End If

            Select Case VbCommClass.VbCommClass.Factory
                Case "BZLANTO"
                    Me.CobFactory.SelectedIndex = 0
                    CobFactory_LostFocus(Nothing, Nothing)
                    Me.ComMoType.SelectedValue = Me.DgMoData.Item("Coltype", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
                    Me.CboDept.SelectedIndex = CboDept.FindString(Me.DgMoData.Item("ColDept", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim())
                    CboDept_LostFocus(Nothing, Nothing)
                    Me.CboLine.SelectedValue = Me.DgMoData.Item("ColLine", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
                    Me.CboCust.SelectedIndex = Me.CboCust.FindString(CboCustID.Text.Split("(")(0).Trim)
                    Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(CboSerialID.Text)
                    TxtparentMo.Text = TxtMoNumber.Text
                    'Me.CobFactory.SelectedIndex = 0
                    txtOrderNo.Text = "1"
                    txtOrderSeq.Text = "1"
                    txtPO.Text = "1"
                    dtDeliveryDate.Checked = True
                    dtScheFinishDate.Checked = True
                Case "SUINING"
                    Me.CobFactory.SelectedIndex = 0
                    CobFactory_LostFocus(Nothing, Nothing)
                    'index 从0开始
                    ' If CboMoType.FindString(Me.DgMoData.Item("Coltype", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim) > 0 Then
                    ' Me.ComMoType.SelectedIndex = CboMoType.FindString(Me.DgMoData.Item("Coltype", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim) - 1
                    ' End If
                    Me.CboDept.SelectedIndex = CboDept.FindString(Me.DgMoData.Item("ColDept", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim())
                    CboDept_LostFocus(Nothing, Nothing)
                    Me.CboLine.SelectedValue = Me.DgMoData.Item("ColLine", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()
                    Me.CboCust.SelectedIndex = CboCust.FindString(Me.DgMoData.Item("CusID", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim()) 'Me.CboCust.FindString(CboCustID.Text.Split("--")(0).Trim)
                    ' Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(CboSerialID.Text)
                    Me.CobSeries.SelectedIndex = Me.CobSeries.FindString(Me.DgMoData.Item("SeriesID", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim())
                    TxtparentMo.Text = TxtMoNumber.Text
                    'Me.CobFactory.SelectedIndex = 0
                    txtOrderNo.Text = Me.DgMoData.Item("ORDERNO", Me.DgMoData.CurrentRow.Index).Value.ToString.Trim() '"1"
                    txtOrderSeq.Text = "1"
                    ' txtPO.Text = "1"
                    dtDeliveryDate.Checked = True
                    dtScheFinishDate.Checked = True
                Case Else
                    'do nothing
            End Select

        End If
    End Sub

    '查询 
    Private Sub ToolQueryMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQueryMO.Click
        Try
            m_blnErpSave = False
            Me.LblMsg.Text = ""
            Dim FiterSqlStr As String = ""
            FiterSqlStr = GetFiterString()

            If FiterSqlStr = "" Then
                TlelCount.Text = "0"
                Exit Sub
            End If
            LoadDataInGrid(FiterSqlStr)
        Catch ex As Exception
            MessageBox.Show("查询工单异常，请联系开发人员")
        End Try
    End Sub

    '编辑 
    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        If Me.DgMoData.Rows.Count = 0 OrElse Me.DgMoData.CurrentRow Is Nothing Then
            MessageBox.Show("请选择需要修改工单!")
            Exit Sub
        End If
        'If factory.IndexOf(Factory) < 0 Then
        '    opFlag = "2"
        'Else
        '    opFlag = "3"
        'End If
        opFlag = "3"
        SetStatus(opFlag)
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartNo.GotFocus
        OldPartID = Me.txtPartNo.Text
    End Sub

    '保存
    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Dim strItemNum As String = "0", strChildMoid As String = "", o_strSerial As String = ""
        Dim strSQL As String = "", mos As String = Nothing
        Dim SqlItemStr As New System.Text.StringBuilder
        Dim ItemSeq As String = String.Empty
        Me.LblMsg.Text = String.Empty

        Try
            If (opFlag = 1) Then  'New Save
                DgMoData.EndEdit()

                '新增检查 田玉琳20190816
                If IsPrintCheck() = False Then
                    Exit Sub
                End If
                If Me.ToolCancel.Enabled = True Then
                    If Not BaseDataCheck() Then
                        Exit Sub
                    End If

                    If Not m_blnErpSave Then

                        Dim partID_SFB05 As String = Trim(txtPartNo.Text)
                        '************************** 田玉琳 20181227 开始 **************************
                        '针对所有新产品，第一次生产PQE需在系统内维护30天每日柏拉图
                        SqlItemStr.Append(" IF NOT EXISTS(SELECT 1 FROM m_PartContrast_t WHERE TAvcPart='" & partID_SFB05 &
                                                "' AND intime < GETDATE()-1  " & MOComBusiness.GetPartFatory & " )  ")
                        SqlItemStr.Append(" BEGIN  ")
                        SqlItemStr.Append(" IF NOT EXISTS(SELECT Partid FROM m_AssyTsProcssCheckPartId WHERE Partid='" & partID_SFB05 & "' AND TYPE = 'D' )  ")
                        SqlItemStr.Append(" BEGIN  ")
                        SqlItemStr.AppendFormat("   INSERT INTO m_AssyTsProcssCheckPartId(PartId, TYPE, ValidStartDate, ValidEndDate, IsValid, Remark, UserId, InTime) " &
                                                "   VALUES('{0}','D',convert(VARCHAR(10),getdate(),111),convert(VARCHAR(10),getdate()+30,111), 'Y',N'FrmWorkSheet-New'," &
                                                "   '{1}',getdate()) ", partID_SFB05, UseId)
                        SqlItemStr.Append(" END  ")
                        SqlItemStr.Append(" END  ")
                        '************************** 田玉琳 20181227 结束 **************************

                        '  SqlItemStr.Append(" DELETE FROM m_Mainmo_t WHERE moid='" & Trim(TxtMoNumber.Text) & "'").Append(vbNewLine)
                        SqlItemStr.Append(" If NOT EXISTS ( SELECT TOP 1 1 FROM m_Mainmo_t  WHERE moid ='" & Trim(TxtMoNumber.Text) & "')")
                        SqlItemStr.Append(" Begin ")
                        SqlItemStr.Append(" INSERT INTO m_Mainmo_t(Moid,PartID,Cusid,Deptid,lineid,Moqty")
                        SqlItemStr.Append(",Typeid,EstateID,Plandate,Createuser,Createtime,FinalY,Finalman,Finaltime,Factory,profitcenter,ParentMo,")
                        SqlItemStr.Append(" VERSION, SeriesID,ORDERNO,Orderseq,DeliveryDate,ScheFinishDate,PO,CreateAPID)")
                        SqlItemStr.Append(" VALUES('" & Trim(TxtMoNumber.Text) & "','" & Trim(txtPartNo.Text) & "','" & CboCust.SelectedValue & "',")
                        SqlItemStr.Append("'" & Trim(CboDept.SelectedValue) & "','" & Trim(CboLine.SelectedValue) & "','" & Trim(TxtMoQty.Text) & "','" & ComMoType.SelectedValue & "','5',")
                        SqlItemStr.Append(" getdate(),'" & UseId.ToLower & "',getdate(),'N','" & UseId.ToLower & "',getdate(),")
                        SqlItemStr.Append("'" & CobFactory.SelectedValue & "','" & profitcenter & "','" & TxtparentMo.Text & "',")
                        SqlItemStr.Append(" '" & GetPnVersionByInputMo() & "','" & CobSeries.SelectedValue & "','" & txtOrderNo.Text & "',")
                        SqlItemStr.Append(" '" & txtOrderSeq.Text & "','" & dtDeliveryDate.Value.ToShortDateString & "','" & dtScheFinishDate.Value.ToShortDateString & "','" & txtPO.Text.Trim & "','FrmWorkSheet-New')")
                        SqlItemStr.Append(" End ")
                    Else
                        For Each dr As DataGridViewRow In DgMoData.Rows
                            If dr.Index = DgMoData.Rows.Count Then Exit For
                            If dr.Cells(enumdgMOData.MOID).Value Is Nothing Then Exit Sub
                            If Not BaseDataCheckForAuto(dr) Then
                                Exit Sub
                            End If
                            If CheckMoExists(dr.Cells(enumdgMOData.MOID).Value) Then
                                mos += dr.Cells(1).Value + ","
                                Continue For
                            End If

                            ' SqlItemStr.Append(" DELETE FROM m_Mainmo_t WHERE PARENTMO='" & dr.Cells(enumdgMOData.MOID).Value & "'").Append(vbNewLine)
                            SqlItemStr.Append(" If NOT EXISTS ( SELECT TOP 1 1 FROM m_Mainmo_t  WHERE moid ='" & dr.Cells(enumdgMOData.MOID).Value & "')")
                            SqlItemStr.Append(" Begin ")
                            'Insert 主工单, add download 订单编号、订单项次、订单预计交货日期、工单预计结束生产日期,cq20151204
                            SqlItemStr.Append(" INSERT INTO m_Mainmo_t(Moid,PartID,Cusid,Deptid,lineid,Moqty")
                            SqlItemStr.Append(",Typeid,EstateID,Plandate,Createuser,Createtime,FinalY,Finalman,")
                            SqlItemStr.Append(" Finaltime,Factory,profitcenter,ParentMo, VERSION, SeriesID,ORDERNO,Orderseq,DeliveryDate,ScheFinishDate,PO,CreateAPID)")
                            SqlItemStr.Append(" VALUES('" & dr.Cells(enumdgMOData.MOID).Value & "','" & dr.Cells(enumdgMOData.PartID).Value & "','" & CboCustID.SelectedItem.ToString.Split("(")(0) & "',")
                            SqlItemStr.Append("'" & dr.Cells(enumdgMOData.Deptid).Value & "','" & dr.Cells(enumdgMOData.Lineid).Value & "','" & dr.Cells(enumdgMOData.MOqty).Value & "',")
                            SqlItemStr.Append("'" & dr.Cells(enumdgMOData.Typeid).Value & "','5',")
                            SqlItemStr.Append(" getdate(),'" & SysMessageClass.UseId.ToLower & "',getdate(),'N',NULL,NULL,")
                            SqlItemStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & profitcenter & "',")
                            SqlItemStr.Append(" '" & IIf(TxtErpParentMo.Text.Trim = "", TxtparentMo.Text, TxtErpParentMo.Text) & "', '" & GetPnVersionByInputMo() & "'")
                            SqlItemStr.Append(" , '" & CboSerialID.SelectedValue & "', '" & dr.Cells(enumdgMOData.OrderNo).Value & "'")
                            SqlItemStr.Append(" , '" & dr.Cells(enumdgMOData.OrderSeq).Value & "'")
                            SqlItemStr.Append(" , '" & dr.Cells(enumdgMOData.DeliveryDate).Value & "', '" & dr.Cells(enumdgMOData.ScheFinishDate).Value & "','" & dr.Cells(enumdgMOData.PO).Value.ToString & "','FrmWorkSheet-New')")
                            SqlItemStr.Append(" End ")
                            Using dt As DataTable = GetChildPnByCurrentMoPn(dr.Cells(enumdgMOData.PartID).Value)
                                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                                    'TAvcPart, PAvcPart, version
                                    For Each drChild As DataRow In dt.Rows
                                        strItemNum = Microsoft.VisualBasic.Right(drChild.Item("TAvcPart").ToString, Len(drChild.Item("TAvcPart").ToString) - InStr(drChild.Item("TAvcPart").ToString, "-"))
                                        ''截取料号后面的数字，会存在子工单重复，直接叠加子料号--by hs ke 20171011
                                        'strChildMoid = dr.Cells(enumdgMOData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(2, "0")

                                        strChildMoid = dr.Cells(enumdgMOData.MOID).Value + "_" + drChild.Item("TAvcPart").ToString
                                        SqlItemStr.Append(" If NOT EXISTS ( SELECT TOP 1 1 FROM m_Mainmo_t  WHERE moid ='" & strChildMoid & "')")
                                        SqlItemStr.Append(" Begin ")
                                        SqlItemStr.Append(" INSERT INTO M_MainMO_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,VERSION,ORDERNO,ORDERSeq,SeriesID,DeliveryDate,ScheFinishDate,CreateAPID)").Append(vbNewLine)
                                        SqlItemStr.Append(" SELECT '" & strChildMoid & "','" & drChild.Item("TAvcPart").ToString & "',DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID")
                                        SqlItemStr.Append(",CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,'" & drChild.Item("VERSION").ToString & "',ORDERNO,ORDERSeq,SeriesID,DeliveryDate,ScheFinishDate,'FrmWorkSheet-New'")
                                        SqlItemStr.Append(" FROM m_MainMO_t WHERE MOID='" & dr.Cells(enumdgMOData.MOID).Value & "'").Append(vbNewLine)
                                        SqlItemStr.Append(" End ")
                                    Next
                                End If
                            End Using
                        Next
                    End If

                    DbOperateUtils.ExecSQL(SqlItemStr.ToString)
                    SetStatus(0) 'Add by cq 20160106
                    MessageUtils.ShowInformation("工单资料保存成功")
                    Exit Sub
                End If
                ' Save auto download from TT 
                For Each Row As DataGridViewRow In DgMoData.Rows
                    If Row.Index = DgMoData.Rows.Count Then Exit For
                    If Row.Cells(enumdgMOData.MOID).Value Is Nothing Then Exit Sub
                    If Not Row.Cells(enumdgMOData.iSelect).FormattedValue Is Nothing AndAlso Row.Cells(enumdgMOData.iSelect).FormattedValue.ToString = "True" Then
                        Me.TxtErpParentMo.Text = Row.Cells(enumdgMOData.MOID).Value
                        If Not BaseDataCheckForAuto(Row) Then
                            Exit Sub
                        End If

                        Dim cus As String = Nothing
                        If CboCustID.Text Is Nothing Then
                            cus = ""
                        Else
                            cus = CboCustID.SelectedValue
                        End If

                        'If String.IsNullOrEmpty(Row.Cells(enumdgMOData.Cust).Value) Then
                        '    'do nothing
                        'Else
                        '    cus = Row.Cells(enumdgMOData.Cust).Value.ToString.Split("--")(0)
                        'End If

                        Dim series As String = Nothing
                        If CboSerialID.Text Is Nothing Then
                            series = ""
                        Else
                            series = CboSerialID.SelectedValue
                        End If

                        Dim partID_SFB05 As String = Row.Cells(enumdgMOData.PartID).Value

                        '没有数据才下载，有数据不下载资料
                        If MOComBusiness.IsHavePartContrast(partID_SFB05) = False Then
                            Dim errorMsg As String = Nothing
                            If MOComBusiness.DownloadBom(partID_SFB05, errorMsg) = False Then
                                Me.LblMsg.Text = errorMsg
                                Exit Sub
                            End If
                        End If

                        '************************** 田玉琳 20181227 开始 **************************
                        '针对所有新产品，第一次生产PQE需在系统内维护30天每日柏拉图
                        SqlItemStr.Append(" IF NOT EXISTS(SELECT 1 FROM m_PartContrast_t WHERE TAvcPart='" & partID_SFB05 &
                                               "' AND intime < GETDATE()-1 " & MOComBusiness.GetPartFatory & " )  ")
                        SqlItemStr.Append(" BEGIN  ")
                        SqlItemStr.Append(" IF NOT EXISTS(SELECT Partid FROM m_AssyTsProcssCheckPartId WHERE Partid='" & partID_SFB05 & "' AND TYPE = 'D' )  ")
                        SqlItemStr.Append(" BEGIN  ")
                        SqlItemStr.AppendFormat("   INSERT INTO m_AssyTsProcssCheckPartId(PartId, TYPE, ValidStartDate, ValidEndDate, IsValid, Remark, UserId, InTime) " &
                                                "   VALUES('{0}','D',convert(VARCHAR(10),getdate(),111),convert(VARCHAR(10),getdate()+30,111), 'Y',N'FrmWorkSheet-TT'," &
                                                "   '{1}',getdate()) ", partID_SFB05, UseId)
                        SqlItemStr.Append(" END  ")
                        SqlItemStr.Append(" END  ")
                        '************************** 田玉琳 20181227 结束 **************************

                        SqlItemStr.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_AssysnD_t WHERE moid='" & Row.Cells(enumdgMOData.MOID).Value.ToString & "')")
                        SqlItemStr.Append(" BEGIN ")
                        SqlItemStr.Append("     DELETE FROM m_Mainmo_t WHERE moid='" & Row.Cells(enumdgMOData.MOID).Value & "'").Append(vbNewLine)
                        SqlItemStr.Append(" END ").Append(vbNewLine)

                        SqlItemStr.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_Mainmo_t WHERE moid='" & Row.Cells(enumdgMOData.MOID).Value.ToString & "' and Factory='" & VbCommClass.VbCommClass.Factory & "' and profitcenter= '" & profitcenter & "' )")
                        'Insert 主工单,add download 订单编号、订单项次、订单预计交货日期、工单预计结束生产日期,cq20151206
                        SqlItemStr.Append("INSERT INTO m_Mainmo_t(Moid,PartID,Cusid,Deptid,lineid,Moqty")
                        SqlItemStr.Append(",Typeid,EstateID,Plandate,Createuser,Createtime,FinalY,Finalman,Finaltime,Factory,profitcenter")
                        SqlItemStr.Append(" ,ParentMo, VERSION,SeriesID,ORDERNO,Orderseq,DeliveryDate,ScheFinishDate,PO,CreateAPID)")
                        SqlItemStr.Append(" VALUES('" & Row.Cells(enumdgMOData.MOID).Value & "','" & Row.Cells(enumdgMOData.PartID).Value & "','" & cus & "',")
                        SqlItemStr.Append("'" & Row.Cells(enumdgMOData.Deptid).Value & "','" & Row.Cells(enumdgMOData.Lineid).Value & "','" & Row.Cells(enumdgMOData.MOqty).Value & "',")
                        SqlItemStr.Append("'" & Row.Cells(enumdgMOData.Typeid).Value & "','5',")
                        SqlItemStr.Append(" getdate(),'" & SysMessageClass.UseId.ToLower & "',getdate(),'N',NULL,NULL,")
                        SqlItemStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & profitcenter & "',")
                        SqlItemStr.Append(" '" & IIf(TxtErpParentMo.Text.Trim = "", TxtparentMo.Text, TxtErpParentMo.Text) & "', '" & Row.Cells(enumdgMOData.Version).Value & "',")
                        SqlItemStr.Append(" '" & IIf(String.IsNullOrEmpty(Row.Cells(enumdgMOData.Series).Value), series, Row.Cells(enumdgMOData.Series).Value) & "','" & Row.Cells(enumdgMOData.OrderNo).Value & "',")
                        SqlItemStr.Append(" '" & Row.Cells(enumdgMOData.OrderSeq).Value & "','" & Row.Cells(enumdgMOData.DeliveryDate).Value & "','" & Row.Cells(enumdgMOData.ScheFinishDate).Value & "','" & Row.Cells(enumdgMOData.PO).Value & "','FrmWorkSheet-TT')")

                        Using dt As DataTable = GetChildPnByCurrentMoPn(Row.Cells(enumdgMOData.PartID).Value)
                            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                                For Each drChild As DataRow In dt.Rows
                                    'L01D3008-YT-R1, L01D5002-R1
                                    strItemNum = Microsoft.VisualBasic.Right(drChild.Item("TAvcPart").ToString, Len(drChild.Item("TAvcPart").ToString) - InStr(drChild.Item("TAvcPart").ToString, "-"))
                                    'If Not String.IsNullOrEmpty(ItemSeq) AndAlso ItemSeq = strItemNum Then
                                    '    'maybe repeat
                                    '    strChildMoid = Row.Cells(enumdgMOData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(3, "0")
                                    'Else
                                    '    strChildMoid = Row.Cells(enumdgMOData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(2, "0")
                                    'End If
                                    ''截取料号后面的数字，会存在子工单重复，直接叠加子料号--by hs ke 20171011
                                    'strChildMoid = Row.Cells(enumdgMOData.MOID).Value + "_" + drChild.Item("TAvcPart").ToString
                                    'ItemSeq = strItemNum
                                    strChildMoid = Row.Cells(enumdgMOData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(2, "0")


                                    SqlItemStr.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_AssysnD_t WHERE moid='" & strChildMoid & "')")
                                    SqlItemStr.Append(" BEGIN ")
                                    SqlItemStr.Append("     DELETE FROM m_Mainmo_t WHERE moid='" & strChildMoid & "'").Append(vbNewLine)
                                    SqlItemStr.Append(" END ").Append(vbNewLine)

                                    SqlItemStr.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_Mainmo_t WHERE moid='" & strChildMoid & "' and Factory='" & VbCommClass.VbCommClass.Factory & "'and profitcenter= '" & profitcenter & "')")
                                    SqlItemStr.Append(" INSERT INTO M_MainMO_T(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,")
                                    SqlItemStr.Append(" VERSION,ORDERNO,SeriesID,Orderseq,DeliveryDate,ScheFinishDate,CreateAPID)").Append(vbNewLine)
                                    SqlItemStr.Append(" SELECT '" & strChildMoid & "','" & drChild.Item("TAvcPart").ToString & "',DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID")
                                    SqlItemStr.Append(",CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,'" & drChild.Item("version").ToString & "',ORDERNO,SeriesID")
                                    SqlItemStr.Append(",Orderseq,DeliveryDate,ScheFinishDate,'FrmWorkSheet-TT'")
                                    SqlItemStr.Append(" FROM m_MainMO_t WHERE MOID='" & Row.Cells(enumdgMOData.MOID).Value & "'").Append(vbNewLine)
                                Next
                            End If
                        End Using
                    End If
                Next

                If SqlItemStr.ToString = "" Then Exit Sub
                Try
                    DbOperateUtils.ExecSQL(SqlItemStr.ToString)
                    MessageBox.Show("工单资料保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetStatus(0)
                    Dim FiterSqlStr As String = GetFiterString()

                    If FiterSqlStr = "" Then
                        TlelCount.Text = "0"
                        Exit Sub
                    End If
                    LoadDataInGrid(FiterSqlStr)
                    Exit Sub
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End Try
            Else
                Try
                    If Not BaseDataEditCheck() Then
                        Exit Sub
                    End If

                    '检查已包装数量
                    If VbCommClass.VbCommClass.Factory = "BZLANTO" OrElse factoryList.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                        '出现开工单线别发现变更现象
                        strSQL = " UPDATE m_Mainmo_t SET Moqty='" & Me.TxtMoQty.Text.Trim & "' " & _
                                 " ,PO =N'" & Me.txtPO.Text.Trim & "', PARENTMO = '" & Me.TxtparentMo.Text.Trim & "' " & _
                                 " ,Cusid =N'" & CboCust.SelectedValue & "',Remark=N'" & Me.txtRemark.Text.Trim & "' , Factory = '" & Trim(CobFactory.SelectedValue) & "' " & _
                                 " ,Deptid =N'" & Trim(CboDept.SelectedValue) & "', Lineid = '" & Trim(CboLine.SelectedValue) & "' " & _
                                 " ,SeriesID =N'" & Trim(CobSeries.SelectedValue) & "', OrderNo = '" & Me.txtOrderNo.Text.Trim & "' " & _
                                 " ,Orderseq =N'" & Me.txtOrderSeq.Text.Trim & "'" & _
                                 " ,DeliveryDate =N'" & dtDeliveryDate.Value.ToShortDateString & "', ScheFinishDate = '" & dtScheFinishDate.Value.ToShortDateString & "' " & _
                                 " WHERE MOID='" & Me.TxtMoNumber.Text.Trim.Replace("'", "''") & "' "
                    ElseIf VbCommClass.VbCommClass.Factory.Trim.ToUpper = "SUINING" Then
                        Dim strFacotry As String = ""
                        If String.IsNullOrEmpty(CobFactory.SelectedValue) Then
                            strFacotry = VbCommClass.VbCommClass.Factory
                        Else
                            strFacotry = CobFactory.SelectedValue
                        End If
                        strSQL = " UPDATE m_Mainmo_t SET Moqty='" & Me.TxtMoQty.Text.Trim & "' " & _
                              " ,Cusid =N'" & CboCust.SelectedValue & "',Remark=N'" & Me.txtRemark.Text.Trim & "'  " & _
                              " ,Deptid =N'" & Trim(CboDept.SelectedValue) & "', Lineid = '" & Trim(CboLine.SelectedValue) & "' " & _
                              " ,SeriesID =N'" & Trim(CobSeries.SelectedValue) & "', OrderNo = '" & Me.txtOrderNo.Text.Trim & "' " & _
                              " ,Orderseq =N'" & Me.txtOrderSeq.Text.Trim & "'" & _
                              " ,DeliveryDate =N'" & dtDeliveryDate.Value.ToShortDateString & "', ScheFinishDate = '" & dtScheFinishDate.Value.ToShortDateString & "',PO =N'" & Me.txtPO.Text.Trim & "' " & _
                              " WHERE MOID='" & Me.TxtMoNumber.Text.Trim.Replace("'", "''") & "' "
                        strSQL = strSQL + " UPDATE m_Mainmo_t SET Cusid =N'" & CboCust.SelectedValue & "',SeriesID =N'" & Trim(CobSeries.SelectedValue) & "' " & _
                                 " WHERE partid ='" & Me.txtPartNo.Text.Trim.Replace("'", "''") & "' "
                        'Me.TxtPartID.Text.Trim.Replace
                        strSQL = strSQL + " UPDATE m_PartContrast_t SET Cusid =N'" & CboCust.SelectedValue & "',SeriesID =N'" & Trim(CobSeries.SelectedValue) & "' " & _
                              " WHERE TAvcPart ='" & Me.txtPartNo.Text.Trim.Replace("'", "''") & "' " & MOComBusiness.GetPartFatory

                    Else

                        strSQL = " UPDATE m_Mainmo_t SET Moqty='" & Me.TxtMoQty.Text.Trim & "',SeriesID =N'" & Trim(CobSeries.SelectedValue) & "' " & _
                              " ,Cusid =N'" & CboCust.SelectedValue & "',Finalman='" & UseId & "',Finaltime=getdate(),Remark=N'" & Me.txtRemark.Text.Trim & "'  " & _
                              " ,Deptid =N'" & Trim(CboDept.SelectedValue) & "', Lineid = '" & Trim(CboLine.SelectedValue) & "' " & _
                              " ,PO =N'" & Me.txtPO.Text.Trim & "', PARENTMO = '" & Me.TxtparentMo.Text.Trim & "',PartID='" & Me.txtPartNo.Text.Trim & "', OrderNo = '" & Me.txtOrderNo.Text.Trim & "' ,Orderseq =N'" & Me.txtOrderSeq.Text.Trim & "' " & _
                             " WHERE MOID='" & Me.TxtMoNumber.Text.Trim.Replace("'", "''") & "'"

                        strSQL = strSQL + " INSERT Into m_MainmoLog_t([Moid],[Orderseq] ,[Tmoid]" & _
                                 " ,[PartID],[Cusid],[Deptid],[Lineid]" & _
                                 " ,[Moqty] ,[Outqty],[Notqty],[Scrapqty]" & _
                                 " ,[Ppidprtqty],[Pkgprtqty],[Typeid]" & _
                                 " ,[EstateID],[Routeid],[Plandate] ,[Createuser]" & _
                                 ",[Createtime],[FinalY],[Finalqty] ,[Remark]" & _
                                 " ,[Finalman],[Finaltime] ,[States] ,[Factory]" & _
                                 " ,[profitcenter],[IsLotOk],[ParentMo] ,[PpidprtCount]" & _
                                 " ,[PackingCount] ,[ProductReprintCount],[PackingReprintCount],[DemandInfo]" & _
                                 " ,[CHECKTEXT],[OldEstateID],[VERSION],[ORDERNO]" & _
                                 " ,[IsPrinted] ,[demandTime] ,[Status],[SeriesID]" & _
                                 " ,[DeliveryDate],[ScheFinishDate],[BlueprintVersion],[PackageVersion]" & _
                                 ",[PO] ,[StartUserId] ,[StartTime],[EndUserId]" & _
                                 " ,[EndTime],[InspectionQuantity],[ActualDate],[PPartID]" & _
                                 " ,[ChangeUserID],[ChangeTime]) " & _
                                 " SELECT [Moid],[Orderseq] ,[Tmoid]" & _
                                 " ,[PartID],[Cusid],[Deptid],[Lineid]" & _
                                 " ,[Moqty] ,[Outqty],[Notqty],[Scrapqty]" & _
                                 " ,[Ppidprtqty],[Pkgprtqty],[Typeid]" & _
                                 " ,[EstateID],[Routeid],[Plandate] ,[Createuser]" & _
                                 ",[Createtime],[FinalY],[Finalqty] ,'" & OldPartID & "'" & _
                                 " ,[Finalman],[Finaltime] ,[States] ,[Factory]" & _
                                 " ,[profitcenter],[IsLotOk],[ParentMo] ,[PpidprtCount]" & _
                                 " ,[PackingCount] ,[ProductReprintCount],[PackingReprintCount],[DemandInfo]" & _
                                 " ,[CHECKTEXT],[OldEstateID],[VERSION],[ORDERNO]" & _
                                 " ,[IsPrinted] ,[demandTime] ,[Status],[SeriesID]" & _
                                 " ,[DeliveryDate],[ScheFinishDate],[BlueprintVersion],[PackageVersion]" & _
                                 ",[PO] ,[StartUserId] ,[StartTime],[EndUserId]" & _
                                 " ,[EndTime],[InspectionQuantity],[ActualDate],[PPartID]," & _
                                 " '" & UseId & "', getdate() FROM m_mainmo_t where MOID='" & Me.TxtMoNumber.Text.Trim.Replace("'", "''") & "' "
                    End If
                    DbOperateUtils.ExecSQL(strSQL)
                    MessageUtils.ShowInformation("保存成功！")

                    Me.TxtMoNo.Text = Me.TxtMoNumber.Text.Trim
                    Dim FiterSqlStr As String = GetFiterString()

                    If FiterSqlStr = "" Then
                        TlelCount.Text = "0"
                        Exit Sub
                    End If
                    LoadDataInGrid(FiterSqlStr)
                    SetStatus(0)
                    SetControl()
                Catch ex As Exception
                    MessageUtils.ShowError("编辑工单异常，请联系开发人员！")
                End Try
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '退出
    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub


#End Region


#Region "方法"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim lsSQL As String = ""

        If ColComboBox.Name = "CboDept" Then
            UserDg = VbCommClass.CommClass.GetUserDeptDt()
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "djc", "deptid")
        ElseIf ColComboBox.Name = "CboCustID" Or ColComboBox.Name = "CboCust" Then
            lsSQL = "SELECT (CusID + '--' + CusName) CustName,CusID FROM m_Customer_t order by CusID"
            UserDg = DbOperateUtils.GetDataTable(lsSQL)
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "CustName", "CusID")
            'UIFunction.Fill_Combobox(UserDg, ColComboBox)
        ElseIf ColComboBox.Name = "CboLine" Then
            'UserDg = DbOperateUtils.GetDataTable("SELECT distinct lineid,lineid from Deptline_t where deptid='" & CboDept.SelectedValue & "' order by Deptline_t.lineid ")
            'UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "lineid", "lineid")
            Dim deptid As String = ""
            If CboDept.SelectedValue IsNot Nothing Then
                deptid = CboDept.SelectedValue.ToString()
            End If
            UserDg = VbCommClass.CommClass.GetDeptLineDt(deptid) ' DbOperateUtils.GetDataTable("Select  lineid,lineid from Deptline_t where deptid='" & deptid & "'")
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "lineid", "lineid")

        ElseIf ColComboBox.Name = "CobFactory" Then
            If (VbCommClass.VbCommClass.IsConSap = "Y") Then
                lsSQL = " SELECT factoryid,shortname FROM m_Factory_t WHERE factoryid='" & VbCommClass.VbCommClass.Factory & "'"
            Else
                lsSQL = " SELECT factoryid,shortname FROM m_Dcompany_t WHERE factoryid='" & VbCommClass.VbCommClass.Factory & "'"
            End If

            UserDg = DbOperateUtils.GetDataTable(lsSQL) 'Select  factoryid,shortname from m_Dcompany_t
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "shortname", "factoryid")
        ElseIf ColComboBox.Name = "ComMoType" Or ColComboBox.Name = "CboMoType" Then
            If VbCommClass.VbCommClass.Factory = "BZLANTO" Then 'hzf BZ工单对应显示不同
                UserDg = DbOperateUtils.GetDataTable("Select  (typeid + '--' + motype) motype ,typeid from motype_t order by cast(typeid as int) ")
            Else
                UserDg = DbOperateUtils.GetDataTable("Select  (typeid + '--' + motype) motype ,typeid from motype_t order by cast(typeid as int)")
            End If
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "motype", "typeid")

        ElseIf ColComboBox.Name = "CboSerialID" Or ColComboBox.Name = "CobSeries" Then
            UserDg = DbOperateUtils.GetDataTable(" SELECT [SeriesID], (SeriesID+'--'+SeriesName) as SeriesName  FROM [m_Series_t] WHERE Usey='Y'")
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "SeriesName", "SeriesID")
        ElseIf ColComboBox.Name = "cobLineQuery" Then
            Dim sql As String = "SELECT distinct lineid,lineid from Deptline_t A JOIN m_Dept_t B ON A.deptid=B.deptid where B.FACTORYID='" & VbCommClass.VbCommClass.PCompany & "'"
            If Not String.IsNullOrEmpty(profitcenter) Then
                sql = sql + " and b.profitcenter='" & profitcenter & "'"
            End If
            sql = sql + " order by a.lineid "
            UserDg = DbOperateUtils.GetDataTable(sql)
            UIFunction.BindComboxNoBlank(UserDg, ColComboBox, "lineid", "lineid")
        End If
        UserDg = Nothing
    End Sub

    '查询语名
    Private Sub LoadDataInGrid(ByVal FiterSqlStr)
        Dim K As Integer
        Dim UserDg As DataTable
        Dim Sqlstr As String
        Dim Flagstr As Boolean

        DgMoData.Rows.Clear()
        DgMoData.ScrollBars = ScrollBars.None
        Sqlstr = "SELECT TOP 100 a.moid, a.partid, (a.cusid+'--'+cus.CusName)cusid, " & _
                 " (a.SeriesID +'--' + ser.SeriesName)SeriesID,a.Lineid, a.moqty,a.PO, a.typeid, a.EstateID," & _
                 " a.ORDERNO, a.Orderseq, a.DeliveryDate, a.ScheFinishDate," & _
                 " b.motype,c.statename,custpart, a.version as MOVERSION,a.ParentMo," & _
                 " d.cusname,ISNULL(d.TavcPart,'') as TavcPart,d.TypeDest,m_Dept_t.djc, a.deptid,a.Finalman,a.Finaltime,a.Remark " & _
                " FROM m_Mainmo_t a " & _
                " LEFT JOIN motype_t b on a.typeid=b.typeid LEFT JOIN mostate c on a.EstateID=c.stateid" & _
                " LEFT JOIN (SELECT a.*,b.cusname from  m_PartContrast_t a JOIN  m_Customer_t b on a.cusid=b.cusid and a.TAvcPart=a.PAvcPart) d on a.partid=d.pavcpart AND A.Factory = D.Factory " & _
                " LEFT JOIN m_Dept_t on m_Dept_t.deptid=a.Deptid " & _
                " LEFT JOIN dbo.m_Customer_t cus ON  a.CusID = cus.CusID" & _
                " LEFT JOIN dbo.m_Series_t ser ON  a.SeriesID = ser.SeriesID"

        UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr)

        For K = 0 To UserDg.Rows.Count - 1
            Try
                If UserDg.Rows(K)("PartID") <> UserDg.Rows(K)("TavcPart") Then
                    Flagstr = True
                End If

                'iSelect, 工单编号,料件编号,(客户), (系列), 品名,生产部门,生产线别,工单数量,工单类型,工单状态,订单编号,订单项次, Version, 订单预计交货日期、工单预计结束生产日期
                DgMoData.Rows.Add(False, UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), _
                                   UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("SeriesID"), _
                                   UserDg.Rows(K)("TypeDest"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("Lineid"), _
                                   UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("PO"), UserDg.Rows(K)("typeid") & "--" & UserDg.Rows(K)("motype"), _
                                   UserDg.Rows(K)("EstateID") & "--" & UserDg.Rows(K)("statename"), _
                                   UserDg.Rows(K)("ORDERNO"), UserDg.Rows(K)("Orderseq"), UserDg.Rows(K)("MOVERSION"), _
                                   UserDg.Rows(K)("DeliveryDate"), UserDg.Rows(K)("ScheFinishDate"), _
                                   UserDg.Rows(K)("ParentMo"), UserDg.Rows(K)("deptid"), UserDg.Rows(K)("motype"), UserDg.Rows(K)("Finalman"), UserDg.Rows(K)("Finaltime"), UserDg.Rows(K)("Remark")
                                   )

            Catch ex As Exception
                Continue For
            End Try
        Next

        DgMoData.ScrollBars = ScrollBars.Both
        TlelCount.Text = UserDg.Rows.Count
        UserDg.Dispose()
    End Sub

    Private Sub InitControl(ByVal row As DataGridViewRow)
        Try
            TxtMoNumber.Text = row.Cells(enumdgMOData.MOID).Value.ToString
            txtPartNo.Text = row.Cells(enumdgMOData.PartID).Value.ToString
            txtOrderNo.Text = row.Cells(enumdgMOData.OrderNo).Value.ToString
            txtOrderSeq.Text = row.Cells(enumdgMOData.OrderSeq).Value.ToString
            txtPO.Text = row.Cells(enumdgMOData.PO).Value.ToString
            CboCust.SelectedIndex = CboCust.FindString(row.Cells(enumdgMOData.Cust).Value.ToString)
            TxtMoQty.Text = row.Cells(enumdgMOData.MOqty).Value.ToString
            TxtparentMo.Text = row.Cells(enumdgMOData.ParentMo).Value.ToString
            CobFactory.Enabled = True
            CobFactory.SelectedIndex = 0
            FillCombox(CboDept)
            CboDept.Enabled = True
            CboDept.SelectedIndex = CboDept.FindString(row.Cells(enumdgMOData.Dept).Value.ToString)
            FillCombox(CboLine)
            CboLine.Enabled = True
            CboLine.SelectedIndex = CboLine.FindString(row.Cells(enumdgMOData.Lineid).Value.ToString)
            ComMoType.Enabled = True
            ComMoType.SelectedIndex = ComMoType.FindString(row.Cells(enumdgMOData.Typeid).Value.ToString)
            CobSeries.SelectedIndex = CobSeries.FindString(row.Cells(enumdgMOData.Series).Value.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QueryDataToGrid()
        Dim o_dtPartCount As New DataTable, o_dtCusSerID As New DataTable
        Dim o_strCustID As String = "", o_strSeriesID As String = ""
        Me.CboCustID.Text = ""
        Me.CboSerialID.Text = ""
        Try
            DgMoData.Rows.Clear()
            If TxtMoNo.Text.Trim = "" Then
                LblMsg.Text = "工单编号不能为空..."
                Exit Sub
            End If


            '20200626 田玉琳 判断如果没有权限下载退出
            If IsHaveProfitAuth() = False Then
                Exit Sub
            End If

            '连接到SAP
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                'o_dtPartCount = OracleOperateUtils.GetDataTableSap(SapCommon.GetSql2ErpSap(TxtMoNo.Text, profitcenter))
                o_dtPartCount = DbOperateUtils.GetDataTable(SapCommon.GetSql2ErpSap(TxtMoNo.Text, profitcenter))
            Else
                o_dtPartCount = OracleOperateUtils.GetDataTable(SapCommon.GetSql2Erp(TxtMoNo.Text, profitcenter))
            End If


            If o_dtPartCount.Rows.Count > 0 Then
                If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    Dim sFactory As String = o_dtPartCount.Rows(0).Item("werks").ToString
                    If sFactory <> VbCommClass.VbCommClass.Factory Then
                        Dim msg As String = "登录工厂代码" + VbCommClass.VbCommClass.Factory + "与查询工单" & Me.TxtMoNo.Text.Trim() &
                                            "工厂代码" + sFactory + "不一致，请确认或者切换登录工厂"
                        LblMsg.Text = msg
                        Me.TxtMoNo.Text = ""
                        Exit Sub
                    End If
                End If

                For i As Byte = 0 To o_dtPartCount.Rows.Count - 1
                    If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
                        MOComBusiness.GetCustIDFromMES(o_dtPartCount.Rows.Item(i)("sfb05").ToString, o_strCustID, o_strSeriesID)
                        Me.CboCustID.SelectedIndex = Me.CboCustID.FindString(o_strCustID)
                        '判断是否线别是否存在,不存在则提示信息
                        Try
                            Dim lsSQL As String = " select * from deptline_t where lineid='" & o_dtPartCount.Rows.Item(i)("sfb82").ToString & "' "
                            Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                            Else
                                LblMsg.Text += "当前线别不存在,请修改维护;"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                    ''iSelect, 工单编号, 料件编号, 品名, 生产部门, 生产线别, 工单数量, 工单类型, 工单状态, 订单编号sfb22, 订单项次sfb221, Version, 
                    ''订单预计交货日期, 工单预计结束生产日期
                    Me.DgMoData.Rows.Add(False, o_dtPartCount.Rows.Item(i)("sfb01").ToString, o_dtPartCount.Rows.Item(i)("sfb05").ToString, "", "", _
                                     o_dtPartCount.Rows.Item(i)("partname").ToString, o_dtPartCount.Rows.Item(i)("tc_imc03").ToString, _
                                     o_dtPartCount.Rows.Item(i)("sfb82").ToString, o_dtPartCount.Rows.Item(i)("sfb08").ToString, o_dtPartCount.Rows.Item(i)("OEA10"), _
                                     o_dtPartCount.Rows.Item(i)("sfb02").ToString, o_dtPartCount.Rows.Item(i)("sfb04").ToString, _
                                     o_dtPartCount.Rows.Item(i)("sfb22").ToString,
                       o_dtPartCount.Rows.Item(i)("sfb221").ToString,
                       GetVersion(o_dtPartCount.Rows.Item(i)("IMA021").ToString),
                       o_dtPartCount.Rows.Item(i)("oeb15"),
                       o_dtPartCount.Rows.Item(i)("sfb15")
                                     )

                    '自动选择数据库工单类型 关晓艳 2018/11/26
                    Dim typeid As String = o_dtPartCount.Rows.Item(0)("sfb02").ToString
                    If String.IsNullOrEmpty(typeid) Then
                        LblMsg.Text = "工单类型不能为空, 请先在Tiptop中维护!.."
                    Else
                        Me.CboMoType.SelectedIndex = Me.CboMoType.FindString(typeid)
                    End If

                    Dim partID As String = o_dtPartCount.Rows.Item(i)("sfb05").ToString

                    If VbCommClass.VbCommClass.Factory = "LX53" Then
                        GetCustSeries(partID, Me.DgMoData.Rows(i))
                    Else
                        '先by主料号查MES DB的客户、系列别，查不到再查TT，还查不到，再自己选。
                        If Me.CboCustID.Text = "" Then
                            Dim dt As DataTable = CommClass.GetPartCusIdSeriIDDt(partID)
                            If (dt.Rows.Count = 0) Then
                                LblMsg.Text = "料件对应客户/系列别不存在,请找PQE在SPC中【物料客户别/系列别】维护！"
                                Exit Sub
                            End If

                            o_strCustID = dt.Rows(0)("CusID").ToString
                            o_strSeriesID = dt.Rows(0)("SeriesID").ToString
                            Me.CboCustID.SelectedIndex = Me.CboCust.FindString(o_strCustID)
                            Me.CboSerialID.SelectedIndex = Me.CboSerialID.FindString(o_strSeriesID)
                        End If
                    End If
                Next
                m_blnErpSave = True
                opFlag = 1 'New save
                ToolSave.Enabled = True
            Else
                LblMsg.Text = "工单编号在ERP中不存在..."
            End If

        Catch ex As Exception
            Throw ex
        Finally
            o_dtPartCount.Dispose()
            o_dtCusSerID.Dispose()
        End Try
    End Sub

    '确认是否有利润中心权限
    Private Function IsHaveProfitAuth() As Boolean
        Dim strSQL As String = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150)" &
                               " EXEC GetCheckUserRightMoid '{0}','{1}','{2}',1,@strmsgid OUTPUT ,@strmsgText OUTPUT " &
                               " SELECT @strmsgid,@strmsgText"
        strSQL = String.Format(strSQL, SysMessageClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0) = "1" Then
                LblMsg.Text = dt.Rows(0)(1).ToString
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub GetCustSeries(ByVal pn As String, ByVal dr As DataGridViewRow)

        Try
            Dim SQL As String = "SELECT QCD01,TA_QCD09 CRESULT,'CUST'  CNAME FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & vbNewLine & _
            " WHERE QCD01='" & pn & "' AND TA_QCD09 IS NOT NULL AND ROWNUM=1" & vbNewLine & _
            " UNION" & vbNewLine & _
            " SELECT QCD01,TA_QCD10 CRESULT,'SERIES' CNAME FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & vbNewLine & _
            " WHERE QCD01='" & pn & "' AND TA_QCD10 IS NOT NULL AND ROWNUM=1"
            Using dt As DataTable = MoComDB.GetErpData(SQL)
                If dt.Rows.Count > 0 Then
                    For Each drOW As DataRow In dt.Rows
                        If drOW("CNAME") = "CUST" Then
                            dr.Cells(enumdgMOData.Cust).Value = drOW("CRESULT")
                        End If
                        If drOW("CNAME") = "SERIES" Then
                            dr.Cells(enumdgMOData.Series).Value = drOW("CRESULT")
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetVersion(ByVal version As String) As String
        Dim arr() As String
        arr = version.Split("-")
        If arr.Length > 1 Then
            If arr(arr.Length - 1).Length > 5 Then Return ""
            Return arr(arr.Length - 1)
        End If
        Return ""
    End Function


    Private Function CobTextInstr(ByVal MoComBox As ComboBox) As String
        If MoComBox.Text = "" Then
            CobTextInstr = ""
            Exit Function
        End If
        Dim I As Integer = InStr(MoComBox.Text.Trim, "-")
        Dim LineStr As String = MoComBox.Text.Substring(0, I - 1)
        CobTextInstr = LineStr
    End Function

    Private Function GetFiterString() As String

        Dim SqlStr As String = ""
        Dim MoComBoxStr As String = ""
        Dim o_strMultiMOSQL As String = ""
        Dim o_DeptPCompany As String = ""
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            o_DeptPCompany = VbCommClass.VbCommClass.PCompany
        Else
            o_DeptPCompany = VbCommClass.VbCommClass.Factory
        End If

        If TxtMoNo.Text.Trim <> "" Then
            For Each sMO As String In TxtMoNo.Text.Trim.Split(vbNewLine)
                If Not String.IsNullOrEmpty(sMO) Then
                    o_strMultiMOSQL &= " A.MOID LIKE '%" & sMO.Trim() & "%'" + " OR"
                End If
            Next

            o_strMultiMOSQL = o_strMultiMOSQL.Substring(0, o_strMultiMOSQL.Length - 3)

            SqlStr = " WHERE " & o_strMultiMOSQL
        End If

        If TxtPartID.Text.Trim <> "" And UCase(TxtPartID.Text.Trim) <> "ALL" Then
            If SqlStr = "" Then
                SqlStr = " WHERE a.PartID like '%" & TxtPartID.Text & "%'"
            Else
                SqlStr = SqlStr & " AND a.PartID LIKE '%" & TxtPartID.Text & "%'"
            End If
        End If

        If cobLineQuery.Text <> "" Then
            If SqlStr = "" Then
                SqlStr = " WHERE a.LINEID ='" & cobLineQuery.Text & "'"
            Else
                SqlStr = SqlStr & " AND a.LINEID ='" & cobLineQuery.Text & "'"
            End If
        End If

        If UCase(CboMoType.Text.Trim) <> "ALL" And UCase(CboMoType.Text.Trim) <> "" Then
            MoComBoxStr = CobTextInstr(CboMoType)
            If SqlStr = "" Then
                SqlStr = " WHERE A.TYPEID='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " AND A.TYPEID='" & MoComBoxStr & "'"
            End If
        End If
        If DtpCreatDate.Checked = True Then
            If SqlStr = "" Then
                If DtMoStart.Checked = True Then
                    SqlStr = " WHERE CONVERT(datetime,CONVERT(varchar(10), createtime,120)) between '" & DtMoStart.Value.ToShortDateString & "' and '" & DtpCreatDate.Value.ToShortDateString & "'"
                Else
                    SqlStr = " WHERE CONVERT(datetime,CONVERT(varchar(10), createtime,120))<='" & DtpCreatDate.Value.ToShortDateString & "'"
                End If
            Else
                If DtMoStart.Checked = True Then
                    SqlStr = SqlStr & " AND CONVERT(datetime,CONVERT(varchar(10), createtime,120)) between '" & DtMoStart.Value.ToShortDateString & "' and '" & DtpCreatDate.Value.ToShortDateString & "'"
                Else
                    SqlStr = SqlStr & " AND CONVERT(datetime,CONVERT(varchar(10), createtime,120))<='" & DtpCreatDate.Value.ToShortDateString & "'"
                End If
            End If
        Else
            If DtMoStart.Checked = True Then
                If SqlStr = "" Then
                    SqlStr = " WHERE CONVERT(datetime,CONVERT(varchar(10), createtime,120))>='" & DtMoStart.Value.ToShortDateString & "'"
                Else
                    SqlStr = SqlStr & " AND CONVERT(datetime,CONVERT(varchar(10), createtime,120))>='" & DtMoStart.Value.ToShortDateString & "'"
                End If
            End If
        End If

        If SqlStr = "" Then
            SqlStr = " WHERE a.Factory='" & VbCommClass.VbCommClass.Factory & "'"
        Else
            SqlStr = SqlStr + " AND a.Factory='" & VbCommClass.VbCommClass.Factory & "'"
        End If
        If Not String.IsNullOrEmpty(profitcenter) Then
            SqlStr = SqlStr + " AND A.PROFITCENTER='" & profitcenter & "'"
        End If

        If SqlStr = "" Then
            SqlStr = " Where m_Dept_t.FactoryID ='" & o_DeptPCompany & "'"
        Else
            SqlStr = SqlStr + " AND m_Dept_t.FactoryID='" & o_DeptPCompany & "'"
        End If

        Return SqlStr + "  ORDER BY CREATETIME DESC ,MOID ASC "

    End Function

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始狀態
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolCancel.Enabled = False
                Me.ToolSave.Enabled = False
                Me.ToolQueryMO.Enabled = True
                Me.TxtMoQty.Enabled = False
                Me.Panel1.Enabled = False
                Me.Panel2.Enabled = True

                Me.TxtMoNumber.Enabled = False
                Me.txtPartNo.Enabled = False
                Me.TxtMoQty.Enabled = False
                Me.CboCust.Enabled = False
                Me.CobFactory.Enabled = False
                Me.CboLine.Enabled = False
                Me.CboDept.Enabled = False
                Me.ComMoType.Enabled = False
                Me.TxtparentMo.Enabled = False
            Case 1      '新增
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = False
                Me.TxtMoQty.Enabled = False
                Me.Panel1.Enabled = True
                Me.Panel2.Enabled = False

                Me.TxtMoNumber.Enabled = True
                Me.txtPartNo.Enabled = True
                Me.TxtMoQty.Enabled = True
                Me.CboCust.Enabled = True
                Me.CobFactory.Enabled = True
                Me.CboLine.Enabled = True
                Me.CboDept.Enabled = True
                Me.ComMoType.Enabled = True
                Me.TxtparentMo.Enabled = True
            Case 2      '修改
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = False
                Me.TxtMoQty.Enabled = True
                Me.Panel1.Enabled = True
                Me.Panel2.Enabled = False

                Me.TxtMoNumber.Enabled = False
                Me.txtPartNo.Enabled = True
                Me.TxtMoQty.Enabled = True

                If VbCommClass.VbCommClass.Factory = "BZLANTO" OrElse VbCommClass.VbCommClass.Factory = "SUINING" Then
                    Me.CboCust.Enabled = True '
                    Me.CobFactory.Enabled = True '
                    Me.CboLine.Enabled = True '
                    Me.CboDept.Enabled = True '
                    Me.ComMoType.Enabled = True '
                    Me.TxtparentMo.Enabled = True '
                Else
                    Me.CboCust.Enabled = False
                    Me.CobFactory.Enabled = False
                    Me.CboLine.Enabled = False
                    Me.CboDept.Enabled = False
                    Me.ComMoType.Enabled = False
                    Me.TxtparentMo.Enabled = True
                End If

            Case 3
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = False
                Me.TxtMoQty.Enabled = True
                Me.Panel1.Enabled = True
                Me.Panel2.Enabled = False

                Me.TxtMoNumber.Enabled = False
                Me.txtPartNo.Enabled = True
                Me.TxtMoQty.Enabled = True
                Me.CboCust.Enabled = True
                Me.CobFactory.Enabled = True
                Me.CboLine.Enabled = True
                Me.CboDept.Enabled = True
                Me.ComMoType.Enabled = True
                Me.TxtparentMo.Enabled = True
        End Select
    End Sub

    Private Sub SetControl()
        TxtMoNumber.Clear()
        txtPartNo.Clear()
        txtPO.Clear()
        txtOrderNo.Clear()
        txtOrderSeq.Clear()
        TxtMoQty.Clear()
        TxtparentMo.Clear()
        CobFactory.SelectedIndex = -1
        CboCust.SelectedIndex = -1
        ComMoType.SelectedIndex = -1
        CboDept.SelectedIndex = -1
        CboLine.SelectedIndex = -1
        CobSeries.SelectedIndex = -1
    End Sub

    '基础检查 
    Private Function BaseDataCheck() As Boolean
        If Me.TxtMoNumber.Text = "" Then
            MessageUtils.ShowInformation("必须输入工单编号")
            TxtMoNumber.Focus()
            Return False
        End If
        If Me.TxtparentMo.Text.Trim = "" Then
            MessageUtils.ShowInformation("必须输入上级工单(包装站工单),如为成品工单则相同...")
            TxtparentMo.Focus()
            Return False
        End If

        If IsNothing(CboLine.SelectedValue) Then
            MessageUtils.ShowInformation("请先选择线别")
            CboLine.Focus()
            Return False
        End If

        If IsNothing(CboCust.SelectedValue) Then
            MessageUtils.ShowInformation("请先选择客户")
            CboCust.Focus()
            Return False
        End If

        If IsNothing(CobSeries.SelectedValue) Then
            MessageUtils.ShowInformation("请先选择系列别")
            CobSeries.Focus()
            Return False
        End If

        If IsNothing(ComMoType.SelectedValue) Then
            MessageUtils.ShowInformation("请先选择工单类型")
            ComMoType.Focus()
            Return False
        End If

        If factoryList.IndexOf(VbCommClass.VbCommClass.Factory) < 0 Then
            If String.IsNullOrEmpty(Me.txtOrderNo.Text) Then
                MessageUtils.ShowInformation("请先选择订单编号")
                txtOrderNo.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(Me.txtOrderSeq.Text) Then
                MessageUtils.ShowInformation("请先选择订单编号")
                txtOrderSeq.Focus()
                Return False
            End If

            If dtDeliveryDate.Checked = False Then
                MessageUtils.ShowInformation("请先选择订单预计交货日期")
                dtDeliveryDate.Select()
                Return False
            End If

            If dtScheFinishDate.Checked = False Then
                MessageUtils.ShowInformation("请先选择工单预计结束生产日期")
                dtScheFinishDate.Select()
                Return False
            End If
        Else
            If Me.txtPartNo.Text = "" Then
                MessageUtils.ShowInformation("必须输入料号")
                txtPartNo.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtPO.Text.Trim) Then
                Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(sql, txtPartNo.Text))
                    If dt.Rows.Count > 0 Then
                        MessageUtils.ShowInformation("工单" & TxtMoNumber.Text & "需要打印合同号,请输入合同号!")
                        Return False
                    Else
                        Return True
                    End If
                End Using
            End If
        End If
        Return True
    End Function

    '存在打印申请记录不能新增
    Private Function IsPrintCheck() As Boolean
        Dim strSQL As String = ""
        strSQL = "SELECT 1 FROM m_SnAssign_t  WHERE moid = '{0}'"
        strSQL = String.Format(strSQL, TxtMoNo.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            MessageUtils.ShowError(String.Format("工单号：{0}存在打印申请记录！不能新增", TxtMoNo.Text.Trim))
            Return False
        End If
        Return True
    End Function

    '编辑检查 
    Private Function BaseDataEditCheck() As Boolean
        If Me.DgMoData.Rows.Count = 0 OrElse Me.DgMoData.CurrentRow Is Nothing Then
            MessageBox.Show("请选择需要修改工单!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.TxtMoNumber.Text.Trim)) Then
            MessageBox.Show("工单不能为空!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.txtPartNo.Text.Trim)) Then
            MessageBox.Show("料件编号!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.TxtparentMo.Text.Trim)) Then
            MessageBox.Show("上级工单不能为空!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.CobFactory.Text.Trim)) AndAlso factoryList.IndexOf(VbCommClass.VbCommClass.Factory) > 0 Then
            MessageBox.Show("工厂名称不能为空!")
            Return False
        End If

        'Mark factory by cq 20180518, add LXXT,LXXN CHECK
        If (String.IsNullOrEmpty(Me.CboDept.Text.Trim)) Then 'AndAlso factory.IndexOf(Factory) > 0 Then
            MessageBox.Show("部门不能为空!")
            Return False
        End If

        'Mark factory by cq 20180518, add LXXT,LXXN CHECK
        If (String.IsNullOrEmpty(Me.CboLine.Text.Trim)) Then 'AndAlso factory.IndexOf(Factory) > 0 Then
            MessageBox.Show("线别不能为空!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.CboCust.Text.Trim)) Then
            MessageBox.Show("客户代码不能为空!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.ComMoType.Text.Trim)) Then
            MessageBox.Show("工单类型不能为空!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.TxtMoQty.Text.Trim())) Then
            MessageBox.Show("工单数量不能为空!")
            Return False
        Else
            If (CInt(Me.TxtMoQty.Text.Trim()) <= 0) Then
                MessageBox.Show("工单数量必须大于0!")
                Return False
            End If
        End If

        If factoryList.IndexOf(VbCommClass.VbCommClass.Factory) > 0 Then
            If String.IsNullOrEmpty(txtPO.Text.Trim) Then
                Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(sql, txtPartNo.Text))
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("工单" & TxtMoNumber.Text & "需要打印合同号,请输入合同号!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End Using
            End If
        End If
        Return True
    End Function

    Dim factoryList As String = "LX81,LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN"
    Dim result = True
    Dim sql As String = "SELECT 1 FROM M_PARTPACK_T A,m_SnRuleD_t B WHERE A.PARTID='{0}' AND A.CodeRuleID=B.CodeRuleID AND A.USEY='Y' AND B.F_codeID='HT'"
    Private Function BaseDataCheckForAuto(ByVal row As DataGridViewRow) As Boolean
        result = True
        If factoryList.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
            If (String.IsNullOrEmpty(row.Cells(enumdgMOData.Cust).Value.ToString) OrElse String.IsNullOrEmpty(row.Cells(enumdgMOData.Series).Value.ToString)) Then
                If IsNothing(Me.CboCustID.SelectedItem) OrElse Me.CboCustID.SelectedItem.ToString.Equals(String.Empty) Then
                    Dim sql As String = "SELECT CUSID,SERIESID FROM m_PartContrast_t WHERE PAVCPART='" & row.Cells(enumdgMOData.PartID).Value.ToString & "' AND TAVCPART='" & row.Cells(enumdgMOData.PartID).Value.ToString & "'" & MOComBusiness.GetPartFatory
                    Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            row.Cells(enumdgMOData.Cust).Value = dt.Rows(0)("CUSID").ToString
                            row.Cells(enumdgMOData.Series).Value = dt.Rows(0)("SERIESID").ToString
                        Else

                        End If
                    End Using
                    Me.CboCustID.SelectedIndex = 0
                    'MessageBox.Show("请先选择客户!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    result = True
                Else : result = True
                End If
            End If
            Dim isPoNullEmpty As Boolean = False
            If row.Cells(enumdgMOData.PO).Value Is Nothing Then
                isPoNullEmpty = True
            ElseIf String.IsNullOrEmpty(row.Cells(enumdgMOData.PO).Value.ToString) Then
                isPoNullEmpty = True
            End If
            If (isPoNullEmpty) Then
                Try
                    Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(sql, row.Cells(enumdgMOData.PartID).Value.ToString))
                        If dt.Rows.Count > 0 Then
                            MessageUtils.ShowInformation("工单" & row.Cells(enumdgMOData.MOID).Value.ToString & "需要打印合同号,请输入合同号!")
                            DgMoData.CurrentCell = row.Cells(enumdgMOData.PO)
                            DgMoData.CurrentCell.Style.BackColor = Drawing.Color.Pink
                            DgMoData.BeginEdit(True)
                            result = False
                        Else
                            result = True
                        End If
                    End Using
                Catch ex As Exception
                End Try
            End If
        Else
            If IsNothing(Me.CboCustID.SelectedItem) OrElse Me.CboCustID.SelectedItem.ToString.Equals(String.Empty) Then
                MessageUtils.ShowInformation("请先选择客户!")
                result = False
            End If

            'add by cq 20180703
            If IsNothing(Me.CboSerialID.SelectedItem) OrElse Me.CboSerialID.SelectedItem.ToString.Equals(String.Empty) Then
                MessageUtils.ShowInformation("请先选择系列别!")
                result = False
            End If

        End If
        Return result
    End Function

    '取得料件版本号
    Private Function GetPnVersionByInputMo() As String
        If factoryList.IndexOf(VbCommClass.VbCommClass.Factory) < 0 Then
            Try
                '是连接SAP
                If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    Dim version As String = SapCommon.GetVerFromTiptopSap(txtPartNo.Text)
                    Return version
                Else
                    Using dt As DataTable = OracleOperateUtils.GetDataTable(SapCommon.GetPnByInputMoSql(txtPartNo.Text))  '料件编号
                        If dt.Rows.Count > 0 Then
                            Return GetVersion(dt.Rows(0)(0).ToString)
                        End If
                    End Using
                End If
                Return ""
            Catch ex As Exception
                Throw ex
            End Try
        Else
            Return ""
        End If
    End Function

    Private Function CheckMoExists(ByVal mo As String) As Boolean
        'Dim ExecuteCmd As New SysDataBaseClass
        'As is: 1工單創建成功確認生產,3.工單打印RUN CARD Now: 3.工單已發放,料表已列印, 
        If DbOperateUtils.GetRowsCount("SELECT MOID FROM M_MainMO_T WHERE PARENTMO='" & Trim(mo) & "'AND ESTATEID NOT IN(1,'A')") > 0 Then
            LblMsg.Text = "{" & mo & "}工单已存在或其可能存在已分批或在制程中或已完工结案的子工单！！！"
            Return True
        End If
        Return False
    End Function

    Private Function GetChildPnByCurrentMoPn(ByVal moPn As String) As DataTable
        Dim lsSQL As String = ""
        'As is: 可扩展，且子料号第一码与主料号一致,Now: remove condition extensible,cq20151208
        'lsSQL = _
        '         "SELECT TAvcPart, PAvcPart, VERSION" + vbCrLf + _
        '         "  FROM m_PartContrast_t" + vbCrLf + _
        '         " WHERE     SUBSTRING (pavcpart, 1, 1) = SUBSTRING (TAvcPart, 1, 1)" + vbCrLf + _
        '         "       AND PAvcPart = '" & moPn & "'" & _
        '         "       AND  ISNULL(EffectiveDate,getdate()) <= getdate() AND  ISNULL(ExpirationDate,getdate()) >= getdate()" & _
        '         "       AND Pavcpart <>  TAvcPart"
        'Modify by cq 20151217, process the ExpirationDate 1900-01-01 00:00:00.000 case 
        'by hs ke 增加子健物料筛选 Extensible='Y' ，能展开的才生成子健工单20171013
        lsSQL = " SELECT TAvcPart, PAvcPart, VERSION" & _
                " FROM m_PartContrast_t" & _
                " WHERE SUBSTRING(pavcpart, 1, 1) = SUBSTRING(TAvcPart, 1, 1)" & _
                " AND PAvcPart = '" & moPn & "'" & _
                " AND ISNULL (EffectiveDate, getdate ()) <= getdate ()" & _
                " AND ISNULL (ExpirationDate, getdate ()) >= getdate ()" & _
                " AND Pavcpart <> TAvcPart and Extensible='Y'" & _
                " UNION " & _
                " SELECT TAvcPart, PAvcPart, VERSION" & _
                " FROM m_PartContrast_t" & _
                " WHERE SUBSTRING(pavcpart, 1, 1) = SUBSTRING(TAvcPart, 1, 1)" & _
                " AND PAvcPart = '" & moPn & "'" & _
                " AND ISNULL (EffectiveDate, getdate ()) <= getdate ()" & _
                " AND CONVERT (NVARCHAR (10), cast (ExpirationDate AS DATETIME), 112) =" & _
                " CONVERT (NVARCHAR (10),cast ('1900-01-01 00:00:00.000' AS DATETIME), 112)" & _
                " AND Pavcpart <> TAvcPart and Extensible='Y' " &
                MOComBusiness.GetPartFatory
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            Return o_dt
        End Using
    End Function


    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        For Each row As DataGridViewRow In DgMoData.Rows
            row.Cells(GridColZero).Value = ChkAll.Checked
        Next
    End Sub

    Private listNew As List(Of String) = New List(Of String)()
    Private Sub CboCustID_TextUpdate(sender As Object, e As EventArgs) Handles CboCustID.TextUpdate
        Try
            '清空combobox
            Me.CboCustID.Items.Clear()
            '清空listNew
            listNew.Clear()
            '遍历全部备查数据
            For Each item As String In m_listCustID
                If item.Contains(Me.CboCustID.Text) Then
                    listNew.Add(item)
                End If
            Next
            'combobox添加已经查到的关键词
            If listNew.Count > 0 Then
                Me.CboCustID.Items.AddRange(listNew.ToArray())
            Else
                Me.CboCustID.Items.AddRange(m_listCustID.ToArray())
            End If
            Thread.Sleep(1)
            '设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            Me.CboCustID.SelectionStart = Me.CboCustID.Text.Length
            ' //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default
            '自动弹出下拉框
            Me.CboCustID.DroppedDown = True
        Catch ex As Exception
            'Throw ex
        Finally
            'listNew = Nothing
        End Try
    End Sub
#End Region

    Private Sub toolAddQty_Click(sender As Object, e As EventArgs) Handles toolAddQty.Click
        Dim o_strMOID As String = ""
        If Not IsNothing(DgMoData.CurrentRow) Then
            Dim frmAddQty As FrmMOQtyChangeRequest = New FrmMOQtyChangeRequest()
            o_strMOID = DgMoData.CurrentRow.Cells("Comoid").Value
            frmAddQty.txtMOID.Text = o_strMOID

            ' frmAddQty.txtBeforeQty.Text = DgMoData.CurrentRow.Cells("Colqty").Value
            frmAddQty.StartPosition = FormStartPosition.CenterParent
            '  frmAddQty.ShowDialog()

            If frmAddQty.ShowDialog() = DialogResult.OK Then
                '刷新数据
                LoadDataInGrid(" where  MOID LIKE '%" & o_strMOID & "%'")
            End If

        Else
            MessageUtils.ShowInformation("请选择一笔工单进行操作！")
            Exit Sub
        End If

    End Sub

    Private Sub toolMOLock_Click(sender As Object, e As EventArgs) Handles toolMOLock.Click
        Dim o_strMOID As String = ""
        If Not IsNothing(DgMoData.CurrentRow) Then
            Dim frmLock As FrmMOLock = New FrmMOLock()
            o_strMOID = DgMoData.CurrentRow.Cells("Comoid").Value
            frmLock.txtMOID.Text = o_strMOID

            frmLock.txtBeforeMOState.Text = DgMoData.CurrentRow.Cells("Colstate").Value
            frmLock.StartPosition = FormStartPosition.CenterParent
            '  frmAddQty.ShowDialog()

            If frmLock.ShowDialog() = DialogResult.OK Then
                '刷新数据
                LoadDataInGrid(" where  MOID LIKE '%" & o_strMOID & "%'")
            End If

        Else
            MessageUtils.ShowInformation("请选择一笔工单进行操作！")
            Exit Sub
        End If
    End Sub

    Private Sub txtNGMOInput_Click(sender As Object, e As EventArgs) Handles txtNGMOInput.Click
        Try
            Dim frm As New FrmLenovoEDIMO
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmLineMOQuery As New FrmLineMOQuery(Me.mtxtMOid, "")
            'Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            frmLineMOQuery.ShowDialog()
            Me.TxtMoNo.Text = Me.mtxtMOid.Text

        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub ToolAddFirmwareVersion_Click(sender As Object, e As EventArgs) Handles ToolAddFirmwareVersion.Click
        Dim o_strMOID As String = ""
        Dim partid As String = ""
        If Not IsNothing(DgMoData.CurrentRow) Then
            Dim FrmMoFirmwareVersion As FrmMoFirmwareVersion = New FrmMoFirmwareVersion()
            o_strMOID = DgMoData.CurrentRow.Cells("Comoid").Value
            partid = DgMoData.CurrentRow.Cells("ColPartid").Value
            FrmMoFirmwareVersion.txtMOID.Text = o_strMOID
            FrmMoFirmwareVersion.txtPartId.Text = partid
            ' frmAddQty.txtBeforeQty.Text = DgMoData.CurrentRow.Cells("Colqty").Value
            FrmMoFirmwareVersion.StartPosition = FormStartPosition.CenterParent
            '  frmAddQty.ShowDialog()

            If FrmMoFirmwareVersion.ShowDialog() = DialogResult.OK Then
                '刷新数据
                LoadDataInGrid(" where  MOID LIKE '%" & o_strMOID & "%'")
            End If

        Else
            MessageUtils.ShowInformation("请选择一笔工单进行操作！")
            Exit Sub
        End If
    End Sub
End Class