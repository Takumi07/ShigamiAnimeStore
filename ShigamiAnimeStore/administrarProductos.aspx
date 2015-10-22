<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="administrarProductos.aspx.vb" Inherits="ShigamiAnimeStore.administrarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">

    <div class="contenedor">
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_adminPerfil" runat="server">Administración de Productos</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <div class="fila">

                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_Descripcion" runat="server">Descripción</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="txt_descripcion" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_TipoProducto" runat="server">Tipo Producto</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:DropDownList ID="ddl_TipoProducto" runat="server" CssClass="combo"  AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_Genero" runat="server">Genero</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:DropDownList ID="ddl_Genero" runat="server" CssClass="combo"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_Precio" runat="server">Precio</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="txt_precio" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_Stock" runat="server">Stock</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="txt_Stock" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="Label1" runat="server">label1</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <br />


                           <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="Label2" runat="server">label2</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    calendar 1
                                </div>
                            </div>
                            <br />




                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="Label3" runat="server">label3</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="fila">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="Label4" runat="server">label4</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />

                            <div class="fila">
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:Button ID="Button3" runat="server" Text="Alta"  cssclass="btn btn-aceptar btn-block" />
                                </div>
                                <div class="col-md-2 col-md-offset-1">
                                    <asp:Button ID="Button1" runat="server" Text="Modificar"  cssclass="btn btn-modificar btn-block" />
                                </div>
                                <div class="col-md-2 col-md-offset-1">
                                    <asp:Button ID="Button2" runat="server" Text="Eliminar"  cssclass="btn btn-cancelar btn-block" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
