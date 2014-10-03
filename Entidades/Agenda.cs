using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Agenda
    /// </summary>
    public class Agenda : Entity<Agenda, AgendaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Agenda
        /// </summary>
        public Agenda()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idTarea;
        private string usuario;
        private string usuarioAsignado;
        private string tarea;
        private System.DateTime fechaDeAlerta;
        private string estado;
        private string criticidad;
        private int codigoRelacion;
        private int idTipoContacto;
        private int idTipoEvento;
        private int idEstado;
        private System.DateTime fechaActualizacion;
        private string contactoEventual;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdTarea
        {
            get { return this.idTarea; }
            set { this.idTarea = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string UsuarioAsignado
        {
            get { return this.usuarioAsignado; }
            set { this.usuarioAsignado = value; }
        }

        public string Tarea
        {
            get { return this.tarea; }
            set { this.tarea = value; }
        }

        public System.DateTime FechaDeAlerta
        {
            get { return this.fechaDeAlerta; }
            set { this.fechaDeAlerta = value; }
        }

        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

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
            set { this.idTipoEvento = value; }
        }

        public int IdEstado
        {
            get { return this.idEstado; }
            set { this.idEstado = value; }
        }
        
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


        #endregion
    }
}
