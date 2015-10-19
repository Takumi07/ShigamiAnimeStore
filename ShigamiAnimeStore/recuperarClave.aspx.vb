Public Class recuperarClave
    Inherits System.Web.UI.Page

    Protected Sub btn_recuperar_Click(sender As Object, e As EventArgs) Handles btn_recuperar.Click
        Try
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            Dim MiUsuarioEntidad As New Entidades.Usuario
            If MiUsuarioBLL.chequearUsuario(txt_usuario.Text) = False Then
                Throw New BLL.UsuarioInexistenteException
            Else
                MiUsuarioEntidad = MiUsuarioBLL.consultarUsuario(txt_usuario.Text)
                If txt_correo.Text <> MiUsuarioEntidad.Persona.Mail Then
                    Throw New BLL.MailIncorrectoException
                Else
                    MiUsuarioBLL.RecuperarContraseña(MiUsuarioEntidad)
                End If
            End If
        Catch ex As BLL.UsuarioInexistenteException
            Me.lbl_TituloError.Text = ex.Mensaje
            Me.lbl_TituloError.Visible = True
        Catch ex As BLL.MailIncorrectoException
            Me.lbl_TituloError.Text = ex.Mensaje
            Me.lbl_TituloError.Visible = True
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try

    End Sub


End Class