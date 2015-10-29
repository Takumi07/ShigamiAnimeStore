<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="resumenCompra.aspx.vb" Inherits="ShigamiAnimeStore.resumenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
           <div class="panel panel-rojo">
        <div class="panel-cabecera">
            <asp:Label ID="lbl_ResumenCompra" runat="server" Text="Resumen Compra"></asp:Label>
        </div>
        <div class="panel-cuerpo">
            <br />
            <div class="fila">
                <div class="col-md-10 col-md-offset-1">

                    <div class="fila">
                        <div class="col-md-10 col-md-offset-1">
                            <asp:GridView ID="GridView1" CssClass="Grid-rojo" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                    <asp:BoundField DataField="N_Tomo" HeaderText="Nro. Tomo" />
                                    <asp:BoundField DataField="Genero.Descripcion" HeaderText="Genero" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div id="sinProductos" class="msj-warning col-md-12" runat="server" visible="false">
                        <asp:Label ID="lbl_SinProductos" runat="server" CssClass="textoTitulo negrita center">No posee productos agregado al carrito.</asp:Label>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
