Public Class Contacto
    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vApellido As String
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property

    Private vMail As String
    Public Property Mail() As String
        Get
            Return vMail
        End Get
        Set(ByVal value As String)
            vMail = value
        End Set
    End Property

    Private vTitulo As String
    Public Property Titulo() As String
        Get
            Return vTitulo
        End Get
        Set(ByVal value As String)
            vTitulo = value
        End Set
    End Property

    Private vMensaje As String
    Public Property Mensaje() As String
        Get
            Return vMensaje
        End Get
        Set(ByVal value As String)
            vMensaje = value
        End Set
    End Property

    Private vTelefono As Integer
    Public Property Telefono() As Integer
        Get
            Return vTelefono
        End Get
        Set(ByVal value As Integer)
            vTelefono = value
        End Set
    End Property

    Private _contestado As Boolean
    Public Property Contestado() As Boolean
        Get
            Return _contestado
        End Get
        Set(ByVal value As Boolean)
            _contestado = value
        End Set
    End Property

    Private _respuesta As String
    Public Property Respuesta() As String
        Get
            Return _respuesta
        End Get
        Set(ByVal value As String)
            _respuesta = value
        End Set
    End Property


    Public ReadOnly Property NombreCompleto() As String
        Get
            Return Me.Apellido & ", " & Me.Nombre
        End Get
    End Property

End Class
