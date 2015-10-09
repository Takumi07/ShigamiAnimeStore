Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Globalization

Public Class IdiomaMPP

    Public Sub bajaIdioma(ByVal paramEntidad As Entidades.Idioma)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("update idioma set BL=@BL where id_Idioma=@ID_Idioma")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Idioma", paramEntidad.ID))
                .Add(New SqlParameter("@BL", True))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub altaIdioma(ByVal paramEntidad As Entidades.Idioma)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("insert into idioma values (@Nombre, @Editable, @BL, @Cultura)")
            With MiComando.Parameters
                .Add(New SqlParameter("@Nombre", paramEntidad.Nombre))
                .Add(New SqlParameter("@Editable", False))
                .Add(New SqlParameter("@BL", False))
                .Add(New SqlParameter("@Cultura", paramEntidad.Cultura.Name))
            End With
            DAL.Conexion.ExecuteNonQuery(MiComando)

            Dim _nuevoidioma As Entidades.Idioma = consultarIdioma(paramEntidad.Nombre)

            For Each _pal As Entidades.Palabra In paramEntidad.Palabras
                MiComando = DAL.Conexion.retornaComando("insert into Traduccion values (@ID_Control, @ID_Idioma, @MIPalabra)")
                With MiComando.Parameters
                    .Add(New SqlParameter("@ID_Control", _pal.ID_Control))
                    .Add(New SqlParameter("@ID_idioma", _nuevoidioma.ID))
                    .Add(New SqlParameter("@MIPalabra", _pal.Traduccion))
                End With
                DAL.Conexion.ExecuteNonQuery(MiComando)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificarIdioma(ByVal paramEntidad As Entidades.Idioma)
        Try
            Dim MiComando As SqlCommand
            For Each _pal As Entidades.Palabra In paramEntidad.Palabras
                MiComando = DAL.Conexion.retornaComando("update Traduccion set Palabra=@MiPalabra where ID_Control=@ID_Control and ID_Idioma=@ID_Idioma")
                With MiComando.Parameters
                    .Add(New SqlParameter("@ID_Control", _pal.ID_Control))
                    .Add(New SqlParameter("@ID_idioma", paramEntidad.ID))
                    .Add(New SqlParameter("@MIPalabra", _pal.Traduccion))
                End With
                DAL.Conexion.ExecuteNonQuery(MiComando)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Cargar(ByVal paramIdiomaEntidad As Entidades.Idioma) As Entidades.Idioma
        Try
            Dim MiIdiomaEntidad As New Entidades.Idioma
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@id_idioma", paramIdiomaEntidad.ID)
            MiDataTable = DAL.Conexion.ExecuteDataTable("Cargar_Idioma", MisParametros)
            MiIdiomaEntidad.Nombre = MiDataTable.Rows(0).Item(3)
            MiIdiomaEntidad.Editable = MiDataTable.Rows(0).Item(4)
            MiIdiomaEntidad.BL = MiDataTable.Rows(0).Item(5)
            MiIdiomaEntidad.Cultura = CultureInfo.GetCultureInfo(MiDataTable.Rows(0).Item(6))
            MiIdiomaEntidad.ID = paramIdiomaEntidad.ID
            For Each MiRow As DataRow In MiDataTable.Rows
                Dim MiPalabra As New Entidades.Palabra
                MiPalabra.ID_Control = MiRow(0)
                MiPalabra.Codigo = MiRow(1)
                MiPalabra.Traduccion = MiRow(2)
                MiIdiomaEntidad.Palabras.Add(MiPalabra)
            Next
            Return MiIdiomaEntidad
        Catch ex As Exception
            Throw ex
        End Try
      
    End Function


    Public Function consultarIdioma(paramNombreIdioma As String) As Entidades.Idioma
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@Nombre", paramNombreIdioma)
            MisParametros.Add("@BL", False)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("consultarIdiomaNombre", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return Me.ConvertirIdioma(_dt.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarIdioma(paramIDIdioma As Integer) As Entidades.Idioma
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Idioma", paramIDIdioma)
            MisParametros.Add("@BL", False)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("consultarIdiomaID", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return Me.ConvertirIdioma(_dt.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function listarIdiomas() As List(Of Entidades.Idioma)
        Try
            Dim _listaIdiomas As New List(Of Entidades.Idioma)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@BL", False)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("listarIdiomas", MisParametros)
            For Each _dr As DataRow In _dt.Rows
                Dim _idi As Entidades.Idioma = ConvertirIdioma(_dr)
                _listaIdiomas.Add(_idi)
            Next

            Return _listaIdiomas
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function ConvertirIdioma(ByVal _dr As DataRow) As Entidades.Idioma
        Dim _idioma As New Entidades.Idioma
        _idioma.ID = CInt(_dr.Item("ID_Idioma"))
        _idioma.Nombre = _dr.Item("Nombre")
        _idioma.Editable = _dr.Item("Editable")
        _idioma.BL = _dr.Item("BL")
        _idioma.Cultura = CultureInfo.GetCultureInfo(_dr.Item("Cultura"))
        Return _idioma
    End Function

    Public Shared Function traducirMensaje(ByVal paramIdioma As Entidades.Idioma, ByVal _IDControl As Integer)
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select Palabra from Traduccion where id_Idioma=@ID_Idioma and ID_Control=@ID_Control")
            With MiComando.Parameters
                .Add(New SqlParameter("@ID_Idioma", paramIdioma.ID))
                .Add(New SqlParameter("@ID_Control", _IDControl))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Return _dt.Rows(0).Item("Palabra").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function chequearNombreIdioma(ByVal paramIdioma As Entidades.Idioma) As Boolean
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select ID_Idioma from Idioma where Nombre=@Nombre")
            With MiComando.Parameters
                .Add(New SqlParameter("@Nombre", paramIdioma.Nombre))
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


End Class