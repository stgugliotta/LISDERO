<%@ page language="C#" masterpagefile="~/MasterPage.master" theme="SampleSiteTheme" enableeventvalidation="false" autoeventwireup="true" inherits="Vistas_ViewRelaciones, App_Web_rjtvlq0v" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<%@ Register Src="~/Vistas/UCPopupDatos.ascx" TagPrefix="myPopupDeDatos" TagName="popupPersona" %>
<%@ Register Src="~/Vistas/UCPopupDatosEmpresa.ascx" TagPrefix="myPopupDeDatos" TagName="popupEmpresa" %>
<%@ Register Src="~/UserControls/UCPopupBuscarRelacion.ascx" TagPrefix="myPopupDeDatos"
    TagName="BuscarRelacion" %>
<%@ Register Src="~/UserControls/UCPopupEditarRelacion.ascx" TagPrefix="myPopupDeDatos"
    TagName="EditarRelacion" %>
<%@ Register Src="~/UserControls/UCPopupEditarTarea.ascx" TagPrefix="myPopupDeDatos"
    TagName="EditarTarea" %>
<%@ Register Src="~/Vistas/UCPopupOtrasContactosEmpresas.ascx" TagPrefix="myPopupDeDatos" TagName="BuscarContactoEmpresa" %>
<%@ Register Src="~/Vistas/UCPopupOtrosContactosPersonas.ascx" TagPrefix="myPopupDeDatos" TagName="BuscarContacto" %>
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
$(document).ready(function()
{
            //alert(' ready ' );
	        //alert('juju');
	        //var textBoxBusqueda = '';
	        //alert(textBoxBusqueda );
            //$find(textBoxBusqueda ).focus();
        setTimeout('textbox1SetFocus();', 300);

	    var options = {minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem){
	    //openMenu(
	    
	    
	    document.location='http://localhost/vistas/ViewRelaciones.aspx';
	            
	    
	    //);
		//alert('you clicked item "' + $(this).text() + e  + '"');
	}};
	});
-->
 function textbox1SetFocus()
 {
    
     var txtId = '#' + '<%= TextBox1.ClientID%>';
     
     if (!$(txtId).is(":focus")) {
        $(txtId).focus();
     }
 }
 
    </script>

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
	            	
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{
	// shows the Popup 
	//var controlCaller=args.get_postBackElement().id;
    //if(controlCaller.indexOf('btnSearch')==-1){
    
    //    $find(ModalProgress).show();
    //}

        	 
}


shortcut.add("Esc",function() {
    
try{
      if (varModalPopupResultadosAbierto) 
      {
          CerrarPanelResultados();
          var usr = document.getElementById('ctl00_Contentplaceholder1_TextBox1');
          usr.value="";
          setTimeout('textbox1SetFocus();', 200);
      }
   }
catch(er)
{}
      }

      
      
      );


function ReducirTamanioDiv()
{

try
{
  var div= document.getElementById('ctl00_Contentplaceholder1_ctl03');

  div.setAttribute('style', 'BORDER-RIGHT: #cccccc 2px solid; WIDTH: 800px; BORDER-BOTTOM: #cccccc 1px inset; HEIGHT: 300px; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: center');
  
  }
  catch(er)
  {
  
  }
  return true;
}

function endReq(sender, args)
{
	                        //  hide the Popup 
	                        //$find(ModalProgress).hide();
	                        
	         var txtId = '#' + '<%= TextBox1.ClientID%>';
             var hiddenTxtId = '#' + '<%= hiddenTextBox1.ClientID%>';
             $(txtId).value = $(hiddenTxtId).value;

} 


