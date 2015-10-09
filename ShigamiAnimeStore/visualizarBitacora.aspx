<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="visualizarBitacora.aspx.vb" Inherits="ShigamiAnimeStore.visualizarBitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css"/>
          <script>
              $(function () {
                  $("#contenidoPagina_datepicker").datepicker();
              });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoPagina" runat="server">
               <div class="contenedor">
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                  <div class="panel panel-rojo">
                        <div class="panel-cabecera"><asp:Label ID="cab_VisualizarBitacora" runat="server">Visualizar Bitacora</asp:Label></div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                            <div class="col-md-4">
                                <div class="col-md-2 col-md-offset-2">
                                   <asp:ImageButton ID="img_filtroUsuario" runat="server" ImageUrl="~/Imagenes/User-32.png" CssClass="IconoImagen center"/>
                                </div>
                                <div class="col-md-6 margenFiltro">
                                     <asp:Label ID="lbl_porUsuario" runat="server" cssclass="label">Usuario</asp:Label>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <div class="col-md-2 col-md-offset-2">
                                <asp:ImageButton ID="img_filtroFecha" runat="server" ImageUrl="~/Imagenes/Calendar-32.png" CssClass="IconoImagen center"/>
                                </div>
                                <div class="col-md-6 margenFiltro">
                                  <asp:Label ID="lbl_porFecha" runat="server" cssclass="label">Fecha</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-2 col-md-offset-2">
                                <asp:ImageButton ID="img_TipoPrioridad" runat="server" ImageUrl="~/Imagenes/Question-type-one-correct-32.png" CssClass="IconoImagen center"/>
                                </div>
                                <div class="col-md-6 margenFiltro">
                                <asp:Label ID="lbl_TipoPrioridad" runat="server" cssclass="label">Tipo de Operacion</asp:Label>
                                </div>
                            </div>
                            </div>
                        <div class="fila">
                            <div class="col-md-4">
                               <div class="col-md-10 col-md-offset-1">
                                   <asp:DropDownList ID="ddl_Usuario" runat="server" CssClass="combo"></asp:DropDownList>
                                </div>
                            </div>
                                <div class="col-md-4">
                                <div class="col-md-10 col-md-offset-1">
                             <asp:TextBox ID="datepicker" runat="server" CssClass="caja-texto"></asp:TextBox>                               
                                    </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-10 col-md-offset-1">
                                    <asp:DropDownList ID="ddl_Operacion" runat="server" CssClass="combo">
                                    </asp:DropDownList>
                            </div>
                            </div> 
                        </div>
                                              <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-5">
                            <asp:Button ID="btn_buscar" runat="server" Text="Buscar"  CssClass="btn btn-modificar btn-block"/>   
                            </div>
                            </div>
                        </div>

                   <div class="panel-cuerpo">
                        <div class="fila">
                            <asp:GridView ID="gv_Bitacora" runat="server" CssClass="Grid-rojo" AutoGenerateColumns="False" HorizontalAlign="Center"  AllowPaging="True" PageSize="20">
                              
       <PagerTemplate>
           <div class="label right">
     <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged"/>
               </div>
                </PagerTemplate>           
                                 <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID_Bitacora" Visible="False" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="TipoOperacion" HeaderText="Tipo de Operacion" />
                <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
        </div>
    </div>
            </div>

</asp:Content>
