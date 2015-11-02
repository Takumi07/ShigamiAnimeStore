<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="resumenCompra.aspx.vb" Inherits="ShigamiAnimeStore.resumenCompra" EnableEventValidation="false" %>

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
                <div id="sinProductos" class="msj-warning col-md-12" runat="server" visible="false">
                    <asp:Label ID="lbl_SinProductos" runat="server" CssClass="textoTitulo negrita center">No posee productos agregado al carrito.</asp:Label>
                </div>


                <div class="col-md-10 col-md-offset-1">

                    <div class="fila">
                        <div class="col-md-10 col-md-offset-1">
                            <br />
                            <br />
                            <asp:GridView ID="GridView1" CssClass="Grid-rojo" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                    <asp:BoundField DataField="TipoProducto.Descripcion" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Genero.Descripcion" HeaderText="Genero" />
                                    <asp:BoundField DataField="CantidadComprada" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_remover" runat="server" OnCommand="btn_remover_Command" ImageUrl="~/Imagenes/delete-32.png" ToolTip="Eliminar Unidad" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                            <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_Eliminar" runat="server" OnCommand="btn_Eliminar_Command" ImageUrl="~/Imagenes/papelera.png" ToolTip="Eliminar" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                        </ItemTemplate>

                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <br />
                            <br />
                            <div class="col-md-12" runat="server" id="botones">
                                <div class="col-md-3 col-md-offset-2">
                                    <asp:Button ID="btn_Confirmar" CssClass="btn btn-aceptar btn-block" runat="server" Text="Confirmar Compra" />
                                </div>
                                <div class="col-md-3 col-md-offset-2">
                                    <asp:Button ID="btn_cancelar" CssClass="btn btn-cancelar btn-block" runat="server" Text="Cancelar" />
                                </div>
                            </div>
                        </div>
                    </div>






                </div>
            </div>

        </div>
    </div>
</asp:Content>
