using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_GrupoEmail
	/// </summary>
	public class GrupoEmailContenido : Entity <GrupoEmailContenido, GrupoEmailContenidoDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
        /// Constructor Standard de  GrupoEmailContenido
		/// </summary>
        public GrupoEmailContenido()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int idGrupoEmail;
		private string codigoRelacion;
        private string cargo;
        private string nombreempresa;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int IdGrupoEmail
				{
					get { return this.idGrupoEmail; }
                    set { this.idGrupoEmail = value; }
				}
		
			public string CodigoRelacion
				{
					get { return this.codigoRelacion; }
                    set { this.codigoRelacion = value; }
				}
           //Agregado por Natalia 22/01/2014 
           public string Cargo
            {
                get { return this.cargo; }
                set { this.cargo = value; }
            }

           public string NombreEmpresa
           {
               get { return this.nombreempresa; }
               set { this.nombreempresa = value; }
           }		
		
		
		#endregion
	}
}
