using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Tratamiento 
    /// </summary>
  	public class TratamientoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Tratamiento 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Tratamiento Load(int id)
			{
				Tratamiento oReturn = new Tratamiento();
				try
				{
					using (DALTratamiento dalTratamiento = new DALTratamiento())
                	{
						oReturn = dalTratamiento.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Tratamiento
        /// </summary>
        /// <param name="oTratamiento"></param>
      	public void Delete(Tratamiento oTratamiento)
			{
				try
				{
					using (DALTratamiento dalTratamiento = new DALTratamiento())
					{
						dalTratamiento.Delete(oTratamiento);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Tratamiento 
		/// </summary>
        /// <param name="oTratamiento"></param>
     	public void Update(Tratamiento oTratamiento)
			{
				try
				{
					using (DALTratamiento dalTratamiento = new DALTratamiento())
					{
						dalTratamiento.Update(oTratamiento);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Tratamiento 
		/// </summary>
        /// <param name="oTratamiento"></param>
     	public void Insert(Tratamiento oTratamiento)
		{
				try
				{
					using (DALTratamiento dalTratamiento = new DALTratamiento())
					{
						dalTratamiento.Insert(oTratamiento);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Tratamiento 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
		public Tratamiento GetTratamiento(int id)
			{
				Tratamiento oReturn = new Tratamiento();
				try
				{
					using (DALTratamiento dalTratamiento = new DALTratamiento())
                	{
						oReturn = dalTratamiento.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Tratamiento
		/// de la tabla dbo.TBL_Tratamiento
        /// </summary>
        /// <returns></returns>
       	public List<Tratamiento> GetAllTratamientos()
		{
			List<Tratamiento> lstTratamiento = new List<Tratamiento>();
            try
            {
                using (DALTratamiento dalTratamiento = new DALTratamiento())
                {
                    lstTratamiento = dalTratamiento.GetAllTratamientos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTratamiento;
			
			}
	}
}
