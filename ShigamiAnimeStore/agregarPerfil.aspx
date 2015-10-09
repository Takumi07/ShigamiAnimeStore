<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="agregarPerfil.aspx.vb" Inherits="ShigamiAnimeStore.agregarPerfil" %>
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
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_agregarPerfil" runat="server">Agregar Perfil</asp:Label></div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label></div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                            </div>
                                                       <div class="col-md-1 col-md-offset-1">
                            <asp:RequiredFieldValidator ID="requerido_txt_nombre" runat="server"
                            ControlToValidate="txt_nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                                                <div class="fila">
                            <div class="col-md-2 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Permisos" runat="server">Permisos</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                 <asp:TreeView ID="treeviewPermisos" runat="server" ExpandDepth="0" ForeColor="Black" CssClass="label"></asp:TreeView>
                            </div>
                                                    </div>

                                                    <br />
                                                    <br />
                        <div id="agregar" runat="server">


                                                <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" cssclass="btn btn-aceptar btn-block"/>
                                </div>
                            <div class="col-md-2 col-md-offset-2">
                                 <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" cssclass="btn btn-cancelar btn-block"/>
                            </div>
                        </div>
                                                    </div>

                                                <div id="modificar" runat="server" visible="false">


                                                <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_modificar" runat="server" Text="Agregar" cssclass="btn btn-modificar btn-block"/>
                                </div>
                            <div class="col-md-2 col-md-offset-2">
                                 <asp:Button ID="btn_cancelarModificar" runat="server" Text="Cancelar" cssclass="btn btn-cancelar btn-block"/>
                            </div>
                        </div>
                                                    </div>
                        </div>
                         </div>
                        </div>
                </div>
          </div>
</asp:Content>
