Imports System.Text.RegularExpressions

Public Class CheckUtils

    Private Shared ReadOnly HalfWidthNumberPattern As Regex = New Regex("^[0-9]+$")

    Public Shared Function HalfWidthNumChecker(target As String) As Boolean
        Dim result As Boolean = False

        If target <> "" Then
            result = HalfWidthNumberPattern.IsMatch(target)
        End If

        HalfWidthNumChecker = result
    End Function

End Class
