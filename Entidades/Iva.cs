using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_IVA
	/// </summary>
	public class Iva : Entity <Iva, IvaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Iva
		/// </summary>
		public  Iva()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private string descripcion;
		private bool activo;
		private string porcentaje;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public string Descripcion
				{
					get { return this.descripcion; }
					set { this.descripcion = value; }
				}
		
			public bool Activo
				{
					get { return this.activo; }
					set { this.activo = value; }
				}
		
			public string Porcentaje
				{
					get { return this.porcentaje; }
					set { this.porcentaje = value; }
				}
		
		
		#endregion
	}
}
