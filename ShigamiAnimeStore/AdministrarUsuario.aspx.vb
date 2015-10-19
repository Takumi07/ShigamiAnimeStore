Imports System.Threading
Public Class AdministrarUsuario
    Inherits System.Web.UI.Page
    Private _gestorUsuario As New BLL.UsuarioBLL
    Private _listausuarios As List(Of ENTIDADES.Usuario)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If validaciones.validarPagina(Me) = False Then
            Response.Redirect("error.aspx")
        End If
        Me.cargarlista()
        If Not IsPostBack Then
            obtenerUsuarios()
            obtenerAyN()
            Me.cargargridview()
        End If
    End Sub
    Protected Overrides Sub InitializeCulture()
        Thread.CurrentThread.CurrentCulture = CType(BLL.SesionBLL.Current.Usuario, ENTIDADES.Usuario).Idioma.Cultura
        Thread.CurrentThread.CurrentUICulture = CType(BLL.SesionBLL.Current.Usuario, ENTIDADES.Usuario).Idioma.Cultura
    End Sub
    Private Sub obtenerUsuarios()
        Me.ddl_Usuario.DataSource = _listausuarios
        Me.ddl_Usuario.DataBind()
        Me.ddl_Usuario.Items.Insert(0, "Todos")
    End Sub

    Private Sub obtenerAyN()
        Dim _listaPersona As New List(Of ENTIDADES.Persona)
        For Each _usu As ENTIDADES.Usuario In Me._listausuarios
            If Not _listaPersona.Contains(_usu.Persona) Then
                _listaPersona.Add(_usu.Persona)
            End If
        Next
        Me.ddl_ApellidoyNombre.DataValueField = "DNI"
        Me.ddl_ApellidoyNombre.DataSource = _listaPersona
        Me.ddl_ApellidoyNombre.DataBind()
        Me.ddl_ApellidoyNombre.Items.Insert(0, "Todos")
    End Sub

    Private Sub cargar()
        cargarlista()
        Me.cargargridview()
    End Sub

    Private Sub cargarlista()
        _listausuarios = _gestorUsuario.consultarUsuarios()
    End Sub


    Private Sub cargargridview()
        Me.gv_Usuarios.DataSource = _listausuarios
        Me.gv_Usuarios.DataBind()
    End Sub

    Private Sub cargargridview(ByVal _listadeusuarios As List(Of ENTIDADES.Usuario))
        Me.gv_Usuarios.DataSource = _listadeusuarios
        Me.gv_Usuarios.DataBind()
    End Sub

    Protected Sub Bloqueo_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim _usu As ENTIDADES.Usuario = _gestorUsuario.consultarUsuario(CInt(e.CommandArgument))
            _gestorUsuario.BloquearUsuario(_usu)
            Response.Redirect("administrarUsuario.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub desBloqueo_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim _usu As ENTIDADES.Usuario = _gestorUsuario.consultarUsuario(CInt(e.CommandArgument))
            _gestorUsuario.desbloquearUsuario(_usu)
            Response.Redirect("administrarUsuario.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Editar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim Context As HttpContext = HttpContext.Current
            If Context.Items.Contains("UsuarioaEditar") = True Then
                Context.Items.Remove("UsuarioaEditar")
            End If
            Context.Items.Add("UsuarioaEditar", _gestorUsuario.consultarUsuario(CInt(e.CommandArgument)))
            Server.Transfer("agregarUsuario.aspx")
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Eliminar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim _usu As ENTIDADES.Usuario = _gestorUsuario.consultarUsuario(CInt(e.CommandArgument))
            _gestorUsuario.bajaUsuario(_usu)
            Response.Redirect("administrarUsuario.aspx")
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gv_Usuarios_DataBound(sender As Object, e As EventArgs) Handles gv_Usuarios.DataBound
        Try
            For Each row As GridViewRow In gv_Usuarios.Rows



                If Not row.Cells(5).Text = "" Then
                    If CBool(row.Cells(5).Text) = True Then
                        row.Cells(5).Text = "Bloqueado"
                        Dim imagen As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloqueo"), System.Web.UI.WebControls.ImageButton)
                        imagen.Visible = False
                        Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desBloqueo"), System.Web.UI.WebControls.ImageButton)
                        imagen2.Visible = True
                    Else
                        row.Cells(5).Text = "Activo"
                        Dim imagen As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desBloqueo"), System.Web.UI.WebControls.ImageButton)
                        imagen.Visible = False
                        Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloqueo"), System.Web.UI.WebControls.ImageButton)
                        imagen2.Visible = True
                    End If
                End If

                If Not row.Cells(7).Text = "" Then
                    If CBool(row.Cells(7).Text) = False Then
                        Dim imagenBloqueo As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloqueo"), System.Web.UI.WebControls.ImageButton)
                        imagenBloqueo.Visible = False
                        Dim imageneliminar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Editar"), System.Web.UI.WebControls.ImageButton)
                        imageneliminar.Visible = False
                        Dim imagenEditar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Eliminar"), System.Web.UI.WebControls.ImageButton)
                        imagenEditar.Visible = False
                    End If
                End If

                gv_Usuarios.Columns(7).Visible = False
            Next
            Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Usuarios.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Usuarios.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gv_Usuarios_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        cargar()
        gv_Usuarios.PageIndex = e.NewPageIndex
        gv_Usuarios.DataBind()
    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
        gv_Usuarios.SetPageIndex(ddl.SelectedIndex)
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            Dim _usuario As ENTIDADES.Usuario = Nothing
            Dim _estado As Integer
            Dim _persona As ENTIDADES.Persona = Nothing
            If Not ddl_Usuario.SelectedIndex = 0 Then
                _usuario = _gestorUsuario.consultarUsuario(Me.ddl_Usuario.SelectedValue)
            End If
            If Not ddl_ApellidoyNombre.SelectedIndex = 0 Then
                Dim _personaBLL As BLL.PersonaBLL = New BLL.PersonaBLL
                _persona = _personaBLL.obtenerPersonaPorDNI(ddl_ApellidoyNombre.SelectedValue)
            End If
            _estado = ddl_Operacion.SelectedValue
            Dim _listadeUsuarios As List(Of ENTIDADES.Usuario) = _gestorUsuario.consultarUsuario(_usuario, _persona, _estado)
            cargargridview(_listadeUsuarios)
        Catch ex As Exception

        End Try
    End Sub

End Class