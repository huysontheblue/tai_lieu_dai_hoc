Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports SysBasicClass

Public Class FrmOnlineSopMailRelation
#Region "属性"
    Dim MailRelationArr(,) As String    '关联清单
#Region "制作人工号"
    Private _MakeUserId As String
    Public Property MakeUserId() As String
        Get
            Return _MakeUserId
        End Get

        Set(ByVal Value As String)
            _MakeUserId = Value
        End Set
    End Property
#End Region
#Region "制作人工号"
    Private _MakeUserName As String
    Public Property MakeUserName() As String
        Get
            Return _MakeUserName
        End Get

        Set(ByVal Value As String)
            _MakeUserName = Value
        End Set
    End Property
#End Region
#End Region

#Region "构造函数"

    Sub New(ByVal sMakeUser As String, ByVal sMakeUserName As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._MakeUserId = sMakeUser
        Me._MakeUserName = sMakeUserName

    End Sub
#End Region
#Region "事件"
    Private Sub FrmOnlineSopMailRelation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtMake.Text = Me.MakeUserName
        LoadUserList()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If CheckData() = True Then
                If SaveData() = True Then
                    '提示
                    MessageUtils.ShowInformation("保存成功！")
                    '退出
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    '提示
                    MessageUtils.ShowInformation("保存失败！")
                End If

            End If
          
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.FrmOnlineSopMailRelation", "btnSave_Click", "sys")
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try
            Dim sSql As String
            sSql = "UPDATE m_OnlineSopMailRelation_t SET Usey='N' WHERE MakeUserId='" & Me.MakeUserId & "'"

            DbOperateUtils.ExecSQL(sSql)
            MessageUtils.ShowInformation("作废成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.FrmOnlineSopMailRelation", "btnDelete_Click", "sys")
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region
#Region "函数"

    '(制作中(N)、待审核(S)、待生产审核(P)、待品管审核(Q)、待核准(A)、已作废(D)、已生效(Y))
    Private Sub LoadUserList()
        SetMailRelationArr("S")
        SetCheckListBox("S", Me.clbVerify)
        SetMailRelationArr("Q")
        SetCheckListBox("Q", Me.clbQC)
        SetMailRelationArr("P")
        SetCheckListBox("P", Me.clbProd)
        SetMailRelationArr("A")
        SetCheckListBox("A", Me.clbApproval)
        SetMailRelationArr("C")
        SetCheckListBox("C", Me.clbDCC)
    End Sub

    ''' <summary>
    ''' 检查输入是否正确
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean
        Dim bResult As Boolean = True
        If Me.clbVerify.CheckedItems.Count < 1 OrElse
             Me.clbQC.CheckedItems.Count < 1 OrElse
             Me.clbProd.CheckedItems.Count < 1 OrElse
            Me.clbApproval.CheckedItems.Count < 1 OrElse
           Me.clbDCC.CheckedItems.Count < 1 Then
            MessageUtils.ShowInformation("资料设置未完整,请检查勾选项！")
            bResult = False

        End If
        Return bResult
    End Function
    ''' <summary>
    ''' 保存数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveData() As Boolean
        Dim bResult As Boolean = False
        Try
            Dim sb As New StringBuilder
            Dim I, J, K, L, M As Int16
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            sb.Append("delete m_OnlineSopMailRelation_t where MakeUserId='" & Me.MakeUserId & "'")
            For I = 1 To Me.clbVerify.Items.Count
                If Me.clbVerify.GetItemChecked(I - 1) Then
                    sb.Append(vbNewLine & "INSERT INTO m_OnlineSopMailRelation_t(MakeUserId ,RelationType,RelationUserId,RelationUserName,CreUserId,IsAutoCheck)")
                    sb.Append(vbNewLine & String.Format("VALUES('{0}','S',N'{1}',N'{2}','{3}','{4}')", Me.MakeUserId, Me.clbVerify.Items(I - 1).ToString.Split("-")(0), Me.clbVerify.Items(I - 1).ToString, UserID, ChkVerify.Checked))
                End If
            Next I

            For J = 1 To Me.clbQC.Items.Count
                If Me.clbQC.GetItemChecked(J - 1) Then
                    sb.Append(vbNewLine & "INSERT INTO m_OnlineSopMailRelation_t(MakeUserId ,RelationType,RelationUserId,RelationUserName,CreUserId,IsAutoCheck)")
                    sb.Append(vbNewLine & String.Format("VALUES('{0}','Q',N'{1}',N'{2}','{3}','{4}')", Me.MakeUserId, Me.clbQC.Items(J - 1).ToString.Split("-")(0), Me.clbQC.Items(J - 1).ToString, UserID, ChkQC.Checked))
                End If
            Next J

            For K = 1 To Me.clbProd.Items.Count
                If Me.clbProd.GetItemChecked(K - 1) Then
                    sb.Append(vbNewLine & "INSERT INTO m_OnlineSopMailRelation_t(MakeUserId ,RelationType,RelationUserId,RelationUserName,CreUserId,IsAutoCheck)")
                    sb.Append(vbNewLine & String.Format("VALUES('{0}','P',N'{1}',N'{2}','{3}','{4}')", Me.MakeUserId, Me.clbProd.Items(K - 1).ToString.Split("-")(0), Me.clbProd.Items(K - 1).ToString, UserID, ChkProd.Checked))
                End If
            Next K
            For L = 1 To Me.clbApproval.Items.Count
                If Me.clbApproval.GetItemChecked(L - 1) Then
                    sb.Append(vbNewLine & "INSERT INTO m_OnlineSopMailRelation_t(MakeUserId ,RelationType,RelationUserId,RelationUserName,CreUserId,IsAutoCheck)")
                    sb.Append(vbNewLine & String.Format("VALUES('{0}','A',N'{1}',N'{2}','{3}','{4}')", Me.MakeUserId, Me.clbApproval.Items(L - 1).ToString.Split("-")(0), Me.clbApproval.Items(L - 1).ToString, UserID, ChkApproval.Checked))
                End If
            Next L
            For M = 1 To Me.clbDCC.Items.Count
                If Me.clbDCC.GetItemChecked(M - 1) Then
                    sb.Append(vbNewLine & "INSERT INTO m_OnlineSopMailRelation_t(MakeUserId ,RelationType,RelationUserId,RelationUserName,CreUserId,IsAutoCheck)")
                    sb.Append(vbNewLine & String.Format("VALUES('{0}','C',N'{1}',N'{2}','{3}','{4}')", Me.MakeUserId, Me.clbDCC.Items(M - 1).ToString.Split("-")(0), Me.clbDCC.Items(M - 1).ToString, UserID, ChkDCC.Checked))
                End If
            Next M


            DbOperateUtils.ExecSQL(sb.ToString)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.FrmOnlineSopMailRelation", "SaveData()", "sys")
        End Try
        Return bResult
    End Function

    ''' <summary>
    ''' 获取已设置的关系
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMailRelationArr(ByVal sRelationType As String)
        Dim sSql As String
        Dim dt As New DataTable
        Dim I As Int32
        Dim SnLen As Int32
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            sSql = String.Format("select RelationUserId,RelationType,IsAutoCheck from m_OnlineSopMailRelation_t where Usey='Y' AND MakeUserId=N'{0}' and RelationType='{1}' ", Me.MakeUserId, sRelationType)
            dt = DbOperateUtils.GetDataTable(sSql)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                'add by 马跃平 2018-07-23
                Dim IsAutoCheck = Convert.ToBoolean(dt.Rows(0)("IsAutoCheck"))
                If sRelationType = "S" Then
                    ChkVerify.Checked = IsAutoCheck
                ElseIf sRelationType = "Q" Then
                    ChkQC.Checked = IsAutoCheck
                ElseIf sRelationType = "P" Then
                    ChkProd.Checked = IsAutoCheck
                ElseIf sRelationType = "A" Then
                    ChkApproval.Checked = IsAutoCheck
                ElseIf sRelationType = "C" Then
                    ChkDCC.Checked = IsAutoCheck
                End If
                '---------end 

                SnLen = dt.Rows.Count
                ReDim MailRelationArr(SnLen - 1, 0)
                For I = 0 To dt.Rows.Count - 1
                    'Me.MailRelationArr(I, 0) = dt.Rows(I)!RelationType.ToString
                    Me.MailRelationArr(I, 0) = dt.Rows(I)!RelationUserId.ToString
                Next I
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.FrmOnlineSopMailRelation", "btnDelete_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 绑定CheckListBox值
    ''' </summary>
    ''' <param name="sStatus">状态</param>
    ''' <param name="contrls"></param>
    ''' <remarks></remarks>
    Private Sub SetCheckListBox(ByVal sStatus As String, ByVal contrls As Windows.Forms.CheckedListBox)
        Try
            'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim dt As New DataTable
            Dim sUserID As String = ""
            Dim sUserName As String = ""
            Dim bChecked As Boolean = False
            Dim sSql As String
            sSql = "SELECT UserId,UserName FROM m_OnlineSopEmail_t where Usey='Y' AND Satus='" & sStatus & "'"
            dt = DbOperateUtils.GetDataTable(sSql)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    sUserID = dr!UserId.ToString
                    sUserName = dr!UserName.ToString
                    If Not IsNothing(MailRelationArr) AndAlso MailRelationArr.Length > 0 Then
                        For I = 1 To MailRelationArr.Length
                            If MailRelationArr(I - 1, 0).Contains(sUserID) Then
                                bChecked = True
                            End If
                        Next
                    End If
                    contrls.Items.Add(sUserID & "-" & sUserName, bChecked)
                    bChecked = False
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RCard.FrmOnlineSopMailRelation", "SetCheckListBox", "sys")
        End Try
    End Sub

#End Region


End Class