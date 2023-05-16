
'--工站扫描设置
'--Create by :　cq
'--Create date :　2016/11/07
'--Update date :  
'--Ver : V01

Public Class SampleScanSetting

#Region "Members"
    Dim LMoid As String
    Dim LMoidqty As String
    Dim custname As String
    Dim LMoCust As String
    Dim LDpetName As String
    Dim LLine As String
    Dim LLength As String
    Dim LTime As String
    Dim SnStyle1 As String
    Dim SnStyle2 As String
    Dim Gflen As String
    Dim BarCode As String
    Dim CheckString As Boolean ''確定編輯標識
    Dim Partid As String
    Dim Snid As String
    Dim ErrorString As String
    '''' lrq   2007/01/10 ''''
    Dim m_PrintPort As String
    Dim m_PackNumber As String   ''外箱編號
    Dim m_DpetId As String
    Dim m_FormName As String
    Dim m_ShowStyle As Int32
    Dim m_BcRuleid As String
    Dim m_IsExitFlag As Boolean
    Dim m_ReplaceQty As String
    Dim m_ReplaceMo As String
    Dim m_CustIdString As String
    Dim m_vProductLot As String
    Dim m_LastPrintQty As String
    Dim m_MoTotalScanQty As Integer
    Dim m_NowScanQty As Integer
    Dim m_NowCartonScanQty As Integer
    Dim m_ReplacePrint As Boolean
    Dim m_LastPrint As Boolean
    Dim m_InCartonScanCheck As Boolean
    Dim m_PrtPackingCheck As Boolean ''是否在线打印外箱信息 柯华松  2014/04/20
    Dim m_IsOnlineGenCartonID As Boolean ''是否在线生成外箱号, cq 20160126
    Dim m_DateCheck As String
    Dim m_ScanPalletCheck = False    '是否掃描棧板
    Dim m_CustPartCheck = False      '是否核對客戶料號
    Dim m_EquipmentLifeCheck As String   '是否冶具寿命卡控 2016/10/25
    Dim m_moType As String ''重工工單是否更換條碼 歐翔烽  2008/04/01
    Dim m_StandId As String
    Dim m_StandName As String
    Dim m_StaOrderId As String  '工站StaOrderId

    Dim m_currentStandIndex As Integer
    Dim m_StandMaxStaIndex As Integer
    Dim mTimeStyleSet As String
    Dim mstyleArray(15, 5) As String
    Dim m_StandIndex As Integer
    Dim m_MainBarCode As String
    Dim m_DeserTionFlag As Boolean
    Dim mReplaceArray(15, 5) As String
    Dim mStationFlag As String  ''站點的屬性 章星  2011/05/11
    Dim mCurrentBarcode As String ''當前掃入的條碼
    Dim mSq As String  ''舍弃
    Dim m_PreStation As String '
    Dim m_WritePCB As String '写入PCB
    Dim m_ReadPCB As String '读取PCB
    Dim m_CartonSame As String '外箱相同
    Dim m_PalletSame As String '栈板相同
    Dim m_ProductSame As String '产品相同
    Dim m_PackType As String '包装类型，Y:箱包装，N:产品包装
    Dim m_PPackingProduct As String
    Dim m_SamePacking As String  '袋子外箱是否相同
    Dim m_CodeRuleID As String
    Dim m_CodeRuleID2 As String  '第二层箱生成规则
    Dim m_vLabelDate As String '条码日期

#End Region

