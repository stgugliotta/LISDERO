using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Calificacion 
    /// </summary>
  	public class CalificacionAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Calificacion 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Calificacion Load(int id)
			{
				Calificacion oReturn = new Calificacion();
				try
				{
					using (DALCalificacion dalCalificacion = new DALCalificacion())
                	{
						oReturn = dalCalificacion.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Calificacion
        /// </summary>
        /// <param name="oCalificacion"></param>
      	public void Delete(Calificacion oCalificacion)
			{
				try
				{
					using (DALCalificacion dalCalificacion = new DALCalificacion())
					{
						dalCalificacion.Delete(oCalificacion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Calificacion 
		/// </summary>
        /// <param name="oCalificacion"></param>
     	public void Update(Calificacion oCalificacion)
			{
				try
				{
					using (DALCalificacion dalCalificacion = new DALCalificacion())
					{
						dalCalificacion.Update(oCalificacion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Calificacion 
		/// </summary>
        /// <param name="oCalificacion"></param>
     	public void Insert(Calificacion oCalificacion)
		{
				try
				{
					using (DALCalificacion dalCalificacion = new DALCalificacion())
					{
						dalCalificacion.Insert(oCalificacion);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Calificacion 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>  
		/// <returns></returns>
		public Calificacion GetCalificacion(int id)
			{
				Calificacion oReturn = new Calificacion();
				try
				{
					using (DALCalificacion dalCalificacion = new DALCalificacion())
                	{
						oReturn = dalCalificacion.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Calificacion
		/// de la tabla dbo.TBL_Calificacion
        /// </summary>
        /// <returns></returns>
       	public List<Calificacion> GetAllCalificacions()
		{
			List<Calificacion> lstCalificacion = new List<Calificacion>();
            try
            {
                using (DALCalificacion dalCalificacion = new DALCalificacion())
                {
                    lstCalificacion = dalCalificacion.GetAllCalificacions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCalificacion;
			
			}
	}
}
