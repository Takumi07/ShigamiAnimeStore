Imports ENTIDADES
Imports MAPPER
Public Class TipoProductoBLL
    ''' <summary> Método que devuelve todos los Tipos de Productos </summary>
    Public Function ListarTipoProducto() As List(Of TipoProductoEntidad)
        Try
            Return (New MAPPER.TipoProductoMPP).ListarTipoProducto
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionRecuperarInformacion
        End Try
    End Function
End Class
