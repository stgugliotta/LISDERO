using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-05-16
	/// Objeto		: DB_LISDERO.dbo.tbl_telefono
	/// Descripcion	: 
	/// </summary>
	public class TelefonoDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Telefono
		/// </summary>
		public  TelefonoDataContracts() 
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
			private string numero;
		
			/// <summary>
			/// 
			/// </summary>
			private int idTipo;
		
			/// <summary>
			/// 
			/// </summary>
			private int codigo;
		
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
			public string Numero
				{
					get { return this.numero; }
					set { this.numero = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdTipo
				{
					get { return this.idTipo; }
					set { this.idTipo = value; }
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
				
		#endregion
	}
}
