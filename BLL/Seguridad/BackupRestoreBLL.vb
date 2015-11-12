Public Class BackupRestoreBLL
    Dim _mpp As New Mapper.BackupRestoreMPP

    Public Function RealizarBackup(ByVal paramBackupRestoreEntidad As ENTIDADES.BackupRestore) As Boolean
        Try
            Dim MiResultado As Boolean
            MiResultado = _mpp.RealizarBackup(paramBackupRestoreEntidad)
            Return MiResultado
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, ENTIDADES.Bitacora.tipoPrioridadBitacora.Alta, ENTIDADES.Bitacora.tipoOperacionBitacora.Backup, "Backup Correcto")
        Catch ex As Exception
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, ENTIDADES.Bitacora.tipoPrioridadBitacora.Alta, ENTIDADES.Bitacora.tipoOperacionBitacora.Backup, "Backup Inorrecto")
            Return False
        End Try
    End Function

    Public Function RealizarRestore(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore) As Boolean
        Try
            Dim MiResultado As Boolean
            MiResultado = _mpp.RealizarRestore(paramBackupRestoreEntidad)
            Return MiResultado
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Restore, "Restore Correcto")
        Catch ex As Exception
            BLL.BitacoraBLL.Alta(SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Restore, "Restore Inorrecto")
            Return False
        End Try
    End Function
End Class
