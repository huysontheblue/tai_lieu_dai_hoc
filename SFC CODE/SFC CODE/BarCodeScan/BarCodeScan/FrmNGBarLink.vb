Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame

Public Class FrmNGBarLink
#Region "属性"
    Private _LineId As String
    Private _MoNo As String
    Public SaveEquip As String = "N"
    Private _PartID As String
    Private _SNStyle As String = ""
    Private _StationID As String =""
#End Region


    Sub New(ByVal LineId As String, ByVal MoNo As String, _
            ByVal PartID As String, ByVal o_strSNStyle As String, ByVal o_strStationID As String
            )
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._LineId = LineId
        Me._MoNo = MoNo
        Me._PartID = PartID
        Me._SNStyle = o_strSNStyle
        Me._StationID = o_strStationID
    End Sub

    Private Sub FrmNGBarLink_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.lblMOID.Text = Me._MoNo
        Me.lblPartID.Text = Me._PartID
        Me.lblSNStyle.Text = Me._SNStyle
        Me.lblStationID.Text = Me._StationID

        Me.lblMsg.Text = ""
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLink_Click(sender As Object, e As EventArgs) Handles btnLink.Click
        Me.lblMsg.Text = ""
        '先检查 
        If String.IsNullOrEmpty(Me.txtSN.Text) Then
            'lblMsg.Text = "NG,请先输入产品条码"
            SetMessage("Fail", "NG,请先输入产品条码")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.txtNGBarCode.Text) Then
            ' lblMsg.Text = "NG,请先输入不良条码"
            SetMessage("Fail", "NG,请先输入不良条码")
            Exit Sub
        End If

        Call RecordNGBarLinkInfo()

    End Sub


    Private Sub RecordNGBarLinkInfo() 'ByVal packBarCode As String
        Dim o_strMsg As String = ""
        Dim blnOnlyClearNGBar As Boolean = False
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_RecordNGBarLinkInfo_P] '" & Trim(lblMOID.Text) & "', '" & lblPartID.Text.Trim & "', '" & lblStationID.Text.Trim & "','" & txtSN.Text.Trim & "',")
            strSQL.Append(" '" & txtNGBarCode.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "',@RTVALUE OUTPUT, @strmsgText OUTPUT ")
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        ' Dim errMsg As Exception = New Exception(String.Format("错误信息:{0}", dt.Rows(0)(0), ex.ToString))
                        'SysMessageClass.WriteErrLog(errMsg, "FrmNGBarLink", "RecordNGBarLinkInfo", "NGBarLink")
                        o_strMsg = "关联失败," + dt.Rows(0)(1).ToString
                        SetMessage("FAIL", o_strMsg)
                        blnOnlyClearNGBar=False
                        ClearUI(blnOnlyClearNGBar)
                    Case "-1"
                        o_strMsg = "关联失败," + dt.Rows(0)(1).ToString
                        SetMessage("FAIL", o_strMsg)
                        blnOnlyClearNGBar = True
                        ClearUI(blnOnlyClearNGBar)
                    Case "1"
                        'OK
                        SetMessage("PASS", "关联成功！")
                        blnOnlyClearNGBar = False
                        ClearUI(blnOnlyClearNGBar)
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmNGBarLink", "RecordNGBarLinkInfo", "NGBarLink")
        End Try
    End Sub

    Private Sub ClearUI(ByVal blnOnlyClearNGBar As Boolean )
        If blnOnlyClearNGBar =True Then
            Me.txtNGBarCode.Text = ""
            me.txtNGBarCode.Focus()
        Else
            Me.txtSN.Text = ""
            Me.txtNGBarCode.Text = ""
            Me.txtSN.Focus()
        End If

        ' Me.txtNGBarCode.Text = ""
        ' Me.txtSN.Focus()
    End Sub


    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String) As Boolean

        '********************************20170206 田玉琳 Start ****************************************************
        '扫描条码样式不能为空
        If lblSNStyle.Text.Trim.Length = 0 Then
            WorkStantOption.ErrorStr = "扫描条码样式不能为空！"
            SetMessage("Fail", "扫描条码样式不能为空！")
            'WorkStantOption.BarCodeStr = BarCode
            'WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            'ShowFrmScanErrPrompt()
            txtSN.Text = ""
            Me.txtSN.Focus()
            ' PlaySimpleSound(1)
            Return False
        End If
        '********************************20170206 田玉琳 End ****************************************************

        '********************************20160615 田玉琳 Start ****************************************************
        '非系统打印条码要求验证样式
        ' 田玉琳 20161101 
        '系统条码也要验证样式（有子件处理）IsHaveChildCode IsPrtSelf <> "Y" And 

        ' 田玉琳 20171128 系统条码也需要验证样式，修改判断条件 
        'If (IsHaveChildCode = "Y" Or IsPrtSelf <> "Y") And TxtSnStyle1.Text.Trim.Length <> 0 Then
        If lblSNStyle.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> lblSNStyle.Text.Length Then
                WorkStantOption.ErrorStr = "扫描条码长度不对"
                SetMessage("Fail", "扫描条码长度不对")
                'WorkStantOption.BarCodeStr = BarCode
                'WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                'ShowFrmScanErrPrompt()
                txtSN.Text = ""
                Me.txtSN.Focus()
                ' PlaySimpleSound(1)
                Return False
            End If

            If TextHandle.verfyBarCodeStyle(Me._SNStyle, BarCode, Me._SNStyle) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                'PlaySimpleSound(1)
                'WorkStantOption.BarCodeStr = BarCode
                'WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                'ShowFrmScanErrPrompt()
                txtSN.Text = ""
                Me.txtSN.Focus()
                'PlaySimpleSound(1)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            'LabResult.Text = "FAIL"
            lblMsg.Text = message
            ' LabResult.ForeColor = Color.Crimson
            lblMsg.ForeColor = Color.Crimson
        Else
            'LabResult.Text = "PASS"
            lblMsg.Text = message
            'LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMsg.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    Private Sub txtSN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSN.PreviewKeyDown
        If e.KeyValue = 13 Then
            me.lblMsg.Text = ""
            If CheckStyle(txtSN.Text) = False Then
                Me.txtSN.Text = ""
                Me.txtSN.Focus()
                Exit Sub
            Else
                '进行下一步的不良条码的输入
                Me.txtNGBarCode.Focus()
            End If
        End If
    End Sub

    Private Sub txtNGBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtNGBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            Me.lblMsg.Text = ""
            '先检查 
            If String.IsNullOrEmpty(Me.txtSN.Text) Then
                lblMsg.Text = "NG,请先输入产品条码"
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.txtNGBarCode.Text) Then
                lblMsg.Text = "NG,请先输入不良条码"
            End If

            Call RecordNGBarLinkInfo()

            ' ClearUI()
        End If
    End Sub
End Class