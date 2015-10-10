Imports System.Xml
Public Class Maestra
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            armarMenuBasico()
            If Not IsNothing(Session("Usuario")) Then
                Me.menuPrincipal.Items.Clear()
                ArmarMenuUsuario()
                cargarMenuOpciones()
                Me.ArmarMenuVertical()
                'miMenuVertical.Attributes.Add("class", "col-md-2")
                'miContenidoPagina.Attributes.Add("class", "col-md-10")
            Else
                Me.opcionesUsuario.Visible = False
                'miContenidoPagina.Attributes.Add("class", "col-md-12")
                Me.ArmarMenuVertical()
            End If
        End If
        obtenerIdioma()
    End Sub


    Private Sub obtenerIdioma()
        If Not IsNothing(Session("Usuario")) Then
            'ESTO LO PUEDO NECESITAR PARA TRADUCIR!!!! NO BORRAR!!!!!!!!!

            'Dim MiMenuP As Menu
            'MiMenuP = Me.FindControl("menuVertical")
            'For Each MiMenuItem As MenuItem In MiMenuP.Items
            '    traducir(MiMenuItem)
            '    If MiMenuItem.ChildItems.Count > 0 Then
            '        For Each MiMenuItemHijo As MenuItem In MiMenuItem.ChildItems
            '            traducir(MiMenuItemHijo)
            '        Next
            '    End If
            'Next

            Dim mpContentPlaceHolder As New ContentPlaceHolder
            mpContentPlaceHolder = Me.FindControl("contenidoPagina")
            traducirControl(mpContentPlaceHolder.Controls)
        End If
    End Sub

    Private Sub traducirControl(ByVal paramListaControl As ControlCollection)
        For Each miControl As Control In paramListaControl
            If TypeOf miControl Is Button Then
                traducir(DirectCast(miControl, Button))
            ElseIf TypeOf miControl Is CheckBox Then
                traducir(DirectCast(miControl, CheckBox))
            ElseIf TypeOf miControl Is RadioButton Then
                traducir(DirectCast(miControl, RadioButton))
            ElseIf TypeOf miControl Is Label Then
                traducir(DirectCast(miControl, Label))
            ElseIf TypeOf miControl Is ImageButton Then
                traducir(DirectCast(miControl, ImageButton))
            ElseIf TypeOf miControl Is HtmlGenericControl Then
                traducirControl(miControl.Controls)
            End If
        Next
    End Sub

