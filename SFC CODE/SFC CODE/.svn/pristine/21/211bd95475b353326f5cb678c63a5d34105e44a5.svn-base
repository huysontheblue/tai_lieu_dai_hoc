
'--SQL字符串类
'--Create by :　马锋
'--Create date :　2015/07/15
'--Update date :  
'--
'--Ver : V01

Public Class SQLStringHelper
    Public Shared Function GetSettingParameterSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUE, PARAMETER_NAME + '[' + PARAMETER_VALUE + ']' AS PARAMETER_NAME FROM m_SettingParameter_t WHERE PARAMETER_MODE='" & ParameterCode & "' ORDER BY ORDERID ASC"
    End Function

End Class
