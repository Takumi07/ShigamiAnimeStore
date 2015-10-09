<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="recuperarClave.aspx.vb" Inherits="ShigamiAnimeStore.recuperarClave" %>
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
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-rojo">
                <div class="panel-cabecera">Recuperar Contraseña</div>
                <div class="panel-cuerpo">
                    <br />
                    <div class="fila">
                        <div class="col-md-1  col-md-offset-2">
                            <asp:Image ID="img_user" runat="server" ImageUrl="~/Imagenes/user-32.png"/>
                        </div>
                        <div class="col-md-2">
                            <div class="label">
                                <asp:Label ID="lbl_Usuario" runat="server">Usuario</asp:Label>
                            </div>
                    </div>
                    <div class="col-md-4 col-md-offset-1">
                            <asp:TextBox ID="txt_usuario" runat="server" CssClass="caja-texto"></asp:TextBox>
                    </div>
                       <div class="col-md-1 col-md-offset-1">
                                                                                       <asp:RequiredFieldValidator ID="requerido_txt_usuario" runat="server"
                            ControlToValidate="txt_usuario" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
   
                       </div>
                    </div>
                    <br />
                   <div class="fila">
                                              <div class="col-md-1  col-md-offset-2">
                            <asp:Image ID="img_pass" runat="server" ImageUrl="~/Imagenes/message-32.png"/>
                        </div>
                         <div class="col-md-2">
                             <div class="label">
                             <asp:Label ID="lbl_Correo" runat="server">Correo</asp:Label>

                        </div>
                    </div>
                    <div class="col-md-4 col-md-offset-1">
                            <asp:TextBox ID="txt_correo" runat="server" CssClass="caja-texto"></asp:TextBox>
                     
                        </div>
                         <div class="col-md-1 col-md-offset-1">
                                                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txt_correo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
ControlToValidate="txt_correo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RegularExpressionValidator>

   
                       </div>
                    </div>
                    <br />
                    <br />
                    <div class="fila">
                        <div class="col-md-2 col-md-offset-5">
                            <asp:Button ID="btn_recuperar" runat="server" Text="Recuperar" cssclass="btn btn-aceptar"/>
                        </div>
                    </div>
                </div>
            </div>
                </div>

        </div>
    </div>


</asp:Content>