#Region "ARMAR MENU"
    Private Sub armarMenuBasico()
        Dim MiMenuInicio As New MenuItem
        Dim _miIdioma As New ENTIDADES.Idioma
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            _miIdioma.ID = 1
        Else
            _miIdioma = BLL.SesionBLL.Current.Usuario.Idioma
        End If
        MiMenuInicio.NavigateUrl = "~/index.aspx"
        'MiMenuInicio.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuInicio.Value = "Inicio"

        Dim QuienesSomos As New MenuItem
        QuienesSomos.NavigateUrl = "~/QuienesSomos.aspx"
        'QuienesSomos.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 147)
        QuienesSomos.Value = "¿Quienes Somos?"



        'Creo los menues principales
        menuPrincipal.Items.Add(MiMenuInicio)
        menuPrincipal.Items.Add(QuienesSomos)


        If IsNothing(Session("Usuario")) Then
            Dim Incripciones As New MenuItem
            Incripciones.NavigateUrl = "~/registrarUsuario.aspx"
            'Incripciones.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 149)
            Incripciones.Value = "Registrarse"

            Dim Contacto As New MenuItem
            Contacto.NavigateUrl = "~/contacto.aspx"
            'Contacto.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 150)
            Contacto.Value = "Contacto"

            'Dim Ingresar As New MenuItem
            'Ingresar.NavigateUrl = "~/login.aspx"
            'Ingresar.Text = "Ingresar"
            'Ingresar.Value = "Ingresar"

            menuPrincipal.Items.Add(Incripciones)
            menuPrincipal.Items.Add(Contacto)
            'menuPrincipal.Items.Add(Ingresar)
        End If



    End Sub


    Public Sub ArmarMenuVertical()

        Dim _miIdioma As New ENTIDADES.Idioma
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            _miIdioma.ID = 1
        Else
            _miIdioma = BLL.SesionBLL.Current.Usuario.Idioma
        End If

        Dim MiMenuManga As New MenuItem
        MiMenuManga.NavigateUrl = "~/Manga.aspx"
        'MiMenuManga.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuManga.Value = "Mangas"

        Dim MiMenuComics As New MenuItem
        MiMenuComics.NavigateUrl = "~/Comics.aspx"
        'MiMenuComics.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuComics.Value = "Comics"

        Dim MiMenuAnime As New MenuItem
        MiMenuAnime.NavigateUrl = "~/Anime.aspx"
        'MiMenuAnime.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuAnime.Value = "Anime"


        Dim MiMenuCosplay As New MenuItem
        MiMenuCosplay.NavigateUrl = "~/Cosplay.aspx"
        'MiMenuCosplay.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuCosplay.Value = "Cosplay"

        Dim MiMenuFiguras As New MenuItem
        MiMenuFiguras.NavigateUrl = "~/Figuras.aspx"
        'MiMenuFiguras.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuFiguras.Value = "Figuras"

        Dim MiMenuJpop As New MenuItem
        MiMenuJpop.NavigateUrl = "~/Jpop.aspx"
        'MiMenuJpop.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuJpop.Value = "Jpop"

        Dim MiMenuMerchandising As New MenuItem
        MiMenuMerchandising.NavigateUrl = "~/Merchandising.aspx"
        'MiMenuMerchandising.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
        MiMenuMerchandising.Value = "Merchandising"

        Me.menuVertical.Items.Add(MiMenuManga)
        Me.menuVertical.Items.Add(MiMenuComics)
        Me.menuVertical.Items.Add(MiMenuAnime)
        Me.menuVertical.Items.Add(MiMenuCosplay)
        Me.menuVertical.Items.Add(MiMenuFiguras)
        Me.menuVertical.Items.Add(MiMenuJpop)
        Me.menuVertical.Items.Add(MiMenuMerchandising)
    End Sub

    Private Sub ArmarMenuUsuario()
        Try
            Dim MiMenuInicio As New MenuItem
            MiMenuInicio.NavigateUrl = "~/index.aspx"
            'MiMenuInicio.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 151)
            MiMenuInicio.Value = "Inicio"

            Dim QuienesSomos As New MenuItem
            QuienesSomos.NavigateUrl = "~/QuienesSomos.aspx"
            'QuienesSomos.Text = BLL.IdiomaBLL.traducirMensaje(_miIdioma, 147)
            QuienesSomos.Value = "¿Quienes Somos?"

            'Creo los menues principales
            menuPrincipal.Items.Add(MiMenuInicio)
            menuPrincipal.Items.Add(QuienesSomos)


            Dim _usu As ENTIDADES.Usuario = DirectCast(Session("Usuario"), ENTIDADES.Usuario)
            Dim archivo As New XmlDocument
            archivo.Load(Server.MapPath("Menu/Menu.xml"))
            'Recorro Todo el Menu en XML
            For i As Integer = 0 To archivo.SelectNodes("menu/submenu").Count - 1
                Dim NodoPadre As XmlNode = archivo.SelectNodes("menu/submenu").Item(i) ' Administrador
                'Recorro los Items dentro del Nodo Sub Menu
                For j As Integer = 0 To NodoPadre.ChildNodes.Count - 1
                    Dim Nodohijo As XmlNode = NodoPadre.ChildNodes(j) ' Los Items de Administrador
                    chequearPermisos(_usu.Perfil.ListaPermisosSimple, NodoPadre.Attributes("nombre").Value.ToString(), Nodohijo.Attributes("nombre").Value.ToString)
                Next
            Next
        Catch ex As Exception

        End Try

    End Sub
    Private Sub chequearPermisos(ByVal listaPermisos As List(Of ENTIDADES.PermisoBase), ByVal paramNombrePadre As String, ByVal paramNombreHijo As String)
        For Each per As ENTIDADES.PermisoBase In listaPermisos
            If per.tieneHijos = False Then ' Si tiene hijos va a ser un Permiso Compuesto
                If per.Nombre = paramNombreHijo Then
                    crearItemMenu(paramNombrePadre, per)
                End If
            Else
                Me.chequearPermisos(per.ObtenerHijos, paramNombrePadre, paramNombreHijo)
            End If
        Next
    End Sub

    'CREO NO NECESITARLO, PORQUE EL MENÚ VERTICAL VA A ESTAR SIEMPRE
    Private Sub crearItemMenu(ByVal paramNombrePadre As String, ByVal paramPermiso As ENTIDADES.PermisoBase)
        'Creo el MenuItemPadre
        Dim MenuItemPadre As New MenuItem
        MenuItemPadre.Text = paramNombrePadre
        MenuItemPadre.Value = paramNombrePadre
        MenuItemPadre.NavigateUrl = "#"
        If MenuExiste(paramNombrePadre) = False Then
            menuPrincipal.Items.Add(MenuItemPadre)
        Else
            MenuItemPadre = BuscarMenu(MenuItemPadre.Text)
        End If
        Dim MenuItemHijo As New MenuItem
        MenuItemHijo.Text = paramPermiso.Nombre
        MenuItemHijo.Value = paramPermiso.Nombre
        MenuItemHijo.NavigateUrl = paramPermiso.URL
        menuPrincipal.Items(menuPrincipal.Items.IndexOf(MenuItemPadre)).ChildItems.Add(MenuItemHijo)
    End Sub

    Private Function MenuExiste(ByVal paramNombrePadre As String) As Boolean
        For Each MiItem As MenuItem In menuPrincipal.Items
            If MiItem.Text = paramNombrePadre Then Return True
        Next
        Return False
    End Function
    Private Function BuscarMenu(ByVal paramNombrePadre As String) As MenuItem
        For Each MiItem As MenuItem In menuPrincipal.Items
            If MiItem.Text = paramNombrePadre Then Return MiItem
        Next
        Return Nothing
    End Function
