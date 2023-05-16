
'--员工打卡
'--Create by :　马锋
'--Create date :　2017/01/06
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame
Imports System
Imports System.Net

#End Region

Public Class FrmEmployeeCard

#Region "变量声明"

    Dim _strMOId As String
    Dim _strLineId As String

#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strMOId As String, ByVal strLineId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strMOId = strMOId
        _strLineId = strLineId
    End Sub

#End Region

    Private Sub FrmEmployeeScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvList.AutoGenerateColumns = False
            Me.mtxtMOID.Text = _strMOId
            Me.mtxtLineId.Text = _strLineId
            GetEmployeeCard(Me.mtxtMOID.Text.Trim)
            Me.ActiveControl = Me.txtCardNo
        Catch ex As Exception
            Me.ActiveControl = Me.txtCardNo
        End Try
    End Sub

    Private Sub txtCardNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCardNo.KeyDown
        Try
            'http://spc.luxshare-ict.com:19999/Api/Employee/GetEmployeesByCardNo?cardNo=4237499356
            If (e.KeyCode = Keys.Enter) Then
                If String.IsNullOrEmpty(Me.mtxtMOID.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "请选择工单", False)
                    Me.txtCardNo.Text = ""
                    Me.ActiveControl = Me.txtCardNo
                    Exit Sub
                End If

                If String.IsNullOrEmpty(Me.mtxtLineId.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "请选择产线", False)
                    Me.txtCardNo.Text = ""
                    Me.ActiveControl = Me.txtCardNo
                    Exit Sub
                End If

                If String.IsNullOrEmpty(Me.txtCardNo.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "获取卡号失败,请重新刷卡", False)
                    Me.txtCardNo.Text = ""
                    Me.ActiveControl = Me.txtCardNo
                    Exit Sub
                End If

                Dim web As New System.Net.WebClient()
                web.Headers.Add("Content-Type", "application/json")
                Dim pagedata As Object = web.DownloadData("http://spc.luxshare-ict.com:19999/Api/Employee/GetEmployeesByCardNo?cardNo=" & Me.txtCardNo.Text.Trim & "")
                Dim strIsSuccess, strErrMsg, strEmpCode, strEmpName, strUrl As String

                FormatEmployee(Encoding.UTF8.GetString(pagedata), strIsSuccess, strErrMsg, strEmpCode, strEmpName, strUrl)

                If (strIsSuccess = "true") Then
                    Me.txtEmployeeCode.Text = strEmpCode
                    Me.txtEmployeeName.Text = strEmpName
                    Me.pbPhoto.ImageLocation = strUrl
                    Me.pbPhoto.Load()

                    If Not CheckEmployeeCard(strEmpCode) Then

                        Dim strSQL As New StringBuilder

                        strSQL.AppendLine("DECLARE @PARTID VARCHAR(32) SELECT @PARTID = PartID FROM m_Mainmo_t WHERE MOID='" & Me.mtxtMOID.Text.Trim & "' ")
                        strSQL.AppendLine(" INSERT INTO m_LineCard_t(Moid, PartId, LineId, CardDay, CardNO, EmployeeCode, EmployeeName, CardFlag, CreateUserId,  CreateTime) ")
                        strSQL.AppendLine(" VALUES('" & Me.mtxtMOID.Text.Trim & "', @PARTID, '" & Me.mtxtLineId.Text.Trim & "', CONVERT(VARCHAR(10), GETDATE(), 120), '" & Me.txtCardNo.Text.Trim & "', '" & strEmpCode & "', N'" & strEmpName & "', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE()) ")
                        DbOperateUtils.ExecSQL(strSQL.ToString)
                        GetEmployeeCard(Me.mtxtMOID.Text.Trim)
                    End If
                    GetMesData.SetMessage(Me.lblMessage, strEmpCode & "刷卡成功", True)
                Else
                    Me.txtEmployeeCode.Text = ""
                    Me.txtEmployeeName.Text = ""
                    Me.pbPhoto.Image = Nothing
                    ' Me.pbPhoto.Load()
                    GetMesData.SetMessage(Me.lblMessage, strErrMsg, False)
                End If
                Me.txtCardNo.Text = ""
                Me.ActiveControl = Me.txtCardNo
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取卡号失败,请重新刷卡", True)
            Me.txtCardNo.Text = ""
            Me.ActiveControl = Me.txtCardNo
        End Try
    End Sub

    Private Sub mtxtMOID_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOID.ButtonCustomClick
        Try
            Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOID, "")
            frmMOQuery.ShowDialog()

            If (Not String.IsNullOrEmpty(Me.mtxtMOID.Text.Trim)) Then
                Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT Moid, PartID, Lineid, Moqty FROM m_Mainmo_t WHERE Moid='" & Me.mtxtMOID.Text.Trim & "'")

                If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                    Me.mtxtLineId.Text = dtTemp.Rows(0).Item("Lineid").ToString
                End If
            Else
                Me.mtxtLineId.Text = ""
            End If

            GetEmployeeCard(Me.mtxtMOID.Text.Trim)
            Me.txtEmployeeCode.Text = ""
            Me.txtEmployeeName.Text = ""
            Me.pbPhoto.Image = Nothing
            'Me.pbPhoto.Load()
            GetMesData.SetMessage(Me.lblMessage, "工单设置成功", True)
            Me.ActiveControl = Me.txtCardNo
        Catch ex As Exception
            Me.ActiveControl = Me.txtCardNo
        End Try
    End Sub

    Private Function CheckEmployeeCard(ByVal strEmployeeCode As String)
        Dim rtValue As Boolean = False
        For i As Int32 = 0 To Me.dgvList.Rows.Count - 1
            If (Me.dgvList.Rows(i).Cells("EmployeeCode").Value.ToString.Trim = strEmployeeCode) Then
                rtValue = True
                Exit For
            End If
        Next
        Return rtValue
    End Function

    Private Sub GetEmployeeCard(ByVal strMOId As String)
        Try
            If (String.IsNullOrEmpty(Me.mtxtMOID.Text.Trim)) Then
                Me.dgvList.DataSource = Nothing
                Me.dgvList.Rows.Clear()
                Exit Sub
            End If

            Me.dgvList.DataSource = DbOperateUtils.GetDataTable("SELECT  LineCardId, Moid, PartId, LineId, CardDay, CardNO, EmployeeCode, EmployeeName, CardFlag, CreateUserId,  CreateTime FROM m_LineCard_t WHERE LineId='" & Me.mtxtLineId.Text.Trim & "' AND MOID='" & Me.mtxtMOID.Text.Trim & "' AND CardDay = CONVERT(VARCHAR(10), GETDATE(), 120) ")
            Me.lblRecord.Text = Me.dgvList.Rows.Count
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取工单刷卡记录异常", False)
        End Try
    End Sub

    Private Sub FormatEmployee(ByVal strValue As String, ByRef strIsSuccess As String, ByRef strErrMsg As String, ByRef strEmpCode As String, ByRef strEmpName As String, ByRef strUrl As String)
        ''{"IsSuccess":true,"ErrMsg":null,"Data":{"EmpCode":"L037520","EmpName":"江泽丹","Url":"http://dcs.luxshare-ict.com/Upload/emp_photo/L037520.jpg"},"Total":0}
        Try
            strValue = strValue.Replace("""Data"":", "")
            strValue = strValue.Replace("{", "").Replace("}", "").Replace("""", "")
            Dim arrValue As Array = strValue.Split(",")

            If arrValue(0).ToString.Split(":")(1) = "true" Then
                strIsSuccess = "true"
                strEmpCode = arrValue(2).ToString.Split(":")(1)
                strEmpName = arrValue(3).ToString.Split(":")(1)
                strUrl = arrValue(4).ToString.Split(":")(1) & ":" & arrValue(4).ToString.Split(":")(2)
            Else
                strIsSuccess = "false"
                strErrMsg = arrValue(1).ToString.Split(":")(1)
            End If
        Catch ex As Exception
            strIsSuccess = "false"
            strErrMsg = "执行员工信息解析异常"
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolStartCard_Click(sender As Object, e As EventArgs) Handles toolStartCard.Click
        Me.ActiveControl = Me.txtCardNo
    End Sub

    Private Sub toolComplete_Click(sender As Object, e As EventArgs) Handles toolComplete.Click
        Try
            If (Not CheckComplete()) Then
                Exit Sub
            End If
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine(" UPDATE m_LineCard_t SET CardFlag = '1', CompleteUserId='" & VbCommClass.VbCommClass.UseId & "', CompleteTime=Getdate() WHERE LineId='" & Me.mtxtLineId.Text.Trim & "' AND MOID='" & Me.mtxtMOID.Text.Trim & "' AND CardDay = CONVERT(VARCHAR(10), GETDATE(), 120) ")
            strSQL.AppendLine(" IF EXISTS(SELECT MOID FROM m_Mainmo_t WHERE MOID='" & Me.mtxtMOID.Text.Trim & "' AND ISNULL(StartUserId, '') = '') BEGIN UPDATE m_Mainmo_t SET StartUserId= '" & VbCommClass.VbCommClass.UseId & "', StartTime=GETDATE() WHERE Moid='" & Me.mtxtMOID.Text.Trim & "' END ")

            DbOperateUtils.ExecSQL(strSQL.ToString)
            Me.mtxtMOID.Text = ""
            Me.txtCardNo.Text = ""
            GetMesData.SetMessage(Me.lblMessage, "完成成功", True)
            Me.ActiveControl = Me.txtCardNo
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "完成异常", False)
            Me.ActiveControl = Me.txtCardNo
        End Try
    End Sub

    Private Sub mtxtLineId_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtLineId.ButtonCustomClick
        Try
            Dim frmLineQuery As New FrmLineQuery("", Me.mtxtLineId)
            frmLineQuery.ShowDialog()
            Me.ActiveControl = Me.txtCardNo
        Catch ex As Exception
            Me.ActiveControl = Me.txtCardNo
        End Try
    End Sub

    Private Function CheckComplete() As Boolean
        Try
            If (String.IsNullOrEmpty(Me.mtxtLineId.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "产线不能为空", True)
                Return False
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 EmployeeCode FROM m_LineCard_t WHERE CardFlag = '0' AND LineId='" & Me.mtxtLineId.Text.Trim & "' AND MOID='" & Me.mtxtMOID.Text.Trim & "' AND CardDay = CONVERT(VARCHAR(10), GETDATE(), 120)")

            If (Not dtTemp Is Nothing) Then
                If (dtTemp.Rows.Count > 0) Then
                    Return True
                Else
                    GetMesData.SetMessage(Me.lblMessage, "完成失败，当前产线未打卡", True)
                    Return False
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "完成失败，当前产线未打卡", True)
                Return False
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查打卡记录异常", True)
            Return False
        End Try
    End Function

End Class