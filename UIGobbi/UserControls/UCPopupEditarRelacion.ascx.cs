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


public partial class Vistas_UCPopupEditarRelacion : System.Web.UI.UserControl
{
    public delegate void UCPopupEditarRelacion_SavedEventHandler();
    public event UCPopupEditarRelacion_SavedEventHandler UCPopupEditarRelacion_Saved;

    private EmpresaPersonaDataContracts m_EmpresaPersona;
    public EmpresaPersonaDataContracts EmpresaPersona
    {

        get { return m_EmpresaPersona; }

        set { m_EmpresaPersona = value; }

    }

    private EmpresaPersonaDataContracts m_EmpresaPersona2;
    public EmpresaPersonaDataContracts EmpresaPersona2
    {

        get { return m_EmpresaPersona2; }

        set { m_EmpresaPersona2 = value; }

    }

    private string m_MODO;
    public string MODO
    {
        get { return m_MODO; }
        set { m_MODO = value; }
    }

    private static int cant;

    /*public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderBuscarRelacion
    { 
        get { return this.ModalPopupResultados_EditarRelacion; } 
    }*/
    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderEditarRelacion
    {
        get { return this.ModalPopupResultados_EditarRelacion; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.popupBuscarRelacionNombre1.UCPopupBuscarRelacionSelected += new Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventHandler(popupBuscarRelacionNombre1_UCPopupBuscarRelacionSelected);
        this.popupBuscarRelacionNombre2.UCPopupBuscarRelacionSelected += new Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventHandler(popupBuscarRelacionNombre2_UCPopupBuscarRelacionSelected);
        this.ModalPopupResultados_EditarRelacion.PreRender += new EventHandler(ModalPopupResultados_EditarRelacion_PreRender);

        if (!Page.IsPostBack)
        {

            cant = 1000;
            List<EmpresaPersonaDataContracts> listaVacia = new List<EmpresaPersonaDataContracts>();
            DataTable dt = ConvertDataTable<EmpresaPersonaDataContracts>.Convert(listaVacia);

            ICargoService cargoService = ServiceClient<ICargoService>.GetService("CargoService");
            List<CargoDataContracts> cargos = new List<CargoDataContracts>();
            cargos = cargoService.GetAllCargos();
            CargoDataContracts seleccioneCargo = new CargoDataContracts();
            seleccioneCargo.Id = 0;
            seleccioneCargo.Descripcion = "--- SELECCIONE ---";
            cargos.Insert(0, seleccioneCargo);

            this.cmbCargo.DataSource = cargos;
            this.cmbCargo.DataTextField = "descripcion";
            this.cmbCargo.DataValueField = "id";
            this.cmbCargo.DataBind();
            this.txtNombre1.Text = "";
            this.txtNombre2.Text = "";
            this.txtRelacion.Text = "";
            //this.btnEliminar.Visible = false;

        }
    }

    void ModalPopupResultados_EditarRelacion_PreRender(object sender, EventArgs e)
    {
        //this.LimpiarPopup();
        if (this.MODO != null)
        {
            this.lblTitulo.Text = this.MODO + " Relación";

            this.btnSearchNombre2_EditarRelacion.Visible = false;
            this.btnAgregarCargos_.Visible= false;
            this.btnEliminarCargo.Visible = false;
            if (this.MODO.ToUpper().Equals("ELIMINAR"))
            {
                this.btnEliminar.Visible = true;
                this.btnAceptar.Visible = false;
                this.cmbCargo.Enabled = false;
                this.txtRelacion.ReadOnly = true;
            }
            else if (this.MODO.ToUpper().Equals("VER"))
            {
                this.btnEliminar.Visible = false;
                this.btnAceptar.Visible = false;
                this.cmbCargo.Enabled = false;
                this.txtRelacion.ReadOnly = true;
            
            }
            else
            {
                this.btnEliminar.Visible = false;
                this.btnAceptar.Visible = true;
                this.cmbCargo.Enabled = true;
                this.txtRelacion.ReadOnly = false;
                this.btnSearchNombre2_EditarRelacion.Visible = true;
                this.btnAgregarCargos_.Visible = true;
                this.btnEliminarCargo.Visible = true;
            }                      
        }

        if (this.EmpresaPersona != null)
        {
            this.txtNombre1.Text = this.EmpresaPersona.Nombre;
            this.txtNombre1Hidden.Value = this.EmpresaPersona.Codigo + "#" + this.EmpresaPersona.Tipo;
            this.lblEmpresaPersona1.Text = this.EmpresaPersona.Tipo + " #1";
            
            if (this.EmpresaPersona.Tipo.ToUpper().Equals("PERSONA"))
            {
                this.txtNombre1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            }
            else
            {
                this.txtNombre1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
            }
        }
       
        if (this.EmpresaPersona2 != null)
        {
            this.txtNombre2.Text = this.EmpresaPersona2.Nombre;
            this.txtNombre2Hidden.Value = this.EmpresaPersona2.Codigo + "#" + this.EmpresaPersona2.Tipo;
            this.lblEmpresaPersona2.Text = this.EmpresaPersona2.Tipo + " #2";
            //this.btnSearchNombre2_EditarRelacion.Visible = false;

            if (this.EmpresaPersona2.Tipo.ToUpper().Equals("PERSONA"))
            {
                this.txtNombre2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            }
            else
            {
                this.txtNombre2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
            }

            ITelefonoService telefonoservice = ServiceClient<ITelefonoService>.GetService("TelefonoService");
            List<TelefonoDataContracts> tele = new List<TelefonoDataContracts>();
            tele = telefonoservice.GetAllTelefonos();

            if (tele != null)
            {
                foreach (TelefonoDataContracts telefonito in tele)
                {
                    if (this.EmpresaPersona2.Codigo.Equals(telefonito.Codigo))
                    {
                        this.txtTelefono.Text = telefonito.Numero;
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
                    if (this.EmpresaPersona2.Codigo.Equals(mailcito.IdRelacion))
                    {
                        this.txtEmail.Text = mailcito.Emaill;
                    }
                }
            }



            IRelacionService relacionService = ServiceClient<IRelacionService>.GetService("RelacionService");
            RelacionDataContracts rela = relacionService.Load(Int32.Parse(EmpresaPersona.Codigo), Int32.Parse(EmpresaPersona2.Codigo));
            if (rela != null)
            {
                if (rela.IdCargo > -1) this.cmbCargo.SelectedValue = rela.IdCargo.ToString();
                this.txtRelacion.Text = rela.TextoRelacion;
            }
        }
    }

    public void LimpiarPopup()
    {
        this.txtNombre1.Text = "";
        this.txtNombre1Hidden.Value = "";
        this.txtNombre2.Text = "";
        this.txtNombre2Hidden.Value = "";
        this.cmbCargo.SelectedIndex = 0;
        this.txtRelacion.Text = "";
    }
    private void LimpiarPopup(string popup)
    {
        switch (popup)
        {
            case "cargo":
                {
                    this.txtCargo.Text = string.Empty;
                    break;
                }
        }

    }

    protected void btnAgregarCargo_Click(object sender, EventArgs e)
    {
        try
        {
            ICargoService cargoService = ServiceClient<ICargoService>.GetService("CargoService");
            CargoDataContracts cargo = new CargoDataContracts();
            cargo.Descripcion = this.txtCargo.Text;
            cargoService.Insert(cargo);

            CargoDataContracts seleccioneCargo = new CargoDataContracts();
            seleccioneCargo.Id = 0;
            seleccioneCargo.Descripcion = "--- SELECCIONE ---";
            List<CargoDataContracts> cargos = cargoService.GetAllCargos();
            cargos.Insert(0, seleccioneCargo);

            this.cmbCargo.DataSource = cargos;//cargoService.GetAllCargos();
            this.cmbCargo.DataTextField = "descripcion";
            this.cmbCargo.DataValueField = "id";
            this.cmbCargo.DataBind();
            LimpiarPopup("cargo");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTratamiento", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevoTratamiento", "javascript:CerrarPanelNuevaCargo();", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }
    protected void btnEliminarCargo_Click(object sender, EventArgs e)
    {
        try
        {
            ICargoService cargoService = ServiceClient<ICargoService>.GetService("CargoService");
            CargoDataContracts cargo = new CargoDataContracts();
            cargo.Descripcion = this.cmbCargo.SelectedItem.Text;
            cargo.Id = int.Parse(this.cmbCargo.SelectedValue.ToString());
            cargoService.Delete(cargo);
            CargoDataContracts seleccioneCargo = new CargoDataContracts();
            seleccioneCargo.Id = 0;
            seleccioneCargo.Descripcion = "--- SELECCIONE ---";
            List<CargoDataContracts> cargos = cargoService.GetAllCargos();
            cargos.Insert(0, seleccioneCargo);

            this.cmbCargo.DataSource = cargos;//cargoService.GetAllCargos();

            this.cmbCargo.DataTextField = "descripcion";
            this.cmbCargo.DataValueField = "id";
            this.cmbCargo.DataBind();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarCargo", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);

        }
    }

    void popupBuscarRelacionNombre1_UCPopupBuscarRelacionSelected(Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventArgs e)
    {
        this.ModalPopupResultados_EditarRelacion.Show();
        this.txtNombre1.Text = e.empresaPersona.Nombre;
        this.txtNombre1Hidden.Value = e.empresaPersona.Codigo + "#" + e.empresaPersona.Tipo;
        this.lblEmpresaPersona1.Text = e.empresaPersona.Tipo + " #1";

    }

    void popupBuscarRelacionNombre2_UCPopupBuscarRelacionSelected(Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventArgs e)
    {
        this.ModalPopupResultados_EditarRelacion.Show();
        this.txtNombre2.Text = e.empresaPersona.Nombre;
        this.txtNombre2Hidden.Value = e.empresaPersona.Codigo + "#" + e.empresaPersona.Tipo;
        this.lblEmpresaPersona2.Text = e.empresaPersona.Tipo + " #2";
    }

    public void SetDatosModalPopupExtenderDatos(List<PersonaDataContracts> personaDataContracts)
    {
        //this.personaDetalle.DataSource = personaDataContracts;
        //this.personaDetalle.DataBind();

    }

    protected void btnSearchNombre1_EditarRelacion_Click(object sender, EventArgs e)
    {
        this.ModalPopupResultados_EditarRelacion.Hide();
        this.popupBuscarRelacionNombre1.ModalPopupExtenderBuscarRelacion.Show();

    }

    protected void btnSearchNombre2_EditarRelacion_Click(object sender, EventArgs e)
    {
        this.ModalPopupResultados_EditarRelacion.Hide();
        this.popupBuscarRelacionNombre2.ModalPopupExtenderBuscarRelacion.Show();

    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            IRelacionService relacionService = ServiceClient<IRelacionService>.GetService("RelacionService");
            RelacionDataContracts relacion = new RelacionDataContracts();
            string tipoRelacion1 = null, tipoRelacion2 = null;
            Boolean relEmpresa1 = false;
            Boolean relEmpresa2 = false;
            if (this.txtNombre1Hidden.Value != null)
            {
                relacion.Codigo1 = int.Parse(this.txtNombre1Hidden.Value.Split('#')[0]);//int.Parse(txtNombre1.ToolTip);
                tipoRelacion1 = this.txtNombre1Hidden.Value.Split('#')[1];
                relEmpresa1 = ("empresa".Equals(tipoRelacion1.ToLower()));

            }
            if (this.txtNombre2Hidden.Value != null)
            {
                relacion.Codigo2 = int.Parse(this.txtNombre2Hidden.Value.Split('#')[0]);//int.Parse(txtNombre1.ToolTip);
                tipoRelacion2 = this.txtNombre1Hidden.Value.Split('#')[1];
                relEmpresa2 = ("empresa".Equals(tipoRelacion2.ToLower()));
            }

            if (relEmpresa1 == true && relEmpresa2 == true)
            {
                relacion.IdTipoRelacion = 3;
            }
            else if (relEmpresa1 == false && relEmpresa2 == false)
            {
                relacion.IdTipoRelacion = 1;
            }
            else
            {
                relacion.IdTipoRelacion = 2;
            }
            relacion.TextoRelacion = txtRelacion.Text;

            relacion.IdCargo = int.Parse(this.cmbCargo.SelectedItem.Value);

            if (relacionService.Load(relacion.Codigo1, relacion.Codigo2) == null)
            {
                relacionService.Insert(relacion);
            }
            else
            {
                relacionService.Update(relacion);
            }

            if (this.UCPopupEditarRelacion_Saved != null)
                this.UCPopupEditarRelacion_Saved();

            this.ModalPopupExtenderEditarRelacion.Hide();
            LimpiarPopup();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarRelacion", "javascript:alert('El elemento ha sido actualizado satisfactoriamente.');", true);


        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            IRelacionService relacionService = ServiceClient<IRelacionService>.GetService("RelacionService");
            RelacionDataContracts relacion = new RelacionDataContracts();
            string tipoRelacion1 = null, tipoRelacion2 = null;
            Boolean relEmpresa1 = false;
            Boolean relEmpresa2 = false;
            if (this.txtNombre1Hidden.Value != null)
            {
                relacion.Codigo1 = int.Parse(this.txtNombre1Hidden.Value.Split('#')[0]);//int.Parse(txtNombre1.ToolTip);
                tipoRelacion1 = this.txtNombre1Hidden.Value.Split('#')[1];
                relEmpresa1 = ("empresa".Equals(tipoRelacion1.ToLower()));

            }
            if (this.txtNombre2Hidden.Value != null)
            {
                relacion.Codigo2 = int.Parse(this.txtNombre2Hidden.Value.Split('#')[0]);//int.Parse(txtNombre1.ToolTip);
                tipoRelacion2 = this.txtNombre1Hidden.Value.Split('#')[1];
                relEmpresa2 = ("empresa".Equals(tipoRelacion2.ToLower()));
            }

            relacionService.Delete(relacion);
            if (this.UCPopupEditarRelacion_Saved != null)
                this.UCPopupEditarRelacion_Saved();

            this.ModalPopupExtenderEditarRelacion.Hide();
            LimpiarPopup();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarRelacion", "javascript:alert('El elemento ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

}
