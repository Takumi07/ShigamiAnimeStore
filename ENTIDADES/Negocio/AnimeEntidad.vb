Public Class AnimeEntidad
    Inherits Entidades.ProductoEntidad

    Private vN_DVD As Integer
    Public Property N_DVD() As Integer
        Get
            Return vN_DVD
        End Get
        Set(ByVal value As Integer)
            vN_DVD = value
        End Set
    End Property

    Private VCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return VCantidad
        End Get
        Set(ByVal value As Integer)
            VCantidad = value
        End Set
    End Property

    Private vTemporada_Completa As Boolean
    Public Property Temporada_Completa() As Boolean
        Get
            Return vTemporada_Completa
        End Get
        Set(ByVal value As Boolean)
            vTemporada_Completa = value
        End Set
    End Property
End Class