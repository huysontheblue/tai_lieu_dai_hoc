Imports BasicFind.FrmShowPictureDetail
Imports com.luxshare_ict.plm
Partial Public Class PLMpic
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnok.Click


        Try

            If Not CheckBasic() Then
                Exit Sub

            End If

            Dim PN As String = txtPn.Text.Trim
            Dim uid As String = "C041987"
            Dim plm As New com.luxshare_ict.plm.WebService1
            '找到料号、類別, 文件號, 文件名稱, 版本, 版次, 權限
            Dim DT As DataTable = plm.GetPLMClassification(uid, PN)
            Dim sb As String = String.Empty '得到一列值

            For Each row As DataRow In DT.Rows
                For Each column As DataColumn In DT.Columns
                    sb += row(column).ToString() + ","

                Next
            Next

            ' sb=   //蓝图/科尔通  ,CAD14-0000002874  ,904091408-蓝图  ,X  ,1  ,Released  ,1  ,Y  ,
            Dim pnkey As String = sb.Split(",")(1).ToString '找到文件编号

            Dim p() As String = {pnkey}

            '用文件編號+密碼, 取得ID號, 文件編碼, URL (加密, 兩個URL中間要加分號) 

            Dim DT2 As DataTable = plm.GetPLMData(p, "n/K67oxui8q8TFMwoAQKng==")
            Dim sb1 As String = String.Empty

            For Each row As DataRow In DT2.Rows
                For Each column As DataColumn In DT2.Columns
                    sb1 += row(column).ToString() + ","

                Next
            Next

            '开始嵌入HTML

            '  WebBrowser1.Url = ""
            Response.Redirect("DisplayPic.aspx?sb1=" + sb1)
            Dim s As String = String.Empty

        Catch ex As Exception

        End Try
    End Sub
    Public Function CheckBasic() As Boolean
        If txtPn.Text = "" Then
            Response.Write("请输入料件编号, 提示信息")
            Return False
        End If
        'If cboReportType.SelectedItem = "" Then
        '    MessageBox.Show("请选择报表类型", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return False
        'End If
        Return True
    End Function

End Class