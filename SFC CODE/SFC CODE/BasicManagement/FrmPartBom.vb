Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame
''' <summary>
''' 修改者： 黄广都
''' 修改日： 2019/12/19
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>物料清单</remarks>

Public Class FrmPartBom

#Region "属性/字段"
    Private _PartNo As String
    Public Property PartNo() As String
        Get
            Return _PartNo
        End Get

        Set(ByVal Value As String)
            _PartNo = Value
        End Set
    End Property
    Private _IsNew As Boolean
    Public Property IsNew() As Boolean
        Get
            Return _IsNew
        End Get

        Set(ByVal Value As Boolean)
            _IsNew = Value
        End Set
    End Property


    Private Enum EStauts
        ''' <summary>
        ''' 新增
        ''' </summary>
        ''' <remarks></remarks>
        Add = 1
        ''' <summary>
        ''' 修改
        ''' </summary>
        ''' <remarks></remarks>
        Modify = 3
        ''' <summary>
        ''' 作废
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5
        ''' <summary>
        ''' 保存
        ''' </summary>
        ''' <remarks></remarks>
        Save = 6
        ''' <summary>
        ''' 返回
        ''' </summary>
        ''' <remarks></remarks>
        Back = 7
        ''' <summary>
        ''' 查询
        ''' </summary>
        ''' <remarks></remarks>
        Query = 8

    End Enum
#End Region
#Region "事件"
    Private Sub FrmPartBom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getData(Me.PartNo)
    End Sub
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
    
        QueryData(txtPartNo.Text, txtItemPartNo.Text)
        setContrlStatus(EStauts.Query)
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click

        setContrlStatus(EStauts.Add)
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvMain.RowCount < 1 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        setContrlStatus(EStauts.Modify)
        Dim o_PartId As String
        Dim o_ItemPartId As String

        o_PartId = Me.dgvMain.CurrentRow.Cells(1).Value.ToString
        o_ItemPartId = Me.dgvMain.CurrentRow.Cells(2).Value.ToString
        txtPartNo.Text = o_PartId
        txtItemPartNo.Text = o_ItemPartId

    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If Me.dgvMain.RowCount < 1 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub

        If (MessageUtils.ShowConfirm("确定要作废吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            DeleteData()

            MessageUtils.ShowInformation("作废成功!")

            getData("")

        End If

    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click

        If CheckData() Then
            If SaveData() Then
                MessageUtils.ShowInformation("保存成功!")
                setContrlStatus(EStauts.Save)
                getData("")
            End If
        End If


    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        setContrlStatus(EStauts.Back)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region
#Region "方法"


    Private Sub getData(ByVal strPartNo)
        Dim sb As New StringBuilder
        Dim dt As New DataTable
        sb.Append("SELECT id,PartID,ItemPartId,UseY,CreateUserID,CreateTime FROM m_PartMoBom_t where 1=1 ")
        If Not String.IsNullOrEmpty(strPartNo) Then
            sb.Append(" and partid='" & strPartNo & "'")
        End If
          If Me.cbUseY.Checked Then
            sb.Append(" and UseY ='Y'")
        End If
      
        dt = DbOperateUtils.GetDataTable(sb.ToString)
        If dt.Rows.Count > 0 Then
            dgvMain.DataSource = dt
        End If
    End Sub
    Private Sub QueryData(ByVal strPartNo, ByVal strItemPartNo)
        Dim sb As New StringBuilder
        Dim dt As New DataTable
        Try
            sb.Append("SELECT id,PartID,ItemPartId,UseY,CreateUserID,CreateTime FROM m_PartMoBom_t where 1=1 ")
            If Not String.IsNullOrEmpty(strPartNo) Then
                sb.Append(" and partid like'%" & strPartNo & "%'")
            End If
            If Not String.IsNullOrEmpty(strItemPartNo) Then
                sb.Append(" and ItemPartId like'%" & strItemPartNo & "%'")
            End If
            If Me.cbUseY.Checked Then
                sb.Append(" and UseY ='Y'")
            End If
            dt = DbOperateUtils.GetDataTable(sb.ToString)
            If dt.Rows.Count > 0 Then
                dgvMain.DataSource = dt
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function CheckData() As Boolean
        Dim b As Boolean = False
        If String.IsNullOrEmpty(txtPartNo.Text) Then
            MessageUtils.ShowError("请输入主料号！")
            Exit Function
        End If
        If String.IsNullOrEmpty(txtItemPartNo.Text) Then
            MessageUtils.ShowError("请输入子料号！")
            Exit Function
        End If
        If txtPartNo.Text.Trim = txtItemPartNo.Text.Trim Then
            MessageUtils.ShowError("主料号不能与子料号相同！")
            Exit Function
        End If

        If CheckPartInfo(txtPartNo.Text.Trim) = False Then
            MessageUtils.ShowError("主料号不存在，请检查！")
            Exit Function
        End If
        If CheckPartInfo(txtItemPartNo.Text.Trim) = False Then
            MessageUtils.ShowError("子料号不存在，请检查！")
            Exit Function
        End If

        If CheckExists() = False Then
            MessageUtils.ShowError("该物料清单已存在，请检查！")
            Exit Function
        End If


        Return True
    End Function

    Private Function CheckPartInfo(ByVal strPartNo As String) As Boolean
        Dim sb As New StringBuilder
        Dim i As Integer
        Try
            sb.Append("SELECT TAvcPart FROM m_PartContrast_t  where TAvcPart = '" & strPartNo & "'")
            i = DbOperateUtils.GetRowsCount(sb.ToString)
            If i > 0 Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
     
    End Function


    Private Function CheckExists() As Boolean
        Dim sb As New StringBuilder
        Dim i As Integer
        Try
            sb.Append("SELECT PartID FROM m_PartMoBom_t  where PartID = '" & txtPartNo.Text & "' and ItemPartId='" & txtItemPartNo.Text & "'")
            i = DbOperateUtils.GetRowsCount(sb.ToString)
            If i > 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub DeleteData()
        Dim sb As New StringBuilder
        Try
            Dim id As String

            id = Me.dgvMain.CurrentRow.Cells(0).Value.ToString

            sb.Append("update m_PartMoBom_t set UseY='N',CreateTime=getdate(),CreateUserID='" & VbCommClass.VbCommClass.UseId & "' WHERE ID='" & id & "'  ")

            DbOperateUtils.ExecSQL(sb.ToString)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Function SaveData() As Boolean
        Dim sb As New StringBuilder
        Try
            If Me.IsNew Then
                sb.Append("insert into m_PartMoBom_t(PartID,ItemPartId,CreateTime,CreateUserID,UseY) ")
                sb.Append(" values('" & txtPartNo.Text.Trim & "','" & txtItemPartNo.Text.Trim & "',getdate(),'" & VbCommClass.VbCommClass.UseId & "','Y')")
            Else
                Dim id As String

                id = Me.dgvMain.CurrentRow.Cells(0).Value.ToString
                sb.Append("update m_PartMoBom_t set PartID='" & txtPartNo.Text.Trim & "',ItemPartId='" & txtItemPartNo.Text.Trim & "',CreateTime=getdate(),CreateUserID='" & VbCommClass.VbCommClass.UseId & "',UseY='Y' WHERE id='" & id & "'  ")
            End If

            DbOperateUtils.ExecSQL(sb.ToString)
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub setContrlStatus(ByVal status As EStauts)
        Select Case status
            Case EStauts.Add
                toolSave.Enabled = True
                toolBack.Enabled = True
                toolEdit.Enabled = False
                toolDelete.Enabled = False
                Me._IsNew = True
            Case EStauts.Modify
                toolAdd.Enabled = False
                toolDelete.Enabled = False
                toolEdit.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                txtPartNo.Enabled = False
                Me._IsNew = False
            Case EStauts.Save
                toolAdd.Enabled = True
                toolEdit.Enabled = True
                toolDelete.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
            Case EStauts.Query
            Case Else
                toolAdd.Enabled = True
                toolEdit.Enabled = True
                toolDelete.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
                txtPartNo.Enabled = True
        End Select

        txtPartNo.Text = ""
        txtItemPartNo.Text = ""
    End Sub
#End Region




End Class