using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-05-16
	/// Objeto		: DB_LISDERO.dbo.tbl_calificacion
	/// Descripcion	: 
	/// </summary>
	public class CalificacionDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Calificacion
		/// </summary>
		public  CalificacionDataContracts() 
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
				
		#endregion
	}
}
