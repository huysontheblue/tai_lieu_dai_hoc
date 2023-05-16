Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Data
Public Class JsonClass
    Public Shared Function ToJson(ByVal Json As String) As Object
        If Json Is Nothing Then
            Return Nothing
        Else
            Return JsonConvert.DeserializeObject(Json)
        End If
    End Function
    Public Shared Function ToTable(ByVal Json As String) As Object
        If Json Is Nothing Then
            Return Nothing
        Else
            Return CType(JsonConvert.DeserializeObject(Json, GetType(DataTable)), DataTable)
        End If
    End Function
End Class
