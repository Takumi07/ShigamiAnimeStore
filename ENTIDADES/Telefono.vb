Public Class Telefono
    Public Enum EnumtipoTelefono
        Particular = 1
        Celular = 2
        Trabajo = 3
        Otro = 4
    End Enum

    'Private _codArea As Integer
    'Public Property CodArea() As Integer
    '    Get
    '        Return _codArea
    '    End Get
    '    Set(ByVal value As Integer)
    '        _codArea = value
    '    End Set
    'End Property

    'Private _codPais As Integer
    'Public Property CodPais() As Integer
    '    Get
    '        Return _codPais
    '    End Get
    '    Set(ByVal value As Integer)
    '        _codPais = value
    '    End Set
    'End Property

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _numero As Integer
    Public Property Numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value
        End Set
    End Property

    Private _tipoTelefono As Telefono.EnumtipoTelefono
    Public Property tipoTelefono() As Telefono.EnumtipoTelefono
        Get
            Return _tipoTelefono
        End Get
        Set(ByVal value As Telefono.EnumtipoTelefono)
            _tipoTelefono = value
        End Set
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        If Me.Numero = DirectCast(obj, Entidades.Telefono).Numero Then
            Return True
        Else
            Return False
        End If
    End Function




End Class
