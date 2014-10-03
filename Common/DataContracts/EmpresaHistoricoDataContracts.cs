using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    public class EmpresaHistoricoDataContracts
    {
        #region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Empresa
		/// </summary>
		public  EmpresaHistoricoDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
			private int id;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_codigo;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_nombre;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_contacto;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_TipoCalificacion;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_Sector;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_SubSector;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_vinculo;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_origenContacto;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_Tratamiento;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_cuit;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_Cargo;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_IIBB;
		
			/// <summary>
			/// 
			/// </summary>
			private System.DateTime fecha_numeroInscripcion;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_activo;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_IVA;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_web;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_horario;
		
			/// <summary>
			/// 
			/// </summary>
            private System.DateTime fecha_notas;

            private System.DateTime fecha_domicilios;
            private System.DateTime fecha_telefonos;
            private System.DateTime fecha_emails;


		#endregion

        #region P U B L I C  P R O P E R T I E S

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

            public System.DateTime Fecha_Notas
            {
                get { return this.fecha_notas; }
                set { this.fecha_notas = value; }
            }


            public System.DateTime Fecha_Emails
            {
                get { return this.fecha_emails; }
                set { this.fecha_emails = value; }
            }


            #endregion

    }
}
