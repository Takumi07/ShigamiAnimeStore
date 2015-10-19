Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES
Imports DAL


Public Class AnimeMPP
    Inherits MAPPER.ProductoMPP


    Public Overrides Sub NuevoProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "Insert into Anime values(@ID_Producto, @N_DVD, @Cantidad_DVD, @Temporada_Completa)"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@N_DVD", DirectCast(paramProductoEntidad, AnimeEntidad).N_DVD))
            .Add(New SqlParameter("@Cantidad_DVD", DirectCast(paramProductoEntidad, AnimeEntidad).Cantidad))
            .Add(New SqlParameter("@Temporada_Completa", DirectCast(paramProductoEntidad, AnimeEntidad).Temporada_Completa))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub

    Public Overrides Sub ModificarProducto(ByVal paramProductoEntidad As ProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "update Anime set N_DVD=@N_DVD, Cantidad_DVD=@Cantidad_DVD, Temporada_Completa=@Temporada_Completa where ID_Producto=@ID_Producto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Producto", paramProductoEntidad.ID))
            .Add(New SqlParameter("@N_DVD", DirectCast(paramProductoEntidad, AnimeEntidad).N_DVD))
            .Add(New SqlParameter("@Cantidad_DVD", DirectCast(paramProductoEntidad, AnimeEntidad).Cantidad))
            .Add(New SqlParameter("@Temporada_Completa", DirectCast(paramProductoEntidad, AnimeEntidad).Temporada_Completa))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub

    Public Overrides Sub BajaProducto(ByVal ProductoEntidad As ProductoEntidad)
        'Esto esta en en la base porque solo la tabla producto tiene el campo bl. Entoces llamo a mybase.baja.
    End Sub


    Public Function ObtenerUnAnime(ByVal paramID As Integer) As AnimeEntidad
        Dim MiAnimeEntidad As New AnimeEntidad
        Dim MiComandoStr3 As String = "Select * from Anime where ID_PRODUCTO=@ID_PRODUCTO"
        Dim MiComando3 = BD.MiComando(MiComandoStr3)
        Dim MiDataTable3 As New DataTable
        With MiComando3.Parameters
            .Add(New SqlParameter("@ID_PRODUCTO", paramID))
        End With
        MiDataTable3 = BD.ExecuteDataTable(MiComando3)
        FormatearAnime(MiDataTable3.Rows(0), MiAnimeEntidad)
        Return MiAnimeEntidad
    End Function


    Private Sub FormatearAnime(ByVal paramRow As DataRow, ByVal paramAnimeEntidad As AnimeEntidad)
        paramAnimeEntidad.N_DVD = paramRow(1)
        paramAnimeEntidad.Cantidad = paramRow(2)
        paramAnimeEntidad.Temporada_Completa = paramRow(3)
    End Sub

End Class

