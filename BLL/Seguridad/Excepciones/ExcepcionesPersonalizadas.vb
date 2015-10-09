Public MustInherit Class ExcepcionesPersonalizadas
    Inherits Exception
    Public MustOverride Function Mensaje() As String
End Class

Public Class UsuarioBloqueadoException
    Inherits ExcepcionesPersonalizadas
    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "El Usuario se encuentra Bloqueado. Contacte con el Administrador."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 166) ' exp_1
        End If

    End Function

End Class

Public Class IdiomaDuplicadoException
    Inherits ExcepcionesPersonalizadas
    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "Ya se ha registrado un Idioma con ese Nombre. Cambielo e intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 167) ' exp_2
        End If
    End Function

End Class

Public Class aceptoTerminosyCondiciones
    Inherits ExcepcionesPersonalizadas
    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "Debe aceptar los terminos y condiciones para poder registrarse."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 168) ' exp_3
        End If
    End Function

End Class


Public Class IngresarunPermisoException
    Inherits ExcepcionesPersonalizadas
    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "Debe ingresar al menos un permiso para dar de alta al Perfil."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 169) ' exp_4
        End If
    End Function

End Class

Public Class UsuarioInexistenteException
    Inherits ExcepcionesPersonalizadas
    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "El Usuario no se encuentra registrado. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 170) ' exp_5
        End If
    End Function

End Class

Public Class PasswordIncorrectoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "La contraseña ingresada es incorrecta. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 171) ' exp_6
        End If

    End Function

End Class

Public Class PasswordCortoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "La contraseña debe tener al menos 6 carateres. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 172) ' exp_7
        End If
    End Function

End Class

Public Class MailIncorrectoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "El Correo ingresado es incorrecto. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 173) ' exp_8
        End If
    End Function

End Class

Public Class CodigoRecuperoIncorrectoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        ' Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 174) ' exp_9
        Return ""
    End Function

End Class


Public Class UsuarioDuplicadoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "El Usuario ingresado ya se encuentra registrado en el Sistema. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 175) ' exp_10
        End If
    End Function

End Class

Public Class PermisoDuplicadoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "Ya se ha registrado un Permiso con ese Nombre. Cambielo e intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 176) ' exp_11
        End If
    End Function

End Class


Public Class PasswordRepetidoNoCoincideException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "Las contraseñas ingresadas no coinciden entre sí. Intente nuevamente"
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 178) ' exp_13
        End If
    End Function

End Class

Public Class PersonaInexistenteException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "La persona seleccionada no se encuentra registrada en el Sistema. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 179) ' exp_14
        End If
    End Function

End Class

Public Class CamposincompletosException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "Los campos del formulario se encuentran incompletos o en un formato incorrecto. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 180) ' exp_15
        End If
    End Function

End Class




Public Class correorepetidoException
    Inherits ExcepcionesPersonalizadas

    Public Overrides Function Mensaje() As String
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return "El correo electronico ingresado ya se encuentra registrado. Intente nuevamente."
        Else
            Return BLL.IdiomaBLL.traducirMensaje(SesionBLL.Current.Usuario.Idioma, 186) ' exp_16
        End If
    End Function

End Class