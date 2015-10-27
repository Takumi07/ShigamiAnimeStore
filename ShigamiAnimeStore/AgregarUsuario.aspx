<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AgregarUsuario.aspx.vb" Inherits="ShigamiAnimeStore.AgregarUsuario" %>

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
                        <asp:Label ID="cab_agregarUsuario" runat="server">Agregar Usuario</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_NombredeUsuario" runat="server">Nombre de Usuario</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_nombreUsuario" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_nombreUsuario" runat="server"
                                    ControlToValidate="txt_nombreUsuario" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div id="passAgregar" runat="server">
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_password" runat="server">Contraseña</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="txt_password" runat="server" CssClass="caja-texto" TextMode="Password" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                    <asp:RequiredFieldValidator ID="requerido_txt_password" runat="server"
                                        ControlToValidate="txt_password" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_repetirPassword" runat="server">Repetir Contraseña</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="txt_repetirPassword" runat="server" CssClass="caja-texto" TextMode="Password" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                    <asp:RequiredFieldValidator ID="Required_txt_repetirPassword" runat="server"
                                        ControlToValidate="txt_repetirPassword" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="fila" id="passModificar" runat="server" visible="false">
                            <br />
                            <div class="col-md-5 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_NuevoPassword" runat="server">Resetear Contraseña</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:CheckBox ID="chk_resetPassword" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_documento" runat="server">N° de Documento</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_Documento" runat="server" CssClass="caja-texto" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="Requiredtxt_Documento" runat="server"
                                    ControlToValidate="txt_Documento" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_perfil" runat="server">Perfil</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:DropDownList ID="ddl_Perfiles" runat="server" CssClass="combo">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_idioma" runat="server">Idioma</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:DropDownList ID="ddl_Idiomas" runat="server" CssClass="combo">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div id="btnAgregar" runat="server">
                            <div class="fila">
                                <div class="col-md-2 col-md-offset-3">
                                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-aceptar btn-block" />
                                </div>
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                                </div>
                            </div>
                        </div>
                        <div id="btnModificar" runat="server">
                            <div class="fila">
                                <div class="col-md-2 col-md-offset-3">
                                    <asp:Button ID="btn_Modificar" runat="server" Text="Modificar" CssClass="btn btn-modificar btn-block" />
                                </div>
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:Button ID="btn_cancelarModificar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
