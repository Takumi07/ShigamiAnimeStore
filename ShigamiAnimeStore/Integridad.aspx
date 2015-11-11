<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Integridad.aspx.vb" Inherits="ShigamiAnimeStore.Integridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
    <div class="panel panel-rojo">
        <div class="panel-cabecera">
            <asp:Label ID="lbl_Integridad" runat="server" Text="Integridad"></asp:Label>
        </div>
        <div class="panel-cuerpo">
            <br />
            <div class="fila">
                <div class="col-md-10 col-md-offset-1">
                    <div class="fila">
                        <div class="col-md-10 col-md-offset-1">
                            <asp:Panel ID="PanelDV" runat="server">
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="col-md-12" runat="server" id="botones">
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="btn_reparar" CssClass="btn btn-aceptar btn-block" runat="server" Text="Reparar Integridad" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
