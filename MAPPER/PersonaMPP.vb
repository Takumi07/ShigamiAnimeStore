Imports System.Data.SqlClient

Public Class PersonaMPP
    Public Function obtenerPersonaPorDNI(ByVal _dni As Integer) As ENTIDADES.Persona
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@DNI", _dni)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("obtenerPersonaPorDNI", MisParametros)
            If _dt.Rows.Count = 1 Then
                Dim _persona As New ENTIDADES.Persona
                Me.Formatear(_dt.Rows(0), _persona)
                Return _persona
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerPersona(ByVal _id As Integer) As Entidades.Persona
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID", _id.ToString)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("obtenerPersonaPorID", MisParametros)
            If _dt.Rows.Count = 1 Then
                Dim _persona As New Entidades.Persona
                Me.Formatear(_dt.Rows(0), _persona)
                Return _persona
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function obtenerPersonas() As List(Of ENTIDADES.Persona)
        Try
            Dim ComandoStr As String
            ComandoStr = "Select * from Persona"
            Dim MiComando = DAL.BD.MiComando(ComandoStr)
            Dim MiDataTable As New DataTable
            MiDataTable = DAL.BD.ExecuteDataTable(MiComando)
            Dim MiListaPersonas As New List(Of ENTIDADES.Persona)
            For Each MiRow As DataRow In MiDataTable.Rows
                Dim MiPersona As New ENTIDADES.Persona
                Me.Formatear(MiRow, MiPersona)
                MiListaPersonas.Add(MiPersona)
            Next
            Return MiListaPersonas
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function comprobarCorreo(ByVal paramPersona As Entidades.Persona) As Boolean
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Persona where Mail=@Mail")
            With MiComando.Parameters
                .Add(New SqlParameter("@Mail", paramPersona.Mail))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "ABM"
    Public Sub AltaPersona(ByVal paramPersona As Entidades.Persona)
        Dim MisParametros As New Hashtable
        'Le paso el id al parametro para ver si me funciona en la otra clase
        paramPersona.ID = DAL.Conexion.ObtenerID("Persona", "ID_Persona")
        MisParametros.Add("@ID_Persona", paramPersona.ID)
        MisParametros.Add("@DNI", paramPersona.DNI)
        MisParametros.Add("@Nombre", paramPersona.Nombre)
        MisParametros.Add("@Apellido", paramPersona.Apellido)
        MisParametros.Add("@FechaNacimiento", paramPersona.FechaNacimiento)
        'ACA NO PASA NADA PORQUE LAS NACIONALIDADES YA VIENEN CARGADAS EN EL SISTEMA!!!!! (LAS ELIJE DE UN COMBO O ALGO)
        MisParametros.Add("@ID_Nacionalidad", paramPersona.Nacionalidad.ID)
        MisParametros.Add("@Mail", paramPersona.Mail)
        'OJO ACA PORQUE LA DIRECCIÓN HAY QUE DARLA DE ALTA ANTES PORQUE LO COMPLETA LA PESONA!!! ==> El ID volvería de la referencia que paso.
        Dim MiDireccion As New DireccionMPP
        MiDireccion.AltaDireccion(paramPersona.Direccion)
        MisParametros.Add("@Direccion", paramPersona.Direccion.ID)

        MisParametros.Add("@Imagen", paramPersona.Imagen)

        '¿LA PERSONA NO TIENE BL?
        DAL.Conexion.ExecuteNonQuery("altaPersona", MisParametros)

        'Doy de Alta los teléfonos
        Dim MiTelefonoMPP As New TelefonoMPP
        MiTelefonoMPP.altaTelefonos(paramPersona.ID, paramPersona.Telefono)
    End Sub


#End Region


    Private Sub Formatear(_datarow As DataRow, _persona As Entidades.Persona)
        _persona.ID = _datarow.Item("ID_Persona")
        _persona.DNI = _datarow.Item("DNI")
        _persona.Nombre = _datarow.Item("Nombre")
        _persona.Apellido = _datarow.Item("Apellido")
        _persona.FechaNacimiento = _datarow.Item("Fecha_Nacimiento")
        If _datarow.Item("Imagen") Is DBNull.Value Then
            _persona.Imagen = ""
        Else
            _persona.Imagen = _datarow.Item("Imagen")
        End If
        _persona.Mail = _datarow.Item("Mail")
        'FALTAN DATOS
    End Sub


End Class
