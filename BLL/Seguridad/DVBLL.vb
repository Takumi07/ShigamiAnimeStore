Public Class DVBLL
    Public Shared Function VerificarIntegridad()
        Try
            If MAPPER.DVMPP.VerificarIntegridad = False Then
                Throw New ExepcionIntegridadCorrupta
            Else
                Return True
            End If
        Catch ex As ExepcionIntegridadCorrupta
            Throw New ExepcionIntegridadCorrupta
        Catch ex As Exception
            Throw New ExepcionIntegridadCorrupta
        End Try
    End Function


    Public Shared Function DefinirErrorIntegridad() As List(Of ENTIDADES.DVEntidades)
        Try
            Return MAPPER.DVMPP.DefinirErrorIntegridad()
        Catch ex As Exception

        End Try
    End Function

    Public Shared Function RepararIntegridad()
        Try
            MAPPER.DVMPP.RepararIntegridad()
        Catch ex As Exception

        End Try
    End Function


End Class

