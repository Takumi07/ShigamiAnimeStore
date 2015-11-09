Imports System.Data.Sql
Imports System.Data.SqlClient
Imports ENTIDADES

Public Class DVMPP
    Public Shared Function VerificarIntegridad() As Boolean
        Dim DigitoVV As DataTable = DAL.BD.ExecuteDataTable(DAL.BD.MiComando("select * from DVV"))
        If DigitoVV.Rows.Count >= 1 Then
            For Each MiRow As DataRow In DigitoVV.Rows
                Dim Verificador As Boolean = True
                Dim TablaAAnalizar As DataTable = DAL.BD.ExecuteDataTable(DAL.BD.MiComando("select * from " & MiRow.Item(0))) 'Obtengo todas las filas de una tabla
                Dim SumaDVH As Integer = 0
                For Each MiRowAnalizar As DataRow In TablaAAnalizar.Rows
                    Dim MiStringAnalizar As String = ""
                    MiStringAnalizar = IterarRow(MiRowAnalizar, TablaAAnalizar.Columns.Count - 2)
                    Dim DVHTemp As Integer
                    DVHTemp = CalcularDVH(MiStringAnalizar)
                    If DVHTemp <> MiRowAnalizar.Item(TablaAAnalizar.Columns.Count - 1) Then
                        Return False
                    End If
                    SumaDVH += DVHTemp
                Next
                If SumaDVH <> MiRow.Item(1) Then
                    Return False
                End If
            Next
            Return True
        Else
            Return False
        End If
    End Function



    Public Shared Function IterarRow(ByVal paramDataRow As DataRow, ByVal paramIterarHasta As Integer) As String
        Dim inCadena As String = ""
        For i As Integer = 0 To paramIterarHasta
            If TypeOf (paramDataRow.Item(i)) Is Date Then
                'Dim MiDate As Date
                'MiDate = Convert.ToDateTime(paramDataRow.Item(i))
                'Lo cambio a ver que pasa.
                inCadena += paramDataRow.Item(i).ToString
            Else
                inCadena += paramDataRow.Item(i).ToString
            End If

        Next
        Return inCadena
    End Function


    '''<summary> Calcula el DVH en base a una concatenaciòn de todos los campos de la base de datos.
    '''Tengo un SP en la bd que hace lo mismo pero deberìa hacerlo en la aplicaciòn así que aca esta...</summary>
    Public Shared Function CalcularDVH(ByVal paramAEvaluar As String) As Integer
        Dim Cantidad As Integer
        Cantidad = Len(paramAEvaluar)
        Dim Flag As Integer = 0
        Dim Resultado As Integer
        For i = 1 To Cantidad
            Flag = Flag + 1
            Dim StrTem As String
            StrTem = Mid(paramAEvaluar, Flag, 1)
            Dim ResuTem As Integer
            ResuTem = Asc(StrTem) * Flag
            Resultado = Resultado + ResuTem
        Next
        Return Resultado
    End Function


    ''' <summary>Actualiza de manera automàtica los DVV de la tabla que se le indica por parámetro.</summary>
    ''' <param name="paramTabla">Nombre de la tabla que deseamos actualizar</param>
    Public Shared Sub ActualizarDVV(ByVal paramTabla As String)
        Dim MiDataTable As New DataTable
        'LO HAGO ASI PORQUE NO LE PUEDO PASAR EL NOMBRE DE UNA TABLA POR SQLPARAMETER
        'COMO SE HACE BIEN????????
        Dim ComandoStr As String = "Select DVH from " & paramTabla
        Dim MiComando = DAL.BD.MiComando(ComandoStr)
        'With MiComando.Parameters
        '    .Add(New SqlParameter("@Tabla", paramTabla))
        'End With
        MiDataTable = DAL.BD.ExecuteDataTable(MiComando)
        Dim Resultado As Integer
        For Each MiDataRow As DataRow In MiDataTable.Rows
            Resultado += MiDataRow.Item(0)
        Next
        ComandoStr = "update DVV set DVV = @DVV where NombreTabla = @paramtabla"
        MiComando = DAL.BD.MiComando(ComandoStr)
        Dim miparametro As New SqlParameter
        With MiComando.Parameters
            .Add(New SqlParameter("@paramtabla", paramTabla))
            .Add(New SqlParameter("@DVV", Resultado))
        End With
        DAL.BD.ExecuteNonQuery(MiComando)
    End Sub


    ''' Calcula y retorna el valor del DVV para la tabla especificada.
    ''' <param name="paramTabla">Nombre de la tabla que deseamos calcular el DVV</param>
    Public Function CalcularDVV(ByVal paramTabla As String) As Integer
        Dim MiDataTable As New DataTable
        Dim ComandoStr As String = "Select DVH from @Tabla"
        Dim MiComando = DAL.BD.MiComando(ComandoStr)
        With MiComando.Parameters
            .Add(New SqlParameter("@Tabla", paramTabla))
        End With
        MiDataTable = DAL.BD.ExecuteDataTable(MiComando)
        Dim Resultado As Integer
        For Each MiDataRow As DataRow In MiDataTable.Rows
            Resultado += MiDataRow.Item(0)
        Next
        Return Resultado
    End Function

End Class

