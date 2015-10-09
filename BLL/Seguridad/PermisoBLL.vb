Public Class PermisoBLL
    Private Shared _mapeador As New Mapper.PermisoMPP

    Public Function ListarFamilias(paramFiltro As Boolean) As List(Of Entidades.PermisoBase)
        Try
            Return _mapeador.listarFamilias(paramFiltro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarFamilias(ByVal paramID As Integer) As Entidades.PermisoCompuesto
        Try
            Return _mapeador.listarFamilias(paramID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Alta(ByVal paramPermiso As Entidades.PermisoBase)
        Try
            If chequearNombrePermiso(paramPermiso.Nombre) = False Then
                _mapeador.AltaPermiso(paramPermiso)
            Else
                Throw New PermisoDuplicadoException
            End If
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se dio de alta el permiso " & paramPermiso.Nombre)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub Modificar(ByVal paramPermiso As Entidades.PermisoBase)
        Try
            _mapeador.ModificarPermiso(paramPermiso)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Se modifico el permiso " & paramPermiso.Nombre)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Baja(ByVal paramID As Integer)
        Try
            _mapeador.BajaPermiso(paramID)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Baja, "Se dio de baja el permiso " & paramID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function obtenerIDPermiso(ByVal paramNombrePermiso As String) As Integer
        Try
            Return _mapeador.obtenerIDPermiso(paramNombrePermiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chequearNombrePermiso(ByVal paramNombrePermiso As String) As Boolean
        Try
            Return _mapeador.chequearNombrePermiso(paramNombrePermiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
