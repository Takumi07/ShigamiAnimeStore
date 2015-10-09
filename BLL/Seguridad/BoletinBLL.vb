Public Class BoletinBLL
    Private Shared _mapeador As New Mapper.BoletinMPP

    Public Sub Alta(ByVal _paramBoletin As Entidades.Boletin)
        Try
            _mapeador.altaBoletin(_paramBoletin)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function obtenerSuscriptores(ByVal _paramTipoBoletin As Entidades.TipoBoletin) As List(Of Entidades.Usuario)
        Try
            '   Return _mapeador.obtenerSubscriptores(_paramTipoBoletin)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviarMail(ByVal _paramBoletin As Entidades.Boletin)
        Try
            _paramBoletin.Suscriptores = obtenerSuscriptores(_paramBoletin.TipoBoletin)
            MailingBLL.EnviarNewsletter(_paramBoletin)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class