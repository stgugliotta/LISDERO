using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-06-02
	/// Objeto		: DB_LISDERO.dbo.tbl_ciudad
	/// Descripcion	: 
	/// </summary>
	public class CiudadDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Ciudad
		/// </summary>
		public  CiudadDataContracts() 
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
			private string descripcion;
		
			/// <summary>
			/// 
			/// </summary>
			private int idProvincia;
		
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
			public string Descripcion
				{
					get { return this.descripcion; }
					set { this.descripcion = value; }
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
				
		#endregion
	}
}
