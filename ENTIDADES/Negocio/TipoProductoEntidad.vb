Public Class TipoProductoEntidad

    Public Sub New()

    End Sub


    Public Sub New(ByVal paramID As Integer)
        Me.vID_TipoProducto = paramID
    End Sub


    Private vID_TipoProducto As Integer
    Public Property ID_TipoProducto() As Integer
        Get
            Return vID_TipoProducto
        End Get
        Set(ByVal value As Integer)
            vID_TipoProducto = value
        End Set
    End Property

    Private vDescripcion As String
    Public Property Descripcion() As String
        Get
            Return vDescripcion
        End Get
        Set(ByVal value As String)
            vDescripcion = value
        End Set
    End Property
End Class

