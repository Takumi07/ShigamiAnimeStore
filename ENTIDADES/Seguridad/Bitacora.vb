Public Class Bitacora

    Public Enum tipoOperacionBitacora
        Alta = 1
        Baja = 2
        Modificacion = 3
        Login = 4
        Logout = 5
        Errores = 6
        Bloqueo = 7
        Desbloqueo = 8
        Backup = 9
        Restore = 10
    End Enum

    Public Enum tipoPrioridadBitacora
        Alta = 1
        Media = 2
        Baja = 3
        Critica = 4
    End Enum

    Private _IDBitacora As Integer
    Public Property ID() As Integer
        Get
            Return _IDBitacora
        End Get
        Set(ByVal value As Integer)
            _IDBitacora = value
        End Set
    End Property

    Private _Fecha As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Private _Prioridad As tipoOperacionBitacora
    Public Property Prioridad() As tipoOperacionBitacora
        Get
            Return _Prioridad
        End Get
        Set(ByVal value As tipoOperacionBitacora)
            _Prioridad = value
        End Set
    End Property

    Private _TipoOperacion As tipoOperacionBitacora
    Public Property TipoOperacion() As tipoOperacionBitacora
        Get
            Return _TipoOperacion
        End Get
        Set(ByVal value As tipoOperacionBitacora)
            _TipoOperacion = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    'Hay que cambiarlo por entidad Usuario
    Private _Usuario As Entidades.Usuario
    Public Property Usuario() As Entidades.Usuario
        Get
            Return _Usuario
        End Get
        Set(ByVal value As Entidades.Usuario)
            _Usuario = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal _usuario As Entidades.Usuario, ByVal _prioridad As tipoPrioridadBitacora, ByVal _tipoOperacion As tipoOperacionBitacora, ByVal _descripcion As String)
        Me.Usuario = _usuario
        Me.Prioridad = _prioridad
        Me.TipoOperacion = _tipoOperacion
        Me.Descripcion = _descripcion
    End Sub
End Class
