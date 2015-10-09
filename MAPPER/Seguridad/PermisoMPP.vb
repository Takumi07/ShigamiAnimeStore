Imports System.Data.SqlClient

Public Class PermisoMPP
    Public Function listarFamilias(paramID As Integer) As Entidades.PermisoCompuesto
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IdPatente", paramID)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("listarFamiliasID", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return ConvertirDataRowEnPermiso(_dt.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerIDPermiso(paramNombrePermiso As String) As Integer
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@Nombre", paramNombrePermiso)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("obtenerIDPermiso", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return CInt(_dt.Rows(0).Item(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chequearNombrePermiso(paramNombrePermiso As String) As Boolean
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@Nombre", paramNombrePermiso)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("obtenerIDPermiso", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ListarHijos(ByVal _id As Integer) As List(Of Entidades.PermisoBase)
        Try
            Dim lista As List(Of Entidades.PermisoBase) = New List(Of Entidades.PermisoBase)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IDFamilia", _id)
            Dim dt As DataTable = DAL.Conexion.ExecuteDataTable("ListarHijos", MisParametros)
            For Each mirow As DataRow In dt.Rows
                Dim MiPermiso As Entidades.PermisoBase = Me.ConvertirDataRowEnPermiso(mirow)
                lista.Add(MiPermiso)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ConvertirDataRowEnPermiso(_dr As DataRow) As Entidades.PermisoBase
        Try
            Dim _permiso As Entidades.PermisoBase
            If Not _dr.Item("esAccion") Is DBNull.Value AndAlso Convert.ToBoolean(_dr.Item("esAccion")) Then
                _permiso = New Entidades.PermisoSimple
            Else
                _permiso = New Entidades.PermisoCompuesto
            End If
            _permiso.ID = CInt(_dr.Item("Id_Patente"))
            _permiso.Nombre = Convert.ToString(_dr.Item("Nombre"))
            _permiso.URL = _dr.Item("URL").ToString
            If _permiso.tieneHijos Then
                Dim ListaHijos As List(Of Entidades.PermisoBase) = Me.ListarHijos(_permiso.ID)
                For Each hijo As Entidades.PermisoBase In ListaHijos
                    _permiso.agregarHijo(hijo)
                Next
            End If
            Return _permiso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarFamilias(paramFiltro As Boolean) As List(Of Entidades.PermisoBase)
        Try
            Dim _listaFamilias As New List(Of Entidades.PermisoBase)
            Dim MisParametros As New Hashtable
            If paramFiltro = True Then
                MisParametros.Add("@accion", 0)
            Else
                MisParametros.Add("@accion", DBNull.Value)
            End If
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("listarFamiliasFiltro", MisParametros)
            For Each _dr As DataRow In _dt.Rows
                Dim _per As Entidades.PermisoBase = ConvertirDataRowEnPermiso(_dr)
                _listaFamilias.Add(_per)
            Next
            Return _listaFamilias
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub AltaPermiso(paramPermiso As Entidades.PermisoBase)
        Try
            Dim MiID As Integer = DAL.Conexion.ObtenerID("Patente", "ID_Patente")
            If paramPermiso.tieneHijos = True Then
                Dim MisParametros As New Hashtable
                MisParametros.Add("@ID_Patente", MiID)
                MisParametros.Add("@Nombre", paramPermiso.Nombre)
                MisParametros.Add("@URL", DBNull.Value)
                MisParametros.Add("@esAccion", 0)
                DAL.Conexion.ExecuteNonQuery("AltaPermisoPatente", MisParametros)
                For Each MiPermiso As Entidades.PermisoBase In paramPermiso.ObtenerHijos
                    Dim MisParametros2 As New Hashtable
                    MisParametros2.Add("@ID_Familia", MiID)
                    MisParametros2.Add("@ID_Patente", MiPermiso.ID)
                    DAL.Conexion.ExecuteNonQuery("AltaPermisoFamiliaPatente", MisParametros2)
                Next
            Else
                'Es un Permiso
                Dim MisParametros As New Hashtable
                MisParametros.Add("@ID_Patente", MiID)
                MisParametros.Add("@Nombre", paramPermiso.Nombre)
                MisParametros.Add("@URL", paramPermiso.URL)
                MisParametros.Add("@esAccion", 1)
                DAL.Conexion.ExecuteNonQuery("AltaPermisoPatente", MisParametros)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub BajaPermiso(paramID As Integer)
        Try
            'Quizá esto se podía hacer mas performante, pero al menos está en SP
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IDFamilia", paramID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoFamiliaPatenteFamilia", MisParametros)

            Dim MisParametros2 As New Hashtable
            MisParametros2.Add("@IDFamilia", paramID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoFamiliaPatentePatente", MisParametros2)


            Dim MisParametros3 As New Hashtable
            MisParametros3.Add("@IDPatente", paramID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoPatente", MisParametros3)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ModificarPermiso(paramPermiso As Entidades.PermisoBase)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IDFamilia", paramPermiso.ID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoFamiliaPatenteFamilia", MisParametros)
            For Each MiPermiso As Entidades.PermisoBase In paramPermiso.ObtenerHijos
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@ID_Familia", paramPermiso.ID)
                MisParametros2.Add("@ID_Patente", MiPermiso.ID)
                If Not paramPermiso.ID = MiPermiso.ID Then
                    DAL.Conexion.ExecuteNonQuery("AltaPermisoFamiliaPatente", MisParametros2)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
