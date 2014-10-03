using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto GrupoEmail 
    /// </summary>
    public class GrupoEmailAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto GrupoEmail 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
        public GrupoEmail Load(int id)
			{
                GrupoEmail oReturn = new GrupoEmail();
				try
				{
                    using (DALGrupoEmail dalGrupoEmail = new DALGrupoEmail())
                	{
                        oReturn = dalGrupoEmail.Load(id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto GrupoEmail
        /// </summary>
        /// <param name="oGrupoEmail"></param>
        public void Delete(GrupoEmail oGrupoEmail)
			{
				try
				{
                    using (DALGrupoEmail dalGrupoEmail = new DALGrupoEmail())
					{
                        dalGrupoEmail.Delete(oGrupoEmail);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto GrupoEmail 
		/// </summary>
        /// <param name="oGrupoEmail"></param>
        public void Update(GrupoEmail oGrupoEmail)
			{
				try
				{
                    using (DALGrupoEmail dalGrupoEmail = new DALGrupoEmail())
					{
                        dalGrupoEmail.Update(oGrupoEmail);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto GrupoEmail 
		/// </summary>
        /// <param name="oGrupoEmail"></param>
        public void Insert(GrupoEmail oGrupoEmail)
		{
				try
				{
                    using (DALGrupoEmail dalGrupoEmail = new DALGrupoEmail())
					{
                        dalGrupoEmail.Insert(oGrupoEmail);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto GrupoEmail 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
        public GrupoEmail GetGrupoEmail(int id)
			{
                GrupoEmail oReturn = new GrupoEmail();
				try
				{
                    using (DALGrupoEmail dalGrupoEmail = new DALGrupoEmail())
                	{
                        oReturn = dalGrupoEmail.Load(id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos GrupoEmail
        /// de la tabla dbo.TBL_GrupoEmail
        /// </summary>
        /// <returns></returns>
        public List<GrupoEmail> GetAllGrupoEmails()
		{
            List<GrupoEmail> lstGrupoEmail = new List<GrupoEmail>();
            try
            {
                using (DALGrupoEmail dalGrupoEmail = new DALGrupoEmail())
                {
                    lstGrupoEmail = dalGrupoEmail.GetAllGrupoEmails();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupoEmail;
			
			}
	}
}
