Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmLifecontrol
    Public Mouldid As String
    Private Sub FrmLifecontrol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sSQL As String
        Try
            sSQL = "SELECT concat(datepart(YYYY,m.CheckDate),'年',datepart(MM,m.CheckDate),'月',datepart(DD,m.CheckDate),'日') " &
                  "CheckDate, m.MouldID, m.OutLineID, Parts, TheDayUseTimes, CheckedTimes, u.UserName" &
                 " FROM m_MouldLife_t m inner  join(select MouldID,MAX(ID) AS ID from m_MouldLife_t " &
                " group by MouldID) n on m.id=n.id " &
                " left join m_Users_t u on m.checkUserId=u.UserID " &
                "where M.MouldID = '" + Mouldid + "' group by CheckDate, m.MouldID, m.OutLineID, Parts, TheDayUseTimes, CheckedTimes, u.UserName,M.ID ORDER BY m.ID asc  "
            Dim ds As DataTable = DbOperateUtils.GetDataTable(sSQL)
            dgvBasis.DataSource = ds
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldLife", "LoadData", "sys")
        End Try
        dtCheckDate.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd HH:mm:ss")
        dtCheckDate1.Value = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        txtMouldID.Text = Mouldid
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim strSQL As String
        Try
            strSQL = "SELECT concat(datepart(YYYY,a.CheckDate),'年',datepart(MM,a.CheckDate),'月',datepart(DD,a.CheckDate),'日') CheckDate," &
                    "a.MouldID, a.OutLineID,Parts,TheDayUseTimes,CheckedTimes ,b.UserName FROM m_MouldLife_t a  " &
                    "LEFT JOIN m_Users_t b on a.checkUserId = b.UserID " &
                    "where a.MouldID = '" + txtMouldID.Text.Trim + "' AND a.CheckDate >='" + dtCheckDate.Value + "' AND a.CheckDate <='" + dtCheckDate1.Value + "' group by CheckDate,a.MouldID, a.OutLineID,Parts,TheDayUseTimes,CheckedTimes ,b.UserName,a.ID ORDER BY a.ID asc"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            dgvBasis.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldLife", "LoadData", "sys")
        End Try
    End Sub
End Class