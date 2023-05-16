Option Strict On
Option Explicit On
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' </summary>
''' 修改者： 田玉琳
''' 修改日： 2016/12/28
''' 修改内容：增加库存数量
'''           自动申请界面内容修改
''' <remarks>重新改版</remarks>
Public Class FrmEquipmentManualApply

#Region "属性"

    Public Enum ActionType
        Load = 0
        Add
        Save
        Query
    End Enum

    Public Enum RequestGrid
        CheckBox = 0
        AppUserName
        AppID
        DeptName
        DeptID
        Line
        hardwarePn
        EquipmentPn
        EquipmentDesc
        RequestQty
        States
        FactoryId
        PorofitCenter
        Remarks
    End Enum

    Private Enum Status
        UNDO
        Abandon
        TELL
        MODIFY
    End Enum

    Private _ismultiline As Boolean = False
    Public Property IsMultiLine() As Boolean
        Get
            Return _ismultiline
        End Get

        Set(ByVal Value As Boolean)
            _ismultiline = Value
        End Set
    End Property

    Private _blnCheckQty As Boolean = True
    Public Property CheckQty() As Boolean
        Get
            Return _blnCheckQty
        End Get

        Set(ByVal Value As Boolean)
            _blnCheckQty = Value
        End Set
    End Property

#End Region

#Region "初期化"

    ''' <summary>
    ''' 初期化Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEquipmentManualApply_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.DesignMode = False Then
            InitLoad()
        End If

    End Sub

    Private Sub InitLoad()
        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
        '初始下拉列表
        EquManageCommon.BindComboxClass(cboRequestClass)
        EquManageCommon.BindComboxClass(cboRequestClass2)
        EquManageCommon.BindComboxClass(cboQueryClass)

        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
            EquManageCommon.BindComboxLine(cboRequestLine2, cboRequestClass2.SelectedValue.ToString)
            EquManageCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
        End If
        '状态
        EquManageCommon.BindComboxStatus(cboQueryStatus)

        Dim dt As DataTable = GetUserInfo()

        If dt.Rows.Count > 0 Then

            txtRequestUser.Text = dt.Rows(0)("RequestUser").ToString
            cboRequestClass.SelectedValue = dt.Rows(0)("Dept").ToString
            cboRequestLine.SelectedValue = dt.Rows(0)("lineid").ToString

            txtRequestUser2.Text = dt.Rows(0)("RequestUser").ToString
            cboRequestClass2.SelectedValue = dt.Rows(0)("Dept").ToString
            cboRequestLine2.SelectedValue = dt.Rows(0)("lineid").ToString
            'txtQueryUser.Text = VbCommClass.VbCommClass.UseId

        End If

        tabControl1_SelectedIndexChanged(Nothing, Nothing)
        '查出借出工治具
        'SearchOut()
    End Sub

#End Region

#Region "手动申请"

    ''' <summary>
    ''' 手动申请添加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If Not BasicCheck() Then Exit Sub '基础检查
            '申请
            'dgvRequest.Rows.Clear()
            Dim partId As String
            Dim PartName As String
            Dim whQty As Integer
            Dim adviceQTY As Integer
            If chkSelectAll.Checked = True Then
                For rowIndex As Integer = 0 To cboPartNumber.Items.Count - 1
                    partId = DirectCast(cboPartNumber.Items(rowIndex), System.Data.DataRowView).Row.ItemArray(0).ToString
                    PartName = DirectCast(cboPartNumber.Items(rowIndex), System.Data.DataRowView).Row.ItemArray(1).ToString
                    whQty = GetWhQty(partId)
                    Dim Sql As String = " SELECT  ISNULL(adviceQTY,0) AS adviceQTY  FROM	m_equipmenthardware_t WHERE PartNumber = '" & partId & "'"
                    Dim dt As DataTable = DbOperateReportUtils.GetDataTable(Sql)
                    adviceQTY = Int32.Parse(dt.Rows(0)(0).ToString())
                    dgvRequest.Rows.Add("True", txtRequestUser.Text.Trim.Split(CChar("/"))(1), txtRequestUser.Text.Trim.Split(CChar("/"))(0),
                        cboRequestClass.Text, cboRequestClass.SelectedValue, cboRequestLine.SelectedValue,
                        txthardwarePartNumber.Text, partId, PartName, adviceQTY,
                        txtRequestQty.Text, whQty, "申请", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
                Next
                For index = 0 To dgvRequest.Rows.Count - 1
                    If Int32.Parse(dgvRequest.Rows(index).Cells("adviceQTY").Value.ToString()) < Int32.Parse(dgvRequest.Rows(index).Cells("RequestQty").Value.ToString()) Then
                        dgvRequest.Rows(index).DefaultCellStyle.BackColor = Color.Red
                    End If
                Next

            Else
                partId = cboPartNumber.Text.Substring(0, cboPartNumber.Text.ToString.IndexOf("---"))
                PartName = cboPartNumber.Text.Substring(cboPartNumber.Text.ToString.IndexOf("---") + 3)
                whQty = GetWhQty(partId)
                Dim Sql As String = " SELECT  ISNULL(adviceQTY,0) AS adviceQTY  FROM	m_equipmenthardware_t WHERE PartNumber = '" & partId & "'"
                Dim dt As DataTable = DbOperateReportUtils.GetDataTable(Sql)
                adviceQTY = Int32.Parse(dt.Rows(0)(0).ToString())
                dgvRequest.Rows.Add("True", txtRequestUser.Text.Trim.Split(CChar("/"))(1), txtRequestUser.Text.Trim.Split(CChar("/"))(0),
                      cboRequestClass.Text, cboRequestClass.SelectedValue, cboRequestLine.SelectedValue,
                      txthardwarePartNumber.Text, partId, PartName, adviceQTY,
                      txtRequestQty.Text, whQty, "申请", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            End If
      
            For Each col As DataGridViewColumn In dgvRequest.Columns
                If col.Name = "uxCheck" Then
                    col.ReadOnly = False
                Else
                    col.ReadOnly = True
                End If
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "btnAdd_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 保存前检查数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BasicCheck() As Boolean
        Dim hardwarePn As String = txthardwarePartNumber.Text.Trim
        Dim Pn As String = cboPartNumber.Text.Trim
        Dim qty As String = txtRequestQty.Text.Trim

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboRequestClass.SelectedValue)) = True Then
            MessageUtils.ShowError("请选择课别!")
            Me.cboRequestClass.Focus()
            Me.cboRequestClass.Select()
            Return False
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboRequestLine.SelectedValue)) = True Then
            If cboRequestLine.Items.Count > 1 Then
                MessageUtils.ShowError("请选择线别!")
                Me.cboRequestClass.Focus()
                Me.cboRequestClass.Select()
                Return False
            End If
        End If

        If hardwarePn = "" Then
            MessageUtils.ShowError("请刷五金料号!")
            Me.txthardwarePartNumber.Focus()
            Return False
        End If

        If Pn = "" Then
            MessageUtils.ShowError("请确认对应的工治具规格!")
            Me.cboPartNumber.Focus()
            Me.cboPartNumber.Select()
            Return False
        End If

        If CheckUtils.HalfWidthNumChecker(qty) = False Then
            MessageUtils.ShowError("请输入正确数量!")
            Me.txtRequestQty.Focus()
            Me.txtRequestQty.Select()
            Return False
        End If

        If cboPartNumber.Text.ToString.IndexOf("---") < 1 Then
            MessageUtils.ShowError("工治具规格不存在，请重新输入五金料号！")
            Return False
        End If

        Dim whQty As String = ""
        Pn = cboPartNumber.Text.ToString.Substring(0, cboPartNumber.Text.ToString.IndexOf("---"))
        If CheckInputQty(Pn, txtRequestQty.Text, whQty) = False Then
            If CInt(whQty) = 0 Then
                MessageUtils.ShowError(String.Format("设备料号【{0}】库存数量0，请联系生技室备货！", Pn))
            Else
                MessageUtils.ShowError(String.Format("请求数量【{0}】大于库存数量【{1}】，请修改请求数量！", txtRequestQty.Text, whQty))
            End If
            Me.txtRequestQty.Focus()
            Me.txtRequestQty.Select()
            Return False
        End If

        For Each row As DataGridViewRow In dgvRequest.Rows
            If row.Cells(RequestGrid.EquipmentPn).Value.ToString = Pn Then
                MessageUtils.ShowError("申请的工治具已经在下方的申请中列表中，请不要重复申请！")
                cboPartNumber.Select()
                cboPartNumber.SelectAll()
                Return False
            End If
        Next

        If chkSelectAll.Checked = True Then
            If dgvRequest.Rows.Count > 0 Then
                MessageUtils.ShowError("申请的工治具已经在下方的申请中列表中,请不要重复申请；请先移除申请列表，再申请.")
                btnRemove.Select()
                Return False
            End If
            Dim EquipmentPn As String = ""
            For rowIndex As Integer = 0 To cboPartNumber.Items.Count - 1
                EquipmentPn = DirectCast(cboPartNumber.Items(rowIndex), System.Data.DataRowView).Row.ItemArray(0).ToString

                If CheckInputQty(EquipmentPn, txtRequestQty.Text, whQty) = False Then
                    If CInt(whQty) = 0 Then
                        MessageUtils.ShowError(String.Format("列表中设备料号【{0}】库存数量0，请联系生技室备货！", EquipmentPn))
                    Else
                        MessageUtils.ShowError(String.Format("列表中设备料号【{0}】请求数量【{1}】大于库存数量【{2}】，请确认！", EquipmentPn, txtRequestQty.Text, whQty))
                    End If
                    cboPartNumber.SelectedIndex = rowIndex
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    ''' <summary>
    ''' 检查输入的数量和库存比较
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckInputQty(pn As String, reQuestQty As String, ByRef whQty As String) As Boolean
        whQty = GetWhQty(pn).ToString

        If CInt(whQty) < CInt(reQuestQty) Then
            whQty = whQty
            Return False
        End If
        Return True
    End Function

    Private Function GetWhQty(pn As String) As Integer
        Dim strSQL As String = " SELECT count(1) FROM m_Equipment_t " & _
                               " WHERE PartNumber  = N'{0}' AND InOut =1   AND Status=1 " & vbCrLf &
        EquManageCommon.GetFatoryProfitcenter()
        strSQL = String.Format(strSQL, pn)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return CInt(dt.Rows(0)(0).ToString)
    End Function

    Private Function GetLineQty(ByVal pn As String, ByVal strLineID As String) As Integer
        Dim strSQL As String = " SELECT count(1) FROM m_Equipment_t " &
                               " WHERE PartNumber  = N'{0}' AND lineid ='" & strLineID & "' " &
                      EquManageCommon.GetFatoryProfitcenter()
        strSQL = String.Format(strSQL, pn)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return CInt(dt.Rows(0)(0).ToString)
    End Function

    ''' <summary>
    ''' 移除数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If dgvRequest.Rows.Count <= 0 Then
                MessageUtils.ShowError("没有可删除的申请项,请确认！")
                Exit Sub
            End If
            Dim bFlag = False
            Dim aListIndex As ArrayList = New ArrayList

            For rowIndex As Integer = 0 To dgvRequest.Rows.Count - 1
                If Not dgvRequest.Rows(rowIndex).Cells(RequestGrid.CheckBox).Value Is Nothing AndAlso
                    dgvRequest.Rows(rowIndex).Cells(RequestGrid.CheckBox).Value.ToString = "True" Then
                    bFlag = True
                    aListIndex.Add(rowIndex)
                End If
            Next

            If (bFlag = False) Then
                MessageUtils.ShowError("请在申请列表选择要移除的申请项！")
            End If

            For i As Integer = aListIndex.Count - 1 To 0 Step -1
                dgvRequest.Rows.RemoveAt(CInt(aListIndex(i)))
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "btnRemove_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 输入五金料号检查
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txthardwarePartNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthardwarePartNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SethardwarePn()
        End If
    End Sub

    ''' <summary>
    ''' 取得对应的设备料号资料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SethardwarePn()
        Dim hardwarePn As String = txthardwarePartNumber.Text.Trim
        If hardwarePn = "" Then
            MessageUtils.ShowError("请刷五金料号")
            Me.txthardwarePartNumber.Select()
            Return
        End If
        Dim FactoryName = VbCommClass.VbCommClass.Factory
        Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
        Dim sql As String
        sql = " select DISTINCT a.PartNumber as VALUE,PartNumberFormat, a.PartNumber+'---'+ISNULL(PartNumberFormat,B.DESCRIPTION) as TEXT  " &
              " from m_equipmenthardware_t A LEFT JOIN m_PartContrast_t B ON" & vbCrLf &
            " A.PartNumber=B.TAvcPart " & vbCrLf &
             " join m_Equipment_t c on c.PartNumber=a.PartNumber and c.Status=1 " & vbCrLf &
              " where HardWarePartNumber = '" & hardwarePn & "'" & vbCrLf &
        " and a.FactoryName='" & FactoryName & "' and A.Profitcenter='" & Profitcenter & "'"
        EquManageCommon.GetFatoryProfitcenter()

        EquManageCommon.BindComboxNoBlank(sql, cboPartNumber, "TEXT", "VALUE")

        '请求数量默认是1
        txtRequestQty.Text = "1"
        '工治具规格，去掉空值，默认选中一笔
        If cboPartNumber.Items.Count = 0 Then
            MessageUtils.ShowError("该五金料号没有对应的工治具规格，请重新输入五金料号！")
            Me.txthardwarePartNumber.Select()
        ElseIf cboPartNumber.Items.Count = 1 Then
            '只有一条数据对应时，直接带出
            cboPartNumber.SelectedIndex = 0
        End If

    End Sub

    ''' <summary>
    ''' 请求数量可以修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvRequest_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApply.CellClick, dgvRequest.CellClick
        For rowIndex As Integer = 0 To dgvRequest.Rows.Count - 1
            If Not dgvRequest.Rows(rowIndex).Cells("uxCheck").EditedFormattedValue Is Nothing AndAlso
                   dgvRequest.Rows(rowIndex).Cells("uxCheck").EditedFormattedValue.ToString = "True" Then
                dgvRequest.Rows(rowIndex).Cells("RequestQty").ReadOnly = False
                dgvRequest.Rows(rowIndex).Cells("Remarks").ReadOnly = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' 数量验证
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvRequest_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvRequest.CellValidating
        Dim whQty As String = ""
        Dim EquipmentPn As String = dgvRequest.CurrentRow.Cells("EquipmentPn").EditedFormattedValue.ToString
        Dim RequestQty As String = dgvRequest.CurrentRow.Cells("RequestQty").EditedFormattedValue.ToString
        Dim QTY As String = dgvRequest.CurrentRow.Cells("adviceQTY").EditedFormattedValue.ToString
        If CheckUtils.HalfWidthNumChecker(RequestQty) = False Then
            MessageUtils.ShowError("请输入正确数量!")
            e.Cancel = True
        Else
            If CheckInputQty(EquipmentPn, RequestQty, whQty) = False Then
                MessageUtils.ShowError(String.Format("请求数量【{0}】大于库存数量【{1}】，请修改请求数量！", RequestQty, whQty))
                e.Cancel = True
            End If
        End If
        If Int32.Parse(QTY) < Int32.Parse(RequestQty) Then
            dgvRequest.CurrentRow.DefaultCellStyle.BackColor = Color.Red
        End If
    End Sub
    Private Sub dgvRequest_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequest.CellValidated
      
    End Sub

#End Region

#Region "自动申请"

    Private Sub txtMOID_TextChanged(sender As Object, e As EventArgs)
        InputMOID()
    End Sub

    Private Sub txtMOID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMOID.KeyPress
        If Asc(e.KeyChar) = 13 Then
            InputMOID()
        End If
    End Sub

    Private Sub InputMOID()
        Dim strMOQty As String = String.Empty
        Try
            Dim strSQL As String = "SELECT PartID,deptid,lineid, MoQty FROM m_Mainmo_t where Moid ='{0}';"

            strSQL = String.Format(strSQL, txtMOID.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("工单不存在!")
                Exit Sub
            End If

            Dim PartID = dt.Rows(0)("PartID").ToString
            Dim deptid = dt.Rows(0)("deptid").ToString
            Dim lineid = dt.Rows(0)("lineid").ToString
            Me.txtMOQty.Text = dt.Rows(0).Item("MoQty").ToString

            strSQL = "SELECT A.EWPartNumber,B.DESCRIPTION,COUNT(1) Qty ,a.PartID FROM m_RCardDPart_t A " &
                     "INNER JOIN (SELECT TAvcPart,DESCRIPTION FROM m_PartContrast_t WHERE  TYPE='E') B ON A.EWPartNumber=B.TAvcPart " &
                     " WHERE A.PartID IN (SELECT PartID FROM m_RCardM_t WHERE Status=1 AND PARTID='{0}') " &
                     "GROUP BY A.PartID,A.EWPartNumber,B.DESCRIPTION " & _
                     " Union " & _
                     " SELECT PartNumber as EWPartNumber,PartNumberFormat as DESCRIPTION ,Qty, HardWarePartNumber as PartID FROM m_EquipmentHardWare_t  " & _
                     " WHERE HardWarePartNumber='{0}'"
            strSQL = String.Format(strSQL, PartID)
            dt.Reset()
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("工单对应的流程卡没有审核或没有工治具料号信息！")
                Exit Sub
            End If

            cboRequestClass2.SelectedValue = deptid
            cboRequestLine2.SelectedValue = lineid
            Dim equPartNumber As String = ""
            Dim WhQty As Integer = 0
            Dim iCurrentLineQty As Integer = 0
            '默认选择 
            dgvApply.Rows.Clear()
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                equPartNumber = dt.Rows(rowIndex)("EWPartNumber").ToString
                WhQty = GetWhQty(equPartNumber)
                iCurrentLineQty = GetLineQty(equPartNumber, lineid)
                If WhQty = 0 Then ' 库存为0不勾选
                    '需求数量, 库存数量
                    dgvApply.Rows.Add("False", dt.Rows(rowIndex)("Qty").ToString, WhQty.ToString,
                                 equPartNumber, dt.Rows(rowIndex)("DESCRIPTION").ToString, iCurrentLineQty.ToString, PartID)
                Else
                    dgvApply.Rows.Add("True", dt.Rows(rowIndex)("Qty").ToString, WhQty.ToString,
                                 equPartNumber, dt.Rows(rowIndex)("DESCRIPTION").ToString, iCurrentLineQty.ToString, PartID)
                End If
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "InputMOID", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub InputPartID()
        Dim partID As String = Me.txtPartNumber.Text.Trim
        Dim strSQL As String = String.Empty
        Dim lineID As String = String.Empty
        Dim dt As New DataTable
        Try

            'Add first check
            'If String.IsNullOrEmpty(Me.cboRequestLine2.Text) Then
            '    MessageUtils.ShowError("")
            'End If

            strSQL = " SELECT A.EWPartNumber,B.DESCRIPTION,COUNT(1) Qty, a.PartID FROM m_RCardDPart_t A " &
                     " INNER JOIN (SELECT TAvcPart,DESCRIPTION FROM m_PartContrast_t WHERE  TYPE='E') B ON A.EWPartNumber=B.TAvcPart " &
                     " WHERE A.PartID IN (SELECT PartID FROM m_RCardM_t WHERE Status=1 AND PARTID='{0}') " &
                     "GROUP BY A.PartID,A.EWPartNumber,B.DESCRIPTION" & _
                     " Union " & _
                     " SELECT PartNumber as EWPartNumber,PartNumberFormat as DESCRIPTION ,Qty, HardWarePartNumber as PartID FROM m_EquipmentHardWare_t  " & _
                     " WHERE HardWarePartNumber='{0}'"
            strSQL = String.Format(strSQL, partID)
            dt.Reset()
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("工单对应的流程卡没有审核或没有工治具料号信息！")
                Exit Sub
            End If

            cboRequestClass2.SelectedValue = DeptID

            Dim equPartNumber As String = ""
            Dim WhQty As Integer = 0
            Dim iCurrentLineQty As Integer = 0
            '默认选择 
            dgvApply.Rows.Clear()
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                equPartNumber = dt.Rows(rowIndex)("EWPartNumber").ToString
                WhQty = GetWhQty(equPartNumber)
                iCurrentLineQty = GetLineQty(equPartNumber, lineID)
                If WhQty = 0 Then ' 库存为0不勾选
                    dgvApply.Rows.Add("False", dt.Rows(rowIndex)("Qty").ToString, WhQty.ToString, _
                                      equPartNumber, dt.Rows(rowIndex)("DESCRIPTION").ToString, iCurrentLineQty.ToString, partID
                                      )
                Else
                    dgvApply.Rows.Add("True", dt.Rows(rowIndex)("Qty").ToString, WhQty.ToString,
                                      equPartNumber, dt.Rows(rowIndex)("DESCRIPTION").ToString, iCurrentLineQty.ToString, partID
                                      )
                End If
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "InputPartID", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub txtPartNumber_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPartNumber.ButtonCustomClick
        Dim obj As New SysBasicClass.InputText(txtPartNumber)
        obj.ShowDialog()
    End Sub

    Private Sub dgvApply_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex = -1 Then Exit Sub

            LoadEquipmentDetail(e.RowIndex)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentManualApply", "dgvApply_CellClick", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadEquipmentDetail(curRowIndex As Integer)
        If dgvApply.Rows.Count = 0 Then
            dgvEquipment.Rows.Clear()
            Exit Sub
        End If

        Dim strSQL As String =
            "select EquipmentNo,ProcessParameters,Storage,lineid,isnull(InOut,1) InOut,FactoryName,Profitcenter from m_Equipment_t  " &
            "where 1=1 " & EquManageCommon.GetFatoryProfitcenter()

        Dim partNumber As String = dgvApply.Rows(curRowIndex).Cells("EWPartNumber").Value.ToString

        Dim strWhere As String = String.Format(" and PartNumber = N'{0}'", partNumber)
        Dim strOrder As String = " order by InOut desc"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

        dgvEquipment.Rows.Clear()
        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            dgvEquipment.Rows.Add(
                dt.Rows(rowIndex)("EquipmentNo").ToString, dt.Rows(rowIndex)("ProcessParameters").ToString,
                dt.Rows(rowIndex)("Storage").ToString, dt.Rows(rowIndex)("lineid").ToString,
                dt.Rows(rowIndex)("FactoryName").ToString, dt.Rows(rowIndex)("Profitcenter").ToString,
                dt.Rows(rowIndex)("InOut").ToString)
        Next

        For rowIndex As Integer = 0 To dgvEquipment.Rows.Count - 1
            If String.IsNullOrEmpty(dgvEquipment.Rows(rowIndex).Cells("colLine").Value.ToString) Then
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightPink
            Else
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
            If dgvEquipment.Rows(rowIndex).Cells("InOut").Value.ToString = "0" Then
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightGray
            Else
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        Next
    End Sub

    Private Sub dgvApply_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvApply.CellValidating
        If CheckQty Then
            CheckAutoApply(e)
        End If
    End Sub

    Private Function CheckAutoApply(e As DataGridViewCellValidatingEventArgs) As Boolean
        Dim whQty As String = ""
        Dim EquipmentPn As String = dgvApply.CurrentRow.Cells("EWPartNumber").EditedFormattedValue.ToString
        Dim RequestQty As String = dgvApply.CurrentRow.Cells("QTY").EditedFormattedValue.ToString
        If CheckUtils.HalfWidthNumChecker(RequestQty) = False Then
            MessageUtils.ShowError("请输入正确数量!")
            If e Is Nothing Then
                Return False
            Else
                e.Cancel = True
            End If
        Else
            If CheckInputQty(EquipmentPn, RequestQty, whQty) = False Then
                If CInt(whQty) = 0 Then
                    MessageUtils.ShowInformation(String.Format("料号【{0}】库存数量为0，不能申请数量！", EquipmentPn))
                    dgvApply.CurrentRow.Cells("colSelect").Value = "False"
                Else
                    MessageUtils.ShowError(String.Format("料号【{0}】请求数量【{1}】大于库存数量【{2}】，请修改请求数量！", EquipmentPn, RequestQty, whQty))
                End If

                If e Is Nothing Then
                    Return False
                Else
                    e.Cancel = True
                End If
            End If
        End If
        Return True
    End Function

#End Region

#Region "记录查询"
    Private Sub dgvResult_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellClick
        For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
            If Not dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                   dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                dgvResult.Rows(rowIndex).Cells("Remark").ReadOnly = False
            End If
        Next
    End Sub
#End Region

#Region "工具条"

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        If tabControl1.SelectedIndex = 0 Then
            SetToolButton(False)
            toolSave.Enabled = True
            toolUndo.Enabled = True
            btnAdd.Enabled = True
            btnRemove.Enabled = True
        ElseIf tabControl1.SelectedIndex = 1 Then
            SetToolButton(False)
            toolSave.Enabled = True
            toolUndo.Enabled = True
            txtMOID.Enabled = True
        End If
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            '检查数据
            If CheckData() = False Then Exit Sub

            'If String.IsNullOrEmpty(Me.cboRequestLine2.Text) Then
            '    MessageUtils.ShowError("线别不能为空,请检查！ ")
            '    Exit Sub
            'End If

            '确认信息
            If MessageUtils.ShowConfirm("你确定保存吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            If tabControl1.SelectedIndex = 0 Then
                InsertData()
                RemoveSucess()
            ElseIf tabControl1.SelectedIndex = 1 Then
                InsertDataAuto()
                RemoveSucess()
            ElseIf tabControl1.SelectedIndex = 2 Then
                UpdateData()
                SetQueryQtyReadOnly()
            End If

            Search()
            '保存成功后,回到初始状态
            tabControl1_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolSave_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub RemoveSucess()
        If tabControl1.SelectedIndex = 0 Then
            dgvRequest.Rows.Clear()
        ElseIf tabControl1.SelectedIndex = 1 Then
            dgvApply.Rows.Clear()
            dgvEquipment.Rows.Clear()
            ClearText()
        End If
    End Sub

    Private Sub SetQueryQtyReadOnly()
        dgvResult.Columns("QueryQTY").ReadOnly = True
    End Sub

    Private Function CheckData() As Boolean
        Dim bFlag As Boolean = False

        If tabControl1.SelectedIndex = 0 Then
            If dgvRequest.Rows.Count = 0 Then
                MessageUtils.ShowError("请先增加数据！")
                Return bFlag
            End If
            For rowIndex As Integer = 0 To dgvRequest.Rows.Count - 1
                If Not dgvRequest.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       dgvRequest.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    bFlag = True
                    Exit For
                End If
            Next
        ElseIf tabControl1.SelectedIndex = 1 Then
            If dgvApply.Rows.Count = 0 Then
                MessageUtils.ShowError("请先增加数据！")
                Return bFlag
            End If
            For rowIndex As Integer = 0 To dgvApply.Rows.Count - 1
                If Not dgvApply.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       dgvApply.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    bFlag = True
                    Exit For
                End If
            Next

            If CheckAutoApply(Nothing) = False Then
                Return False
            End If

        ElseIf tabControl1.SelectedIndex = 2 Then
            For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
                If Not dgvResult.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                       dgvResult.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                    bFlag = True
                    Exit For
                End If
            Next
        End If

        If bFlag = False Then
            MessageUtils.ShowError("请选择要保存的数据！")
        End If

        Return bFlag
    End Function

    Private Sub InsertData()
        Dim insertSql As New System.Text.StringBuilder
        Dim strSQL As String = "INSERT INTO [m_Equipment_App_t]([AppID],[Dept],[Line],[AStatus],[QTY],[AppUserName],[AStatus1]," &
                               "[EquipmentPNumber],[AlreadyBorrowQty],ReturnQty,DeptID,HardWarePartNumber,[FactoryName],[Profitcenter],InTime,Remark)"

        For rowIndex As Integer = 0 To dgvRequest.Rows.Count - 1
            If Not dgvRequest.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue Is Nothing AndAlso
                  dgvRequest.Rows(rowIndex).Cells(RequestGrid.CheckBox).EditedFormattedValue.ToString = "True" Then
                insertSql.Append(strSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.AppID.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.DeptName.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.Line.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", "申请")
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.RequestQty.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.AppUserName.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", "1")
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.EquipmentPn.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", "0")
                insertSql.AppendFormat("N'{0}',", "0")
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.DeptID.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", dgvRequest.Rows(rowIndex).Cells(RequestGrid.hardwarePn.ToString).Value.ToString)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.Factory)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.profitcenter)
                insertSql.Append("GETDATE(),")
                insertSql.AppendFormat("N'{0}'", dgvRequest.Rows(rowIndex).Cells(RequestGrid.Remarks.ToString).Value)
                insertSql.Append(");")
            End If
        Next
        DbOperateUtils.ExecSQL(insertSql.ToString)

        MessageUtils.ShowInformation("保存成功！")
    End Sub

    Private Sub InsertDataAuto()
        Try
            Dim insertSql As New System.Text.StringBuilder
            Dim strSQL As String = "INSERT INTO [m_Equipment_App_t]([AppID],MOID,PNumber,[Dept],[Line],[AStatus],[QTY],[AppUserName],[AStatus1]," &
                                   "[EquipmentPNumber],[AlreadyBorrowQty],ReturnQty,DeptID,[FactoryName],[Profitcenter],InTime)"

            For rowIndex As Integer = 0 To dgvApply.Rows.Count - 1
                If dgvApply.Rows(rowIndex).Cells("colSelect").EditedFormattedValue.ToString = "True" Then
                    insertSql.Append(strSQL)
                    insertSql.Append(" VALUES(")
                    insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                    insertSql.AppendFormat("N'{0}',", txtMOID.Text.Trim)
                    insertSql.AppendFormat("N'{0}',", txtPartNumber.Text.Trim)
                    insertSql.AppendFormat("N'{0}',", cboRequestClass2.SelectedText)
                    insertSql.AppendFormat("N'{0}',", cboRequestLine2.SelectedValue)
                    insertSql.AppendFormat("N'{0}',", "申请")
                    insertSql.AppendFormat("N'{0}',", dgvApply.Rows(rowIndex).Cells("QTY").Value.ToString)
                    insertSql.AppendFormat("N'{0}',", txtRequestUser.Text.Trim.Split(CChar("/"))(1))
                    insertSql.AppendFormat("N'{0}',", "1")
                    insertSql.AppendFormat("N'{0}',", dgvApply.Rows(rowIndex).Cells("EWPartNumber").Value.ToString)
                    insertSql.AppendFormat("N'{0}',", "0")
                    insertSql.AppendFormat("N'{0}',", "0")
                    insertSql.AppendFormat("N'{0}',", cboRequestClass2.SelectedValue.ToString)
                    insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.Factory)
                    insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.profitcenter)
                    insertSql.Append("GETDATE()")
                    insertSql.Append(");")
                End If
            Next
            DbOperateUtils.ExecSQL(insertSql.ToString)

            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "InsertDataAuto", "Equ")
        End Try
    End Sub

    Private Sub UpdateData()
        Dim updateSQL As New System.Text.StringBuilder

        For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
            If Not dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                   dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                updateSQL.AppendFormat("UPDATE m_Equipment_App_t SET Qty={0} WHERE ID={1} ;",
                                       dgvResult.Rows(rowIndex).Cells("QueryQTY").EditedFormattedValue.ToString,
                                       dgvResult.Rows(rowIndex).Cells("ID").EditedFormattedValue.ToString)
            End If
        Next
        DbOperateUtils.ExecSQL(updateSQL.ToString)
        MessageUtils.ShowInformation("更新成功！")
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        ' System.Environment.Exit(System.Environment.ExitCode)
        Me.CheckQty = False
        Me.Close()
    End Sub

    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try
            Dim strSQL As String =
              " SELECT A.AppUserName 申请人,ISNULL(A.DeptID,'')+'-'+ISNULL(B.dqc,'') 课别 , " &
              " A.Line 线别,A.MOID 工单编号, A.PNumber 生产料号,convert(varchar(10),convert(varchar(10),A.AStatus1))+'.'+ISNULL(C.TEXT,'') 状态, " &
              " A.HardWarePartNumber 五金料号,A.EquipmentPNumber 工治具料号,D.DESCRIPTION 工治具规格,REPLACE(QTY,' Set','') 需求数量," &
              " ISNULL(AlreadyBorrowQty,0) 已借出数量,ISNULL(A.ReturnQty,0) 已归还数量,(borr.Receiver + '/'+ (SELECT username FROM m_users_t WHERE userid =borr.Receiver))借出人,a.InTime 申请时间, " &
              " DATEDIFF(minute,a.InTime,GETDATE()) 申请时长,A.FactoryName 厂区,A.Profitcenter 利润中心 FROM m_Equipment_App_t A  " &
              " LEFT JOIN m_Dept_t B ON A.DeptID=B.deptid LEFT JOIN m_BaseData_t C ON convert(varchar(10),A.AStatus1)=C.VALUE  " &
              " LEFT JOIN (SELECT TAvcPart,DESCRIPTION  FROM m_PartContrast_t WHERE TYPE='E') D ON A.EquipmentPNumber=D.TAvcPart  " &
              " LEFT JOIN dbo.m_Equipment_BorrRetu_t borr ON a.id = borr.RequestID" & _
              " where C.ITEMKEY='EqpAppStatus' "

            Dim dt As DataTable = GetDTbyWhere(strSQL)

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolExcel_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolQuery_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function GetDTbyWhere(strSQL As String) As DataTable
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(txtQueryUser.Text) = False Then
            strWhere.AppendFormat(" and A.AppID LIKE '{0}%' ", txtQueryUser.Text.Trim)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryClass.SelectedValue)) = False Then
            strWhere.AppendFormat(" and A.DeptID = '{0}' ", cboQueryClass.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryLine.SelectedValue)) = False Then
            strWhere.AppendFormat(" and A.Line = '{0}' ", cboQueryLine.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(txtQueryMo.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.MOID LIKE '{0}%' ", txtQueryMo.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryPn.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.PNumber LIKE '{0}%' ", txtQueryPn.Text.Trim)
        End If

        If String.IsNullOrEmpty(cboQueryStatus.SelectedValue.ToString) = False Then
            strWhere.AppendFormat(" and A.AStatus1 = '{0}' ", cboQueryStatus.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(txtQueryHardwarePartNumber.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.HardWarePartNumber = '{0}' ", txtQueryHardwarePartNumber.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryPartNumber.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.EquipmentPNumber LIKE '{0}%' ", txtQueryPartNumber.Text.Trim)
        End If

        strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), A.InTime ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeStart.Value)
        strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), A.InTime ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeEnd.Value)

        Dim strOrderby As String = " order by A.intime desc"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrderby)
        Return dt
    End Function

    Private Sub Search()
        Dim strSQL As String =
               "SELECT DISTINCT (borr.Receiver + '/'+ (SELECT username FROM m_users_t WHERE userid =borr.Receiver))Receiver," & _
                "A.AppUserName ,ISNULL(A.DeptID,'')+'-'+ISNULL(B.dqc,'') DeptIDName, A.Remark," &
               "A.Line ,A.MOID , A.PNumber, convert(varchar(10),convert(varchar(10),A.AStatus1))+'.'+ISNULL(C.TEXT,'') Status, " &
               "A.HardWarePartNumber ,A.EquipmentPNumber ,D.DESCRIPTION ,REPLACE(QTY,' Set','') QueryQTY, " &
               "ISNULL(AlreadyBorrowQty,0) AlreadyBorrowQty,ISNULL(A.ReturnQty,0) ReturnQty,a.InTime , " &
               "DATEDIFF(minute,a.InTime,GETDATE()) RequestTime,A.FactoryName ,A.Profitcenter ,A.ID ,A.AStatus1 FROM m_Equipment_App_t A  " &
               "LEFT JOIN (SELECT * FROM  m_Dept_t WHERE Factoryid='" & VbCommClass.VbCommClass.PCompany & "') B ON A.DeptID=B.deptid LEFT JOIN m_BaseData_t C ON convert(varchar(10),A.AStatus1)=C.VALUE  " &
               "LEFT JOIN (SELECT TAvcPart,DESCRIPTION  FROM m_PartContrast_t WHERE TYPE='E') D ON A.EquipmentPNumber=D.TAvcPart  " &
               "LEFT JOIN dbo.m_Equipment_BorrRetu_t borr ON a.id = borr.RequestID" & _
               " WHERE C.ITEMKEY='EqpAppStatus' " &
        EquManageCommon.GetFatoryProfitcenter("A")

        dgvResult.DataSource = GetDTbyWhere(strSQL)

        For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
            If CInt(dgvResult.Rows(rowIndex).Cells("RequestTime").Value.ToString) > CInt(txtRequestTime.Text) AndAlso
               dgvResult.Rows(rowIndex).Cells("AStatus1").Value.ToString = "1" Then
                dgvResult.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightPink
            Else
                dgvResult.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        Next

    End Sub

    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '回到初始状态
        tabControl1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub toolTell_Click(sender As Object, e As EventArgs) Handles toolTell.Click
        Try
            If CheckStatus(Status.TELL) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定备货通知产线吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            UpdateData(Status.TELL)
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolTell_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Try
            If CheckStatus(Status.Abandon) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定驳回吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            UpdateData(Status.Abandon)
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolAbandon_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Try
            If CheckStatus(Status.UNDO) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定撤销吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            UpdateData(Status.UNDO)
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolDelete_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolModify_Click(sender As Object, e As EventArgs) Handles toolModify.Click
        Try
            If CheckStatus(Status.MODIFY) = False Then Exit Sub
            UpdateData(Status.MODIFY)
            SetToolButton(False)
            toolSave.Enabled = True
            toolUndo.Enabled = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "toolModify_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckStatus(CurStatus As Status) As Boolean
        Dim alList As ArrayList = New ArrayList

        GetStatus(alList)
        If alList.Count = 0 Then
            MessageUtils.ShowError("请选择数据！")
            Return False
        End If

        Select Case CurStatus
            Case Status.UNDO
                '1.待处理或3.已备料
                For index As Integer = 0 To alList.Count - 1
                    If (alList(index).ToString <> "1" AndAlso alList(index).ToString <> "3") Then
                        MessageUtils.ShowError("撤销时请选择（1.待处理或3.已备料）的数据撤销！")
                        Return False
                    End If
                Next
            Case Status.MODIFY
                '1.待处理
                For index As Integer = 0 To alList.Count - 1
                    If (alList(index).ToString <> "1") Then
                        MessageUtils.ShowError("修改时请选择（1.待处理）的数据修改！")
                        Return False
                    End If
                Next
            Case Status.Abandon
                '1.待处理或3.已备料
                For index As Integer = 0 To alList.Count - 1
                    If (alList(index).ToString <> "1" AndAlso alList(index).ToString <> "3") Then
                        MessageUtils.ShowError("驳回时请选择（1.待处理或3.已备料）的数据撤销！")
                        Return False
                    End If
                Next
            Case Status.TELL
                '1.待处理
                For index As Integer = 0 To alList.Count - 1
                    If alList(index).ToString <> "1" Then
                        MessageUtils.ShowError("备完料通知产线时请选择（1.待处理）的数据！")
                        Return False
                    End If
                Next
            Case Else
        End Select
        Return True
    End Function

    Private Sub GetStatus(ByRef alList As ArrayList)
        For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
            If Not dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                   dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                alList.Add(dgvResult.Rows(rowIndex).Cells("AStatus1").EditedFormattedValue.ToString)
            End If
        Next
    End Sub

    Private Sub UpdateData(CurStatus As Status)
        Dim alList As ArrayList = New ArrayList
        Dim alListRemark As ArrayList = New ArrayList
        Dim updateSQL As New System.Text.StringBuilder
        GetRequestID(alList, alListRemark)

        Select Case CurStatus
            Case Status.UNDO
                '1.待处理或3.已备料
                For index As Integer = 0 To alList.Count - 1
                    updateSQL.AppendFormat("UPDATE m_Equipment_App_t SET AStatus1=5,AStatus=N'撤销' WHERE ID={0} ;", alList(index))
                Next
                DbOperateUtils.ExecSQL(updateSQL.ToString)
                MessageUtils.ShowInformation("撤销成功！")
            Case Status.MODIFY
                '1.待处理或3.已备料
                For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
                    If Not dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                           dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                        dgvResult.Rows(rowIndex).Cells("QueryQTY").ReadOnly = False
                        dgvResult.Rows(rowIndex).Cells("QueryQTY").Selected = True
                    End If
                Next
            Case Status.Abandon
                '1.待处理或3.已备料
                For index As Integer = 0 To alList.Count - 1
                    updateSQL.AppendFormat("UPDATE m_Equipment_App_t SET AStatus1=0,AStatus=N'驳回',Remark=N'{1}' WHERE ID={0} ;", alList(index), alListRemark(index))
                Next
                DbOperateUtils.ExecSQL(updateSQL.ToString)
                MessageUtils.ShowInformation("驳回成功！")
            Case Status.TELL
                '1.待处理或3.已备料
                For index As Integer = 0 To alList.Count - 1
                    updateSQL.AppendFormat("UPDATE m_Equipment_App_t SET AStatus1=3,AStatus=N'备完料通知产线' WHERE ID={0} ;", alList(index))
                Next
                DbOperateUtils.ExecSQL(updateSQL.ToString)
                MessageUtils.ShowInformation("已备完料请通知产线！")
            Case Else
        End Select


    End Sub

    Private Sub GetRequestID(ByRef alList As ArrayList, ByRef alListRemark As ArrayList)
        For rowIndex As Integer = 0 To dgvResult.Rows.Count - 1
            If Not dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                   dgvResult.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                alList.Add(dgvResult.Rows(rowIndex).Cells("ID").EditedFormattedValue.ToString)
                alListRemark.Add(dgvResult.Rows(rowIndex).Cells("Remark").EditedFormattedValue.ToString)
            End If
        Next
    End Sub
#End Region

#Region "Common"

    Private Sub tabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl1.SelectedIndexChanged
        SetToolButton(False)
        If tabControl1.SelectedIndex = 0 Then
            toolNew.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False))
            btnAdd.Enabled = False
            btnRemove.Enabled = False
            toolExcel.Enabled = False
        ElseIf tabControl1.SelectedIndex = 1 Then
            toolNew.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False))
            txtMOID.Enabled = False
            '  txtPartNumber.Enabled = False  'mark by cq 20170712
            toolExcel.Enabled = False
        Else
            toolModify.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolModify.Tag) = "YES", True, False))
            toolDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False))
            toolAbandon.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolAbandon.Tag) = "YES", True, False))
            toolTell.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolTell.Tag) = "YES", True, False))
            toolQuery.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolQuery.Tag) = "YES", True, False))
            toolExcel.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolExcel.Tag) = "YES", True, False))
            '有查询权限直接显示初始数据
            If toolQuery.Enabled = True Then
                Search()
            End If
        End If
    End Sub

    Private Sub SetToolButton(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolDelete.Enabled = bFlag
        toolAbandon.Enabled = bFlag
        toolTell.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolQuery.Enabled = bFlag
    End Sub

    Private Sub ClearText()
        cboRequestClass2.Text = String.Empty
        cboRequestLine2.Text = String.Empty
        txtMOID.Text = String.Empty
        txtPartNumber.Text = String.Empty
    End Sub

    Private Function GetUserInfo() As DataTable
        Dim dt As DataTable
        Dim strSQL = "SELECT USERID+'/'+ISNULL(UserName,'') RequestUser,A.Dept ,B.dqc ,lineid  FROM m_Users_t A LEFT JOIN m_Dept_t B ON A.Dept=B.deptid " &
                    "where UserID = '" & VbCommClass.VbCommClass.UseId & "'"
        dt = DbOperateUtils.GetDataTable(strSQL)

        GetUserInfo = dt
    End Function

    Private Sub cboRequestClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass.SelectedIndexChanged
        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If
    End Sub

    Private Sub cboRequestClass2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass2.SelectedIndexChanged
        If cboRequestClass2.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine2, cboRequestClass2.SelectedValue.ToString)
        End If
    End Sub

    Private Sub cboQueryClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQueryClass.SelectedIndexChanged
        If cboQueryClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
        End If
    End Sub

#End Region

#Region "Grid行数"
    Private Sub dgvResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvResult.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvRequest_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvRequest.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvApply_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvApply.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvEquipment.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

    Private Sub txtPartNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            InputPartID()
        End If
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim Sql As String = String.Empty
        CheckQty = False

        If String.IsNullOrEmpty(Me.txtMOID.Text) AndAlso String.IsNullOrEmpty(Me.txtPartNumber.Text) Then
            MessageUtils.ShowError("请至少输入工单或者料号！")
            Exit Sub
        End If

        If Me.txtPartNumber.Text.Trim <> "" Then
            If (Me.txtPartNumber.Text.Trim.Split(CChar(";")).Length > 1) Then
                IsMultiLine = True
                Dim str As String = " AND PartID IN("
                Dim strloop As String = ""
                For i = 0 To Me.txtPartNumber.Text.Trim.Split(CChar(";")).Length - 1
                    strloop = strloop + ",'" + Me.txtPartNumber.Text.Trim.Split(CChar(";"))(i) + "'"
                Next
                Sql = str + strloop.Substring(1) + ")"
            Else
                Sql = Sql + " AND PartID LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            End If
        End If

        Call LoadEquBOMData(Sql)

    End Sub

    Private Sub LoadEquBOMData(ByVal SqlWhere As String)
        Dim strSQL As String = String.Empty, lineid As String = ""
        Dim dt As New DataTable

        strSQL = " SELECT A.EWPartNumber,B.DESCRIPTION,COUNT(1) Qty, a.PartID FROM m_RCardDPart_t A " & _
                 " INNER JOIN (SELECT TAvcPart,DESCRIPTION FROM m_PartContrast_t WHERE  TYPE='E') B ON A.EWPartNumber=B.TAvcPart " & _
                 " WHERE A.PartID IN (SELECT PartID FROM m_RCardM_t WHERE Status=1 " & SqlWhere & ") " & _
                 " GROUP BY A.PartID,A.EWPartNumber,B.DESCRIPTION"


        dt = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("工单对应的流程卡没有审核或没有工治具料号信息！")
            Exit Sub
        End If

        'txtPartNumber.Text = PartID
        cboRequestClass2.SelectedValue = DeptID
        lineid = CStr(cboRequestLine2.SelectedValue)
        Dim equPartNumber As String = ""
        Dim WhQty As Integer = 0
        Dim iCurrentLine As Integer = 0
        '默认选择 
        dgvApply.Rows.Clear()
        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            equPartNumber = dt.Rows(rowIndex)("EWPartNumber").ToString
            WhQty = GetWhQty(equPartNumber)
            iCurrentLine = GetLineQty(equPartNumber, lineid)
            If WhQty = 0 Then ' 库存为0不勾选
                dgvApply.Rows.Add("False", dt.Rows(rowIndex)("Qty").ToString, WhQty.ToString,
                                  equPartNumber, dt.Rows(rowIndex)("DESCRIPTION").ToString, iCurrentLine.ToString, dt.Rows(rowIndex)("PartID")
                                  )
            Else
                'checkbox, Qty, Wh, Equpart, des, 
                dgvApply.Rows.Add("True", dt.Rows(rowIndex)("Qty").ToString, WhQty.ToString,
                                equPartNumber, dt.Rows(rowIndex)("DESCRIPTION").ToString, iCurrentLine.ToString, dt.Rows(rowIndex)("PartID")
                                  )
            End If
        Next
    End Sub

    Private Sub chbBOMListSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chbBOMListSelect.CheckedChanged
        Try
            If (Me.dgvApply.RowCount > 0) Then
                For i As Int16 = 0 To CShort(Me.dgvApply.RowCount - 1)
                    dgvApply.Rows(i).Cells("colSelect").Value = Me.chbBOMListSelect.Checked
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentManualApply", "chbBOMListSelect_CheckedChanged", "Equ")
        End Try
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPartNumber.SelectedIndexChanged
        'Dim a(1) As String
        'a(0) = "---"
        'Dim sArray As String() = cboPartNumber.Text.ToString().Split(a, StringSplitOptions.RemoveEmptyEntries)
        'Dim Sql As String = " SELECT  ISNULL(adviceQTY,0) AS adviceQTY  FROM	m_equipmenthardware_t WHERE PartNumber = '" & sArray(0) & "'"
        'Dim dt As DataTable = DbOperateReportUtils.GetDataTable(Sql)
        'If dt.Rows.Count <= 0 Then
        '    Return
        'End If
        'txtRequestQty.Text = dt.Rows(0)(0).ToString()
    End Sub
End Class