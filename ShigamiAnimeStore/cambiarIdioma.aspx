<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="cambiarIdioma.aspx.vb" Inherits="ShigamiAnimeStore.cambiarIdioma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
    

     <div class="contenedor">
        <div class="fila">
            <div class="col-md-12">
                                          <div id="error" class="msj-error col-md-12" runat="server" visible="false">
                <asp:Label ID="lbl_TituloError" runat="server" CssClass="label"></asp:Label>
            </div>
            </div>
            </div>
             <br />
                                 <div class="fila">
                      <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera">     <asp:Label ID="cab_cambiarIdioma" runat="server">Cambiar Idioma</asp:Label></div>
                    <div class="panel-cuerpo">
                                                <br />
                        <div class="fila">
                            <div class="col-md-5 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Idioma" runat="server">Idioma</asp:Label></div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:DropDownList ID="ddl_idiomas" runat="server" CssClass="combo">
                                </asp:DropDownList>
                            </div>
                        </div>
<br />
                        <br />
                            <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                               <asp:Button ID="btn_modificar" runat="server" Text="Agregar" cssclass="btn btn-modificar btn-block"/> 
                                </div>
                            <div class="col-md-2 col-md-offset-2">
                                 <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" cssclass="btn btn-cancelar btn-block"/>
                            </div>
                        </div>

                    </div>
                </div>
                            </div>
            </div>
            </div>
    <br />
</asp:Content>
