Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmCartonRepeatPrint

    Private m_moid As String
    Private m_partId As String
    Private m_printName As String
    Private m_cartonId As String
    Private m_cartonQty As String
    Private m_LabelNum As String
    Private m_userid As String
    Private m_coderuleid As String
    Private m_lineid As String
    Private m_PrintType As EnumPrintType
    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format

    Enum EnumPrintType
        FullCartonSn
        PEPocket
        L01FullSn
        MultiPack
        FullRelationSn
    End Enum

    Public WriteOnly Property Moid() As String
        Set(value As String)
            m_moid = value
        End Set
    End Property

    Public WriteOnly Property PartId() As String
        Set(value As String)
            m_partId = value
        End Set
    End Property

    Public WriteOnly Property PrintName() As String
        Set(value As String)
            m_printName = value
        End Set
    End Property

    Public WriteOnly Property LabelNum() As String
        Set(value As String)
            m_LabelNum = value
        End Set
    End Property

    Public WriteOnly Property PrintType() As EnumPrintType
        Set(value As EnumPrintType)
            m_PrintType = value
        End Set
    End Property

    Public WriteOnly Property Lineid As String
        Set(value As String)
            m_lineid = value
        End Set
    End Property
    Public WriteOnly Property CodeRuleID As String
        Set(value As String)
            m_coderuleid = value
        End Set
    End Property
    Public WriteOnly Property UserID As String
        Set(value As String)
            m_userid = value
        End Set
    End Property

    Private Sub FrmCartonRepeatPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次

        btApp = New BarTender.Application
        btFormat = New BarTender.Format
    End Sub

    Private Sub FrmCartonRepeatPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
    End Sub

    Private Sub BnCancel_Click(sender As Object, e As EventArgs) Handles BnCancel.Click
        Me.Close()
    End Sub

    Private Sub BnOpenlock_Click(sender As Object, e As EventArgs) Handles BnOpenlock.Click
        Try
            If ScanCommon.IsTextBoxBlank(TxtBarcode, "请输入箱号或者产品条码!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(TxtPassWord, "请输入解锁密码!") = False Then Exit Sub
            'If ScanCommon.IsOpenLock(TxtPassWord, "没有解锁权限!") = False Then Exit Sub
            If ScanCommon.IsOpenLock(TxtPassWord, "没有解锁权限!") = False Then Exit Sub
            If ScanCommon.IsNotExsitCarton(TxtBarcode, m_moid, m_cartonId, "输入的箱号或者产品条码没有录入到系统中或者条码和工单配!") = False Then Exit Sub

            If m_PrintType = EnumPrintType.FullCartonSn Then
                ScanCommon.RePrintRecord(m_moid, m_cartonId)
                GetCodeRule()
                PrintCarton()
            ElseIf m_PrintType = EnumPrintType.PEPocket Then
                PrintPEpocket()
            ElseIf m_PrintType = EnumPrintType.L01FullSn Then
                PrintL01Carton()
            ElseIf m_PrintType = EnumPrintType.MultiPack Then
                PrintMultiCarton()
            ElseIf m_PrintType = EnumPrintType.FullRelationSn Then
                'ScanCommon.RePrintRecord(m_moid, m_cartonId)
                GetCodeRule()
                PrintCartonHWHL()
            End If
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmCartonRepeatPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub

    Private Sub PrintCarton()
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        printBarcode.CodeRuleID = m_coderuleid

        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_cartonQty) '包装数量
        alist.Add(TxtBarcode.Text.Substring(4, 2)) '扫描的条码的周别

        printBarcode.PrintFullCarton(m_cartonId, m_LabelNum, alist)

    End Sub

    Private Sub PrintCartonHWHL()
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        printBarcode.CodeRuleID = m_coderuleid

        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_cartonQty) '包装数量
        alist.Add(TxtBarcode.Text.Substring(4, 2)) '扫描的条码的周别

        printBarcode.PrintFullCartonHWHL(m_cartonId, m_LabelNum, alist)

    End Sub

    Private Sub PrintPEpocket()
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        Dim peCode As String = ""
        '没有找到对应的关联条码退出 
        If ScanCommon.GetPEcode(TxtBarcode.Text, peCode) = False Then Exit Sub
        ScanCommon.RePrintRecord(m_moid, peCode)

        printBarcode.RepeatPEPocketPrint(m_partId, peCode)
    End Sub
    Private Sub PrintL01Carton()
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_cartonQty) '包装数量
        alist.Add(TxtBarcode.Text.Substring(4, 2)) '扫描的条码的周别

        printBarcode.PrintL01FullCarton(m_cartonId, m_LabelNum, alist)
    End Sub
    Private Sub PrintMultiCarton()
        Dim printBarcode As New MultiPackOnlinePrint
        Dim str As String = printBarcode.PrintOnlineCarton(m_moid, m_partId, m_coderuleid, m_lineid, m_cartonId, m_userid, m_printName)
        If str <> "" Then
            MessageBox.Show("打印失败!")
            Exit Sub
        End If
    End Sub


    Private Sub GetCodeRule()
        Dim strSQL As String = " EXEC GetOnlinePrintRuleIdAndQty '{0}' "
        strSQL = String.Format(strSQL, m_partId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            m_coderuleid = dt.Rows(0)(0).ToString.ToString
            m_cartonQty = dt.Rows(0)(1).ToString.ToString
        End If

    End Sub

End Class