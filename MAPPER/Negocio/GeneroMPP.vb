Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES
Imports DAL

Public Class GeneroMPP

#Region "Consultas de Selección"
    ''' <summary> Método que devuelve todos los generos </summary>
    Public Function ListarGeneros() As List(Of GeneroEntidad)
        Dim ComandoStr As String
        ComandoStr = "Select * from Genero where bl=@bl"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@bl", 0))
        End With
        Dim MiDataTable As New DataTable
        MiDataTable = BD.ExecuteDataTable(MiComando)
        Dim MiListaGeneroEntidad As New List(Of GeneroEntidad)
        For Each MiRow As DataRow In MiDataTable.Rows
            Dim MiGeneroEntidad As New GeneroEntidad
            FormatearGenero(MiRow, MiGeneroEntidad)
            MiListaGeneroEntidad.Add(MiGeneroEntidad)
        Next
        Return MiListaGeneroEntidad
    End Function


    ''' <summary>Método que devuelve los generos asociados a un evento, según el ID de evento</summary>
    Public Function ObtenerGenerosEvento(ByVal paramIDEvento As Integer) As List(Of GeneroEntidad)
        Dim ComandoStr As String
        ComandoStr = "select Genero.ID_Genero, Genero.Descripcion, Genero.BL from Evento_Genero inner join Genero on Evento_Genero.ID_Genero = Genero.ID_Genero where Genero.BL = @BL and Evento_Genero.ID_Evento = @ID_Evento"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Evento", paramIDEvento))
            .Add(New SqlParameter("@bl", 0))
        End With
        Dim MiDataTable As New DataTable
        MiDataTable = BD.ExecuteDataTable(MiComando)
        Dim MiListaGeneroEntidad As New List(Of GeneroEntidad)
        For Each MiRow As DataRow In MiDataTable.Rows
            Dim MiGeneroEntidad As New GeneroEntidad
            FormatearGenero(MiRow, MiGeneroEntidad)
            MiListaGeneroEntidad.Add(MiGeneroEntidad)
        Next
        Return MiListaGeneroEntidad
    End Function



    'Esto es para darle cumplimiento a una funcionalidad de cliente
    Public Shared Function ObtenerGenero(ByVal paramID As Integer) As GeneroEntidad
        Dim ComandoStr As String
        ComandoStr = "Select * from Genero where ID_Genero=@ID_Genero"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Genero", paramID))
        End With
        Dim MiDataTable As New DataTable
        MiDataTable = BD.ExecuteDataTable(MiComando)

        For Each MiRow As DataRow In MiDataTable.Rows
            Dim MiGeneroEntidad As New GeneroEntidad
            FormatearGenero(MiRow, MiGeneroEntidad)
            Return MiGeneroEntidad
        Next
    End Function


    'NO SE USA.

    'Public Shared Function ListarGeneroDeEvento(ByVal paramEventoEntidad As EventoEntidad) As List(Of GeneroEntidad)
    '    Dim MiListaGeneroEntidad As New List(Of GeneroEntidad)
    '    Dim ComandoStr As String
    '    ComandoStr = "select * from Evento_Genero where ID_Evento = @IDEvento"
    '    Dim MiComando = BD.MiComando(ComandoStr)
    '    With MiComando.Parameters
    '        .Add(New SqlParameter("@IDEvento", paramEventoEntidad.ID))
    '    End With
    '    Dim MiDataTable As DataTable
    '    MiDataTable = BD.ExecuteDataTable(MiComando)
    '    For Each MiRow As DataRow In MiDataTable.Rows
    '        Dim ComandoStr2 As String
    '        ComandoStr2 = "Select * from genero where ID_Genero= @ID_Genero"
    '        Dim MiComando2 = BD.MiComando(ComandoStr2)
    '        With MiComando2.Parameters
    '            .Add(New SqlParameter("@ID_Genero", MiRow(1)))
    '        End With
    '        Dim MiDataTable2 As DataTable
    '        MiDataTable2 = BD.ExecuteDataTable(MiComando2)
    '        Dim MiGeneroEntidad As New GeneroEntidad
    '        FormatearGenero(MiDataTable2.Rows(0), MiGeneroEntidad)
    '        MiListaGeneroEntidad.Add(MiGeneroEntidad)
    '    Next
    '    Return MiListaGeneroEntidad
    'End Function





    Public Function VerfificarGeneroExiste(ByVal paramGeneroEntidad As GeneroEntidad) As Boolean
        Dim ComandoStr As String
        ComandoStr = "Select * from genero where Descripcion= @descripcion and bl=@bl"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@descripcion", paramGeneroEntidad.Descripcion))
            .Add(New SqlParameter("@bl", 0))
        End With
        Dim MiDataTable As New DataTable
        MiDataTable = BD.ExecuteDataTable(MiComando)
        If MiDataTable.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


#End Region



#Region "Consultas de Modificación"
    Public Sub GuardarGenero(ByVal paramGeneroEntidad As GeneroEntidad)
        Dim ComandoStr As String
        ComandoStr = "insert into genero values(@ID, @Descripcion, @BL)"
        Dim MiComando = BD.MiComando(ComandoStr)
        paramGeneroEntidad.ID_Genero = BD.ObtenerID("Genero", "ID_Genero")
        With (MiComando.Parameters)
            .Add(New SqlParameter("@ID", paramGeneroEntidad.ID_Genero))
            .Add(New SqlParameter("@Descripcion", paramGeneroEntidad.Descripcion))
            'poner esto en false en la BLL
            .Add(New SqlParameter("@BL", paramGeneroEntidad.BL))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub


    Public Overridable Sub ModificarGenero(ByVal paramGeneroEntidad As GeneroEntidad)
        Dim ComandoStr As String
        ComandoStr = "update Genero set descripcion = @descripcion where ID_Genero=@ID_Genero"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Genero", paramGeneroEntidad.ID_Genero))
            .Add(New SqlParameter("@Descripcion", paramGeneroEntidad.Descripcion))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub


    Public Overridable Sub BajaGenero(ByVal paramGeneroEntidad As GeneroEntidad)
        Dim ComandoStr As String
        ComandoStr = "update Genero set BL=@BL where ID_Genero=@ID_Genero"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_Genero", paramGeneroEntidad.ID_Genero))
            .Add(New SqlParameter("@BL", paramGeneroEntidad.BL))
        End With
        BD.ExecuteNonQuery(MiComando)
    End Sub
#End Region



#Region "Formateo"
    Private Shared Sub FormatearGenero(ByVal paramRow As DataRow, ByVal paramGeneroEntidad As GeneroEntidad)
        paramGeneroEntidad.ID_Genero = paramRow(0)
        paramGeneroEntidad.Descripcion = paramRow(1)
        paramGeneroEntidad.BL = paramRow(2)
    End Sub
#End Region
End Class
