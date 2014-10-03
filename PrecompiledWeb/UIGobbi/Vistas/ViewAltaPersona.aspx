<%@ page language="C#" masterpagefile="~/MasterPage.master" theme="SampleSiteTheme" enableeventvalidation="false" autoeventwireup="true" inherits="Vistas_ViewAltaPersona, App_Web_j1kq45zw" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />
    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>
    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>
    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>
    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>
    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>
    <script type="text/javascript">
<!--
        $(document).ready(function () {
            var options = { minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function (e, menuItem) {
                //openMenu(



                document.location = 'http://localhost/vistas/ViewImportacionDeFacturas.aspx';



                //);
                //alert('you clicked item "' + $(this).text() + e  + '"');
            } 
            };
        });
-->
 
    </script>
    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';
        
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);



        function beginReq(sender, args) {
            // shows the Popup 
            var controlCaller = args.get_postBackElement().id;
            //alert(controlCaller);
            if (controlCaller.indexOf('btnSearch') == -1) { $find(ModalProgress).show() };


        }


        shortcut.add("Esc", function () {

            try {
                CerrarPanelResultados();
                var usr = document.getElementById('ctl00_Contentplaceholder1_TextBox1');
                usr.value = "";
            }
            catch (er)
{ }
        }



      );


        function ReducirTamanioDiv() {

            try {
                var div = document.getElementById('ctl00_Contentplaceholder1_ctl03');

                div.setAttribute('style', 'BORDER-RIGHT: #cccccc 2px solid; WIDTH: 800px; BORDER-BOTTOM: #cccccc 1px inset; HEIGHT: 300px; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: center');

            }
            catch (er) {

            }
            return true;
        }

        function endReq(sender, args) {
            //  shows the Popup 
            $find(ModalProgress).hide();
        }


        function RecoveryFilters() {
            var url = 'http://' + document.location.host + '/Vistas/ViewGestionDeDeudores.aspx?restoreFilters=true';
            document.location = url;
        }

    </script>
    <script type="text/javascript">
        function ValidarMails(obj) {
            //var ExprReg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3,4})+$/;
            // var ExpReg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/
            // var ExpReg = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            //var regEx =  /^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$/;

            //var regEx = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            var pattern = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var txtEmail = obj.value;

            if (txtEmail == '' || txtEmail == null) {

                return true;
            }

            var aEmails = txtEmail.split(';');
            for (var i = 0; i < aEmails.length; i++) {
                // bug fix para que se valide solo el mail y no espacios que puedan haber adelante y atras
                if (!pattern.test(jQuery.trim(aEmails[i]))) {
                    return false;
                }
            }

            return true;
        }
    </script>
    <script type="text/javascript">
        var to; // variable to which we assign setTimeout function
        var prm = Sys.WebForms.PageRequestManager.getInstance(); // Page Request Manager object
        function onTxtKeyUp() {
            to = setTimeout('performSearch();', 200);
        }
        function onTxtKeyDown() {
            if (to) clearTimeout(to);
        }
        function performSearch() {
            if (prm.get_isInAsyncPostBack) {
                prm.abortPostBack();

            }

            __doPostBack("<%=btnSearch.UniqueID %>", "");
        }
    </script>
    <script type="text/javascript">

        var varModalPopupAbierto;


        function CPcuitValido(cuit) {
            var vec = new Array(10);
            esCuit = false;
            cuit_rearmado = string.Empty;
            errors = ''
            for (i = 0; i < cuit.length; i++) {
                caracter = cuit.charAt(i);
                if (caracter.charCodeAt(0) >= 48 && caracter.charCodeAt(0) <= 57) {
                    cuit_rearmado += caracter;
                }
            }
            cuit = cuit_rearmado;
            if (cuit.length != 11) {  // si to estan todos los digitos
                esCuit = false;
                errors = 'Cuit <11 ';
                alert("CUIT Menor a 11 Caracteres");
                return false;
            } else {
                x = i = dv = 0;
                // Multiplico los dígitos.
                vec[0] = cuit.charAt(0) * 5;
                vec[1] = cuit.charAt(1) * 4;
                vec[2] = cuit.charAt(2) * 3;
                vec[3] = cuit.charAt(3) * 2;
                vec[4] = cuit.charAt(4) * 7;
                vec[5] = cuit.charAt(5) * 6;
                vec[6] = cuit.charAt(6) * 5;
                vec[7] = cuit.charAt(7) * 4;
                vec[8] = cuit.charAt(8) * 3;
                vec[9] = cuit.charAt(9) * 2;

                // Suma cada uno de los resultado.
                for (i = 0; i <= 9; i++) {
                    x += vec[i];
                }
                dv = (11 - (x % 11)) % 11;
                if (dv == cuit.charAt(10)) {
                    esCuit = true;
                }
            }
            if (!esCuit) {
                alert("CUIT Inválido");
                return false;
            }
            //return esCuit ;
        }


        function AbrirPanelBusqueda() {

            var ModalPopupBusqueda = '<%= ModalPopupDetalleControlConcurrencia.ClientID%>';
            $find(ModalPopupBusqueda).show();

            return false;
        }

        function AbrirPanelNuevaProvincia() {

            var ModalPopupNuevaProvincia = '<%= ModalPopupNuevaProvincia.ClientID%>';
            $find(varModalPopupAbierto).hide();
            $find(ModalPopupNuevaProvincia).show();
        }

        function AbrirPanelPaises() {

            var ModalPopupNuevoPais = '<%= ModalPopupNuevoPais.ClientID%>';
            $find(varModalPopupAbierto).hide();
            $find(ModalPopupNuevoPais).show();
        }

        function AbrirPanelNuevaCiudad() {

            var ModalPopupNuevaCiudad = '<%= ModalPopupNuevaCiudad.ClientID%>';
            $find(varModalPopupAbierto).hide();
            $find(ModalPopupNuevaCiudad).show();
        }

        function AbrirPanelNuevaProfesion() {

            var ModalPopupNuevaProfesion = '<%= ModalPopupNuevaProfesion.ClientID%>';
            $find(ModalPopupNuevaProfesion).show();
            return false;
        }

        function AbrirPanelTelefonos() {

            var ModalPopupTelefono = '<%= ModalPopupTelefono.ClientID%>';
            $find(ModalPopupTelefono).show();

            return false;
        }

        function AbrirPanelDomicilios() {

            var ModalPopupDomicilios = '<%= ModalPopupDomicilios.ClientID%>';
            $find(ModalPopupDomicilios).show();
            varModalPopupAbierto = ModalPopupDomicilios;

            return false;
        }

        function AbrirPanelEmails() {

            var ModalPopupEmails = '<%= ModalPopupEmails.ClientID%>';
            $find(ModalPopupEmails).show();

            return false;
        }

        function AbrirPanelTratamientos() {

            var ModalPopupNuevoTratamiento = '<%= ModalPopupNuevoTratamiento.ClientID%>';
            $find(ModalPopupNuevoTratamiento).show();

            return false;
        }

        function AbrirPanelCalificaciones() {

            var ModalPopupNuevaCalificacion = '<%= ModalPopupNuevaCalificacion.ClientID%>';
            $find(ModalPopupNuevaCalificacion).show();

            return false;
        }

        function AbrirPanelResultados() {

            var ModalPopupResultados = '<%= ModalPopupResultados.ClientID%>';
            $find(ModalPopupResultados).show();

            return false;
        }

        function CerrarPanelEmails() {

            var ModalPopupEmails = '<%= ModalPopupEmails.ClientID%>';
            $find(ModalPopupEmails).hide();

            return false;
        }

        function CerrarPanelBusqueda() {
            var ModalPopupDetalleControlConcurrencia = '<%= ModalPopupDetalleControlConcurrencia.ClientID%>';
            $find(ModalPopupDetalleControlConcurrencia).hide();

            return false;
        }

        function CerrarPanelDomicilios() {
            var ModalPopupDomicilios = '<%= ModalPopupDomicilios.ClientID%>';
            $find(ModalPopupDomicilios).hide();

            return false;
        }

        function CerrarPanelTelefonos() {
            var ModalPopupTelefono = '<%= ModalPopupTelefono.ClientID%>';
            $find(ModalPopupTelefono).hide();

            return false;
        }

        function CerrarPanelNuevaProvincia() {
            var ModalPopupNuevaProvincia = '<%= ModalPopupNuevaProvincia.ClientID%>';
            $find(ModalPopupNuevaProvincia).hide();
            $find(varModalPopupAbierto).show();
        }

        function CerrarPanelNuevoPais() {
            var ModalPopupNuevoPais = '<%= ModalPopupNuevoPais.ClientID%>';
            $find(ModalPopupNuevoPais).hide();
            $find(varModalPopupAbierto).show();
        }

        function CerrarPanelNuevaCiudad() {
            var ModalPopupNuevaCiudad = '<%= ModalPopupNuevaCiudad.ClientID%>';
            $find(ModalPopupNuevaCiudad).hide();
            $find(varModalPopupAbierto).show();
        }

        function CerrarPanelNuevaProfesion() {
            var ModalPopupNuevaProfesion = '<%= ModalPopupNuevaProfesion.ClientID%>';
            $find(ModalPopupNuevaProfesion).hide();
            return false;
        }

        function CerrarPanelNuevoTratamiento() {
            var ModalPopupNuevoTratamiento = '<%= ModalPopupNuevoTratamiento.ClientID%>';
            $find(ModalPopupNuevoTratamiento).hide();
            return false;
        }

        function CerrarPanelResultados() {
            var ModalPopupResultados = '<%= ModalPopupResultados.ClientID%>';
            $find(ModalPopupResultados).hide();
            return false;
        }

        function CerrarPanelNuevaCalificacion() {
            var ModalPopupNuevaCalificacion = '<%= ModalPopupNuevaCalificacion.ClientID%>';
            $find(ModalPopupNuevaCalificacion).hide();
            return false;
        }

        function ConfirmarOperacion() {
            if (confirm('¿Desea realizar esta operación?')) {
                return true;
            }
            return false;

        }

        function establerCursorPosicion(pos) {


            var elemento = document.getElementById('ctl00_Contentplaceholder1_TextBox1');
            if (typeof document.selection != 'undefined' && document.selection) {        //método IE
                var tex = elemento.value;
                elemento.value = '';
                elemento.focus();
                var str = document.selection.createRange();
                elemento.value = tex;
                str.move("character", pos);
                str.moveEnd("character", 0);
                str.select();
                elemento.focus();
            }
            else if (typeof elemento.selectionStart != 'undefined') {                    //método estándar
                elemento.setSelectionRange(pos, pos);
                elemento.focus();
            }
        } 
        
    </script>
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">

     
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center;">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupDetalleControlConcurrencia" runat="server"
        TargetControlID="HiddenFieldRemisionesAbiertas" BackgroundCssClass="modalBackground"
        PopupControlID="panelRemisionesAbiertas" />
    <asp:hiddenfield id="HiddenFieldRemisionesAbiertas" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupTelefono" runat="server" TargetControlID="HiddenFieldTelefono"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevoTelefono" />
    <asp:hiddenfield id="HiddenFieldTelefono" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupDomicilios" runat="server" TargetControlID="HiddenFieldDomicilio"
        BackgroundCssClass="modalBackground" PopupControlID="panelDomicilios" />
    <asp:hiddenfield id="HiddenFieldDomicilio" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupEmails" runat="server" TargetControlID="HiddenFieldEmail"
        BackgroundCssClass="modalBackground" PopupControlID="panelEmails" />
    <asp:hiddenfield id="HiddenFieldEmail" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevaProvincia" runat="server" TargetControlID="HiddenFieldNuevaProvincia"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevaProvincia" />
    <asp:hiddenfield id="HiddenFieldNuevaProvincia" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevoPais" runat="server" TargetControlID="HiddenFieldNuevoPais"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevoPais" />
    <asp:hiddenfield id="HiddenFieldNuevoPais" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevaCiudad" runat="server" TargetControlID="HiddenFieldNuevaCiudad"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevaCiudad" />
    <asp:hiddenfield id="HiddenFieldNuevaCiudad" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevoTratamiento" runat="server" TargetControlID="HiddenFieldNuevaCiudad"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevoTratamiento" />
    <asp:hiddenfield id="HiddenFieldNuevoTratamiento" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevaCalificacion" runat="server" TargetControlID="HiddenFieldNuevaCalificacion"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevaCalificacion" />
    <asp:hiddenfield id="HiddenFieldNuevaCalificacion" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevaProfesion" runat="server" TargetControlID="HiddenFieldNuevaProfesion"
        BackgroundCssClass="modalBackground" PopupControlID="panelNuevaProfesion" />
    <asp:hiddenfield id="HiddenFieldNuevaProfesion" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupResultados" runat="server" TargetControlID="HiddenFieldNuevaProfesion"
        BackgroundCssClass="modalBackground" PopupControlID="panelResultados" />
    <asp:hiddenfield id="HiddenFieldResultados" runat="server" />
    <asp:panel id="panelRemisionesAbiertas" runat="server">
        <asp:UpdatePanel ID="updatePanelRemisionesAbiertas" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="Label5" runat="server" Text="  Búsqueda" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 320px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="Panel4" runat="server"  Height="300px" Width="400px">
                       
                        <asp:Panel ID="pnlBusquedaDePersona" runat="server" Width="378px">
                        <table style="width: 389px">
                               <tr style="background-color:#f2f2f2; border:1px solid #ccc; width:100%; height:40px;" align="left">
                                  <td class="style5" >
                                    <asp:TextBox ID="txtPersona" runat="server" CssClass="textboxEditor" 
                                          MaxLength="20" Width="237px" 
                                          onChange="txtPersona_TextChanged" AutoPostBack="True" 
                                          ></asp:TextBox>
                                     
                                      <br />
                                      <br />
                                      <br />
                                  
