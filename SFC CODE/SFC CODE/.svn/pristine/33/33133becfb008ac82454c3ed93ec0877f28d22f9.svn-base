Imports MainFrame
Imports System.Text.RegularExpressions
Imports System.Text
Imports MainFrame.SysCheckData
Public Class FrmQCAddBatch

    ''' <summary>
    ''' 修改者： 黄广都
    ''' 修改日： 2020/01/13
    ''' 修改内容：
    ''' -------------------修改记录---------------------
    ''' 
    ''' </summary>
    ''' <remarks>品质抽检新增批号</remarks>
    ''' 
#Region "属性"
    Private m_CId As String
    Public Property CId() As String
        Get
            Return m_CId
        End Get

        Set(ByVal Value As String)
            m_CId = Value
        End Set
    End Property

    Private m_CheckLevel As String
    Public Property CheckLevel() As String
        Get
            Return m_CheckLevel
        End Get

        Set(ByVal Value As String)
            m_CheckLevel = Value
        End Set
    End Property

    Private m_Moid As String
    Public Property Moid() As String
        Get
            Return m_Moid
        End Get

        Set(ByVal Value As String)
            m_Moid = Value
        End Set
    End Property
    Private m_PartNo As String
    Public Property PartNo() As String
        Get
            Return m_PartNo
        End Get

        Set(ByVal Value As String)
            m_PartNo = Value
        End Set
    End Property

    Private m_MoQty As String
    Public Property MoQty() As String
        Get
            Return m_MoQty
        End Get

        Set(ByVal Value As String)
            m_MoQty = Value
        End Set
    End Property


    Private m_QcQty As String
    Public Property QcQty() As String
        Get
            Return m_QcQty
        End Get

        Set(ByVal Value As String)
            m_QcQty = Value
        End Set
    End Property

    Private m_FunCheckRatio As String
    Public Property FunCheckRatio() As String
        Get
            Return m_FunCheckRatio
        End Get

        Set(ByVal Value As String)
            m_FunCheckRatio = Value
        End Set
    End Property

#End Region
#Region "事件"
    Private Sub FrmQCAddBatch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQcQty.Focus()
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If SaveData() = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
           
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub
    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmMOQuery
            frmMOQuery = New FrmMOQuery(Me.mtxtMOid, "")

            If frmMOQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


#End Region

#Region "函数"
    Private Function SaveData() As Boolean
        Try
            Dim sb As New StringBuilder
            If CheckData() = True Then
                sb.Append(" DECLARE @No nvarchar(30) select @No=dbo.fun_NewCheckCId()")
                sb.Append("INSERT INTO dbo.m_QCCheckMain_t")
                sb.Append("(CId,Moid,PartNo,CheckQty,CheckLevel,FunCheckRatio,OkQty,NgQty,MA_Qty,MI_Qty,CR_Qty,Status,Result,CreateUserId,CreateTime) ")
                sb.Append(" VALUES(@No,'" & m_Moid & "','" & m_PartNo & "'," & txtQcQty.Text.Trim & ",N'" & Me.m_CheckLevel & "'," & Me.m_FunCheckRatio & "")
                sb.Append(" ,0,0,0,0,0,'N','N/A','" & VbCommClass.VbCommClass.UseId & "',GETDATE())")
                sb.Append(" select @No ")
                Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
                If dt.Rows.Count > 0 Then
                    Me.m_CId = dt.Rows(0)(0).ToString
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function
    Private Function CheckData() As Boolean
        If String.IsNullOrEmpty(mtxtMOid.Text) Then

            MessageUtils.ShowWarning("请输入工单！")
            Return False
        End If
    
        If String.IsNullOrEmpty(Me.txtQcQty.Text) Then
            MessageUtils.ShowWarning("请输入本批数量！")
            Return False
        End If
        If RegexNumber(Me.txtQcQty.Text) = False Then
            MessageUtils.ShowWarning("本批数量只能输入数字型！")
            Return False
        End If
        If CheckQCMaxSync(Me.mtxtMOid.Text) = False Then
            MessageUtils.ShowWarning("当前工单已有未检验批，请先检验！")
            Return False
        End If
        If CheckSnCheckIn() = False Then
            Return False
        End If
        If SetQcProperty() = False Then
            MessageUtils.ShowWarning("获取抽验计划失败,请检查!")
            Return False
        End If
        If Me.m_FunCheckRatio = "0" Then
            MessageUtils.ShowWarning("获取功能抽验比例失败，请检查！")
            Return False
        End If

        Return True
    End Function

    Private Function CheckSnCheckIn() As Boolean
        Try
            Dim sb As New StringBuilder
            sb.Append("select moid,count(1) as qty from [dbo].[m_QCCheckInSnList_t] where moid='" & mtxtMOid.Text & "' and Status='N' ")
            sb.Append("  group by moid,Status")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
            If dt.Rows.Count > 0 Then
                Dim qty As Integer
                qty = dt.Rows(0)!qty.ToString

                If CInt(txtQcQty.Text) > CInt(qty) Then

                    MessageUtils.ShowWarning("输入的数量大于可检验的数量" & qty & ",请确认")

                    Return False
                End If
            Else
                MessageBox.Show("该工单没有可检验的SN,请确认", "提示")
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetQcProperty() As Boolean
        Try
            Dim sb As New StringBuilder
            sb.Append(" select TOP 1 a.moid,a.PartID,a.Moqty,c.SamplingType,d.CheckLevel,d.FuncQCRatio from m_Mainmo_t a inner join ")
            sb.Append("   m_RPartStationD_t b on a.PartID=b.PPartid inner join ")
            sb.Append("   m_QCSamplingPlan_t c on c.SamplingId=b.QCPlanId left  join ")
            sb.Append(" m_QCSamplingPlanDetail_t d on d.SamplingId=c.SamplingId and d.IsDefault='Y' ")
            sb.Append("   where a.moid='" & mtxtMOid.Text & "' and b.State='1' and b.IsQCPlan='Y' ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
            If dt.Rows.Count > 0 Then
                Me.m_Moid = dt.Rows(0)!moid.ToString
                Me.m_MoQty = dt.Rows(0)!Moqty.ToString
                Me.m_PartNo = dt.Rows(0)!PartID.ToString
                Me.m_CheckLevel = dt.Rows(0)!CheckLevel.ToString
                Me.m_FunCheckRatio = dt.Rows(0)!FuncQCRatio.ToString

                If dt.Rows(0)!SamplingType.ToString = "C" Then
                    Me.m_CheckLevel = "正常"
                    SetFunCheckRatio(Me.m_Moid)
                End If
                Me.m_QcQty = Me.txtQcQty.Text

                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function
    ''' <summary>
    ''' 设置功能抽验比例
    ''' </summary>
    ''' <param name="moid"></param>
    ''' <remarks></remarks>
    Private Sub SetFunCheckRatio(ByVal moid As String)
        Try
            Dim strSql As String
            strSql = "SELECT MAX(FunctionRatio) AS FunctionRatio FROM m_QCCheckInSnList_t WHERE MOID='" & moid & "' AND Status='N'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.m_FunCheckRatio = dt.Rows(0)!FunctionRatio.ToString
            Else
                Me.m_FunCheckRatio = "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 校验是否是数字
    ''' </summary>
    ''' <param name="strNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegexNumber(ByVal strNumber As String) As Boolean
        Dim reg_Barcode As Regex = New Regex("^[0-9]*$")
        If reg_Barcode.IsMatch(strNumber) = False Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 工单已有空批次，则不允许新增批次
    ''' </summary>
    ''' <param name="strMoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckQCMaxSync(ByVal strMoid As String) As Boolean

        Try
            Dim strSql As String
            strSql = "SELECT * FROM m_QCCheckMain_t a where  a.Moid='" & strMoid & "'" & vbNewLine & _
                    "  and not exists(  select 1 from m_QCCheckSnDetail_t b where b.CId=a.CId )"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region



End Class