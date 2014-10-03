using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Ciudad 
    /// </summary>
  	public class CiudadAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Ciudad 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Ciudad Load(int id)
			{
				Ciudad oReturn = new Ciudad();
				try
				{
					using (DALCiudad dalCiudad = new DALCiudad())
                	{
						oReturn = dalCiudad.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Ciudad
        /// </summary>
        /// <param name="oCiudad"></param>
      	public void Delete(Ciudad oCiudad)
			{
				try
				{
					using (DALCiudad dalCiudad = new DALCiudad())
					{
						dalCiudad.Delete(oCiudad);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Ciudad 
		/// </summary>
        /// <param name="oCiudad"></param>
     	public void Update(Ciudad oCiudad)
			{
				try
				{
					using (DALCiudad dalCiudad = new DALCiudad())
					{
						dalCiudad.Update(oCiudad);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Ciudad 
		/// </summary>
        /// <param name="oCiudad"></param>
     	public void Insert(Ciudad oCiudad)
		{
				try
				{
					using (DALCiudad dalCiudad = new DALCiudad())
					{
						dalCiudad.Insert(oCiudad);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Ciudad 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
		/// <returns></returns>
		public Ciudad GetCiudad(int id)
			{
				Ciudad oReturn = new Ciudad();
				try
				{
					using (DALCiudad dalCiudad = new DALCiudad())
                	{
						oReturn = dalCiudad.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Ciudad
		/// de la tabla dbo.TBL_Ciudad
        /// </summary>
        /// <returns></returns>
       	public List<Ciudad> GetAllCiudads()
		{
			List<Ciudad> lstCiudad = new List<Ciudad>();
            try
            {
                using (DALCiudad dalCiudad = new DALCiudad())
                {
                    lstCiudad = dalCiudad.GetAllCiudads();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
            return lstCiudad;
			
			}

        public List<Ciudad> GetAllCiudadesPorIdProvincia(int idProvincia)
		{
			List<Ciudad> lstCiudad = new List<Ciudad>();
            try
            {
                using (DALCiudad dalCiudad = new DALCiudad())
                {
                    lstCiudad = dalCiudad.GetAllCiudadesPorIdProvincia(idProvincia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
            return lstCiudad;
			
			}
	}
}
