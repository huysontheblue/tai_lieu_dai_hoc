Imports MainFrame
Imports MainFrame.SysCheckData

''' <summary>
''' 显示看板
''' </summary>
''' <remarks></remarks>
Public Class FrmProductionBoard

    '看板地址取得参数
    'Dim productionBoardKey As String = "ProductionBoard"
    Dim productionBoardKey As String = "ProdBoard" '新看板地址取得参数

    Private moidID As String
    ''' <summary>
    ''' 工单号
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property PmoidID()
        Set(ByVal value)
            moidID = value
        End Set
    End Property

    Private lineId As String
    ''' <summary>
    ''' 线别
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property PLineId()
        Set(ByVal value)
            lineId = value
        End Set
    End Property

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmProductionBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim url As String = GetPars(productionBoardKey)
            Dim deptID As String = GetDeptIdByMoid()

            url = String.Format(url, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, deptID, lineId)

            WebBrowser1.Url = New Uri(url)

        Catch ex As Exception
            MessageUtils.ShowError("请与MES开发人员联系！")
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

    Private Function GetDeptIdByMoid() As String
        Dim result As String = ""
        Dim strSQL As String = "select  Deptid  from m_Mainmo_t where moid = '{0}'"
        strSQL = String.Format(strSQL, moidID)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            result = dt.Rows(0)(0).ToString
        End If
        Return result
    End Function


End Class