﻿Public Class AdministrarPerfiles
    Inherits System.Web.UI.Page
    Dim _MigestorPermiso As New BLL.PermisoBLL
    Private _Milistapermisos As List(Of ENTIDADES.PermisoBase)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If validaciones.validarPagina(Me) = False Then
        'Response.Redirect("error.aspx")
        'End If
        Me.Cargar()
        If Not IsPostBack Then
            Me.CargarGridView()
        End If
    End Sub
    Private Sub Cargar()
        _Milistapermisos = _MigestorPermiso.ListarFamilias(True)
    End Sub

    Private Sub CargarGridView()
        Me.gv_Perfiles.DataSource = _Milistapermisos
        Me.gv_Perfiles.DataBind()
        Me.gv_Perfiles.Columns(0).Visible = False
    End Sub

    Protected Sub Editar_Command(sender As Object, e As CommandEventArgs)
        Dim Context As HttpContext = HttpContext.Current
        If Context.Items.Contains("FamiliaaEditar") = True Then
            Context.Items.Remove("FamiliaaEditar")
        End If
        Context.Items.Add("FamiliaaEditar", CInt(e.CommandArgument))
        Server.Transfer("agregarPerfil.aspx", True)
    End Sub


    Protected Sub Eliminar_Command(sender As Object, e As CommandEventArgs)
        Try
            _MigestorPermiso.Baja(e.CommandArgument)
            Session.Remove("Id_Permiso")
            Response.Redirect("administrarPerfiles.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gv_Perfiles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Cargar()
        Me.gv_Perfiles.DataSource = _Milistapermisos
        gv_Perfiles.PageIndex = e.NewPageIndex
        gv_Perfiles.DataBind()
    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ddl As DropDownList = CType(gv_Perfiles.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
        gv_Perfiles.SetPageIndex(ddl.SelectedIndex)
    End Sub

    Private Sub gv_Perfiles_DataBound(sender As Object, e As EventArgs) Handles gv_Perfiles.DataBound
        Try
            For Each row As GridViewRow In gv_Perfiles.Rows
                If CInt(row.Cells(0).Text) = 1 Or CInt(row.Cells(0).Text) = 29 Then
                    Dim imageneliminar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Eliminar"), System.Web.UI.WebControls.ImageButton)
                    imageneliminar.Visible = False
                    Dim imagenEditar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Editar"), System.Web.UI.WebControls.ImageButton)
                    imagenEditar.Visible = False
                End If

            Next

            Dim ddl As DropDownList = CType(gv_Perfiles.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Perfiles.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Perfiles.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt
        Catch ex As Exception

        End Try
    End Sub
End Class