Imports ENTIDADES


Public Class ProductoBLL


    'El flujo de venta se califica para todos los productos igual.
    'CAMBIO!!! COMO TENGO QUE CALIFICAR TODOS LOS PRODUCTOS, NO LE PASO POR PARAMETRO UN PRODUCTOENTIDAD
    'Public Sub CalificarFlujoVenta(ByVal ProductoEntidad As ProductoEntidad)
    Public Sub CalificarFlujoVenta()
        Try
            Dim MiListaProductos As New List(Of ProductoEntidad)
            MiListaProductos = (New MAPPER.ProductoMPP).ListarProductos

            For Each MiProducto As ProductoEntidad In MiListaProductos
                Dim CDiasProdIngHastaFechAct As Integer
                Dim CDiasAltaProdHastaFechIng As Integer
                Dim ValorReferente As Double
                Dim VentasAsociadas As Integer
                Dim Puntaje As Double
                'No estoy seguro de que sea dayofyear => Al parecer funca!
                CDiasProdIngHastaFechAct = DateDiff(DateInterval.DayOfYear, MiProducto.Fecha_Arribo_Sucursal, Date.Now)
                'Ojo! Puede dar Cero! 
                CDiasAltaProdHastaFechIng = DateDiff(DateInterval.DayOfYear, MiProducto.Fecha_Alta_Sistema, MiProducto.Fecha_Arribo_Sucursal)
                If CDiasAltaProdHastaFechIng = 0 Or CDiasProdIngHastaFechAct = 0 Then
                    ValorReferente = 0
                Else
                    ValorReferente = CDiasProdIngHastaFechAct / CDiasAltaProdHastaFechIng
                End If
                VentasAsociadas = (New MAPPER.ProductoMPP).VentasAsociadasProducto(MiProducto)
                If VentasAsociadas = 0 Or ValorReferente = 0 Then
                    Puntaje = 0
                Else
                    Puntaje = VentasAsociadas / ValorReferente
                End If
                If Puntaje >= 0 And Puntaje <= 299 Then
                    'If Puntaje >= 0 And Puntaje <= 15 Then
                    MiProducto.FlujoVenta = 10
                End If
                If Puntaje > 300 And Puntaje <= 599 Then
                    MiProducto.FlujoVenta = 15
                End If
                If Puntaje >= 600 Then
                    MiProducto.FlujoVenta = 25
                End If
                'Impacto la calificación!!!! 
                Dim MiProductoDAL As New MAPPER.ProductoMPP
                MiProductoDAL.GuardarCalificarFlujoVenta(MiProducto)
            Next
        Catch ex As Exception

        End Try
    End Sub


    'ESTE MUSTOVERRIDE, LO VOY A TENER QUE SACAR PORQUE COMO USO LA CLASE PRA HACER COSAS 
    'NO LA PUEDO DECLARAR COMO ABSTRACTA
    'Public MustOverride Sub CalificarNovedad(ByVal ProductoEntidad As ProductoEntidad)
    'Lo mismo que arriba.
    'Public Overridable Sub CalificarNovedad(ByVal ProductoEntidad As ProductoEntidad)
    Public Overridable Sub CalificarNovedad()
        Try
            Dim MiListaProductoEntidad As New List(Of ProductoEntidad)
            MiListaProductoEntidad = (New MAPPER.ProductoMPP).ListarProductos
            For Each MiProducto As ProductoEntidad In MiListaProductoEntidad
                Dim MiPuntaje As Integer
                If TypeOf (MiProducto) Is MangaEntidad Then
                    'La clase mangabll se encargar de aplicar la lógica específica para calificar novedad.
                    Dim MiMangaBLL As New MangaBLL
                    MiMangaBLL.CalificarNovedad(MiProducto)
                Else
                    'ASIGNACIÒN DE PUNTAJE POR FECHA DE ALTA.
                    If DateDiff(DateInterval.Hour, MiProducto.Fecha_Alta_Sistema, Date.Now) <= 72 Then
                        MiPuntaje += 120
                    ElseIf DateDiff(DateInterval.Hour, MiProducto.Fecha_Alta_Sistema, Date.Now) > 72 AndAlso DateDiff(DateInterval.Hour, MiProducto.Fecha_Alta_Sistema, Date.Now) <= 96 Then
                        MiPuntaje += 100
                    ElseIf DateDiff(DateInterval.Hour, MiProducto.Fecha_Alta_Sistema, Date.Now) > 96 AndAlso DateDiff(DateInterval.Hour, MiProducto.Fecha_Alta_Sistema, Date.Now) <= 120 Then
                        MiPuntaje += 80
                    ElseIf DateDiff(DateInterval.Hour, MiProducto.Fecha_Alta_Sistema, Date.Now) > 120 Then
                        MiPuntaje += 50
                    End If
                    'FIN ASIGNACIÓN DE PUTNAJE POR FECHA DE ALTA.

                    'Asignaciòn de puntaje por tipo de producto
                    If MiProducto.TipoProducto.Descripcion = "Anime" Then
                        MiPuntaje += 120
                    ElseIf MiProducto.TipoProducto.Descripcion = "Cosplay" Then
                        MiPuntaje += 100
                    ElseIf MiProducto.TipoProducto.Descripcion = "Comics" Then
                        MiPuntaje += 90
                    ElseIf MiProducto.TipoProducto.Descripcion = "Figuras" Then
                        MiPuntaje += 70
                    ElseIf MiProducto.TipoProducto.Descripcion = "Merchandising" Then
                        MiPuntaje += 50
                    ElseIf MiProducto.TipoProducto.Descripcion = "Jpop" Then
                        MiPuntaje += 40
                    End If
                    'Fin Asignaciòn de puntaje por tipo de producto

                    'Asignación de puntaje por fecha de arribo
                    If DateDiff(DateInterval.Hour, MiProducto.Fecha_Arribo_Sucursal, Date.Now) < 48 Then
                        MiPuntaje += 100
                    ElseIf DateDiff(DateInterval.Hour, MiProducto.Fecha_Arribo_Sucursal, Date.Now) >= 48 AndAlso DateDiff(DateInterval.Hour, MiProducto.Fecha_Arribo_Sucursal, Date.Now) <= 72 Then
                        MiPuntaje += 75
                    ElseIf DateDiff(DateInterval.Hour, MiProducto.Fecha_Arribo_Sucursal, Date.Now) > 72 Then
                        MiPuntaje += 50
                    End If
                    'Fin Asignación de puntaje por fecha de arribo

                    'Asigncación de Calificación
                    If MiPuntaje >= 0 AndAlso MiPuntaje <= 219 Then
                        MiProducto.Novedad = 0
                    ElseIf MiPuntaje >= 220 AndAlso MiPuntaje <= 270 Then
                        MiProducto.Novedad = 15
                    ElseIf MiPuntaje >= 271 AndAlso MiPuntaje <= 349 Then
                        MiProducto.Novedad = 25
                    ElseIf MiPuntaje >= 350 Then
                        MiProducto.Novedad = 35
                    End If
                    'Fin Asigncación de Calificación
                    Dim MiProductoDAL As New MAPPER.ProductoMPP
                    MiProductoDAL.GuardarCalificarNovedad(MiProducto)
                End If
            Next
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
        End Try

    End Sub

    Public Overridable Function ListarProductos() As List(Of ProductoEntidad)
        Try
            Return (New MAPPER.ProductoMPP).ListarProductos
            BitacoraBLL.GuardarBitacora("Se listaron todos los productos de la base de datos", ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionRecuperarInformacion
        End Try
    End Function

#Region "ABM"
    Public Overridable Sub Guardar(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            Dim MiProductoDAL As New MAPPER.ProductoMPP
            paramProductoEntidad.Fecha_Alta_Sistema = Date.Now
            paramProductoEntidad.BL = False
            MiProductoDAL.NuevoProducto(paramProductoEntidad)
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionAltaProducto
        End Try
    End Sub

    Public Overridable Sub Modificar(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            Dim MiProductoDAL As New MAPPER.ProductoMPP
            MiProductoDAL.ModificarProducto(paramProductoEntidad)
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionModificarProducto
        End Try
    End Sub

    Public Overridable Sub Baja(ByVal paramProductoEntidad As ProductoEntidad)
        Try
            Dim MiProductoDAL As New MAPPER.ProductoMPP
            MiProductoDAL.BajaProducto(paramProductoEntidad)
        Catch ex As Exception
            BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, ENTIDADES.Bitacora.tipoPrioridadBitacora.Media, SesionBLL.Current.Usuario.NombreUsuario)
            Throw New ExepcionEliminarProducto
        End Try
    End Sub
#End Region
End Class

