Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub btn_modificarPass_Click(sender As Object, e As EventArgs) Handles btn_modificarPass.Click
        Try
            'validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim _entidadUsuario As Entidades.Usuario = DirectCast(Session("Usuario"), Entidades.Usuario)
            If BLL.EncriptarBLL.EncriptarPass(Me.txt_passwordActual.Text) = _entidadUsuario.Password Then
                If Me.txt_nuevoPassword.Text.Length >= 6 Then
                    If Me.txt_nuevoPassword.Text = Me.txt_repetirPassword.Text Then
                        Dim _usuariobll As New BLL.UsuarioBLL
                        _entidadUsuario.Password = BLL.EncriptarBLL.EncriptarPass(Me.txt_nuevoPassword.Text)
                        _usuariobll.cambiarPassword(_entidadUsuario)
                    Else
                        Throw New BLL.PasswordRepetidoNoCoincideException
                    End If
                Else
                    Throw New BLL.PasswordCortoException
                End If
            Else
                Throw New BLL.PasswordIncorrectoException
            End If
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PasswordCortoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PasswordRepetidoNoCoincideException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PasswordIncorrectoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub


    Private Sub cambiarPassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If validaciones.validarPagina(Me) = False Then
        'Response.Redirect("error.aspx")
        'End If

    End Sub


End Class