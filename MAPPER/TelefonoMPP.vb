Public Class TelefonoMPP

    'Ver si esto está bien!!! Porque necesito el ID de la persona
    Public Sub altaTelefonos(ByVal ID_Persona As Integer, ByVal paramTelefonos As List(Of Entidades.Telefono))
        Try
            For Each MiTelefono As Entidades.Telefono In paramTelefonos
                'Primero Alta en Teléfono
                Dim MisParametros As New Hashtable
                MiTelefono.ID = DAL.Conexion.ObtenerID("Telefono", "ID_Telefono")
                MisParametros.Add("@ID_Telefono", MiTelefono.ID)
                MisParametros.Add("@Numero", MiTelefono.Numero)
                MisParametros.Add("@Tipo", MiTelefono.tipoTelefono)
                DAL.Conexion.ExecuteNonQuery("AltaTelefono", MisParametros)

                'Ahora la relación Entre telefono y persona
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@ID_Persona", ID_Persona)
                MisParametros2.Add("@ID_Telefono", MiTelefono.ID)
                DAL.Conexion.ExecuteNonQuery("AltaTelefonoPersona", MisParametros2)
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub





End Class