function RecoveryFilters()
{
   var url='http://' + document.location.host + '/Vistas/ViewGestionDeDeudores.aspx?restoreFilters=true';
   document.location=url;
}

    </script>

    <script type="text/javascript">
        var to; // variable to which we assign setTimeout function
        var prm = Sys.WebForms.PageRequestManager.getInstance(); // Page Request Manager object
        
        function onTxtKeyUp(e) {
        
             var txtId = '#' + '<%= TextBox1.ClientID%>';
             var hiddenTxtId = '#' + '<%= hiddenTextBox1.ClientID%>';
             $(hiddenTxtId).value = $(txtId).value ;
                     
            switch (e.keyCode) {
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
                    
                    to = setTimeout('performSearch();' , 10);
                    //performSearch();
                    break;
            }
           
        }
        
        function onTxtKeyDown(e) {
        
            prm.abortPostBack();
            if(to) clearTimeout(to);
        
        }
        function performSearch() {
            if(prm.get_isInAsyncPostBack) {
                prm.abortPostBack();

            }

            __doPostBack("<%=btnSearch.UniqueID %>", "");
            
        }
    </script>

    <script type="text/javascript">
 
 var varModalPopupAbierto;
 var  varModalPopupResultadosAbierto = false;
    function AbrirPanelResultados()
    {
      var ModalPopupResultados = '<%= ModalPopupResultados.ClientID%>';
      $find(ModalPopupResultados).show();
      varModalPopupResultadosAbierto = true;
      
          //alert($find(ModalProgress).getAttributes('X'));
        //  var panelResultados = '<%= panelResultados.ClientID%>';
        //  var top = $("#" + panelResultados).offset().top;
        //  top += $("#" + "<%= TextBox1.ClientID%>").height()+100;
        //  var left = $("#" + "<%= TextBox1.ClientID%>").offset().left;
          
          //alert (top + '  ' + left);
          //alert('1: ' + $("#" + panelResultados).offset().top + '  ' + $("#" + panelResultados).offset().left);
          //$("#" + panelResultados).css('top', top);
          //$("#" + panelResultados).css('left', left);
          //alert('2: ' + $("#" + panelResultados).offset().top + '  ' + $("#" + panelResultados).offset().left);
          
          //$("#" + panelResultados).css({
          //      top: top+"px",
          //      left: left + "px"
          //});
            //alert (top + '  ' + left);
            //alert ($("#" + panelResultados).offset().top + '  ' + $("#" + panelResultados).offset().left);
            //alert(document.getElementById(panelResultados));
            //alert($("#" + panelResultados));
            //document.getElementById(panelResultados).setAttribute('style', 'top:'
        
        return false;
    }

    function CerrarPanelResultados()
    {
      var ModalPopupResultados = '<%= ModalPopupResultados.ClientID%>';
      //alert($find(ModalPopupResultados));
      try {
      $find(ModalPopupResultados).hide();
      varModalPopupResultadosAbierto = false;
      } catch (e) {
          alert(e);
      }
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
        
  function establerCursorPosicion(pos){ 

  
  var elemento =document.getElementById('ctl00_Contentplaceholder1_TextBox1');
        if(typeof document.selection != 'undefined' && document.selection){        //método IE
            //if (!elemento.hasFocus()) {
                var tex=elemento.value;
                elemento.value=''; 
                if (!elemento.hasFocus()) elemento.focus();
                var str = document.selection.createRange(); 
                elemento.value=tex;
                str.move("character", pos); 
                str.moveEnd("character", 0); 
                str.select();
                elemento.focus();
            //}
        }
        else if(typeof elemento.selectionStart != 'undefined'){                    //método estándar
            //if (!elemento.hasFocus()) { 
            elemento.setSelectionRange(pos,pos);    
            elemento.focus();
            //}
        }
    }    
        
        
    
var currentRowId = 0;

        function NavegarComTeclado()
        {

            if (event.keyCode == 40)

                MarcarLinha(currentRowId+1);

            else if (event.keyCode == 38)

                MarcarLinha(currentRowId-1);

        }      

 

        function MarcarLinha(rowId)

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


function SelectRow(sTipoGrilla, row) {
 var _selectColor = "#303030";
 var _normalColor = "#909090";
 //var _selectFontSize = "3em";
 //var _normalFontSize = "2em";
 var empresaSelectedHiddenId = '<%= HiddenEmpresaSelected.ClientID %>';
 var personaSelectedHiddenId = '<%= HiddenPersonaSelected.ClientID %>';
 
 var objEmpresaSelectedHidden = document.getElementById(empresaSelectedHiddenId);
 var objPersonaSelectedHidden = document.getElementById(personaSelectedHiddenId);
 //alert(objEmpresaPersonaSelectedHidden + _normalColor);
 // get all data rows - siblings to current
 var _rows = row.parentNode.childNodes;
 // deselect all data rows
 try {
     for (i = 0; i < _rows.length; i++) {
         var _firstCell = _rows[i].getElementsByTagName("td")[1];
         _firstCell.style.color = _normalColor;
        // _firstCell.style.fontSize = _normalFontSize;
         _firstCell.style.fontWeight = "normal";
     }
 }
 catch (e) { }
 // select current row (formatting applied to first cell)
 var _selectedRowFirstCell = row.getElementsByTagName("td")[1];
 _selectedRowFirstCell.style.color = _selectColor;
 //_selectedRowFirstCell.style.fontSize = _selectFontSize;
 _selectedRowFirstCell.style.fontWeight = "bold";
 
 //if (sTipoGrilla == 'persona') {
     objPersonaSelectedHidden.value = row.getElementsByTagName("td")[1].innerText + "#" + sTipoGrilla;
 //}
 
 //if (sTipoGrilla == 'empresa') {
 //    objEmpresaSelectedHidden.value = row.getElementsByTagName("td")[1].innerText + "#" + sTipoGrilla;
 //}

     var btnModificarRelacionPersona = document.getElementById('<%=btnModificarRelacionPersona.ClientID %>');
     var btnEliminarRelacionPersona = document.getElementById('<%=btnEliminarRelacionPersona.ClientID %>');
     var btnVerRelacionPersona = document.getElementById('<%=btnVerRelacionPersona.ClientID %>');
     var btnResumendelContacto = document.getElementById('<%=btnResumendelContacto.ClientID %>');
     btnEliminarRelacionPersona.disabled = false;
     btnEliminarRelacionPersona.setAttribute("class", "buttonOver");
     btnModificarRelacionPersona.disabled = false;
     btnModificarRelacionPersona.setAttribute("class", "buttonOver");
     btnVerRelacionPersona.disabled = false;
     btnVerRelacionPersona.setAttribute("class", "buttonOver");
     btnResumendelContacto.disabled = false;
     btnResumendelContacto.setAttribute("class", "buttonOver");
     
 //alert(objEmpresaPersonaSelectedHidden.value);
}

    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupResultados" runat="server" TargetControlID="HiddenFieldResultados"
        PopupControlID="panelResultados" RepositionMode="None" />
    <asp:hiddenfield id="HiddenFieldResultados" runat="server" />
    <asp:hiddenfield id="HiddenPersonaSelected" runat="server" />
    <asp:hiddenfield id="HiddenEmpresaSelected" runat="server" />
    <myPopupDeDatos:BuscarRelacion ID="popupBuscarRelacion" runat="server" />
    <myPopupDeDatos:EditarRelacion ID="popupEditarRelacion" runat="server" />
    <myPopupDeDatos:EditarTarea ID="popupEditarTarea" runat="server" /> 
    <asp:panel id="panelResultados" runat="server" height="101px" width="396px">
      <asp:UpdatePanel ID="updatePanelResultados" runat="server" UpdateMode="Always" >
      <ContentTemplate>
                <div style="font-family:Lucida,tahoma,verdana,arial,sans-serif; color:White; font-weight: bold;
                    font-size: 16px; background-color: #6d84b4; border-right: #1px solid #3b5998;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 29px; width: 400px;text-align: left;">
                    <table>
                        <tr>
                            <td align="center" style="padding-left:10px;">
                                <asp:Label ID="lblResultados_" runat="server" Text="  Resultados" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: auto; width: 400px; background-color: #ffffff; border-bottom: #cccccc 1px inset; text-align: center;" 
                    CssClass="scrollbar"  >
                 
                    <table style="width: 399px; height: 27px; margin-top: 0px;">
                              <tr>
                                  <td style="background-color:#f2f2f2;">
                                  <asp:Panel ID="pnlGvResultados" runat="server" Height="300px" ScrollBars="Vertical" 
                                          CssClass="scrollbar" Width="390px" >
                                                                    <ma:XGridView ID="gvResultadosBusqueda" runat="server" AllowSorting="True" 
                                                                        AutoGenerateColumns="False" BorderWidth="0px" 
                                                                        EmptyDataText="No se encontraron resultados" ExecutePageIndexChanging="True" 
                                                                        OnFilling="GvResultadosBusqueda_Filling" 
                                                                        OnPageIndexChanging="GvResultadosBusqueda_PageIndexChanging" 
                                                                        OnRowCommand="GvResultadosBusqueda_RowCommand" 
                                                                        OnRowDataBound="GvResultadosBusqueda_RowDataBound" 
                                                                        OnRowDeleting="GvResultadosBusqueda_RowDeleting" 
                                                                        OnRowEditing="GvResultadosBusqueda_RowEditing" 
                                                                        OnSelectedIndexChanged="GvResultadosBusqueda_SelectedIndexChanged" 
                                                                        Width="367px">
                                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                        <Columns>
                                                                        
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnContacto"  
                                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                                 CommandName="DatosPersonales" runat="server" Text="View More" ImageUrl="~/Images/persona.gif"/>
                                                                                 
                                                                            </ItemTemplate>
                                                                            
                                                                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                            
                                                                            </asp:TemplateField>
                                                                           
                                                                            <asp:BoundField DataField="NombreYCodigo" ShowHeader="False" Visible="True">
                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                    BorderWidth="0px" />
                                                                                <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                    HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                       
                                                                          <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnRelacion"  
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
                                                                            No se hallaron resultados.
                                                                        </EmptyDataTemplate>
                                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                        <HeaderStyle BackColor="White" BorderStyle="None" />
                                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                        <RowStyle CssClass="gvItem" />
                                                                    </ma:XGridView>
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlMostrarMas" runat="server" Height="15px"  
                                                                    CssClass="scrollbar" Width="390px" >
                                                                    <p  style="vertical-align:middle;" class="gvItem">
                                                                        <asp:LinkButton ID="linkVerMasResultados" runat="server" 
                                                                            onclick="linkVerMasResultados_Click">Mostrar más resultados...</asp:LinkButton>
                                                                    </p>
                                                                    </asp:Panel>
                                  </td>
                                 
                              </tr>
                        </table>
                        <%--</asp:Panel>--%></div>  
     </ContentTemplate>
     </asp:UpdatePanel>
    </asp:panel>
    <asp:panel>
    <asp:updatepanel id="updatePanelGeneral" runat="server" updatemode="Always">
            <ContentTemplate>            
          <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 11px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px;
                                                text-align: left; width: 250px;">
                                                <table>
                                                    <tr>
                                                        <td align="left">
                                                            Últimas búsquedas
                                                         </td>
                                                    </tr>
                                                </table>
                                                 <table style="width:249px;">
                                                    <tr align="center">
                                                        <asp:Repeater runat="server" ID="rptListBR" OnItemCommand="rptListBR_ItemCommand"  >
                                                            <HeaderTemplate>
                                                                <ul>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                              <li><asp:LinkButton id='lnkCR' runat="server" CommandName="CompletarRelaciones" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo") %>'  Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:LinkButton> </li>
                                                              
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </ul>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                                    </table>
                </div>
                  
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <table align="center">
        <tr>
           <td valign="top">
        
                <table style="width: 615px; height: auto;" class="borderCompleto" 
                    cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" align="center">
                            <table cellpadding="0" cellspacing="0" style="height: 59px; width: 601px;">
                                <tr>
                                    <td align="center">
                                        <asp:panel id="pnlBuscarDatos" runat="server">
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px;
                                                text-align: left; width: 603px;">
                                                <table>
                                                    <tr>
                                                        <td align="left">
                                                            Buscar Persona o Empresa
                                                         </td>
                                                    </tr>
                                                </table>
                                            </div>
  
                                            <table style="width:584px;">
                                                    <tr align="center">
                                                        <td>
                                                          <asp:ImageButton ID="btnContactoPersonaSel"  
                                                              OnClick="btnContactoPersonaSel_Click" runat="server" Text="View More" ImageUrl="~/Images/persona.gif"
                                                              Visible="false" />
                                                       
                                                        </td>
                                                        <td >
                                                        <asp:HiddenField ID="hiddenTextBox1" runat="server"/>
                                                        
                                                        <asp:TextBox ID="TextBox1" onkeydown="onTxtKeyDown(event);" 
                                                        runat="server" onkeyup="onTxtKeyUp(event);" AutoCompleteType="Disabled" CssClass="textboxEditor"  MaxLength="40" Width="400px"/>
                                                                                                     
             <asp:Button runat="server" ID="btnSearch"  OnClick="HandleAjaxCall" style="visibility:hidden;" />
                                                        </td>
                                                       
                                    <td style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse; width:100%;" >

                                                  <table>
                                                            <tr>
                                                                   <td>
                                                                        <ma:SecureButton ID="btnLimpiar" runat="server" 
                                                                            CssClass="buttonOver" CssClassDisabled="buttonDisabled"
                                                                        Height="30px" TabIndex="20" Text="Limpiar"
                                                                            Width="115px" onclick="btnLimpiar_Click"
                                                                            Enabled="false"
                                                                         />
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                                   <td>
                                                                        <ma:SecureButton ID="btnTarea" runat="server" 
                                                                           CssClass="buttonOver" CssClassDisabled="buttonDisabled"
                                                                        Height="30px" TabIndex="20" Text="Ver Agenda"
                                                                            Width="115px" onclick="btnTarea_Click"
                                                                            Enabled="false"
                                                                         />
                                                                   </td>
                                                               </tr>
                                                        </table> 
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
                <table style="width: 615px; height: 62%;" class="borderCompleto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <table width="auto" cellpadding="0" cellspacing="0" style="height:auto; vertical-align:top;" >
                                <tr>
                                    <td align="center" valign="top" class="style11">
                                        <asp:panel id="pnlPersonas" runat="server" Width="616px" >
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 615px;
                                                text-align: left; vertical-align:top;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Personas</td>
                                                    </tr>
                                                </table>
                                            </div>
                                         </asp:panel>
                                         <div style="text-align:center;">
                                         <table>
                                               <tr>
                                                  <td>
                                                     <ma:XGridView ID="gvResultadoPersona" runat="server" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BorderWidth="1px" EmptyDataText="No se encontraron resultados"
                                                                        ExecutePageIndexChanging="True" 
                                                                         OnFilling="gvResultadoPersona_Filling" OnPageIndexChanging="gvResultadoPersona_PageIndexChanging"
                                                                        OnRowDataBound="gvResultadoPersona_RowDataBound" OnRowEditing="gvResultadoPersona_RowEditing"
                                                                        OnRowDeleting="gvResultadoPersona_RowDeleting" OnRowCommand="gvResultadoPersona_RowCommand"
                                                                        OnSelectedIndexChanged="gvResultadoPersona_SelectedIndexChanged"
                                                                         Width="600px" ShowHeader="false" RowStyle-CssClass="gvItem" AlternatingRowStyle-CssClass="gvAlternatingItem"
                                                                         RowStyle-BorderWidth="1px">
                                                                        <Columns>
                                                                        
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnContactoPersona"  
                                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                                 CommandName="DatosPersonales" runat="server" Text="View More" ImageUrl="~/Images/persona.gif"/>
                                                                            </ItemTemplate>
                                                                            
                                                                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                                                                            <ItemStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                Width="53px" />
                                                                            
                                                                            </asp:TemplateField>
                                                                           
                                                                            <asp:BoundField DataField="NombreYCodigo" ShowHeader="False" Visible="True">
                                                                                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" 
                                                                                    BorderWidth="0px" />
                                                                                <ItemStyle BackColor="#FFFF99" BorderColor="White" BorderStyle="None" 
                                                                                    HorizontalAlign="Left" Width="500px" />
                                                                            </asp:BoundField>
                                                                       
                                                                          <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnRelacionPersona"  
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
                                         </div>
                                          <asp:panel id="pnlResultadoEmpresa" runat="server" Width="616px" >
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 615px;
                                                text-align: left; vertical-align:top;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Empresa</td>
                                                    </tr>
                                                </table>
                                            </div>
                                         </asp:panel>
                                          <div style="text-align:center;">
                                              <table>
                                                    <tr>
                                                        <td>
                                                          <ma:XGridView ID="gvResultadoEmpresa" runat="server" AllowSorting="True"
                                                                            AutoGenerateColumns="False" BorderWidth="1px" EmptyDataText="No se encontraron resultados"
                                                                            ExecutePageIndexChanging="True" 
                                                                            OnFilling="gvResultadoEmpresa_Filling" OnPageIndexChanging="gvResultadoEmpresa_PageIndexChanging"
                                                                            OnRowDataBound="gvResultadoEmpresa_RowDataBound" OnRowEditing="gvResultadoEmpresa_RowEditing"
                                                                            OnRowDeleting="gvResultadoEmpresa_RowDeleting" OnRowCommand="gvResultadoEmpresa_RowCommand"
                                                                            OnSelectedIndexChanged="gvResultadoEmpresa_SelectedIndexChanged"
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
                                                                           
                                                                                <asp:BoundField DataField="NombreYCodigo" ShowHeader="False" Visible="True">
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
                                         </div>
                                    </td>
                                    <td style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse; width:100%;" >
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <ma:SecureButton ID="btnNuevaRelacionPersona" runat="server" 
                                                                 CssClass="buttonOver" CssClassDisabled="buttonDisabled"
                                                            Height="30px" TabIndex="20" Text="Nueva Relación" 
                                                                Width="115px" onclick="btnNuevaRelacionPersona_Click"
                                                                />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ma:SecureButton ID="btnVerRelacionPersona" runat="server" CssClass="buttonOver"
                                                            CssClassDisabled="buttonDisabled"
                                                            Height="30px" TabIndex="20" Text="Ver Relación" Width="115px"
                                                            onclick="btnVerRelacionPersona_Click"
                                                                />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ma:SecureButton ID="btnModificarRelacionPersona" runat="server" CssClass="buttonOver"
                                                            CssClassDisabled="buttonDisabled"
                                                            Height="30px" TabIndex="20" Text="Modif. Relación"  Width="115px"
                                                            onclick="btnModificarRelacionPersona_Click"
                                                                />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ma:SecureButton ID="btnEliminarRelacionPersona" runat="server" CssClass="buttonOver"
                                                            CssClassDisabled="buttonDisabled"
                                                            Height="30px" TabIndex="20" Text="Elim. Relación" Width="115px"
                                                                onclick="btnEliminarRelacionPersona_Click"
                                                                />
                                                        </td>
                                                    </tr>
                                                    <tr> 
                                                        <td>
                                                            <ma:SecureButton ID="btnResumendelContacto" runat="server" CssClass="buttonOver"
                                                                    CssClassDisabled="buttonDisabled"
                                                                    Height="30px" TabIndex="20" Text="Resumen"  Width="115px"
                                                                        onclick="btnResumendelContacto_Click"
                                                                        />
                                                        </td>
                                                    </tr>
                                            </table> 
                                     </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
                
    </ContentTemplate>
    </asp:updatepanel>
    </asp:panel>
    <%--    </form>
</body>--%>
    <myPopupDeDatos:popupPersona ID="myPopupPersona" runat="server" />
    <myPopupDeDatos:popupEmpresa ID="myPopupEmpresa" runat="server" />
    <myPopupDeDatos:BuscarContacto ID="popupBuscarContacto" runat="server" />
    <myPopupDeDatos:BuscarContactoEmpresa ID="popupBuscarContactoEmpresa" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
    <style type="text/css">
        .style10
        {
            width: 87px;
        }
        .style11
        {
            width: 800px;
        }
    </style>
</asp:Content>
