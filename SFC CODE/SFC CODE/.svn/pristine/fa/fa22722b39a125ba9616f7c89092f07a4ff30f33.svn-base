Imports System.Collections.Generic
Imports System.Text

Namespace Jiami_and_Jiemi
    Class JiaMiJieMi
        Private cachebyte As Byte()
        Public Inputstring As String = ""

        Public Sub New()
        End Sub
        Public Sub New(ByVal input As String)
            Inputstring = input
        End Sub
        Private Sub ZhuanHuan(ByVal jm As Boolean)
            For i As Integer = 0 To cachebyte.Length - 1
                If jm Then
                    cachebyte(i) = JiaMi(cachebyte(i))
                Else
                    cachebyte(i) = JieMi(cachebyte(i))
                End If
            Next
        End Sub
        Private Function JiaMi(ByVal b As Byte) As Byte
            Return CByte(b + 255)
        End Function
        Private Function JieMi(ByVal b As Byte) As Byte
            Return CByte(b - 255)
        End Function
        Public Function jiamiout(ByVal input As String) As String
            cachebyte = System.Text.Encoding.[Default].GetBytes(input)
            ZhuanHuan(True)
            Return System.Text.Encoding.[Default].GetString(cachebyte)
        End Function
        Public Function jiamiout() As String
            If Inputstring = "" Then
                Return "Nothing!"
            End If
            cachebyte = System.Text.Encoding.[Default].GetBytes(Inputstring)
            ZhuanHuan(True)
            Return System.Text.Encoding.[Default].GetString(cachebyte)
        End Function
        Public Function jiemiout(ByVal input As String) As String
            cachebyte = System.Text.Encoding.[Default].GetBytes(input)
            ZhuanHuan(False)
            Return System.Text.Encoding.[Default].GetString(cachebyte)
        End Function
        Public Function jiemiout() As String
            If Inputstring = "" Then
                Return "Nothing!"
            End If
            cachebyte = System.Text.Encoding.[Default].GetBytes(Inputstring)
            ZhuanHuan(False)
            Return System.Text.Encoding.[Default].GetString(cachebyte)
        End Function
    End Class
End Namespace