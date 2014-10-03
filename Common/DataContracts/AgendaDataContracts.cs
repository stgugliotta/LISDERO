using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_agenda_historia
    /// Descripcion	: 
    /// </summary>
    public class AgendaHistoriaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Agenda
        /// </summary>
        public AgendaHistoriaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S

        /// <summary>
        /// 
        /// </summary>
        private int idTareaHistoria;

        /// <summary>
        /// 
        /// </summary>
        private int idTarea;

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        /// <summary>
        /// 
        /// </summary>
        private string usuarioAsignado;

        /// <summary>
        /// 
        /// </summary>
        private string tarea;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaDeAlerta;

        /// <summary>
        /// 
        /// </summary>
        private string estado;

        /// <summary>
        /// 
        /// </summary>
        private string criticidad;

        /// <summary>
        /// 
        /// </summary>
        private int codigoRelacion;
        /// <summary>
        /// 
        /// </summary>
        private int idTipoContacto;

        private int idTipoEvento;

        private int idEstado;

        private EmpresaPersonaDataContracts empresaPersona;

        private TipoEventoDataContracts tipoEvento;

        private System.DateTime fechaActualizacion;

        private string contactoEventual;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdTareaHistoria
        {
            get { return this.idTareaHistoria; }
            set { this.idTareaHistoria = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdTarea
        {
            get { return this.idTarea; }
            set { this.idTarea = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string UsuarioAsignado
        {
            get { return this.usuarioAsignado; }
            set { this.usuarioAsignado = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Tarea
        {
            get { return this.tarea; }
            set { this.tarea = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaDeAlerta
        {
            get { return this.fechaDeAlerta; }
            set { this.fechaDeAlerta = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Criticidad
        {
            get { return this.criticidad; }
            set { this.criticidad = value; }
        }

        public int CodigoRelacion
        {
            get { return this.codigoRelacion; }
            set { this.codigoRelacion = value; }
        }

        public int IdTipoContacto
        {
            get { return this.idTipoContacto; }
            set { this.idTipoContacto = value; }
        }

        public int IdTipoEvento
        {
            get { return this.idTipoEvento; }
            set { this.idTipoEvento= value; }
        }

        public int IdEstado
        {
            get { return this.idEstado; }
            set { this.idEstado = value; }
        }

        public EmpresaPersonaDataContracts EmpresaPersona
        {
            get { return this.empresaPersona; }
            set { this.empresaPersona = value; }
        }

        public TipoEventoDataContracts TipoEvento
        {
            get { return this.tipoEvento; }
            set { this.tipoEvento = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>System.DateTime</value>
        public System.DateTime FechaActualizacion
        {
            get { return this.fechaActualizacion; }
            set { this.fechaActualizacion = value; }
        }

        public string ContactoEventual
        {
            get { return this.contactoEventual; }
            set { this.contactoEventual = value; }
        }

        public string Contacto
        {
            get {
                if (this.empresaPersona != null)
                {
                    return empresaPersona.Nombre;
                }
                else
                {
                    return this.contactoEventual;
                }
            }
        }

        public string Hora
        {
            get
            {
                if (this.FechaDeAlerta != null)
                {
                    return fechaDeAlerta.TimeOfDay.Hours.ToString("00") + ":" + fechaDeAlerta.TimeOfDay.Minutes.ToString("00");
                }
                else
                {
                    return "";
                }
            }
        }

        public string Evento
        {
            get
            {
                if (this.tipoEvento != null)
                {
                    return tipoEvento.Descripcion;
                }
                else
                {
                    return "";
                }
            }
        }

        public string EventoRgbColor
        {
            get
            {
                if (this.tipoEvento != null)
                {
                    return tipoEvento.RgbColor;
                }
                else
                {
                    return "";
                }
            }
        }



        #endregion
    }
}
