
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports SysBasicClass



''' <summary>
''' 修改者： 黄广都
''' 修改日： 2016/11/17
''' 修改内容：
''' -------------------修改记录---------------------
''' </summary>
''' <remarks>在线SOP编辑</remarks>
Public Class FrmOnlineSopNew

#Region "属性"

#Region "文件编码"
    Private _docID As String
    Public Property docID() As String
        Get
            Return _docID
        End Get

        Set(ByVal Value As String)
            _docID = Value
        End Set
    End Property
#End Region


#Region "事件类型"
    Private _actionType As String
    Public Property actionType() As String
        Get
            Return _actionType
        End Get

        Set(ByVal Value As String)
            _actionType = Value
        End Set
    End Property
#End Region

#Region "GridViewRow"
    Private _gridViewRow As DataGridViewRow
    Public Property SelectedGridViewRow() As DataGridViewRow
        Get
            Return _gridViewRow
        End Get

        Set(ByVal Value As DataGridViewRow)
            _gridViewRow = Value
        End Set
    End Property
#End Region
#Region "品名描述"
    Private _partName As String
    Public Property PartName() As String
        Get
            Return _partName
        End Get

        Set(ByVal Value As String)
            _partName = Value
        End Set
    End Property
#End Region
#Region "规格"
    Private _partDesc As String
    Public Property PartDesc() As String
        Get
            Return _partDesc
        End Get

        Set(ByVal Value As String)
            _partDesc = Value
        End Set
    End Property
#End Region
#End Region


#Region "构造函数"

    Sub New(ByVal actionType As String, ByVal dataGridViewRow As DataGridViewRow)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._actionType = actionType
        Me._gridViewRow = dataGridViewRow

    End Sub
#End Region


#Region "窗体事件"

    ''' <summary>
    ''' 窗体加载
    ''' </summary>
    Private Sub FrmOnlineSopNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Me._gridViewRow Is Nothing Then
            Me.txtShape.Focus()
            Me.txtDocId.Text = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.DocId).Value.ToString
            Me.txtSopName.Text = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.SopName).Value.ToString
            Me.txtVerNo.Text = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.Version).Value.ToString
            Me.txtShape.Text = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.Shape).Value.ToString
            Me.txtRemark.Text = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.Remark).Value.ToString
            Me.txtPartName.Text = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.PartName).Value.ToString
        Else
            Me.txtVerNo.Text = "X1"
        End If

    End Sub
    ''' <summary>
    ''' 保存事件
    ''' </summary>
    Private Sub btnHeaderSave_Click(sender As Object, e As EventArgs) Handles btnHeaderSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If CheckInput() = True Then
                '保存
                If SaveData() = True Then
                    '提示
                    MessageUtils.ShowInformation("保存成功！")
                    '退出
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    lblMsg.Text = ""
                End If

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopNew", "btnHeaderSave_Click", "sys")
        End Try
    End Sub


    Private Sub txtSopName_MouseLeave(sender As Object, e As EventArgs) Handles txtSopName.MouseLeave
        If Not String.IsNullOrEmpty(Me.txtSopName.Text) Then
            SetPartDescByTiptop(Me.txtSopName.Text.Trim)
            Me.txtPartName.Text = Me.PartName
        End If
    End Sub
    ''' <summary>
    ''' 退出事件
    ''' </summary>
    Private Sub btnHeaderCancel_Click(sender As Object, e As EventArgs) Handles btnHeaderCancel.Click
        Me.Close()
    End Sub

#End Region


