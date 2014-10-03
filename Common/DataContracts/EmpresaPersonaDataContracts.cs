using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_accion
    /// Descripcion	: 
    /// </summary>
    public class EmpresaPersonaDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto EmpresaPersona
        /// </summary>
        public EmpresaPersonaDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idEmpresaPersona;

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        /// <summary>
        /// 
        /// </summary>
        private System.DateTime fechaEmpresaPersona;

        /// <summary>
        /// 
        /// </summary>
        private int idEstado;

        /// <summary>
        /// 
        /// </summary>
        private string observacion;

        /// <summary>
        /// 
        /// </summary>
        private string informacionComplementaria;

        /// <summary>
        /// 
        /// </summary>
        private int idFactura;

        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;


        /// <summary>
        /// 
        /// </summary>
        private int idCliente;

        private string tipo;

        /// <summary>
        /// 
        /// </summary>
        private string nombre;

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

        public string NombreYCodigo
        {
            get
            {
                if (this.nombre.Contains("#")) this.nombre.Replace("#", string.Empty);
                return this.nombre + "#(" + Codigo + ")";
            }

        }

        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
    }
}
