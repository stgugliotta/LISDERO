using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Agenda
    /// </summary>
    public class TipoEvento : Entity<TipoEvento, TipoEventoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  Agenda
        /// </summary>
        public TipoEvento()
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

        #region P U B L I C    P R O P E R T I E S
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
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string RgbColor
        {
            get { return this.rgbColor; }
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
