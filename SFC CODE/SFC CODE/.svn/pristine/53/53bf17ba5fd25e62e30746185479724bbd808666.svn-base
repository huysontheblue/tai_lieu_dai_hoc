Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports Microsoft.Office.Interop
Imports MainFrame
Public Class FrmBasicOba
#Region "字段,属性"
    Private actionType As String
    Private Enum FormBtnonType
        Normal
        Add
        Edit
    End Enum
    Private Enum OBAGridView
        ObaCode
        ObaName
        Uesy
        UserName
        InTime
    End Enum
#End Region
    


#Region "事件"
    Private Sub FrmBasicOba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
        SetControl()
    End Sub
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.actionType = FormBtnonType.Add.ToString
        SetControl()
    End Sub
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.grvOBA.RowCount < 1 OrElse Me.grvOBA.CurrentCell Is Nothing Then
            Exit Sub
        End If
        txtObaCode.Text = Me.grvOBA.CurrentRow.Cells(OBAGridView.ObaCode).Value.ToString
        txtObaName.Text = Me.grvOBA.CurrentRow.Cells(OBAGridView.ObaName).Value.ToString
        Me.actionType = FormBtnonType.Edit.ToString
        SetControl()
    End Sub
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
       
        GetData()
    End Sub
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.grvOBA.RowCount < 1 OrElse Me.grvOBA.CurrentCell Is Nothing Then
            Exit Sub
        End If

        Dim confirmMsg As String = "确定要作废吗？"
        If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            If SetAbandon() = True Then
                MessageBox.Show("作废成功!")
                GetData()
            End If

        End If

    End Sub
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
    End Sub
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If String.IsNullOrEmpty(Me.txtObaName.Text) Then
            Me.lbMsg.Text = "请输入名称!"
            Exit Sub
        End If
        If CheckData() = False Then
            Me.lbMsg.Text = "当前名称已存在,请勿重复!"
            Exit Sub
        End If
        SavaData()

        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
        GetData()
  
    End Sub
#End Region

#Region "函数"
    '保存
    Private Sub SavaData()
        Try
            Dim o_strSql As New StringBuilder
            Dim UserID As String = VbCommClass.VbCommClass.UseId

            If Me.actionType = FormBtnonType.Add.ToString Then
                o_strSql.Append(" declare @No nvarchar(30);declare @prevNo nvarchar(30);declare @prefix nvarchar(20);")
                o_strSql.Append(" set @prefix='OBA' ;")
                o_strSql.Append(" select top 1 @prevNo=obacode from m_BasicOBA_t    order by obacode desc; ")
                o_strSql.Append(" if(@prevNo is null) begin  set @No=@prefix+'0001'; End")
                o_strSql.Append(" else begin set @prevNo = cast((cast(right(@prevNo,4) as int) + 1) AS varchar(4));")
                o_strSql.Append("  set @prevNo=replicate('0',4-len(@prevNo))+ @prevNo;  ")
                o_strSql.Append(" set @No=@prefix+@prevNo; End")
                o_strSql.Append(" INSERT INTO m_BasicOBA_t(obacode,obaname,usey,userid,intime)")
                o_strSql.Append(" VALUES(@No,N'" & txtObaName.Text & "','Y','" & UserID & "',GETDATE())")

            Else
                o_strSql.Append(" UPDATE m_BasicOBA_t SET obaname=N'" & txtObaName.Text & "',userid='" & UserID & "',intime=GETDATE() WHERE obacode='" & txtObaCode.Text & "'")

            End If
            DbOperateUtils.ExecSQL(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "SaveData()", "sys")
        End Try
    End Sub
    '验证数据
    Private Function CheckData() As Boolean
        Try
            Dim strSql As String
            Dim b As Boolean = True
            strSql = "select obacode from m_BasicOBA_t where obaname=N'" & txtObaName.Text & "'"
            If Me.actionType = "Edit" Then
                strSql = strSql & " and obacode<>'" & txtObaCode.Text & "'"
            End If
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i > 0 Then
                b = False
            End If
            Return b
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "CheckData()", "sys")
        End Try
    End Function
    '清除数据
    Private Sub clearText()
        txtObaCode.Text = ""
        txtObaName.Text = ""
        lbMsg.Text = ""
    End Sub
    '获取数据
    Private Sub GetData()
        Try
            Dim o_strSql As New StringBuilder
            o_strSql.Append("select a.obacode,a.obaname,a.usey,b.UserName,a.intime from m_BasicOBA_t a inner join ")
            o_strSql.Append(" m_Users_t b on b.UserID=a.userid ")
            If Not String.IsNullOrEmpty(txtObaCode.Text) Then
                o_strSql.Append(" and a.obacode='" & Me.txtObaCode.Text & "'")
            End If
            If Not String.IsNullOrEmpty(Me.txtObaName.Text) Then
                o_strSql.Append(" and a.obaname like '%" & Me.txtObaName.Text & "%'")
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            grvOBA.DataSource = dt
            ToolCount.Text = dt.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "GetData()", "sys")
        End Try
    End Sub

    '设置控件权限
    Private Sub SetControl()
        If Me.actionType = FormBtnonType.Add.ToString Then
            txtObaCode.ReadOnly = True
            toolAdd.Enabled = False
            toolEdit.Enabled = False
            toolAbandon.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
        ElseIf actionType = FormBtnonType.Edit.ToString Then
            txtObaCode.ReadOnly = True
            toolAdd.Enabled = False
            toolAbandon.Enabled = False
            toolEdit.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
        Else
            txtObaCode.ReadOnly = False
            toolAdd.Enabled = True
            toolEdit.Enabled = True
            toolBack.Enabled = False
            toolSave.Enabled = False
            toolAbandon.Enabled = True
            clearText()
        End If
    End Sub

    '作废
    Private Function SetAbandon() As Boolean
        Try
            Dim strSql As String
            Dim obacode As String
            Dim b As Boolean = False
            obacode = Me.grvOBA.CurrentRow.Cells(OBAGridView.ObaCode).Value.ToString
            strSql = "update m_BasicOBA_t set usey='N' WHERE obacode='" & obacode & "' "
            DbOperateUtils.ExecSQL(strSql)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "SaveData()", "sys")
        End Try
    End Function

#End Region



 


End Class