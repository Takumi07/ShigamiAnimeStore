Imports ENTIDADES
Imports DAL

Public Class MangaBLL
    Inherits ProductoBLL
#Region "ABM"
    Public Overrides Sub Guardar(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            MyBase.Guardar(paramProductoEntidad)
            Dim MiMangaDAL As New MAPPER.MangaMPP
            MiMangaDAL.NuevoProducto(paramProductoEntidad)
        Catch MiExepcionAltaProducto As ExepcionAltaProducto
            Throw New ExepcionAltaManga
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionAltaManga
        End Try
    End Sub

    Public Overrides Sub Modificar(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            MyBase.Modificar(paramProductoEntidad)
            Dim MiMangaDAL As New MAPPER.MangaMPP
            MiMangaDAL.ModificarProducto(paramProductoEntidad)
        Catch MiExepcionModificarProducto As ExepcionModificarProducto
            Throw New ExepcionModificarManga
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionModificarManga
        End Try
    End Sub

    Public Overrides Sub Baja(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            'Es lo ùnico que va a hacer en baja porque solo la TABLA producto contiene el campo de BL.
            MyBase.Baja(paramProductoEntidad)
        Catch ex As ExepcionModificarProducto
            Throw New ExepcionElimiarManga
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionElimiarManga
        End Try
    End Sub
#End Region


    'Se cambio porque en la bsae no se pone como mustoverridable.
    'Se pone overloads para evitar advertencias, recordar que es necesario porque es un metodo sobrecargado
    'que esta sobrecargado en la deribada
    Public Overloads Sub CalificarNovedad(ByVal paramProductoEntidad As ENTIDADES.ProductoEntidad)
        Try
            Dim MiPuntaje As Integer
            'ASIGNACIÒN DE PUNTAJE POR FECHA DE ALTA.

            Dim int As Integer
            int = DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now)
            If DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now) <= 72 Then
                MiPuntaje = +120
            ElseIf DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now) > 72 AndAlso DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now) <= 96 Then
                MiPuntaje = +100
            ElseIf DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now) > 96 AndAlso DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now) <= 120 Then
                MiPuntaje = +80
            ElseIf DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Alta_Sistema, Date.Now) > 120 Then
                MiPuntaje = +50
            End If
            'FIN ASIGNACIÓN DE PUTNAJE POR FECHA DE ALTA.

            'Asignaciòn de puntaje por tipo de producto
            'Es constante, porque ya estoy adentro de manga. En producto pregunto por cada uno.
            MiPuntaje += 150
            'Fin Asignaciòn de puntaje por tipo de producto

            'Asignación de puntaje por fecha de arribo
            If DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Arribo_Sucursal, Date.Now) < 48 Then
                MiPuntaje += 100
            ElseIf DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Arribo_Sucursal, Date.Now) >= 48 AndAlso DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Arribo_Sucursal, Date.Now) <= 72 Then
                MiPuntaje += 75
            ElseIf DateDiff(DateInterval.Hour, paramProductoEntidad.Fecha_Arribo_Sucursal, Date.Now) > 72 Then
                MiPuntaje += 50
            End If
            'Fin Asignación de puntaje por fecha de arribo


            'ACA ESTA LA MAGIA!!!!!!
            'ASIGNACIÒN ESPECIAL PARA MANGA!

            If DateDiff(DateInterval.DayOfYear, DirectCast(paramProductoEntidad, MangaEntidad).Fec_Salida_PTomo, Date.Now) < 4 Then
                MiPuntaje += 130
            ElseIf DateDiff(DateInterval.DayOfYear, DirectCast(paramProductoEntidad, MangaEntidad).Fec_Salida_PTomo, Date.Now) >= 4 AndAlso DateDiff(DateInterval.DayOfYear, DirectCast(paramProductoEntidad, MangaEntidad).Fec_Salida_PTomo, Date.Now) < 10 Then
                MiPuntaje += 80
            ElseIf DateDiff(DateInterval.DayOfYear, DirectCast(paramProductoEntidad, MangaEntidad).Fec_Salida_PTomo, Date.Now) >= 10 Then
                MiPuntaje += 50
            End If
            'FIN ASIGNACIÓN ESPECIAL PARA MANGA

            'Asigncación de Calificación
            If MiPuntaje >= 0 AndAlso MiPuntaje <= 219 Then
                paramProductoEntidad.Novedad = 0
            ElseIf MiPuntaje >= 220 AndAlso MiPuntaje <= 270 Then
                paramProductoEntidad.Novedad = 15
            ElseIf MiPuntaje >= 271 AndAlso MiPuntaje <= 349 Then
                paramProductoEntidad.Novedad = 25
            ElseIf MiPuntaje >= 350 Then
                paramProductoEntidad.Novedad = 35
            End If
            'Fin Asigncación de Calificación


            Dim MiMangaDAL As New MAPPER.MangaMPP
            MiMangaDAL.GuardarCalificarNovedad(paramProductoEntidad)

        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            'PARA MI ESTO NO DEBERÌA MOSTRARLE NADA AL USUARIO..
        End Try
    End Sub
End Class

