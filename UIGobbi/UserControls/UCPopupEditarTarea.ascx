<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCPopupEditarTarea.ascx.cs"
    Inherits="Vistas_UCPopupEditarTarea" %>
<%@ Register TagPrefix="ma" Namespace="EvaWebControls" Assembly="EvaWebControls" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="~/UserControls/UCPopupBuscarRelacion.ascx" TagPrefix="myPopupDeDatos"
    TagName="BuscarRelacion" %>


<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />
<!--script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script-->
<!-- gfsb -->
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>
<link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
<link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
<link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript">

    var ModalProgress_EditarTarea = '<%= ModalProgress_EditarTarea.ClientID %>';
    var ModalPopupResultados_EditarTarea = '<%= ModalPopupResultados_EditarTarea.ClientID %>';


    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq_EditarTarea);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq_EditarTarea);

    function colorChanged(sender) {
        sender.get_element().style.color =
       "#" + sender.get_selectedColor();
    }

    function abrirPopupEditarTarea() {
        varModalPopupAbierto = ModalPopupResultados_EditarTarea;
    }

    function beginReq_EditarTarea(sender, args) {
        // shows the Popup 
        var controlCaller = args.get_postBackElement().id;
        //alert(controlCaller);
        if (controlCaller.indexOf('btnSearch') == -1) { $find(ModalProgress_EditarTarea).show() };

    }

    /*
    shortcut.add("Esc",function() {
    try{
    CerrarPanelResultados_EditarTarea();
    //var usr = document.getElementById('ctl00_Contentplaceholder1_TextBox1_EditarTarea');
    //usr.value="";
    }
    catch(er)
    {}
      
      
    } 
    );*/

    function endReq_EditarTarea(sender, args) {
        //  shows the Popup 
        $find(ModalProgress_EditarTarea).hide();
    }

    function CerrarPanelResultados_EditarTarea() {
        $find(ModalPopupResultados_EditarTarea).hide();
        return false;
    }


    function ConfirmarOperacion() {
        if (confirm('¿Desea realizar esta operación?')) {
            return true;
        }
        return false;

    }

    function AbrirPanelTipoEvento() {
        var ModalPopupNuevoTipoEvento = '<%= ModalPopupNuevoTipoEvento.ClientID%>';
        $find(varModalPopupAbierto).hide();

        $find(ModalPopupNuevoTipoEvento).show();

        return false;
    }

    function CerrarPanelNuevoTipoEvento() {
        var ModalPopupNuevoTipoEvento = '<%= ModalPopupNuevoTipoEvento.ClientID%>';
        $find(ModalPopupNuevoTipoEvento).hide();
        $find(varModalPopupAbierto).show();

        return false;
    }


    function AbrirPanelEstado() {
        var ModalPopupNuevoEstado = '<%= ModalPopupNuevoEstado.ClientID%>';
        $find(varModalPopupAbierto).hide();

        $find(ModalPopupNuevoEstado).show();

        return false;
    }

    function CerrarPanelNuevoEstado() {
        var ModalPopupNuevoEstado = '<%= ModalPopupNuevoEstado.ClientID%>';
        $find(ModalPopupNuevoEstado).hide();
        $find(varModalPopupAbierto).show();

        return false;
    }
    function CerrarPanelMaximizado() {
        var ModalPopupListaMaximizada = '<%= ModalPopupListaMaximizada.ClientID%>';
        $find(ModalPopupListaMaximizada).hide();
        $find(varModalPopupAbierto).show();

        return false;
    }
    

    function txtNombre1OnKeyPress() {
        hidden2 = document.getElementById('<%=txtNombre1Hidden.ClientID%>');
        hidden2.value = '';
    }


</script>
<style type="text/css">
    ul.nonecircle
    {
        list-style-type: none;
    }
</style>
<asp:HiddenField ID="HiddenFieldNuevoTipoEvento" runat="server" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevoTipoEvento" runat="server" TargetControlID="HiddenFieldNuevoTipoEvento"
    BackgroundCssClass="modalBackground" PopupControlID="panelNuevoTipoEvento" />
