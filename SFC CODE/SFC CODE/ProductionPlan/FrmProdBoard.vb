Imports MainFrame
Imports MainFrame.SysCheckData

''' <summary>
''' 新显示看板
''' </summary>
''' <remarks></remarks>
Public Class FrmProdBoard

    '看板地址取得参数
    Dim prodBoardKey As String = "ProdBoard"

    Private _deptID As String
    ''' <summary>
    ''' 部门
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property DeptId()
        Set(ByVal value)
            _deptID = value
        End Set
    End Property

    Private _lineId As String
    ''' <summary>
    ''' 线别
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property LineId()
        Set(ByVal value)
            _lineId = value
        End Set
    End Property

    Private _PlanDay As String
    ''' <summary>
    ''' 看板日期
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>    
    Public Property PlanDay() As String
        Get
            Return _PlanDay
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                _PlanDay = Now.ToString("yyyy-MM-dd")
            Else
                _PlanDay = Value
            End If

        End Set
    End Property

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmProdBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim url As String = GetPars(prodBoardKey)
        url = String.Format(url, _lineId, _PlanDay)
        Try
           
            WebBrowser1.Url = New Uri(url)
        Catch ex As Exception
            MessageUtils.ShowError("打开URL" & url & "失败，请与MES开发人员联系！")
            SysMessageClass.WriteErrLog(ex, "FrmProductionBoard", "FrmProductionBoard_Load", "sys")
        End Try
    End Sub

    '取得看板设置参数 
    Private Function GetPars(pars As String) As String
        Dim result As String = ""
        Dim strSQL As String = "select TEXT from m_BaseData_t where [ITEMKEY] = '{0}'"
        strSQL = String.Format(strSQL, pars)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            result = dt.Rows(0)(0).ToString
        End If
        Return result
    End Function

   

End Class