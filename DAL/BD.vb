Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Configuration

Public Class BD

#Region "ExecuteDataSet - Creo no usarlo"
    ''' <summary> Método que devuelve un DataSet</summary>
    ''' <param name="paramcomandtext">Espera la sentencia sql</param>
    Public Shared Function ExecuteDataset(ByVal paramcomandtext As String) As DataSet
        Try
            Dim MiDataset As New DataSet
            Dim MiDataAdapter = New SqlDataAdapter(paramcomandtext, MiConexion)
            MiDataAdapter.Fill(MiDataset)
            Return MiDataset
        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region


    ''' <summary>Devuelve una tabla llena con la instr. SQL que se pasa por parámetro.</summary>
    ''' <param name="paramcomando">Obj Comando con parámetros agregados</param>
    Public Shared Function ExecuteDataTable(ByVal paramcomando As SqlCommand) As DataTable
        Try
            'Dim MiConection = MiConexion()
            Dim MiDataTable As New DataTable
            Dim MiDataadapter As New SqlDataAdapter(paramcomando)
            MiDataadapter.Fill(MiDataTable)
            Return MiDataTable
        Catch ex As SqlException
            Throw ex
        End Try
    End Function


    ''' <summary> Ejecuta una consulta (Delete, update)</summary>
    ''' <param name="paramcomando"> le paso el comando ya con los parámetros agregados</param>
    Public Shared Function ExecuteNonQuery(ByVal paramcomando As SqlCommand) As Integer
        Dim MiConection = MiConexion()
        Try
            paramcomando.Connection = MiConection
            MiConection.Open()
            Return paramcomando.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            MiConection.Close()
            MiConection.Dispose()
        End Try
    End Function



    Shared Function ObtenerID(ByVal paramTabla As String, ByVal paramCampoID As String) As Integer
        Dim MiDataAdapter As New SqlDataAdapter(MiComando("Select Top(1) " & paramCampoID & " from " & paramTabla & " order by " & paramCampoID & " Desc"))
        Dim MiDataTable As New DataTable
        Dim MiResultado As Integer
        MiDataAdapter.Fill(MiDataTable)
        If MiDataTable.Rows.Count = 0 Then
            MiResultado = 1
        Else
            MiResultado = (MiDataTable.Rows(0).Item(0)) + 1
        End If
        Return MiResultado
    End Function


    Public Shared Function ExecuteScalar(ByVal paramcomando As SqlCommand) As Integer
        Dim MiConection = MiConexion()
        Try
            paramcomando.Connection = MiConection
            MiConection.Open()
            Return paramcomando.ExecuteScalar
        Catch ex As Exception
            Throw
        Finally
            MiConection.Close()
            MiConection.Dispose()
        End Try
    End Function

    ''' <summary> Retorna un objeto conexion instanciado, con el string de conexion utilizado.</summary>
    Shared Function MiConexion() As SqlConnection
        Dim MiConecction = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SQLProvider").ConnectionString)
        Return MiConecction
    End Function

    Shared Function MiConexionMaster() As SqlConnection
        Dim MiConecction = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SQLProviderMaster").ConnectionString)
        Return MiConecction
    End Function

    ''' <summary> Retorna un objeto comando al cual se le pueden adjuntar los parametros correspondientes. </summary>
    ''' <param name="paramcomando">String SQL</param>
    Shared Function MiComando(ByVal paramcomando As String) As SqlCommand
        Dim objCommando As New SqlCommand(paramcomando, MiConexion())
        objCommando.CommandType = CommandType.Text
        Return objCommando
    End Function

    Shared Function MiComandoMaster(ByVal paramcomando As String) As SqlCommand
        Dim objCommando As New SqlCommand(paramcomando, MiConexionMaster())
        objCommando.CommandType = CommandType.Text
        Return objCommando
    End Function
End Class
