<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="registrarUsuario.aspx.vb" Inherits="ShigamiAnimeStore.registrarUsuario" %>
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
                        <asp:Label ID="Label1" runat="server">Usuario</asp:Label>
                     </div>
                    <div class="panel-cuerpo">
                        <div class="fila">
                             
                            <div class="col-md-12">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_NombreUsuario" runat="server">Usuario</asp:Label></div>
                                    </div>
                                    <div class="col-md-6 col-md-offset-1">
                                        <asp:TextBox ID="txt_nombreusuario" runat="server" CssClass="caja-texto" MaxLength="10"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Nombre de usuario en uso" ForeColor="Red"></asp:CustomValidator>
                                    </div>
                                </div>
                           
                                <div class="col-md-12">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_Contraseña" runat="server">Contraseña</asp:Label></div>
                                    </div>
                                    <div class="col-md-6 col-md-offset-1">
                                        <asp:TextBox ID="txt_contraseña" runat="server" CssClass="caja-texto" MaxLength="10" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1 text-center">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_contraseña" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*"></asp:CustomValidator>
                                    </div>
                                    
                                    <br />
                                    <br />
                                    
                                </div>
                          
                                <div class="col-md-12">
                                <div class="col-md-3 col-md-offset-1">
                                    <div class="label">
                                        <asp:Label ID="lbl_Idioma" runat="server">Idioma</asp:Label></div>
                                    </div>
                                    <div class="col-md-6 col-md-offset-1">
                                       <asp:DropDownList ID="ddl_idiomas" runat="server" CssClass="combo"></asp:DropDownList>
                                    </div>
                                </div>
                             </div>
                        </div>

                    <div class="panel-cabecera">
                        <asp:Label ID="cab_DatosPersonales" runat="server">Datos Personales</asp:Label>
                        </div>
                    <div class="panel-cuerpo">
                      <br />
<div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Documento" runat="server">Documento</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Documento" runat="server" CssClass="caja-texto" MaxLength="10"></asp:TextBox>
                            </div>
                                <div class="col-md-1 text-center">
                       <asp:RequiredFieldValidator ID="requerido_txt_nombre" runat="server"
                        ControlToValidate="txt_Documento" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="validarDocumento" runat="server" ControlToValidate="txt_Documento" Type="Integer" Operator="DataTypeCheck" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador" />
                                </div>
                            </div>
                                                     <div class="col-md-6">
                              <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Apellido" runat="server">Apellido</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Apellido" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                            </div>
                                                                                        <div class="col-md-1 text-center">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Apellido" runat="server"
                        ControlToValidate="txt_Apellido" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Nombre" runat="server" CssClass="caja-texto" MaxLength="150"></asp:TextBox>
                            </div>
                            <div class="col-md-1 text-center">
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Nombre" runat="server"
                                   ControlToValidate="txt_Nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                            </div>
                            </div>
                                                     <div class="col-md-6">
                              <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_FecNac" runat="server">Fecha de Nacimiento</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="datepicker" runat="server" CssClass="caja-texto"></asp:TextBox>
                            </div>
                            <div class="col-md-1 text-center">
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatordatepicker" runat="server"
                                   ControlToValidate="datepicker" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                             <asp:CompareValidator ID="validadorFecha" runat="server" ControlToValidate="datepicker" Type="Date" Operator="DataTypeCheck" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador" />
                                   </div>
                            </div>
                        </div>
                         <br />
                        <br />

                        <div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_correo" runat="server">Correo Electronico</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_correo" runat="server" CssClass="caja-texto" MaxLength="200"></asp:TextBox>
                            </div>
                                <div class="col-md-1 text-center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txt_correo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador" ></asp:RequiredFieldValidator>

                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
