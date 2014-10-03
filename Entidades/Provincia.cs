using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Provincia
	/// </summary>
	public class Provincia : Entity <Provincia, ProvinciaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Provincia
		/// </summary>
		public  Provincia()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string descripcion;
		private int idPais;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Descripcion
				{
					get { return this.descripcion; }
					set { this.descripcion = value; }
				}
		
			public int IdPais
				{
					get { return this.idPais; }
					set { this.idPais = value; }
				}
		
		
		#endregion
	}
}
