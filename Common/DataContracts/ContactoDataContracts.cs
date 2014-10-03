using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-05-15
	/// Objeto		: DB_LISDERO.dbo.tbl_contacto
	/// Descripcion	: 
	/// </summary>
	public class ContactoDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Contacto
		/// </summary>
		public  ContactoDataContracts() 
				{
				}
		#endregion
		
		#region A T T R I B U T E S
			/// <summary>
			/// 
			/// </summary>
			private int codigo;
		
			/// <summary>
			/// 
			/// </summary>
			private int idTipoContacto;
		
			/// <summary>
			/// 
			/// </summary>
			private int idContacto;
		
		#endregion
		
		#region P U B L I C  P R O P E R T I E S
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
			/// <value>int</value>
			public int IdTipoContacto
				{
					get { return this.idTipoContacto; }
					set { this.idTipoContacto = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdContacto
				{
					get { return this.idContacto; }
					set { this.idContacto = value; }
				}
				
		#endregion
	}
}
