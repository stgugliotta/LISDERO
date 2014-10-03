using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-05-17
	/// Objeto		: DB_LISDERO.dbo.tbl_domicilio
	/// Descripcion	: 
	/// </summary>
	public class DomicilioDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Domicilio
		/// </summary>
		public  DomicilioDataContracts() 
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
			private string pais;
		
			/// <summary>
			/// 
			/// </summary>
			private int idPais;
		
			/// <summary>
			/// 
			/// </summary>
			private string provincia;
		
			/// <summary>
			/// 
			/// </summary>
			private int idProvincia;
		
			/// <summary>
			/// 
			/// </summary>
			private string ciudad;
		
			/// <summary>
			/// 
			/// </summary>
			private int idLocalidad;
		
			/// <summary>
			/// 
			/// </summary>
			private string domicilio;
		
			/// <summary>
			/// 
			/// </summary>
			private string cp;
		
			/// <summary>
			/// 
			/// </summary>
			private string piso;
		
			/// <summary>
			/// 
			/// </summary>
			private string depto;
		
			/// <summary>
			/// 
			/// </summary>
			private string codigo;
		
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
			/// <value>string</value>
			public string Pais
				{
					get { return this.pais; }
					set { this.pais = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdPais
				{
					get { return this.idPais; }
					set { this.idPais = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Provincia
				{
					get { return this.provincia; }
					set { this.provincia = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdProvincia
				{
					get { return this.idProvincia; }
					set { this.idProvincia = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Ciudad
				{
					get { return this.ciudad; }
					set { this.ciudad = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdLocalidad
				{
					get { return this.idLocalidad; }
					set { this.idLocalidad = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Domicilio_
				{
					get { return this.domicilio; }
					set { this.domicilio = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Cp
				{
					get { return this.cp; }
					set { this.cp = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Piso
				{
					get { return this.piso; }
					set { this.piso = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Depto
				{
					get { return this.depto; }
					set { this.depto = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>string</value>
			public string Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
				
		#endregion
	}
}
