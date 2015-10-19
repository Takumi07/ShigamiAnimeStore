Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES
Imports DAL
Public Class TipoProductoMPP
#Region "Consultas de Selección"
    ''' <summary> Método que devuelve todos los Tipos de productos </summary>
    Public Function ListarTipoProducto() As List(Of TipoProductoEntidad)
        Dim ComandoStr As String
        ComandoStr = "Select * from Tipo_Producto where bl=@bl"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@bl", 0))
        End With
        Dim MiDataTable As New DataTable
        MiDataTable = BD.ExecuteDataTable(MiComando)
        Dim MiListaTipoProductoEntidad As New List(Of TipoProductoEntidad)
        For Each MiRow As DataRow In MiDataTable.Rows
            Dim MiTipoProductoEntidad As New TipoProductoEntidad
            FormatearTipoProducto(MiRow, MiTipoProductoEntidad)
            MiListaTipoProductoEntidad.Add(MiTipoProductoEntidad)
        Next
        Return MiListaTipoProductoEntidad
    End Function



    'Esto es para darle cumplimiento a una funcionalidad de cliente
    Public Shared Function ObtenerTipoProducto(ByVal paramID As Integer) As TipoProductoEntidad
        Dim ComandoStr As String
        ComandoStr = "Select * from Tipo_Producto where ID_TipoProducto =@ID_TipoProducto"
        Dim MiComando = BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_TipoProducto", paramID))
        End With
        Dim MiDataTable As New DataTable
        MiDataTable = BD.ExecuteDataTable(MiComando)

        For Each MiRow As DataRow In MiDataTable.Rows
            Dim MiTipoProductoEntidad As New TipoProductoEntidad
            FormatearTipoProducto(MiRow, MiTipoProductoEntidad)
            Return MiTipoProductoEntidad
        Next
    End Function




#End Region

#Region "Formateo"
    Private Shared Sub FormatearTipoProducto(ByVal paramRow As DataRow, ByVal paramTipoProductoEntidad As TipoProductoEntidad)
        paramTipoProductoEntidad.ID_TipoProducto = paramRow(0)
        paramTipoProductoEntidad.Descripcion = paramRow(1)
    End Sub
#End Region


End Class
