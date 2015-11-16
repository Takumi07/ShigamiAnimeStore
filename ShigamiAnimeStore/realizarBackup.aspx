<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="realizarBackup.aspx.vb" Inherits="ShigamiAnimeStore.realizarBackup" %>

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
        <div class="fila" id="Panel" runat="server">
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_Backup" runat="server">Realizar Backup</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-1">
                                <asp:Label ID="lbl_Nombre" runat="server" CssClass="label">Nombre</asp:Label>

                            </div>
                            <div class="col-md-5 col-md-offset-2">
                                <asp:TextBox ID="txt_nombre" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_nombre" runat="server"
                                    ControlToValidate="txt_nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-1">
                                <asp:Label ID="lbl_Directorio" runat="server" CssClass="label">Directorio</asp:Label>
                            </div>
                            <div class="col-md-5 col-md-offset-2">
                                <asp:TextBox ID="txt_Directorio" runat="server" CssClass="caja-texto" MaxLength="200"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Directorio" runat="server"
                                    ControlToValidate="txt_Directorio" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-aceptar btn-block" />
                            </div>
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div id="Confirmacion" class="msj-warning col-md-12" runat="server" visible="false">
            <asp:Label ID="lbl_Confirmacion" runat="server" CssClass="textoTitulo negrita center">No se encontraron productos.</asp:Label>
        </div>
    </div>
           <br />
        <br />
        <br />
</asp:Content>
