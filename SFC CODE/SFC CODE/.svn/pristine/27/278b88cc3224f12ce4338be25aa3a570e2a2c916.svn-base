Imports MainFrame

Public Class FrmRunCardSeries

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        bindSeries()
    End Sub

    Private _Series As String = ""
    Public Property Series() As String
        Get
            Return _Series
        End Get
        Set(ByVal value As String)
            _Series = value
        End Set
    End Property

    Private _PartID As String
    Public Property PartID() As String
        Get
            Return _PartID
        End Get
        Set(ByVal value As String)
            _PartID = value
        End Set
    End Property


    Private Sub FrmRunCardSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSeries.SelectedValue = Series
    End Sub

    Private Sub bindSeries()
        cmbSeries.DataSource = DbOperateUtils.GetDataTable("select * from  m_Series_t")
        cmbSeries.DisplayMember = "SeriesName"
        cmbSeries.ValueMember = "SeriesID"
        cmbSeries.SelectedIndex = -1
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        If String.IsNullOrEmpty(cmbSeries.Text.Trim()) Then
            MainFrame.SysCheckData.MessageUtils.ShowError("请选择一个系列")
            Exit Sub
        End If
        DbOperateUtils.ExecSQL("update m_RCardM_t set SeriesID='" & cmbSeries.SelectedValue & "' where partID='" & PartID & "'")
        MainFrame.SysCheckData.MessageUtils.ShowInformation("提交成功")
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class