using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_EmpresaLiviano
	/// </summary>
	public class EmpresaLiviano : Entity <EmpresaLiviano, EmpresaLivianoDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  EmpresaLiviano
		/// </summary>
		public  EmpresaLiviano()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string codigo;
		private string nombre;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
		
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
		
		
		#endregion
	}
}
