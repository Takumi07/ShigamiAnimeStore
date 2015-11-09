Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class CalcularDescuentos
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function CalcularDescuentos(ByVal paramMonto As Double, ByVal paramTipoPago As String)
        'Pagando en efectivo el monto es el normal.
        If paramTipoPago = "Efectivo" Then
            Return paramMonto
            'Pagando con tarjeta de crédito tiene un recargo del 25%
        ElseIf paramTipoPago = "Tarjeta de Crédito" Then
            Return paramMonto * 1.25
            'Pagando con tarjeta de débito tiene 5% de devolución de IVA
        ElseIf paramTipoPago = "Tarjeta de Débito" Then
            Return paramMonto * 0.94999999999999996
        End If

    End Function


    Public Function PorcentajeDescuento(ByVal paramTipoPago As String) As Double
        'Pagando en efectivo el monto es el normal.
        If paramTipoPago = "Efectivo" Then
            Return 0
            'Pagando con tarjeta de crédito tiene un recargo del 25%
        ElseIf paramTipoPago = "Tarjeta de Crédito" Then
            Return 1.25
            'Pagando con tarjeta de débito tiene 5% de devolución de IVA
        ElseIf paramTipoPago = "Tarjeta de Débito" Then
            Return 0.94999999999999996
        End If
    End Function

End Class