using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.services;
using System.Web;

public partial class Vistas_ViewRelaciones : GobbiPage
{
    private static int cant;
    private static int _i = 0;
    private EmpresaPersonaDataContracts empresaPersonaSelected;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // this.TextBox1.Focus();
        this.popupBuscarRelacion.UCPopupBuscarRelacionSelected += new Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventHandler(popupBuscarRelacion_UCPopupBuscarRelacionSelected);

        this.popupEditarRelacion.UCPopupEditarRelacion_Saved += new Vistas_UCPopupEditarRelacion.UCPopupEditarRelacion_SavedEventHandler(popupEditarRelacion_UCPopupEditarRelacion_Saved);

       
        //this.btnSearch.Visible = false;
        if (!Page.IsPostBack)
        {
            this.TextBox1.BackColor = System.Drawing.Color.White;
            deshabilitarBotonesABMRelacion();
            cant = 1000;
            List<EmpresaPersonaDataContracts> listaVacia = new List<EmpresaPersonaDataContracts>();
            DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(listaVacia);
            this.gvResultadoPersona.DataSource = dt;
            gvResultadoPersona.DataBind();
            this.gvResultadoEmpresa.DataSource = dt;
            gvResultadoEmpresa.DataBind();

            List<EmpresaPersonaDataContracts> lstBusquedasRecientes = (List<EmpresaPersonaDataContracts>)Session["busquedasRecientes"];
            if (lstBusquedasRecientes == null)
            {
                lstBusquedasRecientes = new List<EmpresaPersonaDataContracts>();
                Session["busquedasRecientes"] = lstBusquedasRecientes;

            }

            List<EmpresaPersonaDataContracts> reverseList = new List<EmpresaPersonaDataContracts>(lstBusquedasRecientes);
            reverseList.Reverse();
            rptListBR.DataSource = reverseList;
            rptListBR.DataBind();

            //IEmpresaPersonaService empresasPersonasService =
            //    ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
            //var empresasPersonas = new List<EmpresaPersonaDataContracts>();
            //empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaPorCantidad(8, "in");
            //Session["empresasPersonas"] = empresasPersonas;
        }
    }

    void popupEditarRelacion_UCPopupEditarRelacion_Saved()
    {
        EmpresaPersonaDataContracts empresaPersonaDc = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];

        CargarGrillasPersonasEmpresas(int.Parse(empresaPersonaDc.Codigo));
        //throw new NotImplementedException();
    }

    void popupBuscarRelacion_UCPopupBuscarRelacionSelected(Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventArgs e)
    {
        Console.Write(e.empresaPersona.NombreYCodigo);
        //throw new NotImplementedException();
    }  
  
    //protected void GvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //    //List<string> lista = new List<string>();
    //    //ICacheManager mgr = CacheFactory.GetCacheManager("CacheManagerMagic");

    //    //if (Session["SeleccionGrilla"] != null)
    //    //    lista = (List<string>)Session["SeleccionGrilla"];

    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{
    //    //    string key = e.Row.Cells[4].Text;

    //    //    if (lista.Find(delegate(string dk) { return dk.Equals(key); }) != null)
    //    //    {
    //    //        ((CheckBox)e.Row.Cells[0].Controls[0]).Checked = true;
    //    //    }

    //    //}
    //}
    //protected void GvResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    //this.GvResultados.PageIndex = e.NewPageIndex;
    //    //this.GvResultados.Fill();

    //    //if (Session["busquedaDataContracts"] != null)
    //    //{
    //    //    BusquedaDataContracts busquedaDataContracts = (BusquedaDataContracts)Session["busquedaDataContracts"];
    //    //    busquedaDataContracts.NumPage = e.NewPageIndex;
    //    //}

    //}
    //protected void GvResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    //IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
    //    //try
    //    //{
    //    //    deudorServices.DesactivarPorId(int.Parse(GvResultados.Rows[e.RowIndex].Cells[3].Text));
    //    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Ok", "javascript:alert('Se ha eliminado correctamente el deudor.');", true);
    //    //}
    //    //catch (Exception Ex)
    //    //{
    //    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Eliminar Fallo", "javascript:alert('Ha ocurrido un error. No se pudo eliminar el deudor. Detalle tecnico: " + Ex.Message + "');", true);
    //    //}

    //    //DataTable dataTable = GetDataTableDeudores();
    //    //this.GvResultados.DataSource = dataTable;
    //    //this.GvResultados.DataBind();
    //    //this.lblResultado.Text = "Resultados Obtenidos: " + dataTable.Rows.Count.ToString();
    //}
    //protected void GvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    //if (e.CommandName == "Select")
    //    //{
    //    //    ClienteDataContracts client = new ClienteDataContracts();
    //    //    IClienteService clienteServices = ServiceClient<IClienteService>.GetService("ClienteService");
    //    //    client = clienteServices.GetClientePorDeudor(decimal.Parse(this.GvResultados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text));


    //    //    if (client != null)
    //    //    {
    //    //        this.TabContainer1.ActiveTabIndex = 1;
    //    //        this.UpdatePanelTabContainer.Update();

    //    //    }

    //    //}

    //}
    //protected void GvResultados_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    //int idDomicilioDeudor =
    //    //    int.Parse(
    //    //        GvResultados.Rows[e.NewEditIndex].Cells[
    //    //            Herramientas.UIUtils.GetPosCol(GvResultados, "idDomicilioDeudor")].Text);

    //    //int idDeudor = int.Parse(
    //    //        GvResultados.Rows[e.NewEditIndex].Cells[
    //    //            Herramientas.UIUtils.GetPosCol(GvResultados, "idDeudor")].Text);
    //    //Response.Redirect("ViewAltaDeudor.aspx?Id_Deudor=" + idDeudor.ToString() + "&idDomicilioDeudor=" + idDomicilioDeudor.ToString(), true);
    //}
    //protected DataTable GvResultados_Filling(object sender, EventArgs e)
    //{
    //    DataTable dataTable = new DataTable();
    //    return dataTable;
    //}
   
    protected void txtPersona_TextChanged(object sender, EventArgs e)
    {
        if (Session["ResultadoBusqueda"] != null)
        {
            var personasLiviano = (List<PersonaLivianoDataContracts>)Session["ResultadoBusqueda"];
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //IPersonaLivianoService personaLivianoService = ServiceClient<IPersonaLivianoService>.GetService("PersonaLivianoService");
        //List<PersonaLivianoDataContracts> personasLiviano = new List<PersonaLivianoDataContracts>();
        //personasLiviano = personaLivianoService.GetAllPersonaLivianos();
        //this.GvResultados.DataSource = ConvertDataTable<PersonaLivianoDataContracts>.Convert(personasLiviano);
        //this.GvResultados.DataBind();
        //Session["ResultadoBusqueda"] = personasLiviano;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
    }

    protected void txtBusqueda_TextChanged(object sender, EventArgs e)
    {
    }

    protected void HandleAjaxCall(object sender, EventArgs e)
    {
        Session["EmpresaPersona"] = null;
        deshabilitarBotonesABMRelacion();
        var len = TextBox1.Text.Length;
        if (len == 0) cant = 1000;
        List<EmpresaPersonaDataContracts> empresasPersonas;
        List<EmpresaPersonaDataContracts> empresas;
        List<EmpresaPersonaDataContracts> personas;
        //if (Session["empresasPersonas"] != null)
        //{
            empresasPersonas = (List<EmpresaPersonaDataContracts>)Session["empresasPersonas"];
                
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                empresasPersonas.Clear();
                Session["empresasPersonas"] = null;
            }
            else
            {
            //    empresasPersonas =
            //        empresasPersonas.Where(p => p.Nombre.ToUpper().Contains(TextBox1.Text.ToUpper())).ToList();

                //empresas =
                //                empresasPersonas.Where(p => p.Tipo.ToUpper().Contains("EMPRESA")).ToList();
                //personas =
                //                empresasPersonas.Where(p => p.Tipo.ToUpper().Contains("PERSONA")).ToList();

            //    if (empresasPersonas != null && empresasPersonas.Count == 0)
            //    {
                    var empresasPersonasService =
                    ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
                    empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaPorCantidad(cant, TextBox1.Text);
                    Session["empresasPersonas"] = empresasPersonas;
            //    }

            }

        //}
        //else
       // {
        //    var empresasPersonasService =
        //        ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        //    empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaPorCantidad(cant, TextBox1.Text);
        //    Session["empresasPersonas"] = empresasPersonas;
       // }

        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresasPersonas);
        gvResultadosBusqueda.DataSource = dt;
        gvResultadosBusqueda.DataBind();
        if (empresasPersonas.Count > 0)
        {

            ScriptManager.RegisterStartupScript(Page, GetType(), "AbrirPanelResultados",
                                                "javascript:AbrirPanelResultados();", true);
        }
        else
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados",
                                                "javascript:CerrarPanelResultados();", true);

        ScriptManager.RegisterStartupScript(Page, GetType(), "PosicionarAlFinal", "javascript:establerCursorPosicion(" + len + ");", true);
    }

    protected void GvResultadosBusqueda_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int a;
    }

    protected void GvResultadosBusqueda_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int codigo = int.Parse(this.gvResultadosBusqueda.Rows[e.NewEditIndex].Cells[1].Text.Split('#')[1].Replace(")", string.Empty).Replace("(", string.Empty));
        this.CargarGrillasPersonasEmpresas(codigo);
    }

    private void CargarGrillasPersonasEmpresas(int codigo)
    {
        int len = TextBox1.Text.Length;
        string textoABuscar = TextBox1.Text;
        // int codigo = int.Parse(this.gvResultadosBusqueda.Rows[e.NewEditIndex].Cells[1].Text.Split('(')[1].Replace(")", string.Empty));
        //int codigo = int.Parse(this.gvResultadosBusqueda.Rows[e.NewEditIndex].Cells[1].Text.Split('#')[1].Replace(")", string.Empty).Replace("(", string.Empty));
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
        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresas);
        gvResultadoEmpresa.DataSource = dt;
        gvResultadoEmpresa.DataBind();
        DataTable dt2 = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(personas);
        gvResultadoPersona.DataSource = dt2;
        gvResultadoPersona.DataBind();

    }

    protected void GvResultadosBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GvResultadosBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        // if (e.Row.RowType == DataControlRowType.DataRow)

        //{

        //  //Adicona o Atributo ID com o valor de _i

        //  //A primeira vez é igual a 0(zero).

        //  e.Row.Attributes.Add("id", _i.ToString());



        //  //Adiciona o atribute de onKeyDown pra ver qual seta foi pressionada.


        //  e.Row.Attributes.Add("onKeyDown", "NavegarComTeclado();");



        //  e.Row.Attributes.Add("onClick", "MarcarLinha(" + _i.ToString() + ");");



        //  //Incrementa a valiável _i.

        //  _i++;

        // }




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

        if (e.CommandName == "Relaciones")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados2",
                             "javascript:CerrarPanelResultados();", true);

            CompletarRelaciones(codigo);
            this.TextBox1.Text = descripcion; //this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[0];
            this.TextBox1.Enabled = false;
            this.btnContactoPersonaSel.Visible = true;
            this.btnLimpiar.Enabled = true;
            this.btnTarea.Enabled = true;

            if (Session["EmpresaPersona"] != null)
            {
                EmpresaPersonaDataContracts empresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];

                List<EmpresaPersonaDataContracts> lstBusquedasRecientes = (List<EmpresaPersonaDataContracts >)Session["busquedasRecientes"];
                if (lstBusquedasRecientes == null)
                {
                    lstBusquedasRecientes = new List<EmpresaPersonaDataContracts >();
                    Session["busquedasRecientes"] = lstBusquedasRecientes;

                }

                lstBusquedasRecientes.Insert(lstBusquedasRecientes.Count, empresaPersona);
                List<EmpresaPersonaDataContracts > reverseList = new List<EmpresaPersonaDataContracts >(lstBusquedasRecientes);
                reverseList.Reverse();
                rptListBR.DataSource = reverseList;
                rptListBR.DataBind();

            }
            
        }
        else if (e.CommandName == "DatosPersonales")
        {
            IEmpresaPersonaService empresasPersonasService =
            ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");

            // Persona o Empresa seleccionada en el popup busqueda.
            EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(codigo);
            if (gv.ID.ToLower().EndsWith("empresa"))
            {
                this.myPopupEmpresa.EmpresaPersona = empresaPersona;
                this.myPopupEmpresa.ModalPopupExtenderDatosEmpresa.Show();
            }
            else if (gv.ID.ToLower().EndsWith("persona"))
            {
                this.myPopupPersona.EmpresaPersona = empresaPersona;
                this.myPopupPersona.ModalPopupExtenderDatos.Show();
            }
        }
        // Habilito botones Nueva Relacion.
        this.btnNuevaRelacionPersona.Enabled = true;
        //this.btnNuevaRelacionEmpresa.Enabled = true;
    }

    protected void rptListBR_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "CompletarRelaciones")
        {
            LinkButton btn = e.CommandSource as LinkButton;

            int codigo = Convert.ToInt32(e.CommandArgument.ToString());
            this.CompletarRelaciones(codigo);
            this.TextBox1.Text = btn.Text ; //this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[0];
            this.TextBox1.Enabled = false;
            this.btnContactoPersonaSel.Visible = true;
            this.btnLimpiar.Enabled = true;
            this.btnTarea.Enabled = true;

            // [Steve] removed UpdatePanel2.Update()
        }
    }
    protected void GvResultadosBusqueda_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.GvResultadosGeneric_RowCommand(sender, e, this.gvResultadosBusqueda);

        /*   int codigo;
          int index = Convert.ToInt32(e.CommandArgument.ToString());
        
          string rowText = HttpUtility.HtmlDecode(this.gvResultadosBusqueda.Rows[index].Cells[1].Text);
          int idxText = rowText.IndexOf("#(");
          string sCodigo = rowText.Substring(idxText+2).Replace(")", string.Empty).Replace("(",string.Empty);
          codigo = int.Parse(sCodigo);
          string descripcion = rowText.Substring(0, idxText);

          //codigo = int.Parse(this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[1].Replace(")", string.Empty).Replace("(",string.Empty));
        
          if (e.CommandName == "Relaciones")
          {
               ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados2",
                                "javascript:CerrarPanelResultados();", true);
          }
       
          CompletarRelaciones(codigo);
          this.TextBox1.Text = descripcion; //this.gvResultadosBusqueda.Rows[index].Cells[1].Text.Split('#')[0];
         */
    }

    private void CompletarRelaciones(int codigo)
    {
        int len = TextBox1.Text.Length;
        string textoABuscar = TextBox1.Text;

        List<EmpresaPersonaDataContracts> empresas = new List<EmpresaPersonaDataContracts>();
        List<EmpresaPersonaDataContracts> personas = new List<EmpresaPersonaDataContracts>();
        empresas.Clear();
        personas.Clear();
        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresas);
        gvResultadoEmpresa.DataSource = dt;
        gvResultadoEmpresa.DataBind();
        DataTable dt2 = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(personas);
        gvResultadoPersona.DataSource = dt2;
        gvResultadoPersona.DataBind();

        List<EmpresaPersonaDataContracts> empresasPersonas;

        IEmpresaPersonaService empresasPersonasService =
            ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");

        // Persona o Empresa seleccionada en el popup busqueda.
        try
        {
            EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(codigo);
            if (empresaPersona != null)
            {
                // Establecemos la empresa o persona seleccionada en la busqueda.
                this.empresaPersonaSelected = empresaPersona;
                Session["EmpresaPersona"] = empresaPersona;
                this.TextBox1.ToolTip = empresaPersona.Tipo.ToUpper();
                if (empresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                {
                    this.TextBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
                }
                else
                {
                    this.TextBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }

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


        dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresas);
        gvResultadoEmpresa.DataSource = dt;
        gvResultadoEmpresa.DataBind();
        dt2 = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(personas);
        gvResultadoPersona.DataSource = dt2;
        gvResultadoPersona.DataBind();
    }

    protected void GvResultadosBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected DataTable GvResultadosBusqueda_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }

    protected void linkVerMasResultados_Click(object sender, EventArgs e)
    {
        int len = TextBox1.Text.Length;
        List<EmpresaPersonaDataContracts> empresasPersonas;
        IEmpresaPersonaService empresasPersonasService =
            ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        cant = cant * 2;
        empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaPorCantidad(cant, TextBox1.Text);
        Session["empresasPersonas"] = empresasPersonas;
        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresasPersonas);
        gvResultadosBusqueda.DataSource = dt;
        gvResultadosBusqueda.DataBind();
        if (empresasPersonas.Count > 0)
            ScriptManager.RegisterStartupScript(Page, GetType(), "AbrirPanelResultados",
                                                "javascript:AbrirPanelResultados();", true);
        else
            ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados",
                                                "javascript:CerrarPanelResultados();", true);

        ScriptManager.RegisterStartupScript(Page, GetType(), "PosicionarAlFinal", "javascript:establerCursorPosicion(" + len + ");", true);
    }

    protected void gvResultadoEmpresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvResultadoEmpresa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //add css to GridViewrow based on rowState
            //e.Row.CssClass = e.Row.RowState.ToString();
            //Add onclick attribute to select row.
            //e.Row.Attributes.Add("onClick", "javascript:void SelectRow(this);");
            e.Row.Attributes.Add("onClick", "javascript:void SelectRow('empresa', this);");
        }
    }

    protected void gvResultadoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected DataTable gvResultadoEmpresa_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }

    protected void gvResultadoEmpresa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void gvResultadoEmpresa_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvResultadoEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.GvResultadosGeneric_RowCommand(sender, e, this.gvResultadoEmpresa);
        /*   int codigo;
           int index = Convert.ToInt32(e.CommandArgument.ToString());
           codigo = int.Parse(this.gvResultadoEmpresa.Rows[index].Cells[1].Text.Split('#')[1].Replace(")", string.Empty).Replace("(",string.Empty));
           this.TextBox1.Text = this.gvResultadoEmpresa.Rows[index].Cells[1].Text.Split('#')[0];
           if (e.CommandName == "Relaciones")
           {
               ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados2",
                                "javascript:CerrarPanelResultados();", true);
           }
        
           CompletarRelaciones(codigo);
          */
    }

    protected DataTable gvResultadoPersona_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }

    protected void gvResultadoPersona_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void gvResultadoPersona_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //add css to GridViewrow based on rowState
            //e.Row.CssClass = e.Row.RowState.ToString();
            //Add onclick attribute to select row.
            //e.Row.Attributes.Add("onClick", "javascript:void SelectRow(this);");
            e.Row.Attributes.Add("onClick", "javascript:void SelectRow('persona', this);");
        }
    }

    protected void gvResultadoPersona_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvResultadoPersona_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvResultadoPersona_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.GvResultadosGeneric_RowCommand(sender, e, this.gvResultadoPersona);

        /*        int codigo;
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                codigo = int.Parse(this.gvResultadoPersona.Rows[index].Cells[1].Text.Split('#')[1].Replace(")", string.Empty).Replace("(", string.Empty));
                this.TextBox1.Text = this.gvResultadoPersona.Rows[index].Cells[1].Text.Split('#')[0];
                if (e.CommandName == "Relaciones")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "CerrarPanelResultados2",
                                     "javascript:CerrarPanelResultados();", true);
                }
        
                CompletarRelaciones(codigo);
          */
    }

    protected void gvResultadoPersona_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnNuevaRelacionPersona_Click(object sender, EventArgs e)
    {
        //EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
        //epdc.Codigo = "1";
        //epdc.Nombre = "Gabriel San Blas";
        this.popupEditarRelacion.LimpiarPopup();
        this.popupEditarRelacion.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarRelacion.MODO = "Crear";
        this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.Show();

        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarRelacion", "javascript:abrirPopupEditarRelacion();", true);
        
        //this.popupBuscarRelacion.ModalPopupExtenderBuscarRelacion.Show();
        //this.myPopup.ModalPopupExtenderDatos.Show();
        //this.popupEditarRelacion
        //this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.r
        //this.

    }
    
    protected void btnModificarRelacionPersona_Click(object sender, EventArgs e)
    {
        this.popupEditarRelacion.LimpiarPopup();
        EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
        string[] arrayEmpresaPersona = this.HiddenPersonaSelected.Value.Split('#');
        epdc.Nombre = arrayEmpresaPersona[0];
        epdc.Codigo = arrayEmpresaPersona[1].Split('(')[1].Split(')')[0];
        epdc.Tipo = arrayEmpresaPersona[2].ToUpper();
        this.popupEditarRelacion.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarRelacion.EmpresaPersona2 = epdc;
        this.popupEditarRelacion.MODO = "Editar";
        this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarRelacion", "javascript:abrirPopupEditarRelacion();", true);

    }

    protected void btnVerRelacionPersona_Click(object sender, EventArgs e)
    {
        this.popupEditarRelacion.LimpiarPopup();
        EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
        string[] arrayEmpresaPersona = this.HiddenPersonaSelected.Value.Split('#');
        epdc.Nombre = arrayEmpresaPersona[0];
        epdc.Codigo = arrayEmpresaPersona[1].Split('(')[1].Split(')')[0];
        epdc.Tipo = arrayEmpresaPersona[2].ToUpper();
        this.popupEditarRelacion.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarRelacion.EmpresaPersona2 = epdc;
        this.popupEditarRelacion.MODO = "Ver";
        this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarRelacion", "javascript:abrirPopupEditarRelacion();", true);

    }    

    
    protected void btnModificarRelacionEmpresa_Click(object sender, EventArgs e)
    {
        this.popupEditarRelacion.LimpiarPopup();
        EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
        string[] arrayEmpresaPersona = this.HiddenEmpresaSelected.Value.Split('#');
        epdc.Nombre = arrayEmpresaPersona[0];
        epdc.Codigo = arrayEmpresaPersona[1].Split('(')[1].Split(')')[0];
        epdc.Tipo = arrayEmpresaPersona[2].ToUpper();
        this.popupEditarRelacion.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarRelacion.EmpresaPersona2 = epdc;
        this.popupEditarRelacion.MODO = "Editar";
        this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarRelacion", "javascript:abrirPopupEditarRelacion();", true);

    }

    protected void btnEliminarRelacionPersona_Click(object sender, EventArgs e)
    {
        this.popupEditarRelacion.LimpiarPopup();
        EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
        string[] arrayEmpresaPersona = this.HiddenPersonaSelected.Value.Split('#');
        epdc.Nombre = arrayEmpresaPersona[0];
        epdc.Codigo = arrayEmpresaPersona[1].Split('(')[1].Split(')')[0];
        epdc.Tipo = arrayEmpresaPersona[2].ToUpper();
        this.popupEditarRelacion.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarRelacion.EmpresaPersona2 = epdc;
        this.popupEditarRelacion.MODO = "Eliminar";
        this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarRelacion", "javascript:abrirPopupEditarRelacion();", true);

    }

    protected void btnEliminarRelacionEmpresa_Click(object sender, EventArgs e)
    {
        this.popupEditarRelacion.LimpiarPopup();
        EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
        string[] arrayEmpresaPersona = this.HiddenEmpresaSelected.Value.Split('#');
        epdc.Nombre = arrayEmpresaPersona[0];
        epdc.Codigo = arrayEmpresaPersona[1].Split('(')[1].Split(')')[0];
        epdc.Tipo = arrayEmpresaPersona[2].ToUpper();
        this.popupEditarRelacion.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarRelacion.EmpresaPersona2 = epdc;
        this.popupEditarRelacion.MODO = "Eliminar";
        this.popupEditarRelacion.ModalPopupExtenderEditarRelacion.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarRelacion", "javascript:abrirPopupEditarRelacion();", true);

    }

    protected void btnResumendelContacto_Click(object sender, EventArgs e)
    {
        
            EmpresaPersonaDataContracts epdc = new EmpresaPersonaDataContracts();
            string[] arrayEmpresaPersona = this.HiddenPersonaSelected.Value.Split('#');
            epdc.Nombre = arrayEmpresaPersona[0];
            epdc.Codigo = arrayEmpresaPersona[1].Split('(')[1].Split(')')[0];
            epdc.Tipo = arrayEmpresaPersona[2].ToUpper();
            
            if (epdc.Tipo.ToUpper().Equals("EMPRESA"))
            {
                this.popupBuscarContactoEmpresa.EmpresaPersona = epdc;
                this.popupBuscarContactoEmpresa.ModalPopupExtenderOtrosContactosEmpresa.Show();
            }
            else if (epdc.Tipo.ToUpper().Equals("PERSONA"))
            {
                this.popupBuscarContacto.EmpresaPersona = epdc;
                this.popupBuscarContacto.ModalPopupExtenderOtrosContactosPersonas.Show();
            }   

    }

    private void deshabilitarBotonesABMRelacion()
    {
        // Deshabilitamos botones de ABM Relaciones.
        this.btnNuevaRelacionPersona.Enabled = false;
        this.btnModificarRelacionPersona.Enabled = false;
        this.btnEliminarRelacionPersona.Enabled = false;
        this.btnVerRelacionPersona.Enabled = false;
        this.btnResumendelContacto.Enabled = false;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.TextBox1.BackColor = System.Drawing.Color.White;
        this.TextBox1.Enabled = true;
        this.TextBox1.Text = "";
        this.TextBox1.Focus();
        List<EmpresaPersonaDataContracts> listaVacia = new List<EmpresaPersonaDataContracts>();
        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(listaVacia);
        this.gvResultadoPersona.DataSource = dt;
        gvResultadoPersona.DataBind();
        this.gvResultadoEmpresa.DataSource = dt;
        gvResultadoEmpresa.DataBind();
        this.btnContactoPersonaSel.Visible = false;
        Session["EmpresaPersona"] = null;
        deshabilitarBotonesABMRelacion();
        this.btnLimpiar.Enabled = false;
        this.btnTarea.Enabled = false;
    }

    protected void btnTarea_Click(object sender, EventArgs e)
    {
        this.popupEditarTarea.LimpiarPopup();
        this.popupEditarTarea.EmpresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];// this.empresaPersonaSelected;
        this.popupEditarTarea.MODO = "Agendar";
        this.popupEditarTarea.ModalPopupExtenderEditarTarea.Show();
        ScriptManager.RegisterStartupScript(Page, GetType(), "abrirPopupEditarTarea", "javascript:abrirPopupEditarTarea();", true);
    }

    
    protected void btnContactoPersonaSel_Click(object sender, ImageClickEventArgs e)
    {
        IEmpresaPersonaService empresasPersonasService =
        ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        if (Session["EmpresaPersona"] != null)
        {
            // Persona o Empresa seleccionada en el popup busqueda.
            EmpresaPersonaDataContracts empresaPersona = (EmpresaPersonaDataContracts)Session["EmpresaPersona"];
            if (empresaPersona.Tipo.ToLower().EndsWith("empresa"))
            {
                this.myPopupEmpresa.EmpresaPersona = empresaPersona;
                this.myPopupEmpresa.ModalPopupExtenderDatosEmpresa.Show();
            }
            else if (empresaPersona.Tipo.ToLower().EndsWith("persona"))
            {
                this.myPopupPersona.EmpresaPersona = empresaPersona;
                this.myPopupPersona.ModalPopupExtenderDatos.Show();
            }
        }
    }

}