</td>
                                  <td>
                                   <ma:SecureButton ID="btnCerrar0" runat="server" CausesValidation="True" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return AbrirPanelBusqueda();" TabIndex="20" Text="Buscar" 
                                          ValidationGroup="datosGroup" Width="95px" />
                                  </td>
                               </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlResultados" runat="server" CssClass="buttonOver">
                                <%--   <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" 
                                                             AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                             DataKeyNames="id" EmptyDataText="No se encontraron resultados" 
                                                             ExecutePageIndexChanging="True" OnFilling="GvResultados_Filling" 
                                                             OnPageIndexChanging="GvResultados_PageIndexChanging" 
                                                             OnRowDataBound="GvResultados_RowDataBound" 
                                       PageSize="5" Width="329px" 
                                                             onrowediting="GvResultados_RowEditing" OnRowDeleting="GvResultados_RowDeleting" 
                                                             OnRowCommand="GvResultados_RowCommand"  
                                                               ShowFooter="True">
                                                              <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                              <Columns>
                                                                 <asp:CommandField  ButtonType="Image"                                                                                                        
                                                                  EditImageUrl="~/Images/editar.gif"
                                                                  ShowEditButton="True" 
                                                                  HeaderText="Editar" ><HeaderStyle Font-Bold="True" /><itemstyle width="5%"  HorizontalAlign="Center"  /></asp:CommandField><asp:TemplateField HeaderText="Eliminar"><ItemTemplate><asp:ImageButton    OnClientClick ="return confirm('¿Esta seguro que desea eliminar el registro?');" Visible="true" ID="btnDelete" runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete"  /></ItemTemplate><HeaderStyle Font-Bold="True" /></asp:TemplateField>
                                                                                                          
                                                                     
                                                                     <asp:BoundField DataField="nombre" HeaderText="Nombre" 
                                                                     SortExpression="nombre"  ></asp:BoundField>
                                                                     
                                                                     
                                                                     </Columns><EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" /><EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate><FooterStyle CssClass="gvHeader grayGvHeader" /><HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" /><PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                     <RowStyle CssClass="gvItem" /></ma:XGridView>--%>
                                                                     </asp:Panel>
                        <table style="width: 395px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2; border:1px solid #ccc; width:100%; height:40px;">
                                     
                                      <ma:SecureButton ID="btnCerrar" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelBusqueda();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" UseSubmitBehavior="False" />
                                     
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevaProvincia" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelProvincia" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblProvincia_" runat="server" Text="  Provincia" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelProv" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtProvincia" runat="server" CssClass="textboxEditor" 
                                            MaxLength="40" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvincia" runat="server"
                                                                ControlToValidate="txtProvincia" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarProvincia"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarProvincia_" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarProvincia_Click" 
                                            ValidationGroup="datosAgregarProvincia" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="btnCerrarPanelProvincia" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelNuevaProvincia();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevoTelefono" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelTelefono" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblTelefono_" runat="server" Text="  Telefono" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelTele" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="textboxEditor" 
                                            MaxLength="30" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono_" runat="server"
                                                                ControlToValidate="txtTelefono" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarTelefono"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarTelefono_" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarTelefono_Click" 
                                            ValidationGroup="datosAgregarTelefono" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="SecureButton3" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelTelefonos();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelResultados" runat="server" height="101px" width="396px">
        <asp:UpdatePanel ID="updatePanelResultados" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left; position:absolute; top:-61px;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblResultados_" runat="server" Text="  Personas" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: auto; width: 400px; background-color: #ffffff; border-bottom: #cccccc 1px inset; text-align: center; position:absolute; top:-32px;" 
                    CssClass="scrollbar"  >
                 
                   <%-- <asp:Panel ID="PanelRes" runat="server"  Height="138px" Width="400px"
                       CssClass="scrollbar">--%>
                           

                        <table style="width: 399px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;">
                                  <asp:Panel ID="pnlGvResultados" runat="server" Height="300px" ScrollBars="Vertical" 
                                          CssClass="scrollbar" Width="390px" >
                                                                    <ma:XGridView ID="gvResultadosBusqueda" runat="server" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="Id" EmptyDataText="No se encontraron resultados"
                                                                        ExecutePageIndexChanging="True" OnFilling="GvResultadosBusqueda_Filling" OnPageIndexChanging="GvResultadosBusqueda_PageIndexChanging"
                                                                        OnRowDataBound="GvResultadosBusqueda_RowDataBound" OnRowEditing="GvResultadosBusqueda_RowEditing"
                                                                        OnRowDeleting="GvResultadosBusqueda_RowDeleting" OnRowCommand="GvResultadosBusqueda_RowCommand"
                                                                        OnSelectedIndexChanged="GvResultadosBusqueda_SelectedIndexChanged"
                                                                         Width="367px" >
                                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                        <Columns>
                                                                         
                                                                                   
                                                                         
                                                                                                                                                         
                                                                                 <asp:CommandField  ButtonType="Image"                                                                                                        
                                                                                                          EditImageUrl="~/Images/persona.gif" 
                                                                                                         ShowEditButton="True" 
                                                                                                          ><HeaderStyle Font-Bold="True" BackColor="White" 
                                                                                         BorderColor="White" BorderStyle="None" /><itemstyle width="5%"  
                                                                                         HorizontalAlign="Left" BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                         BorderWidth="3px"  /></asp:CommandField>
                                                                         
                                                                                   
                                                                         
                                                                            <asp:BoundField DataField="NombreYCodigo" Visible="True" ShowHeader="False">
                                                                                
                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                    BorderWidth="0px" />
                                                                                
                                                                                <ItemStyle BackColor="White" HorizontalAlign="Left" BorderColor="White" 
                                                                                    BorderStyle="None"   />
                                                                            </asp:BoundField>
                                                                           
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
                                                                    </asp:Panel>
                                  </td>
                                 
                              </tr>
                        </table>
                        <%--</asp:Panel>--%>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevoTratamiento" runat="server" height="101px" width="399px">
    <asp:UpdatePanel ID="updatePanelTratamiento" runat="server"  UpdateMode="Always" >
        <ContentTemplate>
            <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                text-align: left;">
                <table>
                    <tr>
                        <td align="center" style="padding-left:10px;">
                            <asp:Label ID="lblTratamiento_" runat="server" Text="  Tratamiento" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: center;">
                 
                <asp:Panel ID="PanelTrat" runat="server"  Height="75px" Width="400px"
                    >
                    <table style="width: 100%; height: 46px;">
                           
                            <tr >
                                <td class="style7">
                                    <asp:TextBox ID="txtTratamiento" runat="server" CssClass="textboxEditor" 
                                        MaxLength="50" Width="237px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTratamiento" runat="server"
                                                            ControlToValidate="txtTratamiento" ErrorMessage="* " 
                                                            ValidationGroup="datosAgregarTratamiento"></asp:RequiredFieldValidator>
                                       
                                </td>
                                <td>
                                    <ma:SecureButton ID="btnAgregarTratamiento_" runat="server" 
                                        CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                        Width="95px" CausesValidation="True" onclick="btnAgregarTratamiento_Click" 
                                        ValidationGroup="datosAgregarTratamiento" />
                                </td>
                            </tr>
                         
                    </table>
                      

                    <table style="width: 402px; height: 27px; margin-top: 0px;">
                            <tr>
                                <td style="background-color:#f2f2f2;" class="style7">
                                  
                                </td>
                                <td style="background-color:#f2f2f2;">
                                    <ma:SecureButton ID="btnCerrarNuevoTratamiento" runat="server" 
                                        CssClass="buttonOver" Height="20px" 
                                        OnClientClick="return CerrarPanelNuevoTratamiento();" TabIndex="20" Text="Cerrar" 
                                        Width="95px" />
                                </td>
                            </tr>
                    </table>
                    </asp:Panel>
                       
            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevaCalificacion" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelCalificacion" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblCalificacion_" runat="server" Text="  Calificacion" />
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
                                        <asp:TextBox ID="txtCalificacion" runat="server" CssClass="textboxEditor" 
                                            MaxLength="50" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCalificacion" runat="server"
                                                                ControlToValidate="txtCalificacion" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarCalificacion"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarCalificacion_" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarCalificacion_Click" 
                                            ValidationGroup="datosAgregarCalificacion" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="btnCerrarNuevaCalificacion" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelNuevaCalificacion();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevaCiudad" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelCiudad" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblCiudad_" runat="server" Text="  Ciudad" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelCiud" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtCiudad" runat="server" CssClass="textboxEditor" 
                                            MaxLength="50" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCiudad" runat="server"
                                                                ControlToValidate="txtCiudad" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarCiudad"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarCiudad_" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarCiudad_Click" 
                                            ValidationGroup="datosAgregarCiudad" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="btnCerrarNuevaCiudad" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelNuevaCiudad();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevaProfesion" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelProfesion" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblProfesion_" runat="server" Text="  Profesion" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelProfe" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtProfesion" runat="server" CssClass="textboxEditor" 
                                            MaxLength="50" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProfesion" runat="server"
                                                                ControlToValidate="txtProfesion" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarProfesion"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarProfesion" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarProfesion_Click" 
                                            ValidationGroup="datosAgregarProfesion" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="btnCerrarProfesion" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelNuevaProfesion();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelDomicilios" runat="server">
        <asp:UpdatePanel ID="updatePanelDomicilios" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblDomicilios" runat="server" Text="  Domicilios" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 258px; width: 398px; background-color: #ffffff; border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelDomi" runat="server"  Height="256px" Width="400px"
                       >
                       
                        <asp:Panel ID="pnlBusquedaDomicilio" runat="server" Width="378px">
                        <table style="width: 393px">
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblPais" runat="server" CssClass="labelBold" Text="País:" />
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cmbPais" runat="server" AutoCompleteMode="SuggestAppend" 
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" 
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" 
                                                                Height="20px" MaxLength="0" Selected="true" Width="159px" 
                                                                AutoPostBack="True" onselectedindexchanged="cmbPais_SelectedIndexChanged">
                                                            </asp:DropDownList> 
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorPais" 
                                                                runat="server" ControlToValidate="cmbPais" ErrorMessage="* " 
                                                                ValidationGroup="datosDomicilio"></asp:RequiredFieldValidator>
                                                            <asp:Button ID="btnAgregarPais" runat="server" CausesValidation="False" 
                                                                Height="22px" onclick="btnAgregarPais_Click" 
                                                                onclientclick="return AbrirPanelPaises();" Text="+" 
                                                                UseSubmitBehavior="False" Visible="true" Width="18px" 
                                                                CssClass="buttonOver" />
                                                            &nbsp;<asp:Button ID="btnEliminarPais" runat="server" CausesValidation="False" 
                                                                CssClass="buttonOver" Height="22px" onclick="btnEliminarPais_Click" 
                                                                Text="x" UseSubmitBehavior="False" Visible="true" Width="18px" 
                                                                onclientclick="return ConfirmarOperacion();" />
                                                        </td>
                                                    </tr>
                                                       <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblProvincia" runat="server" CssClass="labelBold" Text="Provincia:" />
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cmbProvincia" runat="server" 
                                                                AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" 
                                                                BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" 
                                                                Font-Names="Verdana" Font-Size="11px" Height="20px" MaxLength="0" 
                                                                Selected="true" Width="159px" AutoPostBack="True" 
                                                                onselectedindexchanged="cmbProvincia_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorProvincia_" 
                                                                runat="server" ControlToValidate="cmbProvincia" ErrorMessage="* " 
                                                                ValidationGroup="datosDomicilio"></asp:RequiredFieldValidator>
                                                            <asp:Button ID="btnAgregarProvincia" runat="server" CausesValidation="False" 
                                                                Height="22px" onclick="btnAgregarProvincia_Click" 
                                                                onclientclick="return AbrirPanelNuevaProvincia();" Text="+" 
                                                                UseSubmitBehavior="False" Visible="true" Width="18px" 
                                                                CssClass="buttonOver" />
                                                            &nbsp;<asp:Button ID="btnEliminarProvincia" runat="server" CausesValidation="False" 
                                                                Height="22px" onclick="btnEliminarProvincia_Click" Text="x" 
                                                                UseSubmitBehavior="False" Visible="true" Width="18px" 
                                                                CssClass="buttonOver" onclientclick="return ConfirmarOperacion();" />
                                                        </td>
                                                    </tr>   
                                                       <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblCiudad" runat="server" CssClass="labelBold" Text="Ciudad:" />
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cmbCiudad" runat="server" 
                                                                AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" 
                                                                BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" 
                                                                Font-Names="Verdana" Font-Size="11px" Height="20px" MaxLength="0" 
                                                                Selected="true" Width="159px">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorCiudad_" 
                                                                runat="server" ControlToValidate="cmbCiudad" ErrorMessage="* " 
                                                                ValidationGroup="datosDomicilio"></asp:RequiredFieldValidator>
                                                            <asp:Button ID="btnAgregarCiudad" runat="server" CausesValidation="False" 
                                                                Height="22px" onclick="btnAgregarPais_Click" 
                                                                onclientclick="return AbrirPanelNuevaCiudad();" Text="+" 
                                                                UseSubmitBehavior="False" Visible="true" Width="18px" 
                                                                CssClass="buttonOver" />
                                                            &nbsp;<asp:Button ID="btnEliminarCiudad" runat="server" CausesValidation="False" 
                                                                Height="22px" onclick="btnEliminarCiudad_Click" Text="x" 
                                                                UseSubmitBehavior="False" Visible="true" Width="18px" 
                                                                CssClass="buttonOver" onclientclick="return ConfirmarOperacion();" />
                                                        </td>
                                                    </tr>   
                                                    <tr align="left">
                                                        <td class="style8">
                                                            <asp:Label ID="lblCalle" runat="server" CssClass="labelBold" Text="Domicilio:" />
                                                        </td>
                                                        <td class="style8">
                                                            <asp:TextBox ID="txtDomicilio" runat="server" CssClass="textboxEditor" 
                                          MaxLength="20"  Width="270px" 
                                             ></asp:TextBox>
                                    
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDomicilio_" 
                                                                runat="server" ControlToValidate="txtDomicilio" ErrorMessage="* " 
                                                                ValidationGroup="datosDomicilio"></asp:RequiredFieldValidator>
                                    
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblPiso" runat="server" CssClass="labelBold" Text="Piso:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPiso" runat="server" CssClass="textboxEditor" Width="270px"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblDepto" runat="server" CssClass="labelBold" Text="Depto:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDepto" runat="server" CssClass="textboxEditor" 
                                                                Width="270px"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblCp" runat="server" CssClass="labelBold" Text="Código Postal:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCp" runat="server" CssClass="textboxEditor" Width="270px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                               <tr >
                                  <td  colspan="2">
                                     
                                                                            <ma:SecureButton ID="btnAgregarDomicilio" runat="server" CssClass="buttonOver" 
                                          Height="20px" TabIndex="20" Text="Agregar" Width="95px" 
                                          onclick="btnAgregarDomicilio_Click" CausesValidation="True" ValidationGroup="datosDomicilio" />
                                      
                                  
