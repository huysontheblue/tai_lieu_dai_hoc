Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports MainFrame
Public Class FrmFixedCodeSet

#Region "属性"

    Private m_Moid As String
    Private m_MoQty As Integer

    Private m_FixOne As String
    Private m_FixTwo As String
    Private m_FixThr As String
    Private m_FixFour As String

    Private m_IsNew As Boolean


    Public Property IsNew() As Boolean
        Get
            Return m_IsNew
        End Get

        Set(ByVal Value As Boolean)
            m_IsNew = Value
        End Set
    End Property



    Public Property MoId() As String
        Get
            Return m_Moid
        End Get

        Set(ByVal Value As String)
            m_Moid = Value
        End Set
    End Property

    Public Property MoQty() As String
        Get
            Return m_MoQty
        End Get

        Set(ByVal Value As String)
            m_MoQty = Value
        End Set
    End Property


    Public Property FixOne() As String
        Get
            Return m_FixOne
        End Get

        Set(ByVal Value As String)
            m_FixOne = Value
        End Set
    End Property

    Public Property FixTwo() As String
        Get
            Return m_FixTwo
        End Get

        Set(ByVal Value As String)
            m_FixTwo = Value
        End Set
    End Property

    Public Property FixThr() As String
        Get
            Return m_FixThr
        End Get

        Set(ByVal Value As String)
            m_FixThr = Value
        End Set
    End Property

    Public Property FixFour() As String
        Get
            Return m_FixFour
        End Get

        Set(ByVal Value As String)
            m_FixFour = Value
        End Set
    End Property

