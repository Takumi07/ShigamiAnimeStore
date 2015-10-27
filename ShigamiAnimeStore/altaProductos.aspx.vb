Imports BLL
Imports ENTIDADES
Public Class altaProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Esto es un alta
            Me.CargarGenero()
            Me.CargarTProducto()
            Me.ddl_TipoProducto.SelectedValue = "Figuras"
            Me.HabilitarProductoAlta()
            Me.Button3.Visible = True
        Else

        End If
    End Sub

    Public Sub HabilitarProductoAlta()
        Me.Label1.Visible = False
        Me.TextBox4.Visible = False
        Me.Label2.Visible = False
        Me.Label3.Visible = False
        Me.Label4.Visible = False
        Me.TextBox4.Visible = False
        Me.TextBox5.Visible = False
        Me.datepicker.Visible = False
        Me.CheckBox1.Visible = False
    End Sub


    Public Sub CargarGenero()
        Me.ddl_Genero.DataSource = (New BLL.GeneroBLL).ListarGeneros
        Me.ddl_Genero.DataBind()
    End Sub

    Public Sub CargarTProducto()
        Try
            Me.ddl_TipoProducto.DataSource = (New BLL.TipoProductoBLL).ListarTipoProducto
            Me.ddl_TipoProducto.DataBind()
        Catch ex As BLL.ExepcionRecuperarInformacion

        Catch ex As Exception
        End Try
    End Sub

    Public Function BuscarTipoProducto(paramDescripcion As String) As TipoProductoEntidad
        For Each MiTProducto As TipoProductoEntidad In (New TipoProductoBLL).ListarTipoProducto
            If MiTProducto.Descripcion = paramDescripcion Then
                Return MiTProducto
            End If
        Next
    End Function


    Public Function BuscarGenero(paramDescripcion As String) As GeneroEntidad
        For Each MiGenero As GeneroEntidad In (New GeneroBLL).ListarGeneros
            If MiGenero.Descripcion = paramDescripcion Then
                Return MiGenero
            End If
        Next
    End Function


    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)

            If ddl_TipoProducto.SelectedValue = "Manga" Then
                Dim MiMangaBLL As New MangaBLL
                Dim MiMangaEntidad As New MangaEntidad
                MiMangaEntidad.Fecha_Salida = Date.Today
                MiMangaEntidad.Fecha_Arribo_Sucursal = Date.Today
                MiMangaEntidad.Descripcion = txt_descripcion.Text
                MiMangaEntidad.TipoProducto = Me.BuscarTipoProducto(Me.ddl_TipoProducto.SelectedValue)
                MiMangaEntidad.Genero = Me.BuscarGenero(Me.ddl_Genero.SelectedValue)
                MiMangaEntidad.Precio = txt_precio.Text
                MiMangaEntidad.Stock = txt_Stock.Text
                MiMangaEntidad.N_Tomo = TextBox4.Text

                'ver jquery
                MiMangaEntidad.Fec_Salida_PTomo = datepicker.Text

                MiMangaBLL.Guardar(MiMangaEntidad)
                'Ojo no debería ir aca porque es un alta
                'Response.Redirect("modificarproductos.aspx")

            ElseIf ddl_TipoProducto.SelectedValue = "Anime" Then
                Dim MiAnimeBLL As New AnimeBLL
                Dim MiAnimeEntidad As New AnimeEntidad
                MiAnimeEntidad.Fecha_Arribo_Sucursal = Date.Today
                MiAnimeEntidad.Fecha_Salida = Date.Today
                MiAnimeEntidad.Descripcion = txt_descripcion.Text
                MiAnimeEntidad.TipoProducto = Me.BuscarTipoProducto(Me.ddl_TipoProducto.SelectedValue)
                MiAnimeEntidad.Genero = Me.BuscarGenero(Me.ddl_Genero.SelectedValue)
                MiAnimeEntidad.Precio = txt_precio.Text
                MiAnimeEntidad.Stock = txt_Stock.Text
                MiAnimeEntidad.N_DVD = TextBox4.Text
                MiAnimeEntidad.Cantidad = TextBox5.Text
                MiAnimeEntidad.Temporada_Completa = CheckBox1.Checked
                MiAnimeBLL.Guardar(MiAnimeEntidad)
                'Ojo no debería ir aca porque es un alta
                'Response.Redirect("modificarproductos.aspx")
            Else
                Dim MiProductoBLL As New ProductoBLL
                Dim MiProductoEntidad As New ProductoEntidad
                MiProductoEntidad.Descripcion = txt_descripcion.Text
                MiProductoEntidad.TipoProducto = Me.BuscarTipoProducto(Me.ddl_TipoProducto.SelectedValue)
                MiProductoEntidad.Genero = Me.BuscarGenero(Me.ddl_Genero.SelectedValue)
                MiProductoEntidad.Precio = txt_precio.Text
                MiProductoEntidad.Stock = txt_Stock.Text
                MiProductoEntidad.Fecha_Salida = Date.Today
                MiProductoEntidad.Fecha_Arribo_Sucursal = Date.Today
                MiProductoBLL.Guardar(MiProductoEntidad)
                'Ojo no debería ir aca porque es un alta
                'Response.Redirect("modificarproductos.aspx")
            End If
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
        End Try
    End Sub


    Private Sub ddl_TipoProducto_TextChanged(sender As Object, e As EventArgs) Handles ddl_TipoProducto.TextChanged
        If ddl_TipoProducto.SelectedValue = "Manga" Then
            Me.Label1.Visible = True
            Me.Label1.Text = "Nro Tomo"
            Me.TextBox4.Visible = True
            Me.Label2.Text = "Fecha Salida P. Tomo"
            Me.Label2.Visible = True
            'ver lo del jquery
            Me.datepicker.Visible = True
            Me.Label4.Visible = False
            Me.CheckBox1.Visible = False
            Me.Label3.Visible = False
            Me.TextBox5.Visible = False
        ElseIf ddl_TipoProducto.SelectedValue = "Anime" Then
            Me.Label1.Visible = True
            Me.Label1.Text = "Nro DVD"
            Me.TextBox4.Visible = True
            Me.Label3.Visible = True
            Me.Label3.Text = "Cantidad DVD"
            Me.TextBox5.Visible = True
            Me.Label4.Text = "Temporada Completa"
            Me.Label4.Visible = True
            Me.CheckBox1.Visible = True
            'Oculto Calendar
            Me.Label2.Visible = False
            Me.datepicker.Visible = False
        Else
            Me.Label1.Visible = False
            Me.TextBox4.Visible = False
            Me.Label2.Visible = False
            Me.datepicker.Visible = False
            Me.Label3.Visible = False
            Me.TextBox5.Visible = False
            Me.Label4.Visible = False
            Me.CheckBox1.Visible = False
        End If
    End Sub
End Class