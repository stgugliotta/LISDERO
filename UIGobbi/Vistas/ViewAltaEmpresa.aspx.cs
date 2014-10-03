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
using EvaWebControls;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using Herramientas;
using System.Reflection;

public partial class Vistas_ViewAltaEmpresa : GobbiPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["estoyEditandoEmpresa"] = false;
            Session["empresaEditada"] = null;
            Session["listaDeEmailsEmpresa"] = null;
            Session["listaDeDomicilioEmpresa"] = null;
            Session["listaDeTelefonosEmpresa"] = null;

            IEmpresaLivianoService empresasLivianaService = ServiceClient<IEmpresaLivianoService>.GetService("EmpresaLivianoService");
            List<EmpresaLivianoDataContracts> empresasLivianos = new List<EmpresaLivianoDataContracts>();
            empresasLivianos = empresasLivianaService.GetAllEmpresaLivianos();
            Session["empresasLivianos"] = empresasLivianos;

            IPaisService paisService = ServiceClient<IPaisService>.GetService("PaisService");
            List<PaisDataContracts> paises = new List<PaisDataContracts>();
            paises = paisService.GetAllPaiss();
            this.cmbPais.DataSource = paises;
            this.cmbPais.DataTextField = "nombre";
            this.cmbPais.DataValueField = "id";
            this.cmbPais.DataBind();

            ICalificacionService calificacionService = ServiceClient<ICalificacionService>.GetService("CalificacionService");
            List<CalificacionDataContracts> calificaciones = new List<CalificacionDataContracts>();
            calificaciones = calificacionService.GetAllCalificacions();
            this.cmbCalificacion.DataSource = calificaciones;
            this.cmbCalificacion.DataTextField = "descripcion";
            this.cmbCalificacion.DataValueField = "id";
            this.cmbCalificacion.DataBind();


            IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
            this.cmbProvincia.DataSource = provinciaService.GetAllProvinciasPorIdPais(int.Parse(this.cmbPais.SelectedValue));
            this.cmbProvincia.DataTextField = "descripcion";
            this.cmbProvincia.DataValueField = "id";
            this.cmbProvincia.DataBind();



            if (!string.IsNullOrEmpty(this.cmbProvincia.SelectedValue))
            {
                ICiudadService ciudadService = ServiceClient<ICiudadService>.GetService("CiudadService");
                this.cmbCiudad.DataSource = ciudadService.GetAllCiudadesPorIdProvincia(int.Parse(this.cmbProvincia.SelectedValue));
                this.cmbCiudad.DataTextField = "descripcion";
                this.cmbCiudad.DataValueField = "id";
                this.cmbCiudad.DataBind();
            }

            IIvaService ivaService = ServiceClient<IIvaService>.GetService("IvaService");
            this.cmbIVA.DataSource = ivaService.GetAllIvas();
            this.cmbIVA.DataTextField = "descripcion";
            this.cmbIVA.DataValueField = "id";
            this.cmbIVA.DataBind();

            IIIBBService iIBBService = ServiceClient<IIIBBService>.GetService("IIBBService");
            this.cmbIIBB.DataSource = iIBBService.GetAllIIBBs();
            this.cmbIIBB.DataTextField = "descripcion";
            this.cmbIIBB.DataValueField = "id";
            this.cmbIIBB.DataBind();

        }
       
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
            List<PersonaLivianoDataContracts> personasLiviano = (List<PersonaLivianoDataContracts>)Session["ResultadoBusqueda"];


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
        try
        {
            IEmpresaService empresaService = ServiceClient<IEmpresaService>.GetService("EmpresaService");
            EmpresaDataContracts empresa = new EmpresaDataContracts();
            empresa.Nombre = this.txtNombre.Text;
            if (Session["listaDeDomicilioEmpresa"] != null)
                empresa.Domicilios = (List<DomicilioDataContracts>)Session["listaDeDomicilioEmpresa"];
            else
                empresa.Domicilios = new List<DomicilioDataContracts>();


            if (Session["listaDeTelefonosEmpresa"] != null)
                empresa.Telefonos = (List<TelefonoDataContracts>)Session["listaDeTelefonosEmpresa"];
            else
                empresa.Telefonos = new List<TelefonoDataContracts>();


            if (Session["listaDeEmailsEmpresa"] != null)
                empresa.Emails = (List<EmailDataContracts>)Session["listaDeEmailsEmpresa"];
            else
                empresa.Emails = new List<EmailDataContracts>();

            empresa.OrigenContacto = this.txtOrigenContacto.Text;
            empresa.Vinculo = this.txtVinculo.Text;
            empresa.IdTipoCalificacion = int.Parse(this.cmbCalificacion.SelectedValue);
            empresa.Cuit = this.txtCuit.Text;
            empresa.Horario = this.txtHorario.Text;
            empresa.Web = this.txtWeb.Text;
            empresa.Notas = this.txtNotas.Text;
            empresa.IdIVA = int.Parse(this.cmbIVA.SelectedValue);
            empresa.IdIIBB = int.Parse(this.cmbIIBB.SelectedValue);
            
            if ((bool)Session["estoyEditandoEmpresa"] != true)
            {
                empresaService.Insert(empresa);

                IEmpresaHistoricoService empresaHistoricoService = ServiceClient<IEmpresaHistoricoService>.GetService("EmpresaHistoricoService");
                EmpresaHistoricoDataContracts empresahistorico = new EmpresaHistoricoDataContracts();
                empresahistorico.Id = empresa.Id;
                empresahistorico.Fecha_Codigo = DateTime.Now.Date;
                empresahistorico.Fecha_Contacto = DateTime.Now.Date;
                empresahistorico.Fecha_Cuit = DateTime.Now.Date;
                empresahistorico.Fecha_Domicilios = DateTime.Now.Date;
                empresahistorico.Fecha_Emails = DateTime.Now.Date;
                empresahistorico.Fecha_Horario = DateTime.Now.Date;
                empresahistorico.Fecha_Cargo = DateTime.Now.Date;
                empresahistorico.Fecha_IIBB = DateTime.Now.Date;
                empresahistorico.Fecha_IVA = DateTime.Now.Date;
                empresahistorico.Fecha_Sector = DateTime.Now.Date;
                empresahistorico.Fecha_SubSector= DateTime.Now.Date;
                empresahistorico.Fecha_TipoCalificacion = DateTime.Now.Date;
                empresahistorico.Fecha_Tratamiento = DateTime.Now.Date;
                empresahistorico.Fecha_Nombre = DateTime.Now.Date;
                empresahistorico.Fecha_Notas = DateTime.Now.Date;
                empresahistorico.Fecha_OrigenContacto = DateTime.Now.Date;
                empresahistorico.Fecha_Telefonos = DateTime.Now.Date;
                empresahistorico.Fecha_Vinculo = DateTime.Now.Date;
                empresahistorico.Fecha_NroInscripcion = DateTime.Now.Date;
                empresahistorico.Fecha_Activo = DateTime.Now.Date;
                empresahistorico.Fecha_Web = DateTime.Now.Date;
                empresaHistoricoService.Insert(empresahistorico);

            }
            else
            {
                empresa.Id = ((EmpresaDataContracts)Session["empresaEditada"]).Id;
                empresa.Codigo = ((EmpresaDataContracts)Session["empresaEditada"]).Codigo;

                IEmpresaService empresitaservice = ServiceClient<IEmpresaService>.GetService("EmpresaService");
                EmpresaDataContracts empresita = new EmpresaDataContracts();
                empresita = empresitaservice.GetEmpresaByCodigo(empresa.Codigo);

                empresaService.Update(empresa);

                IEmpresaHistoricoService empresaHistoricoService = ServiceClient<IEmpresaHistoricoService>.GetService("EmpresaHistoricoService");
                EmpresaHistoricoDataContracts empresahistorico1 = new EmpresaHistoricoDataContracts();

                empresahistorico1 = empresaHistoricoService.GetEmpresa(empresita.Id);
                if (empresahistorico1 != null)
                {
                    if ((empresita.Nombre != null) && (empresita.Nombre.Equals(txtNombre.Text)))
                        empresahistorico1.Fecha_Nombre = DateTime.Parse(lblFechaNombre.Text);
                    else
                        empresahistorico1.Fecha_Nombre = DateTime.Now.Date;
                    /****/
                    if ((empresita.Cuit != null) && (empresita.Cuit.Equals(empresa.Cuit)))
                        empresahistorico1.Fecha_Cuit = DateTime.Parse(lblFechaCuit.Text);
                    else
                        empresahistorico1.Fecha_Cuit = DateTime.Now.Date;
                    /****/
                    if ((empresita.Web != null) && (empresita.Web.Equals(empresa.Web)))
                        empresahistorico1.Fecha_Web = DateTime.Parse(lblFechaWeb.Text);
                    else
                        empresahistorico1.Fecha_Web = DateTime.Now.Date;
                    /****/
                    if ((empresita.Horario != null) && (empresita.Horario.Equals(empresa.Horario)))
                        empresahistorico1.Fecha_Horario = DateTime.Parse(lblFechaHorario.Text);
                    else
                        empresahistorico1.Fecha_Horario = DateTime.Now.Date;
                    /****/
                    if ((empresita.Notas != null) && (empresita.Notas.Equals(empresa.Notas)))
                        empresahistorico1.Fecha_Notas = DateTime.Parse(lblFechaNotas.Text);
                    else
                        empresahistorico1.Fecha_Notas = DateTime.Now.Date;
                    /****/

                    empresahistorico1.Fecha_Domicilios = DateTime.Parse(lblFechaDomicilio.Text);                       
                    /****/
                    empresahistorico1.Fecha_Telefonos = DateTime.Parse(lblFechaTelefono.Text);
                    /****/   
                     empresahistorico1.Fecha_Emails = DateTime.Parse(lblFechaEmails.Text);
                    /****/
                    if (empresita.IdIIBB == empresa.IdIIBB)
                        empresahistorico1.Fecha_IIBB = DateTime.Parse(lblFechaCondicionIIBB.Text);
                    else
                        empresahistorico1.Fecha_IIBB = DateTime.Now.Date;     
                    /****/
                    if (empresita.IdIVA == empresa.IdIVA )
                        empresahistorico1.Fecha_IVA = DateTime.Parse(lblFechaCondicionIva.Text);
                    else
                        empresahistorico1.Fecha_IVA = DateTime.Now.Date;
                    /****/
                    if ((empresita.OrigenContacto != null) && (empresita.OrigenContacto.Equals(empresa.OrigenContacto)))
                        empresahistorico1.Fecha_OrigenContacto = DateTime.Parse(lblFechaContacto.Text);
                    else
                        empresahistorico1.Fecha_OrigenContacto = DateTime.Now.Date;
                    /****/
                    if ((empresita.Vinculo != null) && (empresita.Vinculo.Equals(empresa.Vinculo)))
                        empresahistorico1.Fecha_Vinculo = DateTime.Parse(lblFechaVinculo.Text);
                    else
                        empresahistorico1.Fecha_Vinculo = DateTime.Now.Date;
                    /****/

                    if (empresita.IdTipoCalificacion==empresa.IdTipoCalificacion)
                        empresahistorico1.Fecha_TipoCalificacion = DateTime.Parse(lblFechaCalificacion.Text);
                    else
                        empresahistorico1.Fecha_TipoCalificacion = DateTime.Now.Date;

                    /****/


                    empresaHistoricoService.Update(empresahistorico1);
                }
                else
                {
                    EmpresaHistoricoDataContracts empresahistorico = new EmpresaHistoricoDataContracts();
                    empresahistorico.Id = empresa.Id;
                    empresahistorico.Fecha_Codigo = DateTime.Now.Date;
                    empresahistorico.Fecha_Contacto = DateTime.Now.Date;
                    empresahistorico.Fecha_Cuit = DateTime.Now.Date;
                    empresahistorico.Fecha_Domicilios = DateTime.Now.Date;
                    empresahistorico.Fecha_Emails = DateTime.Now.Date;
                    empresahistorico.Fecha_Horario = DateTime.Now.Date;
                    empresahistorico.Fecha_Cargo = DateTime.Now.Date;
                    empresahistorico.Fecha_IIBB = DateTime.Now.Date;
                    empresahistorico.Fecha_IVA = DateTime.Now.Date;
                    empresahistorico.Fecha_Sector = DateTime.Now.Date;
                    empresahistorico.Fecha_SubSector = DateTime.Now.Date;
                    empresahistorico.Fecha_TipoCalificacion = DateTime.Now.Date;
                    empresahistorico.Fecha_Tratamiento = DateTime.Now.Date;
                    empresahistorico.Fecha_Nombre = DateTime.Now.Date;
                    empresahistorico.Fecha_Notas = DateTime.Now.Date;
                    empresahistorico.Fecha_OrigenContacto = DateTime.Now.Date;
                    empresahistorico.Fecha_Telefonos = DateTime.Now.Date;
                    empresahistorico.Fecha_Vinculo = DateTime.Now.Date;
                    empresahistorico.Fecha_NroInscripcion = DateTime.Now.Date;
                    empresahistorico.Fecha_Activo = DateTime.Now.Date;
                    empresahistorico.Fecha_Web = DateTime.Now.Date;
                    empresaHistoricoService.Insert(empresahistorico); 
                }
            }
            IEmpresaLivianoService empresaLivianaService = ServiceClient<IEmpresaLivianoService>.GetService("EmpresaLivianoService");
            List<EmpresaLivianoDataContracts> empresasLivianos = new List<EmpresaLivianoDataContracts>();
            empresasLivianos = empresaLivianaService.GetAllEmpresaLivianos();
            Session["empresasLivianos"] = empresasLivianos;
            this.LimpiarPantalla("AltaEmpresa");
            this.InicilizaFechas();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Un contacto del tipo Empresa ha sido actualizado satisfactoriamente.');", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar guardar la empresa');", true);
        }
    }

    protected void GvTelefonos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GvTelefonos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GvTelefonos_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvDomicilio_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvDomicilio_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvDomicilio_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvDomicilio_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvDomicilio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected DataTable gvDomicilio_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }
    protected DataTable GvTelefonos_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }
    protected void GvTelefonos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GvTelefonos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected DataTable gvEmail_Filling(object sender, EventArgs e)
    {
        return null;
    }
    protected void gvEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvEmail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvEmail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvEmail_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
    {
        DomicilioDataContracts domicilio = new DomicilioDataContracts();
        domicilio.IdLocalidad = int.Parse(this.cmbCiudad.SelectedValue);
        domicilio.Ciudad = this.cmbCiudad.SelectedItem.Text;
        domicilio.IdProvincia = int.Parse(this.cmbProvincia.SelectedValue);
        domicilio.Provincia = this.cmbProvincia.SelectedItem.Text;
        domicilio.Codigo = string.Empty;
        domicilio.Depto = this.txtDepto.Text;
        domicilio.Domicilio_ = this.txtDomicilio.Text;
        domicilio.IdPais = int.Parse(this.cmbPais.SelectedValue);
        domicilio.Pais = this.cmbPais.SelectedItem.Text;
        domicilio.Piso = this.txtPiso.Text;
        domicilio.Cp = this.txtCp.Text;
        List<DomicilioDataContracts> listaDeDomicilios = new List<DomicilioDataContracts>();
        if (Session["listaDeDomicilioEmpresa"] != null)
            listaDeDomicilios = (List<DomicilioDataContracts>)Session["listaDeDomicilioEmpresa"];

        listaDeDomicilios.Add(domicilio);
        Session["listaDeDomicilioEmpresa"] = listaDeDomicilios;

        if (Session["listaDeDomicilioEmpresa"] != null)
        {
            this.cmbDomicilio.DataSource = listaDeDomicilios;
            this.cmbDomicilio.DataTextField = "Domicilio_";
            this.cmbDomicilio.DataValueField = "Domicilio_";
            this.cmbDomicilio.DataBind();
        }
        LimpiarPopup("domicilio");
        this.lblFechaDomicilio.Text = DateTime.Now.Date.ToString().Substring(0,10);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El domicilio se ha guardado temporalmente.');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarGuardarDomicilioTemp", "javascript:CerrarPanelDomicilios();", true);
    
    }

    private void LimpiarPopup(string popup)
    {
        switch (popup)
        {
            case "domicilio":
                {
                    this.txtDomicilio.Text = string.Empty;
                    this.txtCp.Text = string.Empty;
                    this.txtDepto.Text = string.Empty;
                    this.txtPiso.Text = string.Empty;
                    this.cmbPais.SelectedIndex = 0;
                    this.cmbProvincia.SelectedIndex = 0;
                    this.cmbCiudad.SelectedIndex = 0;
                    break;
                }
            case "telefono":
                {
                    this.txtTelefono.Text = string.Empty;
                    break;
                }
            case "email":
                {
                    this.txtEmail.Text = string.Empty;
                    break;
                }
            case "calificacion":
                {
                    this.txtCalificacion.Text = string.Empty;
                    break;
                }
        }

    }

    private void LimpiarPantalla(string pantalla)
    {

        switch (pantalla)
        {
            case "AltaEmpresa":
                {
                    this.txtNombre.Text = string.Empty;
                    this.txtOrigenContacto.Text = string.Empty;
                    this.txtVinculo.Text = string.Empty;
                    this.cmbDomicilio.Items.Clear();
                    this.txtCuit.Text = string.Empty;
                    this.cmbTelefono.Items.Clear();
                    this.cmbEmails.Items.Clear();
                    this.txtNotas.Text = string.Empty;
                    this.txtWeb.Text = string.Empty;
                    this.txtHorario.Text = string.Empty;
                    Session["listaDeDomicilioEmpresa"] = null;
                    Session["listaDeTelefonosEmpresa"] = null;
                    Session["listaDeEmailsEmpresa"] = null;
                    this.cmbIVA.SelectedIndex = 0;
                    this.cmbIIBB.SelectedIndex = 0;
                    this.cmbCalificacion.SelectedIndex = 0;
                    this.txtVinculo.Text = string.Empty;
                    break;
                }
        }




    }
    protected void btnAgregarPais_Click(object sender, EventArgs e)
    {
        try
        {
            IPaisService paisService = ServiceClient<IPaisService>.GetService("PaisService");
            PaisDataContracts pais = new PaisDataContracts();
            pais.Nombre = this.txtPais.Text;
            paisService.Insert(pais);
            this.cmbPais.DataSource = paisService.GetAllPaiss();
            this.cmbPais.DataTextField = "nombre";
            this.cmbPais.DataValueField = "id";
            this.cmbPais.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardar", "javascript:CerrarPanelNuevoPais();", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void btnEliminarProvincia_Click(object sender, EventArgs e)
    {
        List<ProvinciaDataContracts> listaDeProvincia = new List<ProvinciaDataContracts>();
        List<ProvinciaDataContracts> listaDeProvinciaDefinitiva = new List<ProvinciaDataContracts>();
        if (Session["listaDeProvincia"] != null)
        {
            listaDeProvincia = (List<ProvinciaDataContracts>)Session["listaDeProvincia"];
            foreach (var item in listaDeProvincia)
            {
                if (!this.cmbProvincia.SelectedItem.Text.Equals(item.Descripcion))
                    listaDeProvinciaDefinitiva.Add(item);

            }
            Session["listaDeProvincia"] = listaDeProvinciaDefinitiva;
            this.cmbProvincia.DataSource = listaDeProvinciaDefinitiva;
            this.cmbProvincia.DataTextField = "Descripcion";
            this.cmbProvincia.DataValueField = "Descripcion";
            this.cmbProvincia.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTemp2", "javascript:alert('La provincia se ha eliminado temporalmente.');", true);

        }
    }
    protected void btnEliminarCiudad_Click(object sender, EventArgs e)
    {
        List<CiudadDataContracts> listaDeCiudad = new List<CiudadDataContracts>();
        List<CiudadDataContracts> listaDeCiudadDefinitiva = new List<CiudadDataContracts>();
        if (Session["listaDeCiudad"] != null)
        {
            listaDeCiudad = (List<CiudadDataContracts>)Session["listaDeCiudad"];
            foreach (var item in listaDeCiudad)
            {
                if (!this.cmbCiudad.SelectedItem.Text.Equals(item.Descripcion))
                    listaDeCiudadDefinitiva.Add(item);

            }
            Session["listaDeCiudad"] = listaDeCiudadDefinitiva;
            this.cmbCiudad.DataSource = listaDeCiudadDefinitiva;
            this.cmbCiudad.DataTextField = "Descripcion";
            this.cmbCiudad.DataValueField = "Descripcion";
            this.cmbCiudad.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTemp3", "javascript:alert('La ciudad     se ha eliminado temporalmente.');", true);

        }
    }
    protected void btnAgregarProvincia_Click(object sender, EventArgs e)
    {
        try
        {
            IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
            ProvinciaDataContracts provincia = new ProvinciaDataContracts();
            provincia.Descripcion = this.txtProvincia.Text;
            provincia.IdPais = int.Parse(this.cmbPais.SelectedValue);
            provinciaService.Insert(provincia);
            this.cmbProvincia.DataSource = provinciaService.GetAllProvinciasPorIdPais(int.Parse(this.cmbPais.SelectedValue));
            this.cmbProvincia.DataTextField = "descripcion";
            this.cmbProvincia.DataValueField = "id";
            this.cmbProvincia.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardar", "javascript:CerrarPanelNuevaProvincia();", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

    protected void btnAgregarCiudad_Click(object sender, EventArgs e)
    {
        try
        {
            ICiudadService ciudadService = ServiceClient<ICiudadService>.GetService("CiudadService");
            CiudadDataContracts ciudad = new CiudadDataContracts();
            ciudad.Descripcion = this.txtCiudad.Text;
            if (!string.IsNullOrEmpty(this.cmbProvincia.SelectedValue))
            {
                ciudad.IdProvincia = int.Parse(this.cmbProvincia.SelectedValue);
                ciudadService.Insert(ciudad);
                this.cmbCiudad.DataSource = ciudadService.GetAllCiudadesPorIdProvincia(int.Parse(this.cmbProvincia.SelectedValue));
                this.cmbCiudad.DataTextField = "descripcion";
                this.cmbCiudad.DataValueField = "id";
                this.cmbCiudad.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardar", "javascript:CerrarPanelNuevaCiudad();", true);
            }


        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
            ProvinciaDataContracts provincia = new ProvinciaDataContracts();
            this.cmbProvincia.DataSource = provinciaService.GetAllProvinciasPorIdPais(int.Parse(this.cmbPais.SelectedValue));
            this.cmbProvincia.DataTextField = "descripcion";
            this.cmbProvincia.DataValueField = "id";
            this.cmbProvincia.DataBind();

            if (!string.IsNullOrEmpty(this.cmbProvincia.SelectedValue))
            {
                ICiudadService ciudadService = ServiceClient<ICiudadService>.GetService("CiudadService");
                CiudadDataContracts ciudad = new CiudadDataContracts();
                this.cmbCiudad.DataSource = ciudadService.GetAllCiudadesPorIdProvincia(int.Parse(this.cmbProvincia.SelectedValue));
                this.cmbCiudad.DataTextField = "descripcion";
                this.cmbCiudad.DataValueField = "id";
                this.cmbCiudad.DataBind();
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.cmbProvincia.SelectedValue))
        {
            ICiudadService ciudadService = ServiceClient<ICiudadService>.GetService("CiudadService");
            CiudadDataContracts ciudad = new CiudadDataContracts();
            this.cmbCiudad.DataSource = ciudadService.GetAllCiudadesPorIdProvincia(int.Parse(this.cmbProvincia.SelectedValue));
            this.cmbCiudad.DataTextField = "descripcion";
            this.cmbCiudad.DataValueField = "id";
            this.cmbCiudad.DataBind();
        }
    }
    protected void btnAgregarTelefono_Click(object sender, EventArgs e)
    {
        TelefonoDataContracts telefono = new TelefonoDataContracts();
        telefono.Numero = this.txtTelefono.Text;
        List<TelefonoDataContracts> listaDeTelefonos = new List<TelefonoDataContracts>();
        if (Session["listaDeTelefonosEmpresa"] != null)
            listaDeTelefonos = (List<TelefonoDataContracts>)Session["listaDeTelefonosEmpresa"];

        listaDeTelefonos.Add(telefono);
        Session["listaDeTelefonosEmpresa"] = listaDeTelefonos;
        if (Session["listaDeTelefonosEmpresa"] != null)
        {
            this.cmbTelefono.DataSource = listaDeTelefonos;
            this.cmbTelefono.DataTextField = "Numero";
            this.cmbTelefono.DataValueField = "Numero";
            this.cmbTelefono.DataBind();
            //this.updatePanelGeneral.Update();
        }
        LimpiarPopup("telefono");
        this.lblFechaTelefono.Text = DateTime.Now.Date.ToString().Substring(0, 10);    
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El teléfono se ha guardado temporalmente.');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelTelefonos", "javascript:CerrarPanelTelefonos();", true);


    }
    protected void btnAgregarEmail_Click(object sender, EventArgs e)
    {
        EmailDataContracts email = new EmailDataContracts();
        email.Emaill = this.txtEmail.Text;
        List<EmailDataContracts> listaDeEmails = new List<EmailDataContracts>();
        if (Session["listaDeEmailsEmpresa"] != null)
            listaDeEmails = (List<EmailDataContracts>)Session["listaDeEmailsEmpresa"];

        listaDeEmails.Add(email);
        Session["listaDeEmailsEmpresa"] = listaDeEmails;
        if (Session["listaDeEmailsEmpresa"] != null)
        {
            this.cmbEmails.DataSource = listaDeEmails;
            this.cmbEmails.DataTextField = "Emaill";
            this.cmbEmails.DataValueField = "Emaill";
            this.cmbEmails.DataBind();
            //this.updatePanelGeneral.Update();
        }
        LimpiarPopup("telefono");
        this.lblFechaEmails.Text = DateTime.Now.Date.ToString().Substring(0,10);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El email se ha guardado temporalmente.');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelEmails", "javascript:CerrarPanelEmails();", true);

    }
    protected void btnEliminarDomi_Click(object sender, EventArgs e)
    {
        List<DomicilioDataContracts> listaDeDomicilios = new List<DomicilioDataContracts>();
        List<DomicilioDataContracts> listaDeDomiciliosDefinitiva = new List<DomicilioDataContracts>();
        if (Session["listaDeDomicilioEmpresa"] != null)
        {
            listaDeDomicilios = (List<DomicilioDataContracts>)Session["listaDeDomicilioEmpresa"];
            foreach (var item in listaDeDomicilios)
            {
                if (!this.cmbDomicilio.SelectedItem.Text.Equals(item.Domicilio_))
                    listaDeDomiciliosDefinitiva.Add(item);

            }
            Session["listaDeDomicilioEmpresa"] = listaDeDomiciliosDefinitiva;
            this.cmbDomicilio.DataSource = listaDeDomiciliosDefinitiva;
            this.cmbDomicilio.DataTextField = "Domicilio_";
            this.cmbDomicilio.DataValueField = "Domicilio_";
            this.cmbDomicilio.DataBind();
            this.lblFechaDomicilio.Text = DateTime.Now.Date.ToString().Substring(0, 10);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El domicilio se ha eliminado temporalmente.');", true);

        }

    }
    protected void btnEliminarTelefono_Click(object sender, EventArgs e)
    {
        List<TelefonoDataContracts> listaDeTelefonos = new List<TelefonoDataContracts>();
        List<TelefonoDataContracts> listaDeTelefonosDefinitiva = new List<TelefonoDataContracts>();
        if (Session["listaDeTelefonosEmpresa"] != null)
        {
            listaDeTelefonos = (List<TelefonoDataContracts>)Session["listaDeTelefonosEmpresa"];
            foreach (var item in listaDeTelefonos)
            {
                if (!this.cmbTelefono.SelectedItem.Text.Equals(item.Numero))
                {
                    listaDeTelefonosDefinitiva.Add(item);
                    this.lblFechaTelefono.Text = DateTime.Now.Date.ToString().Substring(0, 10);                  
                }

            }
            Session["listaDeTelefonosEmpresa"] = listaDeTelefonosDefinitiva;
            this.cmbTelefono.DataSource = listaDeTelefonosDefinitiva;
            this.cmbTelefono.DataTextField = "Numero";
            this.cmbTelefono.DataValueField = "Numero";
            this.cmbTelefono.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El teléfono se ha eliminado temporalmente.');", true);

        }
    }


    protected void btnEliminarEmail_Click(object sender, EventArgs e)
    {
        List<EmailDataContracts> listaDeEmails = new List<EmailDataContracts>();
        List<EmailDataContracts> listaDeEmailsDefinitiva = new List<EmailDataContracts>();
        if (Session["listaDeEmailsEmpresa"] != null)
        {
            listaDeEmails = (List<EmailDataContracts>)Session["listaDeEmailsEmpresa"];
            foreach (var item in listaDeEmails)
            {
                if (!this.cmbEmails.SelectedItem.Text.Equals(item.Emaill))
                    listaDeEmailsDefinitiva.Add(item);

            }
            Session["listaDeEmailsEmpresa"] = listaDeEmailsDefinitiva;
            this.cmbEmails.DataSource = listaDeEmailsDefinitiva;
            this.cmbEmails.DataTextField = "Emaill";
            this.cmbEmails.DataValueField = "Emaill";
            this.cmbEmails.DataBind();
            this.lblFechaEmails.Text = DateTime.Now.Date.ToString().Substring(0, 10);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El emails se ha eliminado temporalmente.');", true);

        }
    }
    protected void btnEliminarPais_Click(object sender, EventArgs e)
    {

        List<PaisDataContracts> listaDePais = new List<PaisDataContracts>();
        List<PaisDataContracts> listaDePaisDefinitiva = new List<PaisDataContracts>();
        if (Session["listaDePais"] != null)
        {
            listaDePais = (List<PaisDataContracts>)Session["listaDePais"];
            foreach (var item in listaDePais)
            {
                if (!this.cmbPais.SelectedItem.Text.Equals(item.Nombre))
                    listaDePaisDefinitiva.Add(item);

            }
            Session["listaDePais"] = listaDePaisDefinitiva;
            this.cmbPais.DataSource = listaDePaisDefinitiva;
            this.cmbPais.DataTextField = "Nombre";
            this.cmbPais.DataValueField = "Nombre";
            this.cmbPais.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTemp", "javascript:alert('El pais se ha eliminado temporalmente.');", true);

        }
    }


    protected void btnAgregarCalificacion_Click(object sender, EventArgs e)
    {
        try
        {
            ICalificacionService calificacionService = ServiceClient<ICalificacionService>.GetService("CalificacionService");
            CalificacionDataContracts calificacion = new CalificacionDataContracts();
            calificacion.Descripcion = this.txtCalificacion.Text;
            calificacionService.Insert(calificacion);
            this.cmbCalificacion.DataSource = calificacionService.GetAllCalificacions();
            this.cmbCalificacion.DataTextField = "descripcion";
            this.cmbCalificacion.DataValueField = "id";
            this.cmbCalificacion.DataBind();
            LimpiarPopup("calificacion");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarCalificacion", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevoCalificacion", "javascript:CerrarPanelNuevaCalificacion();", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void btnEliminarCalificacion_Click(object sender, EventArgs e)
    {
        try
        {
            ICalificacionService calificacionService = ServiceClient<ICalificacionService>.GetService("CalificacionService");
            CalificacionDataContracts calificacion = new CalificacionDataContracts();
            calificacion.Descripcion = this.cmbCalificacion.SelectedItem.Text;
            calificacion.Id = int.Parse(this.cmbCalificacion.SelectedValue.ToString());
            calificacionService.Delete(calificacion);
            this.cmbCalificacion.DataSource = calificacionService.GetAllCalificacions();
            this.cmbCalificacion.DataTextField = "descripcion";
            this.cmbCalificacion.DataValueField = "id";
            this.cmbCalificacion.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarCalificacion", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);

        }
    }

    protected void txtBusqueda_TextChanged(object sender, EventArgs e)
    {
    }
    protected void HandleAjaxCall(object sender, EventArgs e)
    {
        int len = this.TextBox1.Text.Length;
        List<EmpresaLivianoDataContracts> empresasLivianos = new List<EmpresaLivianoDataContracts>();
        if (Session["empresasLivianos"] != null)
        {
        empresasLivianos = (List<EmpresaLivianoDataContracts>)Session["empresasLivianos"];
        empresasLivianos = empresasLivianos.Where(p => p.Nombre.ToUpper().StartsWith(this.TextBox1.Text.ToUpper())).ToList();
        if (string.IsNullOrEmpty(this.TextBox1.Text))
        {
            empresasLivianos.Clear();
        }
      
            DataTable dt = ConvertDataTable<EmpresaLivianoDataContracts>.Convert((List<EmpresaLivianoDataContracts>)empresasLivianos);
            this.gvResultadosBusqueda.DataSource = dt;
            this.gvResultadosBusqueda.DataBind();
            if (empresasLivianos.Count>0)
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AbrirPanelResultados", "javascript:AbrirPanelResultados();", true);
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelResultados", "javascript:CerrarPanelResultados();", true);

        }
      
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "PosicionarAlFinal", "javascript:establerCursorPosicion(" + len.ToString()+ ");", true);

    }
    protected void GvResultadosBusqueda_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GvResultadosBusqueda_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Session["estoyEditandoEmpresa"] = true;
        int codigo = int.Parse(this.gvResultadosBusqueda.Rows[e.NewEditIndex].Cells[1].Text.Split('(')[1].Replace(")", string.Empty));
        IEmpresaService empresaService = ServiceClient<IEmpresaService>.GetService("EmpresaService");
        EmpresaDataContracts empresa = new EmpresaDataContracts();
        empresa=empresaService.GetEmpresaByCodigo(codigo);
        CompletarDatosDeEmpresa(empresa);
        Session["empresaEditada"] = empresa;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelResultados", "javascript:CerrarPanelResultados();", true);
    }

    private void CompletarDatosDeEmpresa(EmpresaDataContracts empresa)
    {
        this.txtNombre.Text = empresa.Nombre;
        this.cmbDomicilio.Items.Clear();
        this.txtWeb.Text = empresa.Web;
        this.txtHorario.Text = empresa.Horario;
        foreach (var item in empresa.Domicilios)
        {
            this.cmbDomicilio.Items.Add(new ListItem(item.Domicilio_,item.Id.ToString()));
        }
        this.cmbTelefono.Items.Clear();
        foreach (var item in empresa.Telefonos)
        {
            this.cmbTelefono.Items.Add(new ListItem(item.Numero, item.Id.ToString()));
        }
        this.cmbEmails.Items.Clear();

        foreach (var item in empresa.Emails)
        {
            this.cmbEmails.Items.Add(new ListItem(item.Emaill,item.Id.ToString()));
        }
        Session["listaDeEmailsEmpresa"] = empresa.Emails;
        Session["listaDeDomicilioEmpresa"] = empresa.Domicilios;
        Session["listaDeTelefonosEmpresa"] = empresa.Telefonos;
        this.txtOrigenContacto.Text = empresa.OrigenContacto;
        this.txtVinculo.Text = empresa.Vinculo;
       
       
        try
        {
            this.cmbCalificacion.SelectedValue = (empresa.IdTipoCalificacion == 0) ? "34" : empresa.IdTipoCalificacion.ToString();
        }
        catch (Exception)
        {

            this.cmbCalificacion.SelectedValue = "34";
        }

        try
        {
            this.cmbIVA.SelectedValue = (empresa.IdIVA == 0) ? "5" : empresa.IdIVA.ToString();
        }
        catch (Exception)
        {

            this.cmbIVA.SelectedValue = "5";
        }

        try
        {
            this.cmbIIBB.SelectedValue = (empresa.IdIIBB == 0) ? "5" : empresa.IdIIBB.ToString();
        }
        catch (Exception)
        {

            this.cmbIIBB.SelectedValue = "5";
        }

        this.txtCuit.Text = (string.IsNullOrEmpty(empresa.Cuit)) ? string.Empty : empresa.Cuit;
        this.txtNotas.Text = (string.IsNullOrEmpty(empresa.Notas)) ? string.Empty : empresa.Notas;
        //this.updatePanelGeneral.Update();
        CompletarFechas(empresa.Id);
    
    }

    protected void GvResultadosBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GvResultadosBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GvResultadosBusqueda_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GvResultadosBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected DataTable GvResultadosBusqueda_Filling(object sender, EventArgs e)
    {
        return new DataTable();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["empresaEditada"] != null)
            {
                IEmpresaService empresaService = ServiceClient<IEmpresaService>.GetService("EmpresaService");
                EmpresaDataContracts empresa = new EmpresaDataContracts();
                empresa = ((EmpresaDataContracts)Session["empresaEditada"]);
                empresaService.Delete(empresa);
                IEmpresaLivianoService empresaLivianaService = ServiceClient<IEmpresaLivianoService>.GetService("EmpresaLivianoService");
                List<EmpresaLivianoDataContracts> empresasLivianos = new List<EmpresaLivianoDataContracts>();
                empresasLivianos = empresaLivianaService.GetAllEmpresaLivianos();
                Session["empresasLivianos"] = empresasLivianos;
                this.LimpiarPantalla("AltaEmpresa");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkDelete", "javascript:alert('La operación se ha realizado con éxito.');", true);
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkDelete", "javascript:alert('Debe seleccionar una empresa para eliminar.');", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorDelete", "javascript:alert('Ha ocurrido un error al intentar realizar la operación.');", true);
        }
    }

    private void CompletarFechas(int codigoempresa)
    {
        InicilizaFechas();
        IEmpresaHistoricoService empresahistoricoService = ServiceClient<IEmpresaHistoricoService>.GetService("EmpresaHistoricoService");
        EmpresaHistoricoDataContracts empresahistorico = new EmpresaHistoricoDataContracts();
        empresahistorico = empresahistoricoService.GetEmpresa(codigoempresa);
        if (empresahistorico != null)
        {
            lblFechaNombre.Text = empresahistorico.Fecha_Nombre.ToString().Substring(0,10);
            lblFechaCuit.Text = empresahistorico.Fecha_Cuit.ToString().Substring(0, 10);
            lblFechaWeb.Text = empresahistorico.Fecha_Web.ToString().Substring(0, 10);
            lblFechaHorario.Text = empresahistorico.Fecha_Horario.ToString().Substring(0, 10);
            lblFechaNotas.Text = empresahistorico.Fecha_Notas.ToString().Substring(0, 10);
            lblFechaDomicilio.Text = empresahistorico.Fecha_Domicilios.ToString().Substring(0, 10);
            lblFechaTelefono.Text = empresahistorico.Fecha_Telefonos.ToString().Substring(0, 10);
            lblFechaEmails.Text = empresahistorico.Fecha_Emails.ToString().Substring(0, 10);
            lblFechaCondicionIva.Text = empresahistorico.Fecha_IVA.ToString().Substring(0, 10);
            lblFechaCondicionIIBB.Text = empresahistorico.Fecha_IIBB.ToString().Substring(0, 10);
            lblFechaContacto.Text = empresahistorico.Fecha_OrigenContacto.ToString().Substring(0, 10);
            lblFechaVinculo.Text = empresahistorico.Fecha_Vinculo.ToString().Substring(0, 10);
            lblFechaCalificacion.Text = empresahistorico.Fecha_TipoCalificacion.ToString().Substring(0, 10);
        }
    }

    private void InicilizaFechas()
    {
        lblFechaCalificacion.Text = "";
        lblFechaCuit.Text = "";       
        lblFechaDomicilio.Text = "";
        lblFechaContacto.Text = "";
        lblFechaNombre.Text = "";
        lblFechaNotas.Text = "";
        lblFechaWeb.Text = "";
        lblFechaHorario.Text = "";
        lblFechaTelefono.Text = "";
        lblFechaEmails.Text = "";
        lblFechaVinculo.Text = "";
        lblFechaCondicionIIBB.Text = "";
        lblFechaCondicionIva.Text = "";
    }    

}