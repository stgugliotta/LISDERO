using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-06-22
	/// Objeto		: DB_LISDERO.dbo.tbl_iibb
	/// Descripcion	: 
	/// </summary>
	public class IIBBDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto IIBB
		/// </summary>
		public  IIBBDataContracts() 
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
			private bool activo;
		
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
            public string Descripcion
            {
                get { return this.descripcion; }
                set { this.descripcion = value; }
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
				
		#endregion
	}
}
