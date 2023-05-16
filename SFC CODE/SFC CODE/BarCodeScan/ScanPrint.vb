Public Class ScanPrint

#Region "°ò¥»ÅÜ¶q"


    Shared LMoid As String
    Shared LMoidqty As String
    Shared custname As String

    Shared LMoCust As String
    Shared LDpetName As String
    Shared LLine As String
    Shared LLength As String
    Shared LTime As String
    Shared SnStyle1 As String
    Shared SnStyle2 As String
    Shared Gflen As String
    Shared BarCode As String
    Shared CheckString As Boolean ''½T©w½s¿è¼ÐÃÑ
    Shared Partid As String
    Shared Snid As String
    Shared ErrorString As String

    Shared m_PartPackQty As String    ''½c¸Ë¼Æ¶q ¼Úµ¾²l 2007 01 29
    Shared m_PrintPort As String
    Shared m_PackNumber As String   ''¥~½c½s¸¹

    Shared m_DpetId As String
    Shared m_FormName As String
    Shared m_ShowStyle As Int32
    Shared m_BcRuleid As String
    Shared m_IsExitFlag As Boolean
    Shared m_ReplaceQty As String
    Shared m_ReplaceMo As String
    Shared m_CustIdString As String
    Shared m_LastPrintQty As String
    Shared m_MoTotalScanQty As Integer
    'Shared m_MoTotalCarton As Integer
    Shared m_NowScanQty As Integer
    Shared m_NowCartonScanQty As Integer
    Shared m_ReplacePrint As Boolean
    Shared m_LastPrint As Boolean
    Shared m_isCheck As Boolean
    Shared m_isPass As Boolean