<asp:HiddenField ID="HiddenFieldNuevoEstado" runat="server" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupNuevoEstado" runat="server" TargetControlID="HiddenFieldNuevoEstado"
    BackgroundCssClass="modalBackground" PopupControlID="panelNuevoEstado" />
<ajaxToolkit:ModalPopupExtender ID="ModalProgress_EditarTarea" runat="server" TargetControlID="panelUpdateProgress_EditarTarea"
    BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress_EditarTarea" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupResultados_EditarTarea" runat="server"
    TargetControlID="HiddenFieldResultados_EditarTarea" BackgroundCssClass="modalBackground"
    PopupControlID="panelResultados_EditarTarea" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupListaMaximizada" runat="server" TargetControlID="HiddenFieldListaMaximizada"
    BackgroundCssClass="modalBackground" PopupControlID="panelListaMaximizada" />

<myPopupDeDatos:BuscarRelacion ID="popupBuscarTareaNombre1" runat="server" />
<myPopupDeDatos:BuscarRelacion ID="popupBuscarEmpresaPersona" runat="server" />


<asp:HiddenField ID="HiddenFieldResultados_EditarTarea" runat="server" />
<asp:HiddenField ID="HiddenFieldListaMaximizada" runat="server" />
<asp:Panel ID="panelUpdateProgress_EditarTarea" runat="server" CssClass="updateProgress">
    <asp:UpdateProgress ID="UpdateProg_EditarTarea" DisplayAfter="0" runat="server">
        <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: center;">
                <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                Procesando...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Panel>
<asp:Panel ID="panelNuevoTipoEvento" runat="server" Height="101px" Width="399px">
    <asp:UpdatePanel ID="updatePanelTipoEvento" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;
                text-align: left;">
                <table>
                    <tr>
                        <td align="center" style="padding-left: 10px;">
                            <asp:Label ID="lblTipoEvento_" runat="server" Text="  Evento" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 175px; width: 400px; background-color: #ffffff; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: center;">
                <asp:Panel ID="PanelTipoEvento" runat="server" Height="175px" Width="400px">
                    <table style="width: 100%; height: 146px;">
                        <tr>
                            <td align="left">
                                <asp:Label Text="Descripción:" runat="server" CssClass="labelBold" />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTipoEvento" runat="server" CssClass="textboxEditorBlanco" MaxLength="50"
                                    Width="237px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTipoEvento" runat="server"
                                    ControlToValidate="txtTipoEvento" ErrorMessage="* " ValidationGroup="datosAgregarTipoEvento"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label Text="Color:" runat="server" CssClass="labelBold" />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtColorTipoEvento" runat="server" CssClass="textboxEditorBlanco"
                                    MaxLength="8" Width="60px"></asp:TextBox>
                                <ajaxToolkit:ColorPickerExtender runat="server" ID="ColorPickerExtender1" TargetControlID="txtColorTipoEvento"
                                    OnClientColorSelectionChanged="colorChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ma:SecureButton ID="btnAgregarTipoEvento_" runat="server" CssClass="buttonOver"
                                    Height="20px" TabIndex="20" Text="Agregar" Width="95px" CausesValidation="True"
                                    OnClick="btnAgregarTipoEvento_Click" ValidationGroup="datosAgregarTipoEvento" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 402px; height: 27px; margin-top: 0px;">
                        <tr>
                            <td style="background-color: #f2f2f2;">
                                <ma:SecureButton ID="btnCerrarNuevoTipoEvento" runat="server" CssClass="buttonOver"
                                    Height="20px" OnClientClick="return CerrarPanelNuevoTipoEvento();" TabIndex="20"
                                    Text="Cerrar" Width="95px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="panelListaMaximizada" runat="server" Height="100%" Width="100%">
    <asp:UpdatePanel ID="updatePanelListaMaximizada" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 100%; width: 100%;
                text-align: left;">
                <table>
                    <tr>
                        <td align="center" style="padding-left: 10px;">
                            <asp:Label ID="Label4" runat="server" Text="Listado Maximizado" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height:100%; width: 100%; background-color: #ffffff; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: center;">
                 <asp:Panel ID="panelInternoListaMaximizada" runat="server" CssClass="scrollbar" 
                     Height="100%" ScrollBars="Horizontal"
                                                        Width="100%">
                                                        <ma:XGridView ID="gdvListaTareasMaximizada" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" BorderWidth="1px" DataKeyNames="idTarea" EmptyDataText="No se encontraron resultados"
                                                            ExecutePageIndexChanging="True" PageSize="400" Width="100%" OnFilling="gvTareasAsignadas_Filling"
                                                            OnPageIndexChanging="gvTareasAsignadas_PageIndexChanging" OnRowCommand="gvTareasAsignadas_RowCommand"
                                                            OnSelectedIndexChanged="gvTareasAsignadas_SelectedIndexChanged" RowStyle-BorderWidth="1px"
                                                            OnRowDataBound="gvTareasAsignadas_RowDataBound">
                                                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDetalleTarea" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                            CommandName="Detalles" runat="server" Text="Edit" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                    <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:BoundField DataField="hora" HeaderText="Hora" ItemStyle-HorizontalAlign="Center"
                                                                DataFormatString="{0:HH:MM}">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="contacto" HeaderText="Contacto" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="evento" HeaderText="Evento" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="idTipoEvento" HeaderText="TipoEvento" ItemStyle-HorizontalAlign="Center"
                                                                    InsertVisible="false" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="usuario" HeaderText="Usuario Creac." ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaActualizacion"
                                                                    HeaderText="Fecha Act." ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usuarioAsignado" HeaderText="Usuario Asignado" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="criticidad" HeaderText="Prioridad" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="tarea" HeaderText="Tarea" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="idTarea" HeaderText="idTarea" Visible="true" >
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
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
                                                     <table style="width: 402px; height: 27px; margin-top: 0px;">
                        <tr>
                            <td style="background-color: #f2f2f2;">
                                <ma:SecureButton ID="SecureButton1" runat="server" CssClass="buttonOver"
                                    Height="20px" OnClientClick="return CerrarPanelMaximizado();" TabIndex="20"
                                    Text="Cerrar" Width="95px" />
                            </td>
                        </tr>
                    </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

