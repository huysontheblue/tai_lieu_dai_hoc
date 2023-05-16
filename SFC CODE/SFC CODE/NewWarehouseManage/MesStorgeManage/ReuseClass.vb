Public Class ReuseClass

    Shared m_ReUseLock As Boolean
    Shared m_OutWhid As String
    Shared m_StrInvoice As String

    Public Shared Property ReUseLock() As Boolean

        Get
            Return m_ReUseLock
        End Get
        Set(ByVal Value As Boolean)
            m_ReUseLock = Value
        End Set

    End Property

    Public Shared Property OutWhid() As String

        Get
            Return m_OutWhid
        End Get
        Set(ByVal Value As String)
            m_OutWhid = Value
        End Set

    End Property

    Public Shared Property StrInvos()
        Get
            Return m_StrInvoice
        End Get
        Set(ByVal value)
            m_StrInvoice = value
        End Set
    End Property


End Class
