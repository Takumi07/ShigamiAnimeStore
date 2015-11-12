Imports ENTIDADES
Imports MAPPER

Public Class AnimeBLL
    Inherits ProductoBLL

#Region "ABM Anime"
    Public Overrides Sub Guardar(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            MyBase.Guardar(paramProductoEntidad)
            Dim MiAnimeDAL As New MAPPER.AnimeMPP
            MiAnimeDAL.NuevoProducto(paramProductoEntidad)
        Catch ExepcionAltaProducto As ExepcionAltaProducto
            Throw New ExepcionAltaAnime
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionAltaAnime
        End Try
    End Sub

    Public Overrides Sub Modificar(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            MyBase.Modificar(paramProductoEntidad)
            Dim MiAnimeDAL As New MAPPER.AnimeMPP
            MiAnimeDAL.ModificarProducto(paramProductoEntidad)
        Catch ex As ExepcionModificarProducto
            Throw New ExepcionModificarAnime
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionModificarAnime
        End Try
    End Sub

    Public Overrides Sub Baja(ByVal paramProductoEntidad As ProductoEntidad)
        'Es lo ùnico que va a hacer en baja porque solo la TABLA producto contiene el campo de BL.
        Try
            MyBase.Baja(paramProductoEntidad)
        Catch ex As ExepcionEliminarProducto
            Throw New ExepcionElimiarAnime
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Baja, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionElimiarAnime
        End Try
    End Sub
#End Region

End Class

