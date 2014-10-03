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


public partial class Vistas_UCPopupDatosEmpresa : System.Web.UI.UserControl
{
    private EmpresaPersonaDataContracts m_EmpresaPersona;
    public EmpresaPersonaDataContracts EmpresaPersona
    {
        get { return m_EmpresaPersona; }
        set { m_EmpresaPersona = value; }
    }

    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderDatosEmpresa
    {
        get { return this.ModalPopupDatosEmpresaItem; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ModalPopupExtenderDatosEmpresa.PreRender += new EventHandler(ModalPopupExtenderDatosEmpresa_PreRender);
    }

    void ModalPopupExtenderDatosEmpresa_PreRender(object sender, EventArgs e)
    {
        if (EmpresaPersona != null)
        {
            IEmpresaService empresaService = ServiceClient<IEmpresaService>.GetService("EmpresaService");
            EmpresaDataContracts empresa = new EmpresaDataContracts();
            empresa = empresaService.GetEmpresaByCodigo(Int32.Parse(EmpresaPersona.Codigo));


            CompletarDatosDeEmpresa(empresa);
        }
    }

    public void SetDatosModalPopupExtenderDatos(List<PersonaDataContracts> personaDataContracts)
    {
        //this.personaDetalle.DataSource = personaDataContracts;
        //this.personaDetalle.DataBind();

    }

    private void CompletarDatosDeEmpresa(EmpresaDataContracts empresa)
    {
        this.lblNombreRes.Text = empresa.Nombre;
        this.lblCuitRes.Text = empresa.Cuit;
        this.lblWebRes.Text = empresa.Web;
        this.lblHorarioRes.Text = empresa.Horario;
        this.lblNotasRes.Text = empresa.Notas;
        this.repDomicilios.DataSource = empresa.Domicilios;
        this.repDomicilios.DataBind();
        this.repTelefonos.DataSource = empresa.Telefonos;
        this.repTelefonos.DataBind();
        this.repEmails.DataSource = empresa.Emails;
        this.repEmails.DataBind();
        
        int IVA_SIN_ASIGNAR_ID = 5;
        IIvaService ivaService = ServiceClient<IIvaService>.GetService("IvaService");
        IvaDataContracts iva = ivaService.Load(empresa.IdIVA);
        if (iva == null) iva = ivaService.Load(IVA_SIN_ASIGNAR_ID);

        this.lblIVARes.Text = iva.Descripcion;

        int IIBB_SIN_ASIGNAR_ID = 5;
        IIIBBService iibbService = ServiceClient<IIIBBService>.GetService("IIBBService");
        IIBBDataContracts iibb = iibbService.Load(empresa.IdIIBB);
        if (iibb == null) iibb = iibbService.Load(IIBB_SIN_ASIGNAR_ID);

        this.lblIIBBRes.Text = iibb.Descripcion;
        
        this.lblOrigenContactoRes.Text = empresa.OrigenContacto;
        this.lblVinculoRes.Text = empresa.Vinculo;

        int CALIFICACION_SIN_ASIGNAR_ID = 34;
        ICalificacionService calificacionService = ServiceClient<ICalificacionService>.GetService("CalificacionService");
        CalificacionDataContracts calificacion = calificacionService.Load(empresa.IdTipoCalificacion);
        if (calificacion == null) calificacion = calificacionService.Load(CALIFICACION_SIN_ASIGNAR_ID);
        lblCalificacionRes.Text = calificacion.Descripcion;

    }

}
