<%@ control language="C#" autoeventwireup="true" inherits="Vistas_UCPopupFiltrosABuscar, App_Web_a43a33gs" %>
<%@ Register TagPrefix="ma" Namespace="EvaWebControls" Assembly="EvaWebControls" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

<link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">
//    var ModalPopupOtrosContactosPersonas = '<%= ModalPopupOtrosContactosPersonas.ClientID %>';

//    function CerrarPanelDatos() {

//        $find(ModalPopupOtrosContactosPersonas).hide();
//            
//        return false;
//    }


    var ModalPopupOtrosContactosPersonas = '<%= ModalPopupOtrosContactosPersonas.ClientID %>';

    function CerrarPanelDatos() {

        var ModalPopupOtrosContactosPersonas = '<%= ModalPopupOtrosContactosPersonas.ClientID%>';
        alert($find(ModalPopupOtrosContactosPersonas));
        try {
            $find(ModalPopupOtrosContactosPersonas).hide();
            varModalPopupOtrosContactosPersonas = false;
        } catch (e) {
            alert(e);
        }          

        return false;
    }



</script>

<style type="text/css">
    .style2
    {
        width: 407px;
    }
    .style3
    {
        width: 606px;
    }
</style>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupOtrosContactosPersonas" runat="server" TargetControlID="HiddenFieldOtrosContactosPersonas"
    BackgroundCssClass="modalBackground" PopupControlID="panelDatosItem" />
