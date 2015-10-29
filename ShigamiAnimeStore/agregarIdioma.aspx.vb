Imports System.Globalization
Public Class agregarIdioma
    Inherits System.Web.UI.Page

    Dim _listaPalabras As New List(Of ENTIDADES.Palabra)
    Dim _listaNuevaPalabras As New List(Of ENTIDADES.Palabra)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If validaciones.validarPagina(Me) = False Then
            Response.Redirect("error.aspx")
        End If
        _listaPalabras = DirectCast(Session("Usuario"), ENTIDADES.Usuario).Idioma.Palabras
        If Not IsPostBack Then
            cargarGridView()
            CargarCulturas()
            Dim Context As HttpContext = HttpContext.Current
            If Context.Items.Contains("IdiomaaEditar") Then
                Dim _IdiomaaEditar As New ENTIDADES.Idioma
                _IdiomaaEditar = DirectCast(Context.Items("IdiomaaEditar"), ENTIDADES.Idioma)
                cargarDatos(_IdiomaaEditar)
                Session("IdiomaaEditar") = _IdiomaaEditar
            End If
            Session("listaNuevaPalabras") = _listaNuevaPalabras
        End If
    End Sub

    Private Sub CargarCulturas()
        ddl_cultura.DataSource = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures)
        ddl_cultura.DataTextField = "NativeName"
        ddl_cultura.DataValueField = "Name"
        ddl_cultura.DataBind()
    End Sub

    Private Sub cargarDatos(ByVal paramIdioma As ENTIDADES.Idioma)
        Me.txt_NombreIdioma.Text = paramIdioma.Nombre
        Me.ddl_cultura.SelectedValue = paramIdioma.Cultura.Name.ToString
        Me.txt_NombreIdioma.ReadOnly = True
        For Each pal As ENTIDADES.Palabra In paramIdioma.Palabras
            For Each row As GridViewRow In Me.gv_Palabras.Rows
                If pal.Codigo = row.Cells(1).Text Then
                    If row.Cells(3).HasControls() = True Then
                        For Each micontrol As Control In row.Cells(3).Controls
                            If TypeOf (micontrol) Is TextBox Then
                                DirectCast(micontrol, TextBox).Text = pal.Traduccion
                            End If
                        Next
                    End If
                End If
            Next
        Next
        Me.addIdioma.Visible = False
        Me.modifIdioma.Visible = True
    End Sub
    Private Sub cargarGridView()
        Me.gv_Palabras.DataSource = _listaPalabras
        Me.gv_Palabras.DataBind()
    End Sub


    Private Sub guardarPalabras()
        Dim _listaPalabrasNueva As List(Of ENTIDADES.Palabra) = DirectCast(Session("listaNuevaPalabras"), List(Of ENTIDADES.Palabra))
        For Each _row As GridViewRow In Me.gv_Palabras.Rows
            Dim _palabra As New ENTIDADES.Palabra
            _palabra.ID_Control = CInt(_row.Cells(0).Text)
            _palabra.Codigo = _row.Cells(1).Text
            If _row.Cells(3).HasControls() = True Then
                For Each micontrol As Control In _row.Cells(3).Controls
                    If TypeOf (micontrol) Is TextBox Then
                        'LO TIENE QUE GRABAR SI NO ESTA CARGADA LA PALABRA, SI ESTA LA DEBERIA REEMPLAZAR
                        If Not _listaPalabrasNueva.Contains(_palabra) Then
                            If Not DirectCast(micontrol, TextBox).Text = "" Then
                                _palabra.Traduccion = Trim(DirectCast(micontrol, TextBox).Text)
                                DirectCast(Session("listaNuevaPalabras"), List(Of ENTIDADES.Palabra)).Add(_palabra)
                            End If
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub obtenerPalabras()
        Dim _listaPalabrasnuevas As List(Of ENTIDADES.Palabra)
        If Session("IdiomaaEditar") Is Nothing Then
            _listaPalabrasnuevas = DirectCast(Session("listanuevaPalabras"), List(Of ENTIDADES.Palabra))
        Else
            _listaPalabrasnuevas = DirectCast(Session("IdiomaaEditar"), ENTIDADES.Idioma).Palabras
        End If
        For Each pal As ENTIDADES.Palabra In _listaPalabrasnuevas
            For Each row As GridViewRow In Me.gv_Palabras.Rows
                If pal.Codigo = row.Cells(1).Text Then
                    If row.Cells(3).HasControls() = True Then
                        For Each micontrol As Control In row.Cells(3).Controls
                            If TypeOf (micontrol) Is TextBox Then
                                DirectCast(micontrol, TextBox).Text = pal.Traduccion
                            End If
                        Next
                    End If
                End If
            Next
        Next
    End Sub

    Protected Sub gv_Palabras_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        guardarPalabras()
        Me.gv_Palabras.DataSource = _listaPalabras
        gv_Palabras.PageIndex = e.NewPageIndex
        gv_Palabras.DataBind()
        obtenerPalabras()
    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ddl As DropDownList = CType(gv_Palabras.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
        gv_Palabras.SetPageIndex(ddl.SelectedIndex)
    End Sub


    Private Sub gv_Palabras_DataBound(sender As Object, e As EventArgs) Handles gv_Palabras.DataBound
        Try
            Dim ddl As DropDownList = CType(gv_Palabras.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            For cnt As Integer = 0 To gv_Palabras.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Palabras.PageIndex Then
                    item.Selected = True
                End If
                ddl.Items.Add(item)
            Next cnt
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            Dim _idioma As New ENTIDADES.Idioma
            Dim _bllidioma As New BLL.IdiomaBLL
            _idioma.Nombre = Me.txt_NombreIdioma.Text
            If _bllidioma.chequearNombreIdioma(_idioma) = True Then
                Throw New BLL.IdiomaDuplicadoException
            Else
                _idioma.Cultura = CultureInfo.GetCultureInfo(ddl_cultura.SelectedValue)
                guardarPalabras()
                _idioma.Palabras = DirectCast(Session("listaNuevaPalabras"), List(Of ENTIDADES.Palabra))
                For Each _palabra As ENTIDADES.Palabra In _listaPalabras
                    If Not _idioma.Palabras.Contains(_palabra) Then
                        _idioma.Palabras.Add(_palabra)
                    End If
                Next
                _bllidioma.altaIdioma(_idioma)
                Response.Redirect("administrarIdiomas.aspx", False)
            End If
        Catch ex As BLL.IdiomaDuplicadoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub

    Private Function validarTraducciones() As Boolean
        For Each _row As GridViewRow In Me.gv_Palabras.Rows
            If _row.Cells(3).HasControls() = True Then
                For Each micontrol As Control In _row.Cells(3).Controls
                    If TypeOf (micontrol) Is TextBox Then
                        If DirectCast(micontrol, TextBox).Text = "" Then
                            Return False
                        End If
                    End If
                Next
            End If

        Next
        Return True
    End Function

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("administrarIdiomas.aspx")
    End Sub

    Protected Sub btn_cancelarModif_Click(sender As Object, e As EventArgs) Handles btn_cancelarModif.Click
        Response.Redirect("administrarIdiomas.aspx")
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Try
            Dim _idioma As New ENTIDADES.Idioma
            Dim _bllidioma As New BLL.IdiomaBLL
            _idioma.ID = DirectCast(Session("IdiomaaEditar"), ENTIDADES.Idioma).ID
            _idioma.Cultura = CultureInfo.GetCultureInfo(ddl_cultura.SelectedValue)
            guardarPalabras()
            _idioma.Palabras = DirectCast(Session("listaNuevaPalabras"), List(Of ENTIDADES.Palabra))
            For Each _palabra As ENTIDADES.Palabra In _listaPalabras
                If Not _idioma.Palabras.Contains(_palabra) Then
                    _idioma.Palabras.Add(_palabra)
                End If
            Next
            _bllidioma.modificarIdioma(_idioma)
            Response.Redirect("administrarIdiomas.aspx", False)
        Catch ex As Exception
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Message
        End Try
    End Sub


End Class