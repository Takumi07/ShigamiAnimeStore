Public Class ContactoBLL
    Dim _mpp As New Mapper.ContactoMPP
    Public Sub EnviarConsulta(ByVal paramContacto As Entidades.Contacto)
        Try
            Dim MiContactoMPP As New Mapper.ContactoMPP
            MiContactoMPP.EnviarConsulta(paramContacto)
            ' BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Consulta Enviada")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function obtenerConsulta(ByVal paramContacto As Entidades.Contacto) As Entidades.Contacto
        Try
            Return _mpp.obtenerMensajeContacto(paramContacto)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerConsultas() As List(Of Entidades.Contacto)
        Try
            Return _mpp.obtenerMensajesContacto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub responderConsulta(ByVal paramContacto As Entidades.Contacto)
        Try
            _mpp.responderConsulta(paramContacto)
            MailingBLL.enviarMailRespuesta(_mpp.obtenerMensajeContacto(paramContacto))
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Respuesta Enviada")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
