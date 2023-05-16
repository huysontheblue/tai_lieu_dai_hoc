Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OracleClient
Imports System

Public Class SampleComBusiness

    Public Shared Function GetWhereAnd(tableFieldName As String, value As String) As String
        Dim strValue As String = String.Format(" AND {0}='{1}'", tableFieldName, value)
        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    '执行查询，并返回查询所返回的结果集中第一行的第一列
    Public Shared Function ExecuteScalarOracle(ByVal sql As String) As String
        Dim returnValue As String

        Dim oracleConn As New LXWarehouseManage.OracleDb("")
        Try
            returnValue = oracleConn.ExecuteScalar(sql).ToString()
        Catch ex As Exception
            Throw
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return returnValue
    End Function

    Public Shared Function GetDataTableOracle(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim oracleConn As New LXWarehouseManage.OracleDb("")
        Try
            dt = oracleConn.ExecuteQuery(sql).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Sub Oracle_ExecuteNonQuery(ByVal sql As String)

        Dim oracleConn As New LXWarehouseManage.OracleDb("")
        Try
            oracleConn.ExecuteNonQuery(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try
    End Sub

    Public Shared Function GetDataTable(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            dt = sConn.GetDataTable(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Function GetDataSet(ByVal sql As String) As DataSet
        Dim ds As DataSet

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            ds = sConn.GetDataSet(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return ds
    End Function

    Public Shared Function ExecSQL(ByVal sql As String, Optional ByRef IsQAS As Boolean = False) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        'If sConn.m_SqlserverIP = "172.20.20.155" Then

        'End If

        Try
            If sConn.PubConnection.ConnectionString.Contains("172.20.20.155") Then
                IsQAS = True
            End If
            result = sConn.ExecuteNonQuery(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Function ExecuteNonQureyByProc(ByVal SPName As String, paramsList As ArrayList) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next
            result = sConn.ExecuteNonQureyByProc(SPName, cmdParms)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Function ExecuteNonQureyByProc(ByVal SPName As String, ByVal Paramters() As SqlClient.SqlParameter) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            result = sConn.ExecuteNonQureyByProc(SPName, Paramters)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Sub ExecSQL(sql As String, paramsList As ArrayList)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next

            sConn.ExecSql(sql, cmdParms)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Sub

    Public Shared Function GetDataTable(sql As String, paramsList As ArrayList)
        Dim dt As DataTable
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next

            dt = sConn.GetDataTable(sql, cmdParms)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
        Return dt
    End Function

    Public Shared Sub AddParams(strParamNameValue As String, ByRef sqlParam As SqlParameter)
        Dim keyValue As String() = strParamNameValue.Split("|")
        If keyValue.Length <> 2 Then
            Exit Sub
        End If
        sqlParam = New SqlParameter
        sqlParam.ParameterName = "@" & keyValue(0)
        sqlParam.SqlDbType = SqlDbType.NVarChar
        If keyValue(1).Trim.Length > 0 Then
            sqlParam.Value = keyValue(1)
        Else
            sqlParam.Value = DBNull.Value
        End If
    End Sub

    Public Shared Function DBNullToStr(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            If obj Is Nothing Then
                Return ""
            Else
                Return obj.ToString().Trim()
            End If
        End If
    End Function

    Public Shared Function GetNewDataTable(ByVal o_dt As DataTable, ByVal strCondition As String, ByVal strSort As String) As DataTable
        Dim newdt As DataTable
        Dim o_arrDr As DataRow()
        newdt = o_dt.Clone
        o_arrDr = o_dt.Select(strCondition, strSort)
        For Each o_dr As DataRow In o_arrDr
            newdt.ImportRow(o_dr)
        Next
        Return newdt
    End Function


#Region "添加日期列"
    Public Class CalendarColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New(New CalendarCell())
        End Sub

        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)

                ' Ensure that the cell used for the template is a CalendarCell.
                If (value IsNot Nothing) AndAlso _
                    Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                    Then
                    Throw New InvalidCastException("Must be a CalendarCell")
                End If
                MyBase.CellTemplate = value

            End Set
        End Property

    End Class

    Public Class CalendarCell
        Inherits DataGridViewTextBoxCell

        Public Sub New()
            ' Use the short date format.
            Me.Style.Format = "d"
        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
            ByVal initialFormattedValue As Object, _
            ByVal dataGridViewCellStyle As DataGridViewCellStyle)

            ' Set the value of the editing control to the current cell value.
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                dataGridViewCellStyle)

            Dim ctl As CalendarEditingControl = _
                CType(DataGridView.EditingControl, CalendarEditingControl)
            ctl.Value = CType(Me.Value, DateTime)

        End Sub

        Public Overrides ReadOnly Property EditType() As Type
            Get
                ' Return the type of the editing contol that CalendarCell uses.
                Return GetType(CalendarEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType() As Type
            Get
                ' Return the type of the value that CalendarCell contains.
                Return GetType(DateTime)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                ' Use the current date and time as the default value.
                Return DateTime.Now
            End Get
        End Property

    End Class

    Private Class CalendarEditingControl
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub New()
            Me.Format = DateTimePickerFormat.Short
        End Sub

        Public Property EditingControlFormattedValue() As Object _
            Implements IDataGridViewEditingControl.EditingControlFormattedValue

            Get
                Return Me.Value.ToShortDateString()
            End Get

            Set(ByVal value As Object)
                If TypeOf value Is String Then
                    Me.Value = DateTime.Parse(CStr(value))
                End If
            End Set

        End Property

        Public Function GetEditingControlFormattedValue(ByVal context _
            As DataGridViewDataErrorContexts) As Object _
            Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

            Return Me.Value.ToShortDateString()

        End Function

        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
            DataGridViewCellStyle) _
            Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

            Me.Font = dataGridViewCellStyle.Font
            Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
            Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

        End Sub

        Public Property EditingControlRowIndex() As Integer _
            Implements IDataGridViewEditingControl.EditingControlRowIndex

            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set

        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, _
            ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
            Implements IDataGridViewEditingControl.EditingControlWantsInputKey

            ' Let the DateTimePicker handle the keys listed.
            Select Case key And Keys.KeyCode
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                    Return True

                Case Else
                    Return Not dataGridViewWantsInputKey
            End Select

        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
            Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

            ' No preparation needs to be done.

        End Sub

        Public ReadOnly Property RepositionEditingControlOnValueChange() _
            As Boolean Implements _
            IDataGridViewEditingControl.RepositionEditingControlOnValueChange

            Get
                Return False
            End Get

        End Property

        Public Property EditingControlDataGridView() As DataGridView _
            Implements IDataGridViewEditingControl.EditingControlDataGridView

            Get
                Return dataGridViewControl
            End Get
            Set(ByVal value As DataGridView)
                dataGridViewControl = value
            End Set

        End Property

        Public Property EditingControlValueChanged() As Boolean _
            Implements IDataGridViewEditingControl.EditingControlValueChanged

            Get
                Return valueIsChanged
            End Get
            Set(ByVal value As Boolean)
                valueIsChanged = value
            End Set

        End Property

        Public ReadOnly Property EditingControlCursor() As Cursor _
            Implements IDataGridViewEditingControl.EditingPanelCursor

            Get
                Return MyBase.Cursor
            End Get

        End Property

        Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

            ' Notify the DataGridView that the contents of the cell have changed.
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(eventargs)

        End Sub

    End Class


#End Region

End Class
