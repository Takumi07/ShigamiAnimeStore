Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text

Public Class BackupRestoreMPP
    Public Function RealizarBackup(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore) As Boolean
        Dim MiDirectorio As String
        If paramBackupRestoreEntidad.Directorio.Length <> 3 Then
            MiDirectorio = paramBackupRestoreEntidad.Directorio & "\" & paramBackupRestoreEntidad.Nombre & ".bak"
        Else
            MiDirectorio = paramBackupRestoreEntidad.Directorio & paramBackupRestoreEntidad.Nombre & ".bak"
        End If

        Using MiConectionMaster = DAL.Conexion.retornaConexionMaestra()
            Try
                Dim MiStringBuilder As New StringBuilder
                MiStringBuilder.Append("BACKUP DATABASE [Servicios] TO DISK = '" & MiDirectorio & "' ")
                MiStringBuilder.Append("WITH DESCRIPTION = 'Backup Servicios', NOFORMAT, NOINIT, ")
                MiStringBuilder.Append("NAME = '" & paramBackupRestoreEntidad.Nombre & "', SKIP, NOREWIND, NOUNLOAD, STATS = 10")
                Dim MiComando As New SqlCommand(MiStringBuilder.ToString, MiConectionMaster)
                MiConectionMaster.Open()
                MiComando.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            Finally
                MiConectionMaster.Close()
            End Try
        End Using
    End Function

    Public Function RealizarRestore(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore) As Boolean
        Dim MiConectionMaster As New SqlConnection
        Try
            MiConectionMaster = DAL.Conexion.retornaConexionMaestra
            Dim Strcomando As String = " ALTER DATABASE  [Servicios] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [Servicios] FROM DISK = '" & paramBackupRestoreEntidad.Directorio & "'  With Replace ALTER DATABASE [Servicios] SET MULTI_USER "
            Dim MiComando As New SqlCommand(Strcomando, MiConectionMaster)
            MiConectionMaster.Open()
            MiComando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            MiConectionMaster.Close()
        End Try
    End Function

End Class
