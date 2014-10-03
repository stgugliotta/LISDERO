<%@ control language="C#" autoeventwireup="true" inherits="Vistas_UCPopupBuscarRelacion, App_Web_0kv4fcl1" %>
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
	            var ModalProgress_BuscarRelacion_<%= ClientID %> = '<%= ModalProgress_BuscarRelacion.ClientID %>';   
                var ModalPopupResultados_BuscarRelacion_<%= ClientID %> = 	'<%= PopupResultados_BuscarRelacion.ClientID %>';   
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq_BuscarRelacion_<%= ClientID %>);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq_BuscarRelacion_<%= ClientID %>);
                
                

function beginReq_BuscarRelacion_<%= ClientID %>(sender, args) 
{
	// shows the Popup 
	var controlCaller=args.get_postBackElement().id;
	//alert(controlCaller);
    if(controlCaller.indexOf('btnSearch')==-1){$find(ModalProgress_BuscarRelacion_<%= ClientID %>).show()};
        	 
}


function CerrarPanelResultados_BuscarRelacion_<%= ClientID %>()
{
  $find(ModalPopupResultados_BuscarRelacion_<%= ClientID %>).hide();
  return false;
} 

function endReq_BuscarRelacion_<%= ClientID %>(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress_BuscarRelacion_<%= ClientID %>).hide();
} 


</script>

<script type="text/javascript">
        var to_<%= ClientID %>; // variable to which we assign setTimeout function
        var prm_<%= ClientID %> = Sys.WebForms.PageRequestManager.getInstance(); // Page Request Manager object
        function onTxtKeyUp_BuscarRelacion_<%= ClientID %>(obj) {
            //var elemento =document.getElementById('ctl00_Contentplaceholder1_TextBox1_BuscarRelacion');
            //var elemento = obj;
            //document.getElementById('ctl00$Contentplaceholder1$popupEditarRelacion$popupBuscarRelacionNombre2$TextBox1_BuscarRelacion');
            //alert(elemento.value);
            var txtId = '#' + '<%= TextBox1_BuscarRelacion.ClientID%>';
            var hiddenTxtId = '#' + '<%= hiddenTextBox1_BuscarRelacion.ClientID%>';
            $(hiddenTxtId).value = $(txtId).value;
            
            switch (obj.keyCode) {
                case 36: //home
                case 27: //esc
                case 37: //left key
                case 30: //right key
                case 40: //down
                case 38: //up
                case 13: //enter
                case 16: //shift
                case 33: //pup
                case 34: //pdn
                case 20: //CAPS
                case 9: //tab
                case 17: //ctrl
                case 91: //winkey
                case 45: //insert
                case 19: //pause
                    break;
                default:
                    to_<%= ClientID %> = setTimeout('performSearch_BuscarRelacion_<%= ClientID %>();' , 10);
                    break;
            }
           
        }

        function onTxtKeyDown_BuscarRelacion_<%= ClientID %>(obj) {
            prm_<%= ClientID %>.abortPostBack();
            if(to_<%= ClientID %>)clearTimeout(to_<%= ClientID %>);
        
        }
        function performSearch_BuscarRelacion_<%= ClientID %>() {
            if(prm_<%= ClientID %>.get_isInAsyncPostBack) {
                prm_<%= ClientID %>.abortPostBack();

            }

            __doPostBack("<%=btnSearch_BuscarRelacion.UniqueID %>", "");
        }
</script>


