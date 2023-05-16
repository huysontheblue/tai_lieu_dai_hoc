Imports MainFrame.SysDataHandle
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame

'创建者：田玉琳
'创建日：2016/09/27
'说明：扫描因为自动生成的箱条码的数据
'      实际相同的箱没有扫描。

Public Class FrmCheckCarton

#Region "窗體基本屬性"

    Dim mCustomer As String
    Dim mMoid As String

    Public WriteOnly Property Customer() As String
        Set(value As String)
            mCustomer = value
        End Set
    End Property

    Public WriteOnly Property Moid() As String
        Set(value As String)
            mMoid = value
        End Set
    End Property

#End Region

    Private Sub FrmCheckCarton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMessage.Text = ""

        Dim Sqlstr As String = String.Empty

        Sqlstr = "SELECT A.Cusid,B.CusName  FROM" & _
                   " (SELECT DISTINCT Cusid FROM m_Mainmo_t WHERE ISNULL(Cusid,'')<>''" & _
                   " UNION " & _
                   " SELECT DISTINCT Cusid FROM m_PartContrast_t WHERE ISNULL(Cusid,'')<>'') A" & _
                   " INNER JOIN m_Customer_t B ON A.Cusid=B.CusID" & _
                   " ORDER BY A.Cusid"
        LoadDataToCob(Sqlstr, CboSupport) ''填充客戶

        CboSupport.Text = mCustomer
        mtxtMOid.Text = mMoid

    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0) & "(" & PubDataReader.GetString(1) & ")")
            End While
        End If
        PubDataReader.Close()
        PubClass.PubConnection.Close()
        PubClass = Nothing
    End Sub

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            frmMOQuery.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub BnCancel_Click(sender As Object, e As EventArgs) Handles BnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtBarcode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtBarcode.PreviewKeyDown
        lblMessage.Text = ""
        If String.IsNullOrEmpty(mtxtMOid.Text) Then
            SetMessage("FAIL", "请选择扫描工单！")
            Me.TxtBarcode.Text = ""
            Exit Sub
        End If

        If chkIsSame.Checked Then
            If String.IsNullOrEmpty(txtCartonId.Text) Then
                SetMessage("FAIL", "请输入要比对箱号！")
                txtCartonId.Focus()
                Exit Sub
            End If
            If txtCartonId.Text.Trim <> TxtBarcode.Text.Trim Then
                SetMessage("FAIL", "扫描箱条码和要求的不一致！")
                TxtBarcode.Focus()
                Exit Sub
            End If
        End If

        If e.KeyValue = 13 Then
            StandScan()
        End If
    End Sub

    Private Sub StandScan()
        Try
            Dim Sqlstr As String
            Sqlstr = " DECLARE @RTVALUE varchar(1), @RTMSG varchar(150) " &
                     " EXECUTE [Exec_CartonCheck] @RTVALUE OUTPUT,@RTMSG OUTPUT, '{0}','{1}','{2}','{3}','{4}','{5}' " &
                      "SELECT @RTVALUE,@RTMSG"
            Dim isSystemPrint As String = IIf(chkIsSystemPrint.Checked, "1", "2")

            Sqlstr = String.Format(Sqlstr, mtxtMOid.Text.Trim, TxtBarcode.Text.Trim,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, VbCommClass.VbCommClass.UseId,
                                   isSystemPrint)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SetMessage("FAIL", dt.Rows(0)(1).ToString)
                    Case "1"
                        SetMessage("PASS", "扫描成功...")
                End Select
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.mtxtMOid.Text.Trim, TxtBarcode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmCheckCarton", "StandScan", "sys")
        End Try
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

    Private Sub chkIsSame_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsSame.CheckedChanged
        If chkIsSame.Checked Then
            txtCartonId.Enabled = True
        Else
            txtCartonId.Enabled = False
        End If
    End Sub

    Private Sub chkIsSystemPrint_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsSystemPrint.CheckedChanged
        If chkIsSystemPrint.Checked Then
            chkIsSame.Checked = False
            txtCartonId.Enabled = False
        End If
    End Sub
End Class