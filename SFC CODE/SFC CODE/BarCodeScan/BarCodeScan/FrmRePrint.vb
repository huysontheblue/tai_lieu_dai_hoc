Imports MainFrame

Public Class FrmRePrint


    Public Sub New(ByVal str As String)
        InitializeComponent()
        txtRePrintSN.Text = str
        Me.lblMsg.Text = ""
        GetReprintInfo()
    End Sub

    Public Event ByValueEvent As Action(Of String)
    Public m_strRemark As String

    ''' <summary>
    ''' 抓取重复打印的信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetReprintInfo()
        Dim strSQL As String = " SELECT InTime FROM dbo.m_MSM06OnlinePrint_t WHERE PPID ='" & txtRePrintSN.Text.Trim() & "' ORDER BY item DESC"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            'do nothing
        Else
            Me.txtPrintedTimes.Text = Convert.ToString(dt.Rows.Count)
            Me.txtReprintTime.Text = dt.Rows(0)(0).ToString()
        End If
    End Sub


    ''' <summary>
    ''' 检查界面输入
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckInput() As Boolean
        If String.IsNullOrEmpty(Me.txtUserID.Text) Then
            ' lblMsg.Text = "工号不能为空,请检查！"
            SetMessage("FAIL", "工号不能为空,请检查！")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtPWD.Text) Then
            ' lblMsg.Text = "密码不能为空,请检查！"
            SetMessage("FAIL", "密码不能为空,请检查！")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtRemark.Text) Then
            ' lblMsg.Text = "备注不能为空,请检查！"
            SetMessage("FAIL", "备注不能为空,请检查！")
            Return False
        Else
            m_strRemark = Me.txtRemark.Text.Trim
        End If

        Return True
    End Function
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            ' LabResult.Text = "FAIL"
            lblMsg.Text = message
            ' LabResult.ForeColor = Color.Crimson
            lblMsg.ForeColor = Color.Crimson
        Else
            '  LabResult.Text = "PASS"
            lblMsg.Text = message
            ' LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMsg.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub


    'Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)

    'End Sub

    Public Function GetOpenRePrintLock(ByVal strUserID As String, ByVal pwd As String) As Boolean
        Dim strSQL As String = " select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid" & " where a.userid='{0}' and a.autoid='{1}' and b.tkey='m0510d_'"
        strSQL = String.Format(strSQL, strUserID, pwd)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Me.lblMsg.Text = "请检查解锁密码是否正确！"
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If Not CheckInput() Then
            Return
        End If

        If Not GetOpenRePrintLock(Me.txtUserID.Text.Trim(), Me.txtPWD.Text.Trim()) Then
            Return
        End If

        ' If (Not IsNothing(ByValueEvent)) Then

        RaiseEvent ByValueEvent(txtRemark.Text)
        ' End If


        Me.DialogResult = DialogResult.OK
        'FrmOnlinePrintBarcode.= txtRemark.Text
        Me.Close()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Me.Close()
    End Sub
End Class