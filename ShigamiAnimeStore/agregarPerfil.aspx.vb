Public Class agregarPerfil
    Inherits System.Web.UI.Page
    Private _gestorPermiso As New BLL.PermisoBLL
    Private _listapermisos As List(Of ENTIDADES.PermisoBase)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If validaciones.validarPagina(Me) = False Then
        'Response.Redirect("error.aspx")
        ' End If
        Me.cargarTodos()
        If Not IsPostBack Then
            Me.CargarTreeView()
            Dim Context As HttpContext = HttpContext.Current
            If Context.Items.Contains("FamiliaaEditar") Then
                Dim _permisoaEditar As ENTIDADES.PermisoCompuesto = _gestorPermiso.ListarFamilias(CInt(Context.Items("FamiliaaEditar")))
                Me.cargarPermiso(_permisoaEditar)
                Session("FamiliaaEditar") = _permisoaEditar
            End If
        End If
    End Sub


    Public Sub cargarTodos()
        _listapermisos = _gestorPermiso.ListarFamilias(False)
    End Sub

    Public Sub cargarPermiso(ByVal paramPermiso As ENTIDADES.PermisoCompuesto)
        chequearTreeView(paramPermiso, Me.treeviewPermisos)
        Me.txt_nombre.Text = paramPermiso.Nombre
        Me.txt_nombre.Enabled = False
        Me.agregar.Visible = False
        Me.modificar.Visible = True
    End Sub

    Private Sub CargarTreeView()
        armarTreeView(_listapermisos, Me.treeviewPermisos)
    End Sub

#Region "Composite Permisos"
    Public Shared Sub chequearTreeView(ByVal _permiso As ENTIDADES.PermisoCompuesto, ByRef _tree As TreeView)
        For Each _node As TreeNode In _tree.Nodes
            If _node.Text = _permiso.Nombre Then
                _node.Checked = True
            End If
        Next
    End Sub

    Public Shared Sub armarTreeView(ByVal _listapermisos As List(Of ENTIDADES.PermisoBase), ByRef _tree As TreeView)
        Try
            For Each _per As Entidades.PermisoBase In _listapermisos
                _tree.Nodes.Add(New TreeNode(_per.Nombre))
                _tree.Nodes(_tree.Nodes.Count - 1).ShowCheckBox = True
                If _per.tieneHijos = True Then
                    agregarNodoHijo(_per, _tree.Nodes(_tree.Nodes.Count - 1))
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub agregarNodoHijo(ByVal _listaCompuesto As ENTIDADES.PermisoCompuesto, ByRef _treenodo As TreeNode)
        For Each _per As Entidades.PermisoBase In _listaCompuesto.ListaPermisosSimple
            _treenodo.ChildNodes.Add(New TreeNode(_per.Nombre))
            If Not _per.URL = Nothing And _listaCompuesto.URL <> Nothing Then
                _treenodo.ChildNodes(_treenodo.ChildNodes.Count - 1).ShowCheckBox = True
            End If
            If _per.tieneHijos = True Then
                agregarNodoHijo(_per, _treenodo.ChildNodes(_treenodo.ChildNodes.Count - 1))
            End If
        Next
    End Sub

    Public Shared Function retornarIndice(ByVal _listapermisos As List(Of ENTIDADES.PermisoBase), ByVal _nombre As String) As Integer
        For Each _per As Entidades.PermisoBase In _listapermisos
            If _per.Nombre = _nombre Then
                Return _listapermisos.IndexOf(_per)
            End If
        Next
        Return 0
    End Function

    Public Shared Function revisarLista(ByVal _per As ENTIDADES.PermisoBase, _listaper As List(Of ENTIDADES.PermisoBase)) As Boolean
        If _listaper.Contains(_per) Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            'validaciones.validarSubmit(Me, Me.error, Me.lbl_TituloError)
            If validarListaPermisos() = True Then
                Dim _entidadPermiso As New Entidades.PermisoCompuesto
                _entidadPermiso.Nombre = txt_nombre.Text
                For Each _nodo As TreeNode In treeviewPermisos.CheckedNodes
                    Dim _per As Entidades.PermisoBase = _listapermisos.Item(retornarIndice(_listapermisos, _nodo.Text))
                    If revisarLista(_per, _entidadPermiso.ListaPermisosSimple) = True Then
                        _entidadPermiso.ListaPermisosSimple.Add(_per)
                    End If
                Next
                _gestorPermiso.Alta(_entidadPermiso)
                Response.Redirect("administrarPerfiles.aspx", False)
            Else
                Throw New BLL.CamposincompletosException
            End If
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As BLL.PermisoDuplicadoException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Try
            If validarListaPermisos() = True Then
                Dim _entidadPermiso As New Entidades.PermisoCompuesto
                _entidadPermiso.Nombre = txt_nombre.Text
                For Each _nodo As TreeNode In treeviewPermisos.CheckedNodes
                    Dim _per As Entidades.PermisoBase = _listapermisos.Item(retornarIndice(_listapermisos, _nodo.Text))
                    If revisarLista(_per, _entidadPermiso.ListaPermisosSimple) = True Then
                        _entidadPermiso.ListaPermisosSimple.Add(_per)
                    End If
                Next
                _entidadPermiso.ID = DirectCast(Session("FamiliaaEditar"), Entidades.PermisoCompuesto).ID
                _gestorPermiso.Modificar(_entidadPermiso)
                Session.Remove("FamiliaaEditar")
                Response.Redirect("administrarPerfiles.aspx", False)
            Else
                Throw New BLL.IngresarunPermisoException
            End If
        Catch ex As BLL.CamposincompletosException
            Me.error.Visible = True
            Me.lbl_TituloError.Text = ex.Mensaje
        Catch ex As Exception

        End Try
    End Sub

    Private Function validarListaPermisos() As Boolean
        Dim flagNodo As Boolean = False
        For Each _node As TreeNode In Me.treeviewPermisos.Nodes
            If _node.Checked = True Then
                flagNodo = True
            End If
        Next
        If flagNodo = False Then
            Return False
        Else
            Return True
        End If
    End Function


    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("index.aspx", False)
    End Sub

    Protected Sub btn_cancelarModificar_Click(sender As Object, e As EventArgs) Handles btn_cancelarModificar.Click
        Session.Remove("FamiliaaEditar")
        Response.Redirect("administrarPerfiles.aspx", False)
    End Sub
End Class