using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    public class EmpresaHistorico : Entity<EmpresaHistorico, EmpresaHistoricoDataContracts>
    {
        #region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  PersonaHistorico
		/// </summary>
		public  EmpresaHistorico()
		{
		}
		#endregion

        #region A T T R I B U T E S
        private int id;
        private System.DateTime fecha_codigo;
        private System.DateTime fecha_nombre;
        private System.DateTime fecha_contacto;
        private System.DateTime fecha_TipoCalificacion;
        private System.DateTime fecha_Sector;
        private System.DateTime fecha_SubSector;
        private System.DateTime fecha_vinculo;
        private System.DateTime fecha_origenContacto;
        private System.DateTime fecha_Tratamiento;
        private System.DateTime fecha_cuit;        
        private System.DateTime fecha_Cargo;

        private System.DateTime fecha_IIBB;
        private System.DateTime fecha_numeroInscripcion;
        private System.DateTime fecha_activo;
        private System.DateTime fecha_IVA;
        private System.DateTime fecha_web;
        private System.DateTime fecha_horario;
        
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
            get { return this.fecha_TipoCalificacion; }
            set { this.fecha_TipoCalificacion = value; }
        }

        public System.DateTime Fecha_Sector
        {
            get { return this.fecha_Sector; }
            set { this.fecha_Sector = value; }
        }

        public System.DateTime Fecha_SubSector
        {
            get { return this.fecha_SubSector; }
            set { this.fecha_SubSector = value; }
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
            get { return this.fecha_Tratamiento; }
            set { this.fecha_Tratamiento = value; }
        }

        public System.DateTime Fecha_Cuit
        {
            get { return this.fecha_cuit; }
            set { this.fecha_cuit = value; }
        }

        public System.DateTime Fecha_Cargo
        {
            get { return this.fecha_Cargo; }
            set { this.fecha_Cargo = value; }
        }

        public System.DateTime Fecha_IIBB 
        {
            get { return this.fecha_IIBB; }
            set { this.fecha_IIBB = value; }        
        }

        public System.DateTime Fecha_NroInscripcion
        {
            get { return this.fecha_numeroInscripcion; }
            set { this.fecha_numeroInscripcion = value; }
        }

        public System.DateTime Fecha_Activo
        {
            get { return this.fecha_activo; }
            set { this.fecha_activo = value; }        
        }

        public System.DateTime Fecha_IVA
        {
            get { return this.fecha_IVA; }
            set { this.fecha_IVA = value; }            
        }

        public System.DateTime Fecha_Web
        {
            get { return this.fecha_web; }
            set { this.fecha_web = value; }     
        
        }

        public System.DateTime Fecha_Horario
        {
            get { return this.fecha_horario; }
            set { this.fecha_horario = value; }
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
