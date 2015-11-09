Public Class _error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Muestra un mensaje de error personalizado.
        If Session("Error") = "" Then
        Else
            Me.lbl_TituloErrorGenerico.Text = Session("Error").ToString
            redireccionar()
        End If

    End Sub


    Private Sub redireccionar()
        'redirecciona a la página luego de un período determinado.
        Response.AddHeader("REFRESH", "4;URL=index.aspx")
    End Sub

End Class