Public Class FrmMaintenanceDetails
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Private _EquimentNO As String
    ''' <summary>
    ''' 设备编号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EquimentNO() As String
        Get
            Return _EquimentNO
        End Get
        Set(ByVal value As String)
            _EquimentNO = value
        End Set
    End Property

    Private Sub FrmMaintenanceDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoadMonth()
        DataLoadQuarter()
    End Sub

    ''' <summary>
    ''' 月保养流水记录
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoadMonth()
        Dim sql = "select * from m_AssetMaintenanceMonth_t where AssetNo='" & Me.EquimentNO & "' and convert(varchar(4),getdate(),121)='" & dtpYear.Text & "' order by CreateTime desc"
        dgvMonth.AutoGenerateColumns = False
        dgvMonth.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub

    ''' <summary>
    ''' 季度保养流水记录
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoadQuarter()
        Dim sql = "select * from m_AssetMaintenanceQuarter_t where AssetNo='" & Me.EquimentNO & "' and convert(varchar(4),getdate(),121)='" & dtpYear.Text & "' order by CreateTime desc"
        dgvQuarter.AutoGenerateColumns = False
        dgvQuarter.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub


    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoadMonth()
        DataLoadQuarter()
    End Sub
End Class