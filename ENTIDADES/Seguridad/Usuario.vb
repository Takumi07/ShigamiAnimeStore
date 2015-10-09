Public Class Usuario
    Private _IDUsuario As Integer
    Public Property ID() As Integer
        Get
            Return _IDUsuario
        End Get
        Set(ByVal value As Integer)
            _IDUsuario = value
        End Set
    End Property

    Private _NombreUsuario As String
    Public Property NombreUsuario() As String
        Get
            Return _NombreUsuario
        End Get
        Set(ByVal value As String)
            _NombreUsuario = value
        End Set
    End Property

    Private _Password As String
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Private _Bloqueado As Boolean
    Public Property Bloqueado() As Boolean
        Get
            Return _Bloqueado
        End Get
        Set(ByVal value As Boolean)
            _Bloqueado = value
        End Set
    End Property

    Private _BL As Boolean
    Public Property BL() As Boolean
        Get
            Return _BL
        End Get
        Set(ByVal value As Boolean)
            _BL = value
        End Set
    End Property

    Private _Patente As Entidades.PermisoCompuesto
    Public Property Perfil() As Entidades.PermisoCompuesto
        Get
            Return _Patente
        End Get
        Set(ByVal value As Entidades.PermisoCompuesto)
            _Patente = value
        End Set
    End Property

    Private _Idioma As Entidades.Idioma
    Public Property Idioma() As Entidades.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Entidades.Idioma)
            _Idioma = value
        End Set
    End Property

    Private _Intentos As Integer
    Public Property Intentos() As Integer
        Get
            Return _Intentos
        End Get
        Set(ByVal value As Integer)
            _Intentos = value
        End Set
    End Property

    Private _Editable As Boolean
    Public Property Editable() As Boolean
        Get
            Return _Editable
        End Get
        Set(ByVal value As Boolean)
            _Editable = value
        End Set
    End Property

    Private _fechaAlta As Date
    Public Property FechaAlta() As Date
        Get
            Return _fechaAlta
        End Get
        Set(ByVal value As Date)
            _fechaAlta = value
        End Set
    End Property




    Private _persona As Persona
    Public Property Persona() As Persona
        Get
            Return _persona
        End Get
        Set(ByVal value As Persona)
            _persona = value
        End Set
    End Property

    'PARA MI ESTO ESTA DE MAS
    Private _Correo As String
    Public Property Correo() As String
        Get
            Return _Correo
        End Get
        Set(ByVal value As String)
            _Correo = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return Me.NombreUsuario
    End Function

End Class
