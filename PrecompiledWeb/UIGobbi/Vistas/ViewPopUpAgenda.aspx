<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" theme="SampleSiteTheme" enableeventvalidation="false" autoeventwireup="true" inherits="Vistas_ViewPopUpAgenda, App_Web_a43a33gs" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<%@ Register Src="~/UserControls/UCPopupEditarTarea.ascx" TagPrefix="myPopupDeDatos"
    TagName="EditarTarea" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <myPopupDeDatos:EditarTarea ID="popupEditarTarea" runat="server" />

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

    <script type="text/javascript">
<!--
$(document).ready(function()
{
    setTimeout('abrirPopupAgenda1()', 200);
});
-->

function abrirPopupAgenda1() 
{
      varModalPopupAbierto = ModalPopupResultados_EditarTarea;
      $find(ModalPopupResultados_EditarTarea).show();

}

</script>
    
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
