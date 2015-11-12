Imports ENTIDADES

Public Class GeneroBLL
    ''' <summary> Método que devuelve todos los generos </summary>
    Public Function ListarGeneros() As List(Of GeneroEntidad)
        Try
            Return (New MAPPER.GeneroMPP).ListarGeneros
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
        End Try
    End Function



    Public Sub GuardarGenero(ByVal paramGeneroEntidad As GeneroEntidad)
        Try
            Dim MiGeneroDAL As New MAPPER.GeneroMPP

            If MiGeneroDAL.VerfificarGeneroExiste(paramGeneroEntidad) = True Then
                Throw New ExepcionGeneroYaExiste
            End If

            paramGeneroEntidad.BL = False
            MiGeneroDAL.GuardarGenero(paramGeneroEntidad)
        Catch ex As ExepcionGeneroYaExiste
            'Catcharlo donde haga el abm
            Throw ex
        Catch ex As Exception
        End Try
    End Sub


    Public Sub ModificarGenero(ByVal paramGeneroEntidad As GeneroEntidad)
        Try
            Dim MiGeneroDAL As New MAPPER.GeneroMPP
            paramGeneroEntidad.BL = False
            MiGeneroDAL.ModificarGenero(paramGeneroEntidad)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub EliminarGenero(ByVal paramGeneroEntidad As GeneroEntidad)
        Try
            Dim MiGeneroDAL As New MAPPER.GeneroMPP
            'Le doy de baja.
            paramGeneroEntidad.BL = True
            MiGeneroDAL.BajaGenero(paramGeneroEntidad)
        Catch ex As Exception
        End Try
    End Sub



End Class
