Public Class FrmAssetMaintenanceLog

    Private Sub FrmAssetMaintenanceLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboStatusDay.SelectedIndex = 0
        comboStatusMonth.SelectedIndex = 0
        txtAssetYear.Text = Date.Now.Year
        txtYearQuarter.Text = Date.Now.Year
        txtAssetMonths.Text = Date.Now.Month
        comboQuarter.Text = EquManageCommon.GetQuarter()
        comboStatusQuarter.SelectedIndex = 0
        DataLoad()
    End Sub

    ''' <summary>
    ''' 数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoad()
        Select Case TabControl1.SelectedIndex
            Case 0
                DataLoadDay()
            Case 1
                DataLoadMonth()
            Case 2
                DataLoadQuarter()
        End Select
    End Sub

    ''' <summary>
    ''' 日保养记录数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoadDay()
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtAssetDay.Text.Trim()) = False Then
            where += " and a.AssetNo like '%" & txtAssetDay.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(dtpAssetDay.Text) = False Then
            where += " and cast(Maintenancetime as date)='" & dtpAssetDay.Text & "'"
        End If
        If comboStatusDay.Text = "OK" Then
            where += " and a.Status='O'"
        ElseIf comboStatusDay.Text = "Ng" Then
            where += " and a.Status='X'"
        End If
        Dim sql = "select  a.AssetNo,a.MaintenanceProject," & vbCrLf &
        "iif(a.[Status]='O','OK','Ng') Status,a.Maintenancetime" & vbCrLf &
        ",a.CreateUserID+'/'+b.UserName as CreateUserID,a.Remark" & vbCrLf &
        "from m_AssetMaintenanceDay_t a" & vbCrLf &
        "left join m_Users_t b on b.UserID=a.CreateUserID" & vbCrLf & where
        dgvDay.AutoGenerateColumns = False
        dgvDay.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub

    ''' <summary>
    ''' 月保养记录数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoadMonth()
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtAssetMonth.Text.Trim()) = False Then
            where += " and a.AssetNo like '%" & txtAssetMonth.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtAssetYear.Text.Trim()) = False Then
            where += " and convert(varchar(4),a.CreateTime,23)='" & txtAssetYear.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtAssetMonths.Text.Trim()) = False Then
            where += " and a.Months='" & txtAssetMonths.Text.Trim() & "'"
        End If
        If comboStatusMonth.Text = "OK" Then
            where += " and a.Status='O'"
        ElseIf comboStatusMonth.Text = "Ng" Then
            where += " and a.Status='X'"
        End If
        Dim sql = "select  a.AssetNo,a.MaintenanceProject,a.Months," & vbCrLf &
        "iif(a.[Status]='O','OK','Ng') Status,a.CreateTime" & vbCrLf &
        ",a.CreateUserID+'/'+b.UserName as 'CreateUserID',a.Remark" & vbCrLf &
        "from m_AssetMaintenanceMonth_t a" & vbCrLf &
        "left join m_Users_t b on b.UserID=a.CreateUserID " & vbCrLf & where
        dgvMonth.AutoGenerateColumns = False
        dgvMonth.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub

    ''' <summary>
    ''' 季度保养数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoadQuarter()
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtAssetQuarter.Text.Trim()) = False Then
            where += " and a.AssetNo like '%" & txtAssetQuarter.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtYearQuarter.Text.Trim()) = False Then
            where += " and convert(varchar(4),a.CreateTime,23)='" & txtYearQuarter.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(comboQuarter.Text) = False Then
            where += " and a.Quarter='" & comboQuarter.Text & "'"
        End If
        If comboStatusQuarter.Text = "OK" Then
            where += " and a.Status='O'"
        ElseIf comboStatusQuarter.Text = "Ng" Then
            where += " and a.Status='X'"
        End If
        Dim sql = "select  a.AssetNo,a.MaintenanceProject,a.Quarter," & vbCrLf &
        "iif(a.[Status]='O','OK','Ng') Status,a.CreateTime" & vbCrLf &
        ",a.CreateUserID+'/'+b.UserName as 'CreateUserID',a.Remark" & vbCrLf &
        "from m_AssetMaintenanceQuarter_t a" & vbCrLf &
        "left join m_Users_t b on b.UserID=a.CreateUserID " & vbCrLf & where
        dgvQuarters.AutoGenerateColumns = False
        dgvQuarters.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub

   
    Private Sub btnClick(sender As Object, e As EventArgs) Handles btnAssetDay.Click, btnAssetmonth.Click, btnQuarter.Click
        DataLoad()
    End Sub

End Class