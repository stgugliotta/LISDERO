using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2013-05-17
	/// Objeto		: DB_LISDERO.dbo.tbl_email
	/// Descripcion	: 
	/// </summary>
	public class EmailDataContracts
	{
		#region C O N S T R U C T O R S 
		/// <summary>
		/// Constructor standard para el objeto Email
		/// </summary>
		public  EmailDataContracts() 
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
			private string email;
		
			/// <summary>
			/// 
			/// </summary>
			private int idGrupoMail;
		
			/// <summary>
			/// 
			/// </summary>
			private int idRelacion;
		
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
			public string Emaill
				{
					get { return this.email; }
					set { this.email = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdGrupoMail
				{
					get { return this.idGrupoMail; }
					set { this.idGrupoMail = value; }
				}
				
			/// <summary>
			/// 
			/// </summary>
			/// <value>int</value>
			public int IdRelacion
				{
					get { return this.idRelacion; }
					set { this.idRelacion = value; }
				}
				
		#endregion
	}
}
