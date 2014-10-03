using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Telefono
	/// </summary>
	public class Telefono : Entity <Telefono, TelefonoDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Telefono
		/// </summary>
		public  Telefono()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string numero;
		private int idTipo;
		private int codigo;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Numero
				{
					get { return this.numero; }
					set { this.numero = value; }
				}
		
			public int IdTipo
				{
					get { return this.idTipo; }
					set { this.idTipo = value; }
				}
		
			public int Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
		
		
		#endregion
	}
}
