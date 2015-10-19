Imports ENTIDADES

Public Class ProductoEntidad
    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
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

    Private vStock As Integer
    Public Property Stock() As Integer
        Get
            Return vStock
        End Get
        Set(ByVal value As Integer)
            vStock = value
        End Set
    End Property

    Private vFecha_Alta_Sistema As DateTime
    Public Property Fecha_Alta_Sistema() As DateTime
        Get
            Return vFecha_Alta_Sistema
        End Get
        Set(ByVal value As DateTime)
            vFecha_Alta_Sistema = value
        End Set
    End Property

    Private vFecha_Salida As DateTime
    Public Property Fecha_Salida() As DateTime
        Get
            Return vFecha_Salida
        End Get
        Set(ByVal value As DateTime)
            vFecha_Salida = value
        End Set
    End Property

    Private vFecha_Arribo_Sucursal As DateTime
    Public Property Fecha_Arribo_Sucursal() As DateTime
        Get
            Return vFecha_Arribo_Sucursal
        End Get
        Set(ByVal value As DateTime)
            vFecha_Arribo_Sucursal = value
        End Set
    End Property

    Private vPrecio As Double
    Public Property Precio() As Double
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Double)
            vPrecio = value
        End Set
    End Property

    Private vNovedad As Integer
    Public Property Novedad() As Integer
        Get
            Return vNovedad
        End Get
        Set(ByVal value As Integer)
            vNovedad = value
        End Set
    End Property

    Private vFlujoVenta As Integer
    Public Property FlujoVenta() As Integer
        Get
            Return vFlujoVenta
        End Get
        Set(ByVal value As Integer)
            vFlujoVenta = value
        End Set
    End Property

    Private vGenero As GeneroEntidad
    Public Property Genero() As GeneroEntidad
        Get
            Return vGenero
        End Get
        Set(ByVal value As GeneroEntidad)
            vGenero = value
        End Set
    End Property


    Private vTipoProducto As TipoProductoEntidad
    Public Property TipoProducto() As TipoProductoEntidad
        Get
            Return vTipoProducto
        End Get
        Set(ByVal value As TipoProductoEntidad)
            vTipoProducto = value
        End Set
    End Property

    Private vBL As Boolean
    Public Property BL() As Boolean
        Get
            Return vBL
        End Get
        Set(ByVal value As Boolean)
            vBL = value
        End Set
    End Property

#Region "Agregado"
    Private vCantidadComprada As Integer
    Public Property CantidadComprada() As Integer
        Get
            Return vCantidadComprada
        End Get
        Set(ByVal value As Integer)
            vCantidadComprada = value
        End Set
    End Property

    Public ReadOnly Property PrecioFinal() As Double
        Get
            Return Me.vPrecio * Me.vCantidadComprada
        End Get
    End Property

#End Region
End Class

