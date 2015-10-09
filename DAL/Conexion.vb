Imports System.Data.SqlClient
Imports System.Configuration
Public Class Conexion
    'Facultad
    Private Shared _objConexion As New SqlConnection("Data Source=335-14-71555\SQL_UAI;Initial Catalog=Servicios;Integrated Security=True")
    'Trabajo
    'Private Shared _objConexion As New SqlConnection("Data Source=.;Initial Catalog=Servicios;Integrated Security=True")
    Private Shared _objConexionMaster As New SqlConnection("Data Source=.\SQL_UAI;Initial Catalog=master;Integrated Security=True")
    Private Shared _transaccion As SqlTransaction
    Private Shared _comando As SqlCommand


    Shared Function retornaConexionMaestra() As SqlConnection
        Return _objConexionMaster
    End Function


    ''' <summary>Para Realizar los SELECT</summary>
    ''' <param name="NombreStoreProcedure">Nombre del Store Procedure que se va a ejecutar</param>
    ''' <param name="SQLParameter">Parámetros de la consulta</param>
    Public Shared Function ExecuteDataTable(ByVal NombreStoreProcedure As String, ByVal SQLParameter As Hashtable) As DataTable
        Try
            Dim _dataTable As New DataTable
            _comando = New SqlCommand
            _comando.Connection = _objConexion
            _comando.CommandText = NombreStoreProcedure
            _comando.CommandType = CommandType.StoredProcedure

            If Not SQLParameter Is Nothing Then
                For Each MiParametro As String In SQLParameter.Keys
                    _comando.Parameters.AddWithValue(MiParametro, SQLParameter(MiParametro))
                Next
            End If
            Dim _dataAdapter As New SqlDataAdapter(_comando)
            _dataAdapter.Fill(_dataTable)
            Return _dataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ''' <summary> Ejecuta una Consulta (Insert, Delete, Update)</summary>
    ''' <param name="NombreStoreProcedure">Nombre del Store Procedure que se va a ejecutar</param>
    ''' <param name="SQLParameter">Parámetros de la consulta</param>
    Public Shared Function ExecuteNonQuery(ByVal NombreStoreProcedure As String, ByVal SQLParameter As Hashtable) As Integer
        Try
            If _objConexion.State = ConnectionState.Closed Then
                _objConexion.Open()
            End If

            _transaccion = _objConexion.BeginTransaction
            _comando = New SqlCommand
            _comando.Connection = _objConexion
            _comando.CommandText = NombreStoreProcedure
            _comando.CommandType = CommandType.StoredProcedure
            _comando.Transaction = _transaccion

            If Not SQLParameter Is Nothing Then
                For Each MiParametro As String In SQLParameter.Keys
                    _comando.Parameters.AddWithValue(MiParametro, SQLParameter(MiParametro))
                Next
            End If

            'Aca cambia, porque es con transaccion ahora
            'Entonces le hago un executenonquery para guardarme la rta (filas afectadas) y las devuelvo
            'Como haciamos antes pero en dos pasos
            Dim respuesta As Integer = _comando.ExecuteNonQuery()
            _transaccion.Commit()

            Return respuesta

        Catch ex As Exception
            'Agrego el rollback
            _transaccion.Rollback()
            Throw New Exception(ex.Message)
        Finally
            _objConexion.Close()
        End Try
    End Function

    ''' <summary>Retorna el ultimo ID de la Tabla </summary>
    ''' <param name="_paramTabla">La tabla que quiero el ID</param>
    ''' <param name="_paramCampoID">El campo ID de la tabla</param>
    Shared Function ObtenerID(ByVal _paramTabla As String, ByVal _paramCampoID As String) As Integer
        If _objConexion.State = ConnectionState.Closed Then
            _objConexion.Open()
        End If

        _comando = New SqlCommand
        _comando.Connection = _objConexion
        _comando.CommandText = "ObtenerID"
        _comando.CommandType = CommandType.StoredProcedure

        _comando.Parameters.Add(New SqlParameter("@paramTabla", _paramTabla))
        _comando.Parameters.Add(New SqlParameter("@paramCampoID", _paramCampoID))



        'Ojo esto no lo borré porque es la consulta que hay que poner en el stored procedure
        'Dim _dataAdapter As New SqlDataAdapter(retornaComando("Select Top(1) " & _paramCampoID & " from " & _paramTabla & " order by " & _paramCampoID & " Desc"))

        Dim _dataTable As New DataTable
        Dim _resultado As Integer
        Dim _dataAdapter As New SqlDataAdapter(_comando)
        _dataAdapter.Fill(_dataTable)
        If _dataTable.Rows.Count = 0 Then
            _resultado = 1
        Else
            _resultado = (_dataTable.Rows(0).Item(0)) + 1
        End If
        Return _resultado
    End Function



#Region "Consultas antes"
    ''' <summary>
    ''' Para Realizar los SELECT
    ''' </summary>
    ''' <param name="_paramComando"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteDataTable(ByVal _paramComando As SqlCommand) As DataTable
        Try
            Dim _dataTable As New DataTable
            Dim _dataAdapter As New SqlDataAdapter(_paramComando)
            _dataAdapter.Fill(_dataTable)
            Return _dataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> Ejecuta una Consulta (Insert, Delete, Update)</summary>
    ''' <param name="_paramComando"> le paso el comando ya con los parámetros agregados</param>
    Public Shared Function ExecuteNonQuery(ByVal _paramComando As SqlCommand) As Integer

        Try
            If _objConexion.State = ConnectionState.Open Then
                _objConexion.Close()
            End If
            _paramComando.Connection = _objConexion
            _objConexion.Open()
            Return _paramComando.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _objConexion.Close()
            '_objDAL.Conexion.Dispose()
        End Try
    End Function

    ''' <summary> Retorna un objeto Comando</summary>
    ''' <param name="_paramcomando">String SQL</param>
    Shared Function retornaComando(ByVal _paramComando As String) As SqlCommand
        Dim _objCommando As New SqlCommand(_paramComando, _objConexion)
        _objCommando.CommandType = CommandType.Text
        Return _objCommando
    End Function

    'Shared Function ObtenerID(ByVal _paramTabla As String, ByVal _paramCampoID As String) As Integer
    '    Dim _dataAdapter As New SqlDataAdapter(retornaComando("Select Top(1) " & _paramCampoID & " from " & _paramTabla & " order by " & _paramCampoID & " Desc"))
    '    Dim _dataTable As New DataTable
    '    Dim _resultado As Integer
    '    _dataAdapter.Fill(_dataTable)
    '    If _dataTable.Rows.Count = 0 Then
    '        _resultado = 1
    '    Else
    '        _resultado = (_dataTable.Rows(0).Item(0)) + 1
    '    End If
    '    Return _resultado
    'End Function

#End Region





End Class