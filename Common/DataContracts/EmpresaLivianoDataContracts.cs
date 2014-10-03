using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-06-23
	/// Objeto		: DB_LISDERO.dbo.tbl_empresaliviano
	/// Descripcion	: 
	/// </summary>
	public class EmpresaLivianoDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto EmpresaLiviano
		/// </summary>
		public  EmpresaLivianoDataContracts() 
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
			private string codigo;
		
			/// <summary>
			/// 
			/// </summary>
			private string nombre;
		
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
			public string Codigo
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

            public string NombreYCodigo
            {
                get { return this.nombre + " (" + Codigo + ")"; }

            }
				
		#endregion
	}
}
