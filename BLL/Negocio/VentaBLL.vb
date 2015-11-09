Imports ENTIDADES
Imports MAPPER

Public Class VentaBLL

    Public Function FinalizarVenta(ByVal paramUsuario As ENTIDADES.Usuario, ByVal paramListaProducto As List(Of ENTIDADES.ProductoEntidad), ByVal descuento As Double)
        Try
            Dim MiVentaMPP As New VentaMPP
            MiVentaMPP.FinalizarVenta(paramUsuario, paramListaProducto, descuento)
        Catch ex As Exception
            Throw ex
        End Try

    End Function




End Class
