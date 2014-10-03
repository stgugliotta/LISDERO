using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Domicilio
	/// </summary>
	public class Domicilio : Entity <Domicilio, DomicilioDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Domicilio
		/// </summary>
		public  Domicilio()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string pais;
		private int idPais;
		private string provincia;
		private int idProvincia;
		private string ciudad;
		private int idLocalidad;
		private string domicilio;
		private string cp;
		private string piso;
		private string depto;
		private string codigo;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Pais
				{
					get { return this.pais; }
					set { this.pais = value; }
				}
		
			public int IdPais
				{
					get { return this.idPais; }
					set { this.idPais = value; }
				}
		
			public string Provincia
				{
					get { return this.provincia; }
					set { this.provincia = value; }
				}
		
			public int IdProvincia
				{
					get { return this.idProvincia; }
					set { this.idProvincia = value; }
				}
		
			public string Ciudad
				{
					get { return this.ciudad; }
					set { this.ciudad = value; }
				}
		
			public int IdLocalidad
				{
					get { return this.idLocalidad; }
					set { this.idLocalidad = value; }
				}
		
			public string Domicilio_
				{
					get { return this.domicilio; }
					set { this.domicilio = value; }
				}
		
			public string Cp
				{
					get { return this.cp; }
					set { this.cp = value; }
				}
		
			public string Piso
				{
					get { return this.piso; }
					set { this.piso = value; }
				}
		
			public string Depto
				{
					get { return this.depto; }
					set { this.depto = value; }
				}
		
			public string Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
		
		
		#endregion
	}
}