<script type="text/javascript">
 
 var varModalPopupAbierto_BuscarRelacion_<%= ClientID %>;
  
      function AbrirPanelResultados_BuscarRelacion_<%= ClientID %>()
    {

      var PopupResultados_BuscarRelacion_<%= ClientID %> = '<%= PopupResultados_BuscarRelacion.ClientID%>';
      $find(PopupResultados_BuscarRelacion_<%= ClientID %>).show();
    
    return false;
    }

     function CerrarPanelResultados_BuscarRelacion_<%= ClientID %>()
    {
      var PopupResultados_BuscarRelacion_<%= ClientID %> = '<%= PopupResultados_BuscarRelacion.ClientID%>';
      //alert($find(PopupResultados_BuscarRelacion));
      $find(PopupResultados_BuscarRelacion_<%= ClientID %>).hide();
      ///$find(varModalPopupAbiertoEditarRelacion).show();
      $find(varModalPopupAbierto).show();
      return false;
    }   
    
    
        
  function establerCursorPosicion_BuscarRelacion_<%= ClientID %>(pos){ 

  
  //var elemento =document.getElementById('ctl00_Contentplaceholder1_TextBox1_BuscarRelacion');
  //var elemento =document.getElementById('ctl00$Contentplaceholder1$popupEditarRelacion$popupBuscarRelacionNombre2$TextBox1_BuscarRelacion');
  
  var elemento =document.getElementById('<%= TextBox1_BuscarRelacion.ClientID %>');
  
        if(typeof document.selection != 'undefined' && document.selection){        //método IE
            var tex=elemento.value;
            elemento.value=''; 
            elemento.focus();
            var str = document.selection.createRange(); 
            elemento.value=tex;
            str.move("character", pos); 
            str.moveEnd("character", 0); 
            str.select();
            elemento.focus();
        }
        else if(typeof elemento.selectionStart != 'undefined'){                    //método estándar
            elemento.setSelectionRange(pos,pos);
            elemento.focus();                    
        }
    }    
        
        
    
var currentRowId = 0;

        function NavegarComTeclado_BuscarRelacion_<%= ClientID %>()

        {

            if (event.keyCode == 40)

                MarcarLinha_BuscarRelacion_<%= ClientID %>(currentRowId+1);

            else if (event.keyCode == 38)

                MarcarLinha_BuscarRelacion_<%= ClientID %>(currentRowId-1);

        }      

 

        function MarcarLinha_BuscarRelacion_<%= ClientID %>(rowId)

        {

          if (document.getElementById(rowId) == null)

              return;

          if (document.getElementById(currentRowId) != null )

          // Retorna a primeira alinha do Grid quando clicar.

          document.getElementById(currentRowId).style.backgroundColor = white;

          currentRowId = rowId;

          //Muda a cor da linha atualmente selecionada...

          document.getElementById(rowId).style.backgroundColor = blue;

        }


</script>

<ajaxToolkit:ModalPopupExtender ID="ModalProgress_BuscarRelacion" runat="server"
    TargetControlID="panelUpdateProgress_BuscarRelacion" BackgroundCssClass="modalBackground"
    PopupControlID="panelUpdateProgress_BuscarRelacion" />
<ajaxToolkit:ModalPopupExtender ID="PopupResultados_BuscarRelacion" runat="server"
    PopupControlID="panelResultados_BuscarRelacion" TargetControlID="HiddenFieldResultados_BuscarRelacion"
    BackgroundCssClass="modalBackground" />
<asp:HiddenField ID="HiddenFieldResultados_BuscarRelacion" runat="server" />

<asp:Panel ID="panelUpdateProgress_BuscarRelacion" runat="server" CssClass="updateProgress">
    <asp:UpdateProgress ID="UpdateProg_BuscarRelacion" DisplayAfter="0" runat="server">
        <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: center;">
                <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                Procesando...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Panel>
