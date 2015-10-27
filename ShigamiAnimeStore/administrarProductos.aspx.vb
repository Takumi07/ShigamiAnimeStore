Imports BLL
Imports ENTIDADES
Public Class administrarProductos
    Inherits System.Web.UI.Page


    Dim MiProductoEntidadGlobal As ENTIDADES.ProductoEntidad
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsNothing(Session("Producto")) Then
                MiProductoEntidadGlobal = Session("Producto")
                Me.CargarGenero()
                Me.CargarTProducto()

                If TypeOf (MiProductoEntidadGlobal) Is MangaEntidad Then
                    Me.HabilitarManga()
                ElseIf TypeOf (MiProductoEntidadGlobal) Is AnimeEntidad Then
                    Me.HabilitarAnime()
                Else
                    Me.HabilitarProducto()
                End If
                Me.Button1.Visible = True
                Me.Button2.Visible = True
                Me.ddl_TipoProducto.Enabled = False
            Else
                'Esto es un alta
                Response.Redirect("modificarproductos.aspx")
            End If

        Else
            MiProductoEntidadGlobal = Session("Producto")
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

    Public Sub HabilitarProducto()
        If Not IsNothing(MiProductoEntidadGlobal) Then
            txt_descripcion.Text = MiProductoEntidadGlobal.Descripcion
            ddl_TipoProducto.SelectedValue = MiProductoEntidadGlobal.TipoProducto.Descripcion
            ddl_Genero.SelectedValue = MiProductoEntidadGlobal.Genero.Descripcion
            txt_precio.Text = MiProductoEntidadGlobal.Precio
            txt_Stock.Text = MiProductoEntidadGlobal.Stock

            'oculto
            Me.Label1.Visible = False
            Me.TextBox4.Visible = False
            Me.Label2.Visible = False
            Me.Label3.Visible = False
            Me.Label4.Visible = False
            Me.TextBox4.Visible = False
            Me.TextBox5.Visible = False
            Me.datepicker.Visible = False
            Me.CheckBox1.Visible = False
        End If
    End Sub


    Public Sub HabilitarManga()
        If Not IsNothing(MiProductoEntidadGlobal) Then
            txt_descripcion.Text = MiProductoEntidadGlobal.Descripcion
            ddl_TipoProducto.SelectedValue = MiProductoEntidadGlobal.TipoProducto.Descripcion
            ddl_Genero.SelectedValue = MiProductoEntidadGlobal.Genero.Descripcion
            txt_precio.Text = MiProductoEntidadGlobal.Precio
            txt_Stock.Text = MiProductoEntidadGlobal.Stock
            'Manga
            Me.Label1.Text = "Nro Tomo"
            Me.TextBox4.Visible = True
            Me.TextBox4.Text = DirectCast(MiProductoEntidadGlobal, MangaEntidad).N_Tomo
            Me.Label2.Text = "Fecha Salida P. Tomo"
            Me.Label2.Visible = True

            'ACA HAY QUE SACAR EL JQUERY
            Me.datepicker.Visible = True
            Me.datepicker.Text = DirectCast(MiProductoEntidadGlobal, MangaEntidad).Fec_Salida_PTomo
            'Me.Calendar1.Visible = True
            'Me.Calendar1.SelectedDate = DirectCast(MiProductoEntidadGlobal, MangaEntidad).Fec_Salida_PTomo
            'Me.Calendar1.TodaysDate = DirectCast(MiProductoEntidadGlobal, MangaEntidad).Fec_Salida_PTomo

            'Oculto Anime
            Me.Label3.Visible = False
            Me.Label4.Visible = False
            Me.TextBox5.Visible = False
            Me.CheckBox1.Visible = False

        End If
    End Sub


    Public Sub HabilitarAnime()
        If Not IsNothing(MiProductoEntidadGlobal) Then
            txt_descripcion.Text = MiProductoEntidadGlobal.Descripcion
            ddl_TipoProducto.SelectedValue = MiProductoEntidadGlobal.TipoProducto.Descripcion
            ddl_Genero.SelectedValue = MiProductoEntidadGlobal.Genero.Descripcion
            txt_precio.Text = MiProductoEntidadGlobal.Precio
            txt_Stock.Text = MiProductoEntidadGlobal.Stock
            'Anime
            Me.Label1.Text = "Nro DVD"
            Me.TextBox4.Text = DirectCast(MiProductoEntidadGlobal, AnimeEntidad).N_DVD
            Me.TextBox4.Visible = True
            Me.Label3.Visible = True
            Me.Label3.Text = "Cantidad"
            Me.TextBox5.Visible = True
            Me.Label4.Text = "Temporada Completa"
            Me.Label4.Visible = True
            Me.TextBox5.Text = DirectCast(MiProductoEntidadGlobal, AnimeEntidad).Cantidad
            Me.CheckBox1.Checked = DirectCast(MiProductoEntidadGlobal, AnimeEntidad).Temporada_Completa

            'Manga  
            Me.Label2.Visible = False

            'ACA HAY QUE SACAR EL JQUERY
            Me.datepicker.Visible = False

        End If
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ddl_TipoProducto.SelectedValue = "Manga" Then
            Me.ModificarManga()
            Response.Redirect("modificarproductos.aspx")
        ElseIf ddl_TipoProducto.SelectedValue = "Anime" Then
            Me.ModificarAnime()
            Response.Redirect("modificarproductos.aspx")
        Else
            Me.ModificarProducto()
            Response.Redirect("modificarproductos.aspx")
        End If

    End Sub


    Private Sub ModificarProducto()
        Try
            Dim MiProductoBLL As New ProductoBLL
            MiProductoEntidadGlobal.Descripcion = txt_descripcion.Text
            MiProductoEntidadGlobal.TipoProducto = Me.BuscarTipoProducto(ddl_TipoProducto.SelectedValue)
            MiProductoEntidadGlobal.Genero = Me.BuscarGenero(ddl_Genero.SelectedValue)
            MiProductoEntidadGlobal.Precio = txt_precio.Text
            MiProductoEntidadGlobal.Stock = txt_Stock.Text
            MiProductoBLL.Modificar(MiProductoEntidadGlobal)
        Catch MiExepcionModificarProducto As ExepcionModificarProducto

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub ModificarAnime()
        Try
            Try
                Dim MiAnimeBLL As New AnimeBLL
                Dim MiAnimeEntidad As New AnimeEntidad
                MiAnimeEntidad.ID = MiProductoEntidadGlobal.ID
                MiAnimeEntidad.Fecha_Alta_Sistema = MiProductoEntidadGlobal.Fecha_Alta_Sistema
                MiAnimeEntidad.Fecha_Arribo_Sucursal = MiProductoEntidadGlobal.Fecha_Arribo_Sucursal
                MiAnimeEntidad.Fecha_Salida = MiProductoEntidadGlobal.Fecha_Salida
                MiAnimeEntidad.Novedad = MiProductoEntidadGlobal.Novedad
                MiAnimeEntidad.FlujoVenta = MiProductoEntidadGlobal.FlujoVenta
                MiAnimeEntidad.BL = MiProductoEntidadGlobal.BL
                MiAnimeEntidad.Descripcion = txt_descripcion.Text
                MiAnimeEntidad.TipoProducto = Me.BuscarTipoProducto(Me.ddl_TipoProducto.SelectedValue)
                MiAnimeEntidad.Genero = Me.BuscarGenero(Me.ddl_Genero.SelectedValue)
                MiAnimeEntidad.Precio = txt_precio.Text
                MiAnimeEntidad.Stock = txt_Stock.Text
                MiAnimeEntidad.N_DVD = TextBox4.Text
                MiAnimeEntidad.Cantidad = TextBox5.Text
                MiAnimeEntidad.Temporada_Completa = CheckBox1.Checked
                MiAnimeBLL.Modificar(MiAnimeEntidad)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub



    Private Sub ModificarManga()
        Try
            Dim MiMangaBLL As New MangaBLL
            Dim MiMangaEntidad As New MangaEntidad

            MiMangaEntidad.ID = MiProductoEntidadGlobal.ID
            MiMangaEntidad.Fecha_Alta_Sistema = MiProductoEntidadGlobal.Fecha_Alta_Sistema
            MiMangaEntidad.Fecha_Arribo_Sucursal = MiProductoEntidadGlobal.Fecha_Arribo_Sucursal
            MiMangaEntidad.Fecha_Salida = MiProductoEntidadGlobal.Fecha_Salida
            MiMangaEntidad.Novedad = MiProductoEntidadGlobal.Novedad
            MiMangaEntidad.FlujoVenta = MiProductoEntidadGlobal.FlujoVenta
            MiMangaEntidad.BL = MiProductoEntidadGlobal.BL

            MiMangaEntidad.Descripcion = txt_descripcion.Text
            MiMangaEntidad.TipoProducto = Me.BuscarTipoProducto(Me.ddl_TipoProducto.SelectedValue)
            MiMangaEntidad.Genero = Me.BuscarGenero(Me.ddl_Genero.SelectedValue)
            MiMangaEntidad.Precio = txt_precio.Text
            MiMangaEntidad.Stock = txt_Stock.Text
            MiMangaEntidad.N_Tomo = TextBox4.Text

            'VER EL JQRY!
            MiMangaEntidad.Fec_Salida_PTomo = Convert.ToDateTime(Me.datepicker.Text)
            MiMangaBLL.Modificar(MiMangaEntidad)
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


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If ddl_TipoProducto.SelectedValue = "Manga" Then
                Dim MiMangaBLL As New MangaBLL
                MiMangaBLL.Baja(MiProductoEntidadGlobal)
            ElseIf ddl_TipoProducto.SelectedValue = "Anime" Then
                Dim MiAnimeBLL As New AnimeBLL
                MiAnimeBLL.Baja(MiProductoEntidadGlobal)
            Else
                Dim MiProductoBLL As New ProductoBLL
                MiProductoBLL.Baja(MiProductoEntidadGlobal)
            End If
            Response.Redirect("modificarproductos.aspx")
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