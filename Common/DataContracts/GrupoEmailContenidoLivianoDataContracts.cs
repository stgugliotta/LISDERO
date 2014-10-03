using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    public class GrupoEmailContenidoLivianoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto GrupoEmailContenidoLiviano
        /// </summary>
        public GrupoEmailContenidoLivianoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idGrupoEmail;

        /// <summary>
        /// 
        /// </summary>
        private string codigoRelacion;

        
        //agregado por Natalia 22/01/2014
        //

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

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdGrupoEmail
        {
            get { return this.idGrupoEmail; }
            set { this.idGrupoEmail = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string CodigoRelacion
        {
            get { return this.codigoRelacion; }
            set { this.codigoRelacion = value; }
        }


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
             set { this.campo2 = value; }
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

