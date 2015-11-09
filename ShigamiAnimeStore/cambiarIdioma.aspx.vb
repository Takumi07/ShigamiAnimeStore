Public Class cambiarIdioma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Permite al usuario seleccionar otro idioma que se encuentre dado de alta en el aplicativo.
        If validaciones.validarPagina(Me) = False Then
            Response.Redirect("error.aspx")
        End If
        If Not IsPostBack Then
            obtenerIdiomas()
            Me.ddl_idiomas.SelectedValue = DirectCast(Session("Usuario"), ENTIDADES.Usuario).Idioma.Nombre
        End If

    End Sub

    Private Sub obtenerIdiomas()
        Dim _bllIdioma As New BLL.IdiomaBLL
        Dim _idiomas As List(Of Entidades.Idioma) = _bllIdioma.ListarIdiomas
        Me.ddl_Idiomas.DataSource = _idiomas
        Me.ddl_Idiomas.DataBind()
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Try
            'El usuario seleccionó el idioma y actualiza el idioma que desea que se visualice el sistema.
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim _bllidioma As New BLL.IdiomaBLL
            Dim MiUsuarioEntidad As ENTIDADES.Usuario = DirectCast(Session("Usuario"), ENTIDADES.Usuario)
            Dim _idioma As ENTIDADES.Idioma = _bllidioma.consultarIdioma(Me.ddl_idiomas.SelectedItem.ToString)
            MiUsuarioEntidad.Idioma = _bllidioma.Cargar(_idioma)
            DirectCast(Session("Usuario"), ENTIDADES.Usuario).Idioma = MiUsuarioEntidad.Idioma
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            MiUsuarioBLL.CambiarIdioma(MiUsuarioEntidad)
            Response.Redirect("index.aspx")
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub
End Class