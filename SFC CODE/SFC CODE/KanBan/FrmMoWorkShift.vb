Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text

Public Class FrmMoWorkShift

    Private m_lineid As String
    Private m_moid As String
    Private m_deptid As String
    Public WriteOnly Property Moid() As String
        Set(value As String)
            m_moid = value
        End Set
    End Property
    Public WriteOnly Property DeptId() As String
        Set(value As String)
            m_deptid = value
        End Set
    End Property
    Public WriteOnly Property LineId() As String
        Set(value As String)
            m_lineid = value
        End Set
    End Property

    Private Sub FrmmMoWorkShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '第一次执行
        If Me.DesignMode = True Then Exit Sub

        CboLine.Text = m_lineid
        TxtMoid.Text = m_moid
        comDeptid.Text = m_deptid
        Dim sqlstr As New StringBuilder
        sqlstr.Append("declare @Moid varchar(50)='" & m_moid & "',@Deptid varchar(20)='" & comDeptid.Text.Trim.Split("-")(0) & "',@Lineid varchar(20)='" & m_lineid & "',@Quorum varchar(20),@RealNum varchar(20),@PlanQty varchar(20)")
        sqlstr.Append(" if exists(select top 1 * from [m_MoWorkShift_t] where moid=@Moid and Deptid=@Deptid and lineid=@Lineid and CONVERT(VARCHAR,StartTime,111) =CONVERT(VARCHAR,GETDATE(),111))")
        sqlstr.Append(" begin")
        sqlstr.Append(" select top 1 @Quorum=Quorum,@RealNum=RealNum from [m_MoWorkShift_t] where moid=@Moid and Deptid=@Deptid and lineid=@Lineid and CONVERT(VARCHAR,StartTime,111) =CONVERT(VARCHAR,GETDATE(),111) ")
        sqlstr.Append(" end")
        sqlstr.Append(" else")
        sqlstr.Append(" select @Quorum=lineman from deptlineD_t where lineid=@Lineid")
        sqlstr.Append(" select @PlanQty=PlanQuantity from m_MoWorkPlan_t where Moid=@Moid  and PlanDay=CONVERT(varchar(100), GETDATE(), 23)")
        sqlstr.Append(" select Quorum=isnull(@Quorum,0),RealNum=isnull(@RealNum,0),PlanQty=isnull(@PlanQty,0)")
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr.ToString)
        If dt.Rows.Count > 0 Then
            txtRealNum.Text = dt.Rows(0)("RealNum")
            txtQuorum.Text = dt.Rows(0)("Quorum")
        End If

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If CheckData() = False Then Exit Sub

            SaveData()

            MessageUtils.ShowInformation("保存成功！")
            Me.Close()

            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmmMoWorkShift", "btnOk_Click", "KanBan")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function CheckData() As Boolean
        If Val(Me.txtRealNum.Text.Trim()) <= 0 Then
            MessageUtils.ShowError("实到人数必须大于0!")
            Me.txtRealNum.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SaveData()
        Dim strSQL As String = "exec Exec_InsertMoWorkShift @Factory,@profitcenter,@Moid,@Deptid,@Lineid,@Realman,@UserId "
        Dim al As ArrayList = New ArrayList
        al.Add(String.Format("Factory|{0}", VbCommClass.VbCommClass.Factory))
        al.Add(String.Format("profitcenter|{0}", VbCommClass.VbCommClass.profitcenter))
        al.Add(String.Format("Moid|{0}", TxtMoid.Text.Trim))
        al.Add(String.Format("Deptid|{0}", comDeptid.Text.Trim.Split("-")(0)))
        al.Add(String.Format("Lineid|{0}", CboLine.Text))
        al.Add(String.Format("Realman|{0}", txtRealNum.Text.Trim))
        al.Add(String.Format("UserId|{0}", VbCommClass.VbCommClass.UseId))
        DbOperateUtils.ExecuteNonQureyByProc("Exec_InsertMoWorkShift", al)
    End Sub

    '实到人数
    Private Sub txtRealNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRealNum.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class