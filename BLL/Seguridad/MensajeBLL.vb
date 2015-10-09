Public Class MensajeBLL

    Public Sub enviarMensaje(ByVal paramMensaje As Entidades.Mensaje)
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            _mensajempp.enviarMensaje(paramMensaje)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se envio un mensaje al usuario " & paramMensaje.Receptor.NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function marcarLeido(ByVal paramMensaje As Entidades.Mensaje, ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            If paramMensaje.Receptor.ID = paramUsuario.ID Then
                Return _mensajempp.marcarLeido(paramMensaje)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub borrarMensaje(ByVal paramMensaje As Entidades.Mensaje, ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            If paramMensaje.Receptor.ID = paramUsuario.ID Then
                _mensajempp.borrarMensaje(paramMensaje, True)
                BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se elimino un mensaje recibido del usuario " & paramMensaje.Receptor.NombreUsuario)
            End If
            If paramMensaje.Emisor.ID = paramUsuario.ID Then
                _mensajempp.borrarMensaje(paramMensaje, False)
                BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se elimino un mensaje enviado del usuario " & paramMensaje.Emisor.NombreUsuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function obtenerCantidadNoLeidos(ByVal paramUsuario As Entidades.Usuario) As Integer
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            Return _mensajempp.obtenerCantidadNoLeidos(paramUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMensajes(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Mensaje)
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            Return _mensajempp.obtenerMensajes(paramUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMensaje(ByVal _idMensaje As Integer) As Entidades.Mensaje
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            Return _mensajempp.obtenerMensaje(_idMensaje)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMensajesRecibidos(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Mensaje)
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            Return _mensajempp.obtenerMensajesRecibidos(paramUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMensajesEnviados(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Mensaje)
        Try
            Dim _mensajempp As New Mapper.MensajeMPP
            Return _mensajempp.obtenerMensajesEnviados(paramUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
