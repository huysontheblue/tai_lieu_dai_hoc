Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmEquipmentLog

    Private _EquimentNO As String
    ''' <summary>
    ''' 装备编号
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

    Private Sub dataLoad()
        dgvData.AutoGenerateColumns = False
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select a.*,b.UserName from m_EquipmentLog_t a left join m_Users_t b on  b.UserID=a.UserID where EquipmentNo='" & EquimentNO & "'order by a.InTime desc")
        dgvData.DataSource = dt
        ToolStripStatusLabel1.Text = "记录笔数:" + dt.Rows.Count.ToString()
    End Sub

    Private Sub FrmEquipmentLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataLoad()
    End Sub
End Class