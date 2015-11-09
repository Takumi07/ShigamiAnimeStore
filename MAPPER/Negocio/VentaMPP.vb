Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES
Public Class VentaMPP

    Public Sub FinalizarVenta(ByVal paramUsuario As ENTIDADES.Usuario, ByVal paramListaProducto As List(Of ENTIDADES.ProductoEntidad), ByVal paramdescuento As Double)
        'Primero impacto la factura con los datos del tipo
        Dim ComandoStr As String
        ComandoStr = "Insert into Venta values(@ID_Factura, @ID_Persona, @Fecha,@Hora)"
        Dim MiComando = DAL.BD.MiComando(ComandoStr)
        Dim MiIDFactura As Integer = DAL.BD.ObtenerID("Venta", "ID_Factura")
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Factura", MiIDFactura))
            .Add(New SqlParameter("@ID_Persona", paramUsuario.Persona.ID))
            .Add(New SqlParameter("@Fecha", Date.Now.Date))
            .Add(New SqlParameter("@Hora", SqlDbType.Time)).Value = DateTime.Now.TimeOfDay
        End With
        DAL.BD.ExecuteNonQuery(MiComando)


        For Each MiProducto As ProductoEntidad In paramListaProducto
            Dim ComandoStr2 As String
            ComandoStr2 = "insert into detalle_venta values(@ID_Factura, @ID_Producto, @Cantidad, @Precio, @Descuento, @DVH)"
            Dim MiComando2 = DAL.BD.MiComando(ComandoStr2)
            Dim MIDVH As String
            MIDVH = MiProducto.ID & MiIDFactura & MiProducto.CantidadComprada & MiProducto.Precio & paramdescuento
            With MiComando2.Parameters
                .Add(New SqlParameter("@ID_Producto", MiProducto.ID))
                .Add(New SqlParameter("@ID_Factura", MiIDFactura))
                .Add(New SqlParameter("@Cantidad", MiProducto.CantidadComprada))
                .Add(New SqlParameter("@Precio", MiProducto.Precio))
                .Add(New SqlParameter("@Descuento", paramdescuento))
                .Add(New SqlParameter("@DVH", MAPPER.DVMPP.CalcularDVH(MIDVH)))
            End With
            DAL.BD.ExecuteNonQuery(MiComando2)
            DVMPP.ActualizarDVV("Detalle_Venta")

            'A lo negro por ahora hasta que sepa como solucionarlo
            'Esto funcionarìa si yo al objeto en la bll le resto del stock en memoria lo que me estoy comprando..
            'Sino deberiìa calcularlo con stock menos la cantidad comprada.
            Dim ComandoStr3 As String
            ComandoStr3 = "update Producto set Stock = @Stock where ID_Producto = @ID_Producto"
            Dim MiComando3 = DAL.BD.MiComando(ComandoStr3)
            With MiComando3.Parameters
                .Add(New SqlParameter("@ID_Producto", MiProducto.ID))
                .Add(New SqlParameter("@Stock", MiProducto.Stock - MiProducto.CantidadComprada))
            End With
            DAL.BD.ExecuteNonQuery(MiComando3)
        Next

    End Sub







End Class
