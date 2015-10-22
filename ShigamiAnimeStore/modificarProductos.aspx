<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="modificarProductos.aspx.vb" Inherits="ShigamiAnimeStore.modificarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
    <div class="contenedor">
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_productos" runat="server">Modificar Productos</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                            <div class="col-md-11 col-md-offset-1">
                                <asp:GridView ID="GridView1" runat="server" CssClass="Grid-rojo" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                        <asp:BoundField DataField="TipoProducto.Descripcion" HeaderText="Tipo" />
                                        <asp:BoundField DataField="Genero.Descripcion" HeaderText="Genero" />
                                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="btn_Editar_Command" ImageUrl="~/Imagenes/edit-32.png" Height="20px" CommandArgument='<%#Eval("ID")%>' CssClass="center" />
                                            </ItemTemplate>
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
