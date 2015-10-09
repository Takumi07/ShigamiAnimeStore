Public MustInherit Class PermisoBase
    Private _Id As Integer
    Public Property ID() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _url As String
    Public Property URL() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property


    Public MustOverride Function agregarHijo(ByVal permiso As PermisoBase) As Boolean

    Public MustOverride Function tieneHijos() As Boolean

    Public MustOverride Function ObtenerHijos() As List(Of PermisoBase)



    Public Overrides Function Equals(obj As Object) As Boolean
        If Not obj Is Nothing Then
            If TypeOf obj Is PermisoBase Then
                ' comparacion contra un objeto PermisoBase
                Return Me.Nombre.Equals(CType(obj, PermisoBase).Nombre)
            ElseIf TypeOf obj Is String Then
                ' comparacion contra un String
                Return Me.Nombre.Equals(obj)
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Overrides Function ToString() As String
        Return Nombre.ToString
    End Function
End Class
