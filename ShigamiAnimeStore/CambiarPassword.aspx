<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="CambiarPassword.aspx.vb" Inherits="ShigamiAnimeStore.CambiarPassword" %>
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
               <div class="col-md-8 col-md-offset-2" runat="server">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_cambiarPassword" runat="server">Cambiar Contraseña</asp:Label>

                    </div>
                    <div class="panel-cuerpo">
                                                <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_passwordActual" runat="server">Contraseña Actual</asp:Label></div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_passwordActual" runat="server" CssClass="caja-texto" TextMode="Password" MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                        <asp:RequiredFieldValidator ID="requerido_txt_passwordActual" runat="server"
                        ControlToValidate="txt_passwordActual" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>                    
                        <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_NuevoPassword" runat="server">Nueva Contraseña</asp:Label></div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_nuevoPassword" runat="server" CssClass="caja-texto" TextMode="Password" MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                                        <asp:RequiredFieldValidator ID="requerido_txt_nuevoPassword" runat="server"
                        ControlToValidate="txt_nuevoPassword" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                          <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_RepetirNuevoPassword" runat="server">Repetir Nueva Contraseña</asp:Label></div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_repetirPassword" runat="server" CssClass="caja-texto" TextMode="Password" MaxLength="20"></asp:TextBox>
                            </div>
                                                        <div class="col-md-1 col-md-offset-1">
                        <asp:RequiredFieldValidator ID="requerido_txt_repetirPassword" runat="server"
                        ControlToValidate="txt_repetirPassword" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />
                            <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_modificarPass" runat="server" Text="Agregar" cssclass="btn btn-modificar btn-block"/>
                                </div>
                            <div class="col-md-2 col-md-offset-2">
                                 <asp:Button ID="btn_cancelarPass" runat="server" Text="Cancelar" cssclass="btn btn-cancelar btn-block"/>
                            </div>
                        </div>
                    <br />
                    </div>
                </div>
                            </div>
            </div>
    </div>
    <br />

</asp:Content>
