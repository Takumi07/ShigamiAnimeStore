Public Class Persona

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _direccion As Entidades.Direccion
    Public Property Direccion() As Entidades.Direccion
        Get
            Return _direccion
        End Get
        Set(ByVal value As Entidades.Direccion)
            _direccion = value
        End Set
    End Property

    Private _dni As Integer
    Public Property DNI() As Integer
        Get
            Return _dni
        End Get
        Set(ByVal value As Integer)
            _dni = value
        End Set
    End Property

    Private _fechaNacimienot As String
    Public Property FechaNacimiento() As String
        Get
            Return _fechaNacimienot
        End Get
        Set(ByVal value As String)
            _fechaNacimienot = value
        End Set
    End Property

    Private _mail As String
    Public Property Mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property

    Private _nacionalidad As Nacionalidad
    Public Property Nacionalidad() As Nacionalidad
        Get
            Return _nacionalidad
        End Get
        Set(ByVal value As Nacionalidad)
            _nacionalidad = value
        End Set
    End Property


    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Private _telefono As List(Of Entidades.Telefono)
    Public Property Telefono() As List(Of Entidades.Telefono)
        Get
            Return _telefono
        End Get
        Set(ByVal value As List(Of Entidades.Telefono))
            _telefono = value
        End Set
    End Property

    Private _imagen As String
    Public Property Imagen() As String
        Get
            Return _imagen
        End Get
        Set(ByVal value As String)
            _imagen = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Me.Apellido & ", " & Me.Nombre
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If Me.ID = DirectCast(obj, Entidades.Persona).ID Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
