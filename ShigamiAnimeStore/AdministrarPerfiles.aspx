<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AdministrarPerfiles.aspx.vb" Inherits="ShigamiAnimeStore.AdministrarPerfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
            <div class="contenedor">
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera"><asp:Label ID="cab_adminPerfil" runat="server">Administración de Perfiles</asp:Label> </div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                                    <asp:GridView ID="gv_Perfiles" runat="server"  CssClass="Grid-rojo" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Perfiles_PageIndexChanging" RowStyle-Height="40px">
                     <PagerTemplate>
           <div class="label right">
               <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
     <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged"/>
               </div>
                </PagerTemplate>  
                                         <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Perfil" />
                <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                    <itemtemplate>
                        <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                    <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="Editar_Command" ImageUrl="~/Imagenes/edit-32.png" height="20px" CommandArgument='<%#Eval("ID")%>' />

                        </div>
                                                <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                        <asp:ImageButton ID="btn_Eliminar" runat="server" OnCommand="Eliminar_Command" ImageUrl="~/Imagenes/delete-32.png" height="20px" CommandArgument='<%#Eval("ID")%>' />

                        </div>
                    </itemtemplate>
                    
<HeaderStyle Width="100px"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>


</asp:Content>
