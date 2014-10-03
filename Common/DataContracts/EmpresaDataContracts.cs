using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-05-16
	/// Objeto		: DB_LISDERO.dbo.tbl_empresa
	/// Descripcion	: 
	/// </summary>
	public class EmpresaDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Empresa
		/// </summary>
		public  EmpresaDataContracts() 
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
			private int codigo;
		
			/// <summary>
			/// 
			/// </summary>
			private string nombre;
		
			/// <summary>
			/// 
			/// </summary>
			private string contacto;
		
			/// <summary>
			/// 
			/// </summary>
			private int idTipoCalificacion;
		
			/// <summary>
			/// 
			/// </summary>
			private int idSector;
		
			/// <summary>
			/// 
			/// </summary>
			private int idSubSector;
		
			/// <summary>
			/// 
			/// </summary>
			private string vinculo;
		
			/// <summary>
			/// 
			/// </summary>
			private string origenContacto;
		
			/// <summary>
			/// 
			/// </summary>
			private int idTratamiento;
		
			/// <summary>
			/// 
			/// </summary>
			private string cuit;
		
			/// <summary>
			/// 
			/// </summary>
			private int idCargo;
		
			/// <summary>
			/// 
			/// </summary>
			private int idIIBB;
		
			/// <summary>
			/// 
			/// </summary>
			private string numeroInscripcion;
		
			/// <summary>
			/// 
			/// </summary>
			private bool activo;
		
			/// <summary>
			/// 
			/// </summary>
			private int idIVA;
		
			/// <summary>
			/// 
			/// </summary>
			private string web;
		
			/// <summary>
			/// 
			/// </summary>
			private string horario;
		
			/// <summary>
			/// 
			/// </summary>
			private string notas;


            private List<DomicilioDataContracts> domicilios;
            private List<TelefonoDataContracts> telefonos;
            private List<EmailDataContracts> emails;

		#endregion
		
		#region P U B L I C  P R O P E R T I E S
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Contacto
				{
					get { return this.contacto; }
					set { this.contacto = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdTipoCalificacion
				{
					get { return this.idTipoCalificacion; }
					set { this.idTipoCalificacion = value; }
				}

            public List<DomicilioDataContracts> Domicilios
            {
                get { return this.domicilios; }
                set { this.domicilios = value; }
            }

            public List<TelefonoDataContracts> Telefonos
            {
                get { return this.telefonos; }
                set { this.telefonos = value; }
            }

            public List<EmailDataContracts> Emails
            {
                get { return this.emails; }
                set { this.emails = value; }
            }
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdSector
				{
					get { return this.idSector; }
					set { this.idSector = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdSubSector
				{
					get { return this.idSubSector; }
					set { this.idSubSector = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Vinculo
				{
					get { return this.vinculo; }
					set { this.vinculo = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string OrigenContacto
				{
					get { return this.origenContacto; }
					set { this.origenContacto = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdTratamiento
				{
					get { return this.idTratamiento; }
					set { this.idTratamiento = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Cuit
				{
					get { return this.cuit; }
					set { this.cuit = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdCargo
				{
					get { return this.idCargo; }
					set { this.idCargo = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdIIBB
				{
					get { return this.idIIBB; }
					set { this.idIIBB = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string NumeroInscripcion
				{
					get { return this.numeroInscripcion; }
					set { this.numeroInscripcion = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>bool</value>
			public bool Activo
				{
					get { return this.activo; }
					set { this.activo = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdIVA
				{
					get { return this.idIVA; }
					set { this.idIVA = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Web
				{
					get { return this.web; }
					set { this.web = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Horario
				{
					get { return this.horario; }
					set { this.horario = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Notas
				{
					get { return this.notas; }
					set { this.notas = value; }
				}
				
		#endregion
	}
}
