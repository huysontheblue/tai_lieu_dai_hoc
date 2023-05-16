Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports MainFrame

Public Class FrmNewEquipmentSetForm

#Region "属性"
    Private _LineId As String
    Private _MoNo As String
    Public SaveEquip As String = "N"
#End Region

    Sub New(ByVal LineId As String, ByVal MoNo As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._LineId = LineId
        Me._MoNo = MoNo

    End Sub

#Region "事件"
    Private Sub FrmNewEquipmentSetForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BindEquipmentGrid()

            BindComboxLine(Select_Xianbie, "")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "FrmRunCardPartDetail_Load", "sys")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim EquipmentList As String = ""
        Try
            '将当前用户选择保存到配置文件
            For Each row As DataGridViewRow In dgvEquipmentSelected.Rows
                EquipmentList = EquipmentList & row.Cells("EquipmentNo2").Value & ","
            Next
            EquipmentList = EquipmentList.TrimEnd(",")
            ScanCommon.SaveEquipmentNo(_MoNo, _LineId, EquipmentList)
            Me.SaveEquip = "Y"
            Me.Close()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "btnOK_Click", "sys")
        End Try

    End Sub

#End Region

#Region "加载所有冶具"

    Private Sub BindEquipmentGrid(Optional ByVal where As String = "")

        Dim strSQL As String = ""
        Try

            '根据配置文件标记是否选中
            Dim EquipmentList As String = ScanCommon.GetEquipmentNo(_MoNo, _LineId)
            strSQL = "execute GetEquipmentListSelected '" & EquipmentList & "','1',''"
            dgvEquipmentSelected.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvEquipmentSelected.Rows.Add(row("Flag").ToString(), row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("ServiceCount").ToString(), row("AlertCount").ToString(), row("RemainCount").ToString())
            Next
            dgvEquipmentSelected.Columns(1).ReadOnly = True
            dgvEquipmentSelected.Columns(2).ReadOnly = True

            '加载待选文件

            strSQL = "execute GetEquipmentListSelected '" & EquipmentList & "','3','" & where & "'"
            dgvEquipmentPart.Rows.Clear()
            dt = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvEquipmentPart.Rows.Add(row("Flag").ToString(), row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("ServiceCount").ToString(), row("AlertCount").ToString(), row("RemainCount").ToString())
            Next
            dgvEquipmentPart.Columns(1).ReadOnly = True
            dgvEquipmentPart.Columns(2).ReadOnly = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="where"></param>
    ''' <remarks></remarks>
    Private Sub BindEquipmentGridSearch(Optional ByVal where As String = "")

        Dim strSQL As String = ""
        Try

            '根据配置文件标记是否选中
            Dim EquipmentList As String = ScanCommon.GetEquipmentNo(_MoNo, _LineId)
            strSQL = "execute GetEquipmentListSelected '" & EquipmentList & "','3','" & where & "'"
            dgvEquipmentPart.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvEquipmentPart.Rows.Add(row("Flag").ToString(), row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("ServiceCount").ToString(), row("AlertCount").ToString(), row("RemainCount").ToString())
            Next
            dgvEquipmentPart.Columns(1).ReadOnly = True
            dgvEquipmentPart.Columns(2).ReadOnly = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region

#Region "筛选工冶具"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtEquipmentNo.Text.Trim <> "" Then
            If Select_Xianbie.Text.Trim <> "" Then
                BindEquipmentGridSearch(" AND ( EquipmentNo LIKE N''%" & txtEquipmentNo.Text.Trim & "%'' or ProcessParameters like N''% " & txtEquipmentNo.Text.Trim & "%'') AND ( lineid LIKE N''%" & Select_Xianbie.Text.Trim & "%'') ")
            Else
                BindEquipmentGridSearch(" AND ( EquipmentNo LIKE N''%" & txtEquipmentNo.Text.Trim & "%'' or ProcessParameters like N''% " & txtEquipmentNo.Text.Trim & "%'')  ")
            End If
        Else
            '  BindEquipmentGridSearch()
            If Select_Xianbie.Text.Trim <> "" Then
                BindEquipmentGridSearch(" AND ( lineid LIKE N''%" & Select_Xianbie.Text.Trim & "%'') ")
            Else
                BindEquipmentGridSearch()
            End If
        End If

    End Sub

#End Region

    Private Sub txtEquipmentNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquipmentNo.KeyPress

        If e.KeyChar = Chr(13) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = dgvEquipmentPart.Rows.Count - 1 To 0 Step -1
            If dgvEquipmentPart.Rows(i).Cells("EQ_Select").Value.ToString() = "Y" Then
                dgvEquipmentSelected.Rows.Add("N", dgvEquipmentPart.Rows(i).Cells("EquipmentNo").Value.ToString(), dgvEquipmentPart.Rows(i).Cells("ProcessParameters").Value.ToString(), dgvEquipmentPart.Rows(i).Cells("ServiceCount").Value.ToString(), dgvEquipmentPart.Rows(i).Cells("AlertCount").Value.ToString(), dgvEquipmentPart.Rows(i).Cells("RemainCount").Value.ToString())
                dgvEquipmentPart.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i As Integer = dgvEquipmentSelected.Rows.Count - 1 To 0 Step -1
            If dgvEquipmentSelected.Rows(i).Cells("EQ_Select2").Value.ToString() = "Y" Then
                dgvEquipmentPart.Rows.Add("N", dgvEquipmentSelected.Rows(i).Cells("EquipmentNo2").Value.ToString(), dgvEquipmentSelected.Rows(i).Cells("ProcessParameters2").Value.ToString(), dgvEquipmentSelected.Rows(i).Cells("ServiceCount2").Value.ToString(), dgvEquipmentSelected.Rows(i).Cells("AlertCount2").Value.ToString(), dgvEquipmentSelected.Rows(i).Cells("RemainCount2").Value.ToString())
                dgvEquipmentSelected.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        Dim yy As String = ""
        Dim chk As CheckBox = CType(sender, CheckBox)
        yy = IIf(chk.Checked, "Y", "N")
        For Each dgvr As DataGridViewRow In dgvEquipmentPart.Rows
            dgvr.Cells("EQ_Select").Value = yy
        Next
    End Sub
    Private Sub CheckAll2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAll2.CheckedChanged
        Dim yy As String = ""
        Dim chk As CheckBox = CType(sender, CheckBox)
        yy = IIf(chk.Checked, "Y", "N")
        For Each dgvr1 As DataGridViewRow In dgvEquipmentSelected.Rows
            dgvr1.Cells("EQ_Select2").Value = yy
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim FrmEquipmentSetOfZCTest As New FrmNewEquipmentSetFormZCTest(_LineId, _MoNo)
        FrmEquipmentSetOfZCTest.Owner = Me
        FrmEquipmentSetOfZCTest.ShowDialog()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub


    'Private Sub Select_Xianbie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Select_Xianbie.SelectedIndexChanged
    '    If Select_Xianbie.SelectedValue IsNot Nothing Then
    '        BindComboxLine(Select_Xianbie, "")
    '    End If
    'End Sub

    Public Shared Sub BindComboxLine(ByVal ColComboBox As ComboBox, cboClass As String)
        Dim strSQL As String = String.Format("SELECT distinct lineid FROM [m_Equipment_t] ", cboClass)
        'GetFatoryOther()

        BindCombox(strSQL, ColComboBox, "lineid", "lineid")

    End Sub

    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub

    Private Sub txtEquipmentNo_TextChanged(sender As Object, e As EventArgs) Handles txtEquipmentNo.TextChanged

    End Sub

    Private Sub Select_Xianbie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Select_Xianbie.SelectedIndexChanged

    End Sub

    Private Sub dgvEquipmentPart_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEquipmentPart.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    
End Class