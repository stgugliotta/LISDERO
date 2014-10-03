using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto GrupoEmailContenido
    /// </summary>
    public class GrupoEmailContenidoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto GrupoEmailContenido
        /// </summary>
        /// <param name="idGrupoEmail"></param>		
        /// <param name="codigoRelacion"></param>		
        /// <returns></returns>
        public GrupoEmailContenido Load(int idGrupoEmail, string codigoRelacion)
        {
            GrupoEmailContenido oReturn = new GrupoEmailContenido();
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    oReturn = dalGrupoEmailContenido.Load(idGrupoEmail, codigoRelacion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto GrupoEmailContenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        public void Delete(GrupoEmailContenido oGrupoEmailContenido)
        {
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    dalGrupoEmailContenido.Delete(oGrupoEmailContenido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto GrupoEmailContenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        public void Update(GrupoEmailContenido oGrupoEmailContenido)
        {
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    dalGrupoEmailContenido.Update(oGrupoEmailContenido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto GrupoEmailContenido
        /// </summary>
        /// <param name="oGrupoEmail"></param>
        public void Insert(GrupoEmailContenido oGrupoEmailContenido)
        {
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    dalGrupoEmailContenido.Insert(oGrupoEmailContenido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto GrupoEmailContenido 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public GrupoEmailContenido GetGrupoEmailContenido(int idGrupoEmail, string codigoRelacion)
        {
            GrupoEmailContenido oReturn = new GrupoEmailContenido();
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    oReturn = dalGrupoEmailContenido.Load(idGrupoEmail, codigoRelacion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos GrupoEmailContenido
        /// de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <returns></returns>
        public List<GrupoEmailContenido> GetAllGrupoEmailContenido()
        {
            List<GrupoEmailContenido> lstGrupoEmailContenido = new List<GrupoEmailContenido>();
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    lstGrupoEmailContenido = dalGrupoEmailContenido.GetAllGrupoEmailContenido();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupoEmailContenido;

        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos GrupoEmailContenido
        /// de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <returns></returns>
        public List<GrupoEmailContenido> GetAllGrupoEmailContenidoByIdGrupoEmail(int idGrupoEmail)
        {
            List<GrupoEmailContenido> lstGrupoEmailContenido = new List<GrupoEmailContenido>();
            try
            {
                using (DALGrupoEmailContenido dalGrupoEmailContenido = new DALGrupoEmailContenido())
                {
                    lstGrupoEmailContenido = dalGrupoEmailContenido.GetAllGrupoEmailContenidoByIdGrupoEmail(idGrupoEmail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupoEmailContenido;

        }

        



    }
}
