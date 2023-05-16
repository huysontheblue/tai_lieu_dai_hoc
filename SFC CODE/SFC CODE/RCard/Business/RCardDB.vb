Imports System.Data.OracleClient
Imports System.Data.SqlClient

Public Class RCardDB

#Region " Oracle 数据库"
    Public Class OracleDb
        Private conOra As OracleConnection
        Private cmdOra As OracleCommand
        'private OracleTransaction tranOra;
        Private tranOra As OracleTransaction
        Private _Value As String
        Private _State As Boolean = True
        Public connectionString As String


        Public Sub OracleDb(ByVal conString As String)

            ' // connectionString = "Data Source=TOPPROD;user=MESDG;password=DGMES;";

            ' //测试区
            '//connectionString = "Data Source=test;user=LX11;password=l6644;";
            connectionString = "Data Source=TOPTEST;user=LX11;password=l6644;"
            ' //connectionString = conString;

        End Sub


        Public ReadOnly Property Value() As String
            Get
                Return _Value
            End Get
        End Property

        Public Property State() As Boolean
            Get
                Return _State
            End Get
            Set(ByVal State As Boolean)
                _State = Value
            End Set

        End Property

        Private Sub CreateConnection()

            conOra = New OracleConnection()
            cmdOra = New OracleCommand()
            '  connectionString = "Data Source=TOPTEST;user=LX11;password=l6644;" 'cq 20160504

            connectionString = "User ID=LX11;Password=l6644;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST=192.168.20.191)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=TOPPROD)))"

            conOra.ConnectionString = connectionString
            Try

                conOra.Open()

            Catch ex As Exception
                _State = False
                _Value = ex.Message.ToString()
                Throw New Exception(ex.Message.ToString())
            End Try
        End Sub

        Public Function ExecuteNonQuery(ByVal strSql As String) As Integer

            Dim n As Integer = 0
            Try

                If IsNothing(conOra) Then
                    CreateConnection()
                ElseIf conOra.State = ConnectionState.Closed Then
                    conOra.Open()
                End If


                cmdOra.Connection = conOra
                cmdOra.CommandText = strSql
                cmdOra.CommandType = CommandType.Text
                If Not IsNothing(tranOra) Then
                    cmdOra.Transaction = tranOra
                End If
                ' //oDr[0] = cmdOra.ExecuteNonQuery();
                n = cmdOra.ExecuteNonQuery()


            Catch ex As Exception
                n = -9999
                RollBack()
                _State = False
                _Value = ex.Message.ToString()
                Throw New Exception(ex.Message.ToString())
            End Try
            Return n
        End Function

        Public Sub RollBack()
            If Not IsNothing(tranOra) Then
                tranOra.Rollback()
                tranOra = Nothing
            End If
        End Sub

        '把DBNUll值变为空
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

    End Class
#End Region
End Class

