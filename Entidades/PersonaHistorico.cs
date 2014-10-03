using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    public class PersonaHistorico : Entity <PersonaHistorico, PersonaHistoricoDataContracts>
    {
        #region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  PersonaHistorico
		/// </summary>
		public  PersonaHistorico()
		{
		}
		#endregion

        #region A T T R I B U T E S
        private int id;
        private System.DateTime fecha_codigo;
        private System.DateTime fecha_nombre;
        private System.DateTime fecha_contacto;
        private System.DateTime fecha_idTipoCalificacion;
        private System.DateTime fecha_idSector;
        private System.DateTime fecha_idSubSector;
        private System.DateTime fecha_vinculo;
        private System.DateTime fecha_origenContacto;
        private System.DateTime fecha_idTratamiento;
        private System.DateTime fecha_documento;
        private System.DateTime fecha_idTipoDocumento;
        private System.DateTime fecha_cuit;
        private System.DateTime fecha_idProfesion;
        private System.DateTime fecha_idCargo;
        private System.DateTime fecha_domicilios;
        private System.DateTime fecha_telefonos;
        private System.DateTime fecha_emails;
        private System.DateTime fecha_notas;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public System.DateTime Fecha_Codigo
        {
            get { return this.fecha_codigo; }
            set { this.fecha_codigo = value; }
        }

        public System.DateTime Fecha_Nombre
        {
            get { return this.fecha_nombre; }
            set { this.fecha_nombre = value; }
        }

        public System.DateTime Fecha_Contacto
        {
            get { return this.fecha_contacto; }
            set { this.fecha_contacto = value; }
        }

        public System.DateTime Fecha_TipoCalificacion
        {
            get { return this.fecha_idTipoCalificacion; }
            set { this.fecha_idTipoCalificacion = value; }
        }

        public System.DateTime Fecha_Sector
        {
            get { return this.fecha_idSector; }
            set { this.fecha_idSector = value; }
        }

        public System.DateTime Fecha_SubSector
        {
            get { return this.fecha_idSubSector; }
            set { this.fecha_idSubSector = value; }
        }

        public System.DateTime Fecha_Vinculo
        {
            get { return this.fecha_vinculo; }
            set { this.fecha_vinculo = value; }
        }

        public System.DateTime Fecha_OrigenContacto
        {
            get { return this.fecha_origenContacto; }
            set { this.fecha_origenContacto = value; }
        }

        public System.DateTime Fecha_Tratamiento
        {
            get { return this.fecha_idTratamiento; }
            set { this.fecha_idTratamiento = value; }
        }

        public System.DateTime Fecha_Documento
        {
            get { return this.fecha_documento; }
            set { this.fecha_documento = value; }
        }

        public System.DateTime Fecha_TipoDocumento
        {
            get { return this.fecha_idTipoDocumento; }
            set { this.fecha_idTipoDocumento = value; }
        }

        public System.DateTime Fecha_Cuit
        {
            get { return this.fecha_cuit; }
            set { this.fecha_cuit = value; }
        }

        public System.DateTime Fecha_Profesion
        {
            get { return this.fecha_idProfesion; }
            set { this.fecha_idProfesion = value; }
        }

        public System.DateTime Fecha_Cargo
        {
            get { return this.fecha_idCargo; }
            set { this.fecha_idCargo = value; }
        }

        public System.DateTime Fecha_Domicilios
        {
            get { return this.fecha_domicilios; }
            set { this.fecha_domicilios = value; }
        }

        public System.DateTime Fecha_Telefonos
        {
            get { return this.fecha_telefonos; }
            set { this.fecha_telefonos = value; }
        }

        public System.DateTime Fecha_Emails
        {
            get { return this.fecha_emails; }
            set { this.fecha_emails = value; }
        }

        public System.DateTime Fecha_Notas
        {
            get { return this.fecha_notas; }
            set { this.fecha_notas = value; }
        }      

        #endregion

    }
}
