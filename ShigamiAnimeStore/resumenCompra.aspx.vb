Imports ENTIDADES
Imports BLL
Public Class resumenCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNothing(Session("Usuario")) Then
                sinProductos.Visible = True
                lbl_SinProductos.Text = "Debe iniciar sesión antes de efectuar una compra."
                botones.Visible = False
            Else
                Me.botones.Visible = False
                ''Pregunto si tengo el carrito para no sobreescribirlo
                If IsNothing(Session("Carrito")) Then
                    'Genero el carrito la primera vez
                    Session("Carrito") = New List(Of ENTIDADES.ProductoEntidad)
                End If

                'Pregunto si tengo algo en producto que agregar.
                If Not IsNothing(Session("Producto")) Then
                    'Agrego al Carrito el producto enviado por parámetro
                    Me.AgregarProducto()
                End If

                'Pregunto si el carrito no tiene nada
                If DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad)).Count = 0 Then
                    'Si el carrito no tiene nada, le digo que no hay productos.
                    sinProductos.Visible = True
                Else
                    'Si tiene algo, lo muestro.
                    Me.CargarGrilla()
                End If
            End If
        End If
    End Sub

    Private Sub CargarGrilla()
        'Cargo la grilla con los productos del carrito
        'Si no tiene productos, entonces no muestro nada.
        If DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad)).Count = 0 Then
            Me.botones.Visible = False
            Me.GridView1.DataSource = DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad))
            Me.GridView1.DataBind()
            Me.sinProductos.Visible = True
        Else
            'Cargo los productos de la lista
            Me.botones.Visible = True
            Me.GridView1.DataSource = DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad))
            Me.GridView1.DataBind()
            Me.CalcularMontoCompra()
        End If

    End Sub

    Protected Sub btn_Confirmar_Click(sender As Object, e As EventArgs) Handles btn_Confirmar.Click

        Try
            'Finalizo la venta. Se impactan los datos en la base de datos.
            Dim MiVentaBLL As New VentaBLL
            Dim MiDescuento As Double
            Dim MiWebServices As New CalcularDescuentos
            MiDescuento = MiWebServices.PorcentajeDescuento(ddl_Tarjeta.SelectedValue.ToString)
            MiVentaBLL.FinalizarVenta(DirectCast(Session("Usuario"), ENTIDADES.Usuario), DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad)), MiDescuento)
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        'Se cancela la venta.
        'Elimino todos los productos adquiridos hasta el momento y redirecciono a la página principal.
        Session("Carrito") = Nothing
        Response.Redirect("index.aspx")
    End Sub



    Private Sub CalcularMontoCompra()
        Try
            'Método utilizado para calcular el monto en base al tipo de pago y los productos agregados al carrito.
            Dim Total As Double
            Dim Subtotal As Double

            For Each miproducto As ProductoEntidad In DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad))
                Subtotal = miproducto.Precio * miproducto.CantidadComprada
                Total = Total + Subtotal
            Next

            Dim MiWebService As New CalcularDescuentos

            'Aca invoco al método del webservices.
            Total = MiWebService.CalcularDescuentos(Total, ddl_Tarjeta.SelectedValue.ToString)


            lbl_MontoCompra.Text = "$ " & Total
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarProducto()
        Try
            'Método utilizado para agregar los productos al carrito.
            For Each miproducto As ProductoEntidad In DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad))
                'BUSCO EL PRODUCTO AGREGADO
                If miproducto.ID = DirectCast(Session("Producto"), ProductoEntidad).ID Then
                    'Lo encuentro? Le sumo 1 a la cantidad
                    'Pero antes, valido el stock
                    If miproducto.CantidadComprada = miproducto.Stock Then
                        Throw New SinStockException
                    Else
                        miproducto.CantidadComprada = miproducto.CantidadComprada + 1
                    End If
                    'Me voy del ciclo
                    Exit Sub
                End If
            Next
            '¿No lo encontre? lo agrego al carrito por primera vez (osea solo 1)
            DirectCast(Session("Producto"), ProductoEntidad).CantidadComprada = 1
            DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad)).Add(Session("Producto"))

        Catch ex As SinStockException
            Me.sinProductos.Visible = True
            'Saco para no cargarlo en la BD
            'Me.lbl_SinProductos.Text = ex.Mensaje
            Me.lbl_SinProductos.Text = "No hay stock disponible"
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_remover_Command(sender As Object, e As CommandEventArgs)
        'Método utilizado para quitar un producto (cantidad) del carrito.
        For Each miproducto As ProductoEntidad In DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad))
            'BUSCO EL PRODUCTO AGREGADO
            If miproducto.ID = CInt(e.CommandArgument) Then
                If miproducto.CantidadComprada = 1 Then
                    DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad)).Remove(miproducto)
                Else
                    'Lo encuentro? Le resto 1 a la cantidad
                    miproducto.CantidadComprada = miproducto.CantidadComprada - 1
                End If
                'Me voy del ciclo
                Me.CargarGrilla()
                Exit Sub
            End If
        Next
    End Sub

    Protected Sub btn_Eliminar_Command(sender As Object, e As CommandEventArgs)
        'Método para eliminar un producto del carrito (todo el producto, sin importar la cantidad)
        For Each miproducto As ProductoEntidad In DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad))
            'BUSCO EL PRODUCTO AGREGADO
            If miproducto.ID = CInt(e.CommandArgument) Then
                'Elimino de la lista
                DirectCast(Session("Carrito"), List(Of ENTIDADES.ProductoEntidad)).Remove(miproducto)
                'Me voy del ciclo
                Me.CargarGrilla()
                Exit Sub

            End If
        Next
    End Sub

    Private Sub resumenCompra_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        'Al salir de la página, se elimina el producto seleccionado para poder seleccionar otro.
        Session("Producto") = Nothing
    End Sub

    Private Sub ddl_Tarjeta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Tarjeta.SelectedIndexChanged
        'Con el cambio del combobox, se pide calcular el importe.
        Me.CalcularMontoCompra()
    End Sub

End Class