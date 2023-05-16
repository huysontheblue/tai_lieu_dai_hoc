Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports MainFrame.SysCheckData
Imports MainFrame
Public Class Frmimag

    Private _PicDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\QCCheckFile\" & VbCommClass.VbCommClass.Factory
    Private picPath As String = Nothing
    Public cId As String
    Dim bmp As Bitmap = Nothing
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UploadNgPicture() = True Then
            MessageUtils.ShowInformation("上传成功!")
            Label2.Text = picPath
        Else
            MessageUtils.ShowError("上传失败,请检查!")
        End If
    End Sub

    Private Function UploadNgPicture() As Boolean
        Try
            Dim picFileName As String

            '图片目录
            Dim picDirector As String = String.Empty
            Dim picUpPath As String = String.Empty
            Dim openDlg As OpenFileDialog = New OpenFileDialog()
            openDlg.InitialDirectory = "."
            openDlg.Filter = "JPG File(*.jpg)|*.jpg|JPEG File(*.jpeg)|*.jpeg|PNG File(*.png)|*.png|BMP File(*.bmp)|*.bmp"
            openDlg.RestoreDirectory = True
            openDlg.FileName = "sourcePic"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                picPath = openDlg.FileName
                If (Not picPath Is Nothing AndAlso System.IO.File.Exists(picPath)) Then
                    bmp = Image.FromFile(picPath)
                    If Not bmp Is Nothing Then
                        picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                        picDirector = _PicDirector & "\" & cId
                        If System.IO.Directory.Exists(picDirector) = False Then
                            Directory.CreateDirectory(picDirector)
                        End If
                        picPath = picDirector & "\" & picFileName

                        bmp.Save(picPath)
                    End If
                    bmp.Dispose()
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return True
    End Function



    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Label2.Text.Trim = "" Then
            MessageBox.Show("请选择上传的附件")
            Return
        End If
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("请输入备注")
            Return
        End If
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "INSERT INTO m_QC_PICTURE_t (CId,Remark,imag,userid,inTime) VALUES (N'" + cId + "',N'" + TextBox1.Text.Trim + "',N'" + Label2.Text.Trim + "',N'" + VbCommClass.VbCommClass.UseId + "',getdate())"
        dt = DbOperateUtils.GetDataTable(strSQL)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class