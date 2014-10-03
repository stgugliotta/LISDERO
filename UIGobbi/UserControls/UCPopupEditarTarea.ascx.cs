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
using Herramientas;

using System.Text;
using System.IO;
using Microsoft;


public partial class Vistas_UCPopupEditarTarea : System.Web.UI.UserControl
{

    private int cmbEventoSelectedIndex = 0;
    public delegate void UCPopupEditarTarea_SavedEventHandler();
    public event UCPopupEditarTarea_SavedEventHandler UCPopupEditarTarea_Saved;

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

    public AjaxControlToolkit.ModalPopupExtender ModalPopupExtenderEditarTarea
    {
        get { return this.ModalPopupResultados_EditarTarea; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.popupBuscarTareaNombre1.UCPopupBuscarRelacionSelected += new Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventHandler(popupBuscarTareaNombre1_UCPopupBuscarTareaSelected);

        this.popupBuscarEmpresaPersona.UCPopupBuscarRelacionSelected += new Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventHandler(popupBuscarEmpresaPersona_UCPopupBuscarRelacionSelected);

      

        this.ModalPopupResultados_EditarTarea.PreRender += new EventHandler(ModalPopupResultados_EditarTarea_PreRender);

        if (!Page.IsPostBack)
        {

            cant = 1000;
            List<EmpresaPersonaDataContracts> listaVacia = new List<EmpresaPersonaDataContracts>();


            this.txtNombre1.Text = "";
            this.txtEmpresaPersonaNombre.Text = "";
            this.txtTarea.Text = "";

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
                //TimeSelector1.SetTime(dt.Hour, dt.Minute, am_pm);

                this.Calendar1.SelectedDate = DateTime.Today;
                this.txtFechaNuevaTarea.Text = Calendar1.SelectedDate.ToShortDateString();
                GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];

                string contacto = txtEmpresaPersonaNombre.Text;
                CargarTareas(DateTime.Now, principal.Identity.Name, contacto);



                IAgendaEstadoService agendaEstadoService = ServiceClient<IAgendaEstadoService>.GetService("AgendaEstadoService");
                List<AgendaEstadoDataContracts> estados = new List<AgendaEstadoDataContracts>();
                estados = agendaEstadoService.GetAllAgendaEstado() ;
                /*AgendaEstadoDataContracts seleccioneAgendaEstado= new AgendaEstadoDataContracts();
                seleccioneAgendaEstado.Id = 0;
                seleccioneAgendaEstado.Descripcion = "--- SELECCIONE ---";
                estados.Insert(0, seleccioneAgendaEstado);*/

                this.cmbEstado.DataSource = estados;
                this.cmbEstado.DataTextField = "descripcion";
                this.cmbEstado.DataValueField = "id";
                this.cmbEstado.DataBind();

            }
        }
    }


    void ModalPopupResultados_EditarTarea_PreRender(object sender, EventArgs e)
    {
        //this.LimpiarPopup();
        if (this.MODO != null)
        {
            this.lblTitulo.Text = this.MODO + " Tarea";

            //this.btnSearchNombre2_EditarTarea.Visible = false;
            //this.btnAgregarCargos_.Visible= false;
            //this.btnEliminarCargo.Visible = false;
            if (this.MODO.ToUpper().Equals("ELIMINAR"))
            {
                this.btnEliminar.Visible = true;
                this.btnAceptar.Visible = false;
                this.cmbUsuarioAsignado.Enabled = false;
                this.cmbUsuarioAsignadoEdicion.Enabled = false;
                this.cmbEvento.Enabled = false;
                this.cmbEstado.Enabled = false;
                this.cmbCriticidad.Enabled = false;
                this.txtTarea.ReadOnly = true;
            }
            else if (this.MODO.ToUpper().Equals("VER"))
            {
                this.btnEliminar.Visible = false;
                this.btnAceptar.Visible = false;
                this.cmbUsuarioAsignado.Enabled = false;
                this.cmbUsuarioAsignadoEdicion.Enabled = false;
                this.cmbEvento.Enabled = false;
                this.cmbEstado.Enabled = false;
                this.cmbCriticidad.Enabled = false;
                this.txtTarea.ReadOnly = true;

            }
            else
            {
                this.btnEliminar.Visible = false;
                this.btnAceptar.Visible = true;
                this.cmbUsuarioAsignado.Enabled = true;
                this.cmbUsuarioAsignadoEdicion.Enabled = true;
                this.cmbEvento.Enabled = true;
                this.cmbEstado.Enabled = true;
                this.cmbCriticidad.Enabled = true;
                this.txtTarea.ReadOnly = false;
                this.btnSearchNombre1_EditarTarea.Visible = true;
                //this.btnSearchNombre2_EditarRelacion.Visible = true;
                //this.btnAgregarCargos_.Visible = true;
                // this.btnEliminarCargo.Visible = true;

            }

            this.Calendar1.SelectedDate = DateTime.Today;
            this.txtFechaNuevaTarea.Text = Calendar1.SelectedDate.ToShortDateString();


        }

        if (this.EmpresaPersona != null)
        {
            this.txtEmpresaPersonaNombre.Text = this.EmpresaPersona.Nombre;
            this.txtEmpresaPersonaNombreHidden.Value = this.EmpresaPersona.Codigo + "#" + this.EmpresaPersona.Tipo;
            this.lblEmpresaPersona.Text = "Contacto";

            if (this.EmpresaPersona.Tipo.ToUpper().Equals("PERSONA"))
            {
                this.txtEmpresaPersonaNombre.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            }
            else
            {
                this.txtEmpresaPersonaNombre.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
            }


            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            string contacto = txtEmpresaPersonaNombre.Text;
            CargarTareas(DateTime.Now, principal.Identity.Name, contacto);
        }


        ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");

        List<TipoEventoDataContracts> tiposDeEvento = new List<TipoEventoDataContracts>();
        tiposDeEvento = tipoEventoService.GetAllTiposDeEvento().Where( x => x.FechaDeshabilitacion == null).ToList();
        /*TipoEventoDataContracts seleccioneTipoEvento = new TipoEventoDataContracts();
        seleccioneTipoEvento.Id = 0;
        seleccioneTipoEvento.Descripcion = "--- SELECCIONE ---";
        seleccioneTipoEvento.RgbColor = "000000";
        tiposDeEvento.Insert(0, seleccioneTipoEvento);*/

        ListItem item = null;
        if (this.cmbEvento.SelectedIndex > 0)
        {
            cmbEventoSelectedIndex = this.cmbEvento.SelectedIndex ;
        }
        this.cmbEvento.Items.Clear();
        foreach (TipoEventoDataContracts evento in tiposDeEvento)
        {
            item = new ListItem(evento.Descripcion, evento.Id.ToString());
            //item.Enabled = false;
            //item.Attributes.Add("style", "color:#" + evento.RgbColor);
            this.cmbEvento.Items.Add(item);

        }

        this.cmbEvento.SelectedIndex = cmbEventoSelectedIndex;

        /*foreach (var item2 in this.cmbCriticidad.Items)
        {
            ((ListItem)item2).Attributes.Add("style", "color:#FFaaEE" );
            
        }*/
    }

    public void LimpiarPopup()
    {
        //this.txtEmpresaPersonaNombre.Text = "";
        //this.txtEmpresaPersonaNombre.BackColor = System.Drawing.Color.White;
        //this.txtEmpresaPersonaNombreHidden.Value = "";
        this.txtNombre1.Text = "";
        this.txtNombre1.BackColor = System.Drawing.Color.White;
        this.txtNombre1Hidden.Value = "";
        //this.txtNombre2.Text = "";
        //this.txtNombre2Hidden.Value = "";
        //this.cmbUsuarioAsignado.SelectedIndex = 0;
        this.cmbCriticidad.SelectedIndex = 0;
        this.cmbEvento.SelectedIndex = 0;
        this.cmbEstado.SelectedIndex = 0;
        this.txtTarea.Text = "";
        this.hiddenIdTarea.Value = "";
        this.btnEliminar.Visible = false;
        this.btnSearchNombre1_EditarTarea.Visible = true;
        //this.pnlCmbEvento.BackColor = System.Drawing.Color.Black;
        this.rptListActualizaciones.DataSource = null;
        this.rptListActualizaciones.DataBind();
        
       
    }
    private void LimpiarPopup(string popup)
    {
        switch (popup)
        {
            case "cargo":
                {

                    break;
                }
            case "tipoEvento":
                {
                    this.txtColorTipoEvento.Text = "";
                    this.txtTipoEvento.Text = "";
                    //this.pnlCmbEvento.BackColor = System.Drawing.Color.Black;
                    break;
                }
            case "estado":
                {
                    this.txtEstado.Text = "";
                    break;
                }
        }

    }

    void popupBuscarTareaNombre1_UCPopupBuscarTareaSelected(Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventArgs e)
    {
        this.ModalPopupResultados_EditarTarea.Show();
        this.txtNombre1.Text = e.empresaPersona.Nombre;
        this.txtNombre1Hidden.Value = e.empresaPersona.Codigo + "#" + e.empresaPersona.Tipo;
        this.lblEmpresaPersona1.Text = "Contacto";

    }

    void popupBuscarEmpresaPersona_UCPopupBuscarRelacionSelected(Vistas_UCPopupBuscarRelacion.UCPopupBuscarRelacionCommandEventArgs e)
    {
        this.ModalPopupResultados_EditarTarea.Show();
        this.txtEmpresaPersonaNombre.Text = e.empresaPersona.Nombre;
        this.txtEmpresaPersonaNombreHidden.Value = e.empresaPersona.Codigo + "#" + e.empresaPersona.Tipo;
        this.lblEmpresaPersona.Text = "Contacto";
        string contacto = this.txtEmpresaPersonaNombre.Text;
        CargarTareas(DateTime.Parse(Calendar1.SelectedDate.ToShortDateString()), this.cmbUsuarioAsignado.SelectedValue, contacto);
    }

    
    public void SetDatosModalPopupExtenderDatos(List<PersonaDataContracts> personaDataContracts)
    {
        //this.personaDetalle.DataSource = personaDataContracts;
        //this.personaDetalle.DataBind();

    }

    protected void btnSearchNombre1_EditarTarea_Click(object sender, EventArgs e)
    {
        cmbEventoSelectedIndex = this.cmbEvento.SelectedIndex;
        this.ModalPopupResultados_EditarTarea.Hide();
        this.popupBuscarTareaNombre1.ModalPopupExtenderBuscarRelacion.Show();

    }


    protected void btnSearchEmpresaPersona_EditarTarea_Click(object sender, EventArgs e)
    {
        this.ModalPopupResultados_EditarTarea.Hide();
        this.popupBuscarEmpresaPersona.ModalPopupExtenderBuscarRelacion.Show();

    }

    protected void btnLimpiarEmpresaPersona_EditarTarea_Click(object sender, EventArgs e)
    {

        this.txtEmpresaPersonaNombre.Text = "";
        this.txtEmpresaPersonaNombreHidden.Value = "";
        string contacto = this.txtEmpresaPersonaNombre.Text;
        CargarTareas(DateTime.Parse(Calendar1.SelectedDate.ToShortDateString()), this.cmbUsuarioAsignado.SelectedValue, contacto);
    }

    protected void btnNueva_Click(object sender, EventArgs e)
    {
        this.LimpiarPopup();
        btnSearchNombre1_EditarTarea.Visible = true;
        this.btnEliminar.Visible = false;
        this.hiddenIdTarea.Value = "";
        this.tsHorario.SelectedIndex = 0;
        //this.TimeSelector1.Date = DateTime.Today;
        this.cmbCriticidad.SelectedIndex = 0;
        this.cmbEstado.SelectedIndex = 0;
        this.cmbEvento.SelectedIndex = 0;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            IAgendaService agendaService = ServiceClient<IAgendaService>.GetService("AgendaService");

            AgendaDataContracts agenda = new AgendaDataContracts();

            string tipoRelacion1 = null, tipoRelacion2 = null;
            Boolean relEmpresa1 = false;

            if (this.txtNombre1Hidden.Value != null && this.txtNombre1Hidden.Value.Length > 0)
            {
                agenda.CodigoRelacion = int.Parse(this.txtNombre1Hidden.Value.Split('#')[0]);//int.Parse(txtNombre1.ToolTip);
                tipoRelacion1 = this.txtNombre1Hidden.Value.Split('#')[1];
                relEmpresa1 = ("empresa".Equals(tipoRelacion1.ToLower()));
            }
            else
            {
                agenda.CodigoRelacion = -1;
                agenda.ContactoEventual = this.txtNombre1.Text;
                agenda.IdTipoContacto = 3;
            }

            if (agenda.CodigoRelacion > -1)
            {
                if (relEmpresa1 == true)
                {
                    agenda.IdTipoContacto = 2; // empresa
                }
                else
                {
                    agenda.IdTipoContacto = 1; // persona
                }
            }


            agenda.IdTarea = (hiddenIdTarea.Value != "" ? int.Parse(hiddenIdTarea.Value) : 0);
            agenda.Tarea = txtTarea.Text;
            agenda.Criticidad = this.cmbCriticidad.SelectedItem.Value;

            //TimeSpan dt = this.TimeSelector1.Date.TimeOfDay;
             agenda.FechaDeAlerta = DateTime.Parse(this.txtFechaNuevaTarea.Text + " " + this.tsHorario.SelectedItem.Value);
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            agenda.Usuario = principal.Identity.Name;
            agenda.Estado = this.cmbEstado.SelectedItem.Text;//"PENDIENTE";
            agenda.IdEstado = int.Parse (this.cmbEstado.SelectedItem.Value);
            agenda.UsuarioAsignado = this.cmbUsuarioAsignadoEdicion.SelectedItem.Value; //this.cmbUsuarioAsignado.SelectedItem.Value;
            agenda.IdTipoEvento = int.Parse(this.cmbEvento.SelectedValue);


            if (agendaService.Load(agenda.IdTarea) == null)
            {
                agendaService.Insert(agenda);
            }
            else
            {
                agendaService.Update(agenda);
            }

            if (this.UCPopupEditarTarea_Saved != null)
                this.UCPopupEditarTarea_Saved();

            //this.ModalPopupExtenderEditarTarea.Hide();
            LimpiarPopup();
            this.Calendar1_SelectionChanged(sender, e);
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
            IAgendaService agendaService = ServiceClient<IAgendaService>.GetService("AgendaService");


            int idTarea = (hiddenIdTarea.Value != "" ? int.Parse(hiddenIdTarea.Value) : 0);
            AgendaDataContracts agenda = agendaService.Load(idTarea);
            agendaService.Delete(agenda);

            if (this.UCPopupEditarTarea_Saved != null)
                this.UCPopupEditarTarea_Saved();

            //this.ModalPopupExtenderEditarTarea.Hide();
            LimpiarPopup();
            Calendar1_SelectionChanged(sender, e);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlAgregarRelacion", "javascript:alert('El elemento ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }

    protected void Calendar1_SelectionChanged(object sender,
                                          EventArgs e)
    {
        this.LimpiarPopup();
        this.txtFechaNuevaTarea.Text = Calendar1.SelectedDate.ToShortDateString();
        //GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        string contacto = this.txtEmpresaPersonaNombre.Text;
        CargarTareas(DateTime.Parse(Calendar1.SelectedDate.ToShortDateString()), this.cmbUsuarioAsignado.SelectedValue, contacto);
    }

    private void CargarTareas(DateTime fecha, string analista, string contacto)
    {

        this.gvTareasAsignadas.DataSource = GetDataTableTareas(fecha, analista, contacto);
        this.gvTareasAsignadas.DataBind();
        this.gdvListaTareasMaximizada.DataSource = this.gvTareasAsignadas.DataSource;
        this.gdvListaTareasMaximizada.DataBind();
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tablesorter_gvTareasAsignadas", "doGvTareasAsignadasTableSorter();", true);
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tablesorter_gvTareasAsignadas", "setTimeout('doGvTareasAsignadasTableSorter()', 2000);", true);
        
    }


    private DataTable GetDataTableTareas(DateTime fecha, string analista, string contacto)
    {

        List<AgendaDataContracts> resultadoObtenidos = new List<AgendaDataContracts>();


        IAgendaService AgendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");

        //GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
        resultadoObtenidos = AgendaServices.GetAllAgendasByAnalistaYFecha(analista, fecha);

        //this.lstTareasAsignadas.Items.Clear();
        resultadoObtenidos.Sort(CompararFechas);
        resultadoObtenidos.Sort(CompararCriticidad);
        IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");

        foreach (AgendaDataContracts agenda in resultadoObtenidos)
        {

            EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(agenda.CodigoRelacion);
            TipoEventoDataContracts tipoEvento = tipoEventoService.Load(agenda.IdTipoEvento);
            agenda.EmpresaPersona = empresaPersona;
            agenda.TipoEvento = tipoEvento;
        }

        List<AgendaDataContracts> resultadoObtenidosFiltered = null;
        
        //var list = resultadoObtenidos.Find(g => g.EmpresaPersona.Nombre == contacto);
        if (contacto != null && contacto.Trim().Length > 0)
        {
            var list = resultadoObtenidos.Where(g => g.EmpresaPersona.Nombre.Equals(contacto)).ToList<AgendaDataContracts>(); 
            resultadoObtenidosFiltered = new List<AgendaDataContracts>(list);
        }
        else
        {
            resultadoObtenidosFiltered = new List<AgendaDataContracts>(resultadoObtenidos);
        }

        int orderField = 1;
        int direction = 1;
        switch (orderField){ 
            case 1: {
                var list = resultadoObtenidosFiltered.OrderBy(g => g.IdEstado);
                resultadoObtenidosFiltered = new List<AgendaDataContracts>(list);
                break;
            }
        }


        DataTable dataTable = ConvertDataTable<AgendaDataContracts>.Convert(resultadoObtenidosFiltered);

        return dataTable;
    }


    protected DataTable gvTareasAsignadas_Filling(object sender, EventArgs e)
    {
        DataTable dataTable = null;

        try
        {
            this.Calendar1.SelectedDate = DateTime.Today;
            this.txtFechaNuevaTarea.Text = Calendar1.SelectedDate.ToShortDateString();
            GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];
            string contacto = this.txtEmpresaPersonaNombre.Text;
            dataTable = this.GetDataTableTareas(Calendar1.SelectedDate, principal.Identity.Name, contacto);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dataTable;
    }

    protected void gvTareasAsignadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvTareasAsignadas.PageIndex = e.NewPageIndex;
        this.gvTareasAsignadas.Fill();
    }


    protected void gvTareasAsignadas_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((GridView)sender).SelectedIndex = ((System.Web.UI.WebControls.GridViewEditEventArgs)(e)).NewEditIndex;
        //((GridView)sender).SelectedRowStyle.BackColor = System.Drawing.Color.Blue;
        //((GridView)sender).SelectedRowStyle.ForeColor = System.Drawing.Color.White;
        ((GridView)sender).SelectedRowStyle.Font.Bold = true;

    }

    protected void gvTareasAsignadas_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        // asignar color al forecolor de la fila
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string idTarea = e.Row.Cells[UIUtils.GetPosCol(this.gvTareasAsignadas, "IdTarea")].Text;
            ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");
            IAgendaService agendaService = ServiceClient<IAgendaService>.GetService("AgendaService");
            int idTipoEvento = agendaService.Load(int.Parse(idTarea)).IdTipoEvento;
            string idCriticidad = agendaService.Load(int.Parse(idTarea)).Criticidad;

            //TipoEventoDataContracts tipoEvento = tipoEventoService.Load(idTipoEvento);

            //e.Row.Cells[UIUtils.GetPosCol(this.gvTareasAsignadas, "Evento")].ForeColor = System.Drawing.ColorTranslator.FromHtml("#" + tipoEvento.RgbColor);
            //e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#" + tipoEvento.RgbColor);
            switch (Convert.ToInt32(idCriticidad))
            {
                case 1:
                    e.Row.ForeColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    e.Row.ForeColor = System.Drawing.Color.Orange;
                    break;
                case 3:
                    e.Row.ForeColor = System.Drawing.Color.Green;
                    break;
                case 4:
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                    break;
                default:
                    break;
            }

            int colTareaPos = UIUtils.GetPosCol(this.gvTareasAsignadas, "Tarea");
            // for example i want to show just 8 char
            e.Row.Cells[colTareaPos].ToolTip = e.Row.Cells[colTareaPos].Text;
            if (e.Row.Cells[colTareaPos].Text.Length > 20)
            {
                e.Row.Cells[colTareaPos].Text = e.Row.Cells[colTareaPos].Text.Substring(0, 20);
                e.Row.Cells[colTareaPos].Text += " ...";
            }

        }

    }

    protected void gvTareasAsignadas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());

        if (Session["FilaColorAnterior"] != null)
        {
            foreach (GridViewRow Fila in gvTareasAsignadas.Rows)
            {
                if (Fila.Font.Bold == true)
                {
                    Fila.BackColor = (System.Drawing.Color)Session["FilaColorAnterior"];
                    //Fila.ForeColor = System.Drawing.Color.Black;
                    Fila.Font.Bold = false;
                }
            }
        }

        Session["FilaColorAnterior"] = gvTareasAsignadas.Rows[index].BackColor;
        //gvTareasAsignadas.Rows[index].BackColor = System.Drawing.Color.Blue;
        //gvTareasAsignadas.Rows[index].ForeColor = System.Drawing.Color.White;
        gvTareasAsignadas.Rows[index].Font.Bold = true;


        IAgendaService agendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");
        IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        this.btnEliminar.Visible = false;
        if (e.CommandName == "Detalles")
        {
            string rowText = HttpUtility.HtmlDecode(gvTareasAsignadas.Rows[index].Cells[1].Text);
            AgendaDataContracts agenda = agendaServices.Load(int.Parse(rowText));
            EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(agenda.CodigoRelacion);
            agenda.EmpresaPersona = empresaPersona;

            this.hiddenIdTarea.Value = agenda.IdTarea.ToString();
            this.txtNombre1.Text = agenda.Contacto;
            if (agenda.EmpresaPersona != null)
            {
                this.txtNombre1Hidden.Value = agenda.EmpresaPersona.Codigo + "#" + agenda.EmpresaPersona.Tipo;
                if (agenda.EmpresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                {
                    this.txtNombre1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
                }
                else
                {
                    this.txtNombre1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
                }

            }
            this.txtTarea.Text = agenda.Tarea;
            this.txtFechaNuevaTarea.Text = agenda.FechaDeAlerta.ToShortDateString();
            //this.TimeSelector1.Date = agenda.FechaDeAlerta;
            tsHorario.SelectedValue = agenda.Hora.Split(' ')[0];
            this.cmbCriticidad.SelectedValue = agenda.Criticidad;
            //this.cmbUsuarioAsignado.SelectedValue = agenda.UsuarioAsignado;
            this.cmbUsuarioAsignadoEdicion.SelectedValue = agenda.UsuarioAsignado;
            try
            {
                this.cmbEvento.SelectedValue = agenda.IdTipoEvento.ToString();
            }
            catch (Exception)
            {
                this.cmbEvento.SelectedValue = "-1";
            }
            try
            {
                this.cmbEstado.SelectedValue = agenda.IdEstado.ToString();
            }
            catch (Exception ex)
            {
            }
            ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");
            TipoEventoDataContracts tipoEvento = tipoEventoService.Load(agenda.IdTipoEvento);
            //this.pnlCmbEvento.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + tipoEvento.RgbColor);

            cmbEventoSelectedIndex = this.cmbEvento.SelectedIndex;
            //this.cmbEstado.SelectedValue = agenda.IdEstado.ToString();
            this.btnEliminar.Visible = true;
            //this.btnSearchNombre1_EditarTarea.Visible = false;

        // Cargar la bitacora
            this.rptListActualizaciones.DataSource = agendaServices.GetAllAgendasHistoriaByIdTarea(agenda.IdTarea); ; //TODO: completar
            this.rptListActualizaciones.DataBind();

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



    protected void cmbUsuarioAsignado_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Calendar1_SelectionChanged(sender, e);
    }

    protected void cmbEvento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");
        int idx = ((DropDownList)sender).SelectedIndex;

        ListItem item = (ListItem)((DropDownList)sender).Items[((DropDownList)sender).SelectedIndex];
        TipoEventoDataContracts tipoEvento = tipoEventoService.Load(int.Parse(item.Value));
        //this.pnlCmbEvento.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + tipoEvento.RgbColor);
        this.cmbEvento.SelectedIndex = idx;
        cmbEventoSelectedIndex = idx;
    }


    // Tipo evento 

    protected void btnAgregarTipoEvento_Click(object sender, EventArgs e)
    {
        try
        {
            ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");
            TipoEventoDataContracts tipoEvento = new TipoEventoDataContracts();
            tipoEvento.Descripcion = this.txtTipoEvento.Text;
            tipoEvento.RgbColor = this.txtColorTipoEvento.Text;
            tipoEventoService.Insert(tipoEvento);

            /*TipoEventoDataContracts seleccioneTipoEvento = new TipoEventoDataContracts();
            seleccioneTipoEvento.Id = 0;
            seleccioneTipoEvento.Descripcion = "--- SELECCIONE ---";
            seleccioneTipoEvento.RgbColor = "000000";*/
            List<TipoEventoDataContracts> tiposDeEvento = tipoEventoService.GetAllTiposDeEvento().Where(x => x.FechaDeshabilitacion == null).ToList();
            //tiposDeEvento.Insert(0, seleccioneTipoEvento);

            ListItem item = null;
            this.cmbEvento.Items.Clear();
            foreach (TipoEventoDataContracts evento in tiposDeEvento)
            {
                item = new ListItem(evento.Descripcion, evento.Id.ToString());
                // item.Enabled = false;
                //item.Attributes.Add("style", "color:#" + evento.RgbColor);
                this.cmbEvento.Items.Add(item);
            }

            LimpiarPopup("tipoEvento");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTipoEvento", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevoTipoEvento", "javascript:CerrarPanelNuevoTipoEvento();", true);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }


    protected void btnEliminarTipoEvento_Click(object sender, EventArgs e)
    {
        try
        {
            ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");
            TipoEventoDataContracts tipoEvento = tipoEventoService.Load(int.Parse(this.cmbEvento.SelectedValue));
            tipoEvento.FechaDeshabilitacion = DateTime.Now;
            tipoEventoService.Update(tipoEvento);
            
            List<TipoEventoDataContracts> tiposDeEvento = tipoEventoService.GetAllTiposDeEvento().Where(x => x.FechaDeshabilitacion == null).ToList();
            //tiposDeEvento.Insert(0, seleccioneTipoEvento);
            ListItem item = null;
            this.cmbEvento.Items.Clear();
            foreach (TipoEventoDataContracts evento in tiposDeEvento)
            {
                item = new ListItem(evento.Descripcion, evento.Id.ToString());
                //item.Attributes.Add("style", "color:#" + evento.RgbColor);
                this.cmbEvento.Items.Add(item);
            }
            LimpiarPopup("tipoEvento");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTipoEvento", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);

        }
    }



    protected void btnAgregarEstado_Click(object sender, EventArgs e)
    {
        try
        {
            IAgendaEstadoService agendaEstadoService = ServiceClient<IAgendaEstadoService>.GetService("AgendaEstadoService");
            AgendaEstadoDataContracts estado = new AgendaEstadoDataContracts();
            estado.Descripcion = this.txtEstado.Text;
            agendaEstadoService.Insert(estado);

            /*AgendaEstadoDataContracts seleccioneEstado = new AgendaEstadoDataContracts();
            seleccioneEstado.Id = 0;
            seleccioneEstado.Descripcion = "--- SELECCIONE ---";*/
            List<AgendaEstadoDataContracts> estados = agendaEstadoService.GetAllAgendaEstado();
            //estados.Insert(0, seleccioneEstado);

            this.cmbEstado.DataSource = estados;
            this.cmbEstado.DataTextField = "descripcion";
            this.cmbEstado.DataValueField = "id";
            this.cmbEstado.DataBind();

            LimpiarPopup("estado");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTipoEvento", "javascript:alert('El elemento ha sido agregado satisfactoriamente.');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlGuardarNuevoTipoEvento", "javascript:CerrarPanelNuevoTipoEvento();", true);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);
        }
    }


    protected void btnEliminarEstado_Click(object sender, EventArgs e)
    {
        try
        {
            IAgendaEstadoService agendaEstadoService = ServiceClient<IAgendaEstadoService>.GetService("AgendaEstadoService");
            AgendaEstadoDataContracts estado = new AgendaEstadoDataContracts();
            estado.Id = int.Parse(this.cmbEstado.SelectedValue);
            agendaEstadoService.Delete(estado);
            /*AgendaEstadoDataContracts seleccioneEstado = new AgendaEstadoDataContracts();
            seleccioneEstado.Id = 0;
            seleccioneEstado.Descripcion = "--- SELECCIONE ---";*/
            //seleccioneEstado.RgbColor = "000000";
            List<AgendaEstadoDataContracts> estados = agendaEstadoService.GetAllAgendaEstado();
            //estados.Insert(0, seleccioneEstado);

            //TODO:dadada
            this.cmbEstado.DataSource = estados;
            this.cmbEstado.DataTextField = "descripcion";
            this.cmbEstado.DataValueField = "id";
            this.cmbEstado.DataBind();
            LimpiarPopup("estado");

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OkAlEliminarTipoEvento", "javascript:alert('El elemento seleccionado ha sido eliminado satisfactoriamente.');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorAlGuardar", "javascript:alert('Ha ocurrido un inconveniente al intentar realizar la operación');", true);

        }
    }

    protected void txtNombre1_TextChanged(object sender, System.EventArgs e)
    {
        txtNombre1Hidden.Value = "";
    }

    protected void rptListActualizaciones_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        

        IAgendaService agendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");
        IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        this.btnEliminar.Visible = false;
        if (e.CommandName == "MostrarTarea")
        {
            LinkButton btn = e.CommandSource as LinkButton;

            RepeaterItem item = btn.NamingContainer as RepeaterItem;
            foreach (RepeaterItem rpt in rptListActualizaciones.Items)
            {
                Panel p1 = rpt.FindControl("Panel1") as Panel;
                p1.BackColor = System.Drawing.Color.White;
            }


            Panel p = item.FindControl("Panel1") as Panel;
            p.BackColor = System.Drawing.Color.LightBlue;



            int idTareaHistoria = Convert.ToInt32(e.CommandArgument.ToString());

            AgendaHistoriaDataContracts agenda = agendaServices.LoadHistorica(idTareaHistoria);

            EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(agenda.CodigoRelacion);
            agenda.EmpresaPersona = empresaPersona;

            this.hiddenIdTarea.Value = agenda.IdTarea.ToString();
            this.txtNombre1.Text = agenda.Contacto;
            if (agenda.EmpresaPersona != null)
            {
                this.txtNombre1Hidden.Value = agenda.EmpresaPersona.Codigo + "#" + agenda.EmpresaPersona.Tipo;
                if (agenda.EmpresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                {
                    this.txtNombre1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
                }
                else
                {
                    this.txtNombre1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCCC");
                }

            }
            this.txtTarea.Text = agenda.Tarea;
            this.txtFechaNuevaTarea.Text = agenda.FechaDeAlerta.ToShortDateString();
            //this.TimeSelector1.Date = agenda.FechaDeAlerta;
            tsHorario.SelectedValue = agenda.Hora.Split(' ')[0];
            this.cmbCriticidad.SelectedValue = agenda.Criticidad;
            //this.cmbUsuarioAsignado.SelectedValue = agenda.UsuarioAsignado;
            this.cmbUsuarioAsignadoEdicion.SelectedValue = agenda.UsuarioAsignado;
            this.cmbEvento.SelectedValue = agenda.IdTipoEvento.ToString();
            this.cmbEstado.SelectedValue = agenda.IdEstado.ToString();

            ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");
            TipoEventoDataContracts tipoEvento = tipoEventoService.Load(agenda.IdTipoEvento);
            //this.pnlCmbEvento.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + tipoEvento.RgbColor);

            cmbEventoSelectedIndex = this.cmbEvento.SelectedIndex;
            this.cmbEstado.SelectedValue = agenda.IdEstado.ToString();
            this.btnEliminar.Visible = true;
            //this.btnSearchNombre1_EditarTarea.Visible = false;
        }
    }

    
    protected void btnBuscarDatos_Click(object sender, EventArgs e)
    {
        this.LimpiarPopup();
        this.Calendar1.SelectedDate = DateTime.Today;
        this.txtFechaNuevaTarea.Text = Calendar1.SelectedDate.ToShortDateString();
        GobbiPrincipal principal = (GobbiPrincipal)Session["UserPrincipal"];

        string contacto = txtEmpresaPersonaNombre.Text;     

        CargarTareasOtrosFiltros(DateTime.Now, principal.Identity.Name, contacto);         
    }

    private void CargarTareasOtrosFiltros(DateTime fecha, string analista, string contacto)
    {

        this.gvTareasAsignadas.DataSource = GetDataTableTareasOtrosFiltros(analista,fecha);
        this.gvTareasAsignadas.DataBind();
        this.gdvListaTareasMaximizada.DataSource = this.gvTareasAsignadas.DataSource;
        this.gdvListaTareasMaximizada.DataBind();
    }

    //private void CargarTareasOtrosFiltrosListaMaximizada(DateTime fecha, string analista, string contacto)
    //{

    //    this.gdvListaTareasMaximizada.DataSource = GetDataTableTareasOtrosFiltros(analista, fecha);
    //    this.gdvListaTareasMaximizada.DataBind();
    //}


    private DataTable GetDataTableTareasOtrosFiltros(string analista,DateTime fecha)
    {


        IAgendaService AgendaServices = ServiceClient<IAgendaService>.GetService("AgendaService");

        List<AgendaDataContracts> resultadoObtenidosFiltered = null;
        List<AgendaDataContracts> resultadoObtenidosFilteredByContacto = new List<Common.DataContracts.AgendaDataContracts>();
        List<AgendaDataContracts> list1 = new List<AgendaDataContracts>();

        resultadoObtenidosFiltered = AgendaServices.BuscarAgendaPorFiltros(chkOpcionesIdTarea.Checked, txtFiltroIdTarea.Text,
                                                                            chkOpcionesHora.Checked, txtFiltroHora.Text,
                                                                            chkOpcionesEvento.Checked, txtFiltroEvento.Text,
                                                                            chkOpcionesTipoEvento.Checked, txtFiltroTipoEvento.Text,
                                                                            chkOpcionesUsuario.Checked, txtFiltroUsuario.Text,
                                                                            chkOpcionesFechaAct.Checked, txtFiltroFechaAct.Text,
                                                                            chkOpcionesPrioridad.Checked, txtFiltroPrioridad.Text,
                                                                            chkOpcionesTarea.Checked, txtFiltroTarea.Text,
                                                                            chkOpcionesEstado.Checked, txtFiltroEstado.Text,chkOpcionesContacto.Checked, txtFiltroContacto.Text);


        resultadoObtenidosFiltered.Sort(CompararFechas);
        resultadoObtenidosFiltered.Sort(CompararCriticidad);
        IEmpresaPersonaService empresasPersonasService = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        ITipoEventoService tipoEventoService = ServiceClient<ITipoEventoService>.GetService("TipoEventoService");

            foreach (AgendaDataContracts agenda in resultadoObtenidosFiltered)
            {
                EmpresaPersonaDataContracts empresaPersona = empresasPersonasService.Load(agenda.CodigoRelacion);
                TipoEventoDataContracts tipoEvento = tipoEventoService.Load(agenda.IdTipoEvento);
                agenda.EmpresaPersona = empresaPersona;
                agenda.TipoEvento = tipoEvento;

                if (chkOpcionesContacto.Checked)
                {
                    if (empresaPersona != null)
                    {
                        if (empresaPersona.Nombre.ToLower().Contains(txtFiltroContacto.Text.ToLower()))
                        {
                            resultadoObtenidosFilteredByContacto.Add(agenda);
                        }
                    }

                }
            }
        

        if (chkOpcionesContacto.Checked)
            resultadoObtenidosFiltered = resultadoObtenidosFilteredByContacto;

        if (!chkOpcionesIncluirFinalizadas.Checked)
        {
            resultadoObtenidosFiltered = resultadoObtenidosFiltered.Where(x => x.Estado.ToLower() != "finalizado").ToList();
        }


        int orderField = 1;
        int direction = 1;
        switch (orderField)
        {
            case 1:
                {
                    var list = resultadoObtenidosFiltered.OrderBy(g => g.IdEstado);
                    resultadoObtenidosFiltered = new List<AgendaDataContracts>(list);
                    break;
                }
        }


        DataTable dataTable = ConvertDataTable<AgendaDataContracts>.Convert(resultadoObtenidosFiltered);
        return dataTable;
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        
        chkOpcionesIdTarea.Checked=false;
        chkOpcionesHora.Checked=false;
        chkOpcionesEvento.Checked=false;
        chkOpcionesTipoEvento.Checked=false;
        chkOpcionesUsuario.Checked=false;
        chkOpcionesFechaAct.Checked=false;
        chkOpcionesPrioridad.Checked=false;
        chkOpcionesTarea.Checked=false;
        chkOpcionesEstado.Checked = false;
        txtFechaNuevaTarea.Text = "";
        txtFiltroEstado.Text = "";
        txtFiltroEvento.Text = "";
        txtFiltroFechaAct.Text = "";
        txtFiltroHora.Text = "";
        txtFiltroIdTarea.Text = "";
        txtFiltroPrioridad.Text = "";
        txtFiltroTarea.Text = "";
        txtFiltroTipoEvento.Text = "";
        txtFiltroUsuario.Text = "";
        txtFiltroContacto.Text = "";

    }

    protected void btnExportarExcel_Click(object sender, EventArgs e)
    {

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        
        gvTareasAsignadas.EnableViewState = false;
        gvTareasAsignadas.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
  
        //Export the GridView to Excel
        //GridView aa = new GridView();
        //aa.DataSource = gvModificacion.DataSource;


        Session["CACHE_TAREAS_A_EXPORTAR"] = null;
        Session["CACHE_TAREAS_A_EXPORTAR"] = gvTareasAsignadas.DataSource;
        
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "javascript:AbrirVentanaPequenia('ViewExportToExcelHDR.aspx','_blank');", true);
        //this.StartupScriptKey++;  

    }



    //public void BuscarAgendaFiltros(int IdTarea, string FiltroIdTarea, int Hora, string FiltroHora)
    //{
    //    try
    //    {
    //        DBConnection oDbConnection = DBConnection.Instancia;
    //        Db = oDbConnection.Db;
    //        ObjConnection = oDbConnection.ObjConnection;
    //        ObjCommand = oDbConnection.ObjCommand;
    //        ObjCommand.Connection = ObjConnection; 

    //        CommandText = "PA_MG_FRONT_Agenda_SelectALL_Filtro";
    //        CommandType = CommandType.StoredProcedure;
    //        ArrayList oParameters = new ArrayList();

    //        oParameters.Add(new DBParametro("@IdTarea", DbType.Int32, IdTarea));
    //        oParameters.Add(new DBParametro("@FiltroIdTarea", DbType.String, FiltroIdTarea));
    //        oParameters.Add(new DBParametro("@Hora", DbType.Int32, Hora));
    //        oParameters.Add(new DBParametro("@FiltroHora", DbType.String, FiltroHora));

    //        object idEmpresa = ExecuteScalar(oParameters);
    //    }
    //    catch (Exception ex)
    //    {
    //        Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmpresaHistorico, Insert", ex.Message);

    //        throw new GobbiTechnicalException(
    //            string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
    //    }
    //}

    protected void ListarTarea_Click(object sender, EventArgs e)
    {
        this.ModalPopupResultados_EditarTarea.Hide();  
       // CargarTareasOtrosFiltrosListaMaximizada(DateTime.Now, principal.Identity.Name, contacto);   
        this.ModalPopupListaMaximizada.Show();
    }
}
