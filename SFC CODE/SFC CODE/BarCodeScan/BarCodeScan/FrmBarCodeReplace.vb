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
            If ScanCommon.IsTextBoxBlank(TxtPassWord, "�������������!") = False Then Exit Sub
            If ScanCommon.IsOpenLock(TxtPassWord, "û�н���Ȩ��!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(txtOldBarCode, "������ԭ��Ʒ����!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(txtNewBarCode, "�������²�Ʒ����!") = False Then Exit Sub
            If ScanCommon.IsNotEqual(txtNewBarCode, txtOldBarCode, "�²�Ʒ����;ɲ�Ʒ���벻����ͬ!") = False Then Exit Sub
            If ScanCommon.IsExsitCarton(txtNewBarCode, m_moid, "���������¼���Ѿ�¼�뵽ϵͳ��,�����滻!") = False Then Exit Sub
            If ScanCommon.IsNotExsitCarton(txtOldBarCode, m_moid, m_cartonId, "���������û��¼�뵽ϵͳ�л�������͹�����!") = False Then Exit Sub
            '�����滻
            ScanCommon.UpdateCartonsn(txtNewBarCode.Text.Trim, txtOldBarCode.Text.Trim)
            '���´�ӡ
            PrintCarton()
            '����ر�
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmCartonRepeatPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub

    '���´�ӡ
    Private Sub PrintCarton()
        Dim btApp As BarTender.Application = New BarTender.Application
        Dim btFormat As New BarTender.Format

        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = m_printName
        Dim alist As ArrayList = New ArrayList
        alist.Add(m_partId)  '�Ϻ�
        alist.Add(m_cartonQty) '��װ����
        alist.Add(txtNewBarCode.Text.Substring(4, 2)) 'ɨ���������ܱ�
        printBarcode.PrintFullCarton(m_cartonId, m_LabelNum, alist)
    End Sub

End Class