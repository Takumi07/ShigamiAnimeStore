Public Class resumenCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Acavaelcarrito") = "" Then
            sinProductos.Visible = True
        Else

        End If
    End Sub

End Class