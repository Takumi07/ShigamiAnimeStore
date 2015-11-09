Imports System.Data.SqlClient

Public Class BitacoraMPP
    Public Sub altaBitacora(paramBitacora As Entidades.Bitacora)
        Try
            Dim MisParametros As New Hashtable
            paramBitacora.ID = DAL.Conexion.ObtenerID("Bitacora", "ID_Bitacora")
            paramBitacora.FechaHora = Now
            MisParametros.Add("@FechaHora", Now)
            MisParametros.Add("@Prioridad", paramBitacora.Prioridad)
            MisParametros.Add("@Descripcion", paramBitacora.Descripcion)
            MisParametros.Add("@TipoOperacion", paramBitacora.TipoOperacion)
            MisParametros.Add("@ID_Usuario", paramBitacora.Usuario.ID)
            'Aca tiene que ir el DVH
            MisParametros.Add("@DVH", DVMPP.CalcularDVH(paramBitacora.DigitoVerificador))
            DAL.Conexion.ExecuteNonQuery("altaBitacora", MisParametros)
            DVMPP.ActualizarDVV("Bitacora")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarBitacora() As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("consultarBitacora", Nothing)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Consulta Selección FILTRO"

    Public Function consultarBitacora(ByVal paramOperacion As Integer) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from bitacora where TipoOperacion=@TipoOperacion")
            With MiComando.Parameters
                .Add(New SqlParameter("@TipoOperacion", paramOperacion))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarBitacora(ByVal paramFecha As Date) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from bitacora where CAST(FechaHora AS DATE)=@FechaHora")
            With MiComando.Parameters
                .Add(New SqlParameter("@FechaHora", paramFecha))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarBitacora(ByVal paramFecha As Date, ByVal paramOperacion As Integer) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from bitacora where CAST(FechaHora AS DATE)=@FechaHora and TipoOperacion=@TipoOperacion")
            With MiComando.Parameters
                .Add(New SqlParameter("@FechaHora", paramFecha))
                .Add(New SqlParameter("@TipoOperacion", paramOperacion))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarBitacora(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from bitacora where ID_Usuario=@ID_Usuario")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarBitacora(ByVal paramUsuario As Entidades.Usuario, ByVal paramOperacion As Integer) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from bitacora where ID_Usuario=@ID_Usuario and TipoOperacion=@TipoOperacion")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@TipoOperacion", paramOperacion))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarBitacora(ByVal paramUsuario As Entidades.Usuario, ByVal paramFecha As Date) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from bitacora where ID_Usuario=@ID_Usuario and CAST(FechaHora AS DATE)=@FechaHora")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@FechaHora", paramFecha))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarBitacora(ByVal paramUsuario As Entidades.Usuario, ByVal paramFecha As Date, ByVal paramOperacion As Integer) As List(Of Entidades.Bitacora)
        Try
            Dim _listaBitacora As New List(Of Entidades.Bitacora)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from bitacora where ID_Usuario=@ID_Usuario and CAST(FechaHora AS DATE)=@FechaHora and TipoOperacion=@TipoOperacion")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@FechaHora", paramFecha))
                .Add(New SqlParameter("@TipoOperacion", paramOperacion))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _bitacoraEntidad As New Entidades.Bitacora
                formatearBitacora(dr, _bitacoraEntidad)
                _listaBitacora.Add(_bitacoraEntidad)
            Next
            Return _listaBitacora
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region


    Public Sub formatearBitacora(ByVal paramRow As DataRow, ByVal paramBitacoraEntidad As Entidades.Bitacora)
        paramBitacoraEntidad.ID = paramRow(0)
        paramBitacoraEntidad.FechaHora = paramRow(1)
        paramBitacoraEntidad.Prioridad = paramRow(2)
        paramBitacoraEntidad.Descripcion = paramRow(3)
        paramBitacoraEntidad.TipoOperacion = paramRow(4)
        Dim _usuario As New UsuarioMPP
        paramBitacoraEntidad.Usuario = _usuario.consultarUsuarioLigero(CInt(paramRow(5)))
    End Sub

End Class
