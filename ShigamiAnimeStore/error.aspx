<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="error.aspx.vb" Inherits="ShigamiAnimeStore._error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
        <br />
    <br />
    <br />
<div class="contenedor">
    <div class="fila">
        <div class="col-md-5 col-md-offset-5">
                            <asp:Image ID="img_error" runat="server" CssClass="center-block" ImageUrl="~/Imagenes/Exclamation-Red-64.png"/>
        </div>

    </div>
    <br />
    <div class="fila">
        <div class="col-md-8 col-md-offset-2">
            <div id="error" class="msj-error col-md-12" runat="server">
                <asp:Label ID="lbl_TituloErrorGenerico" runat="server" CssClass="label">Se ha producido un error al ejecutar al acción. Se lo redireccionará al Inicio.</asp:Label>
            </div>
        </div>
    </div>
</div>
    <br />
    <br />
    <br />
</asp:Content>
