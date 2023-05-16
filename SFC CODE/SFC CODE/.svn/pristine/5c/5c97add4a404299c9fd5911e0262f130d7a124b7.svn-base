Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports SysBasicClass
'Imports SysBasicClass

Public Class FrmRunCardCopy


#Region "属性"

#Region "PartNumber"
    Private _RCPartNumber As String

    Public Property RCPartNumber() As String
        Get
            Return _RCPartNumber
        End Get

        Set(ByVal Value As String)
            _RCPartNumber = Value
        End Set
    End Property
#End Region

#End Region

#Region "事件"
    Private Sub FrmRunCardCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化
        Inite()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim lsSQL As String = String.Empty
        'Clear
        Me.lblMsg.Text = ""
        Me.lblMsg.Visible = True

        'Check
        If Me.txtNewPart.Text.Trim = "" Then
            Me.lblMsg.Text = "新料号不能为空 O_O"
            Exit Sub
        End If
        If Me.txtOldPart.Text.Trim = Me.txtNewPart.Text.Trim Then
            Me.lblMsg.Text = "新料号不可与旧料号相 O_O"
            Exit Sub
        End If

        'cq 20160722
        '当复制流程卡时，若里面存在同一个料号流程卡时，点击确定，提示“里面已有此版本的料号，是否替换”，
        '点击“确定”——替换，“取消”——不替换;且BOM下载要B料号的最新BOM
        If PnAlreadyExists() Then
            If MessageUtils.ShowConfirm("里面已有此版本的料号，是否替换?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                'do next
                lsSQL = RunCardBusiness.DeleteHeader(False, Me.txtNewPart.Text.Trim)

                RCardComBusiness.ExecSQL(lsSQL)
            Else
                Me.lblMsg.Text = "新料号流程卡已经存在"
                Exit Sub
            End If
            'Me.lblMsg.Text = "新料号流程卡已经存在"
            'Exit Sub
        End If

        If Not CheckVersionAndDownBOM(Me.txtOldPart.Text) Then
            Me.lblMsg.Text = Me.lblMsg.Text & ",检查版本失败!"
            Exit Sub
        End If

        'Add by cq 20161103
        If Not CheckExistOldVersion(Me.txtNewPart.Text.Trim) Then
            Exit Sub
        End If

        Try
            '参数定义
            Dim arrayList As New ArrayList

            arrayList.Add("OldPN|" & RCPartNumber)
            arrayList.Add("NewPN|" & Me.txtNewPart.Text.Trim)
            arrayList.Add("NewPNVersion|" & txtVersion.Text.Trim)
            arrayList.Add("UserID|" & SysMessageClass.UseId)

            RunCardBusiness.udpCopyRunCard(arrayList)

            MessageUtils.ShowInformation("复制成功！")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCopy", "btnOK_Click", "RCard")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region

#Region "方法"

    Private Sub Inite()
        Me.txtOldPart.Text = Me.RCPartNumber
        Me.txtOldPart.ReadOnly = True
        Me.txtNewPart.Focus()
        Me.lblMsg.Text = ""
        Me.lblMsg.Visible = False
    End Sub

    Private Function PnAlreadyExists() As Boolean
        Dim sql As String = "SELECT PartID FROM m_RCardM_t WHERE PartID='" & Me.txtNewPart.Text.Trim & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
        If dt.Rows.Count > 0 Then Return True
        Return False
    End Function

    Private Function CheckVersionAndDownBOM(ByVal parOldPN As String) As Boolean
        Dim txtErpVersion As String = ""

        Try
            If Me.txtVersion.Text = String.Empty Then
                Me.txtVersion.Focus()
                Me.lblMsg.Text = " 请输入版本号!"
                Return False
            End If

            'remove if, cq 20160722
            '防呆，能指出错误的New PN 在Erp 中不存在.
            'If RunCardBusiness.BomExists(Me.txtNewPart.Text.Trim) = False Then
            Dim msg As String = ""
            If DownloadBom(Me.txtNewPart.Text.Trim, msg, parOldPN) = False Then
                Me.lblMsg.Text = msg
                Return False
            End If
            'End If

            '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
            If Me.txtNewPart.Text.Trim.StartsWith("9") Then
                'Check Version
                txtErpVersion = RunCardBusiness.GetVerFromErp(Me.txtNewPart.Text)

                If Me.txtVersion.Text.Trim <> txtErpVersion Then
                    Me.lblMsg.Text = "版本不一致,Erp 版本为: " & txtErpVersion & " "
                    Me.txtVersion.Focus()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCopy", "CheckVersionAndDownBOM", "RCard")
            Throw ex
        End Try
    End Function


    Private Function CheckExistOldVersion(ByVal parNewPN As String) As Boolean
        Dim lsSQL As String = ""

        Try

            If RunCardBusiness.RCardExistInOldData(parNewPN, Me.txtVersion.Text) Then
                If MessageUtils.ShowConfirm("旧流程卡里面已有此版本的料号，是否替换?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    'do next
                    lsSQL = RunCardBusiness.DeleteOldRCard(parNewPN, Me.txtVersion.Text)
                    RCardComBusiness.ExecSQL(lsSQL)
                Else
                    Me.lblMsg.Text = "旧流程卡里面已经存在这个版本！！"
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCopy", "CheckExistOldVersion", "RCard")
            Throw ex
        End Try
    End Function

#Region "下载BOM"
    Private Function DownloadBom(ByVal pn As String, ByRef msg As String, ByVal parOldPN As String) As Boolean
        Dim strCustID As String = "", strSeriesID As String = ""
        Try
            Dim strSQL As String
            Dim dt As DataTable

            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                strSQL = SapCommon.GetErpFilterSqlSap(pn)
                dt = OracleOperateUtils.GetDataTableSap(strSQL)
            Else
                'A. First Download PN from ERP,Add by CQ 20151116
                strSQL = SapCommon.GetErpFilterSqlUnion(pn)
                dt = OracleOperateUtils.GetDataTable(strSQL)
            End If

            If dt.Rows.Count <= 0 Then
                msg = "ERP 中找不到料件""" & pn & """ 信息"
                Return False
            Else

                Call GetCustIDAndSeriesID(parOldPN, strCustID, strSeriesID)

                dt.Columns.Add("CustID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("CustID") = strCustID
                Next

                dt.Columns.Add("SeriesID", GetType(String))
                For Each dr As DataRow In dt.Rows()
                    dr.Item("SeriesID") = strSeriesID
                Next
                RunCardBusiness.SaveErpData(dt)
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCopy", "DownloadBom", "RCard")
            Throw ex
        End Try
    End Function

    Private Sub GetCustIDAndSeriesID(ByVal parOldPN As String, ByRef strCustID As String, ByRef strSeriesID As String)
        Dim sql As String = " SELECT  CusID, SeriesID FROM m_PartContrast_t WHERE TAvcPart='" & parOldPN & "'"
        Dim dt As DataTable = RCardComBusiness.GetDataTable(sql)
        If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
            strCustID = RCardComBusiness.DBNullToStr(dt.Rows(0).Item("CusID"))
            strSeriesID = RCardComBusiness.DBNullToStr(dt.Rows(0).Item("SeriesID"))
        End If
    End Sub
#End Region
#End Region

End Class