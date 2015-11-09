Imports System.IO
Public Class realizarBackup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Fija la ruta en donde ser guardará el backup realizado.
        If validaciones.validarPagina(Me) = False Then
            Response.Redirect("error.aspx")
        End If
        Me.txt_Directorio.ReadOnly = True
        Me.txt_Directorio.Text = "C:\BCPSHIGAMIANIMESTORE\"
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            'Método utilizado para realizar el backup de la base de datos.
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim MiBackupRestoreBLL As New BLL.BackupRestoreBLL
            Dim MiBackupRestoreEntidad As New ENTIDADES.BackupRestore
            MiBackupRestoreEntidad.Directorio = txt_Directorio.Text
            Me.CrearDirectorio(txt_Directorio.Text)
            MiBackupRestoreEntidad.Nombre = txt_nombre.Text
            MiBackupRestoreEntidad.Usuario = BLL.SesionBLL.Current.Usuario
            Dim Resu As Boolean = MiBackupRestoreBLL.RealizarBackup(MiBackupRestoreEntidad)
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub


    Public Sub CrearDirectorio(ByVal paramPath As String)
        'Crea un directorio en caso de que este no exista.
        Dim MiDirectorio As DirectoryInfo = New DirectoryInfo(paramPath)
        If Not MiDirectorio.Exists Then
            MiDirectorio.Create()
        End If
    End Sub


    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("index.aspx")
    End Sub
End Class