
'--包装参数设置
'--Create by :　马锋
'--Create date :　2016/09/09
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class FrmPackingCheckSetting

    Public packingCheckScan As PackingCheckScan

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _packingCheckScan As PackingCheckScan)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        packingCheckScan = _packingCheckScan

    End Sub

    Private Sub FrmPackingCheckSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'DbOperateUtils.GetDataTable("select lineid from Deptline_t where deptid='" & DeptStr & "' and factoryid='" & factoryidstr & "'  and usey='Y' order by lineid")
            'Me.CobLine.Items.Clear()
            'Me.CobSitId.Items.Clear()
            'While PubDataReader.Read
            '    Me.CobLine.Items.Add(PubDataReader("lineid").ToString)
            'End While
        Catch ex As Exception
            MessageBox.Show("加载异常,请关闭重试")
        End Try
    End Sub

    Private Sub btnConfir_Click(sender As Object, e As EventArgs) Handles btnConfir.Click
        Try
            If (Not String.IsNullOrEmpty(Me.txtNumberDdivisions.Text.Trim)) Then
                If (Not IsNumeric(Me.txtNumberDdivisions.Text.Trim)) Then
                    MessageBox.Show("重复数不是数字")
                    Exit Sub
                End If

                If (CInt(Me.txtNumberDdivisions.Text.Trim) <= 0) Then
                    MessageBox.Show("重复数必须大于0")
                    Exit Sub
                End If
            End If

            If (String.IsNullOrEmpty(Me.CobLine.SelectedValue)) Then
                MessageBox.Show("请选择扫描产线")
                Exit Sub
            End If

            packingCheckScan.NumberDdivisions = Me.txtNumberDdivisions.Text.Trim
            packingCheckScan.AffiliatedBarCode = Me.txtAffiliatedBarCode.Text.Trim
            packingCheckScan.LineId = Me.CobLine.SelectedValue.ToString
            packingCheckScan.MoId = Me.mtxtMOid.Text.Trim
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("设置异常")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, "")
            frmMOQuery.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOid.TextChanged
        Dim DeptStr As String = ""
        Dim SqlStr As String = ""
        Dim factoryidstr As String = ""
        Dim partid As String = ""
        CobLine.Items.Clear()
        CobLine.Text = ""

        If (Not String.IsNullOrEmpty(Me.mtxtMOid.Text)) Then
            Try
                SqlStr = "select deptid,Factory,moqty,partid,lineid from m_Mainmo_t where moid='" & Trim(Me.mtxtMOid.Text.Trim) & "' and  FinalY='N'  ORDER BY Createtime DESC "
                Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                Dim strLine As String = ""

                If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                    DeptStr = dtTemp.Rows(0).Item("deptid").ToString
                    factoryidstr = dtTemp.Rows(0).Item("Factory").ToString
                    CobLine.Text = dtTemp.Rows(0).Item("lineid").ToString
                    strLine = dtTemp.Rows(0).Item("lineid").ToString
                    partid = dtTemp.Rows(0).Item("partid").ToString
                End If

                Dim dtLineTemp As DataTable = DbOperateUtils.GetDataTable("select lineid from Deptline_t where deptid='" & DeptStr & "'  and usey='Y' order by lineid")
                Me.CobLine.Items.Clear()

                Me.CobLine.DataSource = dtLineTemp
                Me.CobLine.ValueMember = "lineid"
                Me.CobLine.DisplayMember = "lineid"

                If String.IsNullOrEmpty(strLine) Then
                    CobLine.SelectedIndex = -1
                Else
                    CobLine.Text = strLine
                End If
                packingCheckScan.PartId = partid

                Dim dtPackingCheckSettingTemp As DataTable = DbOperateUtils.GetDataTable("SELECT AffiliatedBarCode, NumberDdivisions FROM  m_PackingCheckSetting_t WHERE PartId = '" & partid & "'")

                If (dtPackingCheckSettingTemp.Rows.Count > 0) Then
                    Me.txtNumberDdivisions.Text = dtPackingCheckSettingTemp.Rows(0).Item("NumberDdivisions")
                    Me.txtAffiliatedBarCode.Text = dtPackingCheckSettingTemp.Rows(0).Item("AffiliatedBarCode")
                End If
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "mtxtMoid_textChanged", "sys")
                MessageBox.Show("工单信息加载异常")
                Exit Sub
            End Try
        End If
    End Sub

End Class