Public Class FrmSelAddPrtInfo
    Private _AppDt As DataTable
    '/ <summary>
    '/ 申请记录
    '/ </summary>
    Public Property AppDt() As DataTable
        Get
            Return _AppDt
        End Get
        Set(ByVal Value As DataTable)
            _AppDt = Value
        End Set
    End Property
    Private _IsFlag As Boolean = False
    '/ <summary>
    '/ 是否确认OK
    '/ </summary>
    Public Property IsFlag() As Boolean
        Get
            Return _IsFlag
        End Get
        Set(ByVal Value As Boolean)
            _IsFlag = Value
        End Set
    End Property
    Private _SelApList As String = ""
    '/ <summary>
    '/ 选择补数申请单
    '/ </summary>
    Public Property SelApList() As String
        Get
            Return _SelApList
        End Get
        Set(ByVal Value As String)
            _SelApList = Value
        End Set
    End Property
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ApplyPrtSum As Integer = 0
        Dim AppidList As String = ""
        Dim chkTemp As Windows.Forms.DataGridViewCheckBoxCell
        For i As Int16 = 0 To Me.dgvApplyAddPrintList.RowCount - 1
            chkTemp = dgvApplyAddPrintList.Rows(i).Cells("ChkSelect")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                AppidList = AppidList & dgvApplyAddPrintList.Rows(i).Cells("appid").Value & ","
                ApplyPrtSum = ApplyPrtSum + (dgvApplyAddPrintList.Rows(i).Cells("PrtQty").Value - dgvApplyAddPrintList.Rows(i).Cells("FinishPrintQty").Value)
            End If
        Next
        If AppidList <> "" Then
            SetMessage(AppidList)
            SelApList = AppidList.Substring(0, AppidList.Length - 1) & "-" & ApplyPrtSum
            IsFlag = True

            Me.Close()
        Else
            SetMessage("请选择数据")
        End If


    End Sub
    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

    Private Sub FrmSelAddPrtInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelApList = ""
        IsFlag = False
        Me.dgvApplyAddPrintList.AutoGenerateColumns = False
        LoadData(AppDt, dgvApplyAddPrintList)
    End Sub
    Private Sub LoadData(ByVal DReader As DataTable, ByVal dgvName As Windows.Forms.DataGridView)

        Try
            Me.dgvApplyAddPrintList.DataSource = DReader
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmSelAddPrtInfo", "LoadData", "sys")
            Throw ex '出错
        End Try
    End Sub

    Private Sub chkSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelAll.CheckedChanged
        Try
            If (Me.dgvApplyAddPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvApplyAddPrintList.RowCount - 1
                    dgvApplyAddPrintList.Rows(i).Cells("ChkSelect").Value = Me.chkSelAll.Checked
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmSelAddPrtInfo", "chkSelAll_CheckedChanged", "sys")
        End Try
    End Sub
End Class