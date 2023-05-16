Public Class FrmDocLook
    Public m_strFileName As String = String.Empty

    Private Sub FrmDocLooke_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If m_strFileName.ToUpper.Contains("PDF") Then
                Me.TabPage1.Parent = Me.TabControl1
                Me.TabPage2.Parent = Me.TabControl1
                Me.TabPage2.Parent = Nothing
                Call LookPdf()
            Else
                Me.TabPage1.Parent = Me.TabControl1
                Me.TabPage2.Parent = Me.TabControl1
                Me.TabPage1.Parent = Nothing
                Call LookOffice()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LookPdf()
        '  AxAcroPDF1.LoadFile(m_strFileName)
        ' Me.AxFramerControl1.Open(m_strFileName)
    End Sub

    Private Sub LookOffice()
        ' Me.AxFramerControl1.Open(m_strFileName)
    End Sub

    Private Sub FrmDocLook_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            'If Not IsNothing(AxFramerControl1) Then
            '    AxFramerControl1.Dispose()
            'End If

            'If Not IsNothing(AxAcroPDF1) Then
            '    AxAcroPDF1.Dispose()
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class