Public Class Boletin
    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _cuerpo As String
    Public Property Cuerpo() As String
        Get
            Return _cuerpo
        End Get
        Set(ByVal value As String)
            _cuerpo = value
        End Set
    End Property

    Private _tipoBoletin As TipoBoletin
    Public Property TipoBoletin() As TipoBoletin
        Get
            Return _tipoBoletin
        End Get
        Set(ByVal value As TipoBoletin)
            _tipoBoletin = value
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

    Private _listadosuscriptores As List(Of Entidades.Usuario)
    Public Property Suscriptores() As List(Of Entidades.Usuario)
        Get
            Return _listadosuscriptores
        End Get
        Set(ByVal value As List(Of Entidades.Usuario))
            _listadosuscriptores = value
        End Set
    End Property

End Class

Public Enum TipoBoletin
    Noticias = 1
    Ventas = 2
End Enum
