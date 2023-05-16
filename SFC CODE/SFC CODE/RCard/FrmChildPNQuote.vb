
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame


Public Class FrmChildPNQuote

#Region "����"

    Private _CQuoteNo As String
    Private _CPartNumber As String
    Private _CVersoon As String
    Private _CQuoteHour As String
    Private _CMatchingHour As String
    Private _CSumHour As String

#End Region

    Sub New(ByVal QuoteNo As String, ByVal PartNumber As String, ByVal Versoon As String, ByVal QuoteHour As String, ByVal MatchingHour As String, ByVal SumHour As String)
        ' �˵����� Windows ���������������ġ�
        InitializeComponent()
        ' �� InitializeComponent() ����֮������κγ�ʼ����
        Me._CQuoteNo = QuoteNo
        Me._CPartNumber = PartNumber
        Me._CVersoon = Versoon
        Me._CQuoteHour = QuoteHour
        Me._CMatchingHour = MatchingHour
        Me._CSumHour = SumHour
    End Sub

    Private Sub FrmChildPNQuote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbl_PartNumber.Text = Me._CPartNumber
        Me.lbl_Ver.Text = Me._CVersoon
        Me.lbl_MatchingHour.Text = Me._CMatchingHour
        Me.lbl_QuoteNo.Text = Me._CQuoteNo
        Me.lbl_SumHours.Text = Me._CSumHour

        '���ش��Ϻŵ��������Ϻ�
        GridViewBound()
        Me.ActiveControl = Me.txt_QtyTo

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If txt_QtyFrom.Text = String.Empty Or txt_QtyTo.Text = String.Empty Then
            MessageBox.Show("�Ӽ���ʼ��Ų���Ϊ�գ�")
            Exit Sub
        End If

        '����ֵ����ʾ�û�
        If Not IsNumeric(txt_QtyFrom.Text.Trim) Then
            MessageBox.Show("�Ӽ���ʼ��ű���Ϊ��ֵ��")
            Exit Sub
        End If

        If Not IsNumeric(txt_QtyTo.Text.Trim) Then

            MessageBox.Show("�Ӽ�������ű���Ϊ��ֵ��")
            Exit Sub
        End If

        '�����б����Ҫ��ʾ�û�

        If CheckRepeatData() Then

            ''�ڳ�Ʒ�Ϻź����-01��-02
            Dim FromQty As Integer = Val(txt_QtyFrom.Text.Trim)
            Dim ToQty As Integer = Val(txt_QtyTo.Text.Trim)
            Dim len As Integer
            For i As Integer = FromQty To ToQty Step 1

                If i < 100 Then
                    len = 2
                Else
                    len = i.ToString.Length

                End If
                dgvPartNumber.Rows.Add("N", lbl_PartNumber.Text.Trim, lbl_PartNumber.Text.Trim & "-" & i.ToString().PadLeft(len, "0"), 1, Nothing, Nothing, Nothing)
            Next

            toolStripStatusLabel3.Text = Me.dgvPartNumber.Rows.Count

        Else
            MessageBox.Show("���������ظ����Ѿ������ڱ���б��У��������飡")

        End If

    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click

        If Me.dgvPartNumber.Rows.Count = 0 Then
            MessageUtils.ShowInformation("û����Ҫɾ���ļ�¼��")
            Exit Sub
        End If

        Try

            Dim Selected As Boolean = False
            For i As Integer = dgvPartNumber.Rows.Count - 1 To 0 Step -1
                If dgvPartNumber.Rows(i).Cells(0).EditedFormattedValue.ToString() = "True" Then
                    Selected = True
                    dgvPartNumber.Rows.RemoveAt(i)
                End If
            Next

            If Not Selected Then
                MessageUtils.ShowInformation("���빴ѡ����Ҫɾ�����У�")
            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "tsbAbandon_Click", "sys")
            MessageUtils.ShowError("ɾ��ʧ�ܣ�")
        End Try

    End Sub

    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click

        If dgvPartNumber.Rows.Count <> 0 Then

            dgvPartNumber.Rows(0).Cells(0).Selected = True
        End If

        Dim SqlStr As New StringBuilder
        Try

            SqlStr.Append("delete from m_RCardQuoteMaintenanceDetail where QuoteNo='" & lbl_QuoteNo.Text.Trim & "'")
            For i As Integer = dgvPartNumber.Rows.Count - 1 To 0 Step -1
                SqlStr.Append("insert into [m_RCardQuoteMaintenanceDetail] (QuoteNo,PartNumber,C_PartNumber,UQuoteHour,Ncount,Creater,CreateTime,remark) values('" & lbl_QuoteNo.Text.Trim & "','" _
                               & lbl_PartNumber.Text.Trim & "','" & dgvPartNumber.Rows(i).Cells(2).Value & "','" & dgvPartNumber.Rows(i).Cells(4).Value & "','" & dgvPartNumber.Rows(i).Cells(3).Value & "','" & SysMessageClass.UseId & "',getdate(),'" & dgvPartNumber.Rows(i).Cells(6).Value & "' )")
            Next

            DbOperateUtils.ExecSQL(SqlStr.ToString)

            '�޸�������Ϣ
            DbOperateUtils.ExecSQL("exec Exec_UpdateRCardQuoteMaintenance '" & lbl_QuoteNo.Text.Trim & "','" & SysMessageClass.UseId & "' ")

            MessageUtils.ShowInformation("����ɹ���")
            Me.Close()

        Catch ex As Exception
            MessageUtils.ShowInformation("����ʧ�ܣ�")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNCode", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub

    Public Sub GridViewBound()

        Dim SqlStr As String = ""
        SqlStr = " select 'N' as Selected, QuoteNo,PartNumber,C_PartNumber,UQuoteHour,Ncount,UQuoteHour* Ncount as SumHours,remark from m_RCardQuoteMaintenanceDetail where QuoteNo='" & lbl_QuoteNo.Text.Trim & "'  order by C_PartNumber  "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            dgvPartNumber.Rows.Add("N", dt.Rows(i)("PartNumber"), dt.Rows(i)("C_PartNumber"), dt.Rows(i)("Ncount"), dt.Rows(i)("UQuoteHour"), dt.Rows(i)("SumHours"), dt.Rows(i)("remark"))
        Next
        toolStripStatusLabel3.Text = Me.dgvPartNumber.Rows.Count
    End Sub


    Public Function CheckRepeatData() As Boolean

        Dim FromQty As Integer = Val(txt_QtyFrom.Text.Trim)
        Dim ToQty As Integer = Val(txt_QtyTo.Text.Trim)
        Dim len As Integer = 0
        For i As Integer = FromQty To ToQty Step 1

            If i < 100 Then
                Len = 2
            Else
                Len = i.ToString.Length

            End If

            For j As Integer = 0 To dgvPartNumber.Rows.Count - 1 Step 1

                If lbl_PartNumber.Text.Trim & "-" & i.ToString().PadLeft(len, "0") = dgvPartNumber.Rows(j).Cells(2).Value Then
                    Return False
                    Exit Function
                End If
            Next

        Next

        Return True

    End Function

    ''' <summary>
    ''' ��Ԫ��༭����¼�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPartNumber_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartNumber.CellEndEdit
        Dim index As Integer = e.RowIndex
        If index <> -1 Then

            If dgvPartNumber.Rows(index).Cells(3).Value Is Nothing Then
                dgvPartNumber.Rows(index).Cells(3).Value = 1
            End If

            If Not dgvPartNumber.Rows(index).Cells(4).Value Is Nothing Then
                dgvPartNumber.Rows(index).Cells(5).Value = dgvPartNumber.Rows(index).Cells(3).Value * dgvPartNumber.Rows(index).Cells(4).Value

            End If

            If dgvPartNumber.Rows(index).Cells(4).Value <> lbl_UnitTime.Text And lbl_UnitTime.Text <> "" And lbl_UnitTime.Text <> "0" Then
                dgvPartNumber.Rows(index).Cells(4).Style.BackColor = Color.Red
                lbl_UnitTime.Text = ""
            End If


            '�����ܹ�ʱ
            Dim SumHours As Integer = 0
            Dim MacthingHours As Integer = 0

            For j As Integer = 0 To dgvPartNumber.Rows.Count - 1 Step 1

                '�ܹ�ʱ  '���׹�ʱ

                If Not dgvPartNumber.Rows(index).Cells(5).Value Is Nothing Then
                    SumHours = SumHours + dgvPartNumber.Rows(j).Cells(5).Value
                End If

                MacthingHours = MacthingHours + dgvPartNumber.Rows(j).Cells(3).Value * 30

            Next

            Me.lbl_SumHours.Text = SumHours
            Me.lbl_MatchingHour.Text = MacthingHours

        End If


    End Sub

    ''' <summary>
    ''' ��ʼ�¼�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPartNumber_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPartNumber.CellBeginEdit
        Dim index As Integer = e.RowIndex
        If index <> -1 Then
            If Not dgvPartNumber.Rows(index).Cells(4).Value Is Nothing Then
                lbl_UnitTime.Text = dgvPartNumber.Rows(index).Cells(4).Value
            End If
        End If

    End Sub


End Class