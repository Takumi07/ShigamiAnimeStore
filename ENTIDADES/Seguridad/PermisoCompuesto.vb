Public Class PermisoCompuesto
    Inherits PermisoBase


    Public _listaPermisos As New List(Of PermisoBase)
    Public Property ListaPermisosSimple() As List(Of PermisoBase)
        Get
            Return _listaPermisos
        End Get
        Set(ByVal value As List(Of PermisoBase))
            _listaPermisos = value
        End Set
    End Property

    Public Overrides Function agregarHijo(permiso As PermisoBase) As Boolean
        If Not _listaPermisos.Contains(permiso) Then
            Me._listaPermisos.Add(permiso)
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function tieneHijos() As Boolean
        Return True
    End Function

    Public Overrides Function ObtenerHijos() As List(Of PermisoBase)
        Return Me._listaPermisos
    End Function
End Class
