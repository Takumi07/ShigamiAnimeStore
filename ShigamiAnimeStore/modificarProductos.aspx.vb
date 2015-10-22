Imports ENTIDADES
Imports BLL

Public Class modificarProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Me.GridView1.DataSource = (New ProductoBLL).ListarProductos
            Me.GridView1.DataBind()
        End If
    End Sub



    Protected Sub btn_Editar_Command(sender As Object, e As CommandEventArgs)
        'Me trae la fila
        'Dim MiRow As Integer
        'MiRow = CInt(e.CommandArgument)
        Dim MiProducto As ProductoEntidad
        Dim a = Me.BuscarProducto(e.CommandArgument)
        MiProducto = Me.BuscarProducto(e.CommandArgument)
        Session("Producto") = MiProducto
        Response.Redirect("administrarProductos.aspx")
    End Sub

    Public Function BuscarProducto(ByVal paramIDProducto As Integer) As ProductoEntidad
        For Each miproducto As ProductoEntidad In (New ProductoBLL).ListarProductos
            If miproducto.ID = paramIDProducto Then
                Return miproducto
            End If
        Next
    End Function
End Class