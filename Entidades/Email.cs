using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Email
	/// </summary>
	public class Email : Entity <Email, EmailDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Email
		/// </summary>
		public  Email()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string email;
		private int idGrupoMail;
		private int idRelacion;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Emaill
				{
					get { return this.email; }
					set { this.email = value; }
				}
		
			public int IdGrupoMail
				{
					get { return this.idGrupoMail; }
					set { this.idGrupoMail = value; }
				}
		
			public int IdRelacion
				{
					get { return this.idRelacion; }
					set { this.idRelacion = value; }
				}
		
		
		#endregion
	}
}
