Imports System.Net
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class FrmEMCEquipmentconfig

    Sub New()
        InitializeComponent()
    End Sub

    Private _CurrentIndex As Integer = 0
    Public Property CurrentIndex() As Integer
        Get
            Return _CurrentIndex
        End Get
        Set(ByVal value As Integer)
            _CurrentIndex = value
        End Set
    End Property

    Private _PartID As String
    ''' <summary>
    ''' 料号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartID() As String
        Get
            Return _PartID
        End Get
        Set(ByVal value As String)
            _PartID = value
        End Set
    End Property



#Region "提交数据"
    ''' <summary>
    ''' 提交数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiSubmit_Click(sender As Object, e As EventArgs) Handles tsmiSubmit.Click
        Try
            Dim sql = ""
            Dim NO = dgvData.Rows(CurrentIndex).Cells("NO").Value.ToString().Trim()
            Dim StationName = dgvData.Rows(CurrentIndex).Cells("StationName").Value.ToString().Trim
            Dim EquimentName = dgvData.Rows(CurrentIndex).Cells("EquimentName").Value.ToString().Trim
            Dim EquimentNO = dgvData.Rows(CurrentIndex).Cells("EquimentNO").Value.ToString().Trim
            Dim EmpCode = dgvData.Rows(CurrentIndex).Cells("EmpCode").Value.ToString().Trim
            Dim EmpName = dgvData.Rows(CurrentIndex).Cells("EmpName").Value.ToString().Trim
            Dim JobName = dgvData.Rows(CurrentIndex).Cells("JobName").Value.ToString().Trim
            Dim ApplicationDate = dgvData.Rows(CurrentIndex).Cells("ApplicationDate").Value.ToString().Trim
            If Not String.IsNullOrEmpty(ApplicationDate) Then
                ApplicationDate = Convert.ToDateTime(ApplicationDate).ToString("yyyy-MM-dd")
            End If
            Dim ExpirationDate = dgvData.Rows(CurrentIndex).Cells("ExpirationDate").Value.ToString().Trim
            If Not String.IsNullOrEmpty(ExpirationDate) Then
                ExpirationDate = Convert.ToDateTime(ExpirationDate).ToString("yyyy-MM-dd")
            End If
            Dim Status = dgvData.Rows(CurrentIndex).Cells("Status").Value.ToString().Trim
            If String.IsNullOrEmpty(StationName) Then
                MessageUtils.ShowError("请填写工站名称")
                Exit Sub
            ElseIf String.IsNullOrEmpty(EquimentNO) Then
                MessageUtils.ShowError("请填写设备编号")
                Exit Sub
            ElseIf String.IsNullOrEmpty(EmpCode) Then
                MessageUtils.ShowError("请填写设备负责人工号")
                Exit Sub
            ElseIf String.IsNullOrEmpty(EmpName) Then
                MessageUtils.ShowError("请确认输入的工号:" + EmpCode + ",是否是在职人员")
                Exit Sub
            End If
            If String.IsNullOrEmpty(NO) Then '代表的是新增的数据
                NO = DbOperateUtils.GetDataTable("select isnull(max(NO),0)+1 from m_EMCEquipmentconfig_t where partID='" & Me.PartID & "'").Rows(0)(0).ToString()
                sql = "insert into m_EMCEquipmentconfig_t (NO,StationName,EquimentName," & vbCrLf &
                "EquimentNO,EmpCode,EmpName,JobName,ApplicationDate,ExpirationDate,Status,PartID)" & vbCrLf &
                " values ('" & NO & "',N'" & StationName & "',N'" & EquimentName & "'," & vbCrLf &
                "'" & EquimentNO & "','" & EmpCode & "',N'" & EmpName & "',N'" & JobName & "'" & vbCrLf &
                ",'" & ApplicationDate & "','" & ExpirationDate & "',N'" & Status & "','" & Me.PartID & "')"
            Else '做修改动作
                sql = "update m_EMCEquipmentconfig_t " & vbCrLf &
                "set StationName=N'" & StationName & "',EquimentName=N'" & EquimentName & "'" & vbCrLf &
                ",EquimentNO='" & EquimentNO & "',EmpCode='" & EmpCode & "',EmpName=N'" & EmpName & "'" & vbCrLf &
                ",JobName=N'" & JobName & "',ApplicationDate='" & ApplicationDate & "'" & vbCrLf &
                ",ExpirationDate='" & ExpirationDate & "',Status=N'" & Status & "' " & vbCrLf &
                ",PartID='" & Me.PartID & "' where no='" & NO & "' and PartID='" & Me.PartID & "'"
            End If
            DbOperateUtils.ExecSQL(sql)
            MessageUtils.ShowInformation("提交成功！")
            dgvData.Rows(CurrentIndex).Cells("NO").Value = NO
        Catch ex As Exception
            MessageUtils.ShowError("提交失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

    Private Sub FrmEMCEquipmentconfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoad()
    End Sub

#Region "绑定数据源"
    ''' <summary>
    ''' 绑定数据源
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoad()
        Dim sql = "select * from m_EMCEquipmentconfig_t where isnull(PartID,'" & Me.PartID & "')='" & Me.PartID & "' order by no"
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = DbOperateUtils.GetDataTable(sql)
    End Sub
#End Region


#Region "WebAPI获取DCS直接人员岗位相关信息"
    ''' <summary>
    ''' WebAPI获取DCS直接人员岗位相关信息
    ''' </summary>
    ''' <param name="empCode">工号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WebAPILoad(ByVal empCode As String) As String
        Dim result = ""
        Dim url = "https://hr.luxshare-ict.com/api/MES/GetTechnicalJobs?empcode=" + empCode
        Dim Request = CType(WebRequest.Create(url), HttpWebRequest)
        Request.Method = "Get"
        Request.Accept = "text/html,application/xhml+xml,*/*"
        Request.ContentType = "application/json"
        Request.Headers.Add("Authorization", "BasicAuth jWn&mY4v05kDpu$exZC!e69aIk!gw3D7o9qr@G^*$CjQ@^4P8IJyU5jQW7aLUOjk")
        Dim Response = CType(Request.GetResponse(), HttpWebResponse)
        Using reader As StreamReader = New StreamReader(Response.GetResponseStream(), Encoding.UTF8)
            result = reader.ReadToEnd()
        End Using
        Return result
    End Function
#End Region

#Region "Json转成DataTable"
    ''' <summary>
    ''' Json转成DataTable
    ''' </summary>
    ''' <param name="json">Json格式字符串</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function JsonToDataTable(ByVal json As String) As DataTable
        Dim dt = New DataTable()
        Try
            If json.Contains("Results") Then
                Dim One = json.IndexOf("[")
                Dim Two = json.LastIndexOf("]")
                json = json.Substring(One, Two - One + 1)
                dt = JsonConvert.DeserializeObject(Of DataTable)(json)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("json转成DataTable出现异常:" & vbCrLf & "" + ex.Message)
        End Try
        Return dt
    End Function
#End Region

#Region "单元格双击事件"
    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        CurrentIndex = e.RowIndex
    End Sub
#End Region

#Region "单元格结束编辑事件"
    Private Sub dgvData_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        If dgvData.Columns(e.ColumnIndex).Name = "EmpCode" Then
            Dim EmpCode = dgvData.Rows(CurrentIndex).Cells("EmpCode").Value.ToString()

            Dim ObjEmpName = DBUtility.DbOracleForSpcHelperSQL.GetSingle("select name from v_employeeonjob where code='" & EmpCode & "'")
            If ObjEmpName Is Nothing Then
                MessageUtils.ShowError("立讯在职人员没有这个工号:" + EmpCode)
                dgvData.Rows(CurrentIndex).Cells("EmpName").Value = ""
                dgvData.Rows(CurrentIndex).Cells("EmpCode").Value = ""
                isNext = True
                dgvData.ClearSelection()
                dgvData.Rows(CurrentIndex).Selected = True
                dgvData.CurrentCell = dgvData.Rows(CurrentIndex).Cells("EmpCode")
                Exit Sub
            End If
            dgvData.Rows(CurrentIndex).Cells("EmpName").Value = ObjEmpName
            Dim json = WebAPILoad(EmpCode)
            Dim dt = JsonToDataTable(json)
            If dt.Rows.Count > 0 Then
                dgvData.Rows(CurrentIndex).Cells("JobName").Value = dt.Rows(0)("JobName").ToString()
                Dim ApplicationDate = dt.Rows(0)("ApplyDate").ToString()
                If Not String.IsNullOrEmpty(ApplicationDate) Then
                    ApplicationDate = Convert.ToDateTime(ApplicationDate).ToString("yyyy-MM-dd")
                End If
                dgvData.Rows(CurrentIndex).Cells("ApplicationDate").Value = ApplicationDate
                Dim ExpirationDate = dt.Rows(0)("CertEndDate").ToString()
                If Not String.IsNullOrEmpty(ExpirationDate) Then
                    ExpirationDate = Convert.ToDateTime(ExpirationDate).ToString("yyyy-MM-dd")
                End If
                dgvData.Rows(CurrentIndex).Cells("ExpirationDate").Value = ExpirationDate

                dgvData.Rows(CurrentIndex).Cells("Status").Value = GetStatusName(dt.Rows(0)("State").ToString())
            Else '如果测试输入的是间接人员就去掉岗位相关信息 2018-10-10 马跃平
                dgvData.Rows(CurrentIndex).Cells("JobName").Value = Nothing
                dgvData.Rows(CurrentIndex).Cells("ApplicationDate").Value = Nothing
                dgvData.Rows(CurrentIndex).Cells("ExpirationDate").Value = Nothing
                dgvData.Rows(CurrentIndex).Cells("Status").Value = Nothing
            End If
        End If

    End Sub
#End Region

#Region "通过状态ID获取状态名称"
    ''' <summary>
    ''' 通过状态ID获取状态名称
    ''' </summary>
    ''' <param name="statuID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStatusName(ByVal statuID As String) As String
        Dim result = ""

        Select Case statuID
            Case "0"
                result = "待审核"
            Case "1"
                result = "已审核"
            Case "2"
                result = "失效"
            Case "3"
                result = "暂离岗位"
            Case "4"
                result = "离职"
            Case "5"
                result = "吊销"
            Case "6"
                result = "驳回"
            Case Else
                result = "TT同步异常"
        End Select
        Return result
    End Function
#End Region

#Region "删除"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiDelete_Click(sender As Object, e As EventArgs) Handles tsmiDelete.Click
        Dim NO = dgvData.CurrentRow.Cells("NO").Value.ToString()
        If String.IsNullOrEmpty(NO) Then
            MessageUtils.ShowError("没有要删除的数据!")
            Exit Sub
        Else
            If DialogResult.OK = MessageUtils.ShowConfirm("确定要删除该行的设备信息嘛?", MessageBoxButtons.OKCancel) Then
                Dim sql = New System.Text.StringBuilder()
                sql.AppendLine("delete m_EMCEquipmentconfig_t where no='" + NO + "' and PartID='" & Me.PartID & "'")
                sql.AppendLine("update m_EMCEquipmentconfig_t set NO=NO-1 where PartID='" & Me.PartID & "' and NO>" & NO & "")
                DbOperateUtils.ExecSQL(sql.ToString())
                MessageUtils.ShowInformation("删除成功!")
                DataLoad()
            End If
        End If
    End Sub
#End Region

    Dim isNext As Boolean = False
   
    Private Sub dgvData_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvData.RowValidating
        If isNext = True Then
            e.Cancel = True
            isNext = False
        End If
    End Sub
End Class