<asp:Panel ID="panelNuevoEstado" runat="server" Height="70px" Width="270px">
    <asp:UpdatePanel ID="updatePanelEstado" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 270px;
                text-align: left;">
                <table>
                    <tr>
                        <td align="center" style="padding-left: 10px;">
                            <asp:Label ID="lblEstado_" runat="server" Text="  Estado" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 70px; width: 270px; background-color: #ffffff; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: center;">
                <asp:Panel ID="PanelEstado" runat="server" Height="65px" Width="270px">
                    <table style="width: 100%; height: 65px;">
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtEstado" runat="server" CssClass="textboxEditorBlanco" MaxLength="50"
                                    Width="137px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEstado" runat="server" ControlToValidate="txtEstado"
                                    ErrorMessage="* " ValidationGroup="datosAgregarEstado"></asp:RequiredFieldValidator>
                                <ma:SecureButton ID="btnAgregarEstado_" runat="server" CssClass="buttonOver" Height="20px"
                                    TabIndex="20" Text="Agregar" Width="95px" CausesValidation="True" OnClick="btnAgregarEstado_Click"
                                    ValidationGroup="datosAgregarEstado" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 272px; height: 27px; margin-top: 0px;">
                        <tr>
                            <td style="background-color: #f2f2f2;">
                                <ma:SecureButton ID="btnCerrarNuevoEstado" runat="server" CssClass="buttonOver" Height="20px"
                                    OnClientClick="return CerrarPanelNuevoEstado();" TabIndex="20" Text="Cerrar"
                                    Width="95px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="panelResultados_EditarTarea" runat="server" Height="680px" Width="1200px"
    ScrollBars="Vertical">
    <asp:UpdatePanel ID="updatePanelResultados_EditarTarea" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 12px; background-color: #6d84b4; border-bottom: #cccccc 1px inset;
                text-align: left; height: 35px; width: 1100px; text-align: left; position: absolute;
                top: 1px; bottom: 412px;">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblTitulo" Text="Tarea" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="font-family: Tahoma, Arial, MS Sans Serif; font-weight: bold; font-size: 10px;
                background-color: White; border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset;
                text-align: left; height: 850px; text-align: left; width: 1100px; position: absolute;
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
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel runat="server">
                                            <table style="width: 404px">
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lblUsuarioAsignado" runat="server" CssClass="labelBold" Text="Usuario Asignado:" />
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:DropDownList ID="cmbUsuarioAsignado" runat="server" AutoCompleteMode="SuggestAppend"
                                                            BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList"
                                                            Font-Names="Verdana" Font-Size="14px" Height="25px" MaxLength="0" Selected="true"
                                                            AutoPostBack="true" Width="305px" OnSelectedIndexChanged="cmbUsuarioAsignado_SelectedIndexChanged">
                                                            <asp:ListItem Value="avl">Alberto V. Lisdero_AVL</asp:ListItem>
                                                            <asp:ListItem Value="pz">Ma. Agustina Pezzi_PZ</asp:ListItem>
                                                            <asp:ListItem Value="arl">Alfredo Lisdero_ARL</asp:ListItem>
                                                            <asp:ListItem Value="ic">Irene Cragno_ic</asp:ListItem>
                                                            <asp:ListItem Value="nh">Norma Houdin_nh</asp:ListItem>
                                                            <asp:ListItem Value="cp">Carmen Paz_cp</asp:ListItem>
                                                            <asp:ListItem Value="ys">Yanina Segovia_ys</asp:ListItem>
                                                            <asp:ListItem Value="gt">Gastón_Toppano_gt</asp:ListItem>
                                                            <asp:ListItem Value="dm">Denise_Malgieri_dm</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorUsuarioAsignado" runat="server"
                                                            ControlToValidate="cmbUsuarioAsignado" ErrorMessage="* " ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEmpresaPersona" runat="server" CssClass="labelBold" Text="Empresa/Persona" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmpresaPersonaNombre" runat="server" AutoCompleteType="Disabled"
                                                            CssClass="textboxEditor" Width="450px" ReadOnly="true" />
                                                        <asp:HiddenField ID="txtEmpresaPersonaNombreHidden" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnSearchEmpresaPersona" OnClick="btnSearchEmpresaPersona_EditarTarea_Click"
                                                            Text="Sel." CssClass="buttonOver" Font-Bold="true"/>
                                                        <asp:Button runat="server" ID="btnLimpiarEmpresaPersona" OnClick="btnLimpiarEmpresaPersona_EditarTarea_Click"
                                                            Text="Limpiar"  CssClass="buttonOver"/>
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
                                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderColor="#CCCCCC">
                                            <table style="width: 600px">
                                                <tr>
                                                    <td>
                                                        Otros Filtros
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesIdTarea" runat="server" Text="Id Tarea" Width="80px" /><asp:TextBox
                                                                        ID="txtFiltroIdTarea" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesHora" runat="server" Text="Hora" Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroHora" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesEvento" runat="server" Text="Evento" Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroEvento" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                    <asp:CheckBox ID="chkOpcionesContacto" runat="server" Text="Contacto" 
                                                                        Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroContacto" runat="server" CssClass="textboxEditor" 
                                                                        Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesPrioridad" runat="server" Text="Prioridad" Width="80px" /><asp:TextBox
                                                                        ID="txtFiltroPrioridad" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesTarea" runat="server" Text="Tarea" Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroTarea" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesEstado" runat="server" Text="Estado" Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroEstado" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesTipoEvento" runat="server" Text="TipoEvento" Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroTipoEvento" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesUsuario" runat="server" Text="Usuario" Width="80px" />
                                                                    <asp:TextBox ID="txtFiltroUsuario" runat="server" Width="100px" CssClass="textboxEditor"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOpcionesFechaAct" runat="server" Text="Fecha Act.(DD/MM/YYYY)"
                                                                        Width="160px" /><asp:TextBox ID="txtFiltroFechaAct" runat="server" Width="100px"
                                                                            CssClass="textboxEditor" EnableTheming="True"></asp:TextBox>
                                                                    <asp:CheckBox ID="chkOpcionesIncluirFinalizadas" runat="server" Text="Finalizadas"
                                                                        Width="100px" />
                                                                    <asp:Button ID="btnBuscarDatos" runat="server" Text="Sel." OnClick="btnBuscarDatos_Click"
                                                                        Width="52px" CssClass="buttonOver" Font-Bold="true"/>
                                                                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"
                                                                        Width="58px" CssClass="buttonOver" />
                                                                </td>
                                                            </tr>
                                                        </table>
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
                        <td align="left">
                            <table>
                                <tr>
                                    <td valign="middle" align="left">
                                        &nbsp;
                                        <asp:Calendar ID="Calendar1" runat="server" SelectionMode="DayWeekMonth" OnSelectionChanged="Calendar1_SelectionChanged"
                                            Width="200px" Height="190px" DayHeaderStyle-CssClass="gvHeader grayGvHeader"
                                            NextPrevStyle-CssClass="gvHeader grayGvHeader" SelectedDayStyle-CssClass="gvHeader grayGvHeader"
                                            TitleStyle-CssClass="gvHeader grayGvHeader" TitleStyle-Font-Bold="true" DayHeaderStyle-Font-Bold="true">
                                        </asp:Calendar>
                                    </td>
                                    <td>
                                    </td>
                                    <td valign="middle" align="left">
                                        <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                            font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                            border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: left;
                                            width: 853px;">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        Listado de Tareas Agendadas
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
                                                    <ma:SecureButton ID="btnBajarExcel" runat="server" CausesValidation="True" CssClass="button"
                                                        Font-Bold="true" Height="20px" TabIndex="20" Text="Bajar a Excel" ValidationGroup="datosGroup"
                                                        Width="90px" OnClick="btnExportarExcel_Click" />

                                                    <ma:SecureButton ID="btnAbrirListado" runat="server"  CssClass="button"
                                                        Font-Bold="true" Height="20px" TabIndex="20" Text="Maximizar Listado" OnClick="ListarTarea_Click"
                                                        Width="90px"  />
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel2" runat="server" CssClass="scrollbar" Height="170px" ScrollBars="Horizontal"
                                                        Width="850px">
                                                        <ma:XGridView ID="gvTareasAsignadas" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" BorderWidth="1px" DataKeyNames="idTarea" EmptyDataText="No se encontraron resultados"
                                                            ExecutePageIndexChanging="True" PageSize="400" Width="100%" OnFilling="gvTareasAsignadas_Filling"
                                                            OnPageIndexChanging="gvTareasAsignadas_PageIndexChanging" OnRowCommand="gvTareasAsignadas_RowCommand"
                                                            OnSelectedIndexChanged="gvTareasAsignadas_SelectedIndexChanged" RowStyle-BorderWidth="1px"
                                                            OnRowDataBound="gvTareasAsignadas_RowDataBound">
                                                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDetalleTarea" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                            CommandName="Detalles" runat="server" Text="Edit" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                    <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="hora" HeaderText="Hora" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                
                                                                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaDeAlerta"
                                                                    HeaderText="Fecha Cr." ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="contacto" HeaderText="Contacto" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="evento" HeaderText="Evento" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="idTipoEvento" HeaderText="TipoEvento" ItemStyle-HorizontalAlign="Center"
                                                                    InsertVisible="false" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="usuario" HeaderText="Usuario Creac." ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaActualizacion"
                                                                    HeaderText="Fecha Act." ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usuarioAsignado" HeaderText="Usuario Asignado" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="criticidad" HeaderText="Prioridad" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="tarea" HeaderText="Tarea" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="idTarea" HeaderText="idTarea" Visible="true">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>

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
                    <tr align="left">
                        <td>
                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: center;
                                width: 100%;">
                                <table>
                                    <tr>
                                        <td align="left">
                                            Detalle de la Tarea Seleccionada
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblEmpresaPersona1" Text="Contacto" runat="server" CssClass="labelBold" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" Text="Usuario Asignado" runat="server" CssClass="labelBold" />
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:HiddenField ID="hiddenIdTarea" runat="server" />
                                        <asp:TextBox ID="txtNombre1" runat="server" AutoCompleteType="Disabled" CssClass="textboxEditor"
                                            Width="350px" onkeydown="txtNombre1OnKeyPress();" />
                                        <asp:HiddenField ID="txtNombre1Hidden" runat="server" />
                                        <asp:Button runat="server" ID="btnSearchNombre1_EditarTarea" OnClick="btnSearchNombre1_EditarTarea_Click"
                                            Text="Sel." Visible="true" CssClass="buttonOver" Font-Bold="true" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cmbUsuarioAsignadoEdicion" runat="server" AutoCompleteMode="SuggestAppend"
                                            BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList"
                                            Font-Names="Verdana" Font-Size="12px" Height="25px" MaxLength="0" Selected="true"
                                            Width="305px">
                                            <asp:ListItem Value="avl">Alberto V. Lisdero_AVL</asp:ListItem>
                                            <asp:ListItem Value="pz">Ma. Agustina Pezzi_PZ</asp:ListItem>
                                            <asp:ListItem Value="arl">Alfredo Lisdero_ARL</asp:ListItem>
                                            <asp:ListItem Value="ic">Irene Cragno_ic</asp:ListItem>
                                            <asp:ListItem Value="nh">Norma Houdin_nh</asp:ListItem>
                                            <asp:ListItem Value="cp">Carmen Paz_cp</asp:ListItem>
                                            <asp:ListItem Value="ys">Yanina Segovia_ys</asp:ListItem>
                                            <asp:ListItem Value="gt">Gastón_Toppano_gt</asp:ListItem>
                                            <asp:ListItem Value="dm">Denise_Malgieri_dm</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorCmbUsuarioAsignadoEdicion"
                                            runat="server" ControlToValidate="cmbUsuarioAsignadoEdicion" ErrorMessage="* "
                                            ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <table style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                            font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                            border-bottom: #cccccc 1px inset; text-align: left; height: 20px; text-align: left;
                                            width: 350px;">
                                            <tr>
                                                <td align="left">
                                                    Bitácora de Actualizaciones de la tarea
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: normal;
                                            font-size: 12px; background-color: White; border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset;
                                            text-align: left; text-align: left; width: 350px; height: 250px; overflow: scroll;
                                            position: absolute; top: inherit; left: inherit;">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Repeater runat="server" ID="rptListActualizaciones" OnItemCommand="rptListActualizaciones_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Panel ID="Panel1" runat="server">
                                                                            <span><cite><b>
                                                                                <%# DataBinder.Eval(Container.DataItem, "usuario") %></b></cite> la actualizó el
                                                                                <asp:LinkButton ID='lnkActualizaciones' runat="server" CommandName="MostrarTarea"
                                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idTareaHistoria") %>'
                                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "fechaActualizacion") %>'></asp:LinkButton>
                                                                            </span>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblFechaDeAviso" runat="server" Style="font-family: Verdana; font-size: 9px;
                                            font-weight: bold;" Text="Fecha de Tarea "></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblHoraTarea" runat="server" Style="font-family: Verdana; font-size: 9px;
                                            font-weight: bold;" Text="Hora Tarea "></asp:Label>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left">
                                        <asp:TextBox ID="txtFechaNuevaTarea" runat="server" CssClass="textboxEditor" ValidationGroup="MKE"
                                            Width="83px" Height="16px" BackColor="White"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                            Format="dd/MM/yyyy" PopupButtonID="imgFecha2" TargetControlID="txtFechaNuevaTarea" />
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True"
                                            Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaNuevaTarea" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgFecha2" runat="server" ImageUrl="~/Images/Calendar.png" />
                                    </td>
                                    <td align="left">
                                        <mkb:TimeSelector ID="TimeSelector1" runat="server" MinuteIncrement="15" SelectedTimeFormat="TwentyFour" Visible="false"/>
                                    
                                    <asp:DropDownList ID="tsHorario" runat="server" EnableViewState="true">
                                                            <asp:ListItem value ="00:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="00:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="01:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="01:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="02:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="02:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="03:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="03:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="04:00"> 4:00 </asp:ListItem>
                                                            <asp:ListItem value ="04:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="05:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="05:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="06:00"> 6:00 </asp:ListItem>
                                                            <asp:ListItem value ="06:30"> 6:30 </asp:ListItem>
                                                            <asp:ListItem value ="07:00"> 7:00</asp:ListItem>
                                                            <asp:ListItem value ="07:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="08:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="08:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="09:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="09:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPrioridad" runat="server" Style="font-family: Verdana; font-size: 9px;
                                            font-weight: bold;" Text="Prioridad "></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Style="font-family: Verdana; font-size: 9px;
                                            font-weight: bold;" Text="Evento"></asp:Label>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left">
                                        <asp:DropDownList ID="cmbCriticidad" runat="server" AutoCompleteMode="SuggestAppend"
                                            BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList"
                                            Font-Names="Verdana" Font-Size="11px" MaxLength="0" Width="167px" BackColor="White">
                                            <asp:ListItem Value="1" style="color:Red">1 - Critica</asp:ListItem>
                                            <asp:ListItem Value="2" style="color:Orange">2 - Moderada</asp:ListItem>
                                            <asp:ListItem Value="3" style="color:Green">3 - Baja</asp:ListItem>
                                            <asp:ListItem Value="4" style="color:Blue">4 - No prioritaria</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="cmbEvento" runat="server" AutoCompleteMode="SuggestAppend"
                                                        AutoPostBack="true" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" MaxLength="0"
                                                        OnSelectedIndexChanged="cmbEvento_SelectedIndexChanged" Width="167px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Panel ID="pnlCmbEvento" runat="server" BackColor="Black" Height="15" Width="15" Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAgregarTipoEvento" runat="server" CausesValidation="False" CssClass="buttonOver"
                                                        OnClientClick="return AbrirPanelTipoEvento();" Text="+" Visible="true" />
                                                    &nbsp;<asp:Button ID="btnEliminarTipoEvento" runat="server" CausesValidation="False"
                                                        CssClass="buttonOver" OnClick="btnEliminarTipoEvento_Click" OnClientClick="return ConfirmarOperacion();"
                                                        Text="-" Visible="true" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTipoEvento_" runat="server"
                                            ControlToValidate="cmbEvento" ErrorMessage="* " ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblEstado" runat="server" Style="font-family: Verdana; font-size: 9px;
                                            font-weight: bold;" Text="Estado"></asp:Label>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left">
                                        <asp:DropDownList ID="cmbEstado" runat="server" AutoCompleteMode="SuggestAppend"
                                            BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList"
                                            Font-Names="Verdana" Font-Size="11px" MaxLength="0" Width="167px" BackColor="White">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnAgregarEstado" runat="server" CausesValidation="False" CssClass="buttonOver"
                                            OnClientClick="return AbrirPanelEstado();" Text="+" Visible="true" />
                                        &nbsp;
                                        <asp:Button ID="btnEliminarEstado" runat="server" CausesValidation="False" CssClass="buttonOver"
                                            OnClick="btnEliminarEstado_Click" OnClientClick="return ConfirmarOperacion();"
                                            Text="-" Visible="true" />
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label1" Text="Tarea" runat="server" CssClass="labelBold" />
                                    </td>
                                </tr>
                                </table>
                                <table>
                                <tr align="left">
                                    <td>
                                        <asp:TextBox ID="txtTarea" runat="server" AutoCompleteType="Disabled" CssClass="textArea"
                                            BackColor="White" Wrap="true" MaxLength="1000" Width="700px" TextMode="MultiLine"
                                            Columns="80" Rows="10" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ma:SecureButton ID="btnAceptar" runat="server" CausesValidation="True" CssClass="buttonOver"
                                            Height="20px" TabIndex="20" Text="Guardar" ValidationGroup="datosGroup" Width="95px"
                                            OnClick="btnAceptar_Click" />
                                        <ma:SecureButton ID="btnEliminar" runat="server" CssClass="buttonOver" Height="20px"
                                            TabIndex="20" Text="Eliminar" Width="95px" OnClientClick="return ConfirmarOperacion();"
                                            OnClick="btnEliminar_Click" />
                                        <ma:SecureButton ID="btnCerrarEditarTarea" runat="server" CssClass="buttonOver" Height="20px"
                                            OnClientClick="return CerrarPanelResultados_EditarTarea();" TabIndex="20" Text="Cerrar"
                                            Width="95px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table style="width: 660px; height: 27px; margin-top: 0px;">
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
