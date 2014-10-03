using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Relacion
    /// </summary>
    public class Relacion : Entity<Relacion, RelacionDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Relacion
        /// </summary>
        public Relacion()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int codigo1;

        private int codigo2;

        private int idTipoRelacion;

        private int idCargo;

        private string textoRelacion;

        #endregion

        #region P U B L I C    P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int Codigo1
        {
            get { return this.codigo1; }
            set { this.codigo1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int Codigo2
        {
            get { return this.codigo2; }
            set { this.codigo2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdTipoRelacion
        {
            get { return this.idTipoRelacion; }
            set { this.idTipoRelacion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdCargo
        {
            get { return this.idCargo; }
            set { this.idCargo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string TextoRelacion
        {
            get { return this.textoRelacion; }
            set { this.textoRelacion = value; }
        }

        #endregion
    }
}