<asp:HiddenField ID="HiddenFieldOtrosContactosPersonas" runat="server" />
<asp:hiddenfield id="HiddenPersonaSelected" runat="server" />
<asp:hiddenfield id="HiddenEmpresaSelected" runat="server" />
<asp:Panel ID="panelDatosItem" runat="server" Height="600" Width="1250px" ScrollBars="Vertical">
    <asp:UpdatePanel ID="updateDatosItem" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                 font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 1250px;
                text-align: left;">
                <table>
                    <tr>
                        <td align="center" style="padding-left: 10px;">
                            <asp:Label ID="lblDatos_" runat="server" Text="  Detalle de la Persona y Datos Laborales" />
                            <asp:Label ID="lblCodigoPersona" runat="server" Text="Label" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 750px; width: 1250px; background-color: #ffffff; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: center;">
                <asp:Panel ID="PanelProfe_" runat="server" Height="740px" Width="1250px">
                    <table>
                        <tr>
                            <td class="style3">
                                <table>
                                    <tr>
                                        <td>
                                             <asp:Panel ID="PanelDatosPersonales" runat="server" Height="380px" Width="390px">
                                                 <table style="width: 100%; height: 380px;">
                                        <tr class="gvAlternatingItem">
                                            <td align="left">
                                                <asp:Label ID="lblNombre" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Nombre: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblNombreRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gvItem">
                                            <td align="left">
                                                <asp:Label ID="lblDomicilio" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Domicilio/s: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                 <asp:Repeater id="repDomicilios" runat="server">
                                                    <HeaderTemplate>
                                                    <table border="0" width="50%" style="font-family: Verdana; font-size: 10px;">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                    <tr  style="font-family: Verdana; font-size: 10px;">
                                                        <td><%# Eval("Domicilio_")%></td>
                                                        <td><%# Eval("Cp")%></td>
                                                        <td><%# Eval("Ciudad")%></td>
                                                        <td><%# Eval("Provincia")%></td>
                                                        <td><%# Eval("Pais")%></td>
                                                    </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </table>
                                                    </FooterTemplate>
                                                 </asp:Repeater>   
                                            </td>
                                        </tr>
                                        <tr class="gvAlternatingItem">
                                            <td align="left">
                                                <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Teléfono/s: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                 <asp:Repeater id="repTelefonos" runat="server">
                                                    <HeaderTemplate>
                                                    <table border="0" width="50%">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("numero")%></td>
                                                    </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </table>
                                                    </FooterTemplate>
                                    
                                                 </asp:Repeater>   
                                            </td>
                                        </tr>
                                        <tr class="gvItem">
                                            <td align="left">
                                                <asp:Label ID="Label4" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Email/s: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                 <asp:Repeater id="repEmails" runat="server">
                                                    <HeaderTemplate>
                                                    <table border="0" width="50%">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("Emaill")%></td>
                                                    </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </table>
                                                    </FooterTemplate>
                                    
                                                 </asp:Repeater>   
                                            </td>
                                        </tr>                        
                                        <tr class="gvAlternatingItem">
                                            <td align="left">
                                                <asp:Label ID="Label1" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Origen Contacto: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblOrigenContactoRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gvItem">
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Vínculo: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblVinculoRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gvAlternatingItem">
                                            <td align="left">
                                                <asp:Label ID="Label5" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Profesión: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblProfesionRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gvItem">
                                            <td align="left">
                                                <asp:Label ID="Label6" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Documento: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblDocumentoRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="gvAlternatingItem">
                                            <td align="left">
                                                <asp:Label ID="lblCalificacion" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Calificación: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblCalificacionRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>    
                                        <tr class="gvItem">
                                            <td align="left">
                                                <asp:Label ID="lblTratamiento" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Tratamiento: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblTratamientoRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>                        
                                        <tr class="gvAlternatingItem">
                                            <td align="left">
                                                <asp:Label ID="Label7" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Cuit: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblCuitRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>  
                                        <tr class="gvItem">
                                            <td align="left">
                                                <asp:Label ID="lblNotas" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;" Text="Notas: "> </asp:Label>
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblNotasRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                            </td>
                                        </tr>                                                                                                                           
                                    </table>
                                             </asp:Panel>
                                        </td>
                                        <td>
                                             <asp:Panel ID="PanelDatosLaborales" runat="server" Height="380px" Width="390px">
                                                <table style="width: 100%; height: 380px;">                                               
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblNombreEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Nombre: "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNombreResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblCuitEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Cuit: "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblCuitEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr> 
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblWebEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Web: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblWebResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>                                                 
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblHorarioEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Horario: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblHorarioResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>              
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblNotasEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Notas: "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNotasEmpresa" runat="server" 
                                                            Style="font-family: Verdana; font-size: 10px;"></asp:Label>
                                                    </td>
                                                </tr>                                                                   
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblDomicilioEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Domicilio/s: "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                            <asp:Repeater id="repDomiciliosEmpresa" runat="server">
                                                            <HeaderTemplate>
                                                            <table border="0" width="50%" style="font-family: Verdana; font-size: 10px;">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                            <tr  style="font-family: Verdana; font-size: 10px;">
                                                                <td><%# Eval("Domicilio_")%></td>
                                                                <td><%# Eval("Cp")%></td>
                                                                <td><%# Eval("Ciudad")%></td>
                                                                <td><%# Eval("Provincia")%></td>
                                                                <td><%# Eval("Pais")%></td>
                                                            </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </table>
                                                            </FooterTemplate>
                                    
                                                            </asp:Repeater>   
                                                    </td>
                                                </tr>
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblTelefonoEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Teléfono/s: "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                            <asp:Repeater id="repTelefonosEmpresa" runat="server">
                                                            <HeaderTemplate>
                                                            <table border="0" width="50%">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                            <tr>
                                                                <td><%# Eval("numero")%></td>
                                                            </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </table>
                                                            </FooterTemplate>
                                    
                                                            </asp:Repeater>   
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblEmailEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Email/s: "></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                            <asp:Repeater id="repEmailsEmpresa" runat="server">
                                                            <HeaderTemplate>
                                                            <table border="0" width="50%">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                            <tr>
                                                                <td><%# Eval("Emaill")%></td>
                                                            </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </table>
                                                            </FooterTemplate>
                                    
                                                            </asp:Repeater>   
                                                    </td>
                                                </tr>                        
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblIVAEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="IVA: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblIVAResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblIIBBEmp" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="IIBB: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblIIBBResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblOrigenContactoEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Origen Contacto: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblOrigenContactoResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblVinculoEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Vínculo: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblVinculoResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="gvAlternatingItem">
                                                    <td align="left">
                                                        <asp:Label ID="lblCalificacionEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                            font-weight: bold;" Text="Calificación: "> </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblCalificacionResEmpresa" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>                                     
                                            </asp:Panel>    
                                        </td>
                                        <td>
                                            <asp:Panel ID="PanelCargoqueOcupa" runat="server" Height="380px" Width="310px">
                                                <table  style="width: 100%; height: 300px;">                                                
                                                <tr class="gvAlternatingItem">
                                                    <td  align="left"  runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;">
                                                        <asp:Label ID="lblCargo" runat="server" CssClass="labelBold" Text="Cargo" />
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td  align="left" >
                                                        <asp:DropDownList ID="cmbCargo" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                            DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="20px"
                                                            MaxLength="0" Selected="true" Width="305px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorCargoNuevo3" runat="server"
                                                            ControlToValidate="cmbCargo" ErrorMessage="* " ValidationGroup="datosGroup"></asp:RequiredFieldValidator>                                               
                                              
                                                    </td>
                                                </tr>
                                                <tr class="gvAlternatingItem">
                                                    <td  align="left" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;">
                                                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>                            
                                                    </td>                        
                                                </tr>
                                                <tr class="gvItem">
                                                    <td>
                                                        <asp:TextBox ID="txtTelefono" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                                            MaxLength="40" Width="350px" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="gvAlternatingItem" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;">
                                                    <td  align="left">
                                                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>                            
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td  align="left">
                                                        <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                                            MaxLength="40" Width="350px" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="gvAlternatingItem" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                    font-weight: bold;">
                                                    <td  align="left">
                                                        <asp:Label ID="Label23" Text="Nota" runat="server" CssClass="labelBold" />
                                                    </td>
                                                </tr>
                                                <tr class="gvItem">
                                                    <td align="left">
                                                        <asp:TextBox ID="txtRelacion" runat="server" AutoCompleteType="Disabled" CssClass="textArea" BackColor="White" Wrap="true" 
                                                            MaxLength="1000" Width="350px" TextMode="MultiLine" Columns="40" Rows="5" />                                
                                                    </td>
                                                </tr>
                                                </table>
                                            </asp:Panel>                                            
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
                                            <asp:Panel ID="PanelEmpresas" runat="server"  Height="300px" Width="600px">                               
                                            <table>
                                                <tr>
                                                    <td>
                                                          <ma:XGridView ID="gvResultadoEmpresa" runat="server" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BorderWidth="1px" EmptyDataText="No se encontraron resultados"
                                                                        ExecutePageIndexChanging="True"                                                 
                                                                        OnRowDataBound="gvResultadoEmpresa_RowDataBound"
                                                                        OnFilling="gvResultadoEmpresa_Filling" 
                                                                        OnRowCommand="gvResultadoEmpresa_RowCommand"
                                                                        Width="600px" ShowHeader="false" RowStyle-CssClass="gvItem" AlternatingRowStyle-CssClass="gvAlternatingItem"
                                                                        RowStyle-BorderWidth="1px" >
                                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                        <Columns>                                                                            
                                                                            <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnContactoEmpresa"  
                                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                                    CommandName="DatosPersonales" runat="server" Text="View More" ImageUrl="~/Images/persona.gif"/>
                                                                            </ItemTemplate>                                                                            
                                                                                    <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                                    <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                        Width="53px" />                                                                            
                                                                            </asp:TemplateField>                                                                
                                                                             <asp:BoundField DataField="Nombre" ShowHeader="False" Visible="True">
                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                    BorderWidth="0px" />
                                                                                <ItemStyle BackColor="#FFCCCC" BorderColor="White" BorderStyle="None" 
                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                            </asp:BoundField>   
                                                                             <asp:BoundField DataField="Codigo" ShowHeader="False" Visible="True">
                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                    BorderWidth="0px" />
                                                                                <ItemStyle BackColor="#FFCCCC" BorderColor="White" BorderStyle="None" 
                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                            </asp:BoundField>                                                                             
                                                                            <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnRelacionEmpresa"  
                                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>
                                                                                " CommandName="Relaciones" runat="server" Text="View More" ImageUrl="~/Images/red2.png"/>
                                                                            </ItemTemplate>
                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                                <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                            </asp:TemplateField>                                                                           
                                                                        </Columns>                                                                        
                                                                        <SelectedRowStyle BackColor="#99CCFF" />
                                                                        <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                        <EmptyDataTemplate>
                                                                            No se hallaron resultados.</EmptyDataTemplate>
                                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />                                                                        
                                                                        <HeaderStyle BorderStyle="None" BackColor="White" />
                                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                        <RowStyle CssClass="gvItem" />
                                                                    </ma:XGridView>
                                                    </td>                                              
                                                </tr>
                                            </table>  
                                         </asp:Panel>
                                        </td>
                                        <td>
                                             <asp:Panel ID="PanelDatosOtrosContactos" runat="server"  Height="300px" Width="600px">
                                                    <table>
                                                               <tr>
                                                                  <td>
                                                                     <ma:XGridView ID="gvResultadoPersona" runat="server" AllowSorting="True"
                                                                                        AutoGenerateColumns="False" BorderWidth="1px" EmptyDataText="No se encontraron resultados"
                                                                                        ExecutePageIndexChanging="True"                                                                          
                                                                                        Width="600px" ShowHeader="false" RowStyle-CssClass="gvItem" AlternatingRowStyle-CssClass="gvAlternatingItem"
                                                                                        RowStyle-BorderWidth="1px">
                                                                                        <Columns>                                                                        
                                                                                        <asp:TemplateField>  
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="btnContactoEmpresa"  
                                                                                                     CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                                                    CommandName="DatosPersonales" runat="server" Text="View More" ImageUrl="~/Images/persona.gif"/>
                                                                                            </ItemTemplate>                                                                                                                                                                                                                                                                                                    
                                                                                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                                Width="53px" />                                                                            
                                                                                            </asp:TemplateField>                                                                           
                                                                                            <asp:BoundField DataField="Nombre" ShowHeader="False" Visible="True">
                                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                                    BorderWidth="0px" />
                                                                                                <ItemStyle BackColor="#FFFF99" BorderColor="White" BorderStyle="None" 
                                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Cargo" ShowHeader="False" Visible="True">
                                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                                    BorderWidth="0px" />
                                                                                                <ItemStyle BackColor="#FFFF99" BorderColor="White" BorderStyle="None" 
                                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                                            </asp:BoundField>                                                                       
                                                                                            <asp:BoundField DataField="Telefono" ShowHeader="False" Visible="True">
                                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                                    BorderWidth="0px" />
                                                                                                <ItemStyle BackColor="#FFFF99" BorderColor="White" BorderStyle="None" 
                                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Email" ShowHeader="False" Visible="True">
                                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                                    BorderWidth="0px" />
                                                                                                <ItemStyle BackColor="#FFFF99" BorderColor="White" BorderStyle="None" 
                                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                                            </asp:BoundField>     
                                                                                          <asp:TemplateField>       
                                                                                              <ItemTemplate>
                                                                                                <asp:ImageButton ID="btnRelacionEmpresa"  
                                                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>
                                                                                                " CommandName="Relaciones" runat="server" Text="View More" ImageUrl="~/Images/red2.png"/>
                                                                                              </ItemTemplate>                                                                    
                                                                                              <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                                              <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                                            </asp:TemplateField>                                                                            
                                                                                         <asp:CommandField ShowSelectButton="true" ButtonType="Link" Visible="false" SelectText="Enroll" />                                                                         
                                                                                        </Columns>                                                                        
                                                                                        <SelectedRowStyle  BackColor="#99CCFF" />
                                                                                        <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                                        <EmptyDataTemplate>
                                                                                            No se hallaron resultados.</EmptyDataTemplate>
                                                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />                                                                        
                                                                                        <RowStyle CssClass="gvItem" />
                                                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                                        <HeaderStyle BorderStyle="None" BackColor="White" />
                                                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                                    </ma:XGridView>
                                                                  </td>
                                                               </tr>
                                                         </table>   
                                                </asp:Panel>                                    
                                        </td>
                                    </tr>
                                </table>
                            </td>
                         </tr>
                         <tr>
                            <td>  
                                <asp:Panel ID="Panel1" runat="server" Height="30px" Width="1200px">                                       
                                 <table style="width: 402px; height: 27px; margin-top: 0px;">
                                    <tr>
                                        <td style="background-color: #f2f2f2;" class="style7">
                                        </td>
                                        <td style="background-color: #f2f2f2;">
                                            <ma:SecureButton ID="btnPopup" runat="server" CssClass="buttonOver" Height="20px"
                                                OnClientClick="return CerrarPanelDatos();" TabIndex="20" Text="Cerrar" Width="95px" />
                                        </td>
                                    </tr>
                                </table>  
                               </asp:Panel>             
                            </td>                          
                        </tr>
                    </table>                                            
                </asp:Panel>               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

