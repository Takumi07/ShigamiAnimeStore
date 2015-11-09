Public Class Contacto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        Try
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            'Permite que una persona se contacte con la empresa.
            Dim MiContacto As New Entidades.Contacto
            MiContacto.Nombre = txt_nombre.Text
            MiContacto.Apellido = txt_Apellido.Text
            MiContacto.Mail = txt_correo.Text
            If txt_telefono.Text = "" Then
                MiContacto.Telefono = 0
            Else
                MiContacto.Telefono = txt_telefono.Text
            End If
            MiContacto.Titulo = txt_Titulo.Text
            MiContacto.Mensaje = txt_Mensaje.Text
            Dim MiContactoBLL As New BLL.ContactoBLL
            MiContactoBLL.EnviarConsulta(MiContacto)
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub
End Class