Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports MainFrame

Public Class FrmMouldSetForm

#Region "属性"
    Private _iSelectedMouldList As String  '初始
    Public m_SelectedMouldList As String
#End Region

    Sub New(ByVal o_StrSelectedMouldList As String, ByRef m_SelectedMouldList As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._iSelectedMouldList = o_StrSelectedMouldList

    End Sub

#Region "事件"
    Private Sub FrmMouldSetForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BindEquipmentGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "FrmRunCardPartDetail_Load", "sys")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim MouldIDList As String = ""
        Try
            '将当前用户选择保存到配置文件
            For Each row As DataGridViewRow In dgvMouldSelected.Rows
                MouldIDList = MouldIDList & row.Cells("MouldID2").Value & ","
            Next
            MouldIDList = MouldIDList.TrimEnd(",")
            ' ScanCommon.SaveEquipmentNo(_MoNo, _LineId, EquipmentList)
            m_SelectedMouldList = MouldIDList

            '  str = this.textBox1.Text;

            Me.DialogResult = DialogResult.OK

            Me.Close()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "btnOK_Click", "sys")
        End Try

    End Sub

#End Region

#Region "加载所有模具"

    Private Sub BindEquipmentGrid(Optional ByVal where As String = "")

        Dim strSQL As String = ""
        Try

            '根据配置文件标记是否选中
            'Dim EquipmentList As String = ScanCommon.GetEquipmentNo(_MoNo, _LineId)
            'strSQL = "execute GetEquipmentListSelected '" & EquipmentList & "','1',''"
            dgvMouldSelected.Rows.Clear()
            ' Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)


            For Each tempMould As String In _iSelectedMouldList.Split(",")
                ' dgvEquipmentSelected.Rows.Add(row("Flag").ToString(), row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("ServiceCount").ToString(), row("AlertCount").ToString(), row("RemainCount").ToString())
                dgvMouldSelected.Rows.Add("N", tempMould)
            Next

            dgvMouldSelected.Columns(1).ReadOnly = True

            '加载待选文件
            strSQL = "execute GetMouldListSelected '" & _iSelectedMouldList & "','3','" & where & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'"
            dgvMouldPart.Rows.Clear()
            Dim dt = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvMouldPart.Rows.Add(row("Flag").ToString(), row("MouldID").ToString())
            Next
            dgvMouldPart.Columns(1).ReadOnly = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="where"></param>
    ''' <remarks></remarks>
    Private Sub BindMouldGridSearch(Optional ByVal where As String = "")

        Dim strSQL As String = ""
        Try

            '根据配置文件标记是否选中
            ' Dim EquipmentList As String = ScanCommon.GetEquipmentNo(_MoNo, _LineId)
            strSQL = "execute GetMouldListSelected '" & _iSelectedMouldList & "','3','" & where & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'"
            dgvMouldPart.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvMouldPart.Rows.Add(row("Flag").ToString(), row("MouldID").ToString())
            Next
            dgvMouldPart.Columns(1).ReadOnly = True
            'dgvMouldPart.Columns(2).ReadOnly = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region

#Region "筛选工冶具"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtMouldID.Text.Trim <> "" Then
            BindMouldGridSearch(" AND ( MouldID LIKE N''%" & txtMouldID.Text.Trim & "%'') ")
        Else
            BindMouldGridSearch()
        End If
    End Sub

#End Region

    Private Sub txtMouldID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMouldID.KeyPress

        If e.KeyChar = Chr(13) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = dgvMouldPart.Rows.Count - 1 To 0 Step -1
            If dgvMouldPart.Rows(i).Cells("EQ_Select").Value.ToString() = "Y" Then
                dgvMouldSelected.Rows.Add("N", dgvMouldPart.Rows(i).Cells("MouldID").Value.ToString())
                dgvMouldPart.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i As Integer = dgvMouldSelected.Rows.Count - 1 To 0 Step -1
            If dgvMouldSelected.Rows(i).Cells("EQ_Select2").Value.ToString() = "Y" Then
                dgvMouldPart.Rows.Add("N", dgvMouldSelected.Rows(i).Cells("MouldID2").Value.ToString())
                dgvMouldSelected.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        Dim yy As String = ""
        Dim chk As CheckBox = CType(sender, CheckBox)
        yy = IIf(chk.Checked, "Y", "N")
        For Each dgvr As DataGridViewRow In dgvMouldPart.Rows
            dgvr.Cells("EQ_Select").Value = yy
        Next
    End Sub

End Class