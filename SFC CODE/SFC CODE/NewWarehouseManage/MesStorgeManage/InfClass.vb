Public Class InfClass
    Shared m_StrInf As String
    Shared m_StrQustionInf As String
    Shared m_StrColor As Color
    Shared m_StrQColor As Color
    Shared m_StrSize As Integer
    Shared m_StrQSize As Integer
    Shared m_ChoseY As Boolean



#Region "信息內容"
    Public Property StrInf()
        Get
            Return m_StrInf
        End Get
        Set(ByVal value)
            m_StrInf = value
        End Set
    End Property
#End Region

#Region "問題內容"
    Public Property StrQInf()
        Get
            Return m_StrQustionInf
        End Get
        Set(ByVal value)
            m_StrQustionInf = value
        End Set
    End Property
#End Region

#Region "信息字體顏色"
    Public Property StrColor() As Color
        Get
            Return m_StrColor
        End Get
        Set(ByVal value As Color)
            m_StrColor = value
        End Set
    End Property
#End Region

#Region "問題字體顏色"
    Public Property StrQColor()
        Get
            Return m_StrQColor
        End Get
        Set(ByVal value)
            m_StrQColor = value
        End Set
    End Property
#End Region

#Region "信息字體大小"
    Public Property StrSize()
        Get
            Return m_StrSize
        End Get
        Set(ByVal value)
            m_StrSize = value
        End Set
    End Property
#End Region

#Region "問題字體大小"
    Public Property StrQSize()
        Get
            Return m_StrQSize
        End Get
        Set(ByVal value)
            m_StrQSize = value
        End Set
    End Property
#End Region

#Region "確認與否"
    Public Property ChoseY() As Boolean
        Get
            Return m_ChoseY
        End Get
        Set(ByVal value As Boolean)
            m_ChoseY = value
        End Set
    End Property
#End Region


End Class
