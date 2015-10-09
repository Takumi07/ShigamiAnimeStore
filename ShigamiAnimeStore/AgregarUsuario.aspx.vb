Public Class AgregarUsuario
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If validaciones.validarPagina(Me) = False Then
        'Response.Redirect("error.aspx")
        'End If
        If Not IsPostBack Then
            obtenerFamilias()
            obtenerIdiomas()
            Dim Context As HttpContext = HttpContext.Current
            If Context.Items.Contains("UsuarioaEditar") Then
                Dim _usuarioaEditar As ENTIDADES.Usuario = DirectCast(Context.Items("UsuarioaEditar"), ENTIDADES.Usuario)
                cargarDatos(_usuarioaEditar)
                Session("UseraEditar") = _usuarioaEditar
            Else
                Me.btnAgregar.Visible = True
                Me.btnModificar.Visible = False
            End If
        End If
    End Sub

    Private Sub cargarDatos(ByVal _usuario As ENTIDADES.Usuario)
        Me.txt_nombreUsuario.Text = _usuario.NombreUsuario
        Me.txt_nombreUsuario.ReadOnly = True
        Me.txt_Documento.Text = _usuario.Persona.DNI
        Me.txt_Documento.ReadOnly = True
        Me.passAgregar.Visible = False
        Me.passModificar.Visible = True
        Me.btnAgregar.Visible = False
        Me.btnModificar.Visible = True
        Me.ddl_Idiomas.Items.FindByText(_usuario.Idioma.Nombre).Selected = True
        Me.ddl_Perfiles.Items.FindByText(_usuario.Perfil.Nombre).Selected = True
    End Sub
    Private Sub obtenerFamilias()
        If ddl_Perfiles.Items.Count = 0 Then
            Dim _bllPerfil As New BLL.PermisoBLL
            Dim _perfiles As List(Of Entidades.PermisoBase) = _bllPerfil.ListarFamilias(True)
            Me.ddl_Perfiles.DataSource = _perfiles
            Me.ddl_Perfiles.DataBind()
        End If

    End Sub

    Private Sub obtenerIdiomas()
        If ddl_Idiomas.Items.Count = 0 Then
            Dim _bllIdioma As New BLL.IdiomaBLL
            Dim _idiomas As List(Of Entidades.Idioma) = _bllIdioma.ListarIdiomas
            Me.ddl_Idiomas.DataSource = _idiomas
            Me.ddl_Idiomas.DataBind()
        End If

    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            'validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            If Me.txt_password.Text = Me.txt_repetirPassword.Text Then
                If Me.txt_password.Text.Length >= 6 Then
                    Dim _usu As New Entidades.Usuario
                    Dim _bllIdioma As New BLL.IdiomaBLL
                    Dim _bllPerfil As New BLL.PermisoBLL
                    Dim _bllPersona As New BLL.PersonaBLL
                    Dim _bllUsuario As New BLL.UsuarioBLL
                    _usu.Persona = _bllPersona.obtenerPersonaPorDNI(CInt(Me.txt_Documento.Text))
                    If Not _usu.Persona Is Nothing Then
                        _usu.NombreUsuario = txt_nombreUsuario.Text
                        _usu.Password = txt_password.Text
                        'IDIOMA
                        _usu.Idioma = _bllIdioma.consultarIdioma(Me.ddl_Idiomas.SelectedItem.ToString)
                        'PERMISOS
                        _usu.Perfil = _bllPerfil.ListarFamilias(BLL.PermisoBLL.obtenerIDPermiso(ddl_Perfiles.SelectedValue))
                        _bllUsuario.altaUsuarioSimple(_usu)
                        Response.Redirect("administrarUsuario.aspx")
                    Else
                        Throw New BLL.PersonaInexistenteException
                    End If
                Else
                    Throw New BLL.PasswordCortoException
                End If
            Else
                Throw New BLL.PasswordRepetidoNoCoincideException
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
        Catch ex As BLL.PersonaInexistenteException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.UsuarioDuplicadoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub


    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("index.aspx")
    End Sub

    Protected Sub btn_cancelarModificar_Click(sender As Object, e As EventArgs) Handles btn_cancelarModificar.Click
        Session("UseraEditar") = Nothing
        Response.Redirect("administrarUsuario.aspx")
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Dim _usuarioEditado As Entidades.Usuario = DirectCast(Session("UseraEditar"), Entidades.Usuario)
        Try
            'validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim _usu As New Entidades.Usuario
            Dim _bllIdioma As New BLL.IdiomaBLL
            Dim _bllPerfil As New BLL.PermisoBLL
            Dim _bllUsuario As New BLL.UsuarioBLL
            _usu.Persona = _usuarioEditado.Persona
            _usu.ID = _usuarioEditado.ID
            _usu.NombreUsuario = txt_nombreUsuario.Text
            _usu.Idioma = _bllIdioma.consultarIdioma(Me.ddl_Idiomas.SelectedItem.ToString)
            _usu.Perfil = _bllPerfil.ListarFamilias(BLL.PermisoBLL.obtenerIDPermiso(ddl_Perfiles.SelectedValue))
            If Me.chk_resetPassword.Checked = True Then
                _usu.Password = BLL.EncriptarBLL.EncriptarPass("SHIGAMI2016")
            Else
                _usu.Password = _usuarioEditado.Password
            End If
            _bllUsuario.modificarUsuario(_usu)
            Session("UseraEditar") = Nothing
            Response.Redirect("administrarUsuario.aspx", False)
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PasswordCortoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PasswordRepetidoNoCoincideException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PersonaInexistenteException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.UsuarioDuplicadoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub


End Class