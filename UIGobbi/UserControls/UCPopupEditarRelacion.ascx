<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCPopupEditarRelacion.ascx.cs"
    Inherits="Vistas_UCPopupEditarRelacion" %>
<%@ Register TagPrefix="ma" Namespace="EvaWebControls" Assembly="EvaWebControls" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="~/UserControls/UCPopupBuscarRelacion.ascx" TagPrefix="myPopupDeDatos"
    TagName="BuscarRelacion" %>
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
var ModalProgress_EditarRelacion = '<%= ModalProgress_EditarRelacion.ClientID %>';   
var ModalPopupResultados_EditarRelacion = '<%= ModalPopupResultados_EditarRelacion.ClientID %>';   
                
                
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq_EditarRelacion);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq_EditarRelacion);
                

function abrirPopupEditarRelacion() {
   varModalPopupAbiertoEditarRelacion = ModalPopupResultados_EditarRelacion;

}

function beginReq_EditarRelacion(sender, args) 
{
	// shows the Popup 
	var controlCaller=args.get_postBackElement().id;
	//alert(controlCaller);
    if(controlCaller.indexOf('btnSearch')==-1){$find(ModalProgress_EditarRelacion).show()};        	 
}

/*
shortcut.add("Esc",function() {
try{
      CerrarPanelResultados_EditarRelacion();
      //var usr = document.getElementById('ctl00_Contentplaceholder1_TextBox1_EditarRelacion');
      //usr.value="";
   }
catch(er)
{}

} 
);*/

function endReq_EditarRelacion(sender, args)
{
    //  shows the Popup 
    $find(ModalProgress_EditarRelacion).hide();
} 

function CerrarPanelResultados_EditarRelacion()
{
  $find(ModalPopupResultados_EditarRelacion).hide();
  return false;
} 

