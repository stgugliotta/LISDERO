using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_EmpresaPersona
    /// </summary>
    public class EmpresaPersona : Entity<EmpresaPersona, EmpresaPersonaDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  EmpresaPersona
        /// </summary>
        public EmpresaPersona()
        {
        }
        #endregion

        #region A T T R I B U T E S

        private string nombre;
        private string tipo;
        private string codigo;
        #endregion



        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
    }
}
