Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES
Imports DAL
Public Class MangaMPP
    Inherits MAPPER.ProductoMPP


    ''' 
    ''' <param name="paramProductoEntidad"></param>
    Public Overrides Sub GuardarCalificarNovedad(ByVal paramProductoEntidad As ProductoEntidad)
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
    Public Overrides Sub NuevoProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "Insert into Manga values (@ID_Producto, @Fec_Salida_PTomo, @N_Tomo)"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@Fec_Salida_PTomo", DirectCast(paramProductoEntidad, MangaEntidad).Fec_Salida_PTomo))
            .Add(New SqlParameter("@N_Tomo", DirectCast(paramProductoEntidad, MangaEntidad).N_Tomo))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub

    Public Overrides Sub ModificarProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "update Manga set Fec_Salida_PTomo=@Fec_Salida_PTomo, N_Tomo=@N_Tomo where ID_Producto=@ID_Producto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@Fec_Salida_PTomo", DirectCast(paramProductoEntidad, MangaEntidad).Fec_Salida_PTomo))
            .Add(New SqlParameter("@N_Tomo", DirectCast(paramProductoEntidad, MangaEntidad).N_Tomo))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub

    Public Overrides Sub BajaProducto(ByVal ProductoEntidad As ProductoEntidad)
        'Esto esta en en la base porque solo la tabla producto tiene el campo bl. Entoces llamo a mybase.baja.
    End Sub

    Public Function ObtenerUnManga(ByVal paramID As Integer) As MangaEntidad
        Dim MiMangaEntidad As New MangaEntidad
        Dim MiComandoStr2 As String = "Select * from Manga where ID_PRODUCTO=@ID_PRODUCTO"
        Dim MiComando2 = BD.MiComando(MiComandoStr2)
        Dim MiDataTable2 As New DataTable
        With MiComando2.Parameters
            .Add(New SqlParameter("@ID_PRODUCTO", paramID))
        End With
        MiDataTable2 = BD.ExecuteDataTable(MiComando2)
        FormatearManga(MiDataTable2.Rows(0), MiMangaEntidad)
        Return MiMangaEntidad
    End Function

    Private Sub FormatearManga(ByVal paramRow As DataRow, ByVal paramMangaEntidad As MangaEntidad)
        paramMangaEntidad.Fec_Salida_PTomo = paramRow(1)
        paramMangaEntidad.N_Tomo = paramRow(2)
    End Sub


End Class

