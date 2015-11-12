<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="exportarCorreos.aspx.vb" Inherits="ShigamiAnimeStore.exportarCorreos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
    <div class="panel panel-rojo">
        <div class="panel-cabecera">
            <asp:Label ID="lbl_Manga" runat="server" Text="Correos"></asp:Label>
        </div>
        <div class="panel-cuerpo">
            <br />
            <div class="fila">
                <div class="col-md-10 col-md-offset-1">

                    <div class="fila">
                        <div class="col-md-10 col-md-offset-1">
                            <asp:GridView ID="GridView1" CssClass="Grid-rojo" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                    <asp:BoundField DataField="Mail" HeaderText="Mail" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" runat="server" id="botones">
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="btn_Exportar" CssClass="btn btn-aceptar btn-block" runat="server" Text="Exportar a XML" />
                        </div>
                    </div>
                    <div id="sinComentarios" class="msj-warning col-md-12" runat="server" visible="false">
                        <asp:Label ID="lbl_SinComentarios" runat="server" CssClass="textoTitulo negrita center">No se encontraron personas.</asp:Label>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