#End Region

    Private Sub FrmFixedCodeSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        If String.IsNullOrEmpty(txtMoid.Text) Then
            Exit Sub
        End If
        GetFixedCodeSet()
        If Me.m_IsNew Then
            GetPartFixedCodeSet()
        End If
    End Sub

    '查找已配置是信息
    Private Sub GetFixedCodeSet()

        Dim strSql As String
        strSql = "SELECT FixedCodeOne,FixedCodeTwo,FixedCodeThr,FixedCodeFou,boxeffective,box,BoxQty  FROM m_FixedCodeSet_t WHERE MOID='" & txtMoid.Text.Trim & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        ClearText()
        If dt.Rows.Count > 0 Then
            SetScanText(0)
            txtScanOne.Text = dt.Rows(0)!FixedCodeOne.ToString
            txtScanTwo.Text = dt.Rows(0)!FixedCodeTwo.ToString
            txtScanTree.Text = dt.Rows(0)!FixedCodeThr.ToString
            txtScanFour.Text = dt.Rows(0)!FixedCodeFou.ToString
            boxeffective.Checked = If(dt.Rows(0)!boxeffective.ToString = "Y", True, False)
            box.Text = dt.Rows(0)!box.ToString
            Qty.Text = dt.Rows(0)!BoxQty.ToString
            Me.m_IsNew = False
        Else
            SetScanText(1)
            Me.m_IsNew = True
        End If

    End Sub

    '按料号配置获取
    Private Sub GetPartFixedCodeSet()

        Dim strSql As String
        strSql = "SELECT FixedCodeOne,FixedCodeTwo,FixedCodeThr,FixedCodeFou FROM m_Mainmo_t  A INNER JOIN " & _
                " m_PartFixedCodeSet_t  B ON B.PARTNO=A.PartID where a.Moid=  '" & txtMoid.Text.Trim & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

        If dt.Rows.Count > 0 Then
            txtScanOne.Text = dt.Rows(0)!FixedCodeOne.ToString
            txtScanTwo.Text = dt.Rows(0)!FixedCodeTwo.ToString
            txtScanTree.Text = dt.Rows(0)!FixedCodeThr.ToString
            txtScanFour.Text = dt.Rows(0)!FixedCodeFou.ToString
        Else
            lbMsg.Text = "该工单未设置固定条码,请设置!"
            SetScanText(1)

        End If

    End Sub



    Private Sub ClearText()
        txtScanOne.Text = ""
        txtScanTwo.Text = ""
        txtScanTree.Text = ""
        txtScanFour.Text = ""
        box.Text = ""
        Qty.Text = ""
        boxeffective.Checked = False
    End Sub
    Private Sub txtMoid_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtMoid.PreviewKeyDown
        If e.KeyValue = 13 Then
            If String.IsNullOrEmpty(txtMoid.Text) Then
                Exit Sub
            End If
            GetFixedCodeSet()
            If Me.m_IsNew Then
                GetPartFixedCodeSet()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If SetCheckData() Then
            m_FixOne = txtScanOne.Text
            m_FixTwo = txtScanTwo.Text
            m_FixThr = txtScanTree.Text
            m_FixFour = txtScanFour.Text

            SavaData()
            SavePartSet()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub


    Private Sub ShowInfoMsg(ByVal b As Boolean, ByVal msg As String)
        If b Then
            lbMsg.ForeColor = Color.Green
        Else
            lbMsg.ForeColor = Color.Red

        End If
        lbMsg.Text = msg
    End Sub
    Private Function SetCheckData() As Boolean
        If String.IsNullOrEmpty(txtScanOne.Text) AndAlso String.IsNullOrEmpty(txtScanTwo.Text) AndAlso String.IsNullOrEmpty(txtScanTree.Text) AndAlso String.IsNullOrEmpty(txtScanFour.Text) Then

            ShowInfoMsg(False, "请至少配置一个固定码!")
            Return False
        End If
        If String.IsNullOrEmpty(txtScanOne.Text) Then
            ShowInfoMsg(False, "请先配置固定条码一!")
            Return False
        End If

        If Not String.IsNullOrEmpty(txtScanTree.Text) AndAlso String.IsNullOrEmpty(txtScanTwo.Text) Then

            ShowInfoMsg(False, "请先配置固定条码二!")
            Return False
        End If
        If Not String.IsNullOrEmpty(txtScanFour.Text) AndAlso String.IsNullOrEmpty(txtScanTree.Text) Then
            ShowInfoMsg(False, "请先配置固定条码三!")
            Return False
        End If

        If CheckMoidData() = False Then
            ShowInfoMsg(False, "工单信息错误!")
            Return False
        End If

        Return True
    End Function

    Private Function CheckMoidData() As Boolean
        Dim strSql As String
        strSql = "SELECT * FROM m_Mainmo_t  WHERE MOID='" & txtMoid.Text.Trim & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            Me.m_Moid = dt.Rows(0)!moid.ToString
            Me.MoQty = dt.Rows(0)!Moqty.ToString
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub SetScanText(ByVal sOption As Integer)
        If sOption = 1 Then
            txtScanOne.Enabled = True
            txtScanTwo.Enabled = True
            txtScanTree.Enabled = True
            txtScanFour.Enabled = True
            Qty.Enabled = False
            box.Enabled = False
            boxeffective.Enabled = True
        Else
            txtScanOne.Enabled = False
            txtScanTwo.Enabled = False
            txtScanTree.Enabled = False
            txtScanFour.Enabled = False
            Qty.Enabled = False
            box.Enabled = False
            boxeffective.Enabled = False
        End If
    End Sub

    Private Sub SavaData()
        Try
            Dim strSql As New StringBuilder
            If Me.m_IsNew Then
                strSql.Append("INSERT INTO m_FixedCodeSet_t(Moid,FixedCodeOne,FixedCodeTwo,FixedCodeThr,FixedCodeFou,MoQty,userid,intime,boxeffective,box,BoxQty) ")
                strSql.Append(" VALUES('" & m_Moid & "','" & m_FixOne & "','" & m_FixTwo & "','" & m_FixThr & "','" & m_FixFour & "','" & m_MoQty & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),'" & If(boxeffective.Checked = True, "Y", "N") & "','" & box.Text & "','" & Qty.Text & "' )")
            Else
                strSql.Append("update m_FixedCodeSet_t set FixedCodeOne='" & m_FixOne & "' ,FixedCodeTwo='" & m_FixTwo & "'")
                strSql.Append(" ,FixedCodeThr='" & m_FixThr & "',FixedCodeFou='" & m_FixFour & "',MoQty='" & m_MoQty & "',userid='" & VbCommClass.VbCommClass.UseId & "' , boxeffective = '" & If(boxeffective.Checked = True, "Y", "N") & "' ,box = '" & box.Text & "', BoxQty = '" & Qty.Text & "' ")
                strSql.Append(" ,intime=getdate() where moid='" & m_Moid & "'")
            End If

            DbOperateUtils.ExecSQL(strSql.ToString)

        Catch ex As Exception
            Throw ex
        End Try
 
    End Sub


    Private Sub SavePartSet()
        Dim strPartNo As String
        Dim sb As New StringBuilder
        Dim strSql As String = "select PartID from m_Mainmo_t   where  MOID='" & txtMoid.Text.Trim & "'"
        Dim dtMo As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dtMo.Rows.Count > 0 Then
            strPartNo = dtMo.Rows(0)!PartID.ToString
        Else
            Exit Sub
        End If

        If IsPartSet() = False Then

            sb.Append(" insert into m_PartFixedCodeSet_t (PartNo,FixedCodeOne,FixedCodeTwo,FixedCodeThr,FixedCodeFou,userid,intime) ")
            sb.Append(" values('" & strPartNo & "','" & txtScanOne.Text & "','" & txtScanTwo.Text & "','" & txtScanTree.Text & "','" & txtScanFour.Text & "' ")
            sb.Append(" ,'" & VbCommClass.VbCommClass.UseId & "',getdate())")
        Else
            sb.Append("update m_PartFixedCodeSet_t set FixedCodeOne='" & m_FixOne & "' ,FixedCodeTwo='" & m_FixTwo & "'")
            sb.Append(" ,FixedCodeThr='" & m_FixThr & "',FixedCodeFou='" & m_FixFour & "',userid='" & VbCommClass.VbCommClass.UseId & "' ")
            sb.Append(" ,intime=getdate() where PartNo='" & strPartNo & "' ")
        End If
        DbOperateUtils.ExecSQL(sb.ToString)
    End Sub

    Private Function IsPartSet() As Boolean
        Try
            Dim b As Boolean = False
            Dim sb As New StringBuilder
            sb.Append("SELECT FixedCodeOne,FixedCodeTwo,FixedCodeThr,FixedCodeFou FROM m_Mainmo_t  A INNER JOIN ")
            sb.Append(" m_PartFixedCodeSet_t  B ON B.PARTNO=A.PartID where a.Moid='" & txtMoid.Text.Trim & "'")
            Dim i As Integer = DbOperateUtils.GetRowsCount(sb.ToString)
            If i > 0 Then
                Return True
            End If
            Return b
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim SQL As String = "SELECT  boxeffective  FROM  m_FixedCodeSet_t WHERE Moid ='" & txtMoid.Text.Trim & "'"
        Dim dat As DataTable = DbOperateUtils.GetDataTable(SQL)
        If dat.Rows.Count > 0 Then
            If dat.Rows(0)(0).ToString = "Y" Then
                SQL = "SELECT box FROM  m_FixedBox_t WHERE MOID='" & txtMoid.Text.Trim & "' AND Closethebox='Y'"
                dat = DbOperateUtils.GetDataTable(SQL)
                If dat.Rows.Count > 0 Then
                    MessageBox.Show("箱号:" + dat.Rows(0)(0) + " 未满箱不可重置", "错误提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                    Return
                End If
            End If

        End If

        ClearText()
        SetScanText(1)
    End Sub

    Private Sub boxeffective_CheckedChanged(sender As Object, e As EventArgs) Handles boxeffective.CheckedChanged
        If boxeffective.Checked = True And boxeffective.Enabled = True Then
            box.Enabled = True
            Qty.Enabled = True
        Else
            box.Enabled = False
            Qty.Enabled = False
            box.Text = ""
            Qty.Text = ""
        End If

      
    End Sub
End Class