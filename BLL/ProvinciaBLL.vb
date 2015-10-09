Public Class ProvinciaBLL
    Public Function obtenerProvincia() As List(Of ENTIDADES.Provincia)
        Try
            Return (New Mapper.ProvinciaMPP).obtenerProvincia
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProvincia(ByVal paramProvincia As ENTIDADES.Provincia) As ENTIDADES.Provincia
        Try
            Return (New Mapper.ProvinciaMPP).obtenerProvincia(paramProvincia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
