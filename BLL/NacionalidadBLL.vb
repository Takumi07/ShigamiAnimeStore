Public Class NacionalidadBLL
    Public Function obtenerNacionalidad() As List(Of ENTIDADES.Nacionalidad)
        Try
            Return (New Mapper.NacionalidadMPP).obtenerNacionalidad
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNacionalidad(ByVal paramNacionalidad As ENTIDADES.Nacionalidad) As ENTIDADES.Nacionalidad
        Try
            Return (New Mapper.NacionalidadMPP).obtenerNacionalidad(paramNacionalidad)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
