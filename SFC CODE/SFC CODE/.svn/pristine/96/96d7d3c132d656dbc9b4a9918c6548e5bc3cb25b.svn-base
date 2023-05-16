
'--Tiptop资料获取类
'--Create by :　马锋
'--Create date :　2015/07/22
'--Ver : V01
'--Update date :  
'--

Imports LXWarehouseManage

Public Class GetTiptopDate

    Public Shared Function GetWarehouse(ByVal strFactory As String, ByVal strProfitcenter As String) As DataView
        Dim dvTemp As DataView
        Dim strSQL As String
        strSQL = "SELECT IMD01, IMD02 FROM " & strFactory & ".IMD_FILE"

        Dim TiptopConn As New OracleDb(strFactory)
        dvTemp = TiptopConn.getDataView(strSQL)
        Return dvTemp
    End Function

    Public Shared Function GetWarehouseLocation(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strWarehouseId As String) As DataView
        Dim dvTemp As DataView
        Dim strSQL As String
        strSQL = "SELECT IME01, IME02, IME03, IME04  FROM " & strFactory & ".IME_FILE WHERE IME01='" & strWarehouseId & "' AND IME05='Y'"

        Dim TiptopConn As New OracleDb(strFactory)
        dvTemp = TiptopConn.getDataView(strSQL)
        Return dvTemp
    End Function

    Public Shared Function GetWarehouseing(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strOrder As String) As DataView
        Dim dvTemp As DataView
        Dim strSQL As String
        strSQL = "SELECT RVV31,  SUM(RVV17) AS RVV17, IMA02, IMA021, IMA25 FROM " & strFactory & ".RVV_FILE INNER JOIN " & strFactory & ".IMA_FILE ON IMA_FILE.IMA01 = RVV_FILE.RVV31 WHERE RVV01 = '" & strOrder & "' GROUP BY RVV31, IMA02, IMA021, IMA25"

        Dim TiptopConn As New OracleDb(strFactory)
        dvTemp = TiptopConn.getDataView(strSQL)
        Return dvTemp
    End Function

    Public Shared Function GetOutStorehouse(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strOrder As String) As DataView
        Dim dvTemp As DataView
        Dim strSQL As String
        strSQL = "SELECT SFS04, SUM(SFS05) AS SFS05, IMA02, IMA021, IMA25  FROM " & strFactory & ".SFS_FILE INNER JOIN " & strFactory & ".IMA_FILE ON IMA_FILE.IMA01=SFS_FILE.SFS04 WHERE SFS01='" & strOrder & "' GROUP BY SFS04, IMA02, IMA021, IMA25 "

        Dim TiptopConn As New OracleDb(strFactory)
        dvTemp = TiptopConn.getDataView(strSQL)
        Return dvTemp
    End Function

    Public Shared Function GetFinishedProductStorage(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strOrder As String) As DataView
        Dim dvTemp As DataView
        Dim strSQL As String
        strSQL = "SELECT SFV04, SUM(SFV09) AS SFV09, IMA02, IMA021, IMA25 FROM LXXT.SFV_FILE INNER JOIN LXXT.IMA_FILE ON IMA_FILE.IMA01=SFV_FILE.SFV04 WHERE SFV01 = '" & strOrder & "' GROUP BY SFV04, IMA02, IMA021, IMA25 "

        Dim TiptopConn As New OracleDb(strFactory)
        dvTemp = TiptopConn.getDataView(strSQL)
        Return dvTemp
    End Function

    Public Shared Function GetFinishedProduct(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strOrder As String) As DataView
        Dim dvTemp As DataView
        Dim strSQL As String
        strSQL = "SELECT OGB04, SUM(OGB12) AS OGB12, IMA02, IMA021, IMA25 FROM LXXT.OGB_FILE INNER JOIN LXXT.IMA_FILE ON IMA_FILE.IMA01=OGB_FILE.OGB04 WHERE OGB01='" & strOrder & "' GROUP BY OGB04, IMA02, IMA021, IMA25"

        Dim TiptopConn As New OracleDb(strFactory)
        dvTemp = TiptopConn.getDataView(strSQL)
        Return dvTemp
    End Function


End Class
