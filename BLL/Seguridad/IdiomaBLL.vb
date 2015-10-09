Imports Entidades
Public Class IdiomaBLL
    Dim _gestorIdioma As New Mapper.IdiomaMPP

    Public Sub altaIdioma(ByVal paramIdioma As Entidades.Idioma)
        Try
            _gestorIdioma.altaIdioma(paramIdioma)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Alta, "Se dio de alta el idioma " & paramIdioma.Nombre)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificarIdioma(ByVal paramIdioma As Entidades.Idioma)
        Try
            _gestorIdioma.modificarIdioma(paramIdioma)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Media, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Se modifico el idioma " & paramIdioma.Nombre)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub bajaIdioma(ByVal paramIdioma As Entidades.Idioma)
        Try
            _gestorIdioma.bajaIdioma(paramIdioma)
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Baja, "Se elimino el idioma " & paramIdioma.Nombre)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function Cargar(ByVal paramIdiomaEntidad As Entidades.Idioma) As Entidades.Idioma
        Try
            Return _gestorIdioma.Cargar(paramIdiomaEntidad)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarIdioma(ByVal _nombreIdioma As String) As Entidades.Idioma
        Try
            Return _gestorIdioma.consultarIdioma(_nombreIdioma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarIdiomas() As List(Of Entidades.Idioma)
        Try
            Return _gestorIdioma.listarIdiomas()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function traducirMensaje(ByVal paramIdioma As Entidades.Idioma, ByVal _idControl As Integer) As String
        Try
            Return Mapper.IdiomaMPP.traducirMensaje(paramIdioma, _idControl)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chequearNombreIdioma(ByVal paramIdioma As Entidades.Idioma) As Boolean
        Try
            Return _gestorIdioma.chequearNombreIdioma(paramIdioma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
