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
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using Herramientas;


public partial class Vistas_UCPopupDatos : System.Web.UI.UserControl
{
    private EmpresaPersonaDataContracts m_EmpresaPersona;
    public EmpresaPersonaDataContracts EmpresaPersona
    {
        get { return m_EmpresaPersona; }
        set { m_EmpresaPersona = value; }
    }

    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderDatos
    {
        get { return this.ModalPopupDatosItem; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ModalPopupExtenderDatos.PreRender += new EventHandler(ModalPopupExtenderDatos_PreRender);
    }

    void ModalPopupExtenderDatos_PreRender(object sender, EventArgs e)
    {
        if (EmpresaPersona != null)
        {
            IPersonaService personaService = ServiceClient<IPersonaService>.GetService("PersonaService");
            PersonaDataContracts persona = new PersonaDataContracts();
            persona = personaService.GetPersonaByCodigo(Int32.Parse(EmpresaPersona.Codigo));
            CompletarDatosDePersona(persona);
        }
    }

    public void SetDatosModalPopupExtenderDatos(List<PersonaDataContracts> personaDataContracts)
    {
        //this.personaDetalle.DataSource = personaDataContracts;
        //this.personaDetalle.DataBind();

    }

    private void CompletarDatosDePersona(PersonaDataContracts persona)
    {
        this.lblNombreRes.Text = persona.Nombre;
        this.repDomicilios.DataSource = persona.Domicilios;
        this.repDomicilios.DataBind();

        this.repTelefonos.DataSource = persona.Telefonos;
        this.repTelefonos.DataBind();

        this.repEmails.DataSource = persona.Emails;
        this.repEmails.DataBind();

        this.lblOrigenContactoRes.Text = persona.OrigenContacto;
        this.lblVinculoRes.Text = persona.Vinculo;

        int PROFESION_SIN_ASIGNAR_ID = 38;
        IProfesionService profesionService = ServiceClient<IProfesionService>.GetService("ProfesionService");
        ProfesionDataContracts profesion = profesionService.Load(persona.IdProfesion);
        
        if (profesion == null)
        {
            profesion = profesionService.Load(PROFESION_SIN_ASIGNAR_ID);
        }

        this.lblProfesionRes.Text = profesion.Descripcion;

        string tipoDoc = null;
        if (persona.IdTipoDocumento == 1) tipoDoc = "DNI";
        if (persona.IdTipoDocumento == 2) tipoDoc = "LC";
        if (persona.IdTipoDocumento == 3) tipoDoc = "LE";

        this.lblDocumentoRes.Text = tipoDoc + " " + persona.Documento;

        int CALIFICACION_SIN_ASIGNAR_ID = 34;
        ICalificacionService calificacionService = ServiceClient<ICalificacionService>.GetService("CalificacionService");
        CalificacionDataContracts calificacion= calificacionService.Load(persona.IdTipoCalificacion);

        if (calificacion == null)
        {
            calificacion = calificacionService.Load(CALIFICACION_SIN_ASIGNAR_ID);
        }

        lblCalificacionRes.Text = calificacion.Descripcion;

        int TRATAMIENTO_SIN_ASIGNAR_ID = 296;
        ITratamientoService tratamientoService = ServiceClient<ITratamientoService>.GetService("TratamientoService");
        TratamientoDataContracts tratamiento = tratamientoService.Load(persona.IdTratamiento);

        if (tratamiento == null)
        {
            tratamiento = tratamientoService.Load(TRATAMIENTO_SIN_ASIGNAR_ID);
        }

        lblTratamientoRes.Text = tratamiento.Descripcion;

        this.lblCuitRes.Text = (string.IsNullOrEmpty(persona.Cuit)) ? string.Empty : persona.Cuit;
        this.lblNotasRes.Text = (string.IsNullOrEmpty(persona.Notas)) ? string.Empty : persona.Notas;

    }

}
