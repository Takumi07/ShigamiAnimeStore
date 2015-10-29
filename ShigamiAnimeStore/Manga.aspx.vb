Imports ENTIDADES
Imports BLL
Public Class Manga
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MiMangaBLL As New MangaBLL
        Dim MiListaManga As New List(Of MangaEntidad)
        For Each MiProducto As ProductoEntidad In MiMangaBLL.ListarProductos()
            If MiProducto.TipoProducto.Descripcion = "Manga" Then
                MiListaManga.Add(MiProducto)
            End If
        Next
        If MiListaManga.Count = 0 Then
            Me.sinComentarios.Visible = True
        Else
            GridView1.DataSource = MiListaManga
            GridView1.DataBind()
        End If

    End Sub

    Protected Sub btn_Agregar_Command(sender As Object, e As CommandEventArgs)
        Dim MiProducto As ProductoEntidad
        Dim a = Me.BuscarProducto(e.CommandArgument)
        MiProducto = Me.BuscarProducto(e.CommandArgument)
        Session("Producto") = MiProducto

        'ACA TIENE QUE IR A RESUMEN COMPRA O ALGO ASÍ
        'Response.Redirect("administrarProductos.aspx")
    End Sub

    Public Function BuscarProducto(ByVal paramIDProducto As Integer) As ProductoEntidad
        For Each miproducto As ProductoEntidad In (New ProductoBLL).ListarProductos
            If miproducto.ID = paramIDProducto Then
                Return miproducto
            End If
        Next
    End Function
End Class