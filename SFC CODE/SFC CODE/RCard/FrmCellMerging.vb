Imports MainFrame.SysCheckData

Public Class FrmCellMerging

    ''' <summary>
    ''' 排序
    ''' </summary>
    ''' <remarks></remarks>
    Public _OBy As String

    ''' <summary>
    ''' 工站ID标识
    ''' </summary>
    ''' <remarks></remarks>
    Public DetailID As String

    ''' <summary>
    ''' 工时
    ''' </summary>
    ''' <remarks></remarks>
    Public _WorkHours As String

    ''' <summary>
    ''' 平衡工时
    ''' </summary>
    ''' <remarks></remarks>
    Public m_BalanceHours As String

    ''' <summary>
    ''' 表头ID
    ''' </summary>
    ''' <remarks></remarks>
    Public _MID As String


    Private Sub FrmCellMerging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoad()
    End Sub

    Private Sub DataLoad()
        Dim sql = "select iif(b.CellMergingOrderBy is null,'False','True') as ChkItem,a.MainID," & vbCrLf &
        "a.ID,a.OrderBy,a.StationName,a.Equiment,a.SWorkingHours,a.BalanceHours from " & vbCrLf &
        "m_ProductStandardAllocationD_t a" & vbCrLf &
        "left join m_ProductStandardAllocationDMerging_t b " & vbCrLf &
        "on b.MainID=a.MainID and b.DetailID=a.ID and a.OrderBy=b.CellMergingOrderBy and b.OrderBy=" & Me._OBy & " " & vbCrLf &
        "where a.StationType='R' and a.MainID=" & Me._MID & " and  " & vbCrLf &
        "a.OrderBy not in (select CellMergingOrderBy from m_ProductStandardAllocationDMerging_t where MainID=" & Me._MID & " and OrderBy<>" & Me._OBy & ") and " & vbCrLf &
        "a.OrderBy not in (select OrderBy from m_ProductStandardAllocationDMerging_t where MainID=" & Me._MID & " and OrderBy<>" & Me._OBy & ") and " & vbCrLf &
        "cast(a.OrderBy as int)>" & Me._OBy & " order by  cast(a.OrderBy as int)"
        Dim dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        dgvInfo.AutoGenerateColumns = False
        dgvInfo.DataSource = dt
    End Sub

    Private Sub dgvInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInfo.CellClick
        If dgvInfo.Columns(e.ColumnIndex).Name = "ChkItem" Then
            Dim yy = CType(dgvInfo.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue, Boolean)
            dgvInfo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(yy = False, True, False)
        End If
    End Sub

    ''' <summary>
    ''' 合并
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBtnCellMerging_Click(sender As Object, e As EventArgs) Handles tsmiBtnCellMerging.Click
        Dim o_TempStdWorkHours As Double = 0  '标准工时
        Dim o_TempBalanceHours As Double = 0
        Try
            'MainID + "|" + DetailID + "|" + Me._OBy + "|" + OrderBy + "|" + o_strWorkHours
            Dim list = getCheckList()
            Dim sql = New System.Text.StringBuilder()
            sql.AppendLine("delete m_ProductStandardAllocationDMerging_t where MainID=" + Me._MID + " and OrderBy=" & Me._OBy & "")
            For Each Str As String In list
                sql.AppendLine("Insert into m_ProductStandardAllocationDMerging_t " & vbCrLf &
                "(MainID,DetailID,OrderBy,CellMergingOrderBy,InTime,EmpCode,AddWorkHours) values " & vbCrLf &
                "(" & Str.Split("|")(0) & "," & Str.Split("|")(1) & "," & Str.Split("|")(2) & "," & Str.Split("|")(3) & ",getdate(),'" & VbCommClass.VbCommClass.UseId & "'," & Str.Split("|")(4) & ")")
                o_TempStdWorkHours = Val(o_TempStdWorkHours) + Val(Str.Split("|")(4))

                o_TempBalanceHours = Val(o_TempBalanceHours) + Val(Str.Split("|")(5))
                sql.Append(" UPDATE m_ProductStandardAllocationD_t SET BalanceQty=null,BalancePerson=null,BalanceHours=null")
                sql.Append(" WHERE MainID = " + Me._MID + " And OrderBy = '" & Str.Split("|")(3) & "'")

            Next
            'SWorkingHours= cast(SWorkingHours AS decimal(8,1))+ " & o_TempStdWorkHours & "
            'iif(isnull(a.WorkingHours,0)=0,null,3600/a.WorkingHours) as BalanceQty
            'as is :SET BalanceQty=cast(3600/(cast(cast(SWorkingHours AS decimal(8,1))+ " & o_TempStdWorkHours & "/ isnull(BalancePerson,1) as decimal(18,1)))as decimal(18,1))")
            'now: 3600/New_BalanceHours
            sql.Append(" UPDATE m_ProductStandardAllocationD_t SET BalanceQty=cast(3600/(cast(cast(BalanceHours AS decimal(8,1))+ " & o_TempStdWorkHours & "/ isnull(BalancePerson,1) as decimal(18,1)))as decimal(18,1))")
            sql.Append(" ,BalanceHours= cast(BalanceHours AS decimal(8,1))+ " & o_TempBalanceHours & "/BalancePerson ")
            sql.Append(" WHERE MainID = " + Me._MID + " And OrderBy = '" & Me._OBy & "'")

            MainFrame.DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("合并成功!")
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("合并失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    Private Function getCheckList() As List(Of String)
        Dim list = New List(Of String)
        For Each dgvr As DataGridViewRow In dgvInfo.Rows
            If CType(dgvr.Cells("ChkItem").Value, Boolean) = True Then
                Dim MainID = dgvr.Cells("MainID").Value.ToString()
                Dim DetailID = dgvr.Cells("ID").Value.ToString()
                Dim OrderBy = dgvr.Cells("OrderBy").Value.ToString()
                Dim o_strWorkHours As String = dgvr.Cells("SWorkingHours").Value.ToString()
                Dim o_strBalanceHours As String = dgvr.Cells("BalanceHours").Value.ToString()
                list.Add(MainID + "|" + DetailID + "|" + Me._OBy + "|" + OrderBy + "|" + o_strWorkHours + "|" + o_strBalanceHours)
                ' o_strTotalHours = Val(o_strTotalHours) + Val(o_strWorkHours)
            End If
        Next
        Return list
    End Function

End Class