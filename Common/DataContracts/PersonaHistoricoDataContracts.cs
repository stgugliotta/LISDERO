using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    public class PersonaHistoricoDataContracts
    {
        #region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Persona
		/// </summary>
		public  PersonaHistoricoDataContracts() 
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		
			private int id;			
			private DateTime fecha_codigo;	
			private DateTime fecha_nombre;			
			private DateTime fecha_contacto;		
			private DateTime fecha_idTipoCalificacion;
            private DateTime fecha_idSector;
			private DateTime fecha_idSubSector;
			private DateTime fecha_vinculo;			
			private DateTime fecha_origenContacto;
            private DateTime fecha_idTratamiento;
			private DateTime fecha_documento;		
			private DateTime fecha_idTipoDocumento;		
			private DateTime fecha_cuit;
            private DateTime fecha_idProfesion;
			private DateTime fecha_idCargo;
            private DateTime fecha_domicilios;
            private DateTime fecha_telefonos;
            private DateTime fecha_emails;
            private DateTime fecha_notas;
		
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
					set { this.fecha_contacto= value; }
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

            public System.DateTime Fecha_Notas
            {
                get { return this.fecha_notas; }
                set { this.fecha_notas = value; }
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
				
		#endregion

    }
}
