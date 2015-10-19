Imports ENTIDADES
Public MustInherit Class ExcepcionBLL
    Inherits Exception
    Public MustOverride Function Mensaje() As String
    Public MustOverride Function Titulo() As String
End Class

#Region "ABM Productos"
Public Class ExepcionAltaProducto
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_48")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_18")
    End Function
End Class

Public Class ExepcionModificarProducto
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_49")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_19")
    End Function
End Class
Public Class ExepcionEliminarProducto
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_50")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_20")
    End Function
End Class
#End Region

#Region "ABM Anime"
Public Class ExepcionAltaAnime
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_48")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_22")
    End Function
End Class

Public Class ExepcionModificarAnime
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_53")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_23")
    End Function
End Class

Public Class ExepcionElimiarAnime
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_51")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_21")
    End Function
End Class
#End Region

#Region "ABM Manga"
Public Class ExepcionAltaManga
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_57")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_25")
    End Function
End Class

Public Class ExepcionModificarManga
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_58")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_26")
    End Function
End Class

Public Class ExepcionElimiarManga
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_59")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_27")
    End Function
End Class
#End Region

#Region "Bitacora"
Public Class ExepcionRecuperarBitacora
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_32")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_13")
    End Function
End Class
#End Region

#Region "Cliente"
Public Class ExepcionEliminarCliente
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_61")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_28")
    End Function
End Class

Public Class ExepcionModificarCliente
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_62")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_28")
    End Function
End Class

Public Class ExepcionClienteExistente
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_63")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_28")
    End Function
End Class

Public Class ExepcionNuevoCliente
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_65")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_28")
    End Function
End Class

Public Class ExepcionDNIVacio
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_75")
    End Function
    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_28")
    End Function
End Class

#End Region

#Region "DígitoVerificador"
Public Class ExepcionIntegridadCorrupta
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        'No tengo conecciòn a la bd porq esta corrupta, le dejo el mensaje en el idioma nativo del aplicativo.
        Return "La integridad de la base de datos es corrupta. Por favor, contacte a un administrador."
    End Function
    Public Overrides Function Titulo() As String
        'No tengo conecciòn a la bd porq esta corrupta, le dejo el mensaje en el idioma nativo del aplicativo.
        Return "Integridad de Base de Datos"
    End Function
End Class
#End Region

#Region "Idioma"
Public Class ExepcionIdiomaNoEditable
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_35")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_16")
    End Function
End Class

Public Class ExepcionBajaIdioma
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_36")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_16")
    End Function
End Class

Public Class ExepcionIdiomaExistente
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_37")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_16")
    End Function
End Class



#End Region

#Region "Genericas"
Public Class ExepcionRecuperarInformacion
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_32")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_29")
    End Function
End Class

Public Class ExepcionGuardarInformacion
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_42")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_29")
    End Function
End Class

Public Class ExepcionModificarInformacion
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_41")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_29")
    End Function
End Class
#End Region

#Region "Promociones"
Public Class ExepcionPromocionProducto
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_66")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_30")
    End Function
End Class

Public Class ExepcionPromocionCliente
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_67")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_30")
    End Function
End Class

Public Class ExepcionPromocionEvento
    Inherits ExcepcionBLL

    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_68")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_30")
    End Function
End Class
#End Region

#Region "Usuario"
Public Class ExepcionDefinirIdioma
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_40")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_16")
    End Function
End Class

Public Class ExepcionBajaUsuario
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_43")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_8")
    End Function
End Class

Public Class ExepcionLogearUsuario
    Inherits ExcepcionBLL
    'No tengo conexiòn a la BD por eso se muestra en el idioma nativo.
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Ocurrio un problema al logear el usuario.")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Usuario")
    End Function
End Class

Public Class ExepcionUsuarioBloqueado
    Inherits ExcepcionBLL
    'No tengo conexiòn a la BD por eso se muestra en el idioma nativo.
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("El usuario intento logearse en estado bloqueado. Por favor contacte a un administrador.")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Usuario Bloqueado")
    End Function
End Class

Public Class ExepcionUsuarioInexistente
    Inherits ExcepcionBLL
    'No tengo conexiòn a la BD por eso se muestra en el idioma nativo.
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Usuario o Clave Incorrectos. Por favor vuelva a intentarlo.")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Usuario Bloqueado")
    End Function
End Class

#End Region

#Region "Perfiles"
Public Class ExepcionPerfilExistente
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_74")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_9")
    End Function
End Class
#End Region

#Region "Eventos"
Public Class ExepcionEventoYaPaso
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_76")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_34")
    End Function
End Class
Public Class ExepcionEventoErrorBaja
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_81")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_34")
    End Function
End Class
#End Region

#Region "Venta"
Public Class ExepcionStockNoDisponible
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_85")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_32")
    End Function

    Public Function MensajeExtendido() As String
        Return Traductor.TraducirMensaje("Mensaje_86")
    End Function

    Private vMiListaProductoEntidad As New List(Of ProductoEntidad)
    Public ReadOnly Property MiListaProductoEntidad() As List(Of ProductoEntidad)
        Get
            Return vMiListaProductoEntidad
        End Get
    End Property

    'Logica para darle al usuario que producto/s agrego de mas stock.

    Public Sub AgregarProducto(paramProducto As ProductoEntidad)
        vMiListaProductoEntidad.Add(paramProducto)
    End Sub
End Class

Public Class ExepcionNoHayProductos
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_87")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_32")
    End Function
End Class
#End Region

#Region "Genero"
Public Class ExepcionGeneroYaExiste
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_88")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_36")
    End Function
End Class
#End Region

#Region "Organizador"
Public Class ExepcionOrganizadoYaExiste
    Inherits ExcepcionBLL
    Public Overrides Function Mensaje() As String
        Return Traductor.TraducirMensaje("Mensaje_92")
    End Function

    Public Overrides Function Titulo() As String
        Return Traductor.TraducirMensaje("Titulo_37")
    End Function
End Class
#End Region