ControlToValidate="txt_correo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RegularExpressionValidator>
</div>
                            </div>
                                                     <div class="col-md-6">
                              <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Nacionalidad" runat="server">Nacionalidad</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                <asp:DropDownList ID="ddl_Nacionalidad" runat="server" CssClass="combo"></asp:DropDownList>
                            </div>
                            </div>
                        </div>
                        <br />
                        </div>
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_Direccion" runat="server">Direccion</asp:Label>
                        </div>
                    <div class="panel-cuerpo">
                        <br />
                           <div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Calle" runat="server">Calle</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Calle" runat="server" CssClass="caja-texto" MaxLength="180"></asp:TextBox>
                            </div>
                                    <div class="col-md-1 text-center">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Calle" runat="server"
                        ControlToValidate="txt_Calle" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                                     <div class="col-md-6">
                              <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Altura" runat="server">Altura</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Altura" runat="server" CssClass="caja-texto" MaxLength="10"></asp:TextBox>
                            </div>
                                                                                             <div class="col-md-1 text-center">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Altura" runat="server"
                        ControlToValidate="txt_Altura" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                                      <asp:CompareValidator ID="validarAltura" runat="server" ControlToValidate="txt_Altura" Type="Integer" Operator="DataTypeCheck" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador" />
                                                                                             </div>
                            </div>
                        </div>
                        <br />
                        <br />
                           <div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Piso" runat="server">Piso</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Piso" runat="server" CssClass="caja-texto" MaxLength="4"></asp:TextBox>
                            </div>
                            </div>
                                                     <div class="col-md-6">
                              <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Departamento" runat="server">Departamento</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Departamento" runat="server" CssClass="caja-texto" MaxLength="4"></asp:TextBox>
                            </div>
                            </div>
                        </div>
                         <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Localidad" runat="server">Localidad</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Localidad" runat="server" CssClass="caja-texto" MaxLength="180"></asp:TextBox>
                            </div>
                                                                    <div class="col-md-1 text-center">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Localidad" runat="server"
                        ControlToValidate="txt_Localidad" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                                     <div class="col-md-6">
                              <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Provincia" runat="server">Provincia</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                <asp:DropDownList ID="ddl_provincia" runat="server" CssClass="combo"></asp:DropDownList>
                            </div>
                            </div>
                        </div>
                         <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-6">
                                <div class="col-md-3 col-md-offset-1">
                            <div class="label">
                                <asp:Label ID="lbl_Postal" runat="server">Codigo Postal</asp:Label></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                    <asp:TextBox ID="txt_Postal" runat="server" CssClass="caja-texto" MaxLength="10"></asp:TextBox>
                            </div>
                    <div class="col-md-1 text-center">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_Postal" runat="server"
                        ControlToValidate="txt_Postal" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" cssclass="validador"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        </div>
                              <div class="panel-cabecera">
                        <asp:Label ID="cab_Contacto" runat="server">Contacto</asp:Label>
                        </div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-6">
                                <div class="fila">
                                        <div class="col-md-2 col-md-offset-5">
                            <div class="label">
                                <asp:Label ID="lbl_Telefonos" runat="server">Telefonos</asp:Label></div>
                            </div>
                                </div>
                            
                                <div class="fila">
                                       <div class="col-md-10 col-md-offset-1">
                                                                     <asp:GridView ID="gv_Telefono" runat="server"  CssClass="Grid-rojo" AutoGenerateColumns="False" HorizontalAlign="Center">
                                         <Columns>
                <asp:BoundField DataField="Numero" HeaderText="Numero" />
                <asp:BoundField DataField="tipoTelefono" HeaderText="Tipo" />
                <asp:TemplateField HeaderText="Quitar" HeaderStyle-Width="100px">
                    <itemtemplate>
                  <div class="col-md-2 col-md-offset-5 margenIconoMensaje">
                    <asp:ImageButton ID="btn_Eliminar" runat="server" OnCommand="btn_Eliminar_Command" ImageUrl="~/Imagenes/delete-32.png" height="20px" CommandArgument='<%#Eval("Numero")%>' />
                   </div>
                                     </itemtemplate>
                    
<HeaderStyle Width="100px"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                            </div>
                                </div>
                         
                            </div>
                                                        <div class="col-md-6">
                                    <div class="fila">
                                        <div class="col-md-3 col-md-offset-2 label">
                                            <asp:Label ID="lbl_NumeroTelefono" runat="server" Text="Numero"></asp:Label>
                                        </div>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txt_NumeroTelefono" runat="server" CssClass="caja-texto" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                                            <br />
                                                            <br />
                                                                        <div class="fila">
                                        <div class="col-md-3 col-md-offset-2 label">
                                            <asp:Label ID="lbl_TipoTelefono" runat="server" Text="Tipo"></asp:Label>
                                        </div>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="ddl_tipoTelefono" runat="server" CssClass="combo">
                                                               </asp:DropDownList>
                                        </div>
                                    </div>
                                                            <br />
                                          <div class="fila">
                                        <div class="col-md-1 col-md-offset-4">
                                            <asp:ImageButton ID="btn_agregarTelefono" runat="server" imageurl="~/Imagenes/Telephone-Add-32.png" CssClass="IconoImagen" OnClick="btn_agregarTelefono_Click"/>
                                        </div>
                                         <div class="col-md-5 margenIconoMensaje">
                                                  <asp:Label ID="lbl_agregarTelefono" runat="server" cssclass="label" Text="Agregar Telefono"></asp:Label>
                                        </div>
                                    </div>
                            </div>

                        </div>
    </div>


                              <div class="panel-cabecera">
                        <asp:Label ID="lbl_Imagen" runat="server">Imagen de Perfil</asp:Label>
                        </div>
               <br />
                               <div class="fila">
                            <div class="col-md-3 col-md-offset-2">
                                <br />  
                                <asp:Label ID="lbl_SeleccionarImagen" runat="server" Text="Seleccionar Imagen de Perfil" CssClass="label"></asp:Label>
                                </div>
                            <div class="col-md-2 col-md-offset-2">
                                <asp:FileUpload ID="fu_imagenUsuario"  runat="server" cssclass="label"/>
                            </div>
                        </div>
                            <br />
                            <br />                                                                                                       
                            <br />
                               <div class="fila">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" cssclass="btn btn-aceptar btn-block"/>
                                </div>
                            <div class="col-md-2 col-md-offset-2">
                                 <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" cssclass="btn btn-cancelar btn-block"/>
                            </div>
                        </div>
                                              <br />
                                <br />
                </div>

                           

            </div>
        </div>
         <br />
       

</asp:Content>
