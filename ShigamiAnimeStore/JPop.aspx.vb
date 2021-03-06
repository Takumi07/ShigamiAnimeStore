﻿Imports BLL
Imports ENTIDADES
Public Class JPop
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Carga la lista de productos que pertenece a los productos de tipo "JPOP"
        'Genera una grilla con información del producto permitiendo agregar el mismo al carrito de compras del usuario.
        Dim MiProductoBLL As New ProductoBLL
        Dim MiListaProducto As New List(Of ProductoEntidad)
        For Each MiProducto As ProductoEntidad In MiProductoBLL.ListarProductos
            If MiProducto.TipoProducto.Descripcion = "JPop" Then
                MiListaProducto.Add(MiProducto)
            End If
        Next
        If MiListaProducto.Count = 0 Then
            Me.sinComentarios.Visible = True
        Else
            GridView1.DataSource = MiListaProducto
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub btn_Agregar_Command(sender As Object, e As CommandEventArgs)
        'Agrega el producto al carrito del usuario, para que pueda realizar una compra.
        Dim MiProducto As ProductoEntidad
        Dim a = Me.BuscarProducto(e.CommandArgument)
        MiProducto = Me.BuscarProducto(e.CommandArgument)
        Session("Producto") = MiProducto
        Response.Redirect("resumenCompra.aspx")
    End Sub

    Public Function BuscarProducto(ByVal paramIDProducto As Integer) As ProductoEntidad
        For Each miproducto As ProductoEntidad In (New ProductoBLL).ListarProductos
            If miproducto.ID = paramIDProducto Then
                Return miproducto
            End If
        Next
    End Function

End Class