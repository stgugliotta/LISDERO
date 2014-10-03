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

public partial class Vistas_ViewAltaPersona : GobbiPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["estoyEditando"] = false;
            Session["personaEditada"] = null;
            Session["listaDeEmails"] = null;
            Session["listaDeDomicilio"] = null;
            Session["listaDeTelefonos"] = null;
            IPersonaLivianoService personaLivianaService = ServiceClient<IPersonaLivianoService>.GetService("PersonaLivianoService");
            List<PersonaLivianoDataContracts> personasLivianos = new List<PersonaLivianoDataContracts>();
            personasLivianos = personaLivianaService.GetAllPersonaLivianos();
            Session["personasLivianos"] = personasLivianos;

            IProfesionService profesionService = ServiceClient<IProfesionService>.GetService("ProfesionService");
            List<ProfesionDataContracts> profesiones = new List<ProfesionDataContracts>();
            profesiones = profesionService.GetAllProfesions();
            this.cmbProfesion.DataSource = profesiones;
            this.cmbProfesion.DataTextField = "descripcion";
            this.cmbProfesion.DataValueField = "id";
            this.cmbProfesion.DataBind();


            ITratamientoService tratamientoService = ServiceClient<ITratamientoService>.GetService("TratamientoService");
            List<TratamientoDataContracts> tratamientos = new List<TratamientoDataContracts>();
            tratamientos = tratamientoService.GetAllTratamientos();
            this.cmbTratamiento.DataSource = tratamientos;
            this.cmbTratamiento.DataTextField = "descripcion";
            this.cmbTratamiento.DataValueField = "id";
            this.cmbTratamiento.DataBind();

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
            IPersonaService personaService = ServiceClient<IPersonaService>.GetService("PersonaService");
            PersonaDataContracts persona = new PersonaDataContracts();
            persona.Nombre = this.txtNombre.Text;
            if (Session["listaDeDomicilio"] != null)
                persona.Domicilios = (List<DomicilioDataContracts>)Session["listaDeDomicilio"];
            else
                persona.Domicilios=new List<DomicilioDataContracts>();


            if (Session["listaDeTelefonos"] != null)
                persona.Telefonos = (List<TelefonoDataContracts>)Session["listaDeTelefonos"];
            else
                persona.Telefonos=new List<TelefonoDataContracts>();


            if (Session["listaDeEmails"] != null)
                persona.Emails = (List<EmailDataContracts>)Session["listaDeEmails"];
            else
                persona.Emails=new List<EmailDataContracts>();

            persona.OrigenContacto=this.txtOrigenContacto.Text;
            persona.Vinculo=this.txtVinculo.Text;
            persona.IdProfesion = int.Parse(this.cmbProfesion.SelectedValue);
            persona.IdTipoDocumento = int.Parse(this.cmbTipoDoc.SelectedValue);
            persona.Documento = this.txtDoc.Text;
            persona.IdTipoCalificacion = int.Parse(this.cmbCalificacion.SelectedValue);
            persona.IdTratamiento = int.Parse(this.cmbTratamiento.SelectedValue);
            persona.Cuit = this.txtCuit.Text;
            persona.Notas = this.txtNotas.Text;
            if ((bool)Session["estoyEditando"] != true)
            {
                personaService.Insert(persona);

                IPersonaHistoricoService personaHistoricoService = ServiceClient<IPersonaHistoricoService>.GetService("PersonaHistoricoService");
                PersonaHistoricoDataContracts personahistorico = new PersonaHistoricoDataContracts();
                personahistorico.Id = persona.Id;
                personahistorico.Fecha_Cargo = DateTime.Now.Date;
                personahistorico.Fecha_Codigo = DateTime.Now.Date;
                personahistorico.Fecha_Contacto = DateTime.Now.Date;
                personahistorico.Fecha_Cuit = DateTime.Now.Date;
                personahistorico.Fecha_Documento = DateTime.Now.Date;
                personahistorico.Fecha_Domicilios = DateTime.Now.Date;
                personahistorico.Fecha_Emails = DateTime.Now.Date;
                personahistorico.Fecha_Profesion = DateTime.Now.Date;
                personahistorico.Fecha_Sector = DateTime.Now.Date;
                personahistorico.Fecha_SubSector = DateTime.Now.Date;
                personahistorico.Fecha_TipoCalificacion = DateTime.Now.Date;
                personahistorico.Fecha_TipoDocumento = DateTime.Now.Date;
                personahistorico.Fecha_Tratamiento = DateTime.Now.Date;
                personahistorico.Fecha_Nombre = DateTime.Now.Date;
                personahistorico.Fecha_Notas = DateTime.Now.Date;
                personahistorico.Fecha_OrigenContacto = DateTime.Now.Date;
                personahistorico.Fecha_Telefonos = DateTime.Now.Date;
                personahistorico.Fecha_Vinculo = DateTime.Now.Date;
                personaHistoricoService.Insert(personahistorico);
            }
            else
            {
                persona.Id = ((PersonaDataContracts)Session["personaEditada"]).Id;
                persona.Codigo = ((PersonaDataContracts)Session["personaEditada"]).Codigo;
              
                IPersonaService personitaservice = ServiceClient<IPersonaService>.GetService("PersonaService");
                PersonaDataContracts personita = new PersonaDataContracts();
                personita = personitaservice.GetPersonaByCodigo(persona.Codigo);

                personaService.Update(persona);

                IPersonaHistoricoService personaHistoricoService = ServiceClient<IPersonaHistoricoService>.GetService("PersonaHistoricoService");
                PersonaHistoricoDataContracts personahistorico1 = new PersonaHistoricoDataContracts();

                personahistorico1 = personaHistoricoService.GetPersona(personita.Id);
                if (personahistorico1 != null)
                {
                    if ((personita.Nombre != null) && (personita.Nombre.Equals(txtNombre.Text)))
                        personahistorico1.Fecha_Nombre = DateTime.Parse(lblFechaNombre.Text);
                    else
                        personahistorico1.Fecha_Nombre = DateTime.Now.Date;
                    /****/
                 
                    personahistorico1.Fecha_Domicilios = DateTime.Parse(lblFechaDomicilio.Text);
      
                    /****/
                   
                    personahistorico1.Fecha_Telefonos = DateTime.Parse(lblFechaTelefono.Text);
                  
                    /****/
              
                    personahistorico1.Fecha_Emails = DateTime.Parse(lblfechaEmails.Text);
                                       
                    /****/
                    if ((personita.OrigenContacto != null) && (personita.OrigenContacto.Equals(persona.OrigenContacto)))
                        personahistorico1.Fecha_OrigenContacto = DateTime.Parse(lblFechaOrigen.Text);
                    else
                        personahistorico1.Fecha_OrigenContacto= DateTime.Now.Date;
                    /****/
                    if ((personita.Vinculo!=null) && (personita.Vinculo.Equals(persona.Vinculo)))
                        personahistorico1.Fecha_Vinculo = DateTime.Parse(lblFechaVinculo.Text);
                    else
                        personahistorico1.Fecha_Vinculo = DateTime.Now.Date;
                    /****/
                    if (personita.IdProfesion==persona.IdProfesion)
                        personahistorico1.Fecha_Profesion = DateTime.Parse(lblFechaProfesion.Text);
                    else
                        personahistorico1.Fecha_Profesion = DateTime.Now.Date;
                    /****/
                    if (personita.IdTipoDocumento==persona.IdTipoDocumento)
                        personahistorico1.Fecha_TipoDocumento = DateTime.Parse(lblFechaDocumento.Text);
                    else
                        personahistorico1.Fecha_TipoDocumento = DateTime.Now.Date;
                    /****/
                    if ((personita.Documento!=null) && (personita.Documento.Equals(persona.Documento)))
                        personahistorico1.Fecha_Documento = DateTime.Parse(lblFechaDocumento.Text);
                    else
                        personahistorico1.Fecha_Documento = DateTime.Now.Date;
                    /****/                  
                    if (personita.IdTipoCalificacion== persona.IdTipoCalificacion)
                        personahistorico1.Fecha_TipoCalificacion=DateTime.Parse(lblFechaCalificacion.Text);
                    else
                        personahistorico1.Fecha_TipoCalificacion = DateTime.Now.Date;
                    /****/
                    if (personita.IdTratamiento==persona.IdTratamiento)
                        personahistorico1.Fecha_Tratamiento = DateTime.Parse(lblFechaTratamiento.Text);
                    else
                        personahistorico1.Fecha_Tratamiento = DateTime.Now.Date;
                    /****/
                    if ((personita.Cuit != null)&&(personita.Cuit.Equals(persona.Cuit)))
                        personahistorico1.Fecha_Cuit = DateTime.Parse(lblFechaCuit.Text);
                    else
                        personahistorico1.Fecha_Cuit = DateTime.Now.Date;
                    /****/
                    if ((personita.Notas != null) && (personita.Notas.Equals(persona.Notas)))
                        personahistorico1.Fecha_Notas = DateTime.Parse(lblFechaNotas.Text);
                    else
                        personahistorico1.Fecha_Notas = DateTime.Now.Date;
                    /****/
                    personaHistoricoService.Update(personahistorico1);
                   
                }
                else
                {
                    PersonaHistoricoDataContracts personahistorico = new PersonaHistoricoDataContracts();
                    personahistorico.Id = personita.Id;
                    personahistorico.Fecha_Cargo = DateTime.Now.Date;
                    personahistorico.Fecha_Codigo = DateTime.Now.Date;
                    personahistorico.Fecha_Contacto = DateTime.Now.Date;
                    personahistorico.Fecha_Cuit = DateTime.Now.Date;
                    personahistorico.Fecha_Documento = DateTime.Now.Date;
                    personahistorico.Fecha_Domicilios = DateTime.Now.Date;
                    personahistorico.Fecha_Emails = DateTime.Now.Date;
                    personahistorico.Fecha_Profesion = DateTime.Now.Date;
                    personahistorico.Fecha_Sector = DateTime.Now.Date;
                    personahistorico.Fecha_SubSector = DateTime.Now.Date;
                    personahistorico.Fecha_TipoCalificacion = DateTime.Now.Date;
                    personahistorico.Fecha_TipoDocumento = DateTime.Now.Date;
                    personahistorico.Fecha_Tratamiento = DateTime.Now.Date;
                    personahistorico.Fecha_Nombre = DateTime.Now.Date;
                    personahistorico.Fecha_Notas = DateTime.Now.Date;
                    personahistorico.Fecha_OrigenContacto = DateTime.Now.Date;
                    personahistorico.Fecha_Telefonos = DateTime.Now.Date;
                    personahistorico.Fecha_Vinculo = DateTime.Now.Date;                  
                    personaHistoricoService.Insert(personahistorico);
                }
            }
            IPersonaLivianoService personaLivianaService = ServiceClient<IPersonaLivianoService>.GetService("PersonaLivianoService");
            List<PersonaLivianoDataContracts> personasLivianos = new List<PersonaLivianoDataContracts>();
            personasLivianos = personaLivianaService.GetAllPersonaLivianos();
            Session["personasLivianos"] = personasLivianos;
            this.LimpiarPantalla("AltaPersona");
            InicilizaFechas(); 
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Un contacto del tipo Persona ha sido actualizado satisfactoriamente.');", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar guardar la persona');", true);
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
        if (Session["listaDeDomicilio"] != null)
            listaDeDomicilios = (List<DomicilioDataContracts>)Session["listaDeDomicilio"];

        listaDeDomicilios.Add(domicilio);
        Session["listaDeDomicilio"] = listaDeDomicilios;

        if (Session["listaDeDomicilio"] != null)
        {
            this.cmbDomicilio.DataSource = listaDeDomicilios;
            this.cmbDomicilio.DataTextField = "Domicilio_";
            this.cmbDomicilio.DataValueField = "Domicilio_";
            this.cmbDomicilio.DataBind();
        }
        this.lblFechaDomicilio.Text = DateTime.Now.Date.ToString().Substring(0, 10);
        LimpiarPopup("domicilio");
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
            case "tratamiento":
                {
                    this.txtTratamiento.Text= string.Empty;
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
            case "AltaPersona":
                {
                    this.txtNombre.Text = string.Empty;
                    this.txtOrigenContacto.Text = string.Empty;
                    this.txtVinculo.Text = string.Empty;
                    this.txtDoc.Text = string.Empty;
                    this.cmbDomicilio.Items.Clear();
                    this.txtCuit.Text = string.Empty;
                    this.cmbTelefono.Items.Clear();
                    this.cmbEmails.Items.Clear();
                    this.txtNotas.Text = string.Empty;
                    Session["listaDeDomicilio"] = null;
                    Session["listaDeTelefonos"] = null;
                    Session["listaDeEmails"] = null;
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
        if (Session["listaDeTelefonos"] != null)
            listaDeTelefonos = (List<TelefonoDataContracts>)Session["listaDeTelefonos"];

        listaDeTelefonos.Add(telefono);
        Session["listaDeTelefonos"] = listaDeTelefonos;
        if (Session["listaDeTelefonos"] != null)
        {
            this.cmbTelefono.DataSource = listaDeTelefonos;
            this.cmbTelefono.DataTextField = "Numero";
            this.cmbTelefono.DataValueField = "Numero";
            this.cmbTelefono.DataBind();
            //this.updatePanelGeneral.Update();
        }
        this.lblFechaTelefono.Text = DateTime.Now.Date.ToString().Substring(0,10);
        LimpiarPopup("telefono");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El teléfono se ha guardado temporalmente.');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelTelefonos", "javascript:CerrarPanelTelefonos();", true);


    }
    protected void btnAgregarEmail_Click(object sender, EventArgs e)
    {
        EmailDataContracts email = new EmailDataContracts();
        email.Emaill = this.txtEmail.Text;
        List<EmailDataContracts> listaDeEmails = new List<EmailDataContracts>();
        if (Session["listaDeEmails"] != null)
            listaDeEmails = (List<EmailDataContracts>)Session["listaDeEmails"];

        listaDeEmails.Add(email);
        Session["listaDeEmails"] = listaDeEmails;
        if (Session["listaDeEmails"] != null)
        {
            this.cmbEmails.DataSource = listaDeEmails;
            this.cmbEmails.DataTextField = "Emaill";
            this.cmbEmails.DataValueField = "Emaill";
            this.cmbEmails.DataBind();
            //this.updatePanelGeneral.Update();
        }
        this.lblfechaEmails.Text = DateTime.Now.Date.ToString().Substring(0, 10);
        LimpiarPopup("telefono");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El email se ha guardado temporalmente.');", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelEmails", "javascript:CerrarPanelEmails();", true);

    }
    protected void btnEliminarDomi_Click(object sender, EventArgs e)
    {
        List<DomicilioDataContracts> listaDeDomicilios = new List<DomicilioDataContracts>();
        List<DomicilioDataContracts> listaDeDomiciliosDefinitiva = new List<DomicilioDataContracts>();
        if (Session["listaDeDomicilio"] != null)
        {
            listaDeDomicilios = (List<DomicilioDataContracts>)Session["listaDeDomicilio"];
            foreach (var item in listaDeDomicilios)
            {
                if (!this.cmbDomicilio.SelectedItem.Text.Equals(item.Domicilio_))
                    listaDeDomiciliosDefinitiva.Add(item);

            }
            Session["listaDeDomicilio"] = listaDeDomiciliosDefinitiva;
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
        if (Session["listaDeTelefonos"] != null)
        {
            listaDeTelefonos = (List<TelefonoDataContracts>)Session["listaDeTelefonos"];
            foreach (var item in listaDeTelefonos)
            {
                if (!this.cmbTelefono.SelectedItem.Text.Equals(item.Numero))
                    listaDeTelefonosDefinitiva.Add(item);

            }
            Session["listaDeTelefonos"] = listaDeTelefonosDefinitiva;
            this.cmbTelefono.DataSource = listaDeTelefonosDefinitiva;
            this.cmbTelefono.DataTextField = "Numero";
            this.cmbTelefono.DataValueField = "Numero";
            this.cmbTelefono.DataBind();
            this.lblFechaTelefono.Text = DateTime.Now.Date.ToString().Substring(0, 10);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarTemp", "javascript:alert('El teléfono se ha eliminado temporalmente.');", true);

        }
    }


    protected void btnEliminarEmail_Click(object sender, EventArgs e)
    {
        List<EmailDataContracts> listaDeEmails = new List<EmailDataContracts>();
        List<EmailDataContracts> listaDeEmailsDefinitiva = new List<EmailDataContracts>();
        if (Session["listaDeEmails"] != null)
        {
            listaDeEmails = (List<EmailDataContracts>)Session["listaDeEmails"];
            foreach (var item in listaDeEmails)
            {
                if (!this.cmbEmails.SelectedItem.Text.Equals(item.Emaill))
                    listaDeEmailsDefinitiva.Add(item);

            }
            Session["listaDeEmails"] = listaDeEmailsDefinitiva;
            this.cmbEmails.DataSource = listaDeEmailsDefinitiva;
            this.cmbEmails.DataTextField = "Emaill";
            this.cmbEmails.DataValueField = "Emaill";
            this.cmbEmails.DataBind();
            this.lblfechaEmails.Text = DateTime.Now.Date.ToString().Substring(0, 10);
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
    protected void btnAgregarTratamiento_Click(object sender, EventArgs e)
    {
        try
        {
            ITratamientoService tratamientoService = ServiceClient<ITratamientoService>.GetService("TratamientoService");
            TratamientoDataContracts tratamiento = new TratamientoDataContracts();
            tratamiento.Descripcion = this.txtTratamiento.Text;
            tratamientoService.Insert(tratamiento);
            this.cmbTratamiento.DataSource = tratamientoService.GetAllTratamientos();
            this.cmbTratamiento.DataTextField = "descripcion";
            this.cmbTratamiento.DataValueField = "id";
            this.cmbTratamiento.DataBind();
            lblFechaTratamiento.Text = DateTime.Now.ToShortDateString();
            LimpiarPopup("tratamiento");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTratamiento", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevoTratamiento", "javascript:CerrarPanelNuevoTratamiento();", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void btnEliminarTratamiento_Click(object sender, EventArgs e)
    {
        try
        {
            ITratamientoService tratamientoService = ServiceClient<ITratamientoService>.GetService("TratamientoService");
            TratamientoDataContracts tratamiento = new TratamientoDataContracts();
            tratamiento.Descripcion = this.cmbTratamiento.SelectedItem.Text;
            tratamiento.Id =int.Parse( this.cmbTratamiento.SelectedValue.ToString());
            tratamientoService.Delete(tratamiento);
            this.cmbTratamiento.DataSource = tratamientoService.GetAllTratamientos();
            this.cmbTratamiento.DataTextField = "descripcion";
            this.cmbTratamiento.DataValueField = "id";
            this.cmbTratamiento.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTratamiento", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
           
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
            this.lblFechaCalificacion.Text = DateTime.Now.Date.ToString().Substring(0,10);
            LimpiarPopup("calificacion");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTratamiento", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevoTratamiento", "javascript:CerrarPanelNuevaCalificacion();", true);

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
            this.lblFechaCalificacion.Text = DateTime.Now.Date.ToString().Substring(0, 10);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTratamiento", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);

        }
    }
    protected void btnAgregarProfesion_Click(object sender, EventArgs e)
    {
        try
        {
            IProfesionService profesionService = ServiceClient<IProfesionService>.GetService("ProfesionService");
            ProfesionDataContracts profesion = new ProfesionDataContracts();
            profesion.Descripcion = this.txtProfesion.Text;
            profesionService.Insert(profesion);
            this.cmbProfesion.DataSource = profesionService.GetAllProfesions();
            this.cmbProfesion.DataTextField = "descripcion";
            this.cmbProfesion.DataValueField = "id";
            this.cmbProfesion.DataBind();
            lblFechaProfesion.Text = DateTime.Now.ToShortDateString();
            LimpiarPopup("profesion");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarProfesion", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevaProfesion", "javascript:CerrarPanelNuevaProfesion();", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void btnEliminarProfesion_Click(object sender, EventArgs e)
    {
        try
        {
            IProfesionService profesionService = ServiceClient<IProfesionService>.GetService("ProfesionService");
            ProfesionDataContracts profesion = new ProfesionDataContracts();
            profesion.Descripcion = this.cmbProfesion.SelectedItem.Text;
            profesion.Id = int.Parse(this.cmbProfesion.SelectedValue.ToString());
            profesionService.Delete(profesion);
            this.cmbProfesion.DataSource = profesionService.GetAllProfesions();
            this.cmbProfesion.DataTextField = "descripcion";
            this.cmbProfesion.DataValueField = "id";
            this.cmbProfesion.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarProfesion", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

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
        List<PersonaLivianoDataContracts> personasLivianos = new List<PersonaLivianoDataContracts>();
        if (Session["personasLivianos"] != null)
        {
        personasLivianos = (List<PersonaLivianoDataContracts>)Session["personasLivianos"];
        personasLivianos=personasLivianos.Where(p => p.Nombre.ToUpper().StartsWith(this.TextBox1.Text.ToUpper())).ToList();
        if (string.IsNullOrEmpty(this.TextBox1.Text))
        {
            personasLivianos.Clear();
        }
      
            DataTable dt = ConvertDataTable<PersonaLivianoDataContracts>.Convert((List<PersonaLivianoDataContracts>)personasLivianos);
            this.gvResultadosBusqueda.DataSource = dt;
            this.gvResultadosBusqueda.DataBind();
            if (personasLivianos.Count>0)
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AbrirPanelResultados", "javascript:AbrirPanelResultados();", true);
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelResultados", "javascript:CerrarPanelResultados();", true);

        }
        //if (string.IsNullOrEmpty(this.TextBox1.Text))
        //{ this.cmbRes.Items.Clear(); }
       
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "PosicionarAlFinal", "javascript:establerCursorPosicion(" + len.ToString()+ ");", true);

    }
    protected void GvResultadosBusqueda_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GvResultadosBusqueda_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Session["estoyEditando"] = true;
        int codigo = int.Parse(this.gvResultadosBusqueda.Rows[e.NewEditIndex].Cells[1].Text.Split('(')[1].Replace(")", string.Empty));
        IPersonaService personaService = ServiceClient<IPersonaService>.GetService("PersonaService");
        PersonaDataContracts persona = new PersonaDataContracts();
        persona=personaService.GetPersonaByCodigo(codigo);
        CompletarDatosDePersona(persona);
        Session["personaEditada"] = persona;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CerrarPanelResultados", "javascript:CerrarPanelResultados();", true);
    }

    private void CompletarDatosDePersona(PersonaDataContracts persona)
    {
        this.txtNombre.Text = persona.Nombre;
        this.cmbDomicilio.Items.Clear();
        foreach (var item in persona.Domicilios)
        {
            this.cmbDomicilio.Items.Add(new ListItem(item.Domicilio_,item.Id.ToString()));
        }
        this.cmbTelefono.Items.Clear();
        foreach (var item in persona.Telefonos)
        {
            this.cmbTelefono.Items.Add(new ListItem(item.Numero, item.Id.ToString()));
        }
        this.cmbEmails.Items.Clear();

        foreach (var item in persona.Emails)
        {
            this.cmbEmails.Items.Add(new ListItem(item.Emaill,item.Id.ToString()));
        }
        Session["listaDeEmails"] = persona.Emails;
        Session["listaDeDomicilio"] = persona.Domicilios;
        Session["listaDeTelefonos"] = persona.Telefonos;
        this.txtOrigenContacto.Text = persona.OrigenContacto;
        this.txtVinculo.Text = persona.Vinculo;
        if (persona.IdProfesion != 0)
        {
            try
            {
                this.cmbProfesion.SelectedValue = persona.IdProfesion.ToString();
            }
            catch (Exception)
            {
            }
        }

        this.cmbTipoDoc.SelectedValue = (persona.IdTipoDocumento == 0) ? "0" : persona.IdTipoDocumento.ToString();
        this.txtDoc.Text = string.IsNullOrEmpty(persona.Documento) ? string.Empty : persona.Documento;
        try
        {
            if (persona.IdTipoCalificacion == 0)
            {
                try
                {
                    this.cmbCalificacion.SelectedValue = persona.IdTipoCalificacion.ToString();
            
                }
                catch (Exception)
                {
                    
                }
            }
        }
        catch (Exception)
        {

            //this.cmbCalificacion.SelectedValue = "34";
        }
        try
        {
            if (persona.IdTratamiento != 0)
            {
                try
                {
                    this.cmbTratamiento.SelectedValue = persona.IdTratamiento.ToString();
                }
                catch (Exception)
                {
                    
                }
                
            }
        }
        catch (Exception)
        {

            //this.cmbTratamiento.SelectedValue = "290";
        }
        
        this.txtCuit.Text = (string.IsNullOrEmpty(persona.Cuit))? string.Empty:persona.Cuit;
        this.txtNotas.Text = (string.IsNullOrEmpty(persona.Notas))?string.Empty:persona.Notas;
        //this.updatePanelGeneral.Update();
        CompletarFechas(persona.Id);
    
    }

    private void CompletarFechas(int codigopersona) {
        InicilizaFechas();
        IPersonaHistoricoService personahistoricoService = ServiceClient<IPersonaHistoricoService>.GetService("PersonaHistoricoService");
        PersonaHistoricoDataContracts personahistorico = new PersonaHistoricoDataContracts();
        personahistorico = personahistoricoService.GetPersona(codigopersona);
        if (personahistorico != null) {
            lblFechaCalificacion.Text = personahistorico.Fecha_TipoCalificacion.ToString().Substring(0,10);
            lblFechaCuit.Text = personahistorico.Fecha_Cuit.ToString().Substring(0, 10);
            lblFechaDocumento.Text = personahistorico.Fecha_TipoDocumento.ToString().Substring(0, 10);
            lblFechaDomicilio.Text = personahistorico.Fecha_Domicilios.ToString().Substring(0, 10);
            lblfechaEmails.Text = personahistorico.Fecha_Emails.ToString().Substring(0, 10);
            lblFechaNombre.Text = personahistorico.Fecha_Nombre.ToString().Substring(0, 10);
            lblFechaOrigen.Text = personahistorico.Fecha_OrigenContacto.ToString().Substring(0, 10);
            lblFechaNotas.Text = personahistorico.Fecha_Notas.ToString().Substring(0, 10);
            lblFechaProfesion.Text = personahistorico.Fecha_Profesion.ToString().Substring(0, 10);
            lblFechaTelefono.Text = personahistorico.Fecha_Telefonos.ToString().Substring(0, 10);
            lblFechaTratamiento.Text = personahistorico.Fecha_Tratamiento.ToString().Substring(0, 10);
            lblFechaVinculo.Text = personahistorico.Fecha_Vinculo.ToString().Substring(0, 10);
        }   
    }

    private void InicilizaFechas() {
        lblFechaCalificacion.Text = "";
        lblFechaCuit.Text = "";
        lblFechaDocumento.Text = "";
        lblFechaDomicilio.Text = "";
        lblfechaEmails.Text = "";
        lblFechaNombre.Text = "";
        lblFechaNotas.Text = "";
        lblFechaOrigen.Text = "";
        lblFechaProfesion.Text = "";
        lblFechaTelefono.Text = "";
        lblFechaTratamiento.Text = "";
        lblFechaVinculo.Text = "";
    
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
            if (Session["personaEditada"] != null)
            {
                IPersonaService personaService = ServiceClient<IPersonaService>.GetService("PersonaService");
                PersonaDataContracts persona = new PersonaDataContracts();
                persona = ((PersonaDataContracts)Session["personaEditada"]);
                personaService.Delete(persona);
                IPersonaLivianoService personaLivianaService = ServiceClient<IPersonaLivianoService>.GetService("PersonaLivianoService");
                List<PersonaLivianoDataContracts> personasLivianos = new List<PersonaLivianoDataContracts>();
                personasLivianos = personaLivianaService.GetAllPersonaLivianos();
                Session["personasLivianos"] = personasLivianos;
                this.LimpiarPantalla("AltaPersona");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkDelete", "javascript:alert('La operación se ha realizado con éxito.');", true);
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkDelete", "javascript:alert('Debe seleccionar una persona para eliminar.');", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorDelete", "javascript:alert('Ha ocurrido al intentar realizar la operación.');", true);
        }
    }
   
}