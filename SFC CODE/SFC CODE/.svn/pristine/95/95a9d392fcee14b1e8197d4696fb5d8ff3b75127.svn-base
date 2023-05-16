
#Region "Imports"

Imports System.Windows.Forms
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO

#End Region

Public Class ReelPrint

    Dim mStyleID As String
    Dim mMantissaStyleID As String
    Dim mCustomerName As String
    Dim mSupplierPN As String
    Dim mMaterialNO As String
    Dim mVersion As String
    Dim mYears As String
    Dim mMonth As String
    Dim mDays As String
    Dim mPackingCapacity As String
    Dim mMantissaPackingQty As String
    Dim mVendorCode As String
    Dim mDateCode As String
    Dim mRev As String
    Dim mUnit As String
    Dim mGW As String
    Dim mCurrNumber As Int32
    Dim mMantissaCurrNumber As Int32
    Dim mPONO As String
    Dim mItemNO As String
    Dim mPrintCount As Int32
    Dim mPrintName As String

    Public Property StyleID() As String

        Get
            Return mStyleID
        End Get
        Set(ByVal value As String)
            mStyleID = value
        End Set

    End Property

    Public Property MantissaStyleID() As String

        Get
            Return mMantissaStyleID
        End Get
        Set(ByVal value As String)
            mMantissaStyleID = value
        End Set

    End Property

    Public Property CustomerName() As String

        Get
            Return mCustomerName
        End Get
        Set(ByVal value As String)
            mCustomerName = value
        End Set

    End Property

    Public Property SupplierPN() As String

        Get
            Return mSupplierPN
        End Get
        Set(ByVal value As String)
            mSupplierPN = value
        End Set

    End Property

    Public Property MaterialNO() As String

        Get
            Return mMaterialNO
        End Get
        Set(ByVal value As String)
            mMaterialNO = value
        End Set

    End Property

    Public Property Version() As String

        Get
            Return mVersion
        End Get
        Set(ByVal value As String)
            mVersion = value
        End Set

    End Property

    Public Property Years() As String

        Get
            Return mYears
        End Get
        Set(ByVal value As String)
            mYears = value
        End Set

    End Property

    Public Property Month() As String

        Get
            Return mMonth
        End Get
        Set(ByVal value As String)
            mMonth = value
        End Set

    End Property

    Public Property Days() As String

        Get
            Return mDays
        End Get
        Set(ByVal value As String)
            mDays = value
        End Set

    End Property

    Public Property PackingCapacity() As String

        Get
            Return mPackingCapacity
        End Get
        Set(ByVal value As String)
            mPackingCapacity = value
        End Set

    End Property

    Public Property MantissaPackingQty() As String

        Get
            Return mMantissaPackingQty
        End Get
        Set(ByVal value As String)
            mMantissaPackingQty = value
        End Set

    End Property

    Public Property VendorCode() As String

        Get
            Return mVendorCode
        End Get
        Set(ByVal value As String)
            mVendorCode = value
        End Set

    End Property

    Public Property DateCode() As String

        Get
            Return mDateCode
        End Get
        Set(ByVal value As String)
            mDateCode = value
        End Set

    End Property

    Public Property Rev() As String

        Get
            Return mRev
        End Get
        Set(ByVal value As String)
            mRev = value
        End Set

    End Property

    Public Property Unit() As String

        Get
            Return mUnit
        End Get
        Set(ByVal value As String)
            mUnit = value
        End Set

    End Property

    Public Property GW() As String

        Get
            Return mGW
        End Get
        Set(ByVal value As String)
            mGW = value
        End Set

    End Property

    Public Property CurrNumber() As String

        Get
            Return mCurrNumber
        End Get
        Set(ByVal value As String)
            mCurrNumber = value
        End Set

    End Property

    Public Property MantissaCurrNumber() As String

        Get
            Return mMantissaCurrNumber
        End Get
        Set(ByVal value As String)
            mMantissaCurrNumber = value
        End Set

    End Property

    Public Property PONO() As String

        Get
            Return mPONO
        End Get
        Set(ByVal value As String)
            mPONO = value
        End Set

    End Property

    Public Property ItemNO() As String

        Get
            Return mItemNO
        End Get
        Set(ByVal value As String)
            mItemNO = value
        End Set

    End Property

    Public Property PrintCount() As String

        Get
            Return mPrintCount
        End Get
        Set(ByVal value As String)
            mPrintCount = value
        End Set

    End Property

    Public Property PrintName() As String

        Get
            Return mPrintName
        End Get
        Set(ByVal value As String)
            mPrintName = value
        End Set

    End Property


#Region "解除打印時對料件的鎖定"

    Public Sub OpenPrintLock(ByVal StyleID As String)
        Dim Sqlstr As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Sqlstr = "update W_PRINTSTYLE_T set STATUS='N',HISTORY_TIME=getdate() where STYLEFORMAT='" & StyleID & "'"
            Conn.ExecSql(Sqlstr)

            Conn = Nothing
        Catch ex As Exception
            Conn = Nothing
            Throw ex
        End Try
    End Sub

    Public Sub PrintLock(ByVal StyleID As String)
        Dim Sqlstr As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Sqlstr = "update W_PRINTSTYLE_T set STATUS='Y',HISTORY_TIME=getdate() where STYLEFORMAT='" & StyleID & "'"
            Conn.ExecSql(Sqlstr)

            Conn = Nothing
        Catch ex As Exception
            Conn = Nothing
            Throw ex
        End Try
    End Sub

#End Region
#Region "打印參數結構体變量數組"
    ''增加動態數據d。
    Public Structure PrtStructure
        Public Moid As String
        Public CusName As String
        Public AvcPartid As String
        Public Deptid As String
        Public Lineid As String
        Public Qty As String
        Public NowDate As String
        Public NowMonth As String
        Public WorkType As String
        Public DateCode As String
        Public Suppliy As String
        Public weight As String
        Public CustomerPN As String
        Public ConfigFlag As String
        Public DriFlag As String
        Public CheckBit As String
        Public BuildAttribute As String
        Public ContainerNo As String
        Public Extended1 As String
        Public Extended2 As String
        Public Extended3 As String
        Public PO As String
        Public Function ToArray() As Array
            Dim PrtArray(22) As String
            PrtArray(1) = Moid
            PrtArray(2) = CusName
            PrtArray(3) = AvcPartid
            PrtArray(4) = Deptid
            PrtArray(5) = Lineid
            PrtArray(6) = Qty
            PrtArray(7) = NowDate
            PrtArray(8) = NowMonth
            PrtArray(9) = WorkType
            PrtArray(10) = DateCode
            PrtArray(11) = Suppliy
            PrtArray(12) = weight
            PrtArray(13) = CustomerPN
            PrtArray(14) = ConfigFlag
            PrtArray(15) = DriFlag
            PrtArray(16) = CheckBit
            PrtArray(17) = BuildAttribute
            PrtArray(18) = ContainerNo
            PrtArray(19) = Extended1
            PrtArray(20) = Extended2
            PrtArray(21) = Extended3
            PrtArray(22) = PO
            'Array14-固定列中的"Config-产品Config"
            Return PrtArray
        End Function
    End Structure

#End Region
End Class
