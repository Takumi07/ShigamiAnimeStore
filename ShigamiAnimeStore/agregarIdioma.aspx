<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="agregarIdioma.aspx.vb" Inherits="ShigamiAnimeStore.agregarIdioma" %>

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
                        <asp:Label ID="cab_AgregarIdioma" runat="server">Agregar Idioma</asp:Label></div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-5 col-md-offset-1">
                                <div class="label">
                                    <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_NombreIdioma" runat="server" CssClass="caja-texto"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-5 col-md-offset-1">
                                <asp:Label ID="lbl_cultura" runat="server" CssClass="label">Cultura</asp:Label>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:DropDownList ID="ddl_cultura" runat="server" CssClass="combo"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gv_Palabras" runat="server" CssClass="Grid-rojo" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="gv_Palabras_PageIndexChanging">
                        <PagerTemplate>
                            <div class="label right">

                                <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                            </div>
                        </PagerTemplate>
                        <Columns>
                            <asp:BoundField DataField="ID_Control" HeaderText="ID" />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="Traduccion" HeaderText="Traduccion" />
                            <asp:TemplateField HeaderText="Nuevo Texto" HeaderStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:TextBox Width="350px" ID="txt_NuevoTexto" runat="server" CssClass="textarea" TextMode="MultiLine" Wrap="true"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="350px"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <div id="addIdioma" runat="server" visible="true">
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-aceptar btn-block" />
                            </div>
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                            </div>
                        </div>
                        <br />
                    </div>

                    <div id="modifIdioma" runat="server" visible="false">
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CssClass="btn btn-modificar btn-block" />
                            </div>
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Button ID="btn_cancelarModif" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