</td>
                                 
                               </tr>
                        </table>
                        </asp:Panel>
                        <table style="width: 395px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2; border:1px solid #ccc; width:100%; height:40px;">
                                     
                                  
                                      <ma:SecureButton ID="btnCerrarDomicilio" runat="server" CausesValidation="False" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelDomicilios();" TabIndex="20" Text="Cerrar" 
                                           Width="95px" />
                                     
                                  
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelEmails" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelEmail" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblEmail_" runat="server" Text="  Email" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelEm" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxEditor" 
                                            MaxLength="40" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmaill" runat="server"
                                                                ControlToValidate="txtEmail" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarEmail"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarEmaill" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarEmail_Click" 
                                            ValidationGroup="datosAgregarEmail" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="SecureButton4" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelEmails();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelNuevoPais" runat="server" height="101px" width="399px">
        <asp:UpdatePanel ID="updatePanelPais" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                    text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblPais_" runat="server" Text="  País" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 75px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                 
                    <asp:Panel ID="PanelPais" runat="server"  Height="75px" Width="400px"
                       >
                        <table style="width: 100%; height: 46px;">
                           
                                <tr >
                                    <td class="style7">
                                        <asp:TextBox ID="txtPais" runat="server" CssClass="textboxEditor" 
                                            MaxLength="50" Width="237px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPais_" runat="server"
                                                                ControlToValidate="txtPais" ErrorMessage="* " 
                                                                ValidationGroup="datosAgregarPais"></asp:RequiredFieldValidator>
                                       
                                    </td>
                                    <td>
                                     <ma:SecureButton ID="btnAgregarPais_" runat="server" 
                                            CssClass="buttonOver" Height="20px" TabIndex="20" Text="Agregar" 
                                            Width="95px" CausesValidation="True" onclick="btnAgregarPais_Click" 
                                            ValidationGroup="datosAgregarPais" />
                                    </td>
                                </tr>
                         
                        </table>
                      

                        <table style="width: 402px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;" class="style7">
                                  
                                  </td>
                                  <td style="background-color:#f2f2f2;">
                                      <ma:SecureButton ID="SecureButton2" runat="server" 
                                          CssClass="buttonOver" Height="20px" 
                                          OnClientClick="return CerrarPanelNuevoPais();" TabIndex="20" Text="Cerrar" 
                                          Width="95px" />
                                  </td>
                              </tr>
                        </table>
                        </asp:Panel>
                       
                </div>  
            </ContentTemplate>
            </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelGeneral" runat="server">
        <asp:UpdatePanel ID="updatePanelGeneral" runat="server" 
            UpdateMode="Always" >
            <ContentTemplate>
    
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
       <table align="center">
        <tr>
            <td valign="top">
        
                <table style="width: auto; height: auto;" class="borderCompleto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" class="style9">
                            <table width="auto" cellpadding="0" cellspacing="0" style="height: 59px">
                                <tr>
                                    <td align="center">
                                        <asp:panel id="pnlBuscarDatos" runat="server">
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            Buscar</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            
                                            <table style="width:689px;">
                                                    <tr align="left">
                                                        <td class="style10">
                                                            <asp:Label ID="lblBusqueda" runat="server" CssClass="labelBold" 
                                                                Text="Nombre:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox1" onkeydown="onTxtKeyDown();" 
            runat="server" onkeyup="onTxtKeyUp();" AutoCompleteType="Disabled" CssClass="textboxEditor"  MaxLength="40" Width="400px"/>
                                            
             <asp:Button runat="server" ID="btnSearch"  OnClick="HandleAjaxCall" />
                                                        </td>
                                                    </tr>

                                            </table>
                                            <table>
                            </table>
                                         </asp:panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   
    
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
   
    
    
    <table align="center" style="height: 601px">
        <tr style="height: 400px;">
            <td valign="top">
        
                <table style="width: auto; height: 62%;" class="borderCompleto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <table width="auto" cellpadding="0" cellspacing="0" style="height: 400px">
                                <tr>
                                    <td align="center">
                                        <asp:panel id="pnlSeleccionarDatos" runat="server">
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            Datos de la persona</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <table style="width:682px;">
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblNombre" runat="server" CssClass="labelBold" Text="Nombre Completo:" />
                                                        </td>
                                                        <td class="style11">
                                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="textboxEditor" 
                                                                Width="300px" ValidationGroup="datosGroup" 
                                                                ></asp:TextBox>                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreNuevo" runat="server"
                                                                ControlToValidate="txtNombre" Enabled="true" ErrorMessage="*" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>                                                           
                                                        </td>
                                                        <td>
                                                             <asp:Label runat="server" ID="lblFechaNombre" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                         <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblDomicilio" runat="server" CssClass="labelBold" 
                                                                Text="Domicilio:" />
                                                        </td>
                                                        <td class="style11">
                                                            <asp:DropDownList ID="cmbDomicilio" runat="server" 
                                                                AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" 
                                                                BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" 
                                                                Font-Names="Verdana" Font-Size="11px" Height="20px" MaxLength="0" 
                                                                Width="305px" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorDomicilioNuevo" runat="server"
                                                                ControlToValidate="cmbDomicilio" ErrorMessage="* " 
                                                                ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                                    
                                                            <asp:Button ID="btnAgregarDomi" runat="server" Text="+" Visible="true" 
                                                                CausesValidation="False" onclientclick="return AbrirPanelDomicilios();" 
                                                                CssClass="buttonOver" />
                                                                    
                                                            &nbsp;<asp:Button ID="btnEliminarDomi" runat="server" CausesValidation="False" 
                                                                CssClass="buttonOver" onclientclick="return ConfirmarOperacion();" Text="-" 
                                                                Visible="true" onclick="btnEliminarDomi_Click" />                                                                  
                                                        </td>
                                                        <td>
                                                             <asp:Label ID="lblFechaDomicilio" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                          <tr align="left">
                                        <td class="style12">
                                            <asp:Label ID="lblTelefono" runat="server" cssclass="labelBold" 
                                                text="Teléfono:" />
                                        </td>
                                        <td class="style11">
                                            <asp:DropDownList ID="cmbTelefono" runat="server" 
                                                autocompletemode="SuggestAppend" backcolor="#FFFFCC" bordercolor="#B9B9B9" 
                                                borderstyle="Solid" borderwidth="1px" dropdownstyle="DropDownList" 
                                                font-names="Verdana" font-size="11px" height="20px" maxlength="0" 
                                                validationgroup="datosGroup" width="305px">
                                            </asp:DropDownList>
                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelNuevo" runat="server" ControlToValidate="txtTelefono"
                                                                Enabled="false" ErrorMessage="Ingrese el teléfono" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>--%>&nbsp;
                                           <asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidatorDomicilioNuevo0" runat="server" 
                                                controltovalidate="cmbTelefono" errormessage="* " validationgroup="datosGroup"></asp:RequiredFieldValidator>
                                            <asp:Button ID="btnAgregarTelefono" runat="server" CausesValidation="False" 
                                                CssClass="buttonOver" onclientclick="return AbrirPanelTelefonos();" Text="+" 
                                                Visible="true" usesubmitbehavior="False" />
                                            &nbsp;<asp:Button ID="btnEliminarTelefono" runat="server" CausesValidation="False" 
                                                CssClass="buttonOver" onclick="btnEliminarTelefono_Click" 
                                                onclientclick="return ConfirmarOperacion();" Text="-" Visible="true" />                                            
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFechaTelefono" runat="server" CssClass="labelBold" 
                                                Width="100px"></asp:Label>
                                        </td>
                                    </tr>
                                         <tr align="left">
                                        <td class="style12">
                                            <asp:Label ID="lblEmail" runat="server" cssclass="labelBold" text="Email/s:" />
                                        </td>
                                        <td class="style11">
                                            <asp:DropDownList ID="cmbEmails" runat="server" 
                                                autocompletemode="SuggestAppend" backcolor="#FFFFCC" bordercolor="#B9B9B9" 
                                                borderstyle="Solid" borderwidth="1px" dropdownstyle="DropDownList" 
                                                font-names="Verdana" font-size="11px" height="20px" maxlength="0" 
                                                validationgroup="datosGroup" width="305px">
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorDomicilioNuevo1" 
                                                runat="server" controltovalidate="cmbEmails" errormessage="* " 
                                                validationgroup="datosGroup"></asp:RequiredFieldValidator>
                                            <asp:Button ID="btnAgregarEmail" runat="server" 
                                                onclientclick="return AbrirPanelEmails();" text="+" visible="true" 
                                                CssClass="buttonOver" />
                                            &nbsp;<asp:Button ID="btnEliminarEmail" runat="server" CausesValidation="False" 
                                                CssClass="buttonOver" onclientclick="return ConfirmarOperacion();" Text="-" 
                                                Visible="true" onclick="btnEliminarEmail_Click" />                                            
                                        </td>
                                        <td>
                                            <asp:Label ID="lblfechaEmails" runat="server" CssClass="labelBold" 
                                                Width="100px"></asp:Label>
                                        </td>
                                    </tr>
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblOrigenContacto" runat="server" CssClass="labelBold" Text="Origen Contacto:" />
                                                        </td>
                                                        <td class="style11">
                                                            <asp:TextBox ID="txtOrigenContacto" runat="server" CssClass="textboxEditor" Width="300px" ValidationGroup="datosGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrigenContacto" runat="server"
                                                                ControlToValidate="txtOrigenContacto" ErrorMessage="*" 
                                                                ValidationGroup="datosGroup"></asp:RequiredFieldValidator>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblFechaOrigen" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblVinculo" runat="server" CssClass="labelBold" Text="Vínculo:" />
                                                        </td>
                                                        <td class="style11">
                                                            <asp:TextBox ID="txtVinculo" runat="server" CssClass="textboxEditor" Width="300px" ValidationGroup="datosGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorVinculo" runat="server"
                                                                ControlToValidate="txtVinculo" ErrorMessage="*" 
                                                                ValidationGroup="datosGroup" Display="Dynamic"></asp:RequiredFieldValidator>                                                           
                                                        </td>
                                                        <td>
                                                             <asp:Label ID="lblFechaVinculo" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblProfesion" runat="server" CssClass="labelBold" Text="Profesión:" />
                                                        </td>
                                                        <td class="style11"> 
                                                        <asp:DropDownList ID="cmbProfesion" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="20px"
                                                                MaxLength="0" Width="305px" ValidationGroup="datosGroup"></asp:DropDownList>
 
                                                            
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorProfesionCmb" 
                                                                runat="server" controltovalidate="cmbProfesion" errormessage="* " 
                                                                validationgroup="datosGroup"></asp:RequiredFieldValidator>
                                                            <asp:Button ID="btnAgregarProfesion0" runat="server" CssClass="buttonOver" 
                                                                onclientclick="return AbrirPanelNuevaProfesion();" usesubmitbehavior="False" text="+" visible="true" />
                                                            &nbsp;<asp:Button ID="btnEliminarProfesion" runat="server" CausesValidation="False" 
                                                                CssClass="buttonOver" onclick="btnEliminarProfesion_Click" 
                                                                onclientclick="return ConfirmarOperacion();" Text="-" Visible="true" />
                                                         </td>
                                                         <td>
                                                              <asp:Label ID="lblFechaProfesion" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                         </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblDoc" runat="server" CssClass="labelBold" Text="Documento:" />
                                                        </td>
                                                        <td class="style11">
                                                          <asp:DropDownList ID="cmbTipoDoc" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="20px"
                                                                MaxLength="0" Width="72px">
                                                                <asp:ListItem Value="1" Text="DNI" />
                                                                <asp:ListItem Value="2" Text="LC" />
                                                                <asp:ListItem Value="3" Text="LE" />
                                                                </asp:DropDownList>
 
                                                            <asp:TextBox ID="txtDoc" runat="server" CssClass="textboxEditor" Width="225px" 
                                                                ValidationGroup="datosGroup"></asp:TextBox>
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorDoc" runat="server"
                                                                ControlToValidate="txtDoc" ErrorMessage="*" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>                                                            
                                                        </td>
                                                        <td>
                                                                <asp:Label ID="lblFechaDocumento" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblCalificacion" runat="server" CssClass="labelBold" Text="Calificación:" />
                                                        </td>
                                                        <td class="style11">
                                                            <asp:DropDownList ID="cmbCalificacion" runat="server" 
                                                                AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" 
                                                                BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" 
                                                                Font-Names="Verdana" Font-Size="11px" Height="20px" MaxLength="0" 
                                                                Selected="true" Width="305px">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorCalificacionNuevo3" 
                                                                runat="server" ControlToValidate="cmbCalificacion" ErrorMessage="* " 
                                                                ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                            <asp:Button ID="btnAgregarCalificaciones_" runat="server" 
                                                                CausesValidation="False" CssClass="buttonOver" 
                                                                onclientclick="return AbrirPanelCalificaciones();" Text="+" Visible="true" />
                                                            &nbsp;<asp:Button ID="btnEliminarTratamiento0" runat="server" 
                                                                CausesValidation="False" CssClass="buttonOver" 
                                                                onclick="btnEliminarCalificacion_Click" 
                                                                onclientclick="return ConfirmarOperacion();" Text="-" Visible="true" />                                                           
                                                        </td>
                                                        <td>
                                                             <asp:Label ID="lblFechaCalificacion" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td class="style12">
                                                            <asp:Label ID="lblTipoDocumento" runat="server" CssClass="labelBold" 
                                                                Text="Tratamiento:" />
                                                        </td>
                                                        <td class="style11"> 
                                                        <asp:DropDownList ID="cmbTratamiento" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="20px"
                                                                MaxLength="0" Width="305px"  Selected="true" ></asp:DropDownList>
 
                                                             &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorTratamientoNuevo2" 
                                                                runat="server" ControlToValidate="cmbTratamiento" ErrorMessage="* " 
                                                                ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
 
                                                             <asp:Button ID="btnAgregarTratamiento" runat="server" CausesValidation="False" 
                                                                CssClass="buttonOver" onclick="btnAgregarTratamiento_Click" 
                                                                onclientclick="return AbrirPanelTratamientos();" Text="+" Visible="true" />
 
                                                             &nbsp;<asp:Button ID="btnEliminarTratamiento" runat="server" 
                                                                CausesValidation="False" CssClass="buttonOver" 
                                                                onclick="btnEliminarTratamiento_Click" 
                                                                onclientclick="return ConfirmarOperacion();" Text="-" Visible="true" />
                                                             </td>
                                                             <td>
                                                                 <asp:Label ID="lblFechaTratamiento" runat="server" CssClass="labelBold" 
                                                                Width="100px"></asp:Label>
                                                             </td>
                                                    </tr>
                                               
                             
                                                    <tr>
                                    <td align="left" class="style12">
                                        <asp:label id="lblCuit" runat="server" cssclass="labelBold" text="Cuit:" />
                                    </td>
                                    <td align="left" class="style11">
                                        <asp:TextBox ID="txtCuit" runat="server" CssClass="textboxEditor" Width="300px"></asp:TextBox>
                                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelNuevo" runat="server" ControlToValidate="txtTelefono"
                                                                Enabled="false" ErrorMessage="Ingrese el teléfono" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>--%>
                                       
                                     </td>
                                     <td align="left" ><asp:Label ID="lblFechaCuit" runat="server" CssClass="labelBold" Width="74px" 
                                             Height="16px"></asp:Label>
                                     </td>
                              
                <%--                    <tr align="left">
                                        <td>
                                            <asp:Label ID="lblFax" runat="server" cssclass="labelBold" text="Fax:" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFax" runat="server" cssclass="textboxEditor" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                               
                                    <tr align="left">
                                        <td class="style12">
                                            <asp:Label ID="lblNotas" runat="server" cssclass="labelBold" text="Notas:" />
                                        </td>
                                        <td class="style11">
                                            <asp:TextBox ID="txtNotas" runat="server" cssclass="textboxEditor" 
                                                height="50px" width="300px"></asp:TextBox>                                         
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFechaNotas" runat="server" CssClass="labelBold" Width="100px"></asp:Label>
                                        </td>
                                    </tr>
                                </tr>
                                            </table>
                                            <table>
                                <tr>
                                    <td>
                                        <ma:SecureButton ID="btnAceptar" runat="server" CausesValidation="True" CssClass="buttonOver"
                                            Height="20px" TabIndex="20" Text="Guardar" ValidationGroup="datosGroup" Width="95px"
                                            OnClick="btnAceptar_Click"/>
                                    </td>
                                    <td align="right">
                                        <ma:SecureButton ID="btnEliminar" runat="server" CssClass="buttonOver" Height="20px"
                                            TabIndex="20" Text="Eliminar" Width="95px" 
                                            OnClientClick="return ConfirmarOperacion();" onclick="btnEliminar_Click" />
                                    </td>
                                </tr>
                            </table>
                                         </asp:panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:panel>
    <%--    </form>
</body>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
    <style type="text/css">
        .style5
        {
            width: 266px;
        }
        .style7
        {
            width: 286px;
        }
        .style8
        {
            height: 10px;
        }
        .style9
        {
            height: 61px;
        }
        .style10
        {
            width: 92px;
        }
        .style11
        {
            width: 447px;
        }
        .style12
        {
            width: 99px;
        }
    </style>
</asp:Content>
