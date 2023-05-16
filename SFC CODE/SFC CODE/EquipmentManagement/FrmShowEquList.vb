Imports MainFrame
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmShowEquList
    Private iSecond As Integer
    Public m_iDefaulTabIndex As Integer = 0
    Public m_iDefaulSec As Integer = 30
    Public m_iNextShowTabIndex As Integer
    Dim col0Visible As Boolean = True



    Private Sub FrmShowEquList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Timer1.Enabled = True
        Me.lblRemain.Text = ""
        m_iNextShowTabIndex = 0
        iSecond = m_iDefaulSec
        Call ShowProdBoard(m_iNextShowTabIndex)
        style()
    End Sub
    '按Esc键退出窗体
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim WM_KEYDOWN As Integer = 256
        Dim WM_SYSKEYDOWN As Integer = 260

        If msg.Msg = WM_KEYDOWN Or msg.Msg = WM_SYSKEYDOWN Then

            Select Case keyData
                Case Keys.Escape
                    Me.Close()
            End Select
        End If

        Return False
    End Function
    '隐藏tabcontrol
    Private Sub style()
        dgvConsumble.Dock = System.Windows.Forms.DockStyle.Fill
        dgvConsumble.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvEquUsedTimes.Dock = System.Windows.Forms.DockStyle.Fill
        dgvEquUsedTimes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvKeepQuarter.Dock = System.Windows.Forms.DockStyle.Fill
        dgvKeepQuarter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'col0Visible = Not (col0Visible)
        'dgvConsumble.Columns(0).Visible = col0Visible
        'dgvEquUsedTimes.Columns(0).Visible = col0Visible
        'dgvKeepQuarter.Columns(0).Visible = col0Visible
        'TabControl1.SizeMode = TabSizeMode.Fixed
        'TabControl1.ItemSize = New Size(0, 1)
        
    End Sub
    Public Sub BinddgvUsedTimes()
        Dim strSQL As String = String.Format(" EXEC Exec_Biotechnologyboard_UsedTimesTwo '{0}','{1}'", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

        dgvEquUsedTimes.DataSource = ds.Tables(0)
    End Sub

    Public Sub BinddgvConsumble()
        Dim strSQL As String = String.Format(" EXEC Exec_Biotechnologyboard_Consumble '{0}','{1}'", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

        dgvConsumble.DataSource = ds.Tables(0)
    End Sub

    Public Sub BinddgvKeepQuarter()
        Dim strSQL As String = String.Format(" EXEC Exec_Biotechnologyboard_AssetKeep '{0}','{1}'", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

        dgvKeepQuarter.DataSource = ds.Tables(0)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedTab.Name.ToString()
            Case "Consumable"
                Call BinddgvConsumble()
            Case "UsedTimes"
                Call BinddgvUsedTimes()
            Case "KeepQuarter"
                Call BinddgvKeepQuarter()
            Case Else
                Call BinddgvConsumble()

        End Select


    End Sub

    Private Sub dgvConsumble_DataBindingComplete(sender As Object, e As Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvConsumble.DataBindingComplete
        For Each item As DataGridViewRow In dgvConsumble.Rows
            If item.Cells("备注").Value.ToString = "需购置" Then
                item.DefaultCellStyle.BackColor = Color.Yellow
            Else
                item.DefaultCellStyle.BackColor = Color.Green
            End If
        Next


    End Sub

    Private Sub dgvEquUsedTimes_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvEquUsedTimes.DataBindingComplete
        For Each item As DataGridViewRow In dgvEquUsedTimes.Rows
            If item.Cells("备注").Value.ToString = "待维护寿命管制" Then
                item.DefaultCellStyle.BackColor = Color.Yellow
            Else
                item.DefaultCellStyle.BackColor = Color.Red
            End If
        Next


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        iSecond = iSecond - 1
        If iSecond > 0 Then
            lblRemain.Text = iSecond.ToString + "秒后刷新"
        Else
            lblRemain.Text = ""
        End If
        If iSecond < 0 Then

            If m_iNextShowTabIndex = 2 Then
                m_iNextShowTabIndex = 0
            Else
                m_iNextShowTabIndex = m_iNextShowTabIndex + 1
            End If

            Call ShowProdBoard(m_iNextShowTabIndex)
            iSecond = m_iDefaulSec
            ' m_iNextShowTabIndex = m_iNextShowTabIndex + 1

            'If m_iNextShowTabIndex = 2 Then
            '    m_iNextShowTabIndex = 0
            'Else
            '    m_iNextShowTabIndex = m_iNextShowTabIndex + 1
            'End If
        End If
    End Sub

    Private Sub ShowProdBoard(m_iNextShowTabIndex)
        Select Case m_iNextShowTabIndex
            Case 0

                'For Each tab As TabPage In Me.TabControl1.TabPages
                '    If tab.Name = Me.TabControl1.TabPages(0).Name Then
                '        'do nothing
                '    Else
                '        tab.Parent = Nothing
                '    End If
                'Next

                Me.TabControl1.SelectedTab = Me.TabControl1.TabPages("Consumable")
                Me.TabControl1.TabPages("Consumable").Parent = Me.TabControl1

                Call BinddgvConsumble()
                'Me.TabControlD.Visible = True
                'Me.TabControlD.SelectedTab = Me.TabPageP
                'Me.TabPageLoss.Parent = Nothing
                'Me.TabPageSupport.Parent = Nothing
                'Me.TabPageP.Parent = Me.TabControlD
                'm_ActionFlag = enumActionFlag.ProductiveSave


            Case 1
                'For Each tab As TabPage In Me.TabControl1.TabPages
                '    If tab.Name = Me.TabControl1.TabPages(1).Name Then
                '        'do nothing
                '    Else
                '        tab.Parent = Nothing
                '    End If
                'Next

                Me.TabControl1.SelectedTab = Me.TabControl1.TabPages("UsedTimes")
                Me.TabControl1.TabPages("UsedTimes").Parent = Me.TabControl1

                Call BinddgvUsedTimes()
            Case 2
                'For Each tab As TabPage In Me.TabControl1.TabPages
                '    If tab.Name = Me.TabControl1.TabPages(2).Name Then
                '        'do nothing
                '    Else
                '        tab.Parent = Nothing
                '    End If
                'Next
                Me.TabControl1.SelectedTab = Me.TabControl1.TabPages("KeepQuarter")
                Me.TabControl1.TabPages("KeepQuarter").Parent = Me.TabControl1


                Call BinddgvKeepQuarter()
            Case Else


        End Select

    End Sub

    Private Sub chkStop_CheckedChanged(sender As Object, e As EventArgs) Handles chkStop.CheckedChanged
        If chkStop.Checked Then
            Me.Timer1.Enabled = False
        Else
            Me.Timer1.Enabled = True
        End If
    End Sub

    Private Sub dgvKeepQuarter_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvKeepQuarter.DataBindingComplete

        '绿色底纹备注改为已保养    黄色底纹的改为待保养即可

        For Each item As DataGridViewRow In dgvKeepQuarter.Rows

            If IsNothing(item.Cells("备注").Value) Then
                Exit For
            End If

            If item.Cells("备注").Value.ToString = "待保养" Then
                item.DefaultCellStyle.BackColor = Color.Yellow
            Else
                item.DefaultCellStyle.BackColor = Color.GreenYellow
            End If
        Next

    End Sub

    Private Sub dgvEquUsedTimes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvEquUsedTimes.KeyPress
        Clipboard.SetData("Text", Clipboard.GetText())
    End Sub

    Private Sub dgvKeepQuarter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvKeepQuarter.KeyPress
        Clipboard.SetData("Text", Clipboard.GetText())
    End Sub

    Private Sub dgvConsumble_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvConsumble.KeyPress
        Clipboard.SetData("Text", Clipboard.GetText())
    End Sub
End Class