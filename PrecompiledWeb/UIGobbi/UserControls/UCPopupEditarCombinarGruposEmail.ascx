<%@ control language="C#" autoeventwireup="true" inherits="Vistas_UCPopupEditarCombinarGruposEmail, App_Web_d25i0xw0" %>

<%@ Register TagPrefix="ma" Namespace="EvaWebControls" Assembly="EvaWebControls" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="~/UserControls/UCPopupBuscarRelacion.ascx" TagPrefix="myPopupDeDatos" TagName="BuscarRelacion" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

<link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
<link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
<link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" language="javascript">
	            var ModalProgress_EditarCombinarGrupoEmail = '<%= ModalProgress_EditarCombinarGrupoEmail.ClientID %>';   
                var ModalPopupResultados_EditarCombinarGrupoEmail = '<%= ModalPopupResultados_EditarCombinarGrupoEmail.ClientID %>';


                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq_EditarCombinarGrupoEmail);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq_EditarCombinarGrupoEmail);

                function abrirPopupEditarCombinarGrupoEmail() {
                    varModalPopupAbierto = ModalPopupResultados_EditarCombinarGrupoEmail;
   
                }


                function beginReq_EditarCombinarGrupoEmail(sender, args) 
                {
	                // shows the Popup 
	                var controlCaller=args.get_postBackElement().id;
	                //alert(controlCaller);
	                if (controlCaller.indexOf('btnSearch') == -1) { $find(ModalProgress_EditarCombinarGrupoEmail).show() };
        	 
                }

                /*
                shortcut.add("Esc",function() {
                try{
                      CerrarPanelResultados_EditarGrupoEmail();
                      //var usr = document.getElementById('ctl00_Contentplaceholder1_TextBox1_EditarGrupoEmail');
                      //usr.value="";
                   }
                catch(er)
                {}
      
      
                      } 
                      );*/

                function endReq_EditarCombinarGrupoEmail(sender, args)
                {
	                //  shows the Popup 
                    $find(ModalProgress_EditarCombinarGrupoEmail).hide();
                }

                function CerrarPanelResultados_EditarCombinarGrupoEmail()
                {
                    $find(ModalPopupResultados_EditarCombinarGrupoEmail).hide();
                  return false;
                } 


                function ConfirmarOperacion()
                {
                    if (confirm('¿Desea realizar esta operación?' ))
                    {
                        return true;
                    }
                    return false;
    
                }

</script>

<ajaxToolkit:ModalPopupExtender ID="ModalProgress_EditarCombinarGrupoEmail" runat="server"
    TargetControlID="panelUpdateProgress_EditarCombinarGrupoEmail" BackgroundCssClass="modalBackground"
    PopupControlID="panelUpdateProgress_EditarCombinarGrupoEmail" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupResultados_EditarCombinarGrupoEmail" runat="server"
    TargetControlID="HiddenFieldResultados_EditarCombinarGrupoEmail" BackgroundCssClass="modalBackground"
    PopupControlID="panelResultados_EditarCombinarGrupoEmail" />
<myPopupDeDatos:BuscarRelacion ID="popupBuscarEmpresaPersona_GE" runat="server" />
<asp:HiddenField ID="HiddenFieldResultados_EditarCombinarGrupoEmail" runat="server" />
<asp:Panel ID="panelUpdateProgress_EditarCombinarGrupoEmail" runat="server" CssClass="updateProgress">
    <asp:UpdateProgress ID="UpdateProg_EditarCombinarGrupoEmail" DisplayAfter="0" runat="server">
        <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: center;">
                <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                Procesando...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Panel>
