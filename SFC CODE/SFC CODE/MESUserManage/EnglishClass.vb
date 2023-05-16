Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame

Public Class EnglishClass
    Public Sub LoadObjectAttributes(ByVal ParentControl As Control, ByVal ControlName As String, ByVal ControlText As String)

        Dim MyControl As Control

        For Each MyControl In ParentControl.Controls

            If UCase(MyControl.Name).Trim = UCase(ControlName).ToString Then
                MyControl.Text = ControlText
                Exit For
            End If
            If TypeOf MyControl Is ToolStrip Then
                Dim TempControl As ToolStrip
                TempControl = MyControl
                Dim FormStripButton As ToolStripItem
                For Each FormStripButton In TempControl.Items
                    If TypeOf FormStripButton Is System.Windows.Forms.ToolStripButton Then
                        If UCase(FormStripButton.Name) = UCase(ControlName).ToString Then
                            FormStripButton.ToolTipText = ControlText
                            Exit For
                        End If
                    End If
                Next
            End If
            If MyControl.HasChildren Then
                LoadObjectAttributes(MyControl, ControlName, ControlText)
            End If
        Next

    End Sub

    Public Sub GetETextRd(ByVal FromName As Form)
        Dim Cnn As New SqlClient.SqlConnection
        Dim Cmd As New SqlClient.SqlCommand
        Dim LoadReader As SqlDataReader
        Dim SqlBuilderString As New StringBuilder

        Cnn.ConnectionString = "data source=pc-398; initial catalog=MESDB; user id=TESTER; password=123"
        Cmd.Connection = Cnn
        Cnn.Open()
        SqlBuilderString.Append("select * from m_SysapObj_t where apid in (")
        SqlBuilderString.Append("select apid from m_SysapForm_t where apFormid='" & FromName.Name & "')")
         Try
            Cmd.CommandText = SqlBuilderString.ToString
            LoadReader = Cmd.ExecuteReader()
            While LoadReader.Read()
                LoadObjectAttributes(FromName, LoadReader("apObjid"), LoadReader("enname"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "´£¥Ü«H®§")
      
        End Try

        Cnn.Close()
        SqlBuilderString = Nothing

    End Sub
End Class
