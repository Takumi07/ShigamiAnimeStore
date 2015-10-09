Public Class SesionBLL

    Private Sub New()

    End Sub

    Private Shared ReadOnly _current As SesionBLL = New SesionBLL
    Public Shared Function Current() As SesionBLL

        Return (_current)
    End Function


    Sub Inicializar(ByVal ParamUsuario As Entidades.Usuario)
        Me.vUsuario = ParamUsuario
    End Sub



    Private vUsuario As Entidades.Usuario
    Public ReadOnly Property Usuario() As Entidades.Usuario
        Get
            Return vUsuario
        End Get
    End Property


    Sub Finalizar()
        BLL.BitacoraBLL.Alta(BLL.SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Logout, "Logout Correcto")
        Me.vUsuario = Nothing
    End Sub

End Class