#Region "自定义函数"

    ''' <summary>
    ''' 保存数据
    ''' </summary>
    Public Function SaveData() As Boolean
        Dim r As Boolean = False
        Try
            Dim sb As New StringBuilder()
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim m_Version = Nothing,oldDocID As String =""
            Dim m_Remark As String = Nothing
            Dim m_IsVerChange As Integer = 0
            '如果是料号则获取规格
            '从TT获取料号
            'SetPartDescByTiptop(txtSopName.Text.Trim())


            If actionType = "Add" Then
                '获取最新文件编码:DOC+yy+10位流水码
                sb.Append(" declare @No nvarchar(20);declare @prevNo nvarchar(20);declare @prefix nvarchar(20);")
                sb.Append(" set @No=right(DATEPART(YEAR,getdate()),2);set @prefix='DOC' ;")
                sb.Append(" select top 1 @prevNo=DocId from m_OnlineSop_t where  right(DATEPART(YEAR,CreateTime),2) =right(DATEPART(YEAR,getdate()),2) order by CreateTime desc; ")
                sb.Append(" if(@prevNo is null) begin  set @No=@prefix+@No+'0000000001'; End")
                sb.Append(" else begin set @prevNo = cast((cast(right(@prevNo,10) as int) + 1) AS varchar(10));")
                sb.Append("  set @prevNo=replicate('0',10-len(@prevNo))+ @prevNo;  ")
                sb.Append(" set @No=@prefix+@No+@prevNo; End")
                '插入数据
                sb.Append(" INSERT INTO m_OnlineSop_t(DocId,SopName,Version,Shape ,PartName,PartDesc,CreateUserId,CreateTime,Status,Remark)VALUES")
                sb.Append(String.Format(" ( @No,N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',getdate(),'N',N'{6}')", txtSopName.Text.Trim(), txtVerNo.Text.Trim(),
                                        txtShape.Text.Trim(), Me.txtPartName.Text, Me.PartDesc, UserID, txtRemark.Text.Trim()))
            Else
                'SOP大版本升级整套SOP版本变更
                m_Version = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.Version).Value.ToString

                If m_Version <> Me.txtVerNo.Text.Trim Then
                    m_Remark = "版本变更：" & m_Version & "变更为" & Me.txtVerNo.Text.Trim
                    m_IsVerChange = 1           
                End If
                sb.Append(String.Format("Update m_OnlineSop_t set SopName=N'{0}',Version=N'{1}',Shape=N'{2}',PartName=N'{3}',PartDesc=N'{4}',ModifyUserId=N'{5}',Remark=N'{6}',ModifyTime=getdate() where DocId=N'{7}' ;",
                          txtSopName.Text.Trim.ToString, txtVerNo.Text.Trim.ToString, txtShape.Text.Trim.ToString, Me.txtPartName.Text.Trim, PartDesc, UserID, m_Remark, txtDocId.Text.Trim.ToString))
                '记录版本是否变更
                sb.Append(String.Format("update m_OnlineSop_t set IsVerChange={0} where DocId='{1}' AND  VerChangTimes>0 ;", m_IsVerChange, Me.txtDocId.Text.Trim.ToString))
                sb.Append(";UPDATE m_OnlineSopItem_t SET PartId=N'" & txtSopName.Text.Trim.ToString & "' WHERE DocId='" & Me.txtDocId.Text.Trim.ToString & "'")
                If m_IsVerChange = 1 Then
                    '清空单身颜色区分和备注
                    sb.Append(String.Format(" UPDATE m_OnlineSopItem_t  SET Remark=null,IsColor=0  WHERE DocId='{0}' AND  IsColor=1 ", Me.txtDocId.Text.Trim.ToString))
                    'add log by cq 20180731
                    sb.AppendLine(" DECLARE @DocID VARCHAR(20), @OldModifyTime datetime , @OldCreateUserId varchar(20) ")
                    sb.Append("  SELECT @OldModifyTime=ModifyTime,@OldCreateUserId = CreateUserId  FROM dbo.m_OnlineSop_t WHERE DocId ='" & Me.txtDocId.Text.Trim.ToString & "'")
                    sb.AppendLine("    INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                    sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                    sb.Append(" VALUES( '" & Me.txtDocId.Text.Trim & "','',N'版本',@OldCreateUserId,@OldModifyTime, '" & m_Version & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),'" & Me.txtVerNo.Text.Trim & "','" & Me.txtSopName.Text.Trim & "' )")

                    If Not CheckIsExistsCurrVerRecord(Me.txtDocId.Text.Trim, m_Version) Then
                        sb.AppendLine(" INSERT INTO m_OnlineSopOldVer_t ([DocId],[SopName] ,[PartName],[Version]")
                        sb.Append(" ,[Shape],[PartDesc] ,[Status],[CreateUserId],[CreateTime],[ModifyUserId],[ModifyTime] ,[Remark]")
                        sb.Append(" ,[IsPart],[VerChangTimes],[VerifyUserName] ,[VerifyTime],[ProdUserName] ,[ProdTime],[QCUserName]")
                        sb.Append(",[QCTime],[ApprovalUserName],[ApprovalTime],[DCCUserName] ,[DCCTime] ,[InvalidUserName],[InvalidTime],IsVerChange)")
                        sb.Append(" Select [docID]+'_'+'" & m_Version & "',[SopName],[PartName],'" & m_Version & "',[Shape] ,[PartDesc],[Status],[CreateUserId],[CreateTime]")
                        sb.Append(",[ModifyUserId],[ModifyTime],[Remark],[IsPart],[VerChangTimes],[VerifyUserName],[VerifyTime],[ProdUserName]")
                        sb.Append(" ,[ProdTime],[QCUserName],[QCTime],[ApprovalUserName],[ApprovalTime],[DCCUserName],[DCCTime],[InvalidUserName],[InvalidTime],[IsVerChange]")
                        sb.Append(" FROM m_OnlineSop_t where docid ='" & Me.txtDocId.Text.Trim & "'")

                        'add by cq 20180804
                        oldDocID = Me.txtDocId.Text.Trim + "_" + m_Version.ToString

                        sb.AppendLine(" Update m_OnlineSopOldVer_t SET Status='Y' WHERE docid ='" & oldDocID & "'")

                        sb.AppendLine(" INSERT INTO m_OnlineSopItemOldVer_t")
                        sb.Append("(Id,[docID],[PartId],[StationName],[VerNo],[EcnNo],[PageSize]")
                        sb.Append(",[IsAS],[IsLF],[IsHF],[IsOth],[InsItems],[Remark],[IsColor]")
                        sb.Append(" ,[ModifyUserId],[ModifyTime],[FNo],[IsFocusStation],[RecentlyEdit],IsFinger,HeaderVer)")
                        sb.Append(" Select [Id],[DocId]+'_'+'" & m_Version & "',[PartId],[StationName],'" & m_Version & "',[EcnNo],[PageSize],[IsAS]")
                        sb.Append(" ,[IsLF] ,[IsHF],[IsOth],[InsItems],[Remark],[IsColor],[ModifyUserId],[ModifyTime]")
                        sb.Append(" ,[FNo],[IsFocusStation],[RecentlyEdit],[IsFinger],'" & m_Version & "' ")
                        sb.Append(" FROM m_OnlineSopItem_t WHERE docid ='" & Me.txtDocId.Text.Trim & "'")

                        sb.AppendLine(" SET  IDENTITY_INSERT  m_OnlineSopPartOldVer_t ON")
                        sb.AppendLine(" Insert into m_OnlineSopPartOldVer_t ")
                        sb.Append("(Id,[PId],[PartId],[PartName],[Amount],[Spec],[ModifyUserId],ModifyTime)")
                        sb.Append(" SELECT Id,[PId],[PartId],[PartName],[Amount],[Spec],[ModifyUserId],ModifyTime")
                        sb.Append(" FROM  [m_OnlineSopPart_t] WHERE pid IN ( SELECT id FROM m_OnlineSopItem_t WHERE docid  ='" & Me.txtDocId.Text.Trim.ToString & "')")
                        sb.AppendLine(" SET  IDENTITY_INSERT  m_OnlineSopPartOldVer_t OFF")

                        sb.AppendLine(" SET  IDENTITY_INSERT  m_OnlineSopEquipmentOldVer_t ON")
                        sb.AppendLine(" Insert into m_OnlineSopEquipmentOldVer_t ")
                        sb.Append(" (Id,[PId] ,[EquiName],[EquiNo] ,[EquiDesc])")
                        sb.Append(" Select Id,[PId] ,[EquiName],[EquiNo] ,[EquiDesc]")
                        sb.Append("  FROM [m_OnlineSopEquipment_t] WHERE pid IN ( SELECT id FROM m_OnlineSopItem_t WHERE docid  ='" & Me.txtDocId.Text.Trim.ToString & "')")
                        sb.AppendLine(" SET  IDENTITY_INSERT  m_OnlineSopEquipmentOldVer_t OFF")

                        sb.AppendLine(" SET  IDENTITY_INSERT  m_OnlineSopPictureOldVer_t ON")
                        sb.AppendLine("  Insert into m_OnlineSopPictureOldVer_t([Id],[PId],[OrdIndex] ,[PicPath],[PicDesc])")
                        sb.Append(" select [Id],[PId],[OrdIndex] ,[PicPath],[PicDesc] FROM [m_OnlineSopPicture_t] WHERE pid IN ( SELECT id FROM dbo.m_OnlineSopItem_t WHERE docid  ='" & Me.txtDocId.Text.Trim.ToString & "')")
                        sb.AppendLine(" SET  IDENTITY_INSERT  m_OnlineSopPictureOldVer_t OFF")
                    End If
                    '单身更新为新版本
                    sb.AppendLine(" UPDATE m_OnlineSopItem_t SET VerNo=N'" & Me.txtVerNo.Text.Trim & "' WHERE DocId='" & Me.txtDocId.Text.Trim.ToString & "'")
                End If
            End If
            DbOperateUtils.ExecSQL(sb.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopNew", "SaveData()", "sys")
        End Try
        Return True
    End Function


    ''' <summary>
    ''' 输入完整性检查
    ''' </summary>
    Private Function CheckInput() As Boolean
        Dim m_Version As String = Nothing
        'SOP名称
        If String.IsNullOrEmpty(Me.txtSopName.Text.Trim()) Then
            Me.lblMsg.Text = "请输入SOP名称!"
            Me.txtSopName.Focus()
            Return False
        End If
        '版本
        If String.IsNullOrEmpty(Me.txtVerNo.Text.Trim()) Then
            Me.lblMsg.Text = "请输入版本!"
            Me.txtVerNo.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtShape.Text.Trim()) Then
            Me.lblMsg.Text = "请输入形态!"
            Me.txtShape.Focus()
            Return False
        End If
        If actionType = "Add" Then
            If OnlineSopBusiness.CheckVersionItRight(Nothing, Me.txtVerNo.Text.Trim) = False Then
                Me.lblMsg.Text = "输入的版本,格式不正确!"
                Me.txtVerNo.Focus()
                Return False
            End If

            If CheckIsExists(Me.txtSopName.Text.Trim, Nothing) = True Then
                Me.lblMsg.Text = "SOP名称已存在,不能重复录入!"
                Me.txtVerNo.Focus()
                Return False
            End If


        Else
            If CheckIsExists(Me.txtSopName.Text.Trim, Me.txtDocId.Text) = True Then
                Me.lblMsg.Text = "SOP名称已存在,不能重复录入!"
                Me.txtVerNo.Focus()
                Return False
            End If
            m_Version = Me._gridViewRow.Cells(OnlineSopBusiness.HeaderGridView.Version).Value.ToString
            'SOP大版本升级整套SOP版本变更
            If m_Version <> Me.txtVerNo.Text.Trim Then
                If OnlineSopBusiness.CheckVersionItRight(m_Version, Me.txtVerNo.Text.Trim) = False Then
                    Me.lblMsg.Text = "输入的版本,格式不正确或不能小于当前版本,请重新输入!"
                    Me.txtVerNo.Focus()
                    Return False
                End If
            End If

        End If

        Return True
    End Function

    ''' <summary>
    ''' 获取TTop料号表中料号品名规格
    ''' </summary>
    ''' <param name="part"></param>
    ''' <remarks></remarks>
    Private Sub SetPartDescByTiptop(ByVal part As String)
        Try
            Dim dv As DataView
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                dv = SapCommon.SetPartDescBySap(part)
            Else
                dv = SapCommon.SetPartDescByTiptop(part)
            End If

            If Not dv Is Nothing Then
                If (dv.Table.Rows.Count > 0) Then
                    For i As Int16 = 0 To dv.Table.Rows.Count - 1
                        Me._partName = dv.Item(i).Item("PARTNAME").ToString.Replace("'", "")
                        Me._partDesc = dv.Item(i).Item("PARTDESC").ToString.Replace("'", "")
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function CheckIsExists(ByVal sopname As String, ByVal docID As String) As Boolean
        Dim b As Boolean = False
        Dim O_strSql As New StringBuilder
        Dim iCount As Int32 = 0
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        O_strSql.Append("select SopName from m_OnlineSop_t  WHERE SopName=N'" & sopname & "' and [Status]<>'D' ")
        If Not docID Is Nothing Then
            O_strSql.Append(" and DocId<>N'" & docID & "'")
        End If
        iCount = DbOperateUtils.GetRowsCount(O_strSql.ToString)
        If (iCount > 0) Then
            b = True
        End If
        Return b
    End Function

    Private Function CheckIsExistsCurrVerRecord(ByVal docID As String, ByVal txtVer As String) As Boolean
        Dim b As Boolean = False
        Dim O_strSql As New StringBuilder
        Dim iCount As Int32 = 0
        'Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        O_strSql.Append("SELECT SopName from m_OnlineSopOldVer_t  WHERE docid LIKE N'" & docID & "%' AND [Version]='" & txtVer & "' ")
        'If Not docID Is Nothing Then
        '    O_strSql.Append(" and DocId<>N'" & docID & "'")
        'End If
        iCount = DbOperateUtils.GetRowsCount(O_strSql.ToString)
        If (iCount > 0) Then
            b = True
        End If
        Return b
    End Function
    ''' <summary>
    ''' 清除\设置面板控件值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFormText()
        For Each contr As Control In Me.Controls
            If (TypeOf contr Is TextBox) Then
                contr.Text = ""
            End If
        Next

    End Sub





#End Region



End Class