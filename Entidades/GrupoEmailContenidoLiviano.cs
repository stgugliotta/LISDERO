using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_GrupoEmail
    /// </summary>
    public class GrupoEmailContenidoLiviano : Entity<GrupoEmailContenidoLiviano,GrupoEmailContenidoLivianoDataContracts>
    {
       #region C O N S T R U C T O R S 
		/// <summary>
        /// Constructor Standard de  GrupoEmailContenidoLiviano
		/// </summary>
        public GrupoEmailContenidoLiviano()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int idGrupoEmail;
		private string codigoRelacion;
        private string cargo;
        private string nombreempresa;
        private string nombrerelacion;
        private string email;
        private string campo1;
        private string campo2;
        private string campo3;
        private string campo4;
        private string observaciones;
        private bool envioemail;
        private int codigoemail;
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

           public string NombreRelacion
           {
               get { return this.nombrerelacion; }
               set { this.nombrerelacion = value; }
           }

           public string Email
           {
               get { return this.email; }
               set { this.email = value; }
           }

           public string Campo1
           {
               get { return this.campo1; }
               set { this.campo1 = value; }
           }

           public string Campo2
           {
               get { return this.campo2; }
               set { this.campo2= value; }
           }

           public string Campo3
           {
               get { return this.campo3; }
               set { this.campo3 = value; }
           }

           public string Campo4
           {
               get { return this.campo4; }
               set { this.campo4 = value; }
           }

           public string Observaciones
           {
               get { return this.observaciones; }
               set { this.observaciones = value; }
           }

           public bool EnvioEmail
           {
               get { return this.envioemail; }
               set { this.envioemail = value; }
           }

           public int CodigoEmail
           {
               get { return this.codigoemail; }
               set { this.codigoemail = value; }
           }


        #endregion
    }
}