<asp:Panel ID="panelResultados_EditarCombinarGrupoEmail" runat="server" Height="800px" Width="1200px" ScrollBars="Vertical">
    <asp:UpdatePanel ID="updatePanelResultados_EditarCombinarGrupoEmail" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 12px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 35px; width: 1100px;
                text-align: left; position: absolute; top: 1px;">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblTitulo" Text="Grupos de Emails" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="font-family: Tahoma, Arial, MS Sans Serif; font-weight: bold; font-size: 10px;
                background-color: White; border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset;
                text-align: left; height: 900px; text-align: left; width: 1100px; position: absolute;
                top: 20px;">
                <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                    font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: center;
                    width: 100%;">
                    <table>
                        <tr>
                            <td align="left">
                                Filtros de Búsqueda
                            </td>
                        </tr>
                    </table>
                </div>
                <table style="width: 1100px;">
                    <tr>
                        <td align="left">
                            <table>
                                <tr>
                                    <td valign="middle" align="left">
                                        <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                            font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                            border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: left;
                                            width: 853px;">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        Listado de Grupos de Emails
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <ma:SecureButton ID="btnNueva" runat="server" CausesValidation="True" CssClass="button"
                                                        Font-Bold="true" Height="20px" TabIndex="20" Text="Crear" ValidationGroup="datosGroup"
                                                        Width="75px" OnClick="btnNueva_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel2" runat="server" CssClass="scrollbar" Height="170px" ScrollBars="Horizontal"
                                                        Width="850px">
                                                        <ma:XGridView ID="gvGrupoEmail" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" BorderWidth="1px" DataKeyNames="id" EmptyDataText="No se encontraron resultados"
                                                            ExecutePageIndexChanging="True" PageSize="400" Width="100%" OnFilling="gvGrupoEmail_Filling"
                                                            OnPageIndexChanging="gvGrupoEmail_PageIndexChanging" OnRowCommand="gvGrupoEmail_RowCommand"
                                                            OnSelectedIndexChanged="gvGrupoEmail_SelectedIndexChanged" RowStyle-BorderWidth="1px">
                                                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDetalleGrupoEmail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                            CommandName="Detalles" runat="server" Text="Edit" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                    <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                </asp:TemplateField>                                                                                                                  
                                                                <asp:BoundField DataField="id" HeaderText="ID" Visible="True">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="descripcion" HeaderText="Nombre del Grupo" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                 <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkCombinarGrupoEmail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                            CommandName="Combinar" runat="server" Text="Seleccione Evento Combinar" />
                                                                    </ItemTemplate>
                                                            </asp:TemplateField>       
                                                            </Columns>
                                                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" Font-Bold="false" />
                                                            <EmptyDataTemplate>
                                                                No se hallaron resultados.</EmptyDataTemplate>
                                                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                            <RowStyle CssClass="gvItem" Font-Bold="false" />
                                                        </ma:XGridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: center;
                                width: 100%;">
                                <table>
                                    <tr>
                                        <td align="left">
                                            Detalle del Grupo de Email Seleccionado
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblEmpresaPersona1" Text="Descripción" runat="server" CssClass="labelBold" />
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hiddenId" runat="server" />
                                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="textboxEditor" Width="350px" />
                                                </td>
                                                <td>
                                                    <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                        font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                        border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: center;
                                                        width: 500px;">
                                                        <table>
                                                            <tr>
                                                                <td align="left">
                                                                    Contenido del Grupo de Email
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  align="left">
                                                                    <asp:RadioButtonList ID="chkOtrosFiltros" runat="server" Width="194px" 
                                                                        AutoPostBack="True" 
                                                                        RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="1">Codigo</asp:ListItem>
                                                                        <asp:ListItem Value="2">Relacion</asp:ListItem>
                                                                        <asp:ListItem Value="3">Email</asp:ListItem>
                                                                        <asp:ListItem Value="4">Cargo</asp:ListItem>
                                                                        <asp:ListItem Value="5">Empresa</asp:ListItem>
                                                                    </asp:RadioButtonList>                                                       
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  align="left">
                                                                    <asp:TextBox ID="txtFiltro" runat="server" CssClass="textboxEditor" 
                                                                        Width="350px"></asp:TextBox>
                                                                     <asp:Button ID="btnBuscar" runat="server" Text="Buscar " CssClass="buttonOver" 
                                                                        onclick="btnBuscar_Click" Width="95px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtNombre1" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                                                        Width="350px" ReadOnly="true" />
                                                                    <asp:HiddenField ID="txtNombre1Hidden" runat="server" />
                                                                    <ma:SecureButton ID="btnSearchNombre1_EditarGrupoEmail" runat="server" CausesValidation="True"
                                                                        CssClass="buttonOver" Height="20px" TabIndex="20" Text="Buscar..." ValidationGroup="datosGroup"
                                                                        Width="95px" OnClick="btnSearchNombre1_EditarGrupoEmail_Click" />
                                                                    <ma:SecureButton ID="btnAgregarRelacion" runat="server" CausesValidation="True" CssClass="buttonOver"
                                                                        Height="20px" TabIndex="20" Text="Agregar" ValidationGroup="datosGroup" Width="95px"
                                                                        OnClick="btnAgregarRelacion_Click" Visible="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                                                                            <td></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>                                                                              
                                                     </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <ma:SecureButton ID="btnAceptar" runat="server" CausesValidation="True" CssClass="buttonOver"
                                            Height="20px" TabIndex="20" Text="Guardar" ValidationGroup="datosGroup" Width="85px"
                                            OnClick="btnAceptar_Click" />
                                        <ma:SecureButton ID="btnEliminar" runat="server" CssClass="buttonOver" Height="20px"
                                            TabIndex="20" Text="Eliminar" Width="85px" OnClientClick="return ConfirmarOperacion();"
                                            OnClick="btnEliminar_Click" />
                                        <ma:SecureButton ID="btnBajaraExcel" runat="server" CssClass="buttonOver" Height="20px"
                                            TabIndex="20" Text="Bajar a Excel" Width="90px" OnClientClick="return ConfirmarOperacion();"
                                            OnClick="btnBajaraExcel_Click" />
                                        <ma:SecureButton ID="btnCerrarEditarGrupoEmail" runat="server" CssClass="buttonOver"
                                            Height="20px" OnClientClick="return CerrarPanelResultados_EditarCombinarGrupoEmail();"
                                            TabIndex="20" Text="Cerrar" Width="85px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>Combinar a</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   <asp:HiddenField ID="hiddenId1" runat="server" />
                                                   <asp:TextBox ID="txtDescripcion1" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                                    Width="350px" ReadOnly="true" />   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <ma:SecureButton ID="btnCombinarTodos" runat="server" CssClass="buttonOver" Height="20px" TabIndex="20" Text="Combinar Todos" Width="100px" OnClick="btnCombinarTodos_Click"/>
                                                            </td>                                                            
                                                        </tr>
                                                    </table>
                                                </td>                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                  <asp:HiddenField ID="hiddenCodigoRelacion" runat="server" value="0"/>
                                                                  <asp:Label ID="Label2" runat="server" Text="Contacto"></asp:Label>
                                                             </td>
                                                            <td>
                                                                <asp:TextBox ID="txtContacto" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text="Empresa"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmpresa" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>                                                       
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Cargo"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtCargo" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox></td>
                                                             <td>
                                                                <asp:HiddenField ID="hiddenCodigoEmail" runat="server" value="0"/>
                                                                <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                                                               </td>
                                                            <td>                                                               
                                                                <asp:TextBox ID="txtEmails" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox>                                                                
                                                            </td>
                                                        </tr>                                                   
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text="Campo 1"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtCampo1" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="Label7" runat="server" Text="Campo 2"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtCampo2" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox> 
                                                            </td>
                                                        </tr>                                                       
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="Campo 3"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtCampo3" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox> 
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="Observaciones"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtObservaciones" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox> 
                                                            </td>
                                                        </tr>                                                    
                                                        <tr>
                                                            <td><asp:Label ID="Label10" runat="server" Text="Campo4"></asp:Label></td>
                                                            <td><asp:TextBox ID="txtCampo4" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px"></asp:TextBox></td>                                                            
                                                            <td><asp:Label ID="Label11" runat="server" Text="SeleccionarEmail"></asp:Label></td>                                                          
                                                            <td>
                                                                <asp:CheckBox ID="chkSeleccionarEmail" runat="server" Width="30px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text="Seleccione Email"></asp:Label>  </td>             
                                                            <td>
                                                                <asp:DropDownList ID="ddlEmails" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="350px" Height="20px" >
                                                                </asp:DropDownList>
                                                            </td>                                                                                                          
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text="Ingrese Email"></asp:Label>
                                                            <td>
                                                                <asp:TextBox ID="txtNuevoEmail" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="310px"></asp:TextBox>
                                                                 <asp:Button ID="btnGuardarCambios" runat="server" Text="Agregar Email" CssClass="buttonOver" Height="20px"
                                                                        TabIndex="20" Width="100px" OnClick="btnGuardarNuevoEmail_Click"/>
                                                            </td>
                                                            </td>
                                                        </tr>                                                        
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td><asp:Button ID="btnAgregarContactoNuevo" runat="server" Text="Guardar Contacto Nuevo" CssClass="buttonOver" Height="20px"
                                                                        TabIndex="20" Width="150px" OnClick="btnContactoNuevo_Click"/></td>
                                                            <td>  
                                                                <asp:Button ID="btnActualizarContacto" runat="server" Text="Actualizar Contacto" CssClass="buttonOver" Height="20px"
                                                                        TabIndex="20" Width="120px" OnClick="btnActualizarContacto_Click"/>                                                        
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="buttonOver" Height="20px"
                                                                        TabIndex="20" Width="120px" OnClick="btnCancelar_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text="Email Desde"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmailDesde" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="310px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text="Asunto"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAsunto" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="310px"></asp:TextBox></td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label16" runat="server" Text="Desde"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtDesde" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="310px"></asp:TextBox></td>                                                          
                                                            <td><asp:Label ID="Label17" runat="server" Text="Mensaje"></asp:Label></td>
                                                            <td><asp:TextBox ID="txtCuerpo" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor" Width="310px"></asp:TextBox></td>
                                                        </tr>  
                                                        <tr>
                                                            <td>
                                                                <ma:SecureButton ID="btnEnviarCorreo" runat="server" CssClass="buttonOver" Height="20px" TabIndex="20" Text="Enviar Correo" Width="100px" OnClick="btnEnviarCorreo_Click"/>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" Text="Subir Imagen 4" Width="150px"></asp:Label></td>
                                                            <td>
                                                                &nbsp;</td>                                                        
                                                        </tr>                                                      
                                                    </table>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                
                            </table>                
                        </td>
                    </tr>
                    <tr align="left">
                            <td>
                                <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                    font-size: 12px; background-color: #FFFFFF; border-right: #cccccc 2px solid;
                                     border-bottom: #cccccc 1px inset; text-align: left; height: 60px; text-align: center;
                                        width: 100%;"></div>
                                <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                    font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                     border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: center;
                                        width: 100%;">
                                       <table>
                                        <tr>
                                            <td align="left">
                                                Detalle 
                                            </td>
                                        </tr>
                                       </table>
                                </div>
                                <table>
                                    <tr>
                                        <td>
                                                <asp:Panel ID="Panel1" runat="server" CssClass="scrollbar" Height="270px" ScrollBars="Auto"
                                                    Width="1000px">
                                                    <ma:XGridView ID="gvContenidoGrupoEmail" runat="server" AllowPaging="True" AllowSorting="True"
                                                        AutoGenerateColumns="False" BorderWidth="1px" DataKeyNames="idGrupoEmail" EmptyDataText="No se encontraron resultados"
                                                        ExecutePageIndexChanging="True" PageSize="400" Width="100%" OnFilling="gvContenidoGrupoEmail_Filling"
                                                        OnPageIndexChanging="gvContenidoGrupoEmail_PageIndexChanging" OnRowCommand="gvContenidoGrupoEmail_RowCommand"
                                                        OnSelectedIndexChanged="gvContenidoGrupoEmail_SelectedIndexChanged" 
                                                        RowStyle-BorderWidth="1px" >
                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEliminarRelacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                        CommandName="Eliminar" runat="server" Text="[x]" />
                                                                </ItemTemplate>                                                                                                                                                               
                                                                <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                            </asp:TemplateField>                                                                    
                                                            <asp:BoundField DataField="CodigoRelacion" HeaderText="Código" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="cargo" HeaderText="Cargo" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="nombreempresa" HeaderText="Empresa" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="nombrerelacion" HeaderText="Relacion" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>                                                       
                                                            <asp:BoundField DataField="email" HeaderText="Email" Visible="True">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>                                                                                                            
                                                            <asp:BoundField DataField="campo1" HeaderText="Campo A" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="campo2" HeaderText="Campo B" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                            <asp:BoundField DataField="campo3" HeaderText="Campo C" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                                <asp:BoundField DataField="campo4" HeaderText="Campo D" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Bold="True" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                            <ItemTemplate>
	                                                            <asp:LinkButton ID="lnkEditarRelacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
        	                                                            CommandName="Editar" runat="server" Text="[Edit]" />
                                                            </ItemTemplate>  
                                                             </asp:TemplateField>
                                                             <asp:TemplateField>
                                                            <ItemTemplate>
	                                                            <asp:LinkButton ID="lnkCombinarRelacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
        	                                                            CommandName="Combinar" runat="server" Text="[Combinar]" />
                                                            </ItemTemplate>   
                                                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" Font-Bold="false" />
                                                        <EmptyDataTemplate>
                                                            No se hallaron resultados.</EmptyDataTemplate>
                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                        <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="gvItem" Font-Bold="false" />
                                                    </ma:XGridView>
                                                </asp:Panel>
                                        </td>
                                    </tr>
                               </table>
                         </td>
                    </tr>                   
                </table>               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

