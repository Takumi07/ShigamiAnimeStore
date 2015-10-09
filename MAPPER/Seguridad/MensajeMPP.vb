Imports System.Data.SqlClient

Public Class MensajeMPP
    Public Sub enviarMensaje(paramMensaje As Entidades.Mensaje)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("insert into mensaje values (@Asunto, @Texto, @UsuarioEmisor, @UsuarioReceptor, @Leido, @FechaHora, @BL_Emisor, @BL_Receptor)")
            With MiComando.Parameters
                .Add(New SqlParameter("@FechaHora", Now))
                .Add(New SqlParameter("@Asunto", paramMensaje.Asunto))
                .Add(New SqlParameter("@Texto", paramMensaje.Texto))
                .Add(New SqlParameter("@UsuarioEmisor", paramMensaje.Emisor.ID))
                .Add(New SqlParameter("@UsuarioReceptor", paramMensaje.Receptor.ID))
                .Add(New SqlParameter("@Leido", False))
                .Add(New SqlParameter("@BL_Emisor", False))
                .Add(New SqlParameter("@BL_Receptor", False))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function marcarLeido(ByVal paramMensaje As Entidades.Mensaje)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update Mensaje set Leido=@Leido where ID_Mensaje = @ID_Mensaje")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Mensaje", paramMensaje.ID))
                .Add(New SqlParameter("@Leido", True))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function borrarMensaje(ByVal paramMensaje As Entidades.Mensaje, ByVal _tipo As Boolean)
        Try
            If _tipo = True Then ' BORRA DE RECIBIDOS
                Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update Mensaje set BL_Receptor = @BL where ID_Mensaje = @ID_Mensaje")
                With MiComando.Parameters
                    .Add(New SqlParameter("@ID_Mensaje", paramMensaje.ID))
                    .Add(New SqlParameter("@BL", True))
                End With
                DAL.Conexion.ExecuteNonQuery(MiComando)
            Else ' BORRA DE ENVIADOS
                Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update Mensaje set BL_Emisor = @BL where ID_Mensaje = @ID_Mensaje")
                With MiComando.Parameters
                    .Add(New SqlParameter("@ID_Mensaje", paramMensaje.ID))
                    .Add(New SqlParameter("@BL", True))
                End With
                DAL.Conexion.ExecuteNonQuery(MiComando)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function obtenerCantidadNoLeidos(ByVal paramUsuario As Entidades.Usuario) As Integer
        Try
            Dim _listamensaje As New List(Of Entidades.Mensaje)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Mensaje where ID_Usuario_Receptor=@ID_Usuario and Leido=@Leido and BL_Receptor=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@Leido", False))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            Return _dt.Rows.Count
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function obtenerMensajes(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Mensaje)
        Try
            Dim _listamensaje As New List(Of Entidades.Mensaje)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Mensaje where ID_Usuario_Emisor=@ID_Usuario and BL=@BL or Usuario_Receptor=@NombreUsuario and BL=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _mensajeEnt As New Entidades.Mensaje
                FormatearMensaje(dr, _mensajeEnt)
                _listamensaje.Add(_mensajeEnt)
            Next
            Return _listamensaje
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function obtenerMensajesRecibidos(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Mensaje)
        Try
            Dim _listamensaje As New List(Of Entidades.Mensaje)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Mensaje where ID_Usuario_Receptor=@ID_Usuario and BL_Receptor=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _mensajeEnt As New Entidades.Mensaje
                FormatearMensaje(dr, _mensajeEnt)
                _listamensaje.Add(_mensajeEnt)
            Next
            Return _listamensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMensajesEnviados(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Mensaje)
        Try
            Dim _listamensaje As New List(Of Entidades.Mensaje)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Mensaje where ID_Usuario_Emisor=@ID_Usuario and BL_Emisor=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _mensajeEnt As New Entidades.Mensaje
                FormatearMensaje(dr, _mensajeEnt)
                _listamensaje.Add(_mensajeEnt)
            Next
            Return _listamensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMensaje(ByVal _idMensaje As Integer) As Entidades.Mensaje
        Try
            Dim _listamensaje As New List(Of Entidades.Mensaje)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Mensaje where ID_Mensaje=@ID_Mensaje and BL_Emisor=@BL_Emisor or ID_Mensaje=@ID_Mensaje and BL_Receptor=@BL_Receptor")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Mensaje", _idMensaje))
                .Add(New SqlParameter("@BL_Receptor", False))
                .Add(New SqlParameter("@BL_Emisor", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _mensajeEnt As New Entidades.Mensaje
                FormatearMensaje(_dt.Rows(0), _mensajeEnt)
                Return _mensajeEnt
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FormatearMensaje(ByVal paramRow As DataRow, ByVal paramMensaje As Entidades.Mensaje)
        Dim _usuario As New UsuarioMPP
        paramMensaje.ID = paramRow(0)
        paramMensaje.Asunto = paramRow(1)
        paramMensaje.Texto = paramRow(2)
        paramMensaje.Emisor = _usuario.consultarUsuarioLigero(CInt(paramRow(3)))
        paramMensaje.Receptor = _usuario.consultarUsuarioLigero(CInt(paramRow(4)))
        paramMensaje.Leido = paramRow(5)
        paramMensaje.FechaHora = paramRow(6)
        paramMensaje.BL_Emisor = paramRow(7)
        paramMensaje.BL_Receptor = paramRow(8)
    End Sub
End Class
