#Region "Imports"
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports MainFrame

#End Region

Public Class FrmBarCodeReplace

    Private m_moid As String
    Private m_partId As String
    Private m_printName As String
    Private m_cartonId As String
    Private m_cartonQty As String
    Private m_LabelNum As String

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

    Private Sub BnCancel_Click(sender As Object, e As EventArgs) Handles BnCancel.Click
        Me.Close()
    End Sub

    Private Sub BnOpenlock_Click(sender As Object, e As EventArgs) Handles BnOpenlock.Click
        Try
            If ScanCommon.IsTextBoxBlank(TxtPassWord, "请输入解锁密码!") = False Then Exit Sub
            If ScanCommon.IsOpenLock(TxtPassWord, "没有解锁权限!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(txtOldBarCode, "请输入原产品条码!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(txtNewBarCode, "请输入新产品条码!") = False Then Exit Sub
            If ScanCommon.IsNotEqual(txtNewBarCode, txtOldBarCode, "新产品条码和旧产品条码不能相同!") = False Then Exit Sub
            If ScanCommon.IsExsitCarton(txtNewBarCode, m_moid, "输入的条码录入已经录入到系统中,不能替换!") = False Then Exit Sub
            If ScanCommon.IsNotExsitCarton(txtOldBarCode, m_moid, m_cartonId, "输入的条码没有录入到系统中或者条码和工单配!") = False Then Exit Sub
            '条码替换
            ScanCommon.UpdateCartonsn(txtNewBarCode.Text.Trim, txtOldBarCode.Text.Trim)
            '重新打印
            PrintCarton()
            '窗体关闭
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmCartonRepeatPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub

    '重新打印
    Private Sub PrintCarton()
        Dim btApp As BarTender.Application = New BarTender.Application
        Dim btFormat As New BarTender.Format

        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '料号
        alist.Add(m_cartonQty) '包装数量
        alist.Add(txtNewBarCode.Text.Substring(4, 2)) '扫描的条码的周别
        printBarcode.PrintFullCarton(m_cartonId, m_LabelNum, alist)
    End Sub

End Class