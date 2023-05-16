Imports MainFrame.SysDataHandle
Imports MainFrame

Public Class FrmTestStationHandle
    Private sConn As New SysDataBaseClass
 

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()
        If CartonScanOption.CheckStr Then
            Dim strsql As String = "select distinct isnull(productgroup,'') name, productgroup value from MESDataCenter .dbo .m_TestType_t  where ProductGroup IS NOT null"
            LoadDataToCob(strsql, cboGroup)

        End If

    End Sub

    Private Sub cboGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGroup.SelectedIndexChanged

        If cboGroup.Text <> "" Then
            Dim sqlquery As String = "select testtypename name,TestTypeID value  from MESDataCenter .dbo .m_TestType_t  where  productgroup ='" & cboGroup.Text & "'and Usey ='Y' order by stationseq"
            LoadDataToCob(sqlquery, CboStation)
        Else
            SetMessage("FAIL", "请选择群组")
        End If
 
    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        CobName.DataSource = Nothing

        'For index As Integer = 0 To dt.Rows.Count - 1
        '    CobName.Items.Add(dt.Rows(index)(0).ToString)
        'Next
        CobName.DataSource = dt
        CobName.DisplayMember = "name"
        CobName.ValueMember = "value"
    End Sub

    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then

            lblMessage.Text = message

            lblMessage.ForeColor = Color.Crimson
        Else

            lblMessage.Text = message

            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    Private Sub TxtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            If String.IsNullOrEmpty(CboStation.Text) Then
                SetMessage("FAIL", "请选择站点!")
            End If
            If replace.Checked Then
                Dim SQL As String = "SELECT *  FROM  MESDataCenter.dbo.m_C314Binding  WHERE   ASN ='" & TxtBarCode.Text & "'"
                Dim DAT As DataTable = DbOperateUtils.GetDataTable(SQL)
                If DAT.Rows.Count > 0 Then
                    lblMessage.Text = ""
                    TxtBarCode.Enabled = False
                    NEWSN.Enabled = True
                    NEWSN.Focus()
                    Return
                Else
                    Tips.ForeColor = Color.Red
                    Tips.Text = "条码:" + TxtBarCode.Text + "未过绑定不许替换"
                    MessageBox.Show("条码:" + TxtBarCode.Text + "未过绑定不许替换", "异常操作", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                    TxtBarCode.Text = ""
                    Return
                End If
            Else
                If String.IsNullOrEmpty(cboGroup.Text) Then
                    SetMessage("FAIL", "请选择群组!")
                End If
                Redirectstation(TxtBarCode.Text.Trim.ToUpper, CboStation.SelectedValue, cboGroup.SelectedValue, ChkUnbox.Checked)
            End If

           
        End If
    End Sub
    Private Sub Redirectstation(ByVal ppid As String, ByVal stationid As String, ByVal group As String, ByVal chkbox As Boolean)
        SetMessage("OK", "")
        Try


            If String.IsNullOrEmpty(ppid) Then
                SetMessage("FAIL", "请输入条码!")
            End If

            Dim unbox As String
            If chkbox Then
                unbox = "1"
            Else
                unbox = "0"
            End If

            Dim Sqlstr As String
            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText varchar(150) " & _
                     " EXECUTE [Exec_ReTestStation] @strmsgid out, @strmsgText out,'" & ppid & "','" & stationid & "','" & unbox & "','" & group.Trim & "','" & VbCommClass.VbCommClass.UseId & "'" _
                     & " SELECT @strmsgid,@strmsgText "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "1"
                        SetMessage("OK", dt.Rows(0)(1) & "条码:" & Me.TxtBarCode.Text)
                    
                    Case "0"
                        SetMessage("FAIL", dt.Rows(0)(1) & "条码:" & Me.TxtBarCode.Text)
                End Select
            End If
            Me.TxtBarCode.Focus()
            Me.TxtBarCode.Text = ""
        Catch ex As Exception
            SetMessage("FAIL", ex.Message)
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles replace.CheckedChanged
        If replace.Checked Then
            cboGroup.Enabled = False
            Tips.Text = ""
        Else
            cboGroup.Enabled = True
            Tips.Text = ""
        End If
    End Sub
    Private Sub usedSN(ByVal SN As String)
        
    End Sub


    Private Sub NEWSN_KeyDown(sender As Object, e As KeyEventArgs) Handles NEWSN.KeyDown
        If e.KeyValue = 13 Then

            If TxtBarCode.Text.Trim().Length = NEWSN.Text.Trim().Length Then
                Dim SQL As String = "INSERT INTO MESDataCenter.dbo.m_Bindingsubstitution_t(ASN,NEWASN,USID)VALUES('" & TxtBarCode.Text & "','" & NEWSN.Text & "','" & VbCommClass.VbCommClass.UseId & "')"
                DbOperateUtils.ExecSQL(SQL)
                SQL = "UPDATE MESDataCenter.dbo.m_C314Binding  SET ASN='" & NEWSN.Text & "' WHERE ASN='" & TxtBarCode.Text & "'"
                DbOperateUtils.ExecSQL(SQL)
                SQL = "UPDATE MESDataCenter.dbo.m_C314coupling  SET ASN='" & NEWSN.Text & "' WHERE ASN='" & TxtBarCode.Text & "'"
                DbOperateUtils.ExecSQL(SQL)
                SQL = "UPDATE MESDataCenter.dbo.m_C314function  SET SN='" & NEWSN.Text & "' WHERE SN='" & TxtBarCode.Text & "'"
                DbOperateUtils.ExecSQL(SQL)
                Tips.ForeColor = Color.Lime
                Tips.Text = "条码:" + NEWSN.Text + "成功继承条码:" + TxtBarCode.Text
                NEWSN.Text = ""
                NEWSN.Enabled = False
                TxtBarCode.Enabled = True
                TxtBarCode.Text = ""
                TxtBarCode.Focus()
            Else
                Tips.ForeColor = Color.Red
                Tips.Text = "替换失败条码:" + NEWSN.Text + "格式不符"
                NEWSN.Text = ""
            End If

           

        End If

    End Sub
End Class