#End Region

#Region "Traductor"

    Private Sub traducir(ByVal _menuitem As MenuItem)
        For Each MiPalabra As ENTIDADES.Palabra In CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
            If UCase(MiPalabra.Codigo) = UCase(_menuitem.Value) Then
                _menuitem.Text = MiPalabra.Traduccion
            End If
        Next
    End Sub

    Private Sub traducir(ByVal _image As ImageButton)
        For Each MiPalabra As ENTIDADES.Palabra In CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
            If UCase(MiPalabra.Codigo) = UCase(_image.ID) Then
                _image.ImageUrl = MiPalabra.Traduccion
            End If
        Next
    End Sub

    Private Sub traducir(ByVal _radio As RadioButton)
        For Each MiPalabra As ENTIDADES.Palabra In CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
            If UCase(MiPalabra.Codigo) = UCase(_radio.ID) Then
                _radio.Text = MiPalabra.Traduccion
            End If
        Next
    End Sub
    Private Sub traducir(ByVal _label As Label)
        For Each MiPalabra As ENTIDADES.Palabra In CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
            If UCase(MiPalabra.Codigo) = UCase(_label.ID) Then
                _label.Text = MiPalabra.Traduccion
            End If
        Next
    End Sub
    Private Sub traducir(ByVal _button As Button)
        For Each MiPalabra As ENTIDADES.Palabra In CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
            If UCase(MiPalabra.Codigo) = UCase(_button.ID) Then
                _button.Text = MiPalabra.Traduccion
            End If
        Next
    End Sub
    Private Sub traducir(ByVal _checkbox As CheckBox)
        For Each MiPalabra As ENTIDADES.Palabra In CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
            If UCase(MiPalabra.Codigo) = UCase(_checkbox.ID) Then
                _checkbox.Text = MiPalabra.Traduccion
            End If
        Next
    End Sub
