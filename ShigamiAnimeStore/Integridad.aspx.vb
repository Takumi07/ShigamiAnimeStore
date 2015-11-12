Public Class Integridad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.verificarIntegridad()
        Else
            Me.IntegridadReparada.Visible = True
            Me.botones.Visible = False
        End If

    End Sub

    Protected Sub btn_reparar_Click(sender As Object, e As EventArgs) Handles btn_reparar.Click
        BLL.DVBLL.RepararIntegridad()
    End Sub

    Private Sub verificarIntegridad()
        Try
            Dim MiListaDVEntidad As New List(Of ENTIDADES.DVEntidades)
            MiListaDVEntidad = BLL.DVBLL.DefinirErrorIntegridad


            For Each midventidades As ENTIDADES.DVEntidades In MiListaDVEntidad
                Dim labelTitulo As New Label
                labelTitulo.Text = midventidades.NombreTabla
                labelTitulo.CssClass = "panel-cabecera"
                PanelDV.Controls.Add(labelTitulo)
                PanelDV.Controls.Add(New LiteralControl("<br>"))
                PanelDV.Controls.Add(New LiteralControl("<br>"))

                For Each miString As String In midventidades.Registros
                    Dim labelRegistro As New Label
                    labelRegistro.Text = miString
                    PanelDV.Controls.Add(labelRegistro)
                    PanelDV.Controls.Add(New LiteralControl("<br>"))
                Next
                PanelDV.Controls.Add(New LiteralControl("<br>"))
                PanelDV.Controls.Add(New LiteralControl("<br>"))
                PanelDV.Controls.Add(New LiteralControl("<br>"))
            Next


        Catch ex As Exception

        End Try
    End Sub
End Class