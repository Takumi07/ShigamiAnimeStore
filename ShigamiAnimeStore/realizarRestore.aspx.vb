Public Class realizarRestore
    Inherits System.Web.UI.Page
    Dim _gestorBK As New BLL.BackupRestoreBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If validaciones.validarPagina(Me) = False Then
            Response.Redirect("error.aspx")
        End If
    End Sub



    Protected Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        Try
            'Método utilizado para realizar el restore de la base de datos.
            'Toma el archivo de una rúta física del equipo
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim Resultado As Boolean
            Dim MiBackupRestoreEntidad As New ENTIDADES.BackupRestore
            Dim Path As String
            Path = "C:\BCPSHIGAMIANIMESTORE\"
            Path = Path & Me.fu_Restore.FileName
            MiBackupRestoreEntidad.Directorio = Path
            MiBackupRestoreEntidad.Usuario = BLL.SesionBLL.Current.Usuario
            Resultado = _gestorBK.RealizarRestore(MiBackupRestoreEntidad)
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("index.aspx")
    End Sub

End Class