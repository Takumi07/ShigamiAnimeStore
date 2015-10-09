<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MuestraIndexx.aspx.vb" Inherits="ShigamiAnimeStore.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/MisEstilos.css"
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="contenedor">
        <div class="fila">
                          <div class="panel panel-rojo">
                <div class="panel-cabecera">
                    EJEMPLO DE COLOR
                </div>
                <div class="panel-cuerpo">
                    lalalon
                </div>
            </div>
                                    <br />

                          <div class="panel panel-arena">
                <div class="panel-cabecera">
                    EJEMPLO DE COLOR
                </div>
                <div class="panel-cuerpo">
                    lalalon
                </div>
            </div>

            </div>
        <div class="fila">
            <div class="col-md-2">
                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-aceptar btn-block" />
            </div>
                        <div class="col-md-2 col-md-offset-1">
                <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-cancelar btn-block" />
            </div>
                        <div class="col-md-2 col-md-offset-1">
                <asp:Button ID="Button3" runat="server" Text="Button" CssClass="btn btn-modificar btn-block" />
            </div>
                        <div class="col-md-2 col-md-offset-1">
                <asp:Button ID="Button4" runat="server" Text="Button" CssClass="btn btn-remover btn-block" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
