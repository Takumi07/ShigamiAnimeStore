Imports System.Threading
Public Class visualizarBitacora
    Inherits System.Web.UI.Page

    Dim _listalogs As New List(Of ENTIDADES.Bitacora)
    Dim _bllBitacora As New BLL.BitacoraBLL
    Dim _gestorusuario As New BLL.UsuarioBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If validaciones.validarPagina(Me) = False Then
            Response.Redirect("error.aspx")
        End If
        Me.Cargar()
        If Not IsPostBack Then
            cargarGridView()
            obtenerUsuarios()
            obtenerTipoOperacion()
        End If

    End Sub

    'Protected Overrides Sub InitializeCulture()
    '    Thread.CurrentThread.CurrentCulture = CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Cultura
    '    Thread.CurrentThread.CurrentUICulture = CType(Session("Usuario"), ENTIDADES.Usuario).Idioma.Cultura
    'End Sub

    Private Sub Cargar()
        _listalogs = _bllBitacora.consultarBitacora()
    End Sub

    Private Sub obtenerUsuarios()
        Dim _bllUsuario As New BLL.UsuarioBLL
        Me.ddl_Usuario.DataSource = _bllUsuario.consultarUsuarios
        Me.ddl_Usuario.DataBind()
        Me.ddl_Usuario.Items.Insert(0, "Todos")
    End Sub

    Private Sub obtenerTipoOperacion()
        Me.ddl_Operacion.DataSource = System.Enum.GetValues(GetType(ENTIDADES.Bitacora.tipoOperacionBitacora))
        Me.ddl_Operacion.DataBind()
        Me.ddl_Operacion.Items.Insert(0, "Todos")
    End Sub

    Private Sub cargarGridView()
        Me.gv_Bitacora.DataSource = _listalogs
        Me.gv_Bitacora.DataBind()
    End Sub

    Private Sub cargarGridView(ByVal _listabitacora As List(Of ENTIDADES.Bitacora))
        Me.gv_Bitacora.DataSource = _listabitacora
        Me.gv_Bitacora.DataBind()
    End Sub


    Private Sub GridView1_DataBound(sender As Object, e As EventArgs) Handles gv_Bitacora.DataBound
        Try
            Dim ddl As DropDownList = CType(gv_Bitacora.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Bitacora.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Bitacora.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv_Bitacora.PageIndexChanging
        Me.gv_Bitacora.DataSource = _listalogs
        Me.gv_Bitacora.PageIndex = e.NewPageIndex
        Me.gv_Bitacora.DataBind()
    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ddl As DropDownList = CType(gv_Bitacora.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
        Me.gv_Bitacora.DataSource = _listalogs
        Me.gv_Bitacora.PageIndex = ddl.SelectedIndex
        Me.gv_Bitacora.DataBind()
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            Dim _usuario As ENTIDADES.Usuario = Nothing
            Dim _fecha As Date
            Dim _operacion As Integer = 0
            If Not ddl_Usuario.SelectedIndex = 0 Then
                _usuario = _gestorusuario.consultarUsuario(Me.ddl_Usuario.SelectedValue)
            End If
            If Not ddl_Operacion.SelectedIndex = 0 Then
                _operacion = ddl_Operacion.SelectedIndex
            End If
            If Not datepicker.Text = "" Then
                _fecha = CDate(datepicker.Text)
            Else
                _fecha = New Date(1, 1, 1)
            End If
            Dim _listabitacora As List(Of ENTIDADES.Bitacora) = _bllBitacora.consultarBitacora(_usuario, _fecha, _operacion)
            cargarGridView(_listabitacora)
        Catch ex As Exception

        End Try
    End Sub

End Class