using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Profesion 
    /// </summary>
  	public class ProfesionAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Profesion 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Profesion Load(int id)
			{
				Profesion oReturn = new Profesion();
				try
				{
					using (DALProfesion dalProfesion = new DALProfesion())
                	{
						oReturn = dalProfesion.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Profesion
        /// </summary>
        /// <param name="oProfesion"></param>
      	public void Delete(Profesion oProfesion)
			{
				try
				{
					using (DALProfesion dalProfesion = new DALProfesion())
					{
						dalProfesion.Delete(oProfesion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Profesion 
		/// </summary>
        /// <param name="oProfesion"></param>
     	public void Update(Profesion oProfesion)
			{
				try
				{
					using (DALProfesion dalProfesion = new DALProfesion())
					{
						dalProfesion.Update(oProfesion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Profesion 
		/// </summary>
        /// <param name="oProfesion"></param>
     	public void Insert(Profesion oProfesion)
		{
				try
				{
					using (DALProfesion dalProfesion = new DALProfesion())
					{
						dalProfesion.Insert(oProfesion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Profesion 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
		public Profesion GetProfesion(int id)
			{
				Profesion oReturn = new Profesion();
				try
				{
					using (DALProfesion dalProfesion = new DALProfesion())
                	{
						oReturn = dalProfesion.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Profesion
		/// de la tabla dbo.TBL_Profesion
        /// </summary>
        /// <returns></returns>
       	public List<Profesion> GetAllProfesions()
		{
			List<Profesion> lstProfesion = new List<Profesion>();
            try
            {
                using (DALProfesion dalProfesion = new DALProfesion())
                {
                    lstProfesion = dalProfesion.GetAllProfesions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProfesion;
			
			}
	}
}