#End Region

    Public Shared Property vIsCheck() As Boolean

        Get
            Return m_isCheck
        End Get
        Set(ByVal Value As Boolean)
            m_isCheck = Value
        End Set

    End Property

    Public Shared Property vIsPass() As Boolean

        Get
            Return m_isPass
        End Get
        Set(ByVal Value As Boolean)
            m_isPass = Value
        End Set

    End Property


    Public Shared Property ReplacePrintCheck() As Boolean

        Get
            Return m_ReplacePrint
        End Get
        Set(ByVal Value As Boolean)
            m_ReplacePrint = Value
        End Set

    End Property

    Public Shared Property LastPrintCheck() As Boolean

        Get
            Return m_LastPrint
        End Get
        Set(ByVal Value As Boolean)
            m_LastPrint = Value
        End Set

    End Property

    ''2007/06/15  ruqiu'''''''''''''''

    Public Shared Property NowCartonScanQty() As Integer

        Get
            Return m_NowCartonScanQty
        End Get
        Set(ByVal Value As Integer)
            m_NowCartonScanQty = Value
        End Set

    End Property
    ''2007/06/15  ruqiu'''''''''''''''

    Public Shared Property NowScanQty() As Integer

        Get
            Return m_NowScanQty
        End Get
        Set(ByVal Value As Integer)
            m_NowScanQty = Value
        End Set

    End Property
    ' ''2007/06/15  ruqiu'''''''''''''''

    'Public Shared Property MoTotalCarton() As Integer

    '    Get
    '        Return m_MoTotalCarton
    '    End Get
    '    Set(ByVal Value As Integer)
    '        m_MoTotalCarton = Value
    '    End Set

    'End Property
    ''2007/06/15  ruqiu'''''''''''''''

    Public Shared Property MoTotalScanQty() As Integer

        Get
            Return m_MoTotalScanQty
        End Get
        Set(ByVal Value As Integer)
            m_MoTotalScanQty = Value
        End Set

    End Property
    ''2007/06/13  ¼Úµ¾²l'''''''''''''''

    Public Shared Property LastPrintQty() As String

        Get
            Return m_LastPrintQty
        End Get
        Set(ByVal Value As String)
            m_LastPrintQty = Value
        End Set

    End Property
    ''2007/06/13 ¼Úµ¾²l'''''''''''''''

    Public Shared Property CustIdString() As String

        Get
            Return m_CustIdString
        End Get
        Set(ByVal Value As String)
            m_CustIdString = Value
        End Set

    End Property
    ''2007/05/14  ¼Úµ¾²l'''''''''''''''

    Public Shared Property vReplaceMo() As String

        Get
            Return m_ReplaceMo
        End Get
        Set(ByVal Value As String)
            m_ReplaceMo = Value
        End Set

    End Property

    Public Shared Property vReplaceQty() As String

        Get
            Return m_ReplaceQty
        End Get
        Set(ByVal Value As String)
            m_ReplaceQty = Value
        End Set

    End Property

    ''2007/05/14''''''''''''''''''''''''''''

    Public Shared Property IsExitFlag() As Boolean   ''¼Úµ¾²l 2007 05 8

        Get
            Return m_IsExitFlag
        End Get
        Set(ByVal Value As Boolean)
            m_IsExitFlag = Value
        End Set

    End Property

    Public Shared Property BcRuleid() As String  ''¼Úµ¾²l 2007 03 14

        Get
            Return m_BcRuleid
        End Get
        Set(ByVal Value As String)
            m_BcRuleid = Value
        End Set

    End Property
    Public Shared Property FormName() As String  ''¼Úµ¾²l 2007 03 14

        Get
            Return m_FormName
        End Get
        Set(ByVal Value As String)
            m_FormName = Value
        End Set

    End Property

    Public Shared Property DpetId() As String  ''¼Úµ¾²l 2007 03 14

        Get
            Return m_DpetId
        End Get
        Set(ByVal Value As String)
            m_DpetId = Value
        End Set

    End Property

    Public Shared Property PartPackQty() As String   ''¼Úµ¾²l 2007 01 29

        Get
            Return m_PartPackQty
        End Get
        Set(ByVal Value As String)
            m_PartPackQty = Value
        End Set

    End Property

    Public Shared Property PackNumber() As String

        Get
            Return m_PackNumber
        End Get
        Set(ByVal Value As String)
            m_PackNumber = Value
        End Set

    End Property

    Public Shared Property PrintPort() As String

        Get
            Return m_PrintPort
        End Get
        Set(ByVal Value As String)
            m_PrintPort = Value
        End Set

    End Property

    ''¼Úµ¾²l 2007 01 29

    Public Shared Property MoidStr() As String
        Get
            Return LMoid
        End Get
        Set(ByVal Value As String)
            LMoid = Value
        End Set
    End Property

    Public Shared Property MoidqtyStr() As String
        Get
            Return LMoidqty
        End Get
        Set(ByVal Value As String)
            LMoidqty = Value
        End Set
    End Property

    Public Shared Property CustStr() As String
        Get
            Return custname
        End Get
        Set(ByVal Value As String)
            custname = Value
        End Set
    End Property

    Public Shared Property MoCustStr() As String
        Get
            Return LMoCust
        End Get
        Set(ByVal Value As String)
            LMoCust = Value
        End Set
    End Property

    Public Shared Property DpetNameStr() As String
        Get
            Return LDpetName
        End Get
        Set(ByVal Value As String)
            LDpetName = Value
        End Set
    End Property

    Public Shared Property LineStr() As String
        Get
            Return LLine
        End Get
        Set(ByVal Value As String)
            LLine = Value
        End Set
    End Property

    Public Shared Property LengthStr() As String
        Get
            Return LLength
        End Get
        Set(ByVal Value As String)
            LLength = Value
        End Set
    End Property

    Public Shared Property TimeStr() As String
        Get
            Return LTime
        End Get
        Set(ByVal Value As String)
            LTime = Value
        End Set
    End Property

    Public Shared Property CheckStr() As Boolean
        Get
            Return CheckString
        End Get
        Set(ByVal Value As Boolean)
            CheckString = Value
        End Set
    End Property

    Public Shared Property PartidStr() As String
        Get
            Return Partid
        End Get
        Set(ByVal Value As String)
            Partid = Value
        End Set
    End Property

    Public Shared Property SnidStr() As String
        Get
            Return Snid
        End Get
        Set(ByVal Value As String)
            Snid = Value
        End Set
    End Property

    Public Shared Property ErrorStr() As String
        Get
            Return ErrorString
        End Get
        Set(ByVal Value As String)
            ErrorString = Value
        End Set
    End Property

    Public Shared Property SnStyleStr1() As String
        Get
            Return SnStyle1
        End Get
        Set(ByVal Value As String)
            SnStyle1 = Value
        End Set
    End Property

    Public Shared Property SnStyleStr2() As String
        Get
            Return SnStyle2
        End Get
        Set(ByVal Value As String)
            SnStyle2 = Value
        End Set
    End Property

    Public Shared Property GflenStr() As String
        Get
            Return Gflen
        End Get
        Set(ByVal Value As String)
            Gflen = Value
        End Set
    End Property
    Public Shared Property BarCodeStr() As String
        Get
            Return BarCode
        End Get
        Set(ByVal Value As String)
            BarCode = Value
        End Set
    End Property

    Public Shared Property ShowStyle() As Int32
        Get
            Return m_ShowStyle
        End Get
        Set(ByVal Value As Int32)
            m_ShowStyle = Value
        End Set
    End Property

End Class
