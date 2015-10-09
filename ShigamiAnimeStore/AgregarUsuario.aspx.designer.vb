'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class AgregarUsuario

    '''<summary>
    '''Control error.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents [error] As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control lbl_TituloError.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_TituloError As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cab_agregarUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cab_agregarUsuario As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lbl_NombredeUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_NombredeUsuario As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txt_nombreUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_nombreUsuario As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control requerido_txt_nombreUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents requerido_txt_nombreUsuario As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control passAgregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents passAgregar As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control lbl_password.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_password As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txt_password.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_password As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control requerido_txt_password.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents requerido_txt_password As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control lbl_repetirPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_repetirPassword As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txt_repetirPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_repetirPassword As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control Required_txt_repetirPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Required_txt_repetirPassword As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control passModificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents passModificar As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control lbl_NuevoPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_NuevoPassword As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control chk_resetPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chk_resetPassword As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lbl_documento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_documento As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txt_Documento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Documento As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control Requiredtxt_Documento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Requiredtxt_Documento As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control lbl_perfil.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_perfil As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ddl_Perfiles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Perfiles As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control lbl_idioma.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_idioma As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control ddl_Idiomas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Idiomas As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control btnAgregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregar As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control btn_agregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_agregar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btn_cancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_cancelar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btnModificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnModificar As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control btn_Modificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_Modificar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btn_cancelarModificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_cancelarModificar As Global.System.Web.UI.WebControls.Button
End Class
