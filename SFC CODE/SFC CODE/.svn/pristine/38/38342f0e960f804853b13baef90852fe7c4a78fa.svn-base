Imports System.Windows.Forms
Imports MainFrame
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls

''' <summary>
''' 修改者： 黄广都
''' 修改日： 2017/12/14
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>编码原则流水转换器</remarks>
Public Class FrmConvetCodeRule
    Dim LoadM As New BarCodePrint.SqlClassM
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim i As Int64 = -1
        If String.IsNullOrEmpty(Me.txtCodeRuleId.Text) Then
            Me.lbResult.Text = "请输入编码原则!"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtNumberNo.Text) Then
            Me.lbResult.Text = "请输入流水码!"
            Exit Sub
        End If
        i = LoadM.CodeToInt(Me.txtNumberNo.Text.Trim, Me.txtCodeRuleId.Text.Trim)
        If i > 0 Then
            Me.txtResult.Text = LoadM.CodeToInt(Me.txtNumberNo.Text.Trim, Me.txtCodeRuleId.Text.Trim)
        Else
            Me.lbResult.Text = "请正确输入数值，计算失败!"
        End If
        
    End Sub
End Class