<asp:Panel ID="panelResultados_BuscarRelacion" runat="server" Height="101px" Width="550px">
    <asp:UpdatePanel ID="updatePanelResultados_BuscarRelacion" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="font-family: Lucida,tahoma,verdana,arial,sans-serif; color: White; font-weight: bold;
                font-size: 12px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                border-bottom: #cccccc 1px inset; text-align: left; height: 35px; width: 520px;
                text-align: left; position: absolute; top: -81px; ">
                <table>
                    <tr>
                        <td align="left">
                            Buscar Persona o Empresa,
                        </td>
                    </tr>
                </table>
            </div>
            <div style="font-family: Tahoma, Arial, MS Sans Serif; font-weight: bold; font-size: 10px;
                background-color: White; border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset;
                text-align: left; height: 35px; text-align: left; width: 520px; position: absolute;
                top: -61px; ">
                <table style="width: 520px;">
                    <tr align="left">
                        <td>
                        <asp:HiddenField ID="hiddenTextBox1_BuscarRelacion" runat="server"/>
                                                        
                            <asp:TextBox ID="TextBox1_BuscarRelacion" 
                                runat="server"  AutoCompleteType="Disabled"
                                CssClass="textboxEditor" MaxLength="40" Width="350px" />
                            <asp:Button runat="server" ID="btnSearch_BuscarRelacion" OnClick="HandleAjaxCall_BuscarRelacion" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-left: 10px;">
                            <asp:Label ID="lblResultados__BuscarRelacion" runat="server" Text="  Resultados" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: auto; width: 520px; background-color: #ffffff; border-bottom: #cccccc 1px inset;
                text-align: center; position: absolute; top: -32px; " cssclass="scrollbar">
                <table style="width: 520px; height: 27px; margin-top: 0px;">
                    <tr>
                        <td style="background-color: #f2f2f2;">
                            <asp:Panel ID="pnlGvResultados_BuscarRelacion" runat="server" Height="300px" ScrollBars="Vertical"
                                CssClass="scrollbar" Width="500px">
                                <ma:XGridView ID="gvResultadosBusqueda_BuscarRelacion" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No se encontraron resultados"
                                    ExecutePageIndexChanging="True" OnFilling="GvResultadosBusqueda_BuscarRelacion_Filling"
                                    OnPageIndexChanging="GvResultadosBusqueda_BuscarRelacion_PageIndexChanging" OnRowCommand="GvResultadosBusqueda_BuscarRelacion_RowCommand"
                                    OnRowDataBound="GvResultadosBusqueda_BuscarRelacion_RowDataBound" OnRowDeleting="GvResultadosBusqueda_BuscarRelacion_RowDeleting"
                                    OnRowEditing="GvResultadosBusqueda_BuscarRelacion_RowEditing" OnSelectedIndexChanged="GvResultadosBusqueda_BuscarRelacion_SelectedIndexChanged"
                                    Width="450px">
                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnContacto_BuscarRelacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    CommandName="DatosPersonales" runat="server" Text="View More" ImageUrl="~/Images/persona.gif" />
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NombreYCodigo" ShowHeader="False" Visible="True">
                                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="0px" />
                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnRelacion_BuscarRelacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>
                                                                                " CommandName="Relaciones" runat="server" Text="View More"
                                                    ImageUrl="~/Images/red2.png" />
                                            </ItemTemplate>
                                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#99CCFF" />
                                    <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No se hallaron resultados.
                                    </EmptyDataTemplate>
                                    <FooterStyle CssClass="gvHeader grayGvHeader" />
                                    <HeaderStyle BackColor="White" BorderStyle="None" />
                                    <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                    <RowStyle CssClass="gvItem" />
                                </ma:XGridView>
                            </asp:Panel>
                            <asp:Panel ID="pnlMostrarMas_BuscarRelacion" runat="server" Height="15px" CssClass="scrollbar"
                                Width="500px">
                                <p style="vertical-align: middle;" class="gvItem">
                                    <asp:LinkButton ID="linkVerMasResultados_BuscarRelacion" runat="server" OnClick="linkVerMasResultados_BuscarRelacion_Click">Mostrar más resultados...</asp:LinkButton>
                                </p>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table style="width: 470px; height: 27px; margin-top: 0px;">
                    <tr>
                        <td style="background-color: #f2f2f2;" class="style7">
                        </td>
                        <td style="background-color: #f2f2f2;">
                            <ma:SecureButton ID="btnCerrarBuscarRelacion" runat="server" CssClass="buttonOver"
                                Height="20px" 
                                TabIndex="20" Text="Cerrar" Width="95px" />
                        </td>
                    </tr>
                </table>
                <%--</asp:Panel>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
