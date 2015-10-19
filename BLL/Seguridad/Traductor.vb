Option Compare Text
Imports ENTIDADES
Imports MAPPER



Public Class Traductor
    Public Shared Function TraducirMensaje(ByVal paramCodigo As String)
        Try
            Dim MiPalabra As New Palabra
            MiPalabra.Codigo = paramCodigo
            For Each MiTraduccion As Palabra In SesionBLL.Current.Usuario.Idioma.Palabras
                If MiTraduccion.Codigo = paramCodigo Then
                    Return MiTraduccion.Traduccion
                End If
            Next
        Catch ex As Exception
            'BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
        End Try
    End Function

End Class
