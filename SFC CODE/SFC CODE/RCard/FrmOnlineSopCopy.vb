Option Explicit On
Option Strict On
Imports System.IO
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Aspose.Cells
Imports System.Text
Imports MainFrame
Imports SysBasicClass
Public Class FrmOnlineSopCopy
#Region "构造函数"
    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <param name="copyDocId">被复制文件编码</param>
    ''' <param name="copySopName">被复制SOP名称</param>
    ''' <param name="copyVersion">被复制版本</param>
    ''' <param name="copyShape">被复制形态</param>
    ''' <remarks></remarks>
    Sub New(ByVal copyDocId As String, ByVal copySopName As String, ByVal copyVersion As String, ByVal copyShape As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.txtCopyDocId.Text = copyDocId
        Me.txtCopySopName.Text = copySopName
        Me.txtCopyVersion.Text = copyVersion
        Me.txtCopyShape.Text = copyShape
        Me.txtShape.Text = copyShape
        Me.txtVersion.Text = "X1"
    End Sub
#End Region
#Region "事件"
    Private Sub FrmOnlineSopCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        DIM o_strErrMsg As String =""
        Try

            If (MessageUtils.ShowConfirm("确定要复制SOP吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                If InputCheck() = True Then
                    If CopySopData(o_strErrMsg) = True Then
                        '提示
                        MessageUtils.ShowInformation("复制成功！")
                        '退出
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        lbMsg.Text = "复制失败! " + o_strErrMsg
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopCopy", "btnOK_Click", "sys")
        End Try

    End Sub



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region
#Region "方法"
    ''' <summary>
    ''' 检查输入项
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheck() As Boolean
        Dim r As Boolean = True
        If String.IsNullOrEmpty(Me.txtSopName.Text.Trim) Then
            Me.lbMsg.Text = "请输入SOP名称!"
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtVersion.Text.Trim) Then
            Me.lbMsg.Text = "请输入版本!"
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtShape.Text.Trim) Then
            Me.lbMsg.Text = "请输入形态!"
            Return False
        End If
        If txtCopySopName.Text.Trim() = txtSopName.Text.Trim() Then 'add by马跃平 2018-08-21
            Me.lbMsg.Text = "新旧SOP名称不能相同!"
            Return False
        End If

        Return r
    End Function


    ''' <summary>
    ''' 复制SOP数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CopySopData(ByRef strErr As String) As Boolean
        Try
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim Falg As Integer = 0
            Dim Msg As String = String.Empty
            '插入数据明细表
            Dim para(6) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@CopyDocId", SqlDbType.VarChar, 50),
                New SqlParameter("@SopName", SqlDbType.NVarChar, 100),
                New SqlParameter("@Version", SqlDbType.NVarChar, 50),
                New SqlParameter("@Shape", SqlDbType.NVarChar, 50),
                New SqlParameter("@UserId", SqlDbType.NVarChar, 50),
                New SqlParameter("@Msg", SqlDbType.NVarChar, 100),
                New SqlParameter("@Falg", SqlDbType.Int, 20)
            }
            parameters(0).Value = Me.txtCopyDocId.Text.Trim
            parameters(1).Value = Me.txtSopName.Text.Trim
            parameters(2).Value = Me.txtVersion.Text.Trim
            parameters(3).Value = Me.txtShape.Text.Trim
            parameters(4).Value = UserID

            parameters(5).Value = Msg
            parameters(5).Direction = ParameterDirection.Output
            parameters(6).Value = Falg
            parameters(6).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopCopyData", parameters)
            If parameters(6).Value.ToString = "0" Then
                'MessageUtils.ShowError(parameters(5).Value.ToString)
                strErr = CStr(IIf(IsDBNull(parameters(5).Value), "", parameters(5).Value.ToString()))
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopCopy", "CopySopData()", "sys")
        End Try
        Return True
    End Function

#End Region

End Class