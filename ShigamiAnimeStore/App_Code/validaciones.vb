Imports Microsoft.VisualBasic

Public Class validaciones
    Public Shared Function validarPagina(ByVal paramPage As Page) As Boolean
        If BLL.SesionBLL.Current.Usuario Is Nothing Then
            Return False
        End If
        Dim _perfilUsuario As Entidades.PermisoBase = DirectCast(BLL.SesionBLL.Current.Usuario.Perfil, Entidades.PermisoBase)
        For Each MiPermiso As Entidades.PermisoBase In _perfilUsuario.ObtenerHijos
            If MiPermiso.URL.ToUpper = paramPage.AppRelativeVirtualPath.ToString.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Sub validarSubmit(ByVal paramPage As Page, ByRef _txtError As HtmlGenericControl, ByRef _labelError As Label)
        paramPage.Validate()
        If Not paramPage.IsValid Then
            Throw New BLL.CamposincompletosException
        Else
            _txtError.Visible = False
            _labelError.Text = ""
        End If
    End Sub
End Class
