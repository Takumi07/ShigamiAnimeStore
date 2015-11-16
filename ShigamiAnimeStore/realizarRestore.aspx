<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="realizarRestore.aspx.vb" Inherits="ShigamiAnimeStore.realizarRestore" %>

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
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_Restore" runat="server">Realizar Restore</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-4 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_SeleccionarArchivo" runat="server">Seleccionar el Archivo</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                <asp:FileUpload ID="fu_Restore" runat="server" CssClass="caja-texto" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_aceptar" runat="server" Text="Agregar" CssClass="btn btn-aceptar btn-block" />
                            </div>
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" OnClick="btn_cancelar_Click" />
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
