Imports System.Data.SqlClient

Public Class UsuarioMPP
#Region "ABM"
    Public Sub altaUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            'Cambio para que el ID lo trabaje la aplicacion
            paramUsuario.ID = DAL.Conexion.ObtenerID("Usuario", "ID_Usuario")
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)

            MisParametros.Add("@NombreUsuario", paramUsuario.NombreUsuario)
            MisParametros.Add("@Password", paramUsuario.Password)
            MisParametros.Add("@ID_Patente", paramUsuario.Perfil.ID)
            'Idioma por defecto español?
            MisParametros.Add("@ID_Idioma", paramUsuario.Idioma.ID)
            'Persona
            MisParametros.Add("@ID_Persona", paramUsuario.Persona.ID)
            MisParametros.Add("@Bloqueado", False)
            MisParametros.Add("@Editable", True)
            MisParametros.Add("@Intentos", 0)
            MisParametros.Add("@FechaAlta", Today)
            MisParametros.Add("@BL", False)
            DAL.Conexion.ExecuteNonQuery("altaUsuario", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificarUsuario(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update Usuario set Password=@Password, ID_Patente=@ID_Patente, ID_Idioma=@ID_Idioma where ID_Usuario=@ID_Usuario")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@Password", paramUsuario.Password))
                .Add(New SqlParameter("@ID_Patente", paramUsuario.Perfil.ID))
                .Add(New SqlParameter("@ID_Idioma", paramUsuario.Idioma.ID))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub bajaUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@BL", True)
            DAL.Conexion.ExecuteNonQuery("bajaUsuario", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ActualizarIntentos(paramUsuario As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@Intentos", paramUsuario.Intentos)
            DAL.Conexion.ExecuteNonQuery("actualizarIntentos", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Bloqueo - Desbloqueo"
    Public Sub bloquearUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@Bloqueado", True)
            DAL.Conexion.ExecuteNonQuery("ManejoBloqueoUsuario", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub desbloquearUsuario(paramUsuario As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@Bloqueado", False)
            DAL.Conexion.ExecuteNonQuery("ManejoBloqueoUsuario", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Chequear"
    Public Function chequearUsuario(paramNombreUsuario As String) As Boolean
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@NombreUsuario", paramNombreUsuario)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("chequearUsuario", MisParametros)
            If _dt.Rows(0).Item(0) = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function chequearContraseña(paramNombreUsuario As String, paramContraseña As String) As Boolean
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@NombreUsuario", paramNombreUsuario)
            MisParametros.Add("@Password", paramContraseña)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("chequearContraseña", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chequearBloqueado(paramNombreUsuario As String) As Boolean
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@NombreUsuario", paramNombreUsuario)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("chequearBloqueado", MisParametros)
            Return DirectCast(_dt.Rows(0).Item(0), Boolean)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    <Obsolete("Esto esta mal, usuario no tiene mas el mail, va a pinchar. Revisar", True)>
    Public Function chequearMail(paramNombreUsuario As String, paramMail As String) As Boolean
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where NombreUsuario=@NombreUsuario and Correo=@Mail")
            With MiComando.Parameters
                .Add(New SqlParameter("@NombreUsuario", paramNombreUsuario))
                .Add(New SqlParameter("@Mail", paramMail))
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


#End Region
#Region "Consulta Selección FILTRO"

    Public Function consultarUsuario(ByVal paramActivo As Boolean) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and Bloqueado=@Bloqueado")
            With MiComando.Parameters
                .Add(New SqlParameter("@Bloqueado", paramActivo))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramPersona As Entidades.Persona) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and ID_Persona=@ID_Persona")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Persona", paramPersona.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramPersona As Entidades.Persona, ByVal paramActivo As Boolean) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and ID_Persona=@ID_Persona and Bloqueado=@Bloqueado")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Persona", paramPersona.ID))
                .Add(New SqlParameter("@Bloqueado", paramActivo))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function
  
    Public Function consultarUsuario(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and ID_Usuario=@ID_Usuario")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramUsuario As Entidades.Usuario, ByVal paramActivo As Boolean) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and ID_Usuario=@ID_Usuario and Bloqueado=@Bloqueado")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@Bloqueado", paramActivo))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramUsuario As Entidades.Usuario, ByVal paramPersona As Entidades.Persona) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and ID_Usuario=@ID_Usuario and ID_Persona=@ID_Persona")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@ID_Persona", paramPersona.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarUsuario(ByVal paramUsuario As Entidades.Usuario, ByVal paramPersona As Entidades.Persona, ByVal paramActivo As Boolean) As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuario As New List(Of Entidades.Usuario)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where BL=@BL and ID_Usuario=@ID_Usuario and ID_Persona=@ID_Persona and Bloqueado=@Bloqueado")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@ID_Persona", paramPersona.ID))
                .Add(New SqlParameter("@Bloqueado", paramActivo))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _usuarioEntidad As New Entidades.Usuario
                formatearUsuario(dr, _usuarioEntidad)
                _listaUsuario.Add(_usuarioEntidad)
            Next
            Return _listaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Consulta"
    Public Function consultarUsuario(paramNombreUsuario As String) As Entidades.Usuario
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@NombreUsuario", paramNombreUsuario)
            MisParametros.Add("@BL", False)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("consultarUsuarioNombre", MisParametros)
            If _dt.Rows.Count = 1 Then
                Dim _usuario As New Entidades.Usuario
                Me.formatearUsuario(_dt.Rows(0), _usuario)
                'Aca falta cargar el idioma, es mejor arriba en formatear usuario.
                Return _usuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function consultarUsuario(IDUsuario As Integer) As Entidades.Usuario
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from usuario where ID_Usuario=@ID_Usuario and BL=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", IDUsuario))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _usuario As New Entidades.Usuario
                Me.formatearUsuario(_dt.Rows(0), _usuario)
                'Aca falta cargar el idioma, es mejor arriba en formatear usuario.
                Return _usuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function listarUsuarios() As List(Of Entidades.Usuario)
        Try
            Dim _listaUsuarios As New List(Of Entidades.Usuario)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@BL", False)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("listarUsuarios", MisParametros)
            For Each _row As DataRow In _dt.Rows
                Dim _usuario As New Entidades.Usuario
                Me.formatearUsuario(_row, _usuario)
                _listaUsuarios.Add(_usuario)
            Next
            Return _listaUsuarios
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Formatear Usuario"
    Public Sub formatearUsuario(paramDataRow As DataRow, paramUsuario As Entidades.Usuario)
        paramUsuario.ID = paramDataRow.Item("ID_Usuario")
        paramUsuario.NombreUsuario = paramDataRow.Item("NombreUsuario")
        paramUsuario.Password = paramDataRow.Item("Password")
        paramUsuario.FechaAlta = paramDataRow.Item("FechaAlta")
        paramUsuario.Intentos = paramDataRow.Item("Intentos")
        paramUsuario.Bloqueado = paramDataRow.Item("Bloqueado")
        paramUsuario.Editable = paramDataRow.Item("Editable")
        paramUsuario.BL = paramDataRow.Item("BL")
        Dim _idioma As New Entidades.Idioma
        _idioma.ID = CInt(paramDataRow.Item("ID_Idioma"))
        paramUsuario.Idioma = (New IdiomaMPP).Cargar(_idioma)
        paramUsuario.Perfil = (New PermisoMPP).listarFamilias(paramDataRow.Item("ID_Patente"))
        paramUsuario.Persona = (New PersonaMPP).obtenerPersona(paramDataRow.Item("ID_Persona"))
    End Sub
#End Region
#Region "RecuperoContraseña"
    <Obsolete("Revisar ID de usuario antes de migrar a stored", True)>
    Public Sub recuperarContraseña(paramUsuario As Entidades.Usuario, paramCodigo As String)
        Try
            Dim MiID As Integer = DAL.Conexion.ObtenerID("Recupero", "ID_Recupero")
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("insert into recupero values(@ID_Recupero, @ID_Usuario, @FechaSolicitud, @FechaFinVigencia, @Codigo, @Estado)")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Recupero", MiID))
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@FechaSolicitud", Today))
                .Add(New SqlParameter("@FechaFinVigencia", DateAdd(DateInterval.Day, 1, Today)))
                .Add(New SqlParameter("@Codigo", paramCodigo))
                .Add(New SqlParameter("@Estado", True))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    <Obsolete("Revisar ID de usuario antes de migrar a stored", True)>
    Public Function chequearUsuarioyCodigo(paramUsuario As Entidades.Usuario, paramCodigo As String) As Boolean
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select count(*) from recupero where NombreUsuario=@NombreUsuario and Codigo=@Codigo")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@Codigo", paramCodigo))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows(0).Item(0) = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#Region "Opciones"
    Public Sub CambiarIdioma(Paramusuario As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", Paramusuario.ID)
            MisParametros.Add("@ID_Idioma", Paramusuario.Idioma.ID)
            DAL.Conexion.ExecuteNonQuery("CambiarIdiomaUsuario", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub cambiarPassword(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update Usuario set Password=@Password where ID_Usuario=@ID_Usuario")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                .Add(New SqlParameter("@Password", paramUsuario.Password))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Lazy Loading"
    Public Function consultarUsuarioLigero(ByVal IDUsuario As Integer) As Entidades.Usuario
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select ID_Usuario,NombreUsuario,ID_Persona from usuario where ID_Usuario=@ID_Usuario and BL=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Usuario", IDUsuario))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _usuario As New Entidades.Usuario
                Me.formatearUsuarioLigero(_dt.Rows(0), _usuario)
                Return _usuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub formatearUsuarioLigero(paramDataRow As DataRow, paramUsuario As Entidades.Usuario)
        paramUsuario.ID = paramDataRow.Item("ID_Usuario")
        paramUsuario.NombreUsuario = paramDataRow.Item("NombreUsuario")
        paramUsuario.Persona = (New PersonaMPP).obtenerPersona(paramDataRow.Item("ID_Persona"))
    End Sub
#End Region
End Class
