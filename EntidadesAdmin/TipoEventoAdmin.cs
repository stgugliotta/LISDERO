using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{

    /// <summary>
    /// Manejador del objeto TipoEventoAdmin
    /// </summary>
    public class TipoEventoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto TipoEventoAdmin
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public TipoEvento  Load(int id)
        {
            TipoEvento  oReturn = new TipoEvento();
            try
            {
                using (DALTipoEvento dalTipoEvento = new DALTipoEvento())
                {
                    oReturn = dalTipoEvento.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto TipoEvento
        /// </summary>
        /// <param name="oTipoEvento"></param>
        public void Delete(TipoEvento oTipoEvento)
        {
            try
            {
                using (DALTipoEvento dalTipoEvento = new DALTipoEvento())
                {
                    dalTipoEvento.Delete(oTipoEvento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto TipoEvento 
        /// </summary>
        /// <param name="oTipoEvento"></param>
        public void Update(TipoEvento oTipoEvento)
        {
            try
            {
                using (DALTipoEvento dalTipoEvento = new DALTipoEvento())
                {
                    dalTipoEvento.Update(oTipoEvento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto TipoEvento 
        /// </summary>
        /// <param name="oTipoEvento"></param>
        public void Insert(TipoEvento oTipoEvento)
        {
            try
            {
                using (DALTipoEvento dalTipoEvento = new DALTipoEvento())
                {
                    dalTipoEvento.Insert(oTipoEvento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto TipoEvento 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public TipoEvento GetTipoEvento(int id)
        {
            TipoEvento oReturn = new TipoEvento();
            try
            {
                using (DALTipoEvento dalTipoEvento = new DALTipoEvento())
                {
                    oReturn = dalTipoEvento.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos TipoEvento
        /// de la tabla dbo.MTR_TipoEvento
        /// </summary>
        /// <returns></returns>
        public List<TipoEvento> GetAllTiposDeEvento()
        {
            List<TipoEvento> lstTipoEvento = new List<TipoEvento>();
            try
            {
                using (DALTipoEvento dalTipoEvento = new DALTipoEvento())
                {
                    lstTipoEvento = dalTipoEvento.GetAllTiposDeEvento();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTipoEvento;

        }
    }
}
