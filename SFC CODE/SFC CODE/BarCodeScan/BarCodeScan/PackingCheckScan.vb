

Public Class PackingCheckScan
    Dim m_MoId As String
    Dim m_PartId As String
    Dim m_LineId As String
    Dim m_NumberDdivisions As String
    Dim m_AffiliatedBarCode As String

    Public Property MoId() As String

        Get
            Return m_MoId
        End Get
        Set(ByVal Value As String)
            m_MoId = Value
        End Set

    End Property

    Public Property PartId() As String

        Get
            Return m_PartId
        End Get
        Set(ByVal Value As String)
            m_PartId = Value
        End Set

    End Property

    Public Property LineId() As String

        Get
            Return m_LineId
        End Get
        Set(ByVal Value As String)
            m_LineId = Value
        End Set

    End Property

    Public Property NumberDdivisions() As String

        Get
            Return m_NumberDdivisions
        End Get
        Set(ByVal Value As String)
            m_NumberDdivisions = Value
        End Set

    End Property

    Public Property AffiliatedBarCode() As String

        Get
            Return m_AffiliatedBarCode
        End Get
        Set(ByVal Value As String)
            m_AffiliatedBarCode = Value
        End Set

    End Property

End Class



