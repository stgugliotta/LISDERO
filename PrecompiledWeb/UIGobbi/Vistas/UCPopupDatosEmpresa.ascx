<%@ control language="C#" autoeventwireup="true" inherits="Vistas_UCPopupDatosEmpresa, App_Web_j1kq45zw" %>
<%@ Register TagPrefix="ma" Namespace="EvaWebControls" Assembly="EvaWebControls" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<script type="text/javascript" language="javascript">
                var ModalPopupDatosEmpresaItem = '<%= ModalPopupDatosEmpresaItem.ClientID %>';   

function CerrarPanelDatosEmpresa()
{
  $find(ModalPopupDatosEmpresaItem).hide();
  return false;
} 

</script>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupDatosEmpresaItem" runat="server" TargetControlID="HiddenFieldDatosEmpresaItem"
    BackgroundCssClass="modalBackground" PopupControlID="panelDatosEmpresaItem" />
<asp:HiddenField ID="HiddenFieldDatosEmpresaItem" runat="server" />
<asp:Panel ID="panelDatosEmpresaItem" runat="server" Height="240px" Width="399px">
    <asp:UpdatePanel ID="updateDatosEmpresaItem" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                 font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                text-align: left;">
                <table>
                    <tr>
                        <td align="center" style="padding-left: 10px;">
                            <asp:Label ID="lblDatos_" runat="server" Text="  Detalle de la Empresa" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 410px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: center;">
                <asp:Panel ID="PanelProfe_" runat="server" Height="310px" Width="400px">
                    <table style="width: 100%; height: 380px;">
                        <tr class="gvAlternatingItem">
                            <td align="left">
                                <asp:Label ID="lblNombre" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Nombre: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNombreRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>
                        <tr class="gvItem">
                            <td align="left">
                                <asp:Label ID="lblCuit" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Cuit: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCuitRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr> 
                        <tr class="gvAlternatingItem">
                            <td align="left">
                                <asp:Label ID="lblWeb" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Web: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblWebRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>                                                 
                        <tr class="gvItem">
                            <td align="left">
                                <asp:Label ID="lblHorario" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Horario: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblHorarioRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>              
                        <tr class="gvAlternatingItem">
                            <td align="left">
                                <asp:Label ID="lblNotas" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Notas: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNotasRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>                                                                   
                        <tr class="gvItem">
                            <td align="left">
                                <asp:Label ID="lblDomicilio" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Domicilio/s: "> </asp:Label>
                            </td>
                            <td align="left">
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
                            <td align="left">
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
                            <td align="left">
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
                                <asp:Label ID="lblIVA" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="IVA: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblIVARes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>
                        <tr class="gvItem">
                            <td align="left">
                                <asp:Label ID="lblIIBB" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="IIBB: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblIIBBRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>
                        <tr class="gvAlternatingItem">
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Origen Contacto: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblOrigenContactoRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>
                        <tr class="gvItem">
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Vínculo: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblVinculoRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>
                        <tr class="gvAlternatingItem">
                            <td align="left">
                                <asp:Label ID="lblCalificacion" runat="server" Style="font-family: Verdana; font-size: 10px;
                                    font-weight: bold;" Text="Calificación: "> </asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCalificacionRes" runat="server" Style="font-family: Verdana; font-size: 10px;" Text=""> </asp:Label>
                            </td>
                        </tr>    
                        
                    </table>
                    <table style="width: 402px; height: 27px; margin-top: 0px;">
                        <tr>
                            <td style="background-color: #f2f2f2;" class="style7">
                            </td>
                            <td style="background-color: #f2f2f2;">
                                <ma:SecureButton ID="btnPopup" runat="server" CssClass="buttonOver" Height="20px"
                                    OnClientClick="return CerrarPanelDatosEmpresa();" TabIndex="20" Text="Cerrar" Width="95px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
