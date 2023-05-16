Public Class outScanOption


#Region "基本變量"


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
    Shared CheckString As Boolean ''確定編輯標識
    Shared Partid As String
    Shared Snid As String
    Shared ErrorString As String

    Shared m_PartPackQty As String    ''箱裝數量 歐翔烽 2007 01 29
    Shared m_PrintPort As String
    Shared m_PackNumber As String   ''外箱編號

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
    Shared m_PalletNo As String
    Shared m_LastPalletCheck As Boolean
    Shared m_CurrentPalletCartonIndex As Integer ''箱在棧板上的順序號
    Shared m_CurrentPalletCartonCount As Integer ''棧應裝箱數
    Shared m_PalletMultQty As String() ''箱裝數量順序

    Shared m_NormalPalletCartonCount As Integer ''棧應裝箱數
    Shared m_NormalPalletMultQty As String() ''箱裝數
    Shared m_LastPalletMultQty As String()
    Shared m_CartonSitNo As String
    Shared m_StandIndex As String
    Shared m_IsLastPallet As Boolean
    Shared m_MultQtyStr As String
    Shared m_NoFullFlag As Boolean
    Shared m_CartonSitName As String
    Shared m_IsPalletStyle As Boolean
    Shared m_InCartonScanCheck As Boolean

    Shared m_moType As String ''重工工單是否更換條碼 歐翔烽  2008/04/01

#End Region

    Public Shared Property InCartonScanCheck() As Boolean

        Get
            Return m_InCartonScanCheck
        End Get
        Set(ByVal Value As Boolean)
            m_InCartonScanCheck = Value
        End Set

    End Property


    Public Shared Property moType() As String ''重工工單是否更換條碼 歐翔烽 2008/04/01

        Get
            Return m_moType
        End Get
        Set(ByVal Value As String)
            m_moType = Value
        End Set

    End Property

    Public Shared Property vIsPalletStyle() As Boolean

        Get
            Return m_IsPalletStyle
        End Get
        Set(ByVal Value As Boolean)
            m_IsPalletStyle = Value
        End Set

    End Property

    Public Shared Property vCartonSitName() As String

        Get
            Return m_CartonSitName
        End Get
        Set(ByVal Value As String)
            m_CartonSitName = Value
        End Set

    End Property


    Public Shared Property vNoFullFlag() As Boolean

        Get
            Return m_NoFullFlag
        End Get
        Set(ByVal Value As Boolean)
            m_NoFullFlag = Value
        End Set

    End Property


    Public Shared Property vMultQtyStr() As String

        Get
            Return m_MultQtyStr
        End Get
        Set(ByVal Value As String)
            m_MultQtyStr = Value
        End Set

    End Property


    Public Shared Property vCartonSitNo() As String

        Get
            Return m_CartonSitNo
        End Get
        Set(ByVal Value As String)
            m_CartonSitNo = Value
        End Set

    End Property

    Public Shared Property vStandIndex() As String

        Get
            Return m_StandIndex
        End Get
        Set(ByVal Value As String)
            m_StandIndex = Value
        End Set

    End Property

    Public Shared Property vIsLastPallet() As Boolean

        Get
            Return m_IsLastPallet
        End Get
        Set(ByVal Value As Boolean)
            m_IsLastPallet = Value
        End Set

    End Property


    Public Shared Property vLastPalletMultQty() As String()

        Get
            Return m_LastPalletMultQty
        End Get
        Set(ByVal Value As String())
            m_LastPalletMultQty = Value
        End Set

    End Property


    Public Shared Property vNormalPalletMultQty() As String()

        Get
            Return m_NormalPalletMultQty
        End Get
        Set(ByVal Value As String())
            m_NormalPalletMultQty = Value
        End Set

    End Property

    Public Shared Property vNormalPalletCartonCount() As Integer

        Get
            Return m_NormalPalletCartonCount
        End Get
        Set(ByVal Value As Integer)
            m_NormalPalletCartonCount = Value
        End Set

    End Property


    Public Shared Property vPalletMultQty() As String()

        Get
            Return m_PalletMultQty
        End Get
        Set(ByVal Value As String())
            m_PalletMultQty = Value
        End Set

    End Property

    Public Shared Property vCurrentPalletCartonCount() As Integer

        Get
            Return m_CurrentPalletCartonCount
        End Get
        Set(ByVal Value As Integer)
            m_CurrentPalletCartonCount = Value
        End Set

    End Property

    Public Shared Property vCurrentPalletCartonIndex() As Integer

        Get
            Return m_CurrentPalletCartonIndex
        End Get
        Set(ByVal Value As Integer)
            m_CurrentPalletCartonIndex = Value
        End Set

    End Property


    Public Shared Property vLastPalletCheck() As Boolean

        Get
            Return m_LastPalletCheck
        End Get
        Set(ByVal Value As Boolean)
            m_LastPalletCheck = Value
        End Set

    End Property

    Public Shared Property vPalletNo() As String

        Get
            Return m_PalletNo
        End Get
        Set(ByVal Value As String)
            m_PalletNo = Value
        End Set

    End Property


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
    ''2007/06/13  歐翔烽'''''''''''''''

    Public Shared Property LastPrintQty() As String

        Get
            Return m_LastPrintQty
        End Get
        Set(ByVal Value As String)
            m_LastPrintQty = Value
        End Set

    End Property
    ''2007/06/13 歐翔烽'''''''''''''''

    Public Shared Property CustIdString() As String

        Get
            Return m_CustIdString
        End Get
        Set(ByVal Value As String)
            m_CustIdString = Value
        End Set

    End Property
    ''2007/05/14  歐翔烽'''''''''''''''

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

    Public Shared Property IsExitFlag() As Boolean   ''歐翔烽 2007 05 8

        Get
            Return m_IsExitFlag
        End Get
        Set(ByVal Value As Boolean)
            m_IsExitFlag = Value
        End Set

    End Property

    Public Shared Property BcRuleid() As String  ''歐翔烽 2007 03 14

        Get
            Return m_BcRuleid
        End Get
        Set(ByVal Value As String)
            m_BcRuleid = Value
        End Set

    End Property
    Public Shared Property FormName() As String  ''歐翔烽 2007 03 14

        Get
            Return m_FormName
        End Get
        Set(ByVal Value As String)
            m_FormName = Value
        End Set

    End Property

    Public Shared Property DpetId() As String  ''歐翔烽 2007 03 14

        Get
            Return m_DpetId
        End Get
        Set(ByVal Value As String)
            m_DpetId = Value
        End Set

    End Property

    Public Shared Property PartPackQty() As String   ''歐翔烽 2007 01 29

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

    ''歐翔烽 2007 01 29

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