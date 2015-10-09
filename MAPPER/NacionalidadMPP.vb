Imports System.Data.SqlClient
Public Class NacionalidadMPP

    Public Function obtenerNacionalidad() As List(Of Entidades.Nacionalidad)
        Try
            Dim _ListaNacionalidad As New List(Of Entidades.Nacionalidad)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Nacionalidad")
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _nacionalidad As New Entidades.Nacionalidad
                formatearNacionalidad(dr, _nacionalidad)
                _ListaNacionalidad.Add(_nacionalidad)
            Next
            Return _ListaNacionalidad
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNacionalidad(ByVal paramNacionalidad As Entidades.Nacionalidad) As Entidades.Nacionalidad
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Nacionalidad where Descripcion=@Descripcion")
            With MiComando.Parameters
                .Add(New SqlParameter("@Descripcion", paramNacionalidad.Descripcion))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _nacionalidad As New Entidades.Nacionalidad
                formatearNacionalidad(_dt.Rows(0), _nacionalidad)
                Return _nacionalidad
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub formatearNacionalidad(paramDataRow As DataRow, paramNacionalidad As Entidades.Nacionalidad)
        paramNacionalidad.ID = paramDataRow.Item("ID_Nacionalidad")
        paramNacionalidad.Descripcion = paramDataRow.Item("Descripcion")
    End Sub
End Class
