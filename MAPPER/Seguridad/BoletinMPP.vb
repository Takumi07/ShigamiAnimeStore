Imports System.Data.SqlClient
Public Class BoletinMPP
    Public Sub altaBoletin(paramBoletin As Entidades.Boletin)
        Try
            Dim MiID As Integer = DAL.Conexion.ObtenerID("Boletin", "ID_Boletin")

            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Boletin", MiID)
            MisParametros.Add("@Nombre", paramBoletin.Nombre)
            MisParametros.Add("@Descripcion", paramBoletin.Descripcion)
            MisParametros.Add("@Cuerpo", paramBoletin.Cuerpo)
            MisParametros.Add("@ID_TipoBoletin", paramBoletin.TipoBoletin)
            MisParametros.Add("@Fecha_Alta", Now)
            DAL.Conexion.ExecuteNonQuery("altaBoletin", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    <Obsolete("Ojo, no pude pasar esta consulta, no estaba la tabla.", True)>
    Public Function obtenerSubscriptores(ByVal _idTipoBoletin As Integer) As List(Of Entidades.Usuario)
        Dim _listaSubscriptores As New List(Of Entidades.Usuario)
        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("Select * from Subscriptores where ID_TipoBoletin=@ID_TipoBoletin")
        With MiComando.Parameters
            .Add(New SqlParameter("@ID_TipoBoletin", _idTipoBoletin))
        End With
        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
        For Each dr As DataRow In _dt.Rows
            Dim _usudal As New UsuarioMPP
            Dim _usuarioentidad As Entidades.Usuario = _usudal.consultarUsuario(CInt(dr.Item("ID_Usuario")))
            _listaSubscriptores.Add(_usuarioentidad)
        Next
        Return _listaSubscriptores
    End Function
End Class
