
Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Public Class FrmOnlinePrintCarton

    Private m_printName As String
    Private m_PackQty As String
    Private m_moid As String
    Private m_partId As String
    Private m_cartonId As String
    Private m_labelnum As String
    Private m_barcode As String

    Private m_PrintType As EnumPrintType
    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format


    Enum EnumPrintType
        CartonA4
        CartonQR
    End Enum

    Public WriteOnly Property PrintType() As EnumPrintType
        Set(value As EnumPrintType)
            m_PrintType = value
        End Set
    End Property

    Public WriteOnly Property PrintName() As String
        Set(value As String)
            m_printName = value
        End Set
    End Property
    Public WriteOnly Property Moid() As String
        Set(value As String)
            m_moid = value
        End Set
    End Property
    Public WriteOnly Property CartonId() As String
        Set(value As String)
            m_cartonId = value
        End Set
    End Property
    Public WriteOnly Property PackQty() As String
        Set(value As String)
            m_PackQty = value
        End Set
    End Property

    Public WriteOnly Property PartId() As String
        Set(value As String)
            m_partId = value
        End Set
    End Property

    Public WriteOnly Property LabelNum() As String
        Set(value As String)
            m_labelnum = value
        End Set
    End Property

    Public WriteOnly Property Barcode() As String
        Set(value As String)
            m_barcode = value
        End Set
    End Property

#Region "事件"
    Private Sub FrmOnlinePrintCarton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次

        SetComBox()
        Dim findIndex As Integer = 0
        If m_PrintType = EnumPrintType.CartonQR Then
            Me.Text = Me.Text + " 二维码"

            For i As Integer = 0 To cboPack.Items.Count - 1
                If DirectCast(cboPack.Items(i), System.Data.DataRowView).Row.ItemArray(1).Contains("QR") Then
                    findIndex = i
                End If
            Next
            cboPack.SelectedIndex = findIndex
        ElseIf m_PrintType = EnumPrintType.CartonA4 Then
            Me.Text = Me.Text + " A4"

            For i As Integer = 0 To cboPack.Items.Count - 1
                If DirectCast(cboPack.Items(i), System.Data.DataRowView).Row.ItemArray(1).Contains("A4") Then
                    findIndex = i
                End If
            Next
            cboPack.SelectedIndex = findIndex
        End If

        NewPrint()
    End Sub

    Private Sub SetComBox()
        Dim strSQL As String =
            " SELECT PFormatID, CONVERT(VARCHAR,PackItem) + '/' + Packid + '/' + CodeRuleID + '/' + PFormatID + ':'+ DESCRIPTION CodeRuleName FROM m_PartPack_t " &
            " WHERE PackId <> 'A' AND PackId <> 'S' AND PackId <> 'P' AND ISNULL(DisorderTypeId,'') <> 'S' AND USEY='Y' AND Partid='" & m_partId & "'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        'Dim dr As DataRow = dt.NewRow
        'dr("CodeRuleID") = ""
        'dr("CodeRuleName") = ""
        'dt.Rows.InsertAt(dr, 0)

        Me.cboPack.DisplayMember = "CodeRuleName"
        Me.cboPack.ValueMember = "PFormatID"
        Me.cboPack.DataSource = dt
    End Sub

    Private Function GetTemplatePath() As String
        Dim strSQL As String = " SELECT TEMPLATEPath FROM m_SnMFormat_t WHERE PFormatID = '{0}'"
        If cboPack.SelectedValue Is Nothing Then
            SetComBox()
            Dim formatid As String = ""
            For i As Integer = 0 To cboPack.Items.Count - 1
                If DirectCast(cboPack.Items(i), System.Data.DataRowView).Row.ItemArray(1).ToString.Contains("QR") Then
                    formatid = DirectCast(cboPack.Items(i), System.Data.DataRowView).Row.ItemArray(0)
                    Exit For
                End If
            Next
            strSQL = String.Format(strSQL, formatid)
        Else
            strSQL = String.Format(strSQL, cboPack.SelectedValue.ToString)
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            GetTemplatePath = dt.Rows(0)(0).ToString
        End If
    End Function

    Public Sub NewPrint()
        btApp = New BarTender.Application
        btFormat = New BarTender.Format
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If ScanCommon.IsTextBoxBlank(txtBarcode, "请输入外箱或箱内产品条码!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(txtPassword, "请输入解锁密码!") = False Then Exit Sub
            If ScanCommon.IsOpenLock(txtPassword, "没有解锁权限!") = False Then Exit Sub
            If ScanCommon.IsComBoxBlank(cboPack, "请选择要打印的模板文件，没有找到要找标签房设置!") = False Then Exit Sub

            m_barcode = txtBarcode.Text.Trim
            GetDataPrint()
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmOnlineWorkPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub

    Public Sub GetDataPrint()
        '获取箱号信息
        GetCartonData()
        If String.IsNullOrEmpty(m_cartonId) Then
            MessageUtils.ShowError("外箱或箱内产品条码不存在,请重新输入!")
            Exit Sub
        End If
        '打印
        PrintFullCarton()
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub FrmOnlinePrintCarton_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBarcode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarcode.PreviewKeyDown
        If e.KeyValue = 13 Then
            txtPassword.Focus()
        End If

    End Sub
#End Region

#Region "函数"
    '装满箱后打印条码
    Private Sub PrintFullCarton()
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        printBarcode.CodeRuleID = cboPack.SelectedValue.ToString()
        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_PackQty) '包装数量

        Dim tempPath As String = GetTemplatePath()

        'If m_PrintType = EnumPrintType.CartonQR Then
        '    tempPath = "C147-F07\GPTEST_carton-QR.btw"
        'ElseIf m_PrintType = EnumPrintType.CartonA4 Then
        '    tempPath = "C147-F07\GPTEST_carton-A4.btw"
        'End If

        printBarcode.PrintOnlineFullCartonQR(m_cartonId, m_labelnum, tempPath, alist)

    End Sub

    '获取装箱信息
    Private Sub GetCartonData()
        Try
            Dim o_strSql As New StringBuilder
            o_strSql.Append("select distinct a.Cartonid,a.Cartonqty  from m_carton_t(nolock) a ")
            o_strSql.Append(" left join m_cartonsn_t(nolock) b on b.Cartonid=a.Cartonid ")
            o_strSql.Append(" where a.moid='" & m_moid & "' and   (a.cartonid='" & m_barcode & "' or b.ppid='" & m_barcode & "')")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                m_cartonId = dt.Rows(0)!Cartonid.ToString
                m_PackQty = dt.Rows(0)!Cartonqty.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlinePrintCarton", "GetCartonData", "sys")
        End Try
    End Sub
#End Region



End Class