Public Class GeneroEntidad


    Public Sub New()

    End Sub

    'Creo un constructor parametrizado así me ahorro cosas en la dal deproductos... para hacer mas fàcil.
    Public Sub New(ByVal paramID As Integer)
        Me.vID_Genero = paramID
    End Sub


    Private vID_Genero As Integer
    Public Property ID_Genero() As Integer
        Get
            Return vID_Genero
        End Get
        Set(ByVal value As Integer)
            vID_Genero = value
        End Set
    End Property



    Private VDescripcion As String
    Public Property Descripcion() As String
        Get
            Return VDescripcion
        End Get
        Set(ByVal value As String)
            VDescripcion = value
        End Set
    End Property


    Private vBL As Boolean
    Public Property BL() As Boolean
        Get
            Return vBL
        End Get
        Set(ByVal value As Boolean)
            vBL = value
        End Set
    End Property


    'Lo redefino para usarlo en eventos cuando hago la checklist
    Public Overrides Function ToString() As String
        Return Me.Descripcion
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is GeneroEntidad Then
            Return Me.Descripcion.Equals(CType(obj, GeneroEntidad).Descripcion)

        ElseIf TypeOf obj Is String Then
            Return Me.Descripcion.Equals(obj)
        Else
            Return False
        End If
    End Function
End Class
