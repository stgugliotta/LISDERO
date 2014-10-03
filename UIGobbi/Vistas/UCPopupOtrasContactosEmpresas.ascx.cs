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


public partial class Vistas_UCPopupOtrasContactosEmpresas : System.Web.UI.UserControl
{

    private EmpresaPersonaDataContracts m_EmpresaPersona;
    public EmpresaPersonaDataContracts EmpresaPersona
    {

        get { return m_EmpresaPersona; }

        set { m_EmpresaPersona = value; }

    }

    private string m_MODO;
    public string MODO
    {
        get { return m_MODO; }
        set { m_MODO = value; }
    }

    private static int cant;

    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderOtrosContactosEmpresa
    {
        get { return this.ModalPopupOtrosContactosEmpresa; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ModalPopupExtenderOtrosContactosEmpresa.PreRender += new EventHandler(ModalPopupExtenderOtrosContactosEmpresa_PreRender); 
    }

    void ModalPopupExtenderOtrosContactosEmpresa_PreRender(object sender, EventArgs e)
    {
        if (EmpresaPersona != null)
        {
            IEmpresaService empresaService = ServiceClient<IEmpresaService>.GetService("EmpresaService");
            EmpresaDataContracts empresa = new EmpresaDataContracts();
            empresa = empresaService.GetEmpresaByCodigo(Int32.Parse(EmpresaPersona.Codigo));
            CompletarDatosDeEmpresa(empresa);
            CargarGrillasOtrosContactos(empresa.Codigo.ToString());
            //CargarGrillasEmpresas();
        }
    }

    

    private void CompletarDatosDeEmpresa(EmpresaDataContracts empresa)
    {
        
        this.lblNombreResEmpresa.Text = empresa.Nombre;
        this.lblCuitEmpresa.Text = empresa.Cuit;
        this.lblWebResEmpresa.Text = empresa.Web;
        this.lblHorarioResEmpresa.Text = empresa.Horario;
        this.lblNotasEmpresa.Text = empresa.Notas;
        this.repDomiciliosEmpresa.DataSource = empresa.Domicilios;
        this.repDomiciliosEmpresa.DataBind();
        this.repTelefonosEmpresa.DataSource = empresa.Telefonos;
        this.repTelefonosEmpresa.DataBind();
        this.repEmailsEmpresa.DataSource = empresa.Emails;
        this.repEmailsEmpresa.DataBind();

        int IVA_SIN_ASIGNAR_ID = 5;
        IIvaService ivaService = ServiceClient<IIvaService>.GetService("IvaService");
        IvaDataContracts iva = ivaService.Load(empresa.IdIVA);
        if (iva == null) iva = ivaService.Load(IVA_SIN_ASIGNAR_ID);

        this.lblIVAResEmpresa.Text = iva.Descripcion;

        int IIBB_SIN_ASIGNAR_ID = 5;
        IIIBBService iibbService = ServiceClient<IIIBBService>.GetService("IIBBService");
        IIBBDataContracts iibb = iibbService.Load(empresa.IdIIBB);
        if (iibb == null) iibb = iibbService.Load(IIBB_SIN_ASIGNAR_ID);

        this.lblIIBBResEmpresa.Text = iibb.Descripcion;

        this.lblOrigenContactoResEmpresa.Text = empresa.OrigenContacto;
        this.lblVinculoResEmpresa.Text = empresa.Vinculo;

        int CALIFICACION_SIN_ASIGNAR_ID = 34;
        ICalificacionService calificacionService = ServiceClient<ICalificacionService>.GetService("CalificacionService");
        CalificacionDataContracts calificacion = calificacionService.Load(empresa.IdTipoCalificacion);
        if (calificacion == null) calificacion = calificacionService.Load(CALIFICACION_SIN_ASIGNAR_ID);
        lblCalificacionResEmpresa.Text = calificacion.Descripcion;

    }

    //private void CargarGrillasEmpresas()
    //{
    //    List<EmpresaPersonaDataContracts> empresasPersonas;
    //    IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
    //    empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaRelaciones(EmpresaPersona.Codigo);

    //    List<EmpresaPersonaDataContracts> empresas = new List<EmpresaPersonaDataContracts>();

    //    if (empresasPersonas != null)
    //    {
    //        foreach (var empresaPersonaDataContract in empresasPersonas)
    //        {
    //            if (empresaPersonaDataContract.Tipo.ToUpper().Equals("EMPRESA"))
    //            {
    //                empresas.Add(empresaPersonaDataContract);
    //            }
    //        }

    //        DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(empresas);
    //        gvResultadoEmpresa.DataSource = dt;
    //        gvResultadoEmpresa.DataBind();

    //    }

    //}


    ////protected void gvResultadoEmpresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
    ////{

    ////}

    //protected void gvResultadoEmpresa_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        // Display the company name in italics.
    //        //  this.HiddenPersonaSelected.Value= e.Row.Cells[1].Text ;      
    //    }
    //}

    ////protected void gvResultadoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
    ////{

    ////}

    //protected DataTable gvResultadoEmpresa_Filling(object sender, EventArgs e)
    //{
    //    return new DataTable();
    //}

    ////protected void gvResultadoEmpresa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    ////{

    ////}

    ////protected void gvResultadoEmpresa_RowEditing(object sender, GridViewEditEventArgs e)
    ////{

    ////}

    //protected void gvResultadoEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.CommandArgument.ToString());
    //    string rowText = HttpUtility.HtmlDecode(this.gvResultadoEmpresa.Rows[index].Cells[2].Text);


    //    IEmpresaService empresaService = ServiceClient<IEmpresaService>.GetService("EmpresaService");
    //    EmpresaDataContracts empresa = new EmpresaDataContracts();
    //    empresa = empresaService.GetEmpresaByCodigo(Int32.Parse(rowText));
    //    if (empresa != null)
    //    {
    //        CompletarDatosDeEmpresa(empresa);
    //        CargarGrillasOtrosContactos(rowText);
    //    }

    //}

    //private void verrelacion(PersonaDataContracts persona, EmpresaDataContracts empresa)
    //{


    //    if (empresa != null)
    //    {

    //        ITelefonoService telefonoservice = ServiceClient<ITelefonoService>.GetService("TelefonoService");
    //        List<TelefonoDataContracts> tele = new List<TelefonoDataContracts>();
    //        tele = telefonoservice.GetAllTelefonos();

    //        if (tele != null)
    //        {
    //            foreach (TelefonoDataContracts telefonito in tele)
    //            {
    //                if (persona.Codigo.Equals(telefonito.Codigo))
    //                {
    //                    txtTelefono.Text = telefonito.Numero;
    //                }
    //            }
    //        }

    //        IEmailService emailservice = ServiceClient<IEmailService>.GetService("EmailService");
    //        List<EmailDataContracts> mail = new List<EmailDataContracts>();
    //        mail = emailservice.GetAllEmails();

    //        if (mail != null)
    //        {
    //            foreach (EmailDataContracts mailcito in mail)
    //            {
    //                if (persona.Codigo.Equals(mailcito.IdRelacion))
    //                {
    //                    this.txtEmail.Text = mailcito.Emaill;
    //                }
    //            }
    //        }

    //        IRelacionService relacionService = ServiceClient<IRelacionService>.GetService("RelacionService");
    //        RelacionDataContracts rela = relacionService.Load(persona.Codigo, empresa.Codigo);
    //        if (rela != null)
    //        {
    //            if (rela.IdCargo > -1) this.cmbCargo.SelectedValue = rela.IdCargo.ToString();
    //            this.txtRelacion.Text = rela.TextoRelacion;
    //        }
    //    }

    //}


    private void CargarGrillasOtrosContactos(String CodigoEmpresa)
    {

        List<EmpresaPersonaDataContracts> empresasPersonas;
        IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        empresasPersonas = empresasPersonasService.GetAllEmpresaPersonaRelaciones(CodigoEmpresa);

        List<EmpresaPersonaDataContracts> personas = new List<EmpresaPersonaDataContracts>();

        if (empresasPersonas != null)
        {

            foreach (var empresaPersonaDataContract in empresasPersonas)
            {
                if (empresaPersonaDataContract.Tipo.ToUpper().Equals("PERSONA"))
                {
                    personas.Add(empresaPersonaDataContract);                    
                }
            }


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Nombre", typeof(string)),  
                                new DataColumn("Cargo", typeof(string)),  
                                new DataColumn("Telefono",typeof(string)),
                                new DataColumn("Email",typeof(string)) });

            foreach (var personita in personas)
            {
                DataRow row = dt.NewRow();
                row[0] = personita.NombreYCodigo;

                IRelacionService relacionService1 = ServiceClient<IRelacionService>.GetService("RelacionService");
                RelacionDataContracts rela1 = relacionService1.GetRelacion(Int32.Parse(personita.Codigo), Int32.Parse(CodigoEmpresa));

                if (rela1 != null)
                {
                    row[1] = rela1.TextoRelacion;
                }

                ITelefonoService telefonoservice = ServiceClient<ITelefonoService>.GetService("TelefonoService");
                List<TelefonoDataContracts> tele = new List<TelefonoDataContracts>();
                tele = telefonoservice.GetAllTelefonos();

                if (tele != null)
                {
                    foreach (TelefonoDataContracts telefonito in tele)
                    {
                        if (personita.Codigo.Equals(telefonito.Codigo))
                        {
                            row[2] = telefonito.Numero;
                        }
                    }
                }

                IEmailService emailservice = ServiceClient<IEmailService>.GetService("EmailService");
                List<EmailDataContracts> mail = new List<EmailDataContracts>();
                mail = emailservice.GetAllEmails();

                if (mail != null)
                {
                    foreach (EmailDataContracts mailcito in mail)
                    {
                        if (personita.Codigo.Equals(mailcito.IdRelacion))
                        {
                            row[3] = mailcito.Emaill;
                        }
                    }
                }
                dt.Rows.Add(row);

            }

            gvResultadoPersona.DataSource = dt;
            gvResultadoPersona.DataBind();
        }
    }

}