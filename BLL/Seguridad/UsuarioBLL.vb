Public Class UsuarioBLL
    Public Function Login(ByVal NombreUsuario As String, ByVal Password As String) As Entidades.Usuario
        Dim _Usuario As New Entidades.Usuario
        _Usuario.NombreUsuario = NombreUsuario
        _Usuario.Password = EncriptarBLL.EncriptarPass(Password)
        'Aca falta comprobar la integridad de la base de datos
        Try
            'Existe el usuario?
            If Me.chequearUsuario(_Usuario.NombreUsuario) = False Then
                Throw New UsuarioInexistenteException
            Else

                'Esta bloquedo?
                If Me.chequearBloqueado(_Usuario.NombreUsuario) = True Then
                    Throw New UsuarioBloqueadoException
                Else
                    'Esta bien la contraseña?
                    If Me.chequearContraseña(_Usuario.NombreUsuario, _Usuario.Password) = False Then
                        Throw New PasswordIncorrectoException
                    Else
                        'Resetear los intentos
                        _Usuario = (New Mapper.UsuarioMPP).consultarUsuario(_Usuario.NombreUsuario)
                        Me.resetearIntentos(_Usuario)
                        BLL.BitacoraBLL.Alta(_Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Login, "Login Correcto")
                        Return _Usuario
                    End If
                End If
            End If
        Catch ex As UsuarioInexistenteException
            Throw New UsuarioInexistenteException
        Catch ex As UsuarioBloqueadoException
            Throw New UsuarioBloqueadoException
        Catch ex As PasswordIncorrectoException
            Throw New PasswordIncorrectoException
        Catch ex As Exception
            Throw New Exception
        End Try
    End Function


    Public Sub cambiarPassword(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim _mppUsuario As New Mapper.UsuarioMPP
            _mppUsuario.cambiarPassword(paramUsuario)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Se modifico la contraseña del usuario " & paramUsuario.NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function chequearUsuario(paramNombreUsuario As String) As Boolean
        Try
            Return (New Mapper.UsuarioMPP).chequearUsuario(paramNombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chequearContraseña(paramNombreUsuario As String, paramContraseña As String) As Boolean
        Try
            If (New Mapper.UsuarioMPP).chequearContraseña(paramNombreUsuario, paramContraseña) = True Then
                Return True
            Else
                Me.actualizarIntentos(paramNombreUsuario)
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
      
    End Function

    Public Function chequearBloqueado(paramNombreUsuario As String) As Boolean
        Try
            Return (New Mapper.UsuarioMPP).chequearBloqueado(paramNombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub actualizarIntentos(ByVal paramNombreUsuario As String)
        Try
            Dim _usuario As Entidades.Usuario = (New Mapper.UsuarioMPP).consultarUsuario(paramNombreUsuario)
            _usuario.Intentos += 1
            Dim _usu As New Mapper.UsuarioMPP
            If _usuario.Intentos >= 3 Then
                Me.BloquearUsuario(_usuario)
            End If
            _usu.ActualizarIntentos(_usuario)
            BLL.BitacoraBLL.Alta(_usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Login, "Intento Fallido de Login")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub resetearIntentos(ByVal paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.Intentos = 0
            Dim _usu As New Mapper.UsuarioMPP
            _usu.ActualizarIntentos(paramUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarUsuarios() As List(Of Entidades.Usuario)
        Try
            Return (New Mapper.UsuarioMPP).listarUsuarios()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramNombreUsuario As String) As Entidades.Usuario
        Try
            Return (New Mapper.UsuarioMPP).consultarUsuario(paramNombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramIDUsuario As Integer) As Entidades.Usuario
        Try
            Return (New Mapper.UsuarioMPP).consultarUsuario(paramIDUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function consultarUsuario(ByVal paramUsuario As Entidades.Usuario, ByVal paramPersona As Entidades.Persona, ByVal paramActivo As Integer) As List(Of Entidades.Usuario)
        Try
            Dim _mppusuario As New Mapper.UsuarioMPP
            If paramUsuario Is Nothing And paramPersona Is Nothing And paramActivo = 2 Then
                'NO TIENE NADA
                Return _mppusuario.listarUsuarios()
            ElseIf paramUsuario Is Nothing And paramPersona Is Nothing And (paramActivo = 1 Or paramActivo = 0) Then
                'TIENE SOLO EL ESTADO
                Dim _bool As Boolean = CBool(paramActivo)
                Return _mppusuario.consultarUsuario(_bool)
            ElseIf paramUsuario Is Nothing And Not paramPersona Is Nothing And paramActivo = 2 Then
                'TIENE LA PERSONA
                Return _mppusuario.consultarUsuario(paramPersona)
            ElseIf paramUsuario Is Nothing And Not paramPersona Is Nothing And (paramActivo = 1 Or paramActivo = 0) Then
                'TIENE LA PERSONA Y EL ESTADO
                Dim _bool As Boolean = CBool(paramActivo)
                Return _mppusuario.consultarUsuario(paramPersona, _bool)
            ElseIf Not paramUsuario Is Nothing And paramPersona Is Nothing And paramActivo = 2 Then
                'TIENE EL USUARIO
                Return _mppusuario.consultarUsuario(paramUsuario)
            ElseIf Not paramUsuario Is Nothing And paramPersona Is Nothing And (paramActivo = 1 Or paramActivo = 0) Then
                'TIENE EL USUARIO y EL ESTADO
                Dim _bool As Boolean = CBool(paramActivo)
                Return _mppusuario.consultarUsuario(paramUsuario, _bool)
            ElseIf Not paramUsuario Is Nothing And Not paramPersona Is Nothing And paramActivo = 2 Then
                'TIENE EL USUARIO Y LA PERSONA
                Return _mppusuario.consultarUsuario(paramUsuario, paramPersona)
            ElseIf Not paramUsuario Is Nothing And Not paramPersona Is Nothing And (paramActivo = 1 Or paramActivo = 0) Then
                'TIENE EL USUARIO, LA PERSONA y EL ESTADO
                Dim _bool As Boolean = CBool(paramActivo)
                Return _mppusuario.consultarUsuario(paramUsuario, paramPersona, _bool)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub BloquearUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            _usu.bloquearUsuario(paramUsuario)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Bloqueo, "Se bloqueo el usuario " & paramUsuario.NombreUsuario)
            '     MailingBLL.enviarMailBloqueado(paramUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub desbloquearUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            _usu.desbloquearUsuario(paramUsuario)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Desbloqueo, "Se desbloqueo el usuario " & paramUsuario.NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub bajaUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            _usu.bajaUsuario(paramUsuario)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Baja, "Se dio de baja el usuario " & paramUsuario.NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub altaUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            If _usu.chequearUsuario(paramUsuario.NombreUsuario) = False Then
                Dim PassparaMail As String
                PassparaMail = paramUsuario.Password
                paramUsuario.Password = EncriptarBLL.EncriptarPass(paramUsuario.Password)
                _usu.altaUsuario(paramUsuario)

                'COMENTADO PARA QUE ANDE EN LA FACULTAD
                'MailingBLL.enviarMailRegistroUsuario(paramUsuario, PassparaMail)
                ' BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se dio de alta el usuario " & paramUsuario.NombreUsuario)
            Else
                Throw New UsuarioDuplicadoException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub altaUsuarioSimple(paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            If _usu.chequearUsuario(paramUsuario.NombreUsuario) = False Then
                Dim PassparaMail As String
                PassparaMail = paramUsuario.Password
                paramUsuario.Password = EncriptarBLL.EncriptarPass(paramUsuario.Password)
                _usu.altaUsuario(paramUsuario)
                '  MailingBLL.enviarMailRegistroUsuario(paramUsuario, PassparaMail)
                ' BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se dio de alta el usuario " & paramUsuario.NombreUsuario)
            Else
                Throw New UsuarioDuplicadoException
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificarUsuario(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            _usu.modificarUsuario(paramUsuario)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Se modifico el usuario " & paramUsuario.NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CambiarIdioma(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim MiUsuarioMPP As New Mapper.UsuarioMPP
            MiUsuarioMPP.CambiarIdioma(paramUsuario)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Se modifico el idioma del usuario " & paramUsuario.NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RecuperarContraseña(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New Mapper.UsuarioMPP
            Dim PassparaMail As String
            PassparaMail = EncriptarBLL.generarCodigoPassword()
            paramUsuario.Password = EncriptarBLL.EncriptarPass(PassparaMail)
            _usu.modificarUsuario(paramUsuario)
            MailingBLL.enviarMailRecupero(paramUsuario, PassparaMail)
            BLL.BitacoraBLL.Alta(BLL.SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Cambio de Contraseña")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
