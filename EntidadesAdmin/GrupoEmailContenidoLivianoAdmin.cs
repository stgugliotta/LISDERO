using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    public class GrupoEmailContenidoLivianoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto GrupoEmailContenido
        /// </summary>
        /// <param name="idGrupoEmail"></param>		
        /// <param name="codigoRelacion"></param>		
        /// <returns></returns>
        public GrupoEmailContenidoLiviano Load(int idGrupoEmail, string codigoRelacion)
        {
            GrupoEmailContenidoLiviano oReturn = new GrupoEmailContenidoLiviano();
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
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
        public void Delete(GrupoEmailContenidoLiviano oGrupoEmailContenido)
        {
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
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
        public void Update(GrupoEmailContenidoLiviano oGrupoEmailContenido)
        {
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
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
        public void Insert(GrupoEmailContenidoLiviano oGrupoEmailContenido)
        {
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
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
        /// M?todo para traer una lista de la totalidad de los objetos GrupoEmailContenido
        /// de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <returns></returns>       

        //Agregado por Natalia
        public List<GrupoEmailContenidoLiviano> GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int idGrupoEmail)
        {
            List<GrupoEmailContenidoLiviano> lstGrupoEmailContenido = new List<GrupoEmailContenidoLiviano>();
            try 
            { 
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
                {
                    lstGrupoEmailContenido = dalGrupoEmailContenido.GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(idGrupoEmail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupoEmailContenido;

        }


        //Agregado por Natalia
        public List<GrupoEmailContenidoLiviano> GetAllGrupoEmailContenidoLivianoByIdGrupoEmail(int idGrupoEmail)
        {
            List<GrupoEmailContenidoLiviano> lstGrupoEmailContenido = new List<GrupoEmailContenidoLiviano>();
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
                {
                    lstGrupoEmailContenido = dalGrupoEmailContenido.GetAllGrupoEmailContenidoLivianoByIdGrupoEmail(idGrupoEmail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupoEmailContenido;

        }

        //Agregado por Natalia
        public List<GrupoEmailContenidoLiviano> GetAllGrupoEmailContenidoLivianoByEmail(int idGrupoEmail, string idCodigoRelacion)
        {
            List<GrupoEmailContenidoLiviano> lstGrupoEmailContenido = new List<GrupoEmailContenidoLiviano>();
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
                {
                    lstGrupoEmailContenido = dalGrupoEmailContenido.GetAllGrupoEmailContenidoLivianoByEmail(idGrupoEmail,idCodigoRelacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupoEmailContenido;

        }

        public void Combinar(int id_GrupoEmailNuevo, int id_GrupoEmailViejo, string id_CodigoRelacion)
        {
            try
            {
                using (DALGrupoEmailContenidoLiviano dalGrupoEmailContenido = new DALGrupoEmailContenidoLiviano())
                {
                    dalGrupoEmailContenido.Combinar(id_GrupoEmailNuevo,id_GrupoEmailViejo,id_CodigoRelacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
