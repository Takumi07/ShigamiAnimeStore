Public Class MangaEntidad
    Inherits Entidades.ProductoEntidad

    Private vFec_Salida_PTomo As DateTime
    Public Property Fec_Salida_PTomo() As DateTime
        Get
            Return vFec_Salida_PTomo
        End Get
        Set(ByVal value As DateTime)
            vFec_Salida_PTomo = value
        End Set
    End Property

    Private vN_Tomo As Integer
    Public Property N_Tomo() As Integer
        Get
            Return vN_Tomo
        End Get
        Set(ByVal value As Integer)
            vN_Tomo = value
        End Set
    End Property

End Class