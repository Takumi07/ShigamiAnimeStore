Imports System.IO
Public Class registrarUsuario
    Inherits System.Web.UI.Page
    Dim _listaTelefono As New List(Of ENTIDADES.Telefono)
    Dim MiPersonaBLL As New BLL.PersonaBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Se cargan los dátos necesarios para operar con la página.
        If Not IsPostBack Then
            obtenerProvincia()
            obtenerNacionalidad()
            obtenerIdiomas()
            Session("listaTelefonos") = _listaTelefono
            obtenerTipoTelefono()
        End If
    End Sub

    Private Sub obtenerIdiomas()
        'Se cargan los idiomas que el sistema posee.
        If ddl_idiomas.Items.Count = 0 Then
            Dim _bllIdioma As New BLL.IdiomaBLL
            Dim _idiomas As List(Of ENTIDADES.Idioma) = _bllIdioma.ListarIdiomas
            Me.ddl_idiomas.DataSource = _idiomas
            Me.ddl_idiomas.DataBind()
        End If
    End Sub
    Private Sub obtenerProvincia()
        'Se obtienen las provincias las cuales vienen por defecto en el sistema.
        Me.ddl_provincia.DataSource = (New BLL.ProvinciaBLL).obtenerProvincia
        Me.ddl_provincia.DataBind()
    End Sub

    Private Sub obtenerNacionalidad()
        'Se obtienen las Localidades las cuales vienen por defecto en el sistema.
        Me.ddl_Nacionalidad.DataSource = (New BLL.NacionalidadBLL).obtenerNacionalidad
        Me.ddl_Nacionalidad.DataBind()
    End Sub


    Private Sub obtenerTipoTelefono()
        'Se obtienen los Tipos de teléfono las cuales vienen por defecto en el sistema.
        Me.ddl_tipoTelefono.DataSource = System.Enum.GetValues(GetType(ENTIDADES.Telefono.EnumtipoTelefono))
        Me.ddl_tipoTelefono.DataBind()
    End Sub

    Private Sub actualizarGrilla(ByVal paramTelefono As ENTIDADES.Telefono)
        DirectCast(Session("listaTelefonos"), List(Of ENTIDADES.Telefono)).Add(paramTelefono)
        Me.gv_Telefono.DataSource = DirectCast(Session("listaTelefonos"), List(Of ENTIDADES.Telefono))
        Me.gv_Telefono.DataBind()
        Me.txt_NumeroTelefono.Text = ""
    End Sub

    Private Sub actualizarGrilla()
        Me.gv_Telefono.DataSource = DirectCast(Session("listaTelefonos"), List(Of ENTIDADES.Telefono))
        Me.gv_Telefono.DataBind()
        Me.txt_NumeroTelefono.Text = ""
    End Sub

    Protected Sub btn_Eliminar_Command(sender As Object, e As CommandEventArgs)
        Dim _telefono As New ENTIDADES.Telefono
        _telefono.Numero = e.CommandArgument
        If DirectCast(Session("listaTelefonos"), List(Of ENTIDADES.Telefono)).Contains(_telefono) Then
            DirectCast(Session("listaTelefonos"), List(Of ENTIDADES.Telefono)).Remove(_telefono)
        End If
        actualizarGrilla()
    End Sub


    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        'Contiene el código pertinente para dar de alta a un usuario en el sistema.
        Try
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            If Me.txt_contraseña.Text > 6 Then
                Dim MiPersona As New ENTIDADES.Persona
                MiPersona.DNI = Me.txt_Documento.Text
                MiPersona.Nombre = Me.txt_Nombre.Text
                MiPersona.Apellido = Me.txt_Apellido.Text
                MiPersona.Mail = Me.txt_correo.Text
                If MiPersonaBLL.comprobarCorreo(MiPersona) = False Then
                    MiPersona.FechaNacimiento = Me.datepicker.Text
                    'NACIONALIDAD
                    Dim _nacionalidad As New ENTIDADES.Nacionalidad
                    _nacionalidad.Descripcion = Me.ddl_Nacionalidad.SelectedValue.ToString
                    MiPersona.Nacionalidad = (New BLL.NacionalidadBLL).obtenerNacionalidad(_nacionalidad)
                    Dim _dire As New ENTIDADES.Direccion
                    _dire.Calle = Me.txt_Calle.Text
                    _dire.Altura = Me.txt_Altura.Text
                    _dire.Piso = Me.txt_Piso.Text
                    _dire.Departamento = Me.txt_Departamento.Text
                    _dire.Localidad = Me.txt_Localidad.Text
                    'PROVINCIA
                    Dim _provincia As New ENTIDADES.Provincia
                    _provincia.Descripcion = Me.ddl_provincia.SelectedValue.ToString
                    _dire.Provincia = (New BLL.ProvinciaBLL).obtenerProvincia(_provincia)
                    _dire.CodigoPostal = Me.txt_Postal.Text
                    MiPersona.Direccion = _dire
                    MiPersona.Telefono = obtenerTelefono()
                    'CÓDIGO PARA LA IMAGEN
                    Dim PostedFilesCollection As HttpFileCollection = Request.Files
                    Dim PostedFile As HttpPostedFile = PostedFilesCollection(0)
                    If PostedFile.FileName <> "" Then
                        Dim MiDirPath As String = Server.MapPath("~/ImagenesUsuario")
                        Me.CrearDirectorio(MiDirPath)
                        Dim MiPathAGuardar As String = String.Format("{0}\{1}", MiDirPath, MiPersona.Nombre & "." & MiPersona.Apellido & ".png")
                        PostedFile.SaveAs(MiPathAGuardar)
                        MiPersona.Imagen = "~/ImagenesUsuario/" & MiPersona.Nombre & "." & MiPersona.Apellido & ".png"
                    Else
                        MiPersona.Imagen = "~/Imagenes/userH.png"
                    End If
                    MiPersonaBLL.AltaPersona(MiPersona)

                    'Alta del usuario
                    Dim MiUsuario As New ENTIDADES.Usuario
                    MiUsuario.NombreUsuario = txt_nombreusuario.Text
                    MiUsuario.Password = BLL.EncriptarBLL.EncriptarPass(txt_contraseña.Text)
                    Dim MiIdiomaBLL As New BLL.IdiomaBLL
                    MiUsuario.Idioma = MiIdiomaBLL.consultarIdioma(Me.ddl_idiomas.SelectedItem.ToString)
                    'ACA LE METO EL PERFIL CLIENTE QUE VA A SER NO EDITABLE, NO BORRABLE, NO NADA
                    Dim MiPerfilEntidad As New ENTIDADES.PermisoCompuesto
                    MiPerfilEntidad.ID = 1
                    MiUsuario.Perfil = MiPerfilEntidad
                    MiUsuario.Persona = MiPersona
                    Dim MiUsuarioBLL As New BLL.UsuarioBLL
                    MiUsuarioBLL.altaUsuario(MiUsuario)

                Else
                    Throw New BLL.correorepetidoException
                End If
            Else
                Throw New BLL.PasswordCortoException
            End If
        Catch ex As BLL.PasswordCortoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub

    Public Sub CrearDirectorio(ByVal paramPath As String)
        'Método utilizado para crear el directorio que contendrá las imágenes, en caso de que no exista.
        Dim MiDirectorio As DirectoryInfo = New DirectoryInfo(paramPath)
        If Not MiDirectorio.Exists Then
            MiDirectorio.Create()
        End If
    End Sub



    Private Function obtenerTelefono() As List(Of ENTIDADES.Telefono)
        Dim _listaTelefono As New List(Of ENTIDADES.Telefono)
        For Each _row As GridViewRow In Me.gv_Telefono.Rows
            Dim _telefono As New ENTIDADES.Telefono
            _telefono.Numero = _row.Cells(0).Text
            _telefono.tipoTelefono = [Enum].Parse(GetType(ENTIDADES.Telefono.EnumtipoTelefono), _row.Cells(1).Text, True)
            _listaTelefono.Add(_telefono)
        Next
        Return _listaTelefono
    End Function

    Protected Sub btn_agregarTelefono_Click(sender As Object, e As ImageClickEventArgs)
        'Método que permite agregar teléfonos a la información personal del usuario.
        Try
            Dim _telefono As New ENTIDADES.Telefono
            _telefono.tipoTelefono = Me.ddl_tipoTelefono.SelectedIndex + 1
            _telefono.Numero = CInt(txt_NumeroTelefono.Text)
            actualizarGrilla(_telefono)
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try

    End Sub

    Private Sub CustomValidator1_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        'Validación.
        Dim MiUsuarioBLL As New BLL.UsuarioBLL
        If MiUsuarioBLL.chequearUsuario(txt_nombreusuario.Text) = True Then
            CustomValidator1.IsValid = False
        Else
            CustomValidator1.IsValid = True
        End If
    End Sub
End Class