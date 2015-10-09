Public Class PersonaBLL
    Dim _mppPersona As New Mapper.PersonaMPP

    Public Function obtenerPersonaPorDNI(ByVal _dni As Integer) As ENTIDADES.Persona
        Try
            Return _mppPersona.obtenerPersonaPorDNI(_dni)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerPersona(ByVal _id As Integer) As Entidades.Persona
        Try
            Return _mppPersona.obtenerPersona(_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function validarDNI(ByVal _dni As Integer) As Boolean

    End Function

    Public Sub AltaPersona(ByVal parampersona As Entidades.Persona)
        Try
            _mppPersona.AltaPersona(parampersona)
            ' BLL.BitacoraBLL.Alta(BLL.SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se agregó una Persona")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function comprobarCorreo(ByVal paramPersona As Entidades.Persona) As Boolean
        Try
            Return _mppPersona.comprobarCorreo(paramPersona)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
