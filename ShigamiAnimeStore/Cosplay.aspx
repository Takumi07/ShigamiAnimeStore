<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Cosplay.aspx.vb" Inherits="ShigamiAnimeStore.Cosplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
            <div class="panel panel-rojo">
        <div class="panel-cabecera">
            <asp:Label ID="lbl_Cosplay" runat="server" Text="Cosplay"></asp:Label>
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
                                    <asp:BoundField DataField="Genero.Descripcion" HeaderText="Genero" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_Agregar" runat="server" OnCommand="btn_Agregar_Command" ImageUrl="~/Imagenes/add-32.png" Height="20px" CommandArgument='<%#Eval("ID")%>' CssClass="center" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div id="sinComentarios" class="msj-warning col-md-12" runat="server" visible="false">
                        <asp:Label ID="lbl_SinComentarios" runat="server" CssClass="textoTitulo negrita center">No se encontraron productos.</asp:Label>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
