using System;
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
using Common.DataContracts;
using System.Collections.Generic;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.services;


public partial class Vistas_UCPopupBuscarRelacion : System.Web.UI.UserControl
{
    //private string m_TargetControlID = "TextBox1_BuscarRelacion"; // Solo para que no falle.
    //private AjaxControlToolkit.PopupControlPopupPosition m_Position = AjaxControlToolkit.PopupControlPopupPosition.Bottom;

    //public delegate void OnPopupClose();
    //public event  OnPopupClose onCloseHandler;
    

    public delegate void UCPopupBuscarRelacionCommandEventHandler(UCPopupBuscarRelacionCommandEventArgs e);
    public event UCPopupBuscarRelacionCommandEventHandler UCPopupBuscarRelacionSelected;

    public class UCPopupBuscarRelacionCommandEventArgs
    {
        public EmpresaPersonaDataContracts empresaPersona { get; protected set; }

        public UCPopupBuscarRelacionCommandEventArgs(EmpresaPersonaDataContracts empresaPersona)
        {
            this.empresaPersona = empresaPersona;
        }
    }

    private static int cant;

    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderBuscarRelacion
    {
        get { return this.PopupResultados_BuscarRelacion; }
    }

    /*public string TargetControlID 
        {

        get { return m_TargetControlID; }

        set { m_TargetControlID = value; }

    }

    public AjaxControlToolkit.PopupControlPopupPosition Position 
        {

        get { return m_Position; }

        set { m_Position = value; }

    }*/


    protected void Page_Load(object sender, EventArgs e)
    {
        //this.PopupResultados_BuscarRelacion.Position =  m_Position;
        //this.PopupResultados_BuscarRelacion.TargetControlID = m_TargetControlID;
        this.btnCerrarBuscarRelacion.OnClientClick = " return CerrarPanelResultados_BuscarRelacion_" + ClientID + "();";
        this.TextBox1_BuscarRelacion.Attributes.Add("onkeyup", "onTxtKeyUp_BuscarRelacion_" + ClientID + "(this);");
        this.TextBox1_BuscarRelacion.Attributes.Add("onkeydown", "onTxtKeyDown_BuscarRelacion_" + ClientID + "(this);");
        if (!Page.IsPostBack)
        {
            this.TextBox1_BuscarRelacion.Text = "";
            cant = 1000;
            List<EmpresaPersonaDataContracts> listaVacia = new List<EmpresaPersonaDataContracts>();
            DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(listaVacia);
        }
    }

    public void SetDatosModalPopupExtenderDatos(List<PersonaDataContracts> personaDataContracts)
    {
        //this.personaDetalle.DataSource = personaDataContracts;
        //this.personaDetalle.DataBind();

    }

    protected void HandleAjaxCall_BuscarRelacion(object sender, EventArgs e)
    {
        var len = TextBox1_BuscarRelacion.Text.Length;
        if (len == 0) cant = 1000;
        List<EmpresaPersonaDataContracts> empresasPersonas;
        List<EmpresaPersonaDataContracts> empresas;
        List<EmpresaPersonaDataContracts> personas;
        if (Session["empresasPersonas"] != null)
        {
            empresasPersonas = (List<EmpresaPersonaDataContracts>)Session["empresasPersonas"];
            empresasPersonas =
                empresasPersonas.Where(p => p.Nombre.ToUpper().Contains(TextBox1_BuscarRelacion.Text.ToUpper())).ToList();

            if (string.IsNullOrEmpty(TextBox1_BuscarRelacion.Text))
            {
                empresasPersonas.Clear();
            }
        }
        else
        {
            var empresasPersonasService =
                ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
            empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaPorCantidad(cant, TextBox1_BuscarRelacion.Text);
            Session["empresasPersonas"] = empresasPersonas;
        }
        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresasPersonas);
        gvResultadosBusqueda_BuscarRelacion.DataSource = dt;
        gvResultadosBusqueda_BuscarRelacion.DataBind();
        if (empresasPersonas.Count > 0)
        {

            ScriptManager.RegisterStartupScript(Page, GetType(), "AbrirPanelResultados_BuscarRelacion",
                                                "javascript:AbrirPanelResultados_BuscarRelacion_"+this.ClientID+"();", true);
        }
        /*else {
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados_BuscarRelacion",
                                                "javascript:CerrarPanelResultados_BuscarRelacion();", true);
        }*/

