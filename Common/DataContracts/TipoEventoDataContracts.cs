using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2013-10-29
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_tipo_evento
    /// Descripcion	: 
    /// </summary>
    public class TipoEventoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto TipoEvento
        /// </summary>
        public TipoEventoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int id;

        /// <summary>
        /// 
        /// </summary>
        private string descripcion;

        /// <summary>
        /// 
        /// </summary>
        private string rgbColor;


        private Nullable<DateTime> fechaDeshabilitacion;



        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string Descripcion
        {
            get { return this.descripcion ; }
            set { this.descripcion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string RgbColor
        {
            get { return this.rgbColor ; }
            set { this.rgbColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>DateTime</value>
        public Nullable<DateTime> FechaDeshabilitacion
        {
            get { return this.fechaDeshabilitacion; }
            set { this.fechaDeshabilitacion = value; }
        }

        #endregion
    }
}
