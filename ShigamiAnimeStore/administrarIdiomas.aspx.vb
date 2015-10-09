Public Class administrarIdiomas
    Inherits System.Web.UI.Page

    Dim _gestorIdioma As New BLL.IdiomaBLL
    Dim _listaIdioma As New List(Of ENTIDADES.Idioma)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If validaciones.validarPagina(Me) = False Then
        '    Response.Redirect("error.aspx")
        'End If
        Me.cargar()
        If Not IsPostBack Then
            Me.cargarGridView()
        End If
    End Sub


    Private Sub cargar()
        _listaIdioma = _gestorIdioma.ListarIdiomas()
    End Sub

    Private Sub cargarGridView()
        Me.gv_Idiomas.DataSource = _listaIdioma
        Me.gv_Idiomas.DataBind()
    End Sub
    Protected Sub gv_Idiomas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        cargarGridView()
        gv_Idiomas.PageIndex = e.NewPageIndex
        gv_Idiomas.DataBind()
    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ddl As DropDownList = CType(gv_Idiomas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
        gv_Idiomas.SetPageIndex(ddl.SelectedIndex)
    End Sub

    Protected Sub Editar_Command(sender As Object, e As CommandEventArgs)
        Dim Context As HttpContext = HttpContext.Current
        If Context.Items.Contains("IdiomaaEditar") = True Then
            Context.Items.Remove("IdiomaaEditar")
        End If
        Dim _idioma As New Entidades.Idioma
        _idioma.ID = CInt(e.CommandArgument)
        Context.Items.Add("IdiomaaEditar", _gestorIdioma.Cargar(_idioma))
        Server.Transfer("agregarIdioma.aspx")
    End Sub


    Protected Sub Eliminar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim _idioma As New Entidades.Idioma
            _idioma.ID = CInt(e.CommandArgument)
            _idioma = _gestorIdioma.Cargar(_idioma)
            _gestorIdioma.bajaIdioma(_idioma)
            Response.Redirect("administrarIdiomas.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gv_Idiomas_DataBound(sender As Object, e As EventArgs) Handles gv_Idiomas.DataBound
        Try
            For Each row As GridViewRow In gv_Idiomas.Rows
                If Not row.Cells(2).Text = "" Then
                    If CBool(row.Cells(2).Text) = False Then
                        Dim imageneliminar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Eliminar"), System.Web.UI.WebControls.ImageButton)
                        imageneliminar.Visible = False
                        Dim imagenEditar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Editar"), System.Web.UI.WebControls.ImageButton)
                        imagenEditar.Visible = False
                    End If
                End If
            Next

            gv_Idiomas.Columns(2).Visible = False

            Dim ddl As DropDownList = CType(gv_Idiomas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Idiomas.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Idiomas.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt
        Catch ex As Exception

        End Try
    End Sub


End Class