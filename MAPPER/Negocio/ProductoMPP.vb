Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES
Imports DAL

Public Class ProductoMPP


    Public Function ListarProductos() As List(Of ProductoEntidad)
        Dim MiComandoStr As String = "Select * from Producto where bl=@bl"
        Dim MiComando = BD.MiComando(MiComandoStr)
        Dim MiDataTable As New DataTable
        Dim MiListaProductoEntidad As New List(Of ProductoEntidad)
        With MiComando.Parameters
            .Add(New SqlParameter("@bl", 0))
        End With
        MiDataTable = BD.ExecuteDataTable(MiComando)
        For Each MiRow As DataRow In MiDataTable.Rows
            If MiRow(2) = 1 Then
                'Esto quiere decir que es un Manga = 1
                Dim MiMangaEntidad As New MangaEntidad
                'Aca le asigno todos los atributos que tiene en común con Producto así no tipeo al pedo.
                MiMangaEntidad = (New MAPPER.MangaMPP).ObtenerUnManga(MiRow(0))
                FormatearProducto(MiRow, MiMangaEntidad)
                MiListaProductoEntidad.Add(MiMangaEntidad)
            ElseIf MiRow(2) = 2 Then
                'Esto quiere decir que es un Anime = 2
                Dim MiAnimeEntidad As New AnimeEntidad
                MiAnimeEntidad = (New MAPPER.AnimeMPP).ObtenerUnAnime(MiRow(0))
                FormatearProducto(MiRow, MiAnimeEntidad)
                MiListaProductoEntidad.Add(MiAnimeEntidad)
            Else
                Dim MiProductoEntidad As New ProductoEntidad
                FormatearProducto(MiRow, MiProductoEntidad)
                MiListaProductoEntidad.Add(MiProductoEntidad)
            End If
        Next
        Return MiListaProductoEntidad
    End Function

    'Me interessa cosumir esto desde la clase PromociónDAL dado que en la misma se carga una lista
    'De productos. Para no tipear 2 veces al pedo y que la responsabilidad "este bien asignada"
    'Esto lo meto public por mas que la consulta de SQL la replique.
    Public Sub FormatearProducto(ByVal paramRow As DataRow, ByVal paramProductoEntidad As ProductoEntidad)
        paramProductoEntidad.ID = paramRow(0)
        'Esto pincha, sabelo
        'Modificación 2.0. No creo un genero o producto con el id por constructor, sino que lo lleno 
        'Desde sus dals para que quede el objeto completo para otras cosas.
        paramProductoEntidad.Genero = ObtenerGenero(paramRow(1))
        paramProductoEntidad.TipoProducto = ObtenerTipoProducto(paramRow(2))
        'Fin Pincha
        paramProductoEntidad.Descripcion = paramRow(3)
        paramProductoEntidad.Stock = paramRow(4)
        paramProductoEntidad.Fecha_Alta_Sistema = paramRow(5)
        paramProductoEntidad.Fecha_Salida = paramRow(6)
        paramProductoEntidad.Fecha_Arribo_Sucursal = paramRow(7)
        paramProductoEntidad.Precio = paramRow(8)
        paramProductoEntidad.Novedad = paramRow(9)
        paramProductoEntidad.FlujoVenta = paramRow(10)
        paramProductoEntidad.BL = paramRow(11)
    End Sub

    Private Function ObtenerTipoProducto(ByVal paramID As Integer) As TipoProductoEntidad
        For Each MiTipoProducto As TipoProductoEntidad In (New MAPPER.TipoProductoMPP).ListarTipoProducto
            If MiTipoProducto.ID_TipoProducto = paramID Then
                Return MiTipoProducto
            End If
        Next
    End Function

    Private Function ObtenerGenero(ByVal paramID As Integer) As GeneroEntidad
        For Each MiGenero As GeneroEntidad In (New MAPPER.GeneroMPP).ListarGeneros
            If MiGenero.ID_Genero = paramID Then
                Return MiGenero
            End If
        Next
    End Function


    ''' 
    ''' <param name="paramProductoEntidad"></param>
    Public Overridable Sub GuardarCalificarNovedad(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "update producto set Novedad = @Novedad where ID_Producto = @ID_Producto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@Novedad", paramProductoEntidad.Novedad))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub

    ''' 
    ''' <param name="paramProductoEntidad"></param>
    Public Sub GuardarCalificarFlujoVenta(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "update producto set Flujo_Venta = @FlujoVenta where ID_Producto = @ID_Producto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@FlujoVenta", paramProductoEntidad.FlujoVenta))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub

    ''' <summary>Este método se encargará de persistir un producto.</summary>
    ''' <param name="paramProductoEntidad"></param>
    Public Overridable Sub NuevoProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "Insert into Producto values(@ID_Producto, @ID_Genero, @ID_TipoProducto, @Descripcion, @Stock, @Fec_Alta_Sistema, @Fec_Salida, @Fec_Arribo_Suc, @Precio, @Novedad, @Flujo_Venta, @BL)"
        Dim MiComando = BD.MiComando(ComandoStr)
        paramProductoEntidad.ID = BD.ObtenerID("Producto", "ID_Producto")
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@ID_Genero", paramProductoEntidad.Genero.ID_Genero))
            .Add(New SqlParameter("@ID_TipoProducto", paramProductoEntidad.TipoProducto.ID_TipoProducto))
            .Add(New SqlParameter("@Descripcion", paramProductoEntidad.Descripcion))
            .Add(New SqlParameter("@Stock", paramProductoEntidad.Stock))
            .Add(New SqlParameter("@Fec_Alta_Sistema", paramProductoEntidad.Fecha_Alta_Sistema))
            .Add(New SqlParameter("@Fec_Salida", paramProductoEntidad.Fecha_Salida))
            .Add(New SqlParameter("@Fec_Arribo_Suc", paramProductoEntidad.Fecha_Arribo_Sucursal))
            .Add(New SqlParameter("@Precio", paramProductoEntidad.Precio))
            .Add(New SqlParameter("@Novedad", 0))
            .Add(New SqlParameter("@Flujo_Venta", 0))
            .Add(New SqlParameter("@BL", paramProductoEntidad.BL))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub


    Public Overridable Sub ModificarProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "update Producto set ID_Genero=@ID_Genero, ID_TipoProducto=@ID_TipoProducto, Descripcion=@Descripcion, Stock=@Stock, Fec_Salida=@Fec_Salida, Fec_Arribo_Suc=@Fec_Arribo_Suc, Precio = @Precio where ID_Producto=@ID_Producto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@ID_Genero", paramProductoEntidad.Genero.ID_Genero))
            .Add(New SqlParameter("@ID_TipoProducto", paramProductoEntidad.TipoProducto.ID_TipoProducto))
            .Add(New SqlParameter("@Descripcion", paramProductoEntidad.Descripcion))
            .Add(New SqlParameter("@Stock", paramProductoEntidad.Stock))
            .Add(New SqlParameter("@Fec_Salida", paramProductoEntidad.Fecha_Salida))
            .Add(New SqlParameter("@Fec_Arribo_Suc", paramProductoEntidad.Fecha_Arribo_Sucursal))
            .Add(New SqlParameter("@Precio", paramProductoEntidad.Precio))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub


    Public Overridable Sub BajaProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "update Producto set BL=@BL where ID_Producto=@ID_Producto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@BL", True))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub


    Public Function VentasAsociadasProducto(ByVal paramProductoEntidad As ProductoEntidad) As Integer
        Dim VentasAsociadas As Integer
        Dim MiComandoStr As String = "Select cantidad from Detalle_Venta where ID_Producto=@ID_Producto"
        Dim MiComando = BD.MiComando(MiComandoStr)
        Dim MiDataTable As New DataTable
        Dim MiListaProductoEntidad As New List(Of ProductoEntidad)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
        End With
        MiDataTable = BD.ExecuteDataTable(MiComando)
        For Each MiRow As DataRow In MiDataTable.Rows
            'Acá tengo una duda de negocio. A que llamo venta asociada?
            'A la cantidad de productos vendidos, o a la cantidad de ventas hechas????
            'Ahora tomo la cantidad de productos vendidos....
            VentasAsociadas = MiRow(0)
        Next
        Return VentasAsociadas
    End Function


End Class

