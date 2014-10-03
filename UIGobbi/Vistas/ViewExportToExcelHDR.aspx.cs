﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;
using Common.DataContracts;

public partial class Vistas_ViewExportToExcelHDR : GobbiPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        try
        {
            HojaDeRutaExcelDataContracts hr = (HojaDeRutaExcelDataContracts)Session["CACHE_TAREAS_A_EXPORTAR"];
            System.IO.File.Delete(Server.MapPath("Files\\TareasAgenda.xls"));

            if (hr != null)
            {

                ExcelXmlWriter.ExcelExport.Generate(Server.MapPath(".") + "\\Files\\TareasAgenda.xls", hr);


            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment;filename=TareasAgenda.xls");
            //Response.ContentType = "application/vnd.ms-excel";

            Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.WriteFile("/Vistas/Files/TareasAgenda.xls");
            Response.Charset = "";
            Response.Flush();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorExcel", "javascript:alert('Ha ocurrido un error al intentar generar el archivo Excel. Detalle Técnico:  " + ex.Message +"');", true);
        }

    }
}
