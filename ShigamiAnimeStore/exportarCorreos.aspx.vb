Imports System.Xml

Public Class exportarCorreos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim MiPersonaBLL As New BLL.PersonaBLL
            Dim MiListaPErsona As New List(Of ENTIDADES.Persona)
            MiListaPErsona = MiPersonaBLL.listarPersonas
            GridView1.DataSource = MiListaPErsona
            GridView1.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Exportar_Click(sender As Object, e As EventArgs) Handles btn_Exportar.Click
        Dim MiPersonaBLL As New BLL.PersonaBLL
        Dim MiListaPErsona As New List(Of ENTIDADES.Persona)
        MiListaPErsona = MiPersonaBLL.listarPersonas
        Dim MiXMLWriter As New XmlTextWriter(Server.MapPath("Personas.xml"), Nothing)
        MiXMLWriter.Formatting = Formatting.Indented
        MiXMLWriter.WriteStartDocument()
        MiXMLWriter.WriteStartElement("Exportacion")
        For Each mipersona As ENTIDADES.Persona In MiListaPErsona

            MiXMLWriter.WriteStartElement("Persona")

            MiXMLWriter.WriteStartElement("DNI")
            MiXMLWriter.WriteValue(mipersona.DNI)
            MiXMLWriter.WriteEndElement()

            MiXMLWriter.WriteStartElement("Nombre")
            MiXMLWriter.WriteValue(mipersona.Nombre)
            MiXMLWriter.WriteEndElement()

            MiXMLWriter.WriteStartElement("Apellido")
            MiXMLWriter.WriteValue(mipersona.Apellido)
            MiXMLWriter.WriteEndElement()

            MiXMLWriter.WriteStartElement("Email")
            MiXMLWriter.WriteValue(mipersona.Mail)
            MiXMLWriter.WriteEndElement()


            MiXMLWriter.WriteEndElement()
        Next
        MiXMLWriter.WriteEndElement()
        MiXMLWriter.WriteEndDocument()
        MiXMLWriter.Flush()
        MiXMLWriter.Dispose()

        Session("Error") = "Se exportó la información correctamente."
        'Aca tiene que ir a la página pertinente
        Response.Redirect("error.aspx", False)

    End Sub
End Class