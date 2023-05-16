Public Class ListItem

    Private _id As String = String.Empty
    Private _name As String = String.Empty
    Private _Tag As String = String.Empty
    Private _stationId As String = String.Empty

    Sub New(sid As String, sname As String)
        ' TODO: Complete member initialization 
        _id = sid
        _name = sname
    End Sub

    Sub New(sid As String, sname As String, tag As String, staionid As String)
        ' TODO: Complete member initialization 
        _id = sid
        _name = sname
        _Tag = tag
        _stationId = staionid
    End Sub

    Public Overrides Function ToString() As String
        Return _name
    End Function

    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Tag() As String
        Get
            Return _Tag
        End Get
        Set(ByVal value As String)
            _Tag = value
        End Set
    End Property

    Public Property StationId() As String
        Get
            Return _stationId
        End Get
        Set(ByVal value As String)
            _stationId = value
        End Set
    End Property
End Class
