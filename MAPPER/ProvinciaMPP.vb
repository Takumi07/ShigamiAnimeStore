Imports System.Data.SqlClient

Public Class ProvinciaMPP

    Public Function obtenerProvincia() As List(Of Entidades.Provincia)
        Try
            Dim _listaProvincia As New List(Of Entidades.Provincia)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Provincia")
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _Provincia As New Entidades.Provincia
                formatearProvincia(dr, _Provincia)
                _listaProvincia.Add(_Provincia)
            Next
            Return _listaProvincia
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProvincia(ByVal paramProvincia As Entidades.Provincia) As Entidades.Provincia
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Provincia where Descripcion=@Descripcion")
            With MiComando.Parameters
                .Add(New SqlParameter("@Descripcion", paramProvincia.Descripcion))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _provincia As New Entidades.Provincia
                formatearProvincia(_dt.Rows(0), _provincia)
                Return _provincia
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Sub formatearProvincia(paramDataRow As DataRow, paramProvincia As Entidades.Provincia)
        paramProvincia.ID = paramDataRow.Item("ID_Provincia")
        paramProvincia.Descripcion = paramDataRow.Item("Descripcion")
    End Sub

End Class
