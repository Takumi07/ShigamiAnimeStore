Public Class _error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lbl_TituloErrorGenerico.Text = Session("Error").ToString
        redireccionar()
    End Sub


    Private Sub redireccionar()
        Response.AddHeader("REFRESH", "4;URL=index.aspx")
    End Sub

End Class