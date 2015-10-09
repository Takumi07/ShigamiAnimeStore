Public Class Mensaje

    Private _IDMensaje As Integer
    Public Property ID() As Integer
        Get
            Return _IDMensaje
        End Get
        Set(ByVal value As Integer)
            _IDMensaje = value
        End Set
    End Property

    Private _asunto As String
    Public Property Asunto() As String
        Get
            Return _asunto
        End Get
        Set(ByVal value As String)
            _asunto = value
        End Set
    End Property

    Private _texto As String
    Public Property Texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property


    Private _emisor As Entidades.Usuario
    Public Property Emisor() As Entidades.Usuario
        Get
            Return _emisor
        End Get
        Set(ByVal value As Entidades.Usuario)
            _emisor = value
        End Set
    End Property

    Private _receptor As Entidades.Usuario
    Public Property Receptor() As Entidades.Usuario
        Get
            Return _receptor
        End Get
        Set(ByVal value As Entidades.Usuario)
            _receptor = value
        End Set
    End Property

    Private _leido As Boolean
    Public Property Leido() As Boolean
        Get
            Return _leido
        End Get
        Set(ByVal value As Boolean)
            _leido = value
        End Set
    End Property

    Private _fechaHora As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return _fechaHora
        End Get
        Set(ByVal value As DateTime)
            _fechaHora = value
        End Set
    End Property

    Private _bl_Emisor As Boolean
    Public Property BL_Emisor() As Boolean
        Get
            Return _bl_Emisor
        End Get
        Set(ByVal value As Boolean)
            _bl_Emisor = value
        End Set
    End Property

    Private _bl_Receptor As Boolean
    Public Property BL_Receptor() As Boolean
        Get
            Return _bl_Receptor
        End Get
        Set(ByVal value As Boolean)
            _bl_Receptor = value
        End Set
    End Property





End Class
