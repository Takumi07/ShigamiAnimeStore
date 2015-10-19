Public Class BitacoraBLL
    Private Shared _mapeador As New Mapper.BitacoraMPP
    Public Function consultarBitacora(ByVal paramUsuario As Entidades.Usuario, ByVal paramFecha As Date, ByVal paramOperacion As Integer) As List(Of Entidades.Bitacora)
        Try
            If paramUsuario Is Nothing And paramFecha = "#12:00:00 AM#" And paramOperacion = 0 Then
                'NO TIENE NADA
                Return _mapeador.consultarBitacora()
            ElseIf paramUsuario Is Nothing And paramFecha = "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE SOLO OPERACION
                Return _mapeador.consultarBitacora(paramOperacion)
            ElseIf paramUsuario Is Nothing And paramFecha <> "#12:00:00 AM#" And paramOperacion = 0 Then
                'TIENE LA FECHA
                Return _mapeador.consultarBitacora(paramFecha)
            ElseIf paramUsuario Is Nothing And paramFecha <> "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE LA FECHA Y EL OPERACION
                Return _mapeador.consultarBitacora(paramFecha, paramOperacion)
            ElseIf Not paramUsuario Is Nothing And paramFecha = "#12:00:00 AM#" And paramOperacion = 0 Then
                'TIENE EL USUARIO
                Return _mapeador.consultarBitacora(paramUsuario)
            ElseIf Not paramUsuario Is Nothing And paramFecha = "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE EL USUARIO y EL OPERACION
                Return _mapeador.consultarBitacora(paramUsuario, paramOperacion)
            ElseIf Not paramUsuario Is Nothing And paramFecha <> "#12:00:00 AM#" And paramOperacion = 0 Then
                'TIENE EL USUARIO Y LA FECHA
                Return _mapeador.consultarBitacora(paramUsuario, paramFecha)
            ElseIf Not paramUsuario Is Nothing And paramFecha <> "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE EL USUARIO, LA PERSONA y EL ESTADO
                Return _mapeador.consultarBitacora(paramUsuario, paramFecha, paramOperacion)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function consultarBitacora() As List(Of Entidades.Bitacora)
        Try
            Return _mapeador.consultarBitacora()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub Alta(ByVal _usuario As Entidades.Usuario, ByVal _prioridad As Entidades.Bitacora.tipoPrioridadBitacora, ByVal _tipooperacion As Entidades.Bitacora.tipoOperacionBitacora, ByVal _descripcion As String)
        Try
            Dim paramBitacora As New Entidades.Bitacora(_usuario, _prioridad, _tipooperacion, _descripcion)
            _mapeador.altaBitacora(paramBitacora)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    'ver este método esta chamulletimo
    Public Shared Sub GuardarBitacora(ByVal paramDetalle As String, ByVal paramIDTipoBitacora As Integer, ByVal paramNombreUsuario As String)
        Try
            Dim MiBitacoraDAL As New MAPPER.BitacoraMPP
            Dim MiBitacoraEntidad As New ENTIDADES.Bitacora
            With MiBitacoraEntidad
                .TipoOperacion = paramIDTipoBitacora
                .Descripcion = paramDetalle
                .FechaHora = DateTime.Now
                .TipoOperacion = ENTIDADES.Bitacora.tipoOperacionBitacora.Alta
                Dim MiUsuario As New ENTIDADES.Usuario
                MiUsuario.NombreUsuario = paramNombreUsuario
                .Usuario = MiUsuario
            End With
            MiBitacoraDAL.altaBitacora(MiBitacoraEntidad)
        Catch ex As Exception

        End Try
    End Sub


End Class