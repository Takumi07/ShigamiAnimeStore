Public Class DVEntidades

    Sub New(ByVal NombreTabla As String, ByVal ListaRegistros As List(Of String))
        Me.vNombreTabla = NombreTabla
        Me.vRegistros = ListaRegistros
    End Sub

    Private vNombreTabla As String
    Public Property NombreTabla() As String
        Get
            Return vNombreTabla
        End Get
        Set(ByVal value As String)
            vNombreTabla = value
        End Set
    End Property


    Private vRegistros As List(Of String)
    Public Property Registros() As List(Of String)
        Get
            Return vRegistros
        End Get
        Set(ByVal value As List(Of String))
            vRegistros = value
        End Set
    End Property



End Class