#Region "Properties"

    Public Property vWritePCB() As String

        Get
            Return m_WritePCB
        End Get
        Set(ByVal Value As String)
            m_WritePCB = Value
        End Set

    End Property

    Public Property vReadPCB() As String

        Get
            Return m_ReadPCB
        End Get
        Set(ByVal Value As String)
            m_ReadPCB = Value
        End Set

    End Property

    Public Property vCartonSame() As String

        Get
            Return m_CartonSame
        End Get
        Set(ByVal Value As String)
            m_CartonSame = Value
        End Set

    End Property

    Public Property vPalletSame() As String

        Get
            Return m_PalletSame
        End Get
        Set(ByVal Value As String)
            m_PalletSame = Value
        End Set

    End Property

    Public Property vProductSame() As String

        Get
            Return m_ProductSame
        End Get
        Set(ByVal Value As String)
            m_ProductSame = Value
        End Set

    End Property

    Public Property vPackType() As String
        Get
            Return m_PackType
        End Get
        Set(ByVal Value As String)
            m_PackType = Value
        End Set
    End Property

    Public Property vPPackingProduct() As String
        Get
            Return m_PPackingProduct
        End Get
        Set(ByVal Value As String)
            m_PPackingProduct = Value
        End Set
    End Property

    Public Property vSamePacking() As String
        Get
            Return m_SamePacking
        End Get
        Set(ByVal Value As String)
            m_SamePacking = Value
        End Set
    End Property

    Public Property vPreStation() As String
        Get
            Return m_PreStation
        End Get
        Set(ByVal Value As String)
            m_PreStation = Value
        End Set
    End Property
    Public Property vSq() As String
        Get
            Return mSq
        End Get
        Set(ByVal value As String)
            mSq = value
        End Set
    End Property

    Public Property vmReplaceArray() As String(,)

        Get
            Return mReplaceArray
        End Get
        Set(ByVal Value As String(,))
            mReplaceArray = Value
        End Set

    End Property

    Public Property vDeserTionFlag() As Boolean

        Get
            Return m_DeserTionFlag
        End Get
        Set(ByVal Value As Boolean)
            m_DeserTionFlag = Value
        End Set

    End Property

    Public Property vMainBarCode() As String ''重工工單是否更換條碼 歐翔烽 2008/04/01

        Get
            Return m_MainBarCode
        End Get
        Set(ByVal Value As String)
            m_MainBarCode = Value
        End Set

    End Property


    Public Property vStandIndex() As Integer

        Get
            Return m_StandIndex
        End Get
        Set(ByVal Value As Integer)
            m_StandIndex = Value
        End Set

    End Property

    Public Property vstyleArray() As String(,)

        Get
            Return mstyleArray
        End Get
        Set(ByVal Value As String(,))
            mstyleArray = Value
        End Set

    End Property

    Public Property vTimeStyleSet() As Integer

        Get
            Return mTimeStyleSet
        End Get
        Set(ByVal Value As Integer)
            mTimeStyleSet = Value
        End Set

    End Property

    Public Property vStandMaxStaIndex() As Integer

        Get
            Return m_StandMaxStaIndex
        End Get
        Set(ByVal Value As Integer)
            m_StandMaxStaIndex = Value
        End Set

    End Property

    Public Property vCurrentStandIndex() As Integer

        Get
            Return m_currentStandIndex
        End Get
        Set(ByVal Value As Integer)
            m_currentStandIndex = Value
        End Set

    End Property

    Public Property vStandName() As String ''重工工單是否更換條碼 歐翔烽 2008/04/01

        Get
            Return m_StandName
        End Get
        Set(ByVal Value As String)
            m_StandName = Value
        End Set

    End Property

    Public Property vStandId() As String ''重工工單是否更換條碼 歐翔烽 2008/04/01

        Get
            Return m_StandId
        End Get
        Set(ByVal Value As String)
            m_StandId = Value
        End Set

    End Property

    Public Property moType() As String ''重工工單是否更換條碼 歐翔烽 2008/04/01

        Get
            Return m_moType
        End Get
        Set(ByVal Value As String)
            m_moType = Value
        End Set

    End Property

    Public Property DateCheck() As String

        Get
            Return m_DateCheck
        End Get
        Set(ByVal Value As String)
            m_DateCheck = Value
        End Set

    End Property

    Public Property ScanPalletCheck() As Boolean
        Get
            Return m_ScanPalletCheck
        End Get
        Set(ByVal Value As Boolean)
            m_ScanPalletCheck = Value
        End Set

    End Property

    Public Property CustPartCheck() As Boolean

        Get
            Return m_CustPartCheck
        End Get
        Set(ByVal Value As Boolean)
            m_CustPartCheck = Value
        End Set

    End Property

    Public Property InCartonScanCheck() As Boolean

        Get
            Return m_InCartonScanCheck
        End Get
        Set(ByVal Value As Boolean)
            m_InCartonScanCheck = Value
        End Set

    End Property

    Public Property PrtPackingCheck() As Boolean

        Get
            Return m_PrtPackingCheck
        End Get
        Set(ByVal Value As Boolean)
            m_PrtPackingCheck = Value
        End Set

    End Property
    Public Property IsOnlineGenCartonID() As Boolean
        Get
            Return m_IsOnlineGenCartonID
        End Get
        Set(ByVal Value As Boolean)
            m_IsOnlineGenCartonID = Value
        End Set
    End Property

    Public Property ReplacePrintCheck() As Boolean
        Get
            Return m_ReplacePrint
        End Get
        Set(ByVal Value As Boolean)
            m_ReplacePrint = Value
        End Set
    End Property

    Public Property LastPrintCheck() As Boolean

        Get
            Return m_LastPrint
        End Get
        Set(ByVal Value As Boolean)
            m_LastPrint = Value
        End Set

    End Property

    ''2007/06/15  ruqiu'''''''''''''''

    Public Property NowCartonScanQty() As Integer

        Get
            Return m_NowCartonScanQty
        End Get
        Set(ByVal Value As Integer)
            m_NowCartonScanQty = Value
        End Set

    End Property
    ''2007/06/15  ruqiu'''''''''''''''

    Public Property NowScanQty() As Integer

        Get
            Return m_NowScanQty
        End Get
        Set(ByVal Value As Integer)
            m_NowScanQty = Value
        End Set

    End Property
    ' ''2007/06/15  ruqiu'''''''''''''''

    'Public  Property MoTotalCarton() As Integer

    '    Get
    '        Return m_MoTotalCarton
    '    End Get
    '    Set(ByVal Value As Integer)
    '        m_MoTotalCarton = Value
    '    End Set

    'End Property
    ''2007/06/15  ruqiu'''''''''''''''

    Public Property MoTotalScanQty() As Integer

        Get
            Return m_MoTotalScanQty
        End Get
        Set(ByVal Value As Integer)
            m_MoTotalScanQty = Value
        End Set

    End Property
    ''2007/06/13  歐翔烽'''''''''''''''

    Public Property LastPrintQty() As String

        Get
            Return m_LastPrintQty
        End Get
        Set(ByVal Value As String)
            m_LastPrintQty = Value
        End Set

    End Property
    ''2007/06/13 歐翔烽'''''''''''''''

    Public Property CustIdString() As String

        Get
            Return m_CustIdString
        End Get
        Set(ByVal Value As String)
            m_CustIdString = Value
        End Set

    End Property

    Public Property vProductLot() As String

        Get
            Return m_vProductLot
        End Get
        Set(ByVal Value As String)
            m_vProductLot = Value
        End Set

    End Property

    ''2007/05/14  歐翔烽'''''''''''''''

    Public Property vReplaceMo() As String

        Get
            Return m_ReplaceMo
        End Get
        Set(ByVal Value As String)
            m_ReplaceMo = Value
        End Set

    End Property

    Public Property vReplaceQty() As String

        Get
            Return m_ReplaceQty
        End Get
        Set(ByVal Value As String)
            m_ReplaceQty = Value
        End Set

    End Property

    ''2007/05/14''''''''''''''''''''''''''''

    Public Property IsExitFlag() As Boolean   ''歐翔烽 2007 05 8

        Get
            Return m_IsExitFlag
        End Get
        Set(ByVal Value As Boolean)
            m_IsExitFlag = Value
        End Set

    End Property

    Public Property BcRuleid() As String  ''歐翔烽 2007 03 14

        Get
            Return m_BcRuleid
        End Get
        Set(ByVal Value As String)
            m_BcRuleid = Value
        End Set

    End Property
    Public Property FormName() As String  ''歐翔烽 2007 03 14

        Get
            Return m_FormName
        End Get
        Set(ByVal Value As String)
            m_FormName = Value
        End Set

    End Property

    Public Property DpetId() As String  ''歐翔烽 2007 03 14

        Get
            Return m_DpetId
        End Get
        Set(ByVal Value As String)
            m_DpetId = Value
        End Set

    End Property

    Public Property PackNumber() As String

        Get
            Return m_PackNumber
        End Get
        Set(ByVal Value As String)
            m_PackNumber = Value
        End Set

    End Property

    Public Property PrintPort() As String

        Get
            Return m_PrintPort
        End Get
        Set(ByVal Value As String)
            m_PrintPort = Value
        End Set

    End Property

    ''歐翔烽 2007 01 29
    Public Property MoidStr() As String
        Get
            If (LMoid Is Nothing) Then
                LMoid = ""
            End If
            Return LMoid
        End Get
        Set(ByVal Value As String)
            LMoid = Value
        End Set
    End Property

    Public Property MoidqtyStr() As String
        Get
            Return LMoidqty
        End Get
        Set(ByVal Value As String)
            LMoidqty = Value
        End Set
    End Property

    Public Property CustStr() As String
        Get
            Return custname
        End Get
        Set(ByVal Value As String)
            custname = Value
        End Set
    End Property

    Public Property MoCustStr() As String
        Get
            Return LMoCust
        End Get
        Set(ByVal Value As String)
            LMoCust = Value
        End Set
    End Property

    Public Property DpetNameStr() As String
        Get
            Return LDpetName
        End Get
        Set(ByVal Value As String)
            LDpetName = Value
        End Set
    End Property

    Public Property LineStr() As String
        Get
            Return LLine
        End Get
        Set(ByVal Value As String)
            LLine = Value
        End Set
    End Property

    Public Property LengthStr() As String
        Get
            Return LLength
        End Get
        Set(ByVal Value As String)
            LLength = Value
        End Set
    End Property

    Public Property TimeStr() As String
        Get
            Return LTime
        End Get
        Set(ByVal Value As String)
            LTime = Value
        End Set
    End Property

    Public Property CheckStr() As Boolean
        Get
            Return CheckString
        End Get
        Set(ByVal Value As Boolean)
            CheckString = Value
        End Set
    End Property

    Public Property PartidStr() As String
        Get
            Return Partid
        End Get
        Set(ByVal Value As String)
            Partid = Value
        End Set
    End Property

    Public Property SnidStr() As String
        Get
            Return Snid
        End Get
        Set(ByVal Value As String)
            Snid = Value
        End Set
    End Property

    Public Property ErrorStr() As String
        Get
            Return ErrorString
        End Get
        Set(ByVal Value As String)
            ErrorString = Value
        End Set
    End Property

    Public Property SnStyleStr1() As String
        Get
            Return SnStyle1
        End Get
        Set(ByVal Value As String)
            SnStyle1 = Value
        End Set
    End Property

    Public Property SnStyleStr2() As String
        Get
            Return SnStyle2
        End Get
        Set(ByVal Value As String)
            SnStyle2 = Value
        End Set
    End Property

    Public Property GflenStr() As String
        Get
            Return Gflen
        End Get
        Set(ByVal Value As String)
            Gflen = Value
        End Set
    End Property
    Public Property BarCodeStr() As String
        Get
            Return BarCode
        End Get
        Set(ByVal Value As String)
            BarCode = Value
        End Set
    End Property

    Public Property ShowStyle() As Int32
        Get
            Return m_ShowStyle
        End Get
        Set(ByVal Value As Int32)
            m_ShowStyle = Value
        End Set
    End Property
    Public Property StationFlag() As String
        Get
            Return mStationFlag
        End Get
        Set(ByVal value As String)
            mStationFlag = value
        End Set
    End Property
    Public Property PreBarcode() As String
        Get
            Return mCurrentBarcode
        End Get
        Set(ByVal value As String)
            mCurrentBarcode = value
        End Set
    End Property

    Public Property CodeRuleID() As String
        Get
            Return m_CodeRuleID
        End Get
        Set(ByVal value As String)
            m_CodeRuleID = value
        End Set
    End Property

    Public Property CodeRuleID2() As String
        Get
            Return m_CodeRuleID2
        End Get
        Set(ByVal value As String)
            m_CodeRuleID2 = value
        End Set
    End Property

    Public Property vLabelDate() As String
        Get
            Return m_vLabelDate
        End Get
        Set(ByVal Value As String)
            m_vLabelDate = Value
        End Set
    End Property

    Public Property EquipmentLifeCheck() As String
        Get
            Return m_EquipmentLifeCheck
        End Get
        Set(ByVal Value As String)
            m_EquipmentLifeCheck = Value
        End Set
    End Property


#End Region

End Class
