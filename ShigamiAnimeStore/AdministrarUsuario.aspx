<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AdministrarUsuario.aspx.vb" Inherits="ShigamiAnimeStore.AdministrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
        <div class="contenedor">
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                  <div class="panel panel-rojo">
                        <div class="panel-cabecera"><asp:Label ID="cab_AdminUsuario" runat="server">Administración de Usuarios</asp:Label></div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                            <div class="col-md-4">
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:ImageButton ID="img_filtroUsuario" runat="server" ImageUrl="~/Imagenes/User-32.png" CssClass="IconoImagen center"/>
                                </div>
                                <div class="col-md-6 margenFiltro">
                                    <asp:Label ID="lbl_porUsuario" runat="server" cssclass="label">Usuario</asp:Label>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <div class="col-md-2 col-md-offset-2">
                                <asp:ImageButton ID="img_information" runat="server" ImageUrl="~/Imagenes/Personal-information-32.png" CssClass="IconoImagen center"/>
                                </div>
                                <div class="col-md-6 margenFiltro">
                                <asp:Label ID="lbl_porDNI" runat="server" cssclass="label">Por DNI</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:Image ID="img_Estado" runat="server" ImageUrl="~/Imagenes/Lock_32.png" CssClass="IconoImagen center"/>
                                </div>
                                <div class="col-md-6 margenFiltro">
                                    <asp:Label ID="lbl_Estado" runat="server" cssclass="label">Estado</asp:Label>
                                </div>
                            </div>

                            </div>
                        <div class="fila">
                            <div class="col-md-4">
                               <div class="col-md-10 col-md-offset-1">
                                    <asp:DropDownList ID="ddl_Usuario" runat="server" CssClass="combo">
                                    </asp:DropDownList>
                                </div>
                            </div>
                                <div class="col-md-4">
                                <div class="col-md-10 col-md-offset-1">
                                    <asp:DropDownList ID="ddl_ApellidoyNombre" runat="server" CssClass="combo"></asp:DropDownList>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-10 col-md-offset-1">
                                <asp:DropDownList ID="ddl_Operacion" runat="server" CssClass="combo">
                                    <asp:ListItem Selected="True" Value="2">Todos</asp:ListItem>
                                    <asp:ListItem Value="0">Activo</asp:ListItem>
                                    <asp:ListItem Value="1">Bloqueado</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            </div> 
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-5">
                            <asp:Button ID="btn_buscar" runat="server" Text="Buscar"  CssClass="btn btn-modificar btn-block"/>   
                                </div>
                            </div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                            <asp:GridView ID="gv_Usuarios" runat="server" CssClass="Grid-rojo" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="gv_Usuarios_PageIndexChanging" RowStyle-Height="30px">
                                                                                  <PagerTemplate>
           <div class="label right">
            
     <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged"/>
               </div>
                </PagerTemplate>  
                                 <Columns>
                                                                <asp:BoundField DataField="ID" HeaderText="ID Usuario" Visible="false" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                                                                <asp:BoundField DataField="Persona" HeaderText="Apellido y Nombre" />
                <asp:BoundField DataField="Idioma.Nombre" HeaderText="Idioma" />
                <asp:BoundField DataField="Perfil.Nombre" HeaderText="Perfil" />

                <asp:BoundField DataField="Bloqueado" HeaderText="Estado" />
                                <asp:BoundField DataField="FechaAlta"  HeaderText="Fecha de Alta" dataformatstring="{0:d}" />
                                                   <asp:BoundField DataField="Editable"  HeaderText="Editable"/>
                 <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                    <itemtemplate>
                        <div class="col-md-2 col-md-offset-1">
                            <asp:ImageButton ID="btn_Bloqueo" runat="server" OnCommand="Bloqueo_Command" ImageUrl="~/Imagenes/lock-32.png" height="20px" CommandArgument='<%#Eval("ID")%>' cssclass="left"/>
                         <asp:ImageButton ID="btn_desBloqueo" runat="server" OnCommand="desBloqueo_Command" ImageUrl="~/Imagenes/unlock-32.png" height="20px" CommandArgument='<%#Eval("ID")%>' cssclass="left" />
                        </div>
                        <div class="col-md-2 col-md-offset-2">
                            <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="Editar_Command" ImageUrl="~/Imagenes/edit-32.png" height="20px" CommandArgument='<%#Eval("ID")%>' cssclass="center"/>
                        </div>
                        <div class="col-md-2 col-md-offset-2">
                            <asp:ImageButton ID="btn_Eliminar" runat="server" OnCommand="Eliminar_Command" ImageUrl="~/Imagenes/delete-32.png" height="20px" CommandArgument='<%#Eval("ID")%>' cssclass="right"/>
                        </div>
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
        </div>
</asp:Content>
