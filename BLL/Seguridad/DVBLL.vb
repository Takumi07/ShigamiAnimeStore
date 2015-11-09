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
End Class