function AbrirPanelCargos()
{ 
  var ModalPopupNuevaCargo = '<%= ModalPopupNuevaCargo.ClientID%>';
  $find(varModalPopupAbiertoEditarRelacion).hide();

  $find(ModalPopupNuevaCargo).show();
  
  //var varModalPopupAbiertoEditarRelacion;
  return false;
}

    function CerrarPanelNuevaCargo()
{
    var ModalPopupNuevaCargo = '<%= ModalPopupNuevaCargo.ClientID%>';
    $find(ModalPopupNuevaCargo).hide();
    $find(varModalPopupAbiertoEditarRelacion).show();

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
<asp:hiddenfield id="HiddenFieldNuevaCargo" runat="server" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevaCargo" runat="server" TargetControlID="HiddenFieldNuevaCargo"
    BackgroundCssClass="modalBackground" PopupControlID="panelNuevaCargo" />    
<ajaxToolkit:ModalPopupExtender ID="ModalProgress_EditarRelacion" runat="server"
    TargetControlID="panelUpdateProgress_EditarRelacion" BackgroundCssClass="modalBackground"
    PopupControlID="panelUpdateProgress_EditarRelacion" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupResultados_EditarRelacion" runat="server"
    TargetControlID="HiddenFieldResultados_EditarRelacion" BackgroundCssClass="modalBackground"
    PopupControlID="panelResultados_EditarRelacion" />
<myPopupDeDatos:BuscarRelacion ID="popupBuscarRelacionNombre1" runat="server" />
<myPopupDeDatos:BuscarRelacion ID="popupBuscarRelacionNombre2" runat="server" />
<asp:HiddenField ID="HiddenFieldResultados_EditarRelacion" runat="server" />
<asp:Panel ID="panelUpdateProgress_EditarRelacion" runat="server" CssClass="updateProgress">
    <asp:UpdateProgress ID="UpdateProg_EditarRelacion" DisplayAfter="0" runat="server">
        <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: center;">
                <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                Procesando...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Panel>
<asp:panel id="panelNuevaCargo" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelCargo" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblCargo_" runat="server" Text="  Cargo" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelCalif" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtCargo" runat="server" CssClass="textboxEditor" 
                                            MaxLength="50" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCargo" runat="server"
                                                                ControlToValidate="txtCargo" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarCargo"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarCargo_" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarCargo_Click" 
                                            ValidationGroup="datosAgregarCargo" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="btnCerrarNuevaCargo" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelNuevaCargo();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
<asp:Panel ID="panelResultados_EditarRelacion" runat="server" Height="310px" Width="480px">
    <asp:UpdatePanel ID="updatePanelResultados_EditarRelacion" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 12px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 35px; width: 470px;
                text-align: left; position: absolute; top: -81px;">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblTitulo" Text="Editar Relación" runat="server"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="font-family: Tahoma, Arial, MS Sans Serif; font-weight: bold; font-size: 10px;
                background-color: White; border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset;
                text-align: left; height: 350px; text-align: left; width: 470px; position: absolute;
                top: -61px; ">
                <table style="width: 470px;">
                    <tr align="left">
                        <td>
                            <asp:Label  ID="lblEmpresaPersona1" Text="Persona o Empresa #1" runat="server" CssClass="labelBold" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:TextBox ID="txtNombre1" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                MaxLength="40" Width="350px" ReadOnly="true" />
                             <asp:HiddenField ID="txtNombre1Hidden" runat="server" />    
                            <asp:Button runat="server" ID="btnSearchNombre1_EditarRelacion" OnClick="btnSearchNombre1_EditarRelacion_Click"
                                Text="Sel." Visible="false" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:Label ID="lblEmpresaPersona2"  Text="Persona o Empresa #2" runat="server" CssClass="labelBold" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:TextBox ID="txtNombre2" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                MaxLength="40" Width="350px" ReadOnly="true" />
                            <asp:HiddenField ID="txtNombre2Hidden" runat="server" />    
                            <asp:Button runat="server" ID="btnSearchNombre2_EditarRelacion" OnClick="btnSearchNombre2_EditarRelacion_Click"
                                Text="Sel." />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:Label ID="lblCargo" runat="server" CssClass="labelBold" Text="Cargo" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:DropDownList ID="cmbCargo" runat="server" AutoCompleteMode="SuggestAppend"
                                 BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="20px"
                                MaxLength="0" Selected="true" Width="305px">
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorCargoNuevo3" runat="server"
                                ControlToValidate="cmbCargo" ErrorMessage="* " ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnAgregarCargos_" runat="server" CausesValidation="False"
                                CssClass="buttonOver" OnClientClick="return AbrirPanelCargos();" Text="+"
                                Visible="true" />
                            &nbsp;<asp:Button ID="btnEliminarCargo" runat="server" CausesValidation="False" 
                                CssClass="buttonOver" OnClick="btnEliminarCargo_Click" OnClientClick="return ConfirmarOperacion();"
                                Text="-" Visible="true" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>                            
                        </td>                        
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:TextBox ID="txtTelefono" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                MaxLength="40" Width="350px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>                            
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                MaxLength="40" Width="350px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:Label ID="Label1" Text="Nota" runat="server" CssClass="labelBold" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:TextBox ID="txtRelacion" runat="server" AutoCompleteType="Disabled" CssClass="textArea" BackColor="White" Wrap="true" 
                                MaxLength="1000" Width="350px" TextMode="MultiLine" Columns="40" Rows="5" />                                
                        </td>
                    </tr>
                </table>
                <table style="width: 470px; height: 27px; margin-top: 0px;">
                        <tr>
                            <td>
                                <ma:SecureButton ID="btnAceptar" runat="server" CssClass="buttonOver"
                                    Height="20px" TabIndex="20" Text="Guardar" Width="95px"
                                    OnClick="btnAceptar_Click" />
                                <ma:SecureButton ID="btnEliminar" runat="server" CssClass="buttonOver" Height="20px"
                                    TabIndex="20" Text="Eliminar" Width="95px" 
                                    OnClientClick="return ConfirmarOperacion();" onclick="btnEliminar_Click" />
                                <ma:SecureButton ID="btnCerrarEditarRelacion" runat="server" 
                                    CssClass="buttonOver" Height="20px" 
                                    OnClientClick="return CerrarPanelResultados_EditarRelacion();" TabIndex="20" Text="Cerrar" 
                                    Width="95px" />
                            </td>
                        </tr>
                </table>                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
