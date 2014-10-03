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
using Gobbi.CoreServices.Security.Principal;

public partial class Vistas_UCPopupEditarGruposEmail : System.Web.UI.UserControl
{
    public delegate void UCPopupEditarGrupoEmail_SavedEventHandler();
    public event UCPopupEditarGrupoEmail_SavedEventHandler UCPopupEditarGrupoEmail_Saved;
    private const string CONST_AGREGAR_CONTACTO = "Agregar contacto...";

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

    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderEditarGrupoEmail
    {
        get { return this.ModalPopupResultados_EditarGrupoEmail; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.popupBuscarEmpresaPersona_GE.UCPopupBuscarRelacionSelected += new Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventHandler(popupBuscarEmpresaPersona_GE_UCPopupBuscarRelacionSelected);

        this.ModalPopupResultados_EditarGrupoEmail.PreRender += new EventHandler(ModalPopupResultados_EditarGrupoEmail_PreRender);

        if (!Page.IsPostBack)
        {

            cant = 1000;
            List<EmpresaPersonaDataContracts> listaVacia = new List<EmpresaPersonaDataContracts>();

            this.txtNombre1.Text = CONST_AGREGAR_CONTACTO;
            this.txtDescripcion.Text = "";

            if (!IsPostBack)
            {
                DateTime dt = DateTime.Parse("12:35 PM");
                MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                if (dt.ToString("tt") == "AM")
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                }
                else
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                }
                GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];

                CargarGruposEmail();
            }
        }
    }

    void ModalPopupResultados_EditarGrupoEmail_PreRender(object sender, EventArgs e)
    {
        if (this.MODO != null)
        {
            this.lblTitulo.Text = this.MODO + " Tarea";

            if (this.MODO.ToUpper().Equals("ELIMINAR"))
            {
                this.btnEliminar.Visible = true;
                this.btnAceptar.Visible = false;

            }
            else if (this.MODO.ToUpper().Equals("VER"))
            {
                this.btnEliminar.Visible = false;
                this.btnAceptar.Visible = false;
            }
            else
            {
                this.btnEliminar.Visible = false;
                this.btnAceptar.Visible = true;
                this.btnSearchNombre1_EditarGrupoEmail.Visible = true;
            }
        }
        CargarGruposEmail();

    }

    public void LimpiarPopup()
    {
        this.txtDescripcion.Text = "";
        this.hiddenId.Value = "";
        this.txtNombre1.Text = CONST_AGREGAR_CONTACTO;
        this.txtNombre1.BackColor = System.Drawing.Color.White;
        this.txtNombre1Hidden.Value = "";
        this.btnEliminar.Visible = false;
        this.btnSearchNombre1_EditarGrupoEmail.Visible = true;
        this.btnAgregarRelacion.Visible = false;
        //this.gvContenidoGrupoEmail.DataSource = new List<GrupoEmailContenidoDataContracts>();
        //this.gvContenidoGrupoEmail.DataBind();
        this.gvContenidoGrupoEmail.DataSource = new List<GrupoEmailContenidoLivianoDataContracts>();
        this.gvContenidoGrupoEmail.DataBind();
    }

    private void LimpiarPopup(string popup)
    {
        switch (popup)
        {
            case "cargo":
                {

                    break;
                }
        }

    }


    void popupBuscarEmpresaPersona_GE_UCPopupBuscarRelacionSelected(Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventArgs e)
    {
        this.txtNombre1.Text = e.empresaPersona.Nombre;
        this.txtNombre1Hidden.Value = e.empresaPersona.Codigo + "#" + e.empresaPersona.Tipo;
        this.lblEmpresaPersona1.Text = "Contacto";

        this.btnAgregarRelacion.Visible = true;
        this.ModalPopupResultados_EditarGrupoEmail.Show();
    }


    public void SetDatosModalPopupExtenderDatos(List<PersonaDataContracts> personaDataContracts)
    {
        //this.personaDetalle.DataSource = personaDataContracts;
        //this.personaDetalle.DataBind();

    }

    protected void btnSearchNombre1_EditarGrupoEmail_Click(object sender, EventArgs e)
    {
        this.ModalPopupResultados_EditarGrupoEmail.Hide();
        this.popupBuscarEmpresaPersona_GE.ModalPopupExtenderBuscarRelacion.Show();

    }

    protected void btnLimpiarEmpresaPersona_EditarTarea_Click(object sender, EventArgs e)
    {

        //this.txtEmpresaPersonaNombre.Text = "";
        //this.txtEmpresaPersonaNombreHidden.Value = "";
        //string contacto = this.txtEmpresaPersonaNombre.Text;
        //CargarTareas(DateTime.Parse(Calendar1.SelectedDate.ToShortDateString()), this.cmbUsuarioAsignado.SelectedValue, contacto);
    }

    protected void btnNueva_Click(object sender, EventArgs e)
    {
        this.LimpiarPopup();
        btnSearchNombre1_EditarGrupoEmail.Visible = true;
        this.btnEliminar.Visible = false;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            IGrupoEmailService grupoEmailService = ServiceClient<IGrupoEmailService>.GetService("GrupoEmailService");

            GrupoEmailDataContracts grupoEmail = new GrupoEmailDataContracts();
            grupoEmail.Id = (hiddenId.Value != "" ? int.Parse(hiddenId.Value) : 0);
            grupoEmail.Descripcion = txtDescripcion.Text;

            if (grupoEmailService.Load(grupoEmail.Id) == null)
            {
                grupoEmailService.Insert(grupoEmail);
            }
            else
            {
                grupoEmailService.Update(grupoEmail);
            }

            if (this.UCPopupEditarGrupoEmail_Saved != null)
                this.UCPopupEditarGrupoEmail_Saved();

            LimpiarPopup();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarGrupoEmail", "javascript:alert('El elemento ha sido actualizado satisfactoriamente.');", true);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

    protected void btnAgregarRelacion_Click(object sender, EventArgs e)
    {
        try
        {
            string idGrupo = this.hiddenId.Value;
            string codigoRelacion = this.txtNombre1Hidden.Value.Substring(0, this.txtNombre1Hidden.Value.IndexOf('#'));

            IGrupoEmailContenidoService grupoEmailContenidoServices = ServiceClient<IGrupoEmailContenidoService>.GetService("GrupoEmailContenidoService");
            GrupoEmailContenidoDataContracts gec = new GrupoEmailContenidoDataContracts();
            gec.IdGrupoEmail = int.Parse(idGrupo);
            gec.CodigoRelacion = codigoRelacion;

            if (grupoEmailContenidoServices.Load(gec.IdGrupoEmail, gec.CodigoRelacion) == null)
            {
                grupoEmailContenidoServices.Insert(gec);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarRelacion", "javascript:alert('El elemento ya existe.');", true);
            }

            this.txtNombre1.Text = CONST_AGREGAR_CONTACTO;
            this.txtNombre1Hidden.Value = "";
            this.btnAgregarRelacion.Visible = false;

            CargarContenidoGrupoEmail();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarRelacion", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

    private DataTable GetDataTableContenidoGrupoEmail(string idGrupo)
    {
        //List<GrupoEmailContenidoDataContracts> resultadoObtenidos = new List<GrupoEmailContenidoDataContracts>();

        //IGrupoEmailContenidoService grupoEmailContenidoServices = ServiceClient<IGrupoEmailContenidoService>.GetService("GrupoEmailContenidoService");
        //resultadoObtenidos = grupoEmailContenidoServices.GetAllGrupoEmailContenidoByIdGrupoEmail(int.Parse(idGrupo));

        //foreach (GrupoEmailContenidoDataContracts gec in resultadoObtenidos)
        //{
        //    gec.doCustomFill();
            
        //}

        //DataTable dataTable = ConvertDataTable<GrupoEmailContenidoDataContracts>.Convert(resultadoObtenidos);

        //return dataTable;

        List<GrupoEmailContenidoLivianoDataContracts> resultadoObtenidos = new List<GrupoEmailContenidoLivianoDataContracts>();

        IGrupoEmailContenidoLivianoService grupoEmailContenidoServices = ServiceClient<IGrupoEmailContenidoLivianoService>.GetService("GrupoEmailContenidoLivianoService");
        resultadoObtenidos = grupoEmailContenidoServices.GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int.Parse(idGrupo));

        //foreach (GrupoEmailContenidoLivianoDataContracts gec in resultadoObtenidos)
        //{
        //    gec.doCustomFill();

        //}

        DataTable dataTable = ConvertDataTable<GrupoEmailContenidoLivianoDataContracts>.Convert(resultadoObtenidos);

        return dataTable;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            IGrupoEmailService grupoEmailService = ServiceClient<IGrupoEmailService>.GetService("GrupoEmailService");
            IGrupoEmailContenidoService grupoEmailContenidoServices = ServiceClient<IGrupoEmailContenidoService>.GetService("GrupoEmailContenidoService");
        
            int id = (hiddenId.Value != "" ? int.Parse(hiddenId.Value) : 0);
            GrupoEmailDataContracts grupoEmail = grupoEmailService.Load(id);

            List<GrupoEmailContenidoDataContracts> emails = grupoEmailContenidoServices.GetAllGrupoEmailContenidoByIdGrupoEmail(grupoEmail.Id);
            foreach (GrupoEmailContenidoDataContracts email in emails)
            {
                grupoEmailContenidoServices.Delete(email);
            }

            grupoEmailService.Delete(grupoEmail);

            if (this.UCPopupEditarGrupoEmail_Saved != null)
                this.UCPopupEditarGrupoEmail_Saved();

            LimpiarPopup();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarRelacion", "javascript:alert('El elemento ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

    private void CargarGruposEmail()
    {

        this.gvGrupoEmail.DataSource = GetDataTableGrupoEmail();
        this.gvGrupoEmail.DataBind();
    }

    private DataTable GetDataTableGrupoEmail()
    {

        List<GrupoEmailDataContracts> resultadoObtenidos = new List<GrupoEmailDataContracts>();

        IGrupoEmailService grupoEmailServices = ServiceClient<IGrupoEmailService>.GetService("GrupoEmailService");

        resultadoObtenidos = grupoEmailServices.GetAllGrupoEmails();

        DataTable dataTable = ConvertDataTable<GrupoEmailDataContracts>.Convert(resultadoObtenidos);

        return dataTable;
    }


    protected DataTable gvGrupoEmail_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            dataTable = this.GetDataTableGrupoEmail();


        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected void gvGrupoEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvGrupoEmail.PageIndex = e.NewPageIndex;
        this.gvGrupoEmail.Fill();
    }


    protected void gvGrupoEmail_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((GridView)sender).SelectedIndex = ((System.Web.UI.WebControls.GridViewEditEventArgs)(e)).NewEditIndex;
        //((GridView)sender).SelectedRowStyle.BackColor = System.Drawing.Color.Blue;
        //((GridView)sender).SelectedRowStyle.ForeColor = System.Drawing.Color.White;
        ((GridView)sender).SelectedRowStyle.Font.Bold = true;

    }

    protected void gvGrupoEmail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());

        if (Session["FilaColorAnterior"] != null)
        {
            foreach (GridViewRow Fila in gvGrupoEmail.Rows)
            {
                if (Fila.Font.Bold == true)
                {
                    Fila.BackColor = (System.Drawing.Color)Session["FilaColorAnterior"];
                    //Fila.ForeColor = System.Drawing.Color.Black;
                    Fila.Font.Bold = false;
                }
            }
        }

        Session["FilaColorAnterior"] = gvGrupoEmail.Rows[index].BackColor;
        //gvGrupoEmail.Rows[index].BackColor = System.Drawing.Color.Blue;
        //gvGrupoEmail.Rows[index].ForeColor = System.Drawing.Color.White;
        gvGrupoEmail.Rows[index].Font.Bold = true;


        IGrupoEmailService grupoEmailServices = ServiceClient<IGrupoEmailService>.GetService("GrupoEmailService");
        IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        this.btnEliminar.Visible = false;
        if (e.CommandName == "Detalles")
        {
            string rowText = HttpUtility.HtmlDecode(gvGrupoEmail.Rows[index].Cells[1].Text);
            GrupoEmailDataContracts grupoEmail = grupoEmailServices.Load(int.Parse(rowText));

            this.hiddenId.Value = grupoEmail.Id.ToString();
            this.txtDescripcion.Text = grupoEmail.Descripcion;
            CargarContenidoGrupoEmail();
            this.btnEliminar.Visible = true;
            this.btnAgregarRelacion.Visible = false;
        }
    }

    private void CargarContenidoGrupoEmail()
    {
        string idGrupo = hiddenId.Value; 
        this.gvContenidoGrupoEmail.DataSource = GetDataTableContenidoGrupoEmail(idGrupo);
        this.gvContenidoGrupoEmail.DataBind();
    }


    protected DataTable gvContenidoGrupoEmail_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            string idgrupo = hiddenId.Value;
            dataTable = this.GetDataTableContenidoGrupoEmail(idgrupo);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected void gvContenidoGrupoEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvContenidoGrupoEmail.PageIndex = e.NewPageIndex;
        this.gvContenidoGrupoEmail.Fill();
    }


    protected void gvContenidoGrupoEmail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvContenidoGrupoEmail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            IGrupoEmailContenidoService grupoEmailContenidoServices = ServiceClient<IGrupoEmailContenidoService>.GetService("GrupoEmailContenidoService");
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "Eliminar")
            {
                string rowText = HttpUtility.HtmlDecode(gvContenidoGrupoEmail.Rows[index].Cells[1].Text);
                GrupoEmailContenidoDataContracts gec = grupoEmailContenidoServices.Load(int.Parse(this.hiddenId.Value), rowText);
                if (gec != null)
                {
                    grupoEmailContenidoServices.Delete(gec);
                    CargarContenidoGrupoEmail();

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarRelacion", "javascript:alert('El elemento ha sido eliminado satisfactoriamente.');", true);
                }


            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlEliminar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }


    public int CompararFechas(AgendaDataContracts fecha1, AgendaDataContracts fecha2)
    {


        return fecha1.FechaDeAlerta.CompareTo(fecha2.FechaDeAlerta);


    }

    public int CompararCriticidad(AgendaDataContracts agenda1, AgendaDataContracts agenda2)
    {

        int criticidad1 = int.Parse(agenda1.Criticidad);
        int criticidad2 = int.Parse(agenda2.Criticidad);

        return criticidad1.CompareTo(criticidad2);
    }

   
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string idGrupo = hiddenId.Value;
        this.gvContenidoGrupoEmail.DataSource = GetDataTableContenidoGrupoEmailOtrosFiltros(idGrupo);
        this.gvContenidoGrupoEmail.DataBind();

    }

    private DataTable GetDataTableContenidoGrupoEmailOtrosFiltros(string idGrupo)
    {
        
        List<GrupoEmailContenidoLivianoDataContracts> resultadoObtenidos = new List<GrupoEmailContenidoLivianoDataContracts>();

        IGrupoEmailContenidoLivianoService grupoEmailContenidoServices = ServiceClient<IGrupoEmailContenidoLivianoService>.GetService("GrupoEmailContenidoLivianoService");
        resultadoObtenidos = grupoEmailContenidoServices.GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int.Parse(idGrupo));

        List<GrupoEmailContenidoLivianoDataContracts> resultadoObtenidosFiltered = null;
        List<GrupoEmailContenidoLivianoDataContracts> list1 = new List<GrupoEmailContenidoLivianoDataContracts>();

        switch (chkOtrosFiltros.SelectedValue)
        {
            case "1":
                if (txtFiltro.Text != null && txtFiltro.Text.Trim().Length > 0)
                {
                    foreach (GrupoEmailContenidoLivianoDataContracts email in resultadoObtenidos)
                    {
                        if (email.CodigoRelacion.ToString().Contains(txtFiltro.Text.ToUpper()))
                        {
                            list1.Add(email);
                        }
                    }
                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(list1);
                }
                else
                {
                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(resultadoObtenidos);
                }
                break;
            case "2":
                if (txtFiltro.Text != null && txtFiltro.Text.Trim().Length > 0)
                {
                    foreach (GrupoEmailContenidoLivianoDataContracts email in resultadoObtenidos)
                    {
                        if (email.NombreRelacion.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()))
                        {
                            list1.Add(email);
                        }
                    }

                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(list1);
                }
                else
                {
                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(resultadoObtenidos);
                }
                break; 
            case "3":
                if (txtFiltro.Text != null && txtFiltro.Text.Trim().Length > 0)
                {
                    foreach (GrupoEmailContenidoLivianoDataContracts email in resultadoObtenidos)
                    {
                        if (email.Email.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()))
                        {
                            list1.Add(email);
                        }
                    }

                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(list1);
                }
                else
                {
                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(resultadoObtenidos);
                }
                break;
            case "4":
                if (txtFiltro.Text != null && txtFiltro.Text.Trim().Length > 0)
                {
                    foreach (GrupoEmailContenidoLivianoDataContracts email in resultadoObtenidos)
                    {
                        if (email.Cargo.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()))
                        {
                            list1.Add(email);
                        }
                    }

                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(list1);
                }
                else
                {
                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(resultadoObtenidos);
                }
                break;
            case "5":
                if (txtFiltro.Text != null && txtFiltro.Text.Trim().Length > 0)
                {
                    foreach (GrupoEmailContenidoLivianoDataContracts email in resultadoObtenidos)
                    {
                        if (email.NombreEmpresa.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()))
                        {
                            list1.Add(email);
                        }
                    }

                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(list1);
                }
                else
                {
                    resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(resultadoObtenidos);
                }
                break; 
            default:
                resultadoObtenidosFiltered = new List<GrupoEmailContenidoLivianoDataContracts>(resultadoObtenidos);
                break;
        }

        DataTable dataTable = ConvertDataTable<GrupoEmailContenidoLivianoDataContracts>.Convert(resultadoObtenidosFiltered);

        return dataTable;
    }

    protected void  btnBajaraExcel_Click(object sender, EventArgs e)
    {
        //ReportDocument reporteDoc = new ReportDocument();
        //reporteDoc.Load(Server.MapPath("GruposEmails.rpt"));
   
        
        //reporteDoc.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Informes por Premios");            
        

   }

}
