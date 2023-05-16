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

    Public Function HalfWidthDecimalChecker(s As String, precision As String, scale As String) As Boolean
        If ((precision = 0) AndAlso (scale = 0)) Then
            Return False
        End If
        Dim pattern As String = "(^\d{1," + precision + "}"
        If (scale > 0) Then
            pattern = pattern + "\.\d{0," + scale + "}$)|" + pattern
        End If
        pattern = pattern + "$)"

        Return Regex.IsMatch(s, pattern)
    End Function

End Class
