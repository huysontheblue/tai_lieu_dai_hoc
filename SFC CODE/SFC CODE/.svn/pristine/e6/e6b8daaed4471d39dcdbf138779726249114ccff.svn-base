Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text
Imports MainFrame
Imports SysBasicClass
''' <summary>
''' 修改者： 黄广都
''' 修改日： 2017/02/09
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>选择责任人</remarks>
Public Class FrmSelectPIC

#Region "事件"
    Private Sub FrmSelectPIC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDutyUser()
        Me.txtCondition.Focus()
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        LoadDutyUser()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region
#Region "方法"
    Private Sub LoadDutyUser()
         Try
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim o_strSql As New StringBuilder
            '查询料件资料
            o_strSql.Append(" SELECT distinct  DutyUserName,DutyUserID,DutyDeptName,DutyEmail FROM m_SamplePic_t where UseY='Y' ")

            If Not String.IsNullOrEmpty(Me.txtCondition.Text.Trim) Then
                o_strSql.Append(String.Format(" and DutyUserName like N'%{0}%' or DutyUserID like '%{0}%' or DutyDeptName like '%{0}%' ", txtCondition.Text.Trim))
            End If
            Dim dt As DataTable = DAL.GetDataTable(o_strSql.ToString())

            Me.dgvPIC.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSelectPIC", "LoadDutyUser()", "sys")
        End Try
    End Sub
#End Region
End Class