<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="QuienesSomos.aspx.vb" Inherits="ShigamiAnimeStore.QuienesSomos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
       <div class="contenedor">
        <div class="fila">
            <div class="col-md-12">
            </div>
            </div>
           <div class="fila">
               <div class="col-md-10 col-md-offset-1">
                   <div class="panel panel-rojo">
                       <div class="panel-cabecera">
                           <asp:Label ID="cab_quienessomos" runat="server">¿Quienes Somos?</asp:Label>
                       </div>
                       <div class="panel-cuerpo">
                           <div class="fila">
                             <div class="col-md-10 col-md-offset-1">
                                   <div class="texto">
                                       <asp:Label ID="lbl_quienesomos" runat="server" Text="Label">Somos una empresa Argentina que se dedica a la comercialización de diversos productos referidos a la cultura del manga y anime y sus posibles acoples. Dentro de nuestro catálogo podrás encontrar diversos productos referentes de la cultura nipona. <br /><br />
            A su vez ofrecemos un seguimineto del cliente, y estamos a su absoluta disposición. Contamos con los mejores productos directos de sus importadores. Podrás obtener todos los productos directamente de nuestros proveedores exclusivos.</asp:Label>
                                   </div>
                                   <br />
                                   <asp:Image ID="Image1" CssClass="imagenQuienesSomos" runat="server" ImageUrl="~/Imagenes/Anime1.jpg" />
                               </div>
                           </div>
                       </div>
                   </div>
               </div>
           </div>
    </div>
</asp:Content>