        ScriptManager.RegisterStartupScript(Page, GetType(), "PosicionarAlFinal_BuscarRelacion",
                                            "javascript:establerCursorPosicion_BuscarRelacion_"+this.ClientID+"(" + len + ");", true);
    }

    protected void GvResultadosBusqueda_BuscarRelacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int a;
    }

    protected void GvResultadosBusqueda_BuscarRelacion_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int len = TextBox1_BuscarRelacion.Text.Length;
        string textoABuscar = TextBox1_BuscarRelacion.Text;
        // int codigo = int.Parse(this.gvResultadosBusqueda.Rows[e.NewEditIndex].Cells[1].Text.Split('(')[1].Replace(")", string.Empty));
        int codigo = int.Parse(this.gvResultadosBusqueda_BuscarRelacion.Rows[e.NewEditIndex].Cells[1].Text.Split('#')[1].Replace(")", string.Empty).Replace("(", string.Empty));
        List<EmpresaPersonaDataContracts> empresasPersonas;
        List<EmpresaPersonaDataContracts> empresas = new List<EmpresaPersonaDataContracts>();
        List<EmpresaPersonaDataContracts> personas = new List<EmpresaPersonaDataContracts>();
        IEmpresaPersonaService empresasPersonasService =
            ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaRelaciones(codigo.ToString());

        foreach (var empresaPersonaDataContract in empresasPersonas)
        {
            if (empresaPersonaDataContract.Tipo.ToUpper().Equals("PERSONA"))
            {
                personas.Add(empresaPersonaDataContract);
            }
            if (empresaPersonaDataContract.Tipo.ToUpper().Equals("EMPRESA"))
            {
                empresas.Add(empresaPersonaDataContract);
            }
        }

    }


    private void GvResultadosGeneric_BuscarRelacion_RowCommand(object sender, GridViewCommandEventArgs e, GridView gv)
    {
        int codigo;
        int index = Convert.ToInt32(e.CommandArgument.ToString());

        string rowText = HttpUtility.HtmlDecode(gv.Rows[index].Cells[1].Text);
        int idxText = rowText.IndexOf("#(");
        string sCodigo = rowText.Substring(idxText + 2).Replace(")", string.Empty).Replace("(", string.Empty);
        codigo = int.Parse(sCodigo);
        string descripcion = rowText.Substring(0, idxText);

        if (e.CommandName == "Relaciones")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados2_BuscarRelacion",
                             "javascript:CerrarPanelResultados_BuscarRelacion_"+this.ClientID+"();", true);
        }

        //CompletarRelaciones(codigo);
        //this.TextBox1_BuscarRelacion.Text = descripcion; //this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[0];
    }

    protected void GvResultadosBusqueda_BuscarRelacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.GvResultadosGeneric_RowCommand(sender, e, this.gvResultadosBusqueda_BuscarRelacion);

    }

    private void CompletarRelaciones(int codigo)
    {
        int len = TextBox1_BuscarRelacion.Text.Length;
        string textoABuscar = TextBox1_BuscarRelacion.Text;

        IEmpresaPersonaService empresasPersonasService =
            ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");

        // Persona o Empresa seleccionada en el popup busqueda.
        try
        {
            EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(codigo);
            if (empresaPersona != null)
            {
                this.TextBox1_BuscarRelacion.ToolTip = empresaPersona.Tipo.ToUpper();
                if (empresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                {
                    this.TextBox1_BuscarRelacion.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
                }
                else
                {
                    this.TextBox1_BuscarRelacion.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
                }

                // Notificamos a los clientes del UC que se hizo la seleccion de la persona/empresa
                if (this.UCPopupBuscarRelacionSelected != null)
                    UCPopupBuscarRelacionSelected(new UCPopupBuscarRelacionCommandEventArgs(empresaPersona));

            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }


    }

    protected void GvResultadosBusqueda_BuscarRelacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected DataTable GvResultadosBusqueda_BuscarRelacion_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }
    protected void GvResultadosBusqueda_BuscarRelacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void linkVerMasResultados_BuscarRelacion_Click(object sender, EventArgs e)
    {
        int len = TextBox1_BuscarRelacion.Text.Length;
        List<EmpresaPersonaDataContracts> empresasPersonas;
        IEmpresaPersonaService empresasPersonasService =
            ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        cant = cant * 2;
        empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaPorCantidad(cant, TextBox1_BuscarRelacion.Text);
        Session["empresasPersonas"] = empresasPersonas;
        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresasPersonas);
        gvResultadosBusqueda_BuscarRelacion.DataSource = dt;
        gvResultadosBusqueda_BuscarRelacion.DataBind();
        if (empresasPersonas.Count > 0)
            ScriptManager.RegisterStartupScript(Page, GetType(), "AbrirPanelResultados_BuscarRelacion",
                                                "javascript:AbrirPanelResultados_BuscarRelacion_"+this.ClientID+"();", true);
        else
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados_BuscarRelacion",
                                                "javascript:CerrarPanelResultados_BuscarRelacion_"+this.ClientID+"();", true);

        ScriptManager.RegisterStartupScript(Page, GetType(), "PosicionarAlFinal_BuscarRelacion",
                                            "javascript:establerCursorPosicion_BuscarRelacion_"+this.ClientID+"(" + len + ");", true);
    }


    private void GvResultadosGeneric_RowCommand(object sender, GridViewCommandEventArgs e, GridView gv)
    {
        int codigo;
        int index = Convert.ToInt32(e.CommandArgument.ToString());

        string rowText = HttpUtility.HtmlDecode(gv.Rows[index].Cells[1].Text);
        int idxText = rowText.IndexOf("#(");
        string sCodigo = rowText.Substring(idxText + 2).Replace(")", string.Empty).Replace("(", string.Empty);
        codigo = int.Parse(sCodigo);
        string descripcion = rowText.Substring(0, idxText);

        this.TextBox1_BuscarRelacion.Text = descripcion; //this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[0];
        if (e.CommandName == "Relaciones")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados2_BuscarRelacion",
                             "javascript:CerrarPanelResultados_BuscarRelacion_"+this.ClientID+"();", true);
        }

        CompletarRelaciones(codigo);
        //this.TextBox1_BuscarRelacion.Text = descripcion; //this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[0];

    }

    protected void GvResultadosBusqueda_BuscarRelacion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
