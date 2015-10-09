Imports System.Data.SqlClient

Public Class ContactoMPP
    Public Sub EnviarConsulta(ByVal paramContacto As Entidades.Contacto)
        Try
            Dim MisParametros As New Hashtable
            paramContacto.ID = DAL.Conexion.ObtenerID("Contacto", "ID_Contacto")
            MisParametros.Add("@ID_Contacto", paramContacto.ID)
            MisParametros.Add("@Nombre", paramContacto.Nombre)
            MisParametros.Add("@Apellido", paramContacto.Apellido)
            MisParametros.Add("@Titulo", paramContacto.Titulo)
            MisParametros.Add("@Mensaje", paramContacto.Mensaje)
            MisParametros.Add("@Telefono", paramContacto.Telefono)
            MisParametros.Add("@Correo", paramContacto.Mail)
            MisParametros.Add("@Contestado", False)
            MisParametros.Add("@Respuesta", "")
            DAL.Conexion.ExecuteNonQuery("AltaContacto", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function obtenerMensajesContacto() As List(Of Entidades.Contacto)
        Try
            Dim _listaContacto As New List(Of Entidades.Contacto)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Contacto where Contestado=@Contestado")
            With MiComando.Parameters
                .Add(New SqlParameter("@Contestado", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _contacto As New Entidades.Contacto
                Me.Formatear(dr, _contacto)
                _listaContacto.Add(_contacto)
            Next
            Return _listaContacto
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function obtenerMensajeContacto(ByVal paramContacto As Entidades.Contacto) As Entidades.Contacto
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Contacto where ID_Contacto=@ID_Contacto")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Contacto", paramContacto.ID))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _contacto As New Entidades.Contacto
                Me.Formatear(_dt.Rows(0), _contacto)
                Return _contacto
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub responderConsulta(ByVal paramContacto As Entidades.Contacto)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update Contacto set Respuesta=@Respuesta, Contestado=@Contestado where ID_Contacto=@ID_Contacto")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Contacto", paramContacto.ID))
                .Add(New SqlParameter("@Respuesta", paramContacto.Respuesta))
                .Add(New SqlParameter("@Contestado", True))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Formatear(_datarow As DataRow, paramContacto As Entidades.Contacto)
        paramContacto.ID = _datarow.Item("ID_Contacto")
        paramContacto.Nombre = _datarow.Item("Nombre")
        paramContacto.Apellido = _datarow.Item("Apellido")
        paramContacto.Telefono = _datarow.Item("Telefono")
        paramContacto.Mail = _datarow.Item("Correo")
        paramContacto.Titulo = _datarow.Item("Titulo")
        paramContacto.Mensaje = _datarow.Item("Mensaje")
        paramContacto.Contestado = _datarow.Item("Contestado")
        If _datarow.Item("Respuesta") Is DBNull.Value Then
            paramContacto.Respuesta = ""
        Else
            paramContacto.Respuesta = _datarow.Item("Respuesta")
        End If

    End Sub

End Class
