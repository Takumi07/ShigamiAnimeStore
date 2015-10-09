Public Class DireccionMPP

    Public Sub AltaDireccion(ByVal paramDireccion As Entidades.Direccion)
        Try
            Dim MisParametros As New Hashtable
            paramDireccion.ID = DAL.Conexion.ObtenerID("Direccion", "ID_Direccion")
            MisParametros.Add("@ID_Direccion", paramDireccion.ID)
            MisParametros.Add("@Calle", paramDireccion.Calle)
            MisParametros.Add("@Altura", paramDireccion.Altura)
            MisParametros.Add("@piso", paramDireccion.Piso)
            MisParametros.Add("@Departamento", paramDireccion.Departamento)
            MisParametros.Add("@Localidad", paramDireccion.Localidad)
            MisParametros.Add("@ID_Provincia", paramDireccion.Provincia.ID)
            MisParametros.Add("@Cod_Postal", paramDireccion.CodigoPostal)
            DAL.Conexion.ExecuteNonQuery("AltaDireccion", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
