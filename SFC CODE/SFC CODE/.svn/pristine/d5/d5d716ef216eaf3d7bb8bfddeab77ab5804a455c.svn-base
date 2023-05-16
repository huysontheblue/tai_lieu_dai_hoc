Imports Aspose.Cells

Public Class OnlineSopBusiness
    Public Enum HeaderGridView
        CheckBox = 0
        SopName
        DocId
        PartName
        PartDesc
        Version
        PageAmount
        Shape
        Status
        Remark
        UserName
        CreateTime
        RecentlyModifyTime
        ModifyUserId
        ModifyTime
        CreateUserId
        '选择 /SOP名称/文件编码/描述/规格/版本/页数/形态/状态/备注/创建人/创建日期/最后修改日期/修改人/修改时间
    End Enum


    Public Enum BodyGridView
        CheckBox = 0
        StationName
        VerNo
        EcnNo
        PageSize
        IsFocusStation
        UserName
        ModifyTime
        Remark
        IsColor
        ID
        '选择/工站名称/版本/ECN编码/页次/重点工站/用户名称/修改时间 /备注/ID
    End Enum

    ''' <summary>
    ''' 料号信息XML数据传输，去掉特殊字符
    ''' </summary>
    ''' <param name="strPartInfo">料号信息</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetXmlCharHandle(ByRef strPartInfo As String) As String
        Dim result As String = strPartInfo
        result = result.Replace("&", "")
        result = result.Replace("'", "")
        result = result.Replace("<", "")
        result = result.Replace(">", "")
        Return result
    End Function

    ''' <summary>
    ''' 检查输入的版本是否正确
    ''' </summary>
    ''' <param name="cur_VerNo">当前版本</param>
    ''' <param name="new_VerNo">新版本</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckVersionItRight(ByVal cur_VerNo As String, ByVal new_VerNo As String) As Boolean
        Dim r As Boolean = False
        Dim cur_idx As Integer = -1
        Dim new_idx As Integer = -1
        Dim idx As Integer = 0
        '版本依次X/A/B/C/D/E/F/G/H/I/J/K/L/M/N/P/Q/R/S/T/U/V/W/Y。
        'X1-X3;A1-A9，B1-B9，以此类推
        Dim arrVer() As String = {"X", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "Y"}
        If new_VerNo.Length > 2 Then
            Return False
        End If
        'X版本X1-X3
        If new_VerNo.Substring(0, 1) = "X" And CInt(new_VerNo.Substring(1, 1)) > 3 Then
            Return False
        Else
            For Each Str As String In arrVer
                ' '是否有当前 版本
                If Not cur_VerNo Is Nothing AndAlso cur_VerNo.Substring(0, 1) = Str Then
                    cur_idx = idx
                End If
                If new_VerNo.Substring(0, 1) = Str Then
                    new_idx = idx
                End If
                idx = idx + 1
            Next
            '第一个字符是否在字符数组中
            If cur_VerNo Is Nothing And new_idx = -1 Then
                Return False
            End If
            If Not cur_VerNo Is Nothing Then
                '第一个字符之前还靠前
                If new_idx < cur_idx Then
                    Return False
                End If
                '第一个字符相同，但第二个字符比之前小
                If new_idx = cur_idx AndAlso CInt(new_VerNo.Substring(1, 1)) < CInt(cur_VerNo.Substring(1, 1)) Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

End Class
