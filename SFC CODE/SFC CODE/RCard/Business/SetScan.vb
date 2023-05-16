Public Class SetScan

    'Find the Child PN 
    Public Shared Function GetChildPNByBarcode(ByVal Barcode As String, ByRef strChildPNOfMO As String) As String
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        ' lsSQL = " SELECT  PartID FROM m_Ppidlink_t Where ppid='" & Barcode & "'"
        lsSQL = "SELECT  b.partid,a.moid  FROM m_SnSBarCode_t a, m_Mainmo_t b  " & _
                " WHERE sbarcode='" & Barcode & "'" & _
                " AND a.moid =b.moid"
        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNByBarcode = o_dt.Rows(0).Item(0)
                strChildPNOfMO = o_dt.Rows(0).Item("moid")
            Else
                GetChildPNByBarcode = ""
            End If
        End Using
        Return GetChildPNByBarcode
    End Function

    Public Shared Function GetPNByBarcode(ByVal Barcode As String) As String
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        ' lsSQL = " SELECT  PartID FROM m_Ppidlink_t Where ppid='" & Barcode & "'"
        lsSQL = "SELECT  b.partid,a.moid  FROM m_SnSBarCode_t a, m_Mainmo_t b  " & _
                " WHERE sbarcode='" & Barcode & "'" & _
                " AND a.moid =b.moid"
        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPNByBarcode = o_dt.Rows(0).Item(0)
            Else
                GetPNByBarcode = ""
            End If
        End Using
        Return GetPNByBarcode
    End Function

    'Find One of Child PN 
    Public Shared Function GetChildPNByWNBarcode(ByVal PartID As String, ByVal strMOID As String, ByVal Barcode As String) As String
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        lsSQL = " SELECT DISTINCT PARTID  FROM m_Mainmo_t " & _
                " WHERE PARTID LIKE '" & PartID & "-%'" & _
                " AND PARTID NOT IN (SELECT DISTINCT PARTID  FROM m_SnSBarCode_t" & _
                " WHERE MOID LIKE '" & PartID & "-%')" & _
                " AND partid NOT IN (SELECT DISTINCT partid FROM m_SetScanD_t" & _
                " WHERE packbarcode ='" & Barcode & "')"
        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNByWNBarcode = o_dt.Rows(0).Item(0)
            Else
                GetChildPNByWNBarcode = ""
            End If
        End Using
        Return GetChildPNByWNBarcode
    End Function

    Public Shared Function GetFinishChildPNQty(ByVal PPartID As String, ByVal PackBarcode As String) As Integer
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        lsSQL = " SELECT  1  FROM m_SetScanD_t Where PPartID='" & PPartID & "' AND Qty=ScanedQty  And PackBarcode='" & PackBarcode & "'"

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetFinishChildPNQty = o_dt.Rows.Count
            Else
                GetFinishChildPNQty = 0
            End If
        End Using
        Return GetFinishChildPNQty
    End Function

    Public Shared Function IsAlreadyScaned(ByVal sBarcode As String) As Integer
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        lsSQL = " SELECT 1 FROM m_SetScanD_t" & _
                " WHERE  charindex( '," & sBarcode & ",',','+sbarcode+',') >0"

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsAlreadyScaned = True
            Else
                IsAlreadyScaned = False
            End If
        End Using
        Return IsAlreadyScaned
    End Function

    'Find the Parent MO by Pack barcode
    Public Shared Function GetPMOByPackBarcode(ByVal Barcode As String, _
                                               ByRef PartID As String, ByRef strMOQty As String, _
                                               ByRef strLineID As String
                                               ) As String
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        lsSQL = " SELECT  a.MOID,b.PARTID, b.Moqty,b.lineid  FROM m_SnSBarCode_t a, m_Mainmo_t b  " & _
                " WHERE  a.moid = b.moid AND a.SBarCode='" & Barcode & "'"

        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPMOByPackBarcode = o_dt.Rows(0).Item(0)
                PartID = o_dt.Rows(0).Item("PARTID")
                strMOQty = o_dt.Rows(0).Item("Moqty")
                strLineID = o_dt.Rows(0).Item("lineid")
            Else
                GetPMOByPackBarcode = ""
            End If
        End Using
        Return GetPMOByPackBarcode
    End Function

    'Add by cq 20160429
    Public Shared Function GetChildPNCount(ByVal strMOID As String, ByRef o_stdPartID As DataTable) As Integer
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT DISTINCT  A.PARTID  FROM " & _
                  " (SELECT  A.PARTID  FROM m_MainMO_t A WHERE" & _
                  " A.PARENTMO = '" & strMOID & "' AND A.MOID <> PARENTMO AND A.ESTATEID <> 'A')A " & _
                  " ORDER BY  A.PARTID"
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNCount = o_dt.Rows.Count
                o_stdPartID = o_dt
            Else
                GetChildPNCount = 0
            End If
            Return GetChildPNCount
        End Using
    End Function

    Public Shared Function IsExistUnfinshPack(ByVal strPackBarcode As String, ByRef o_strUnfinishPack As String) As Boolean
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT PackBarcode  FROM m_SetScanM_t Where status='0' and packbarcode <>'" & strPackBarcode & "'  "
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsExistUnfinshPack = True
                o_strUnfinishPack = o_dt.Rows(0).Item(0)
            Else
                IsExistUnfinshPack = False
                o_strUnfinishPack = ""
            End If
            Return IsExistUnfinshPack
        End Using
    End Function

    Public Shared Function GetChildPNInfo(ByVal PartID As String, ByVal PackBarcode As String) As DataTable
        Dim str As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        str = " SELECT PartID, PPartID, Isnull(ScanedQty,0) ScanedQty  FROM m_SetScanD_t " & _
              " WHERE PartID ='" & PartID & "' " & _
              " AND packbarcode='" & PackBarcode & "'"
        Using o_dt As DataTable = sConn.GetDataTable(str)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNInfo = o_dt
            Else
                GetChildPNInfo = Nothing
            End If
            Return GetChildPNInfo
        End Using
    End Function

    Public Shared Function GetChildPNSetQty(ByVal strChildPN As String) As Integer
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT ISNULL(AmountQty,1) AmountQty  FROM m_PartContrast_t WHERE  Tavcpart='" & strChildPN & "' " & _
                   " AND TAvcpart <>  PAvcPart"
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNSetQty = o_dt.Rows(0).Item(0)
            Else
                GetChildPNSetQty = 1
            End If
            Return GetChildPNSetQty
        End Using

    End Function

    Public Shared Function GetPPartIDVersion(ByVal strPPartID As String) As String
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT  IIf( ISNULL(version,'')='', substring(description,charindex('-',DESCRIPTION,0)+1,5), version) VERSION  " & _
                   " FROM m_PartContrast_t WHERE  Tavcpart='" & strPPartID & "' " & _
                   " AND TAvcpart =  PAvcPart"
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPPartIDVersion = o_dt.Rows(0).Item(0)
            Else
                GetPPartIDVersion = ""
            End If
            Return GetPPartIDVersion
        End Using

    End Function

    Public Shared Function GetVerFromTiptop(partNumber As String) As String
        Dim returnValue As String
        Dim StrSql As String = "SELECT NVL(IMA021,IMA02)  FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & partNumber & "'"

        returnValue = RCardComBusiness.ExecuteScalarOracle(StrSql).ToString()

        If returnValue <> "" Then
            Dim index As Integer = returnValue.LastIndexOf("-")
            If index >= 0 Then
                returnValue = returnValue.Substring(index + 1, returnValue.Length - index - 1)
            Else
                returnValue = ""
            End If
        End If
        Return returnValue
    End Function

    Public Shared Function GetMOFinishPackQty(ByVal strMOID As String) As String
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT  COUNT(1)   " & _
                   " FROM m_SetScanM_t(nolock) " & _
                   " WHERE  moid='" & strMOID & "' AND status ='1' "
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetMOFinishPackQty = o_dt.Rows(0).Item(0)
            Else
                GetMOFinishPackQty = ""
            End If
            Return GetMOFinishPackQty
        End Using

    End Function


    Public Shared Function IsByPassChildPN(ByVal strChildPartID As String, ByVal PVersion As String) As Boolean
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT  1  FROM m_SetScanPass_t WHERE CPartID='" & strChildPartID & "' AND PVersion='" & PVersion & "'"
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsByPassChildPN = True
            Else
                IsByPassChildPN = False
            End If
            Return IsByPassChildPN
        End Using

    End Function

    Public Shared Function IsGroup(ByVal strPartID As String, ByVal strMPartID As String, ByRef strCPartID As String) As Boolean
        Dim o_strSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        o_strSQL = " SELECT  CPartID  FROM m_SetScanGroupPass_t " & _
                   " WHERE PPartID='" & strPartID & "' AND MPartID='" & strMPartID & "'" & _
                   " AND MPartID <> CPartID"
        Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows
                    strCPartID = strCPartID + dr.Item(0) + ","
                Next
                strCPartID = strCPartID.Substring(0, strCPartID.Length - 1)
                IsGroup = True
            Else
                IsGroup = False
            End If
            Return IsGroup
        End Using

    End Function


    '    Public Shared Function GetChildPNQty() As String
    '        Dim lsSQL As String = String.Empty
    '        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
    '        lsSQL = " SELECT  CAST(ROW_NUMBER() OVER(ORDER BY PN) AS INT)ID,   A.PN," & _
    '               " CAST(A.QTY AS INT) QTY" & _
    '               " FROM (   SELECT DISTINCT D.TAvcPart PN,B.StationSQ,ISNULL(D.AmountQty,0) QTY " & _
    '               " FROM m_RCardM_t A,m_RCardD_t B,m_PartContrast_t M,m_PartContrast_t D,   m_Rstation_t E " & _
    '               " LEFT JOIN m_RstationSection_t F ON E.SECTIONID =F.ID AND F.usey =1   "
    '        WHERE ISNULL(D.EFFECTIVEDATE, GETDATE() - 1) <= Convert(VARCHAR(10), GETDATE(), 111)
    '					   AND (D.EXPIRATIONDATE='' OR ISNULL(D.EXPIRATIONDATE, GETDATE() +1) >=GETDATE() )   
    '					   AND ISNULL(D.EXTENSIBLE,'Y')='Y'   AND D.TAvcPart=A.PARTID  AND A.PartID =B.PartID  and D.TAvcPart <> D.PAvcPart 
    '					   AND D.PAvcPart=M.TAvcPart   
    '					   AND D.TAvcPart LIKE '%904092728%'  AND A.Factoryid='LXXT' AND A.Profitcenter= 'SEE-D' 
    'AND A.STATUS IN(1,2)  AND B.STATUS=1  AND B.StationID =E.Stationid   )A  GROUP BY PN,QTY  
    '        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)

    '            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
    '                GetPMOByBarcode = o_dt.Rows(0).Item(0)
    '                GetPMOByBarcode = GetPMOByBarcode.Substring(0, GetPMOByBarcode.LastIndexOf("-"))
    '                PartID = o_dt.Rows(0).Item("PartID")
    '            Else
    '                GetPMOByBarcode = ""
    '            End If
    '        End Using
    '        Return GetPMOByBarcode()
    '    End Function

End Class
