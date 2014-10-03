using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Contacto
	/// </summary>
	public class Contacto : Entity <Contacto, ContactoDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Contacto
		/// </summary>
		public  Contacto()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int codigo;
		private int idTipoContacto;
		private int idContacto;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
		
			public int IdTipoContacto
				{
					get { return this.idTipoContacto; }
					set { this.idTipoContacto = value; }
				}
		
			public int IdContacto
				{
					get { return this.idContacto; }
					set { this.idContacto = value; }
				}
		
		
		#endregion
	}
}
