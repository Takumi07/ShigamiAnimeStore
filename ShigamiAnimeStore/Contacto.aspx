<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Contacto.aspx.vb" Inherits="ShigamiAnimeStore.Contacto" %>
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
        <div class="fila">

            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-rojo">
                    <div class="panel-cabecera"><asp:Label ID="cab_contacto" runat="server">Contacto</asp:Label></div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                            <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label></div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                            </div>
                                                        <div class="col-md-1 col-md-offset-1">
                        <asp:RequiredFieldValidator ID="requerido_txt_nombre" runat="server"
                        ControlToValidate="txt_nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_apellido" runat="server">Apellido</asp:Label></div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="txt_Apellido" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                            </div>
                                                                                    <div class="col-md-1 col-md-offset-1">
                        <asp:RequiredFieldValidator ID="Requiredtxt_Apellido" runat="server"
                        ControlToValidate="txt_Apellido" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                                                <div class="fila">
                            <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Correo" runat="server">Correo</asp:Label></div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="txt_correo" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                                </div>
<div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txt_correo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador" ></asp:RequiredFieldValidator>

                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
ControlToValidate="txt_correo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RegularExpressionValidator>
</div>
                            </div>
                        <br />
                                                <div class="fila">
                            <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Telefono" runat="server">Teléfono</asp:Label></div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="txt_telefono" runat="server" CssClass="caja-texto" MaxLength="20"></asp:TextBox>
                                </div>
                                                    <div class="col-md-1 col-offset-1">
                                    <asp:CompareValidator ID="validartelefono" runat="server" ControlToValidate="txt_telefono" Type="Integer" Operator="DataTypeCheck" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador" />
                            </div>
                                                    </div>  
                    <br />
                            <div class="fila" >
                            <div class="col-md-3 col-md-offset-1">
                                <asp:Label ID="lbl_Titulo" runat="server" CssClass="label">Título</asp:Label></div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_Titulo" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>           
                            </div>
                                                                                    <div class="col-md-1 col-md-offset-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Titulo" runat="server"
                        ControlToValidate="txt_Titulo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                                                <br />
                                                <div class="fila">
                            <div class="col-md-3 col-md-offset-1">
                                <asp:Label ID="lbl_mensaje" runat="server" CssClass="label">Mensaje</asp:Label></div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_Mensaje" runat="server" CssClass="caja-texto sinEditar" Height="250px" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                            </div>
                                                                                    <div class="col-md-1 col-md-offset-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Mensaje" runat="server"
                        ControlToValidate="txt_Mensaje" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>

                                                    </div>
                        <br />
                                                                                                    <br />
                                                <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_enviar" runat="server" Text="Enviar" cssclass="btn btn-aceptar btn-block"/>
                                </div>
                             <div class="col-md-2 col-md-offset-2">
                                <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" cssclass="btn btn-cancelar btn-block"/>
                                </div>
                                  </div>       
                                    <br /> 
                         <br /> 
                            </div> 
                                          
                        </div>

                    </div>
            </div>

    </div>
</asp:Content>
