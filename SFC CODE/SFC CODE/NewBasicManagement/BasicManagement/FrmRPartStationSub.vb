Imports MainFrame
Imports MainFrame.SysCheckData

'--料件工艺流程设置
'--Create by :　田玉琳
'--Create date :　2017/02/20
'--内容：A.第一层，第二层，第三层

Public Class FrmRPartStationSub


    '实期化
    Private Sub FrmRPartStationSub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbLevel.SelectedIndex = 0
        ListBox3.Visible = False

        BMComDB.BindComboxScanCodeSpec(cmbSpec)
        SetListBox()

    End Sub

    Private Sub SetListBox()
        Dim strSQL As String = " select VALUE, TEXT from m_BaseData_t where ITEMKEY = 'ScanCodeType' AND Status = 1 ORDER BY SORT "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        SetListboxText(dt, ListBox1, "ONE")
        SetListboxText(dt, ListBox2, "TWO")
        SetListboxText(dt, ListBox3, "THREE")
    End Sub

    Private Sub SetListboxText(dt As DataTable, listbox As ListBox, vals As String)
        Dim dr() As DataRow = dt.Select(String.Format("VALUE = '{0}'", vals))

        listbox.Items.Clear()
        For cnt As Integer = 0 To dr.Length - 1
            listbox.Items.Add(dr(cnt).ItemArray(1))
        Next
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If cmbSpec.Text = "" Then
            If ListBox1.Text = "" Then
                MessageUtils.ShowError("请选择第一层内容!")
                Exit Sub
            End If
            If ListBox2.Text = "" Then
                MessageUtils.ShowError("请选择第二层内容!")
                Exit Sub
            End If
            If cmbLevel.SelectedIndex = 1 And ListBox3.Text = "" Then
                MessageUtils.ShowError("请选择第三层内容!")
                Exit Sub
            End If
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLevel.SelectedIndexChanged, cmbSpec.SelectedIndexChanged
        If cmbLevel.SelectedIndex = 0 Then
            ListBox3.Visible = False
            lblThree.Visible = False
        ElseIf cmbLevel.SelectedIndex = 1 Then
            ListBox3.Visible = True
            lblThree.Visible = True
        End If
    End Sub

End Class