#End Region

#Region "Opciones de Usuario"
    Private Sub cargarMenuOpciones()
        Me.opcionesUsuario.Visible = True
        Dim _bllMensaje As New BLL.MensajeBLL
        If _bllMensaje.obtenerCantidadNoLeidos(DirectCast(Session("Usuario"), ENTIDADES.Usuario)) = 0 Then
            img_mensajes.ImageUrl = "~/Imagenes/Message-already-read-32.png"
        End If
        Me.lbl_apellidoyNombre.Text = DirectCast(Session("Usuario"), ENTIDADES.Usuario).Persona.ToString
        Me.lbl_NombredeUsuarioLogueado.Text = DirectCast(Session("Usuario"), ENTIDADES.Usuario).NombreUsuario

        'Agregado para img
        If DirectCast(Session("Usuario"), ENTIDADES.Usuario).Persona.Imagen <> "" Then
            Me.img_Usuario.Src = DirectCast(Session("Usuario"), ENTIDADES.Usuario).Persona.Imagen
        Else
            Me.img_Usuario.Src = "~/Imagenes/userh.png"
        End If
    End Sub
    Protected Sub img_logout_Click(sender As Object, e As ImageClickEventArgs)
        If Not IsNothing(Session("Usuario")) Then
            BLL.SesionBLL.Current.Finalizar()
            Session.Remove("Usuario")

            Me.menuPrincipal.Items.Clear()

            Me.armarMenuBasico()
            Response.Redirect("Index.aspx")
            Me.opcionesUsuario.Visible = False
            'MenuLogin.Visible = True

            Me.Image1.Visible = True
            Me.Image2.Visible = True
            Me.txt_usuario.Visible = True
            Me.txt_password.Visible = True
            Me.ImageButton1.Visible = True
        End If
    End Sub

    Protected Sub img_opciones_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("cambiarIdioma.aspx")
    End Sub

    Protected Sub img_mensajes_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("administrarMensajes.aspx")
    End Sub
#End Region



#Region "Nuevo Para Manejar Usuario"

    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Try
            '    validaciones.validarSubmit(Me, Me.Error, Me.lbl_TituloError)
            Dim _usu As ENTIDADES.Usuario = (New BLL.UsuarioBLL).Login(Me.txt_usuario.Text, Me.txt_password.Text)
            Session.Add("Usuario", _usu)
            Session.Timeout = 120
            'No me funco
            'MenuLogin.Visible = False
            'Me.Image1.Visible = False
            ' Me.Image2.Visible = False
            'Me.txt_usuario.Visible = False
            'Me.txt_password.Visible = False
            'Me.ImageButton1.Visible = False
            Me.MenuLogin.Visible = False
            cargarMenuOpciones()
            'Agregado para Bitacora
            Dim MiSesion As BLL.SesionBLL = BLL.SesionBLL.Current
            MiSesion.Inicializar(_usu)
            '    Response.Redirect("Index.aspx")

            'OJO ACA TENGO QUE REDIRECCIONAR A MI PÁGINA ERROR!!!
        Catch ex As BLL.CamposincompletosException
            Session("Error") = ex.Mensaje
            Response.Redirect("Error.aspx")
        Catch ex As BLL.UsuarioInexistenteException
            Session("Error") = ex.Mensaje
            Response.Redirect("Error.aspx")
        Catch ex As BLL.PasswordIncorrectoException
            Session("Error") = ex.Mensaje
            Response.Redirect("Error.aspx")
        Catch ex As BLL.UsuarioBloqueadoException
            Session("Error") = ex.Mensaje
            Response.Redirect("Error.aspx")
        End Try
    End Sub
#End Region


End Class