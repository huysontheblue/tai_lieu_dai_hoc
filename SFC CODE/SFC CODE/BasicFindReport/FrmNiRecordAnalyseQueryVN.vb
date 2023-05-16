' 2019-11-26  Mr Luu Add Function : Query Data in NI Station
Imports MainFrame
Public Class FrmNiRecordAnalyseQueryVN
    Dim dtDept As DataTable = Nothing
    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmNiRecordAnalyseQueryVN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNiLine()
    End Sub


    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        If Not BasicCheck() Then Return
        LoadData()
    End Sub

    Private Sub LoadNiLine()
        Dim Teststion As DataTable
        Dim sql As String = "select  TestTypeID, TestTypeName from m_testtype_v WHERE USEY='Y' "
        Teststion = conn.GetDataTable(sql)
        conn.PubConnection.Close()

        CboDeptid.Items.Clear()

        For i = 0 To Teststion.Rows.Count - 1
            CboDeptid.Items.Add(Teststion.Rows(i)("TestTypeID") & "-" & Teststion.Rows(i)("TestTypeName"))
        Next
        'Dim sql As String = " Select distinct NiMacId from m_sendasndatainfo_t where IsUse='Y' "
        'dtDept = conn.GetDataTable(sql)
        'dtDept.Rows.InsertAt(dtDept.NewRow, 0)
        'CboDeptid.DataSource = dtDept
        'CboDeptid.DisplayMember = "NiMacId"
        'CboDeptid.ValueMember = "NiMacId"
        'conn.PubConnection.Close()
    End Sub

    Private Function BasicCheck()
        If DtStar.Value > DtEnd.Value Then
            MessageBox.Show(" Start time can not greater End time .")
            DtStar.Value = Now()
            DtEnd.Value = Now()
            Return False
        End If
        Dim startDate As DateTime = DateTime.Parse(DtStar.Text)
        Dim endDate As DateTime = DateTime.Parse(DtEnd.Text)
        If startDate.AddDays(1) < endDate Then
            MessageBox.Show(" Can not choose over 1 day .")
            Return False
        End If
        If String.IsNullOrEmpty(CboDeptid.Text) Then
            MessageBox.Show(" Please select NiMAC LineID .")
            Return False
        End If
        Return True
    End Function

    Public Sub LoadData()
        lbl_NiMACLineID.Text = CboDeptid.Text
        Dim Sql As String
        Sql = "SELECT SaveTableName  from m_testtype_v where TestTypeID='" & CboDeptid.Text.Split("-")(0) & "'"
        Dim testtable As DataTable
        testtable = conn.GetDataTable(Sql)

        Dim teble As String = testtable.Rows(0)("SaveTableName").ToString()
        Dim BeginDate As String = DtStar.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Dim EndDate As String = DtEnd.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Dim niMacIds As String = CboDeptid.Text
        Dim sql_All = " select count(*) Qty  from [MESDataCenter].dbo." & teble & " a  inner join ( select  ppid, min(COLLECTTIME) as mindate from [MESDataCenter].dbo." & teble & " where COLLECTTIME between '" & BeginDate & "' and  '" & EndDate & "'  group by ppid) b on a.ppid=b.ppid and a.COLLECTTIME=b.mindate   "
        Dim dt_All As DataTable = conn.GetDataTable(sql_All)
        If dt_All.Rows.Count > 0 Then
            lbl_Totaltested.Text = Convert.ToString(dt_All.Rows(0)("Qty").ToString())
        Else
            lbl_Totaltested.Text = "0"
        End If

        ' First time 

        Dim sql_AllPassMinTime = " select count(*) QtyPass  from [MESDataCenter].dbo." & teble & "  a  inner join ( select  ppid, min(COLLECTTIME) as mindate from [MESDataCenter].dbo." & teble & "  where COLLECTTIME between '" & BeginDate & "' and  '" & EndDate & "'  group by ppid) b on a.ppid=b.ppid and a.COLLECTTIME=b.mindate  where  a.result='PASS' "
        Dim dt_AllPassMinTime As DataTable = conn.GetDataTable(sql_AllPassMinTime)
        If dt_AllPassMinTime.Rows.Count > 0 Then
            lbl_FirstQtyPass.Text = Convert.ToString(dt_AllPassMinTime.Rows(0)("QtyPass").ToString())
        Else
            lbl_FirstQtyPass.Text = "0"
        End If

        Dim sql_AllFailMinTime = " select count(*) QtyFail  from [MESDataCenter].dbo." & teble & " a  inner join ( select  ppid, min(COLLECTTIME) as mindate from [MESDataCenter].dbo." & teble & " where COLLECTTIME between '" & BeginDate & "' and  '" & EndDate & "'  group by ppid) b on a.ppid=b.ppid and a.COLLECTTIME=b.mindate  where  a.result='FAIL' "
        Dim dt_AllFailMinTime As DataTable = conn.GetDataTable(sql_AllFailMinTime)
        If dt_AllFailMinTime.Rows.Count > 0 Then
            lbl_FirstQtyFail.Text = Convert.ToString(dt_AllFailMinTime.Rows(0)("QtyFail").ToString())
        Else
            lbl_FirstQtyFail.Text = "0"
        End If

        'Last time

        Dim sql_AllPassMaxTime = " select count(*) QtyPass  from [MESDataCenter].dbo." & teble & " a  inner join ( select  ppid, max(COLLECTTIME) as maxdate from [MESDataCenter].dbo." & teble & " where COLLECTTIME between '" & BeginDate & "' and  '" & EndDate & "'  group by ppid) b on a.ppid=b.ppid and a.COLLECTTIME=b.maxdate  where  a.result='PASS' "
        Dim dt_AllPassMaxTime As DataTable = conn.GetDataTable(sql_AllPassMaxTime)
        If dt_AllPassMaxTime.Rows.Count > 0 Then
            lbl_LastQtyPass.Text = Convert.ToString(dt_AllPassMaxTime.Rows(0)("QtyPass").ToString())
        Else
            lbl_LastQtyPass.Text = "0"
        End If

        Dim sql_AllFailMaxTime = " select count(*) QtyFail  from [MESDataCenter].dbo." & teble & " a  inner join ( select  ppid, max(COLLECTTIME) as maxdate from [MESDataCenter].dbo." & teble & " where COLLECTTIME between '" & BeginDate & "' and  '" & EndDate & "'  group by ppid) b on a.ppid=b.ppid and a.COLLECTTIME=b.maxdate  where  a.result='FAIL' "
        Dim dt_AllFailMaxTime As DataTable = conn.GetDataTable(sql_AllFailMaxTime)
        If dt_AllFailMaxTime.Rows.Count > 0 Then
            lbl_LastQtyFail.Text = Convert.ToString(dt_AllFailMaxTime.Rows(0)("QtyFail").ToString())
        Else
            lbl_LastQtyFail.Text = "0"
        End If

        lbl_RetestRateFirst.Text = Convert.ToString(Math.Round(Convert.ToDouble(lbl_FirstQtyPass.Text) * 100 / (Convert.ToDouble(lbl_FirstQtyFail.Text) + Convert.ToDouble(lbl_FirstQtyPass.Text)), 2, MidpointRounding.AwayFromZero))
        lbl_LastRetestRate.Text = Convert.ToString(Math.Round(Convert.ToInt32(lbl_LastQtyPass.Text) * 100 / (Convert.ToInt32(lbl_LastQtyFail.Text) + Convert.ToInt32(lbl_LastQtyPass.Text)), 2, MidpointRounding.AwayFromZero))
        lbl_Passrate.Text = lbl_LastRetestRate.Text
        lbl_Failrate.Text = Convert.ToString(Math.Round((100 - Convert.ToDouble(lbl_Passrate.Text)), 2, MidpointRounding.AwayFromZero))
        lbl_Retestrate.Text = Convert.ToString(Math.Round(Convert.ToDouble(lbl_LastRetestRate.Text) - Convert.ToDouble(lbl_RetestRateFirst.Text), 2, MidpointRounding.AwayFromZero))

        conn.PubConnection.Close()

    End Sub
    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

End Class